'by Felix Modellbusse ;) (MoBu) 2019
Module Log
    Public Const logfile As String = "\Logfile.txt"

    Public Const TYPE_INFO As Byte = 0
    Public Const TYPE_WARNUNG As Byte = 1
    Public Const TYPE_ERROR As Byte = 2
    Public Const TYPE_DEBUG As Byte = 3

    Public Sub Add(addText As String, Optional type As Byte = 0, Optional popup As Boolean = False)
        Dim typeS As String
        Select Case type
            Case TYPE_WARNUNG
                typeS = "Warnung"
            Case TYPE_ERROR
                typeS = "Error!"
            Case TYPE_DEBUG
                If Not My.Settings.LogDebug Then
                    Exit Sub
                End If
                typeS = "DEBUG"
            Case Else
                typeS = "Info"
        End Select
        My.Computer.FileSystem.WriteAllText(Application.StartupPath & logfile, vbCrLf & typeS & vbTab & "(" & TimeString & ") - " & addText, True)
        Frm_Main.TBLogfile.AppendText(typeS & vbTab & "(" & TimeString & ") - " & addText & vbCrLf)

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
