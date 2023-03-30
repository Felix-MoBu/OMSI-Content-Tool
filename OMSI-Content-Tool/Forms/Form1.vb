'by Felix Modellbusse ;) (MoBu) 2019
Public Class Form1
    Private Sub BTTauschen_Click(sender As Object, e As EventArgs) Handles BTTauschen.Click
        Dim newlines As New List(Of String)
        Dim lines As List(Of String) = TextBox1.Text.Split(vbCrLf).ToList
        For Each line In lines
            Dim newline = line.Split("=")
            newlines.Add(newline(1).Trim & " = " & newline(0).Trim)
        Next

        TextBox1.Clear()
        TextBox1.Text = Join(newlines.ToArray, vbCrLf)
    End Sub



    Dim idChange As New Point

    Private Sub LBMeshes_MouseDown(sender As Object, e As MouseEventArgs) Handles LBMeshes.MouseDown
        LBSelected.Text = LBMeshes.SelectedItem
        idChange.X = LBMeshes.SelectedIndex
    End Sub

    Private Sub LBMeshes_MouseMove(sender As Object, e As MouseEventArgs) Handles LBMeshes.MouseMove
        idChange.Y = LBMeshes.SelectedIndex
    End Sub

    Private Sub LBMeshes_MouseUp(sender As Object, e As MouseEventArgs) Handles LBMeshes.MouseUp
        LBSelected.Text = idChange.X & "  " & idChange.Y
    End Sub
End Class