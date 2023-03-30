'by Felix Modellbusse ;) (MoBu) 2019
Public Class Frm_FindMesh
    Private Sub Frm_FindMesh_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Location = New Point(Convert.ToInt16(Frm_Main.Width / 2 - Me.Width / 2), Convert.ToInt16(Frm_Main.Height / 2 - Me.Height / 2))
    End Sub

    Private Sub BTAbbrechen_Click(sender As Object, e As EventArgs) Handles BTAbbrechen.Click
        Me.Hide()
    End Sub

    Private Sub BTSuchen_Click(sender As Object, e As EventArgs) Handles BTSuchen.Click
        suchen()
    End Sub

    Private Sub TBSuchen_KeyDown(sender As Object, e As KeyEventArgs) Handles TBSuchen.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                suchen()
                e.Handled = True
                e.SuppressKeyPress = True
            Case Keys.Escape
                Me.Hide()
                e.Handled = True
                e.SuppressKeyPress = True
        End Select
    End Sub

    Private Sub suchen(Optional vonForne As Boolean = False)
        If TBSuchen.Text <> "" Then
            If CBMesh.Checked Then
                With Frm_Main.LBMeshes
                    Dim startindex As Integer = .SelectedIndex
                    If vonForne Then startindex = -1
                    For i As Integer = startindex + 1 To .Items.Count - 1
                        If LCase(.Items(i)).contains(LCase(TBSuchen.Text)) Then
                            .SelectedIndex = i
                            Exit Sub
                        End If
                    Next
                    If vonForne Then
                        Exit Sub
                    Else
                        suchen(True)
                    End If
                End With
            End If
            If CBTexture.Checked Then
                'hier weiert...
            End If
            If CBVariable.Checked Then
                'hier weiter
            End If
        End If
    End Sub
End Class