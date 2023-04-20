Public Class Frm_Git
    Private Sub Frm_Git_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TBPfad.Text = Git.getPath
        TBUrl.Text = Git.getURL
        loadBranches()

    End Sub

    Private Sub loadBranches()
        LBBranches.Items.Clear()
        LBBranches.Items.AddRange(Git.getBranches)
        LBBranches.SelectedIndex = LBBranches.Items.IndexOf(Git.selectedBranch)
    End Sub

    Private Sub LBBranches_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LBBranches.SelectedIndexChanged
        Git.selectedBranch = LBBranches.SelectedItem
    End Sub

    Private Sub BTNeu_Click(sender As Object, e As EventArgs) Handles BTNeu.Click
        Dim newBranch = InputBox("Neuer Branch", "Neu")
        If newBranch.Length > 3 Then Git.selectedBranch = newBranch
        loadBranches()
    End Sub

    Private Sub BTGitignore_Click(sender As Object, e As EventArgs) Handles BTGitignore.Click
        Shell("C:\WINDOWS\Notepad.exe " & Git.getPath() & "\.gitignore", 1)
    End Sub

    Private Sub BTPull_Click(sender As Object, e As EventArgs) Handles BTPull.Click
        Git.Pull()
    End Sub

    Private Sub BTPush_Click(sender As Object, e As EventArgs) Handles BTPush.Click
        Git.Push()
    End Sub
End Class