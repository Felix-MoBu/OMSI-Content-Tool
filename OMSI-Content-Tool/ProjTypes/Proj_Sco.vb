'by Felix Modellbusse ;) (MoBu) 2019
Imports System.Text

Public Class Proj_Sco
    Public Const TYPE = 3
    Public Const EXTENSION As String = "sco"

    Public isloaded As Boolean
    Public filename As Filename
    Public changed As Boolean = True '#####  Wieder raus nehmen!  ######

    Public position As New Point3D

    Public name As String
    Public gruppen As New List(Of String)
    Public bbox As OMSI_BBox

    Public rendertype As String 'String und integer Möglich  ->  siehe modul Rendertypes
    Public nightmapmode As Integer
    Public detail_factor As Integer
    Public complexity As Integer        '0: sehr wichtig(Kreuzung), 1: wichtig(Haltestelle), 2: normal(Telefonzelle), 3: Unwichtig(Parkbank)
    Public crashmode_pole As New Point3D    'X: Winkel / (TonnenMeter / Sekunde), Y: und Abreißwinkel, Z: nix
    Public cog As Point3D

    Public traffic_lights_group As Single
    Public traffic_lights As New List(Of OMSI_traffic_light)

    Public varlists As New List(Of String)
    Public stringvarlists As New List(Of String)
    Public scripts As New List(Of String)
    Public constfiles As New List(Of String)
    Public sound_file As Filename


    Public fixed As Boolean
    Public surface As Boolean
    Public joinable As Boolean
    Public nocollision As Boolean
    Public absheight As Boolean
    Public LightMapMapping As Boolean
    Public onlyeditor As Boolean
    Public shadow As Boolean
    Public petrolstation As Boolean
    Public nomallighting As Boolean

    Public busstop As Boolean
    Public carpark_p As Boolean
    Public entrypoint As Boolean
    Public helparrow As Boolean


    Public ki_paths As New List(Of OMSI_KIPath)
    Public attachPnts As New List(Of OMSI_Attachment)
    Public maplights As New List(Of OMSI_Maplight)

    Public cabin As OMSI_Cabin
    Public tree As OMSI_Tree

    Public splinehelpers As New List(Of OMSI_Splinehelper)
    Public helperObjects As New List(Of Integer)

    Public crossing_heightdeformation As Filename
    Public terrainhole As Filename

    Public model As OMSI_Model
    'Public subPorjs As New List(Of Proj_Sli)
    Public collisionMesh As Filename
    Public ProjDataBase As DataBase

    Public Sub New()
        'Hier das rein was zum erstellen eines Busses vorhanden sein muss!
    End Sub


    Public Sub New(filepath As String)
        filename = New Filename(filepath)
        If System.IO.File.Exists(filepath) Then
            Log.Add("Projekt """ & filename.name & """ laden...")
            Dim allLines As String() = System.IO.File.ReadAllLines(filename, Encoding.GetEncoding(1252))

            If allLines.Contains("[particle_emitter]") Then
                MsgBox("Feuerwerk wird nicht unterstützt!")
                Exit Sub
            End If

            For linect = 0 To allLines.Count - 1
                Select Case LCase(allLines(linect))
                    Case "[groups]"
                        If IsNumeric(allLines(linect + 1)) Then
                            For i = linect + 2 To linect + 2 + allLines(linect + 1) - 1
                                gruppen.Add(allLines(i))
                            Next
                            linect += 2 + allLines(linect + 1)
                        End If
                    Case "[friendlyname]"
                        name = allLines(linect + 1)
                    Case "[model]"
                        model = New OMSI_Model(New Filename(allLines(linect + 1), filename.path))
                    Case "[fixed]"
                        fixed = True
                    Case "[joinable]"
                        joinable = True
                    Case "[nocollision]"
                        nocollision = True
                    Case "[absheight]"
                        absheight = True
                    Case "[surface]"
                        surface = True
                    Case "[LightMapMapping]"
                        LightMapMapping = True
                    Case "[NightMapMode]"
                        nightmapmode = allLines(linect + 1)
                    Case "[onlyeditor]"
                        onlyeditor = True
                    Case "[shadow]"
                        shadow = True
                    Case "[petrolstation]"
                        petrolstation = True
                    Case "[crossing_heightdeformation]"
                        crossing_heightdeformation = New Filename(allLines(linect + 1), filename.path & "\Model")
                    Case "[terrainhole]"
                        terrainhole = New Filename(allLines(linect + 1), filename.path & "\Model")
                    Case "[busstop]"
                        busstop = True
                    Case "[carpark_p]"
                        carpark_p = True
                    Case "[entrypoint]"
                        entrypoint = True
                    Case "[helparrow]"
                        helparrow = True
                    Case "[nomaplighting]"
                        nomallighting = True
                    Case "[complexity]"
                        complexity = allLines(linect + 1)
                    Case "[collision_mesh]"
                        collisionMesh = New Filename(allLines(linect + 1), filename.path & "\Model")
                    Case "[rendertype]"
                        rendertype = allLines(linect + 1)
                    Case "[detail_factor]"
                        detail_factor = allLines(linect + 1)
                    Case "[sound]"
                        sound_file = New Filename(allLines(linect + 1), filename.path & "\Sound")
                    Case "[crashmode_pole]"
                        crashmode_pole = New Point3D(toSingle(allLines(linect + 1)), toSingle(allLines(linect + 2)), 0)
                    Case "[cog]"
                        cog = New Point3D(toSingle(allLines(linect + 1)), toSingle(allLines(linect + 2)), toSingle(allLines(linect + 3)))
                    Case "[boundingbox]"
                        bbox = New OMSI_BBox(toSingle(allLines(linect + 1)), toSingle(allLines(linect + 2)), toSingle(allLines(linect + 3)), toSingle(allLines(linect + 4)), toSingle(allLines(linect + 5)), toSingle(allLines(linect + 6)))
                    Case "[maplight]"
                        Dim newMaplight As New OMSI_Maplight
                        With newMaplight
                            .position = New Point3D(toSingle(allLines(linect + 1)), toSingle(allLines(linect + 2)), toSingle(allLines(linect + 3)))
                            .color = Color.FromArgb(toSingle(allLines(linect + 4)) * 255, toSingle(allLines(linect + 5)) * 255, toSingle(allLines(linect + 6)) * 255)
                            .radius = toSingle(allLines(linect + 7))
                        End With
                        Maplights.Add(newMaplight)
                    Case "[tree]"
                        tree = New OMSI_Tree
                        With tree
                            .texture = allLines(linect + 1)
                            .minheight = toSingle(linect + 2)
                            .maxheight = toSingle(linect + 3)
                            .minratio = toSingle(linect + 4)
                            .maxratio = toSingle(linect + 5)
                        End With
                        linect += 5
                    Case "[splinehelper]"
                        Dim tmpHelper As New OMSI_Splinehelper
                        With tmpHelper
                            .spline = New Filename(allLines(linect + 1), My.Settings.OmsiPfad)
                            .position = New Point3D(toSingle(allLines(linect + 2)), toSingle(allLines(linect + 3)), toSingle(allLines(linect + 4)))
                            .rotation = New Point3D(toSingle(allLines(linect + 5)), toSingle(allLines(linect + 6)), toSingle(allLines(linect + 7)))
                        End With
                        splinehelpers.Add(tmpHelper)
                        linect += 7
                    Case "[path]"
                        Dim newPath As New OMSI_KIPath
                        With newPath
                            .position = New Point3D(toSingle(allLines(linect + 1)), toSingle(allLines(linect + 2)), toSingle(allLines(linect + 3)))
                            .rot_z = toSingle(allLines(linect + 4))
                            .radius = toSingle(allLines(linect + 5))
                            .length = toSingle(allLines(linect + 6))
                            .start_grad = toSingle(allLines(linect + 7))
                            .end_grad = toSingle(allLines(linect + 8))
                            .type = allLines(linect + 9)
                            .width = toSingle(allLines(linect + 10))
                            .direction = allLines(linect + 11)
                            .blinker = allLines(linect + 12)

                            .recalc()
                            linect += 12

                            For i = linect To allLines.Count - 1
                                If allLines(i) = "[use_traffic_light]" Then
                                    .traffic_light = allLines(i + 1)
                                    Exit For
                                Else
                                    If allLines(i).Contains("[") Then Exit For
                                End If
                            Next
                        End With

                        ki_paths.Add(newPath)

                    Case "[varnamelist]"
                        Dim varlistct As Integer = allLines(linect + 1)
                        For listct As Integer = linect + 2 To varlistct + linect + 1
                            varlists.Add(allLines(listct))
                        Next
                        linect = linect + varlistct + 2
                    Case "[stringvarnamelist]"
                        Dim stringvarlistct As Integer = allLines(linect + 1)
                        For listct As Integer = linect + 2 To stringvarlistct + linect + 1
                            stringvarlists.Add(allLines(listct))
                        Next
                        linect = linect + stringvarlistct + 2
                    Case "[script]"
                        Dim scriptct As Integer = allLines(linect + 1)
                        For listct As Integer = linect + 2 To scriptct + linect + 1
                            scripts.Add(allLines(listct))
                        Next
                        linect = linect + scriptct + 2
                    Case "[constfile]"
                        Dim constfilect As Integer = allLines(linect + 1)
                        For listct As Integer = linect + 2 To constfilect + linect + 1
                            constfiles.Add(allLines(listct))
                        Next
                        linect = linect + constfilect + 2
                    Case "[passengercabin]"
                        cabin = New OMSI_Cabin(New Filename(allLines(linect + 1), filename.path))
                    Case "[new_attachment]"
                        For i = linect To allLines.Count - 1
                            If allLines(i).Contains("[") Then
                                linect += i - 1
                                Exit For
                            End If
                            If allLines(i) = "attach_trans" Then
                                Dim newAtp As New OMSI_Attachment
                                With newAtp
                                    .attach_pnt = New Point3D(toSingle(allLines(i + 1)), toSingle(allLines(i + 2)), toSingle(allLines(i + 3)))
                                End With
                                attachPnts.Add(newAtp)
                                Exit For
                            End If
                        Next
                    Case "[traffic_lights_group]"
                        traffic_lights_group = allLines(linect + 1)
                        For i = linect + 1 To allLines.Count - 1
                            With traffic_lights
                                If allLines(i) = "[traffic_light]" Then
                                    Dim newlight As New OMSI_traffic_light
                                    newlight.name = allLines(i + 1)
                                    For n = i + 1 To allLines.Count - 1
                                        If allLines(n) = "[phase]" Then
                                            Dim newPhase As New OMSI_TrafficLightPhase
                                            newPhase.type = allLines(n + 1)
                                            newPhase.length = toSingle(allLines(n + 2))
                                            newlight.phasen.Add(newPhase)
                                            i = n
                                        Else
                                            If allLines(n) = "[approachdist]" Then
                                                newlight.approachdist = toSingle(allLines(n + 1))
                                            Else
                                                If allLines(n).Contains("[") Then
                                                    i = n - 1
                                                    Exit For
                                                End If
                                            End If
                                        End If
                                    Next
                                    .Add(newlight)
                                    linect = i
                                Else
                                    If allLines(i).Contains("[") Then
                                        linect = i - 1
                                        Exit For
                                    End If
                                End If
                            End With
                        Next
                    Case Else
                        If allLines(linect).Length > 0 Then
                            If allLines(linect)(0) = vbTab Then
                                If allLines(linect).Contains("[") And allLines(linect).Contains("[") Then
                                    Log.Add("""" & allLines(linect) & """ ist ein ungültiger Tag!", Log.TYPE_DEBUG)
                                End If
                            End If
                        End If
                End Select
            Next

            If model Is Nothing Then
                model = New OMSI_Model(filename)
            End If

            ProjDataBase = New DataBase(filename)
            Log.Add("Projekt """ & filename.name & """ fertig geladen.")
            isloaded = True
        Else
            Log.Add("Objekt nicht gefunden! (" & filename & ")")
        End If
    End Sub

    Public Sub save()
        If Not changed Then Exit Sub
        Dim writer As New FileWriter(filename)
        With writer
            .Add("[friendlyname]")
            .Add(name, True)

            .Add("[groups]")
            .Add(gruppen.Count)
            For Each gruppe In gruppen
                .Add(gruppe)
            Next
            .Nl()

            If Not model.filename = filename Then
                .Add("[model]")
                .Add(model.filename.name, True)
            End If

            If Not sound_file Is Nothing Then
                .Add("[sound]")
                .Add(sound_file.name, True)
            End If

            If varlists.Count > 0 Then
                .Add("[varnamelist]")
                .Add(varlists.Count)
                For Each varlist In varlists
                    .Add(varlist)
                Next
                .Nl()
            End If

            If stringvarlists.Count > 0 Then
                .Add("[stringvarnamelist]")
                .Add(stringvarlists.Count)
                For Each svlist In stringvarlists
                    .Add(svlist)
                Next
                .Nl()
            End If

            If constfiles.Count > 0 Then
                .Add("[constfile]")
                .Add(constfiles.Count)
                For Each constfile In constfiles
                    .Add(constfile)
                Next
                .Nl()
            End If

            If scripts.Count > 0 Then
                .Add("[script]")
                .Add(scripts.Count)
                For Each script In scripts
                    .Add(script)
                Next
                .Nl()
            End If

            If Not cabin Is Nothing Then
                .Add("[passengercabin]")
                .Add(cabin.filename.name, True)
            End If



            If rendertype <> "" Then
                .Add("[rendertype]")
                .Add(rendertype, True)
            End If

            If fixed Then .Add("[fixed]", True)
            If joinable Then .Add("[joinable]", True)
            If nocollision Then .Add("[nocollision]", True)
            If absheight Then .Add("[absheight]", True)
            If surface Then .Add("[surface]", True)
            If LightMapMapping Then .Add("[LightMapMapping]", True)
            If onlyeditor Then .Add("[onlyeditor]", True)
            If shadow Then .Add("[shadow]", True)
            If petrolstation Then .Add("[petrolstation]", True)
            If busstop Then .Add("[busstop]", True)
            If carpark_p Then .Add("[carpark_p]", True)
            If entrypoint Then .Add("[entrypoint]", True)
            If helparrow Then .Add("[helparrow]", True)
            If nomallighting Then .Add("[nomaplighting]", True)

            If complexity <> 0 Then
                .Add("[complexity]")
                .Add(complexity, True)
            End If

            If detail_factor <> 0 Then
                .Add("[detail_factor]")
                .Add(detail_factor, True)
            End If

            If Not collisionMesh Is Nothing Then
                .Add("[collision_mesh]")
                .Add(collisionMesh.name, True)
            End If

            If Not crossing_heightdeformation Is Nothing Then
                .Add("[crossing_heightdeformation]")
                .Add(crossing_heightdeformation.name, True)
            End If

            If Not terrainhole Is Nothing Then
                .Add("[terrainhole]")
                .Add(terrainhole.name, True)
            End If

            If Not crashmode_pole Is Nothing Then
                If Not crashmode_pole.X = 0 And Not crashmode_pole.Y = 0 Then
                    .Add("[crashmode_pole]")
                    .Add(crashmode_pole.X)
                    .Add(crashmode_pole.Y, True)
                End If
            End If

            If Not cog Is Nothing Then
                .Add("[cog]")
                .Add(cog.X)
                .Add(cog.Y)
                .Add(cog.Z, True)
            End If

            If Not bbox Is Nothing Then
                .Add("[boundingbox]")
                .Add(fromSingle(bbox.size.X) & vbCrLf & fromSingle(bbox.size.Y) & vbCrLf & fromSingle(bbox.size.Z))
                .Add(fromSingle(bbox.pos.X) & vbCrLf & fromSingle(bbox.pos.Y) & vbCrLf & fromSingle(bbox.pos.Z), True)
            End If

            For Each maplight In maplights
                .Add("[maplight]")
                .Add(maplight.position.X)
                .Add(maplight.position.Y)
                .Add(maplight.position.Z)
                .Add(maplight.color.R)
                .Add(maplight.color.G)
                .Add(maplight.color.B)
                .Add(fromSingle(maplight.radius), True)
            Next

            If Not tree Is Nothing Then
                .Add("[tree]")
                .Add(tree.texture)
                .Add(tree.minheight)
                .Add(tree.maxheight)
                .Add(tree.minratio)
                .Add(tree.maxratio, True)
            End If

            If traffic_lights_group <> 0 Then
                .teilüberschrift("Ampelschaltung")

                .Add("[traffic_lights_group]")
                .Add(traffic_lights_group, True)

                For Each tl In traffic_lights
                    .Add("[traffic_light]")
                    .Add(tl.name, True)

                    For Each phase In tl.phasen
                        .Add("[phase]")
                        .Add(phase.type)
                        .Add(phase.length, True)
                    Next

                    If tl.approachdist > -1 Then
                        .Add("[approachdist]")
                        .Add(tl.approachdist, True)
                    End If
                Next
            End If


            If splinehelpers.Count > 0 Then
                .teilüberschrift("Splinehelper")

                For Each splinehelper In splinehelpers
                    .Add("[splinehelper]")
                    .Add(splinehelper.spline.name)
                    .Add(splinehelper.position.X)
                    .Add(splinehelper.position.Y)
                    .Add(splinehelper.position.Z)

                    .Add(splinehelper.rotation.X)
                    .Add(splinehelper.rotation.Y)
                    .Add(splinehelper.rotation.Z, True)
                Next
            End If


            If ki_paths.Count > 0 Then
                .teilüberschrift("Pfade")

                For Each path In ki_paths
                    .Add("[path]")
                    .Add(path.position.X)
                    .Add(path.position.Y)
                    .Add(path.position.Z)

                    .Add(path.rot_z)
                    .Add(path.radius)
                    .Add(path.length)
                    .Add(path.start_grad)
                    .Add(path.end_grad)
                    .Add(path.type)
                    .Add(path.width)
                    .Add(path.direction)
                    .Add(path.blinker, True)

                    If path.traffic_light > -1 Then
                        .Add("[use_traffic_light]")
                        .Add(path.traffic_light, True)
                    End If
                Next
            End If

            For Each attpnt In attachPnts
                .Add("[new_attachment]", True)
                .Add("attach_trans")
                .Add(attpnt.attach_pnt.X)
                .Add(attpnt.attach_pnt.Y)
                .Add(attpnt.attach_pnt.Z, True)
            Next

            .Nl()
        End With

        writer.Write()

        If Not model.filename = filename Then
            model.save(False)
        Else
            model.save(True)
        End If
    End Sub

    Public Function usedFiles() As List(Of Filename)
        usedFiles = New List(Of Filename)
        With usedFiles
            .Add(filename)
            .AddRange(model.usedFiles)

        End With
        Return usedFiles
    End Function
End Class
