Public Module Git
    Dim isRepo As Boolean
    Dim gitShell As Object = CreateObject("WScript.Shell")
    Dim gitPath As String
    Dim gitUrl As String

    Public Function tryFindRepoAt(filepath As String) As Boolean
        If filepath <> "" Then
            ChangeFolger(filepath)
            If Execute("git status").Split(" ")(0) = "fatal:" Or Execute("git status") = "" Then
                Frm_Main.UnGitToolStripMenuItem.Visible = False
                isRepo = False
                Return False
            Else
                gitPath = Execute("git rev-parse --show-toplevel").Replace("/", "\").Replace(vbLf, "")
                gitUrl = Execute("git config --get remote.origin.url")
                Log.Add("Repository gefunden (" & gitPath & ")")
                Frm_Main.UnGitToolStripMenuItem.Visible = True
                isRepo = True
                Return True
            End If
        Else
            Return False
        End If
    End Function

    Public Sub NewRepoAt(filepath As String)
        ChangeFolger(filepath)
        Execute("git init")
        Execute("git add *")
        tryFindRepoAt(filepath)
    End Sub

    Public Sub Connect(Optional url As String = "")
        If url = "" Then

        Else

        End If
    End Sub

    Public Sub Commit()
        Dim message As String = InputBox("Kommentar")
        Execute("git commit -m '" & message & "'")
    End Sub

    Public Sub Pull()
        Execute("git pull")
    End Sub

    Public Sub Push()
        Execute("git push origin " & getOrigin())
    End Sub

    Public Sub Sync()
        Pull()
        Push()
    End Sub

    Public Sub delete()
        My.Computer.FileSystem.DeleteDirectory(gitPath & "\.git", FileIO.DeleteDirectoryOption.DeleteAllContents)
        tryFindRepoAt(gitPath)
    End Sub

    Private Sub ChangeFolger(path As String)
        If path <> "" Then
            gitShell.CurrentDirectory = path
        End If
    End Sub

    Private Function Execute(command As String) As String
        Return gitShell.Exec(command).StdOut.ReadAll()
    End Function

    Public Function getPath() As String
        Return Execute("git rev - parse - -show - toplevel")
    End Function

    Public Function getOrigin() As String
        Dim result As String = Execute("git shwo --origin")
        If InStr(result, "'") Then
            Return result.Split("'")(1)
        Else
            Return ""
        End If
    End Function
End Module
