'by Felix Modellbusse ;) (MoBu) 2019
Public Class Frm_Export
    Public choice As Byte = CHOICE_ERROR

    Public Const CHOICE_ERROR = 0
    Public Const CHOICE_DATA = 1
    Public Const CHOICE_EIG = 2


    Private Sub Frm_Export_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Location = New Point(Frm_Main.Width / 2 - Me.Width / 2, Frm_Main.Height / 2 - Me.Height / 2)
        choice = CHOICE_ERROR
    End Sub

    Private Sub BTDatei_Click(sender As Object, e As EventArgs) Handles BTDatei.Click
        choice = CHOICE_DATA
        Me.Close()
    End Sub

    Private Sub BTEig_Click(sender As Object, e As EventArgs) Handles BTEig.Click
        choice = CHOICE_EIG
        Me.Close()
    End Sub
End Class