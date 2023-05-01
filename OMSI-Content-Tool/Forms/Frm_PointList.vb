Public Class Frm_PointList
    Private Sub Frm_PointList_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        For i = 0 To 20
            'hier weiter!!!
        Next

        TB0.Text = Frm_Main.getProj.ProjDataBase.storedPointNames(0)
        PS0.Point = Frm_Main.getProj.ProjDataBase.storedPoints(0)
    End Sub
End Class