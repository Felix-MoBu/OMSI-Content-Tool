Imports System.ComponentModel

Public Class Frm_Listen
    Dim liste As New List(Of String)
    Dim changed As Boolean = False
    Dim path As String
    Dim filter As String

    Dim tmpInfoStr As String

    Public Projekt As Object

    Private Sub Frm_Listen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Location = New Point(Frm_Main.Width / 2 - Me.Width / 2, Frm_Main.Height / 2 - Me.Height / 2)
    End Sub

    Public Sub LoadFilled(ProjektToLoad As Object, name As String, path As String, filter As String)
        Projekt = ProjektToLoad
        If Not Projekt Is Nothing And path IsNot Nothing Then

            Me.path = path
            Me.filter = filter
            Me.Text = name

            LoadFromSelected()
            LoadFromFolder()
        Else
            Me.Close()
            MsgBox("Bitte zunächst ein Projekt öffnen/erstellen!", , "Warnung!")
            Exit Sub
        End If

        Me.Show()
    End Sub


    Private Sub TBOrdnerFiltern_TextChanged(sender As Object, e As EventArgs) Handles TBOrdnerFiltern.TextChanged
        LoadFromFolder(TBOrdnerFiltern.Text)
    End Sub

    Private Sub LoadFromFolder(Optional search As String = "")
        LBOrdner.Items.Clear()

        If My.Computer.FileSystem.DirectoryExists(path & "\script") Then
            Dim files() As String = IO.Directory.GetFiles(path & "\script")

            For Each fileTmp In files
                If fileTmp.Substring(fileTmp.Length - 3) = filter Then
                    Dim strTemp As String = ""
                    Dim addBool As Boolean = False
                    For Each part In Split(fileTmp, "\")
                        If addBool Then strTemp &= "\"
                        If LCase(part) = "script" Then addBool = True
                        If addBool Then strTemp &= part
                    Next
                    If Not LBAusgewählt.Items.Contains(strTemp) And InStr(LCase(strTemp), LCase(search)) Then LBOrdner.Items.Add(strTemp)
                End If
            Next
        End If
    End Sub

    Private Sub TBAusgFiltern_TextChanged(sender As Object, e As EventArgs) Handles TBAusgFiltern.TextChanged
        LoadFromSelected(TBAusgFiltern.Text)
    End Sub

    Private Sub LoadFromSelected(Optional search As String = "")
        LBAusgewählt.Items.Clear()
        Select Case LCase(Me.Text)
            Case "varlists"
                liste = Projekt.varlists
            Case "stringvarlists"
                liste = Projekt.stringvarlists
            Case "constfiles"
                liste = Projekt.constfiles
            Case "scripts"
                liste = Projekt.scripts
            Case Else
                liste = New List(Of String)
        End Select

        For Each item In liste
            If InStr(LCase(item), LCase(search)) Then LBAusgewählt.Items.Add(item)
        Next
    End Sub

    Private Sub LBAusgewählt_DoubleClick(sender As Object, e As EventArgs) Handles LBAusgewählt.DoubleClick
        Dim filename As String = Projekt.filename.path & "\" & LBAusgewählt.SelectedItem

        If My.Computer.FileSystem.FileExists(filename) Then
            Process.Start(filename)
        Else
            Log.Add("Script-Datei nicht gefunden! (Fehler:L002, Datei:" & filename & ")")
            MsgBox("Die Datei kann nicht gefunden werden!")
        End If
    End Sub

    Private Sub LBOrdner_DoubleClick(sender As Object, e As EventArgs) Handles LBOrdner.DoubleClick
        If LBOrdner.SelectedItem <> "" Then
            LBAusgewählt.Items.Add(LBOrdner.SelectedItem)
            LBOrdner.Items.Remove(LBOrdner.SelectedItem)
            changed = True
        End If
    End Sub

    Private Sub BTHinzu_Click(sender As Object, e As EventArgs) Handles BTHinzu.Click
        If LBOrdner.SelectedItem <> "" Then
            LBAusgewählt.Items.Add(LBOrdner.SelectedItem)
            LBOrdner.Items.Remove(LBOrdner.SelectedItem)
            changed = True
        End If
    End Sub

    Private Sub BTEntf_Click(sender As Object, e As EventArgs) Handles BTEntf.Click
        If LBAusgewählt.SelectedItem <> "" Then
            Dim selectedindex As Integer = LBAusgewählt.SelectedIndex
            LBOrdner.Items.Add(LBAusgewählt.SelectedItem)
            LBAusgewählt.Items.Remove(LBAusgewählt.SelectedItem)
            changed = True
            If LBAusgewählt.Items.Count > 0 Then
                If Not selectedindex > LBAusgewählt.Items.Count - 1 Then
                    LBAusgewählt.SelectedIndex = selectedindex
                Else
                    LBAusgewählt.SelectedIndex = LBAusgewählt.Items.Count - 1
                End If
            End If
        End If
    End Sub

    Private Sub Frm_Listen_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If changed Then
            Dim x = MsgBox("Änderungen übernehmen?", vbYesNo)
            If x = vbYes Then SaveChanges()
        End If
    End Sub

    Private Sub TBOrdnerFiltern_Click(sender As Object, e As EventArgs) Handles TBOrdnerFiltern.Click
        TBOrdnerFiltern.Text = ""
        LoadFromFolder()
    End Sub

    Private Sub TBAusgFiltern_Click(sender As Object, e As EventArgs) Handles TBAusgFiltern.Click
        TBAusgFiltern.Text = ""
    End Sub

    Private Sub BTÜbernehmen_Click(sender As Object, e As EventArgs) Handles BTÜbernehmen.Click
        SaveChanges()
        Frm_Main.VariablenAusOrdnerLaden(Frm_Main.getProj.varlists, Frm_Main.getProj.filename)
        Me.Close()
    End Sub

    Private Sub SaveChanges()
        liste.Clear()
        For Each item In LBAusgewählt.Items
            liste.Add(item)
        Next

        With Projekt
            Select Case LCase(Name)
                Case "varlists"
                    .varlists = liste
                Case "stringvarlists"
                    .stringvarlists = liste
                Case "constfiles"
                    .constfiles = liste
                Case "scripts"
                    .scripts = liste
                Case Else
                    liste = New List(Of String)
            End Select
            If changed Then .changed = True 'Nicht gleich setzen sonst wird Projekt.changed auf False gesetzt obwohl es vlt. auf True war
            changed = False
        End With
    End Sub

    Private Sub BTAbbrechen_Click(sender As Object, e As EventArgs) Handles BTAbbrechen.Click
        changed = False
        Me.Close()
    End Sub

    Private Sub BTNeu_Click(sender As Object, e As EventArgs) Handles BTNeu.Click
        Dim input = InputBox("Neuen Dateinamen eingeben! (" & filter & ")")
        If input <> "" Then
            If input.Length > 3 Then
                If Not input.Substring(input.Count - 4) = "." & filter Then input &= "." & filter
            Else
                input &= "." & filter
            End If
            LBAusgewählt.Items.Add("Script\" & input)
            If Not My.Computer.FileSystem.DirectoryExists(path & "\Script") Then
                My.Computer.FileSystem.CreateDirectory(path & "\Script")
            End If
            My.Computer.FileSystem.WriteAllText(path & "\Script\" & input, "", False)
            changed = True
        End If
    End Sub

    Private Sub BTOrdner_Click(sender As Object, e As EventArgs) Handles BTOrdner.Click
        Process.Start(path & "\Script\")
    End Sub

    Private Sub BTÜbernehmen_MouseEnter(sender As Object, e As EventArgs) Handles BTÜbernehmen.MouseEnter
        tmpInfoStr = LBInfo.Text
        LBInfo.Text = "Der Alle Dateien werden neu eingelesen!"
    End Sub

    Private Sub BTÜbernehmen_MouseLeave(sender As Object, e As EventArgs) Handles BTÜbernehmen.MouseLeave
        LBInfo.Text = tmpInfoStr
    End Sub

    Private Sub LBAusgewählt_KeyDown(sender As Object, e As KeyEventArgs) Handles LBAusgewählt.KeyDown
        Select Case e.KeyCode
            Case Keys.Delete
                BTEntf_Click(BTEntf, Nothing)
            Case Keys.Enter
                If LBAusgewählt.Items.Count > 0 Then
                    LBAusgewählt_DoubleClick(LBAusgewählt, Nothing)
                Else
                    Me.Close()
                End If
        End Select
    End Sub
End Class