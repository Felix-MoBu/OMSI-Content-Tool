'by Felix Modellbusse ;) (MoBu) 2019
 Option Strict On

Public Class VarSelector
    Private localChanged As Boolean
    Private Sub VarSelector_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        Height = 20
        TBVar.Width = Me.Width
    End Sub

    Public Property Variable As String
        Get
            Return TBVar.Text
        End Get
        Set(value As String)
            TBVar.Text = value
        End Set
    End Property

    Private Sub TBVar_Click(sender As Object, e As EventArgs) Handles TBVar.Click
        Frm_Vars.SelectedVar = TBVar.Text
        Frm_Vars.ShowDialog()
        TBVar.Text = Frm_Vars.SelectedVar
    End Sub

    Private Sub TBVar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TBVar.KeyPress
        e.Handled = True
    End Sub

    Public Sub TBVar_TextChanged(sender As Object, e As EventArgs) Handles TBVar.TextChanged
        localChanged = True
    End Sub

    'Public Event changed(ByVal EventNumber As Integer)

End Class
