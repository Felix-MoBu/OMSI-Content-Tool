'by Felix Modellbusse ;) (MoBu) 2019
Imports System.Text

Public Class Proj_Bus
    Public Const TYPE As Byte = 1
    Public Const EXTENSION As String = "bus"

    Public isloaded As Boolean
    Public filename As Filename
    Public changed As Boolean = True '#####  Wieder raus nehmen!  ######

    Public hersteller As String
    Public typ As String
    Public anstrich As String

    Public beschreibung As New List(Of String)
    Public number_path As String
    Public reg_list As String
    Public reg_auto_pre As String
    Public reg_auto_post As String
    Public reg_free As Boolean
    Public aiVehicleType As Byte = AI_TYPE.NOT_SELECTED

    Public baujahr As Integer
    Public laufleistung As String

    Public sound_file As Filename
    Public sound_ai_file As Filename
    Public model As OMSI_Model
    Public paths As OMSI_Paths
    Public cabin As OMSI_Cabin

    Public varlists As New List(Of String)
    Public stringvarlists As New List(Of String)
    Public scripts As New List(Of String)
    Public constfiles As New List(Of String)
    Public scriptshare As Boolean

    Public driver_cam_list As New List(Of OMSI_Camera)
    Public pax_cam_list As New List(Of OMSI_Camera)
    Public cam_std As Byte
    Public cam_outeside As New Point3D
    Public spiegel As New List(Of OMSI_ReflexCamera)
    Public ticketblöcke As New List(Of OMSI_Attachment)

    Public masse As Single
    Public trägheit As New Point3D
    Public bbox As OMSI_BBox
    Public cog As New Point3D
    Public schwerpunkt As Single
    Public rollwiederstand As Integer
    Public drehpunkt As Single
    Public lenkradius As Single
    Public aiheight As Single

    Public achsen As New List(Of OMSI_Achse)

    Public couple_back As Boolean
    Public couple_back_point As Point3D
    Public couple_back_file As Filename
    Public couple_back_dir As Boolean
    Public couple_back_sphere As LocalSphere

    Public couple_front As Boolean
    Public couple_front_point As Point3D
    Public couple_front_sound As Boolean
    Public couple_front_char As Point3D
    Public couple_front_type As Boolean

    Public ProjDataBase As DataBase

    Public Structure AI_TYPE
        Const CAR As Byte = 0
        Const TAXI As Byte = 1
        Const BUS As Byte = 2
        Const TRUCK As Byte = 3
        Const NOT_SELECTED As Byte = 255
    End Structure

    Public Structure COUPLE_TYPE
        Const LKW As Boolean = False
        Const BUS As Boolean = True
    End Structure

    Public Sub New()
        'ggf löschen, damit kein leeres Projekt erstellt werden kann!
    End Sub

    Public Sub New(filepath As String)
        Dim tmppath = Split(filepath, "\")
        Dim camReflexIndex As Byte = 0

        filename = New Filename(filepath)
        If System.IO.File.Exists(filename.path & "\" & filename.name) Then
            Log.Add("Projekt """ & filename.name & """ laden...")
            Dim allLines As String() = System.IO.File.ReadAllLines(filename, Encoding.GetEncoding(1252))

            For linect = 0 To allLines.Count - 1
                Select Case allLines(linect)
                    Case "[friendlyname]"
                        hersteller = allLines(linect + 1)
                        typ = allLines(linect + 2)
                        anstrich = allLines(linect + 3)
                        linect += 3
                    Case "[description]"
                        For decct = linect + 1 To allLines.Count - 1
                            If allLines(decct) = "[end]" Then
                                linect = decct
                                Exit For
                            End If
                            beschreibung.Add(allLines(decct))
                        Next
                    Case "[number]"
                        number_path = allLines(linect + 1)
                    Case "[registration_free]"
                        reg_free = False
                    Case "[registration_automatic]"
                        reg_auto_pre = allLines(linect + 1)
                        reg_auto_post = allLines(linect + 2)
                        linect += 2
                    Case "[registration_list]"
                        reg_list = allLines(linect + 1)
                    Case "[kmcounter_init]"
                        baujahr = allLines(linect + 1)
                        laufleistung = allLines(linect + 2)
                        linect += 2
                    Case "[sound]"
                        sound_file = New Filename(allLines(linect + 1), filename.path)
                    Case "[sound_ai]"
                        sound_ai_file = New Filename(allLines(linect + 1), filename.path)
                    Case "[model]"
                        model = New OMSI_Model(New Filename(allLines(linect + 1), filename.path))
                    Case "[paths]"
                        paths = New OMSI_Paths(New Filename(allLines(linect + 1), filename.path))
                    Case "[passengercabin]"
                        cabin = New OMSI_Cabin(New Filename(allLines(linect + 1), filename.path))
                    Case "[ai_veh_type]"
                        aiVehicleType = toByte(allLines(linect + 1))
                    Case "[scriptshare]"
                        scriptshare = True
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
                    Case "[view_schedule]"
                        driver_cam_list(driver_cam_list.Count - 1).schedule = True
                        linect += 1
                    Case "[view_ticketselling]"
                        driver_cam_list(driver_cam_list.Count - 1).selling = True
                        linect += 1
                    Case "[add_camera_driver]"
                        Dim newCam As New OMSI_Camera
                        With newCam
                            .type = 0
                            .name = Replace(allLines(linect - 1), vbTab, "")
                            .position = New Point3D(toSingle(allLines(linect + 1)), toSingle(allLines(linect + 2)), toSingle(allLines(linect + 3)))
                            .dist = toSingle(allLines(linect + 4))
                            .sichtwinkel = toSingle(allLines(linect + 5))
                            .rotX = toSingle(allLines(linect + 6))
                            .rotY = toSingle(allLines(linect + 7))
                            .PositionCam()
                        End With
                        driver_cam_list.Add(newCam)
                        linect += 7
                    Case "[add_camera_pax]"
                        Dim newCam As New OMSI_Camera
                        With newCam
                            .type = 1
                            .name = Replace(allLines(linect - 1), vbTab, "")
                            .position = New Point3D(toSingle(allLines(linect + 1)), toSingle(allLines(linect + 2)), toSingle(allLines(linect + 3)))
                            .dist = toSingle(allLines(linect + 4))
                            .sichtwinkel = toSingle(allLines(linect + 5))
                            .rotX = toSingle(allLines(linect + 6))
                            .rotY = toSingle(allLines(linect + 7))
                            .PositionCam()
                        End With
                        pax_cam_list.Add(newCam)
                        linect += 7
                    Case "[set_camera_std]"
                        cam_std = toSingle(allLines(linect + 1))
                    Case "[set_camera_outside_center]"
                        cam_outeside = New Point3D(toSingle(allLines(linect + 1)), toSingle(allLines(linect + 2)), toSingle(allLines(linect + 3)))
                        linect += 3
                    Case "[add_camera_reflexion_2]"
                        Dim newCam As New OMSI_ReflexCamera
                        With newCam
                            .typ = 1
                            .index = camReflexIndex
                            .position = New Point3D(toSingle(allLines(linect + 1)), toSingle(allLines(linect + 2)), toSingle(allLines(linect + 3)))
                            .dist = toSingle(allLines(linect + 4))
                            .sichtwinkel = toSingle(allLines(linect + 5))
                            .rotX = toSingle(allLines(linect + 6))
                            .rotY = toSingle(allLines(linect + 7))
                            .renderDist = toSingle(allLines(linect + 8))
                            .PositionCam()
                            camReflexIndex += 1
                        End With
                        spiegel.Add(newCam)
                        linect += 8
                    Case "[add_camera_reflexion]"
                        Dim newCam As New OMSI_ReflexCamera
                        With newCam
                            .typ = 0
                            .index = camReflexIndex
                            .position = New Point3D(toSingle(allLines(linect + 1)), toSingle(allLines(linect + 2)), toSingle(allLines(linect + 3)))
                            .dist = toSingle(allLines(linect + 4))
                            .sichtwinkel = toSingle(allLines(linect + 5))
                            .rotX = toSingle(allLines(linect + 6))
                            .rotY = toSingle(allLines(linect + 7))
                            .PositionCam()
                            camReflexIndex += 1
                        End With
                        spiegel.Add(newCam)
                        linect += 7
                    Case "[new_attachment]"
                        Dim newTicketBlock As New OMSI_Attachment
                        With newTicketBlock
                            If allLines(linect - 1) <> "" Then .name = allLines(linect - 1)
                            For i = linect + 1 To allLines.Count - 1
                                Select Case allLines(i)
                                    Case "attach_rot_x"
                                        .attach_rot.X = toSingle(allLines(i + 1))
                                    Case "attach_rot_y"
                                        .attach_rot.Y = toSingle(allLines(i + 1))
                                    Case "attach_rot_z"
                                        .attach_rot.Z = toSingle(allLines(i + 1))
                                    Case "attach_trans"
                                        .attach_pnt = New Point3D(toSingle(allLines(i + 1)), toSingle(allLines(i + 2)), toSingle(allLines(i + 3)))
                                        i += 3
                                    Case Else
                                        If allLines(i).Contains("[") And allLines(i).Contains("]") Then
                                            linect = i - 1
                                            Exit For
                                        End If
                                End Select
                            Next
                        End With
                        ticketblöcke.Add(newTicketBlock)
                    Case "[mass]"
                        masse = toSingle(allLines(linect + 1))
                    Case "[momentofintertia]"
                        trägheit = New Point3D(toSingle(allLines(linect + 1)), toSingle(allLines(linect + 2)), toSingle(allLines(linect + 3)))
                    Case "[boundingbox]"
                        bbox = New OMSI_BBox(toSingle(allLines(linect + 1)), toSingle(allLines(linect + 2)), toSingle(allLines(linect + 3)), toSingle(allLines(linect + 4)), toSingle(allLines(linect + 5)), toSingle(allLines(linect + 6)))
                        If bbox.size.dist(0) = 0 Then bbox = Nothing
                    Case "[cog]"
                        cog = New Point3D(toSingle(allLines(linect + 1)), toSingle(allLines(linect + 2)), toSingle(allLines(linect + 3)))
                    Case "[schwerpunkt]"
                        schwerpunkt = toSingle(allLines(linect + 1))
                    Case "[rollwiderstand]"
                        rollwiederstand = toSingle(allLines(linect + 1))
                    Case "[rot_pnt_long]"
                        drehpunkt = toSingle(allLines(linect + 1))
                    Case "[inv_min_turnradius]"
                        lenkradius = toSingle(allLines(linect + 1))
                    Case "[ai_deltaheight]"
                        aiheight = toSingle(allLines(linect + 1))
                    Case "[newachse]"
                        Dim newAchse As New OMSI_Achse
                        With newAchse
                            For i = linect + 1 To allLines.Count - 1
                                Select Case allLines(i)
                                    Case "achse_long"
                                        .Y = toSingle(allLines(i + 1))
                                    Case "achse_maxwidth"
                                        .maxwidth = toSingle(allLines(i + 1))
                                    Case "achse_minwidth"
                                        .minwidth = toSingle(allLines(i + 1))
                                    Case "achse_raddurchmesser"
                                        .raddurchmesser = toSingle(allLines(i + 1))
                                    Case "achse_feder"
                                        .feder = toSingle(allLines(i + 1))
                                    Case "achse_maxforce"
                                        .maxforce = toSingle(allLines(i + 1))
                                    Case "achse_daempfer"
                                        .daempfer = toSingle(allLines(i + 1))
                                    Case "achse_antrieb"
                                        .antrieb = toSingle(allLines(i + 1))
                                        Exit For
                                    Case Else
                                        If allLines(i).Contains("[") Then
                                            linect = i - 1
                                            Exit For
                                        End If
                                End Select
                            Next
                            achsen.Add(newAchse)
                        End With
                    Case "[coupling_back]"
                        couple_back = True
                        couple_back_point = New Point3D(toSingle(allLines(linect + 1)), toSingle(allLines(linect + 2)), toSingle(allLines(linect + 3)))
                        couple_back_sphere = New LocalSphere(couple_back_point, 0.3)
                    Case "[couple_back]"
                        couple_back_file = New Filename(allLines(linect + 1), filename.path)
                        couple_back_dir = stringToBool(allLines(linect + 2))
                    Case "[couple_front_open_for_sound]"
                        couple_front_sound = True
                    Case "[coupling_front]"
                        couple_front = True
                        couple_front_point = New Point3D(toSingle(allLines(linect + 1)), toSingle(allLines(linect + 2)), toSingle(allLines(linect + 3)))
                    Case "[coupling_front_character]"
                        couple_front_char = New Point3D(toSingle(allLines(linect + 1)), toSingle(allLines(linect + 2)), toSingle(allLines(linect + 3)))
                        couple_front_type = toBool(allLines(linect + 4))
                    Case Else
                        If allLines(linect) <> "" Then
                            If allLines(linect).Substring(0, 1) = "[" Then
                                MsgBox("Der Eintrag """ & allLines(linect) & """ ist kein gültiges Schlüsselwort. (Zeile: " & linect & ")" & vbCrLf & "Der Eintrag wir nach dem Speichern verloren gehen!", vbOKOnly)
                                Log.Add("Ungültiges Schlüssewort! (Eintrag: """ & allLines(linect) & """Zeile: " & linect & ")", Log.TYPE_ERROR)
                            End If
                        End If
                End Select
            Next

            If model Is Nothing Then model = New OMSI_Model
            If model.filename Is Nothing Then model = New OMSI_Model(filename)
            ProjDataBase = New DataBase(filename)
            Log.Add("Projekt """ & filename.name & """ fertig geladen.")
            isloaded = True
        Else
            Log.Add("Bus nicht gefunden! (" & filepath & ")")
        End If



    End Sub

    Public Sub save(Optional only_save_proj As Boolean = False)
        If filename = "" Then
            Log.Add("Kein Speicherort für Bus-Datei festgelegt!", Log.TYPE_ERROR)
            Exit Sub
        End If

        If Not changed Then Exit Sub

        Dim newFile As New FileWriter(filename)
        With newFile

            If Not couple_front Then
                If typ <> "" Then
                    .Add("[friendlyname]")
                    .Add(hersteller)
                    .Add(typ)
                    .Add(anstrich, True)
                End If
            End If

            If beschreibung.Count > 0 Then
                .AddTag("description", beschreibung)
                .Add("[end]", True)
            End If

            If number_path <> "" Then
                .AddTag("number", number_path, True)
            End If

            If reg_free Then
                .Add("[registration_free]", True)
            End If

            If reg_auto_pre <> "" Then
                .Add("[registration_automatic]")
                .Add(reg_auto_pre)
                .Add(reg_auto_post, True)
            End If

            If reg_list <> "" Then
                .AddTag("registration_list", reg_list, True)
            End If

            If baujahr > 0 Then
                .Add("[kmcounter_init]")
                .Add(baujahr)
                .Add(laufleistung, True)
            End If

            If Not sound_file Is Nothing Then
                .AddTag("sound", sound_file.name, True)
            End If

            If Not sound_ai_file Is Nothing Then
                .AddTag("sound_ai", sound_ai_file.name, True)
            End If

            If Not model Is Nothing Then
                If Not model.filename Is Nothing Then
                    .AddTag("model", model.filename.name, True)
                End If
            End If

            If Not paths Is Nothing Then
                .AddTag("paths", paths.filename.name, True)
            End If

            If Not cabin Is Nothing Then
                .AddTag("passengercabin", cabin.filename.name, True)
            End If

            If Not aiVehicleType = AI_TYPE.NOT_SELECTED Then
                .AddTag("ai_veh_type", aiVehicleType, True)
            End If

            .Teilüberschrift("Scripts")

            If scriptshare Then
                .Add("[scriptshare]", True)
            End If

            If varlists.Count > 0 Then
                .AddTag("varnamelist", varlists.Count)
                For Each file In varlists
                    .Add(file)
                Next
                .Add(vbCrLf)
            End If

            If stringvarlists.Count > 0 Then
                .AddTag("stringvarnamelist", stringvarlists.Count)
                For Each file In stringvarlists
                    .Add(file)
                Next
                .Add(vbCrLf)
            End If

            If scripts.Count > 0 Then
                .AddTag("script", scripts.Count)
                For Each file In scripts
                    .Add(file)
                Next
                .Add(vbCrLf)
            End If

            If constfiles.Count > 0 Then
                .AddTag("constfile", constfiles.Count)
                For Each file In constfiles
                    .Add(file)
                Next
                .Add(vbCrLf)
            End If

            .teilüberschrift("Kameras (Fahrer)")

            For Each camera In driver_cam_list
                If camera.name <> "" Then
                    .Add(vbTab & camera.name)
                End If
                .Add("[add_camera_driver]")
                .Add(fromSingle(camera.position.X) & vbCrLf & fromSingle(camera.position.Y) & vbCrLf & fromSingle(camera.position.Z))
                .Add(camera.dist)
                .Add(camera.sichtwinkel)
                .Add(camera.rotX)
                .Add(camera.rotY, True)

                If camera.selling Then
                    .Add("[view_ticketselling]", True)
                End If

                If camera.schedule Then
                    .Add("[view_schedule]", True)
                End If
            Next

            .Add("[set_camera_std]")
            .Add(cam_std, True)

            .teilüberschrift("Passagiersichten")

            For Each camera In pax_cam_list
                If camera.name <> "" Then
                    .Add(vbTab & camera.name)
                End If
                .Add("[add_camera_pax]")
                .Add(fromSingle(camera.position.X) & vbCrLf & fromSingle(camera.position.Y) & vbCrLf & fromSingle(camera.position.Z))
                .Add(camera.dist)
                .Add(camera.sichtwinkel)
                .Add(camera.rotX)
                .Add(camera.rotY, True)
            Next

            .Add("[set_camera_outside_center]")
            .Add(fromSingle(cam_outeside.X) & vbCrLf & fromSingle(cam_outeside.Y) & vbCrLf & fromSingle(cam_outeside.Z), True)

            .teilüberschrift("Reflexionskameras *NEU01*")

            For Each mirror In spiegel
                If mirror.typ = 0 Then
                    .Add("[add_camera_reflexion]")
                Else
                    .Add("[add_camera_reflexion_2]")
                End If
                .Add(fromSingle(mirror.position.X) & vbCrLf & fromSingle(mirror.position.Y) & vbCrLf & fromSingle(mirror.position.Z))
                .Add(mirror.dist)
                .Add(mirror.sichtwinkel)
                .Add(mirror.rotX)
                .Add(mirror.rotY)
                If mirror.typ = 1 Then .Add(mirror.renderDist)
                .Add(vbCrLf)
            Next

            If ticketblöcke.Count > 0 Then
                .teilüberschrift("ticket block attach points")
                Dim ct As Integer = 0
                For Each ticket In ticketblöcke
                    If ticket.name <> "" Then
                        .Add(ticket.name)
                    Else
                        .Add("ticket type " & ct & ":")
                    End If
                    .Add("[new_attachment]")
                    If ticket.attach_rot.X <> 0 Then
                        .Add("attach_rot_x")
                        .Add(ticket.attach_rot.X)
                    End If
                    If ticket.attach_rot.Y <> 0 Then
                        .Add("attach_rot_y")
                        .Add(ticket.attach_rot.Y)
                    End If
                    If ticket.attach_rot.Z <> 0 Then
                        .Add("attach_rot_z")
                        .Add(ticket.attach_rot.Z)
                    End If
                    .Add("attach_trans")
                    .Add(ticket.attach_pnt.X)
                    .Add(ticket.attach_pnt.Y)
                    .Add(ticket.attach_pnt.Z, True)
                    ct += 1
                Next
            End If

            .teilüberschrift("Physikalische und geometrische Grunddaten")

            .AddTag("mass", masse, True)

            .Add("[momentofintertia]")
            .Add(fromSingle(trägheit.X) & vbCrLf & fromSingle(trägheit.Y) & vbCrLf & fromSingle(trägheit.Z), True)

            If Not bbox Is Nothing Then
                .Add("[boundingbox]")
                .Add(fromSingle(bbox.size.X) & vbCrLf & fromSingle(bbox.size.Y) & vbCrLf & fromSingle(bbox.size.Z))
                .Add(fromSingle(bbox.pos.X) & vbCrLf & fromSingle(bbox.pos.Y) & vbCrLf & fromSingle(bbox.pos.Z), True)
            End If

            If Not cog.dist(New Point3D) = 0 Then
                .Add("[cog]")
                .Add(fromSingle(cog.X) & vbCrLf & fromSingle(cog.Y) & vbCrLf & fromSingle(cog.Z), True)
            End If

            .AddTag("schwerpunkt", schwerpunkt, True)
            .AddTag("rollwiderstand", rollwiederstand, True)
            .AddTag("rot_pnt_long", drehpunkt, True)
            .AddTag("inv_min_turnradius", lenkradius, True)
            .AddTag("ai_deltaheight", aiheight, True)

            .teilüberschrift("Achsen")

            For Each achse In achsen
                .Add("[newachse]")
                .Add("achse_long" & vbCrLf & fromSingle(achse.Y))
                .Add("achse_maxwidth" & vbCrLf & fromSingle(achse.maxwidth))
                .Add("achse_minwidth" & vbCrLf & fromSingle(achse.minwidth))
                .Add("achse_raddurchmesser" & vbCrLf & fromSingle(achse.raddurchmesser))
                .Add("achse_feder" & vbCrLf & fromSingle(achse.feder))
                .Add("achse_maxforce" & vbCrLf & fromSingle(achse.maxforce))
                .Add("achse_daempfer" & vbCrLf & fromSingle(achse.daempfer))
                .Add("achse_antrieb" & vbCrLf & fromBool(achse.antrieb), True)
            Next

            If couple_back Then
                .Add("[coupling_back]")
                .Add(fromSingle(couple_back_point.X) & vbCrLf & fromSingle(couple_back_point.Y) & vbCrLf & fromSingle(couple_back_point.Z), True)

                If Not couple_back_file Is Nothing Then
                    If Replace(couple_back_file.name, "\", "") <> "" Then
                        .Add("[couple_back]")
                        If couple_back_file.path = filename.path Then
                            .Add(couple_back_file.name)
                        Else
                            .Add(couple_back_file)
                        End If

                        .Add(boolToInt(couple_back_dir), True)
                    End If
                End If
            End If

            If couple_front Then
                .Add("[coupling_front]")
                .Add(fromSingle(couple_front_point.X) & vbCrLf & fromSingle(couple_front_point.Y) & vbCrLf & fromSingle(couple_front_point.Z), True)

                If couple_front_sound Then .Add("[couple_front_open_for_sound]", True)

                .Add("[coupling_front_character]")
                .Add(fromSingle(couple_front_char.X) & vbCrLf & fromSingle(couple_front_char.Y) & vbCrLf & fromSingle(couple_front_char.Z))
                .Add(fromBool(couple_front_type), True)
            End If
        End With

        Dim linesCount As Integer
        linesCount = newFile.Write()

        Log.Add("Projekt gespeichert! (Datei: " & filename.name & ", Zeilen: " & linesCount & ")")
        If Not only_save_proj Then
            If Not model Is Nothing Then
                If model.filename = filename Then
                    model.save(True)
                Else
                    model.save()
                End If
            End If
            If Not paths Is Nothing Then paths.save()
            If Not cabin Is Nothing Then cabin.save()
            ProjDataBase.Save()
        End If
    End Sub

    Public Function usedFiles() As List(Of Filename)
        usedFiles = New List(Of Filename)
        With usedFiles
            .Add(filename)
            .Add(New Filename(number_path))

            .AddRange(model.usedFiles)
            .Add(sound_file)
            .Add(sound_ai_file)
            .Add(paths.filename)
            .Add(cabin.filename)

            For Each script In scripts
                .Add(New Filename(script, filename.path))
            Next

            For Each varlist In varlists
                .Add(New Filename(varlist, filename.path))
            Next

            For Each stringvarlist In stringvarlists
                .Add(New Filename(stringvarlist, filename.path))
            Next

            For Each constfile In constfiles
                .Add(New Filename(constfile, filename.path))
            Next

            For i = 0 To spiegel.Count - 1
                .Add(New Filename("reflexion" & i & ".bmp", filename.path))
            Next

            If Not couple_back_file Is Nothing Then
                Log.Add("Erforderliche Dateien des Nachläufers wurden nicht berücksichtigt!")
            End If
        End With

        Return usedFiles
    End Function
End Class
