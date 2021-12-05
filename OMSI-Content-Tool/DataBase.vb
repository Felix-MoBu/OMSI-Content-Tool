'by Felix Modellbusse ;) (MoBu) 2019
Public Class DataBase
    Public filename As Filename

    Public Sub LoadFile(name As Filename)
        filename = New Filename(name.path & "\" & name.nameNoEnding & ".ocdb")
        If Not My.Computer.FileSystem.FileExists(filename) Then
            Log.Add("Es wurde keine Projektdatenbank geladen!")
            Log.Add("Datei: " & filename, Log.TYPE_DEBUG)
            Exit Sub
        End If

        Log.Add("Projektdatenbank laden...")

        Dim allines As List(Of String) = My.Computer.FileSystem.ReadAllText(filename).Split(vbCrLf).ToList

        Log.Add("Projektdatenbank """ & filename.name & """ fertig geladen.")
    End Sub

    Public Sub SaveFile()
        Log.Add("Projektdatenbank speichern ist noch nicht möglich", Log.TYPE_DEBUG)
    End Sub

    'Kommentar
End Class
