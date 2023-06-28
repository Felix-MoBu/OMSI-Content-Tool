'by Felix Modellbusse ;) (MoBu) 2019
Public Class Frm_Help
    Private Sub Frm_Help_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If IO.File.Exists(Application.StartupPath & "\help.html") Then
            Me.Location = New Point(Frm_Main.Width / 2 - Me.Width / 2, Frm_Main.Height / 2 - Me.Height / 2)
            WBMain.Navigate("file:///" & IO.Path.GetFullPath(".\help.html"))
        Else
            MsgBox("Die lokale Hilfe wurde nicht mit installiert!")
            Me.Close()
        End If
    End Sub

    Private Sub WBMain_Navigating(sender As Object, e As WebBrowserNavigatingEventArgs) Handles WBMain.Navigating
        If e.Url.ToString.Substring(0, 4) <> "file" Then
            WBMain.Navigate("file:///" & IO.Path.GetFullPath(".\help.html"))
        End If
        Me.Text = WBMain.DocumentTitle
    End Sub
End Class