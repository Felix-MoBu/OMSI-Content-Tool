'by Felix Modellbusse ;) (MoBu) 2019
Public Class Frm_lod
    Private Sub Frm_lod_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Location = New Point(Frm_Main.Width / 2 - Me.Width / 2, Frm_Main.Height / 2 - Me.Height / 2)
        TBLod.Value = Frm_Main.lodVal * 20
        LBVal.Text = Frm_Main.lodVal
    End Sub

    Private Sub TBLod_Scroll(sender As Object, e As EventArgs) Handles TBLod.Scroll
        Frm_Main.lodVal = TBLod.Value / 20
        LBVal.Text = Frm_Main.lodVal
        Frm_Main.RecalcLod()
    End Sub
End Class