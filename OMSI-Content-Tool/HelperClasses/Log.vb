'by Felix Modellbusse ;) (MoBu) 2019
Module Log
    Public Const logfile As String = "\Logfile.txt"

    Public Const TYPE_INFO As Byte = 0
    Public Const TYPE_WARNUNG As Byte = 1
    Public Const TYPE_ERROR As Byte = 2
    Public Const TYPE_DEBUG As Byte = 3
    Public Const TYPE_GIT As Byte = 4

    Public Sub Add(addText As String, Optional type As Byte = 0, Optional popup As Boolean = False)
        Dim typeS As String
        Select Case type
            Case TYPE_WARNUNG
                typeS = "Warnung"
                Frm_Main.TBLogfile.SelectionColor = Color.Violet
            Case TYPE_ERROR
                typeS = "Error!"
                Frm_Main.TBLogfile.SelectionColor = Color.Red
            Case TYPE_DEBUG
                If Not Settings.LogDebug Then Exit Sub
                typeS = "DEBUG"
                Frm_Main.TBLogfile.SelectionColor = Color.Blue
            Case TYPE_GIT
                If Not Settings.LogGit Then Exit Sub
                typeS = "GIT"
                Frm_Main.TBLogfile.SelectionColor = Color.DarkOrange
            Case Else
                typeS = "Info"
        End Select
        My.Computer.FileSystem.WriteAllText(Application.StartupPath & logfile, vbCrLf & typeS & vbTab & "(" & TimeString & ") - " & addText, True)
        Frm_Main.TBLogfile.AppendText(typeS & vbTab & "(" & TimeString & ") - " & addText & vbCrLf)
        Frm_Main.TBLogfile.SelectionColor = Color.Black
        Frm_Main.TBLogfile.ScrollToCaret()

        If popup Then
            If type = TYPE_ERROR Then
                MsgBox(addText, MsgBoxStyle.Information)
            Else
                MsgBox(addText)
            End If
        End If
    End Sub

    Public Sub Clear()
        My.Computer.FileSystem.WriteAllText(Application.StartupPath & logfile, "Logfile " & My.Application.Info.Title & " Version " & My.Application.Info.Version.ToString & vbCrLf, False)
    End Sub

    Public Sub Close()
        My.Computer.FileSystem.WriteAllText(Application.StartupPath & logfile, vbCrLf & vbCrLf & " - Logfile Ende - ", True)
    End Sub
End Module
