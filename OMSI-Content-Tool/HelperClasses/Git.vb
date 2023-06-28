Imports System.Diagnostics.Eventing.Reader

Public Module Git
    Dim isRepoInt As Boolean
    Dim gitShell As Object = CreateObject("WScript.Shell")
    Dim gitPath As String
    Dim gitUrl As String

    Public Function isInstalled() As Boolean
        If Execute("git --version").Split(" ")(0) = "git" Then Return True
        Return False
    End Function

    Public ReadOnly Property isRepo
        Get
            Return isRepoInt
        End Get
    End Property

    Public Function tryFindRepoAt(filepath As String) As Boolean
        If Not isInstalled() Then Return False
        If filepath <> "" Then
            ChangeFolger(filepath)
            If Execute("git status").Split(" ")(0) = "fatal:" Or Execute("git status") = "" Then
                Frm_Main.UnGitToolStripMenuItem.Visible = False
                isRepoInt = False
                Return False
            Else
                gitPath = Execute("git rev-parse --show-toplevel").Replace("/", "\").Replace(vbLf, "")
                gitUrl = Execute("git config --get remote.origin.url")
                Log.Add("Repository gefunden (" & gitPath & ")")
                Frm_Main.UnGitToolStripMenuItem.Visible = True
                isRepoInt = True
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
        If url <> "" Then
            Execute("git clone " & url)
            Log.Add("git clon", TYPE_GIT)
        End If
    End Sub

    Public Sub Commit(message As String)
        If gitPath <> "" Then
            Execute("git commit -m '" & message & "'")
        End If
    End Sub

    Public Sub Pull()
        If gitPath <> "" Then
            Execute("git pull")
        End If
    End Sub

    Public Sub Push()
        If gitPath <> "" Then
            Execute("git push origin " & selectedBranch)
        End If
    End Sub

    Public Sub Sync()
        Pull()
        Push()
    End Sub

    Public Sub delete()
        My.Computer.FileSystem.DeleteDirectory(gitPath & "\.git", FileIO.DeleteDirectoryOption.DeleteAllContents)
        tryFindRepoAt(gitPath)
    End Sub

    Public Function getBranches(Optional remote As Boolean = False) As String()
        Dim command As String = "git branch"
        If remote Then command &= " -r"
        Dim branchList As List(Of String) = Execute(command).Split(vbLf).ToList
        For i = 0 To branchList.Count - 1
            If branchList(i).Length < 2 Then
                branchList.RemoveAt(i)
            Else
                branchList(i) = branchList(i).Substring(2)
            End If
        Next
        Return branchList.ToArray
    End Function

    Public Property selectedBranch As String
        Get
            Dim branchList As List(Of String) = Execute("git branch").Split(vbLf).ToList
            If branchList(0) <> "" Then
                For i = 0 To branchList.Count - 1
                    If branchList(i).Substring(0, 1) = "*" Then Return branchList(i).Substring(2)
                Next
            End If
            Return ""
        End Get
        Set(value As String)
            Dim branchList As String() = getBranches()
            If branchList.Contains(value) Then
                Execute("git checkout " & value)
            Else
                Execute("git checkout -b" & value)
            End If
        End Set
    End Property

    Private Sub ChangeFolger(path As String)
        If path <> "" Then
            gitShell.CurrentDirectory = path
        End If
    End Sub

    Private Function Execute(command As String) As String
        Log.Add(command, TYPE_GIT)
        Return gitShell.Exec(command).StdOut.ReadAll()
    End Function

    Public Function getPath() As String
        Return Execute("git rev-parse --show-toplevel").Replace("/", "\").Trim
    End Function

    Public Function getURL() As String
        Return Execute("git config --get remote.origin.url").Trim
    End Function
End Module
