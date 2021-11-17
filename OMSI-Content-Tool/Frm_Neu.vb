Public Class Frm_Neu
    Public ProjTyp As Byte


    Private Sub Frm_Neu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Location = New Point(Frm_Main.Width / 2 - Me.Width / 2, Frm_Main.Height / 2 - Me.Height / 2)
    End Sub

    Private Sub PBBus_Click(sender As Object, e As EventArgs) Handles PBBus.Click
        PBselect(sender)
    End Sub

    Private Sub PBselect(PB As PictureBox)
        PBBus.BorderStyle = BorderStyle.None
        PBOvh.BorderStyle = BorderStyle.None
        PBSco.BorderStyle = BorderStyle.None
        PBSli.BorderStyle = BorderStyle.None

        PB.BorderStyle = BorderStyle.FixedSingle
        ProjTyp = PB.Tag
        ProjType_Change()
        BTErstellen.Enabled = True
    End Sub

    Private Sub ProjType_Change()
        Dim ext As String
        Select Case ProjTyp
            Case Frm_Main.PROJ_TYPE_BUS
                ext = "bus"
            Case Frm_Main.PROJ_TYPE_OVH
                ext = "ovh"
            Case Frm_Main.PROJ_TYPE_SCO
                ext = "sco"
            Case Frm_Main.PROJ_TYPE_SLI
                ext = "sli"
            Case Else
                ext = ""
        End Select
        GBAblageort.Enabled = True
        TBName.Text = Split(TBName.Text, ".")(0) & "." & ext
    End Sub

    Private Sub TBName_Leave(sender As Object, e As EventArgs) Handles TBName.Leave
        ProjType_Change()
    End Sub

    Private Sub PBOvh_Click(sender As Object, e As EventArgs) Handles PBOvh.Click
        PBselect(sender)
    End Sub

    Private Sub PBSco_Click(sender As Object, e As EventArgs) Handles PBSco.Click
        PBselect(sender)
    End Sub

    Private Sub PBSli_Click(sender As Object, e As EventArgs) Handles PBSli.Click
        PBselect(sender)
    End Sub

    Private Sub PBMap_Click(sender As Object, e As EventArgs)
        PBselect(sender)
    End Sub

    Private Sub BTDurchsuchen_Click(sender As Object, e As EventArgs) Handles BTDurchsuchen.Click
        Dim fd As New FolderBrowserDialog
        If fd.ShowDialog Then
            TBSpeicherort.Text = fd.SelectedPath
        End If
    End Sub

    Private Sub OBErstellen_Click(sender As Object, e As EventArgs) Handles BTErstellen.Click
        If CBHersteller.Text = "" Then
            LBHersteller.ForeColor = Color.Red
            Exit Sub
        Else
            LBHersteller.ForeColor = Color.Black
        End If

        If CBTyp.Text = "" Then
            LBTyp.ForeColor = Color.Red
            Exit Sub
        Else
            LBTyp.ForeColor = Color.Black
        End If

        If TBAussehen.Text = "" Then
            LBAussehen.ForeColor = Color.Red
            Exit Sub
        Else
            LBAussehen.ForeColor = Color.Black
        End If

        If Split(TBName.Text, ".")(0) = "" Then
            LBName.ForeColor = Color.Red
            Exit Sub
        Else
            LBName.ForeColor = Color.Black
        End If

        If TBSpeicherort.Text = "" Then
            LBSpeicherort.ForeColor = Color.Red
            Exit Sub
        Else
            LBSpeicherort.ForeColor = Color.Black
        End If


        'Neues Projekt-Objekt erstellen
        Dim Proj_temp As New Object

        Select Case ProjTyp
            Case Frm_Main.PROJ_TYPE_BUS
                Proj_temp = New Proj_Bus
                With Proj_temp
                    .hersteller = CBHersteller.Text
                    .typ = CBTyp.Text
                    .anstrich = TBAussehen.Text
                    .model = modelFromEmpty()
                    If .model Is Nothing Then
                        .model = New OMSI_Model
                    End If
                    .model.filename = New Filename("Model\" & TBName.Text.Split(".")(0) & ".cfg", TBSpeicherort.Text)
                End With
            Case Frm_Main.PROJ_TYPE_OVH
                'Frm_Main.AlleOvh.Add(New Proj_Ovh)
            Case Frm_Main.PROJ_TYPE_SCO
                Proj_temp = New Proj_Sco
                With Proj_temp
                    .name = CBHersteller.Text
                    .gruppen.add(CBTyp.Text)
                    .model = modelFromEmpty()
                    If .model Is Nothing Then
                        .model = New OMSI_Model
                    End If
                    .model.filename = New Filename(TBName.Text, TBSpeicherort.Text)
                End With
            Case Frm_Main.PROJ_TYPE_SLI
                Proj_temp = New Proj_Sli
        End Select

        Proj_temp.filename = New Filename(TBName.Text, TBSpeicherort.Text)
        Frm_Main.ProjNew(Proj_temp)

        Frm_Main.EigenschaftenToolStripMenuItem_Click(New Object, Nothing)


        Frm_Main.Text = TBName.Text & " - " & My.Application.Info.Title
        Frm_Main.SpeichernToolStripMenuItem.Enabled = True
        Me.Close()
    End Sub

    Private Function modelFromEmpty()
        If Not Frm_Main.getProj.model Is Nothing Then
            Dim erg As Byte = MsgBox("Aktuelles Modell übernehmen?", vbYesNo)
            If erg = vbYes Then
                Return Frm_Main.getProj.model
            End If
        End If
        Return Nothing
    End Function

    Private Sub BTAbbrechen_Click(sender As Object, e As EventArgs) Handles BTAbbrechen.Click
        Me.Close()
    End Sub

    Private Sub CBTyp_Leave(sender As Object, e As EventArgs) Handles CBTyp.Leave
        If TBName.Text.Contains(".") Then
            If Split(TBName.Text, ".")(0) = "" Then
                TBName.Text = CBHersteller.Text & "_" & CBTyp.Text.Replace(" ", "_") & "." & Split(TBName.Text, ".")(1)
            End If
            If Split(TBName.Text, ".")(0) = "_" Then TBName.Text = "." & Split(TBName.Text, ".")(1)
        End If
    End Sub
End Class