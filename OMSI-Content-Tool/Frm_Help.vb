'by Felix Modellbusse ;) (MoBu) 2019
Public Class Frm_Help
    Private Sub Frm_Help_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Location = New Point(Frm_Main.Width / 2 - Me.Width / 2, Frm_Main.Height / 2 - Me.Height / 2)
        WBMain.Document.Write(IO.File.ReadAllText(Application.StartupPath & "\help.html"))
        WBMain.Navigate("file:///" & IO.Path.GetFullPath(".\help.html"))
    End Sub

    Private Sub WBMain_Navigating(sender As Object, e As WebBrowserNavigatingEventArgs) Handles WBMain.Navigating
        If InStr(e.Url.ToString, "http") Or InStr(e.Url.ToString, "ftp") Or InStr(e.Url.ToString, "www") Then
            WBMain.Navigate("file:///" & IO.Path.GetFullPath(".\help.html"))
        End If
    End Sub
End Class