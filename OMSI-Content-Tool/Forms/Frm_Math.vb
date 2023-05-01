'by Felix Modellbusse ;) (MoBu) 2019
Public Class Frm_Math
    Private Sub BTAbstand_Click(sender As Object, e As EventArgs) Handles BTAbstand.Click
        TBAbstand.Text = PSA.Point.dist(PSB.Point)
    End Sub

    Private Sub BTDrehen_Click(sender As Object, e As EventArgs) Handles BTDrehen.Click
        If TBWinkel.Text.Trim = "" Then
            MsgBox("Bitte Drehwinkel angeben")
            Exit Sub
        End If
        Dim newPnt As New Point3D(PSA.Point)
        newPnt.rotate(TBWinkel.Text, CBAchse.SelectedIndex, PSB.Point)
        newPnt.X = Math.Round(newPnt.X, 4)
        newPnt.Y = Math.Round(newPnt.Y, 4)
        newPnt.Z = Math.Round(newPnt.Z, 4)
        PSWinkel.Point = newPnt
    End Sub

    Private Sub Frm_Math_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CBAchse.SelectedIndex = 0
        Me.Location = New Point(Frm_Main.Width / 2 - Me.Width / 2, Frm_Main.Height / 2 - Me.Height / 2)
    End Sub

    Private Sub Frm_Math_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Hide()
        e.Cancel = True
    End Sub
End Class