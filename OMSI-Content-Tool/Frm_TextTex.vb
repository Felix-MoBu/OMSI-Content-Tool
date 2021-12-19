'by Felix Modellbusse ;) (MoBu) 2019
Imports System.ComponentModel

Public Class Frm_TextTex
    Dim CSMain As ColorSelector
    Dim tempItem As String
    Dim oldName As String
    Private Sub TBFont_Click(sender As Object, e As EventArgs) Handles TBFont.Click
        Frm_Fonts.Show()
    End Sub

    Private Sub Frm_TextTex_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Location = New Point(Frm_Main.Width / 2 - Me.Width / 2, Frm_Main.Height / 2 - Me.Height / 2)
        CBAusr.SelectedIndex = 0
        CSMain = New ColorSelector
        With CSMain
            .Top = 113
            .Left = 10
            .WidthOfTB = 228
            .StartOfTB = 42
            .Name = "CSMain"
            AddHandler .PBColor.BackColorChanged, AddressOf colorChanged
        End With
        GBMain.Controls.Add(CSMain)

        LBMain.Items.Clear()
        For Each TTex In Frm_Main.getProj.model.TextTexturen
            LBMain.Items.Add(TTex.name)
        Next

        If LBMain.Items.Count > 0 Then LBMain.SelectedIndex = 0
    End Sub

    Dim manuelColorChange As Boolean = True
    Private Sub colorChanged()
        If manuelColorChange Then
            If LBMain.SelectedIndex >= 0 Then
                With Frm_Main.getProj.model.TextTexturen(LBMain.SelectedIndex)
                    .r = toByte(CSMain.ColorR.Text)
                    .g = toByte(CSMain.ColorG.Text)
                    .b = toByte(CSMain.ColorB.Text)
                End With
            End If
        End If
    End Sub

    Private Sub LBMain_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LBMain.SelectedIndexChanged
        tempItem = Frm_Main.Mat_CBTextTex.SelectedItem
        If LBMain.SelectedIndex >= 0 Then
            With Frm_Main.getProj.model.TextTexturen(LBMain.SelectedIndex)
                TBName.Text = .name
                TBFont.Text = .font
                TBBreite.Text = .breite
                TBHoehe.Text = .höhe
                RBColor.Checked = .FontColorBool
                RBMono.Checked = Not .FontColorBool

                manuelColorChange = False
                CSMain.ColorR.Text = .r
                CSMain.ColorG.Text = .g
                CSMain.ColorB.Text = .b
                manuelColorChange = True

                CBEnh.Checked = .enh
                If .enh Then
                    CBAusr.SelectedIndex = .orientation
                    CBGrid.Checked = .grid
                End If
            End With
        End If
    End Sub

    Private Sub CBEnh_CheckedChanged(sender As Object, e As EventArgs) Handles CBEnh.CheckedChanged
        GBEnh.Visible = CBEnh.Checked
        Frm_Main.getProj.model.TextTexturen(LBMain.SelectedIndex).enh = CBEnh.Checked
    End Sub

    Private Sub TBName_KeyDown(sender As Object, e As KeyEventArgs) Handles TBName.KeyDown
        oldName = TBName.Text
    End Sub

    Private Sub TBName_KeyUp(sender As Object, e As KeyEventArgs) Handles TBName.KeyUp
        Frm_Main.getProj.model.TextTexturen(LBMain.SelectedIndex).name = TBName.Text
        LBMain.Items(LBMain.SelectedIndex) = TBName.Text
        If tempItem = oldName Then tempItem = TBName.Text
    End Sub

    Private Sub TBFont_TextChanged(sender As Object, e As EventArgs) Handles TBFont.TextChanged
        Frm_Main.getProj.model.TextTexturen(LBMain.SelectedIndex).font = TBFont.Text
    End Sub

    Private Sub TBBreite_TextChanged(sender As Object, e As EventArgs) Handles TBBreite.TextChanged
        If sender.text <> "" Then
            Frm_Main.getProj.model.TextTexturen(LBMain.SelectedIndex).breite = TBBreite.Text
        End If
    End Sub

    Private Sub TBHoehe_TextChanged(sender As Object, e As EventArgs) Handles TBHoehe.TextChanged
        If sender.text <> "" Then
            Frm_Main.getProj.model.TextTexturen(LBMain.SelectedIndex).höhe = TBHoehe.Text
        End If
    End Sub

    Private Sub RBMono_Click(sender As Object, e As EventArgs) Handles RBMono.Click
        If RBMono.Checked Then
            Frm_Main.getProj.model.TextTexturen(LBMain.SelectedIndex).FontColorBool = False
        Else
            Frm_Main.getProj.model.TextTexturen(LBMain.SelectedIndex).FontColorBool = True
        End If
    End Sub

    Private Sub RBColor_Click(sender As Object, e As EventArgs) Handles RBColor.Click
        If RBColor.Checked Then
            Frm_Main.getProj.model.TextTexturen(LBMain.SelectedIndex).FontColorBool = True
        Else
            Frm_Main.getProj.model.TextTexturen(LBMain.SelectedIndex).FontColorBool = False
        End If
    End Sub

    Private Sub CBAusr_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBAusr.SelectedIndexChanged
        If LBMain.SelectedIndex >= 0 Then
            Frm_Main.getProj.model.TextTexturen(LBMain.SelectedIndex).orientation = CBAusr.SelectedIndex
        End If
    End Sub

    Private Sub CBGrid_CheckedChanged(sender As Object, e As EventArgs) Handles CBGrid.CheckedChanged
        Frm_Main.getProj.model.TextTexturen(LBMain.SelectedIndex).grid = CBGrid.Checked
    End Sub

    Private Sub Frm_TextTex_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        With Frm_Main
            .Mat_CBTextTex.Items.Clear()
            .Mat_CBTextTex.Items.Add("")
            For Each TextTex In .getProj.model.TextTexturen
                .Mat_CBTextTex.Items.Add(TextTex.name)
            Next
            .Mat_CBTextTex.SelectedItem = tempItem
        End With
    End Sub

    Private Sub BTSpeichern_Click(sender As Object, e As EventArgs) Handles BTSpeichern.Click
        Me.Close()
    End Sub

    Private Sub BTNeu_Click(sender As Object, e As EventArgs) Handles BTNeu.Click
        Dim NewTex As New TextTexture
        With NewTex
            .name = "Neu"
            .index = Frm_Main.getProj.model.TextTexturen.Count
            .breite = 128
            .höhe = 128
        End With
        Frm_Main.getProj.model.TextTexturen.Add(NewTex)

        LBMain.Items.Clear()
        For Each TTex In Frm_Main.getProj.model.TextTexturen
            LBMain.Items.Add(TTex.name)
        Next

        LBMain.SelectedIndex = LBMain.Items.Count - 1
    End Sub

    Private Sub BTEntfernen_Click(sender As Object, e As EventArgs) Handles BTEntfernen.Click
        If LBMain.SelectedIndex >= 0 Then
            LBMain.SelectedIndex = LBMain.SelectedIndex - 1
            Frm_Main.getProj.model.TextTexturen.Remove(Frm_Main.getProj.model.TextTexturen(LBMain.SelectedIndex + 1))
        End If

        LBMain.Items.Clear()
        For Each TTex In Frm_Main.getProj.model.TextTexturen
            LBMain.Items.Add(TTex.name)
        Next

        If LBMain.Items.Count > 0 Then LBMain.SelectedIndex = 0
    End Sub

    Private Sub TBHoehe_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TBHoehe.KeyPress
        e.Handled = helper.NumbersOnly(e, sender)
    End Sub

    Private Sub TBBreite_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TBBreite.KeyPress
        e.Handled = helper.NumbersOnly(e, sender)
    End Sub
End Class