Public Class OMSI_Paths
    Public isloaded As Boolean
    Public filename As Filename
    Public changed As Boolean = True '#####  Wieder raus nehmen!  ######

    Public soundpacks As New List(Of List(Of String))
    Public vertices As Double()
    Public edges As Integer()
    Public dots As New List(Of Integer())

    Public arrows As New List(Of Arrow)

    Public stemsounds As New List(Of Integer)
    Public roomheight As New List(Of Double)

    Public pathPoints As New List(Of Point3D)
    Public pathLinks As New List(Of Point)
    Public oneways As New List(Of Integer)

    Public Sub New()
        Dim newName As String = "paths_" & Frm_Main.getProj.Filename.nameNoEnding & ".cfg"
        Do
            newName = InputBox("Es muss zunächst eine Datei für Pfade angelegt werden. Wie soll die Datei heißen?", "Neue Pfade-Datei anlegen...", newName)
        Loop Until newName <> ""
        filename = New Filename(newName, Frm_Main.getProj.filename.path & "\Model")
        Log.Add("Pfade-Datei hinzugefügt (Datei: " & newName & ")")
    End Sub

    Public Sub New(filename As Filename)

        If Not My.Computer.FileSystem.FileExists(filename) Then
            Log.Add("Pfad-Datei """ & filename.name & """ existiert nicht!", Log.TYPE_ERROR)
        End If
        Log.Add("Pfad-Datei """ & filename.name & """ laden...")
        Dim allLines As String() = Split(My.Computer.FileSystem.ReadAllText(filename), vbCrLf)

        Me.filename = filename

        'Dim edgesTemp As New List(Of Integer)
        Dim soundsTemp As List(Of String)
        Dim stemsoundTemp As Integer
        Dim roomheightTemp As Double

        For i = 0 To allLines.Count - 1
            Select Case allLines(i)
                Case "[stepsoundpack]"
                    soundsTemp = New List(Of String)
                    For n = i + 2 To allLines(i + 1) + i + 1
                        soundsTemp.Add(allLines(n))
                    Next
                    soundpacks.Add(soundsTemp)
                Case "[pathpnt]"
                    pathPoints.Add(New Point3D(toSingle(allLines(i + 1)), toSingle(allLines(i + 2)), toSingle(allLines(i + 3))))
                    If Not allLines(i - 1) = "" Then
                        pathPoints(pathPoints.Count - 1).Tag = allLines(i - 1)
                    End If
                    i += 3
                Case "[pathlink]"
                    pathLinks.Add(New Point(allLines(i + 1), allLines(i + 2)))
                    stemsounds.Add(stemsoundTemp)
                    roomheight.Add(roomheightTemp)

                    'edgesTemp.Add(allLines(i + 1))
                    'edgesTemp.Add(allLines(i + 2))
                    i += 2

                Case "[pathlink_oneway]"
                    pathLinks.Add(New Point(allLines(i + 1), allLines(i + 2)))
                    oneways.Add(pathLinks.Count)        'Hier liegt der Unterschied!
                    stemsounds.Add(stemsoundTemp)
                    roomheight.Add(roomheightTemp)

                    'edgesTemp.Add(allLines(i + 1))
                    'edgesTemp.Add(allLines(i + 2))
                    i += 2

                Case "[next_stepsound]"
                    stemsoundTemp = allLines(i + 1)
                Case "[next_roomheight]"
                    roomheightTemp = toSingle(allLines(i + 1))
            End Select
        Next
        'edges = edgesTemp.ToArray

        recalc()




        Log.Add("Pfad-Datei """ & filename.name & """ fertig geladen.")
    End Sub

    Public Sub recalc()

        Dim edgesTemp As New List(Of Integer)
        For Each link In pathLinks
            edgesTemp.Add(link.X)
            edgesTemp.Add(link.Y)
        Next
        edges = edgesTemp.ToArray


        Dim verticesTemp As New List(Of Double)
        For Each pnt In pathPoints
            verticesTemp.Add(-pnt.X)
            verticesTemp.Add(pnt.Z)
            verticesTemp.Add(pnt.Y)
        Next
        vertices = verticesTemp.ToArray

        dots = New List(Of Integer())
        For i = 0 To pathPoints.Count - 1
            dots.Add({i})
        Next

    End Sub


    Public Sub calcArrows(punkte As List(Of Point), richtungen As List(Of Boolean))
        arrows = New List(Of Arrow)
        For i As Integer = 0 To punkte.Count - 1
            arrows.Add(New Arrow(New Point3D(-vertices(punkte(i).X * 3), vertices(punkte(i).X * 3 + 2), vertices(punkte(i).X * 3 + 1)), New Point3D(-vertices(punkte(i).Y * 3), vertices(punkte(i).Y * 3 + 2), vertices(punkte(i).Y * 3 + 1)), richtungen(i)))
        Next
    End Sub

    Public Sub save()
        If Not changed Then Exit Sub
        Dim fw As New FileWriter(filename)
        With fw

            .teilüberschrift("Soundsets:")
            For Each soundpack In soundpacks
                .Add("[stepsoundpack]")
                .Add(soundpack.Count)
                For Each sound In soundpack
                    .Add(sound)
                Next
                .Add(vbCrLf)
            Next

            .teilüberschrift("Pathpoints:")
            For Each pathPnt In pathPoints
                If Not pathPnt.Tag Is Nothing Then
                    .Add(pathPnt.Tag)
                End If
                .Add("[pathpnt]")
                .Add(pathPnt.X)
                .Add(pathPnt.Y)
                .Add(pathPnt.Z, True)
            Next

            .teilüberschrift("Pathlinks:")

            Dim lastStepSound As Integer = -1
            Dim lastRoomHeight As Double = -1
            For i = 0 To pathLinks.Count - 1
                If Not lastStepSound = stemsounds(i) Then
                    .Add("[next_stepsound]")
                    .Add(stemsounds(i), True)
                    lastStepSound = stemsounds(i)
                End If

                If Not lastRoomHeight = roomheight(i) Then
                    .Add("[next_roomheight]")
                    .Add(roomheight(i), True)
                    lastRoomHeight = roomheight(i)
                End If

                .Add("[pathlink]")
                .Add(pathLinks(i).X)
                .Add(pathLinks(i).Y, True)
            Next

            .Write()
        End With

        Log.Add("Pfade-Datei gespeichert! (Datei: " & filename.name & ")")

    End Sub
End Class
