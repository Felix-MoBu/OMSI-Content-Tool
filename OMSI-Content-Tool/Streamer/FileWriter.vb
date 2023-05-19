'by Felix Modellbusse ;) (MoBu) 2019
Option Strict On
'by Felix Modellbusse ;) (MoBu) 2019
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class FileWriter
    Private filename As Filename
    Private lines As List(Of String)


    Public Sub New(filename As Filename, Optional noheader As Boolean = False)
        Me.filename = filename
        lines = New List(Of String)
        If Not noheader Then
            lines.Add("Diese Datei wurde mit dem " & My.Application.Info.Title & " erstellt/bearbeitet (zuletzt: " & FormatDateTime(Now) & ")")
            Nl()
        End If
    End Sub

    Public Sub Add(str As String, Optional newLine As Boolean = False)
        lines.Add(str)
        If newLine Then Nl()
    End Sub

    Public Sub Add(val As Double, Optional newLine As Boolean = False)
        lines.Add(Replace(fromDouble(val), ".000", ""))
        If newLine Then Nl()
    End Sub

    Public Sub Add(val As Boolean, Optional newLine As Boolean = False)
        If val Then
            lines.Add(fromSingle(1))
        Else
            lines.Add(fromSingle(0))
        End If
        If newLine Then Nl()
    End Sub

    Public Sub AddTag(tag As String, val As String, Optional newLine As Boolean = False)
        If tag <> "" Then
            Add("[" & tag & "]")
            Add(val, newLine)
        End If
    End Sub

    Public Sub AddTag(tag As String, vals As List(Of String), Optional newLine As Boolean = False)
        If tag.Contains("[") Then Log.Add("FileWrite Tag mit [ hinzugefügt!")
        If tag <> "" Then
            Add("[" & tag & "]")
            For Each item In vals
                Add(item)
            Next
            If newLine Then Nl()
        End If
    End Sub

    Public Sub AddTag(tag As String, val As Double, Optional newLine As Boolean = False)
        If tag <> "" Then
            Add("[" & tag & "]")
            Add(val, newLine)
        End If
    End Sub

    Public Sub AddTag(tag As String, val As Color, Optional newLine As Boolean = False)
        If tag <> "" Then
            Add("[" & tag & "]")
            Add(val.R)
            Add(val.G)
            Add(val.B, newLine)
        End If
    End Sub

    Public Sub Add(val As Integer, Optional newLine As Boolean = False) 'WICHTIG damit keine Punkte in den Zahlenwerten sind
        lines.Add(Convert.ToString(val))
        If newLine Then Nl()
    End Sub

    Public Sub Add(val As Byte, Optional newLine As Boolean = False) 'WICHTIG damit keine Punkte in den Zahlenwerten sind
        lines.Add(Convert.ToString(val))
        If newLine Then Nl()
    End Sub

    Public Sub AddRange(list As List(Of String), Optional newLine As Boolean = False)
        lines.AddRange(list)
        If newLine Then Nl()
    End Sub

    Public Sub Nl()
        'Leerzeiche einfügen
        lines.Add(vbNullString)
    End Sub

    Public Sub Teilüberschrift(text As String)
        'Überschrift mit Trenner und Leerzeile
        lines.Add(vbTab & "////////////////////////////////////////////////////////")
        lines.Add(vbTab & vbTab & text)
        lines.Add(vbTab & "////////////////////////////////////////////////////////")
        Nl()
    End Sub

    Public Function Write(Optional addToFile As Boolean = False) As Integer

        'Backup anlegen
        If Settings.BackupAnlegen Then
            If System.IO.File.Exists(filename) Then
                My.Computer.FileSystem.CopyFile(filename, filename & "_bak")
            End If
        End If

        'Signatur und Leerzeile entfertnen wenn an Datei angehängt werden soll.
        If addToFile And lines.Count > 2 Then
            lines.RemoveAt(0)
            lines.RemoveAt(0)
        End If

        'Zeilen Schreiben
        With My.Computer.FileSystem
            If Not .DirectoryExists(filename.path) Then
                .CreateDirectory(filename.path)
            End If
            If filename.name.Contains("\") And Not .DirectoryExists(filename.path & "\" & Split(filename.name, "\")(0)) Then
                .CreateDirectory(filename.path & "\" & Split(filename.name, "\")(0))
            End If

            .WriteAllText(filename, Join(lines.ToArray, vbCrLf), addToFile, System.Text.Encoding.ASCII)
            Return lines.Count
        End With
    End Function

    Public Function Lenght() As Integer
        Return (lines.Count)
    End Function
End Class
