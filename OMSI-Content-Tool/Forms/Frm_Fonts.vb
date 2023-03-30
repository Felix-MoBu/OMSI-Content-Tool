'by Felix Modellbusse ;) (MoBu) 2019
Imports System.ComponentModel

Public Class Frm_Fonts
    Dim alleFonts As New List(Of OMSI_Font)

    Private Sub Frm_Fonts_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Location = New Point(Frm_Main.Width / 2 - Me.Width / 2, Frm_Main.Height / 2 - Me.Height / 2)
        Dim fontPath As String = My.Settings.OmsiPfad & "\Fonts"

        For Each file In My.Computer.FileSystem.GetFiles(fontPath)
            If Not file.Substring(file.Length - 4) = ".oft" Then Continue For

            Dim lines As String() = My.Computer.FileSystem.ReadAllText(file).Split(vbCr)

            For ctline = 0 To lines.Count - 1

                If lines(ctline).Replace(vbLf, "") = "[newfont]" Then
                    Dim newFont As New OMSI_Font
                    With newFont
                        .filename = New Filename(file)
                        .name = lines(ctline + 1).Replace(vbLf, "")
                        .bitmap = New Filename(lines(ctline + 2).Replace(vbLf, ""), fontPath)
                        .alpha = New Filename(lines(ctline + 3).Replace(vbLf, ""), fontPath)
                        .height = lines(ctline + 4).Replace(vbLf, "")

                        For Each textTexture In Frm_Main.getProj.model.TextTexturen
                            If textTexture.font = .name Then .isUsed = True
                        Next

                        If Not System.IO.File.Exists(.bitmap) Then
                            Log.Add("Bitmap konnte nicht geladen werden Font: " & .name & " Datei: " & .bitmap, Log.TYPE_WARNUNG)
                            Continue For
                        End If

                        If Not System.IO.File.Exists(.alpha) Then
                            Log.Add("AlphaMap konnte nicht geladen werden Font: " & .name & " Datei: " & .alpha, Log.TYPE_WARNUNG)
                            Continue For
                        End If
                    End With
                    alleFonts.Add(newFont)
                End If


                If lines(ctline).Replace(vbLf, "") = "[char]" Then
                    If lines(ctline + 2).Replace(vbLf, "") < " " Then
                        alleFonts(alleFonts.Count - 1).left = lines(ctline + 2).Replace(vbLf, "")
                        alleFonts(alleFonts.Count - 1).top = lines(ctline + 4).Replace(vbLf, "")

                        Exit For
                    End If
                End If

            Next
        Next

        For Each Ufont In Frm_Main.getProj.model.TextTexturen
            Dim found As Boolean = False
            For Each OFont In alleFonts
                If OFont.name = Ufont.font Then
                    found = True
                    Exit For
                End If
            Next
            If Not found Then
                Log.Add("Die verwendete Font konnte nicht gefunden werden: " & Ufont.name)
            End If
        Next

        draw()

        Me.Text = "Fonts (" & alleFonts.Count & ")"
    End Sub


    Private Sub TBSuche_TextChanged(sender As Object, e As EventArgs) Handles TBSuche.TextChanged
        clear()
        draw()
    End Sub

    Private Sub clear()
        For ct = 1 To PMain.Controls.Count - 2
            PMain.Controls.Remove(PMain.Controls(2))
        Next
    End Sub

    Private Sub draw(Optional limit As Integer = 50, Optional start As Integer = 0)
        Dim t As Integer = 32 - PMain.VerticalScroll.Value
        Dim l As Integer = 220
        Dim ct As Integer = 0

        For Each OFont In alleFonts
            If LCase(OFont.name).Contains(LCase(TBSuche.Text)) Then
                If (CBUsedOnly.Checked And OFont.isUsed) Or Not CBUsedOnly.Checked Then
                    If ct < limit And ct >= start Then
                        Dim PL As New Panel
                        With PL
                            .Top = t
                            .Left = l
                            .Height = 120
                            .Width = 200
                            .BorderStyle = BorderStyle.FixedSingle
                            If OFont.isUsed Then .BackColor = Color.Green

                            Dim LB As New Label
                            With LB
                                .Top = 95
                                .Left = 5
                                .Text = OFont.name
                                .Width = 190
                                .Height = 30
                                .Name = ct
                                .TextAlign = ContentAlignment.TopCenter
                                AddHandler .Click, AddressOf font_click
                            End With
                            .Controls.Add(LB)

                            Dim bmp As New Bitmap(100, OFont.height)
                            Dim bmp_alt As New Bitmap(Image.FromFile(OFont.alpha))
                            Dim rect1 As New Rectangle(OFont.top, OFont.left, OFont.height * 2.2, OFont.height)
                            Dim rect2 As New Rectangle(0, 0, 200, 90)

                            Using gr As Graphics = Graphics.FromImage(bmp)
                                gr.DrawImage(bmp_alt, rect1, rect1, GraphicsUnit.Pixel)
                            End Using

                            Dim PB As New PictureBox
                            With PB
                                .Width = 200
                                .Height = 90
                                .SizeMode = PictureBoxSizeMode.Zoom
                                .Image = bmp

                                bmp = Nothing
                                bmp_alt = Nothing

                                .Name = ct
                                AddHandler .Click, AddressOf font_click
                            End With
                            .Controls.Add(PB)
                        End With

                        PMain.Controls.Add(PL)
                    End If


                    ct += 1
                    If ct <= limit Then
                        l += 210
                        If l + 210 > Me.Width Then
                            l = 10
                            t += 130
                        End If
                    End If
                End If
            End If
        Next

        If ct > limit Then
            Dim PL2 As New Panel
            With PL2
                .Top = t
                .Left = l
                .Height = 120
                .Width = 200
                .BorderStyle = BorderStyle.FixedSingle
                .BackColor = Color.White
                AddHandler .Click, AddressOf weitere_click

                Dim LB As New Label
                With LB
                    .Top = 95
                    .Left = 5
                    .Text = "weitere laden..."
                    .Width = 190
                    .Height = 30
                    .TextAlign = ContentAlignment.TopCenter
                    AddHandler .Click, AddressOf weitere_click
                End With
                .Controls.Add(LB)
            End With
            PMain.Controls.Add(PL2)
        End If
    End Sub

    Private Sub weitere_click(ByVal sender As Object, ByVal e As EventArgs)
        PMain.Controls.Remove(PMain.Controls(PMain.Controls.Count - 1))
        Dim count As Integer = PMain.Controls.Count
        draw(count + 49, count - 3)
    End Sub

    Private Sub font_click(ByVal sender As Object, ByVal e As EventArgs)
        Frm_TextTex.TBFont.Text = alleFonts(sender.name).name
        Me.Hide()
    End Sub


    Private Sub CBUsedOnly_CheckedChanged(sender As Object, e As EventArgs) Handles CBUsedOnly.CheckedChanged
        clear()
        draw()
    End Sub

    Private Sub PBKeine_Click(sender As Object, e As EventArgs) Handles PBKeine.Click, PKeine.Click
        Frm_TextTex.TBFont.Text = ""
        Me.Hide()
    End Sub
End Class