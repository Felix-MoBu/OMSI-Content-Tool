'by Felix Modellbusse ;) (MoBu) 2019
Public Class Frm_Save
    Private Sub Frm_Save_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Location = New Point(Frm_Main.Width / 2 - Me.Width / 2, Frm_Main.Height / 2 - Me.Height / 2)

        Select Case Frm_Main.getprojtype()
            Case Proj_Bus.TYPE
                LBProjDatei.Text = "Bus-Datei"
            Case Proj_Emt.TYPE
                LBProjDatei.Text = "Proj-Datei"
            Case Proj_Ovh.TYPE
                LBProjDatei.Text = "Ovh-Datei"
            Case Proj_Sco.TYPE
                LBProjDatei.Text = "Sco-Datei"
                CBExtraModel.Visible = True
            Case Proj_Sli.TYPE
                LBProjDatei.Text = "Sli-Datei"
        End Select

        Dim fullName As String = Frm_Main.actProj.filename.ToString
        TBProj.Text = fullName
        TBModel.Text = fullName
    End Sub

    Private Sub BTProj_Click(sender As Object, e As EventArgs) Handles BTProj.Click
        Dim fd As New SaveFileDialog
        With fd
            .Title = "Projekt-Datei speichern unter..."
            .InitialDirectory = Frm_Main.actProj.filename.path
            .FileName = Frm_Main.actProj.filename.name
            .Filter = "OMSI-Bus (*.bus)|*.bus"

            If .ShowDialog = DialogResult.OK Then
                TBProj.Text = .FileName
            End If
        End With
    End Sub

    Private Sub BTModel_Click(sender As Object, e As EventArgs) Handles BTModel.Click
        Dim fd As New SaveFileDialog
        With fd
            .Title = "Model-Datei speichern unter..."
            .InitialDirectory = Frm_Main.actProj.model.filename.path
            .FileName = Frm_Main.actProj.model.filename.name
            .Filter = "OMSI-Model (*.cfg)|*.cfg"

            If .ShowDialog = DialogResult.OK Then
                If .FileName.Contains(New Filename(TBProj.Text).path) Then
                    TBModel.Text = .FileName
                Else
                    MsgBox("Der angegebene Pfad ist ungültig!")
                End If
            End If
        End With
    End Sub

    Private Sub BTAbbr_Click(sender As Object, e As EventArgs) Handles BTAbbr.Click
        Me.Close()
    End Sub

    Private Sub BTSpeichern_Click(sender As Object, e As EventArgs) Handles BTSpeichern.Click

        Frm_Main.actProj.filename = New Filename(TBProj.Text)
        Frm_Main.actProj.model.filename = New Filename(TBModel.Text.Substring(Frm_Main.actProj.filename.path.length + 1), Frm_Main.actProj.filename.path)

        Frm_Main.actProj.SaveFile()

        Frm_Main.SpeichernToolStripMenuItem.Enabled = True
        Me.Close()
    End Sub
End Class