'by Felix Modellbusse ;) (MoBu) 2019
Public Class Frm_Sounds
    Private Sub Frm_Sounds_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Location = New Point(Frm_Main.Width / 2 - Me.Width / 2, Frm_Main.Height / 2 - Me.Height / 2)

        LBGruppen.Items.Clear()
        LBDateien.Items.Clear()

        If Frm_Main.getProjType = Proj_Bus.TYPE Then
            If Not Frm_Main.getProj.paths Is Nothing Then
                For i As Integer = 0 To Frm_Main.getProj.paths.soundpacks.count - 1
                    LBGruppen.Items.Add(i)
                Next

            Else
                MsgBox("Es wurde keine Path-Datei gefunden")
                Me.Close()
            End If
        End If
    End Sub

    Private Sub LBGruppen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LBGruppen.SelectedIndexChanged
        If LBGruppen.SelectedIndex > -1 Then
            LBDateien.Items.Clear()
            LBDateien.Items.AddRange(Frm_Main.getProj.paths.soundpacks(LBGruppen.SelectedIndex).toarray)
        End If
    End Sub
End Class