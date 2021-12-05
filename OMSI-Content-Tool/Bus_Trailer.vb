Public Class Bus_Trailer
    Public isloaded As Boolean = False
    Public filename As String
    Public path As String
    Public changed As Boolean = False
    Public position As New Point3D(0, 0, 0)

    Public hersteller As String
    Public typ As String
    Public anstrich As String

    Public beschreibung As String
    Public number_path As String
    Public reg_auto_pre As String
    Public reg_auto_post As String
    Public reg_free As Boolean

    Public baujahr As Integer
    Public laufleistung As String

    Public sound_file As String
    Public sound_ai_file As String
    Public model As OMSI_Model
    Public path_file As String  'As pathFile
    Public cabin_file As String 'As cabinFile

    Public varlists As New List(Of String)
    Public stringvarlists As New List(Of String)
    Public scripts As New List(Of String)
    Public constfiles As New List(Of String)

    Public dirver_cam_list As New List(Of Kamera)
    Public pax_cam_list As New List(Of Kamera)
    Public cam_std As Byte
    Public cam_outeside As New Point3D(0, 0, 0)
    Public spiegel As New List(Of Reflex_Kamera)
    Public spiegel_2 As New List(Of Reflex_Kamera_2)

    'Ticketblock

    Public masse As Single
    Public trägheit As New Point3D(0, 0, 0)
    Public bbox As OMSI_BBox
    Public schwerpunkt As Single
    Public rollwiederstand As Integer
    Public drehpunkt As Single
    Public lenkradius As Single
    Public aiheight As Single

    Public achsen As New List(Of OMSI_Achse)

    'Noch einbinden!
    Public trailer As Bus_Trailer
    Public couple_back As Boolean
    Public couple_back_point As Point3D
    Public couple_back_file As String
    Public couple_back_dir As Boolean

    Public couple_front As Boolean
    Public couple_front_point As Point3D
    Public couple_front_sound As Boolean = False
    Public couple_front_char As Point3D
    Public couple_front_type As Boolean


    Public Sub LoadFile(filepath As String)
        Dim tmppath = Split(filepath, "\")
        Dim camReflexIndex As Byte = 0

        filename = tmppath(tmppath.Count - 1)
        path = filepath.Substring(0, filepath.Count - filename.Count - 1)
        reg_free = True
        If My.Computer.FileSystem.FileExists(path & "\" & filename) Then
            Log.Add("Projekt """ & filename & """ laden...")
            Dim allLines As String() = Split(My.Computer.FileSystem.ReadAllText(path & "\" & filename), vbCrLf)

            For linect = 0 To allLines.Count - 1
                Select Case allLines(linect)
                    Case "[friendlyname]"
                        hersteller = allLines(linect + 1)
                        typ = allLines(linect + 2)
                        anstrich = allLines(linect + 3)
                        linect += 3
                    Case "[description]"
                        For decct = linect + 1 To linect + 32
                            If allLines(decct) = "[end]" Then Exit For
                            beschreibung &= allLines(decct) & vbCrLf
                        Next
                    Case "[number]"
                        number_path = allLines(linect + 1)
                    Case "[registration_free]"
                        reg_free = False
                    Case "[registration_automatic]"
                        reg_auto_pre = allLines(linect + 1)
                        reg_auto_post = allLines(linect + 2)
                        linect += 2
                    Case "[kmcounter_init]"
                        baujahr = allLines(linect + 1)
                        laufleistung = allLines(linect + 2)
                        linect += 2
                    Case "[sound]"
                        sound_file = allLines(linect + 1)
                    Case "[sound_ai]"
                        sound_ai_file = allLines(linect + 1)
                    Case "[model]"
                        model = New OMSI_Model(allLines(linect + 1), path)
                    Case "[paths]"
                        path_file = allLines(linect + 1)
                    Case "[passengercabin]"
                        cabin_file = allLines(linect + 1)
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
                        dirver_cam_list(dirver_cam_list.Count - 1).schedule = True
                        linect += 1
                    Case "[view_ticketselling]"
                        dirver_cam_list(dirver_cam_list.Count - 1).selling = True
                        linect += 1
                    Case "[add_camera_driver]"
                        Dim newCam As New Kamera
                        With newCam
                            .type = 0
                            .position = New Point3D(toSingle(allLines(linect + 1)), toSingle(allLines(linect + 2)), toSingle(allLines(linect + 3)))
                            .dist = toSingle(allLines(linect + 4))
                            .sichtwinkel = toSingle(allLines(linect + 5))
                            .rotX = toSingle(allLines(linect + 6))
                            .rotY = toSingle(allLines(linect + 7))
                            .PositionCam()
                        End With
                        dirver_cam_list.Add(newCam)
                        linect += 7
                    Case "[add_camera_pax]"
                        Dim newCam As New Kamera
                        With newCam
                            .type = 1
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
                        Dim newCam As New Reflex_Kamera_2
                        With newCam
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
                        spiegel_2.Add(newCam)
                        linect += 8
                    Case "[add_camera_reflexion]"
                        Dim newCam As New Reflex_Kamera
                        With newCam
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
                    Case "[mass]"
                        masse = toSingle(allLines(linect + 1))
                    Case "[momentofintertia]"
                        trägheit = New Point3D(toSingle(allLines(linect + 1)), toSingle(allLines(linect + 2)), toSingle(allLines(linect + 3)))
                    Case "[boundingbox]"
                        bbox = New OMSI_BBox(toSingle(allLines(linect + 1)), toSingle(allLines(linect + 2)), toSingle(allLines(linect + 3)), toSingle(allLines(linect + 4)), toSingle(allLines(linect + 5)), toSingle(allLines(linect + 6)))
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
                            For i = linect + 1 To linect + 32
                                Select Case allLines(i)
                                    Case "achse_long"
                                        .achse_long = toSingle(allLines(i + 1))
                                    Case "achse_maxwidth"
                                        .achse_maxwidth = toSingle(allLines(i + 1))
                                    Case "achse_minwidth"
                                        .achse_minwidth = toSingle(allLines(i + 1))
                                    Case "achse_raddurchmesser"
                                        .achse_raddurchmesser = toSingle(allLines(i + 1))
                                    Case "achse_feder"
                                        .achse_feder = toSingle(allLines(i + 1))
                                    Case "achse_maxforce"
                                        .achse_maxforce = toSingle(allLines(i + 1))
                                    Case "achse_daempfer"
                                        .achse_daempfer = toSingle(allLines(i + 1))
                                    Case "achse_antrieb"
                                        .achse_antrieb = toSingle(allLines(i + 1))
                                        Exit For
                                    Case "[newachse]"
                                        linect = i - 1
                                        Exit For
                                End Select
                            Next
                            achsen.Add(newAchse)
                        End With
                    Case "[coupling_back]"
                        couple_back = True
                        couple_back_point = New Point3D(toSingle(allLines(linect + 1)), toSingle(allLines(linect + 2)), toSingle(allLines(linect + 3)))
                    Case "[couple_back]"
                        couple_back = True
                        couple_back_file = allLines(linect + 1)
                        trailer = New Bus_Trailer
                        trailer.position = couple_back_point
                        trailer.LoadFile(couple_back_file)

                        If allLines(linect + 2) = "true" Then
                            couple_back_dir = True
                        Else
                            couple_back_dir = False
                        End If
                    Case "[coupling_front]"
                        couple_front = True
                        position.X -= toSingle(allLines(linect + 1))
                        position.Y -= toSingle(allLines(linect + 2))
                        position.Z -= toSingle(allLines(linect + 3))

                        For Each mesh In model.meshes
                            mesh.position = position
                        Next
                    Case "[couple_front_open_for_sound]"
                        couple_front_sound = True
                    Case "[coupling_front_character]"
                        couple_front = True
                        couple_front_char = New Point3D(toSingle(allLines(linect + 1)), toSingle(allLines(linect + 2)), toSingle(allLines(linect + 3)))
                        couple_front_type = allLines(linect + 4)
                End Select
            Next
            Log.Add("Projekt """ & filename & """ fertig geladen.")
        Else
            Log.Add("Bus nicht gefunden! (" & filepath & ")")
        End If

        isloaded = True
    End Sub

    Function toSingle(text As String) As Single
        Return Replace(text, ".", ",")
    End Function
End Class
