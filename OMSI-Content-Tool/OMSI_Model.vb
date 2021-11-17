Imports System.Text

Public Class OMSI_Model
    Public filename As Filename
    Public changed As Boolean = False

    Public vfdBox As BoundingBox
    Public detailfaktor As Single

    Public TexChangeName As String
    Public TexChangeFolder As String
    Public TexChangeInd As Integer
    Public TexChangeTexs As New List(Of Texture_Change)
    Public ScriptTextures As New List(Of ScriptTexture)

    Public TextTexturen As New List(Of TextTexture)
    Public lichter As New List(Of OMSI_Licht)
    Public spots As New List(Of OMSI_Spot)
    Public intLichter As New List(Of OMSI_IntLicht)

    Public meshes As New List(Of OMSI_Mesh)
    Public rauch As New List(Of OMSI_Rauch)
    '##############################
    'Bein Hinzufügen neuer Eigeschaften Add-Sub mit ergänzen!
    '##############################

    Public Sub New()
        Log.Add("Neues Modell ohne Namen angelegt.")
    End Sub

    Public Sub New(filename As Filename)
        If My.Computer.FileSystem.FileExists(filename) Then
            Log.Add("Model-Datei """ & filename & """ laden...")
            Me.filename = filename
            Dim allLines As String() = Split(My.Computer.FileSystem.ReadAllText(filename, Encoding.GetEncoding(1252)), vbCrLf)

            Dim text_tex_index As Integer = 0
            Dim tempLODMin As Single = 0
            Dim tempLODMax As Single = 1

            For linect = 0 To allLines.Count - 1
                If Trim(allLines(linect)) <> "" Then
                    Select Case allLines(linect)
                        Case "[VFDmaxmin]"
                            vfdBox = New BoundingBox(toSingle(allLines(linect + 1)), toSingle(allLines(linect + 2)), toSingle(allLines(linect + 3)), toSingle(allLines(linect + 4)), toSingle(allLines(linect + 5)), toSingle(allLines(linect + 6)))
                            linect += 6
                        Case "[tex_detail_factor]"
                            detailfaktor = toSingle(allLines(linect + 1))
                        Case "[CTC]"
                            TexChangeName = allLines(linect + 1)
                            TexChangeFolder = allLines(linect + 2)
                            TexChangeInd = allLines(linect + 3)
                            linect += 3
                        Case "[CTCTexture]"
                            TexChangeTexs.Add(New Texture_Change(allLines(linect + 1), allLines(linect + 2)))
                            linect += 2
                        Case "[texttexture_enh]"
                            Dim t_enh As New TextTexture With {
                                .enh = True,
                                .index = text_tex_index,
                                .name = allLines(linect + 1),
                                .font = allLines(linect + 2),
                                .breite = allLines(linect + 3),
                                .höhe = allLines(linect + 4),
                                .r = toByte(allLines(linect + 6)),
                                .g = toByte(allLines(linect + 7)),
                                .b = toByte(allLines(linect + 8)),
                                .orientation = allLines(linect + 9)
                                }
                            If allLines(linect + 5) = 1 Then t_enh.FontColorBool = True
                            If allLines(linect + 10) = 1 Then t_enh.grid = True
                            TextTexturen.Add(t_enh)
                            text_tex_index += 1
                            linect += 10
                        Case "[texttexture]"
                            Dim t_tex As New TextTexture With {
                                .index = text_tex_index,
                                .name = allLines(linect + 1),
                                .font = allLines(linect + 2),
                                .breite = allLines(linect + 3),
                                .höhe = allLines(linect + 4),
                                .r = toByte(allLines(linect + 6)),
                                .g = toByte(allLines(linect + 7)),
                                .b = toByte(allLines(linect + 8))
                                }
                            If allLines(linect + 5) = 1 Then t_tex.FontColorBool = True
                            TextTexturen.Add(t_tex)
                            text_tex_index += 1
                            linect += 8
                        Case "[scripttexture]"
                            Dim newST As New ScriptTexture
                            newST.name = Trim(allLines(linect - 1))
                            newST.X = allLines(linect + 1)
                            newST.Y = allLines(linect + 2)
                            ScriptTextures.Add(newST)
                        Case "[LOD]"
                            If tempLODMin > 0 Then tempLODMax = tempLODMin
                            tempLODMin = toSingle(allLines(linect + 1))
                        Case "[spotlight]"
                            Dim spot As New OMSI_Spot
                            With spot
                                .position.X = toSingle(allLines(linect + 1))
                                .position.Y = toSingle(allLines(linect + 2))
                                .position.Z = toSingle(allLines(linect + 3))
                                .richtung.X = toSingle(allLines(linect + 4))
                                .richtung.Y = toSingle(allLines(linect + 5))
                                .richtung.Z = toSingle(allLines(linect + 6))
                                .color.R = toByte(allLines(linect + 7))
                                .color.G = toByte(allLines(linect + 8))
                                .color.B = toByte(allLines(linect + 9))
                                .range = toSingle(allLines(linect + 10))
                                .innerCone = allLines(linect + 11)
                                .outerCone = allLines(linect + 12)
                                If meshes.Count > 0 Then
                                    .parent = meshes(meshes.Count - 1).filename.name
                                End If
                            End With
                            spots.Add(spot)
                            linect += 12
                        Case "[light_enh_2]"
                            Dim licht As New OMSI_Licht
                            With licht
                                .name = Trim(allLines(linect - 1))
                                .position.X = toSingle(allLines(linect + 1))
                                .position.Y = toSingle(allLines(linect + 2))
                                .position.Z = toSingle(allLines(linect + 3))
                                .richtung.X = toSingle(allLines(linect + 4))
                                .richtung.Y = toSingle(allLines(linect + 5))
                                .richtung.Z = toSingle(allLines(linect + 6))
                                .upVector.X = toSingle(allLines(linect + 7))
                                .upVector.Y = toSingle(allLines(linect + 8))
                                .upVector.Z = toSingle(allLines(linect + 9))
                                .ausrichtung = allLines(linect + 10)
                                .rotating = allLines(linect + 11)
                                .color.R = toByte(allLines(linect + 12))
                                .color.G = toByte(allLines(linect + 13))
                                .color.B = toByte(allLines(linect + 14))
                                .size = toSingle(allLines(linect + 15))
                                .innerCone = allLines(linect + 16)
                                .outerCone = allLines(linect + 17)
                                .var = allLines(linect + 18)
                                .faktor = toSingle(allLines(linect + 19))
                                .offset = toSingle(allLines(linect + 20))
                                .effekt = allLines(linect + 21)
                                .cone = toSingle(allLines(linect + 22))
                                .timeconst = toSingle(allLines(linect + 23))
                                .bitmap = allLines(linect + 24)
                                If meshes.Count > 0 Then
                                    .parent = meshes(meshes.Count - 1).filename.name
                                End If
                            End With
                            lichter.Add(licht)
                            linect += 24
                        Case "[interiorlight]"
                            Dim intLicht As New OMSI_IntLicht
                            With intLicht
                                .name = Trim(allLines(linect - 1))
                                .var = allLines(linect + 1)
                                .reichweite = toSingle(allLines(linect + 2))
                                .color.R = toByte(allLines(linect + 3))
                                .color.G = toByte(allLines(linect + 4))
                                .color.B = toByte(allLines(linect + 5))
                                .position.X = toSingle(allLines(linect + 6))
                                .position.Y = toSingle(allLines(linect + 7))
                                .position.Z = toSingle(allLines(linect + 8))
                                .parent = meshes(meshes.Count - 1).filename.name
                            End With
                            intLichter.Add(intLicht)
                            linect += 8
                        Case "[smoke]"
                            Dim rauch_neu As New OMSI_Rauch
                            With rauch_neu
                                .name = Trim(allLines(linect - 1))
                                .position.X = toSingle(allLines(linect + 1))
                                .position.Y = toSingle(allLines(linect + 2))
                                .position.Z = toSingle(allLines(linect + 3))
                                .richtung.X = toSingle(allLines(linect + 4))
                                .richtung.Y = toSingle(allLines(linect + 5))
                                .richtung.Z = toSingle(allLines(linect + 6))

                                .speed = allLines(linect + 7)
                                .speedvar = allLines(linect + 8)
                                .frequenz = allLines(linect + 9)
                                .lebensdauer = allLines(linect + 10)
                                .bremsfaktor = allLines(linect + 11)
                                .fallkurve = allLines(linect + 12)
                                .größe = allLines(linect + 13)
                                .vergrößerung = allLines(linect + 14)
                                .alphaInit = allLines(linect + 15)
                                .alphavVar = allLines(linect + 16)
                                .color = New RGBColor(toSingle(allLines(linect + 17)), toSingle(allLines(linect + 18)), toSingle(allLines(linect + 19)))
                                .parent = meshes(meshes.Count - 1).filename.name
                            End With
                            rauch.Add(rauch_neu)
                            linect += 19
                        Case "[mesh]"
                            Dim mesh As New OMSI_Mesh
                            With mesh
                                .filename = New Filename(allLines(linect + 1), filename.path)
                                .center = New Point3D
                                .lodMin = tempLODMin
                                .lodMax = tempLODMax
                                For i As Integer = linect + 1 To allLines.Count - 1
                                    If i = allLines.Count Then Exit For
                                    Select Case allLines(i)
                                        Case "[viewpoint]"
                                            .viewpoint = allLines(i + 1)
                                        Case "[illumination_interior]"
                                            .illumination = New OMSI_Illumination
                                            .illumination.values.Add(allLines(i + 1))
                                            .illumination.values.Add(allLines(i + 2))
                                            .illumination.values.Add(allLines(i + 3))
                                            .illumination.values.Add(allLines(i + 4))
                                            i += 4
                                        Case "[mouseevent]"
                                            .mouseevent = allLines(i + 1)
                                        Case "[visible]"
                                            .visibleVar = allLines(i + 1)
                                            .visibleInt = allLines(i + 2)
                                            i += 2
                                        Case "[isshadow]"
                                            .isshadow = True
                                        Case "[matl_change]"
                                            .matl_change_file = allLines(i + 1)
                                            .matl_change_index = allLines(i + 2)
                                            .matl_change_var = allLines(i + 3)
                                            i += 3
                                        Case "[mesh_ident]"
                                            .meshident = allLines(i + 1)
                                        Case "[animparent]"
                                            .animparent = allLines(i + 1)
                                        Case "[smoothskin]"
                                            .smoothskin = True
                                        Case "[setbone]"
                                            .bones.Add(New OMSI_Bone(allLines(i + 1), allLines(i + 2)))
                                        Case "[newanim]"
                                            Dim newAnim As New OMSI_Anim
                                            For a As Integer = i + 1 To allLines.Count - 1
                                                If a = allLines.Count Then Exit For
                                                With newAnim
                                                    Select Case allLines(a)
                                                        Case "origin_from_mesh"
                                                            .origin_from_mesh = True
                                                        Case "origin_trans"
                                                            .origin_trans.X = toSingle(allLines(a + 1))
                                                            .origin_trans.Y = toSingle(allLines(a + 2))
                                                            .origin_trans.Z = toSingle(allLines(a + 3))
                                                            a += 3
                                                        Case "origin_rot_x"
                                                            .origin_rot_x = toSingle(allLines(a + 1))
                                                        Case "origin_rot_y"
                                                            .origin_rot_y = toSingle(allLines(a + 1))
                                                        Case "origin_rot_z"
                                                            .origin_rot_z = toSingle(allLines(a + 1))
                                                        Case "anim_trans"
                                                            .anim_type = OMSI_Anim.TYPE_TRANSFORM
                                                            .anim_var = allLines(a + 1)
                                                            .anim_val = toSingle(allLines(a + 2))
                                                        Case "anim_rot"
                                                            .anim_type = OMSI_Anim.TYPE_ROTATION
                                                            .anim_var = allLines(a + 1)
                                                            .anim_val = toSingle(allLines(a + 2))
                                                            a += 2
                                                        Case Else
                                                            If allLines(a).Contains("[") And allLines(a).Contains("]") Then
                                                                i = a - 1
                                                                Exit For
                                                            End If
                                                    End Select
                                                End With
                                            Next
                                            .animations.Add(newAnim)
                                        Case "[matl]"
                                            Dim matl As New OMSI_Matl
                                            With matl
                                                .name = allLines(i + 1)
                                                .index = allLines(i + 2)
                                                For n As Integer = i + 2 To allLines.Count - 1
                                                    If n = allLines.Count Then Exit For
                                                    Select Case allLines(n)
                                                        Case "[matl_freetex]"
                                                            .freetexFile = allLines(n + 1)
                                                            .freetexVar = allLines(n + 2)
                                                            n += 2
                                                        Case "[texcoordtransX]"
                                                            .transX = allLines(n + 1)
                                                        Case "[texcoordtransY]"
                                                            .transY = allLines(n + 1)
                                                        Case "[matl_alpha]"
                                                            .alpha = allLines(n + 1)
                                                        Case "[alphascale]"
                                                            .alphascale = allLines(n + 1)
                                                        Case "[matl_envmap]"
                                                            .env_map = allLines(n + 1)
                                                            .env_scalce = toSingle(allLines(n + 2))
                                                            n += 2
                                                        Case "[matl_envmap_mask]"
                                                            .envmask = allLines(n + 1)
                                                        Case "[matl_lightmap]"
                                                            .lightmap_name = allLines(n + 1)
                                                            .lightmap_var = allLines(n + 2)
                                                            n += 2
                                                        Case "[matl_bumpmap]"
                                                            .bumpmap_file = allLines(n + 1)
                                                            .bumpmap_val = toSingle(allLines(n + 2))
                                                            n += 2
                                                        Case "[matl_texadress_border]"
                                                            .adressBorder = New List(Of Byte)
                                                            .adressBorder.Add(toByte(allLines(n + 1)))
                                                            .adressBorder.Add(toByte(allLines(n + 2)))
                                                            .adressBorder.Add(toByte(allLines(n + 3)))
                                                            .adressBorder.Add(toByte(allLines(n + 4)))
                                                            n += 4
                                                        Case "[matl_transmap]"
                                                            .transmap = True
                                                            If allLines(n + 1) <> "" Then .transmapVar = allLines(n + 1)
                                                        Case "[matl_noZwrite]"
                                                            .zWrite = True
                                                        Case "[matl_noZcheck]"
                                                            .zCheck = True
                                                        Case "[useTextTexture]"
                                                            .texTex = True
                                                            .texTexVal = allLines(n + 1)
                                                        Case Else
                                                            If allLines(n).Contains("[") And allLines(n).Contains("]") Then
                                                                i = n - 1
                                                                Exit For
                                                            End If
                                                    End Select
                                                Next
                                            End With
                                            .materials.Add(matl)
                                        Case "[mesh]"
                                            linect = i - 1
                                            Exit For
                                        Case "[light_enh_2]"
                                            linect = i - 1
                                            Exit For
                                        Case "[interiorlight]"
                                            linect = i - 1
                                            Exit For
                                        Case "[smoke]"
                                            linect = i - 1
                                            Exit For
                                        Case "[spotlight]"
                                            linect = i - 1
                                            Exit For
                                        Case "[LOD]"
                                            linect = i - 1
                                            Exit For
                                    End Select
                                Next
                            End With
                            meshes.Add(mesh)
                    End Select
                End If
            Next
            Log.Add("Model-Datei """ & filename.name & """ fertig geladen.")
        Else
            Log.Add("Model-Datei """ & filename.name & """ wurde nicht gefunden!", 2)
        End If
    End Sub

    Public Sub save(Optional addToFile As Boolean = False)
        If filename = "" Then
            Log.Add("Kein Speicherort für Modell-Datei festgelegt!", Log.TYPE_ERROR)
            Exit Sub
        End If

        'If Not changed Then Exit Sub       #####################     MUSS WIEDER REIN!!!    ######################

        'Dim filename_n As New Filename(filename)
        'filename_n.nameNoEnding &= "_neu"

        Dim tmpLodMin As Single = 1

        Dim newFile As New FileWriter(filename)
        With newFile

            If Not vfdBox Is Nothing Then
                .teilüberschrift("Sichtbarkeits-Boundingbox")
                .Add("[VFDmaxmin]")
                .Add(fromSingle(vfdBox.size.X) & vbCrLf & fromSingle(vfdBox.size.Y) & vbCrLf & fromSingle(vfdBox.size.Z))
                .Add(fromSingle(vfdBox.pos.X) & vbCrLf & fromSingle(vfdBox.pos.Y) & vbCrLf & fromSingle(vfdBox.pos.Z), True)
            End If

            If detailfaktor > 0 Then
                .Add("[tex_detail_factor]")
                .Add(detailfaktor, True)
            End If

            If TexChangeName <> "" Then
                .teilüberschrift("Repaints")

                .Add("[CTC]")
                .Add(TexChangeName)
                .Add(TexChangeFolder)
                .Add(TexChangeInd, True)


                For Each ChangeTex In TexChangeTexs
                    .Add("[CTCTexture]")
                    .Add(ChangeTex.Var)
                    .Add(ChangeTex.file, True)
                Next
            End If

            If TextTexturen.Count > 0 Then
                .teilüberschrift("TextTexturen")
                For Each TextTexture In TextTexturen
                    .Add(TextTexture.index)
                    If TextTexture.enh Then
                        .Add("[texttexture_enh]")
                    Else
                        .Add("[texttexture]")
                    End If
                    .Add(TextTexture.name)
                    .Add(TextTexture.font)
                    .Add(TextTexture.breite)
                    .Add(TextTexture.höhe)
                    .Add(fromBool(TextTexture.FontColorBool))
                    .Add(TextTexture.r)
                    .Add(TextTexture.g)
                    .Add(TextTexture.b)
                    If TextTexture.enh Then
                        .Add(TextTexture.orientation)
                        .Add(fromBool(TextTexture.grid))
                    End If
                    .Add(vbCrLf)
                Next
            End If

            If ScriptTextures.Count > 0 Then
                .teilüberschrift("Script-Texturen")
                For Each ScriptTexture In ScriptTextures
                    .Add(ScriptTexture.name)
                    .Add("[scripttexture]")
                    .Add(ScriptTexture.X)
                    .Add(ScriptTexture.Y, True)
                Next
            End If

            If meshes.Count > 0 Then
                .teilüberschrift("Meshes")
                For Each mesh In meshes
                    If Not mesh.lodMin = tmpLodMin Then
                        .Add("---------------------------------")
                        .Add("[LOD]")
                        .Add(mesh.lodMin)
                        tmpLodMin = mesh.lodMin
                    End If

                    .AddRange(mesh.getpropertys)

                    For Each licht In lichter
                        If licht.parent = mesh.filename.name Then
                            If licht.name <> "" Then .Add(licht.name)
                            .Add("[light_enh_2]")
                            .Add(licht.position.X)
                            .Add(licht.position.Y)
                            .Add(licht.position.Z)
                            .Add(licht.richtung.X)
                            .Add(licht.richtung.Y)
                            .Add(licht.richtung.Z)
                            .Add(licht.upVector.X)
                            .Add(licht.upVector.Y)
                            .Add(licht.upVector.Z)
                            .Add(licht.ausrichtung)
                            .Add(licht.rotating)
                            .Add(licht.color.R & vbCrLf & licht.color.G & vbCrLf & licht.color.B)
                            .Add(licht.size)
                            .Add(licht.innerCone)
                            .Add(licht.outerCone)
                            If Not licht.var = "" Then
                                .Add(licht.var)
                            Else
                                .Add(1)
                                Log.Add("Licht ohne Variable beim Speichern auf 1 gesetzt!", Log.TYPE_WARNUNG)
                            End If

                            .Add(licht.faktor)
                            .Add(licht.offset)
                            .Add(licht.effekt)
                            .Add(licht.cone)
                            .Add(licht.timeconst)
                            If licht.bitmap <> "" Then .Add(licht.bitmap)
                            .Add(vbCrLf)
                        End If
                    Next

                    For Each intLicht In intLichter
                        If intLicht.parent = mesh.filename.name Then
                            If intLicht.name <> "" Then .Add(intLicht.name)
                            .Add("[interiorlight]")
                            .Add(intLicht.var)
                            .Add(intLicht.reichweite)
                            .Add(intLicht.color.R)
                            .Add(intLicht.color.G)
                            .Add(intLicht.color.B)
                            .Add(intLicht.position.X)
                            .Add(intLicht.position.Y)
                            .Add(intLicht.position.Z, True)
                        End If
                    Next

                    For Each smoke In rauch
                        If smoke.parent = mesh.filename.name Then
                            If smoke.name <> "" Then .Add(smoke.name)
                            .Add("[smoke]")
                            .Add(smoke.position.X)
                            .Add(smoke.position.Y)
                            .Add(smoke.position.Z)
                            .Add(smoke.richtung.X)
                            .Add(smoke.richtung.Y)
                            .Add(smoke.richtung.Z)
                            .Add(smoke.speed)
                            .Add(smoke.speedvar)
                            .Add(smoke.frequenz)
                            .Add(smoke.lebensdauer)
                            .Add(smoke.bremsfaktor)
                            .Add(smoke.fallkurve)
                            .Add(smoke.größe)
                            .Add(smoke.vergrößerung)
                            .Add(smoke.alphaInit)
                            .Add(smoke.alphavVar)
                            .Add(fromSingle(smoke.color.R / 255))
                            .Add(fromSingle(smoke.color.G / 255))
                            .Add(fromSingle(smoke.color.B / 255), True)
                        End If
                    Next

                    For Each spot In spots
                        If spot.parent = mesh.filename.name Then
                            If spot.name <> "" Then .Add(spot.name)
                            .Add("[spotlight]")
                            .Add(spot.position.X)
                            .Add(spot.position.Y)
                            .Add(spot.position.Z)
                            .Add(spot.richtung.X)
                            .Add(spot.richtung.Y)
                            .Add(spot.richtung.Z)
                            .Add(spot.color.R)
                            .Add(spot.color.G)
                            .Add(spot.color.B)
                            .Add(spot.range)
                            .Add(spot.innerCone)
                            .Add(spot.outerCone, True)
                        End If
                    Next
                Next
            End If

            For Each licht In lichter
                If licht.parent = "" Then
                    If licht.name <> "" Then .Add(licht.name)
                    .Add("[light_enh_2]")
                    .Add(licht.position.X)
                    .Add(licht.position.Y)
                    .Add(licht.position.Z)
                    .Add(licht.richtung.X)
                    .Add(licht.richtung.Y)
                    .Add(licht.richtung.Z)
                    .Add(licht.upVector.X)
                    .Add(licht.upVector.Y)
                    .Add(licht.upVector.Z)
                    .Add(licht.ausrichtung)
                    .Add(licht.rotating)
                    .Add(licht.color.R & vbCrLf & licht.color.G & vbCrLf & licht.color.B)
                    .Add(licht.size)
                    .Add(licht.innerCone)
                    .Add(licht.outerCone)
                    .Add(licht.var)
                    .Add(licht.faktor)
                    .Add(licht.offset)
                    .Add(licht.effekt)
                    .Add(licht.cone)
                    .Add(licht.timeconst)
                    If licht.bitmap <> "" Then .Add(licht.bitmap)
                    .Add(vbCrLf)
                End If
            Next

        End With

        newFile.Write(addToFile)

        Log.Add("Modell-Datei gespeichert! (Datei: " & filename.name & ")")

    End Sub

    Public Sub add(newModel As OMSI_Model)
        If Not newModel Is Nothing Then
            changed = True

            If Not newModel.vfdBox Is Nothing Then
                Dim x As MsgBoxResult = MsgBox("Boundinbox überschreiben?", vbYesNo)
                If x = MsgBoxResult.Yes Then
                    vfdBox = newModel.vfdBox
                End If
            End If

            If newModel.detailfaktor > 0 Then
                Dim x As MsgBoxResult = MsgBox("Detailfaktor überschreiben?", vbYesNo)
                If x = MsgBoxResult.Yes Then
                    detailfaktor = newModel.detailfaktor
                End If
            End If

            If newModel.TexChangeName <> "" Or newModel.TexChangeFolder <> "" Or newModel.TexChangeTexs.Count > 0 Then
                Dim x As MsgBoxResult = MsgBox("Texturtausch überschreiben?", vbYesNo)
                If x = MsgBoxResult.Yes Then

                    If newModel.TexChangeName <> "" Then
                        TexChangeName = newModel.TexChangeName
                    End If

                    If newModel.TexChangeFolder <> "" Then
                        TexChangeFolder = newModel.TexChangeFolder
                    End If

                    TexChangeInd = newModel.TexChangeInd

                    If newModel.TexChangeTexs.Count > 0 Then
                        TexChangeTexs = newModel.TexChangeTexs
                    End If

                End If
            End If

            If newModel.ScriptTextures.Count > 0 Then
                If ScriptTextures.Count > 0 Then
                    Dim x As MsgBoxResult = MsgBox("Scripttexturen komplett überschreiben?", vbYesNo)
                    If x = MsgBoxResult.Yes Then
                        ScriptTextures = newModel.ScriptTextures
                    Else
                        For Each newScriptTexture In newModel.ScriptTextures
                            ScriptTextures.Add(newScriptTexture)
                        Next
                    End If
                Else
                    ScriptTextures = newModel.ScriptTextures
                End If
            End If

            If newModel.TextTexturen.Count > 0 Then
                If TextTexturen.Count > 0 Then
                    Dim x As MsgBoxResult = MsgBox("Texttexturen komplett überschreiben?", vbYesNo)
                    If x = MsgBoxResult.Yes Then
                        TextTexturen = newModel.TextTexturen
                    Else
                        For Each newTextTexture In newModel.TextTexturen
                            TextTexturen.Add(newTextTexture)
                        Next
                    End If
                Else
                    TextTexturen = newModel.TextTexturen
                End If
            End If

            If newModel.lichter.Count > 0 Then
                If lichter.Count > 0 Then
                    Dim x As MsgBoxResult = MsgBox("Lichter komplett überschreiben?", vbYesNo)
                    If x = MsgBoxResult.Yes Then
                        lichter = newModel.lichter
                    Else
                        For Each newLicht In newModel.lichter
                            lichter.Add(newLicht)
                        Next
                    End If

                Else
                    lichter = newModel.lichter
                End If
            End If

            If newModel.spots.Count > 0 Then
                If lichter.Count > 0 Then
                    Dim x As MsgBoxResult = MsgBox("Spots komplett überschreiben?", vbYesNo)
                    If x = MsgBoxResult.Yes Then
                        spots = newModel.spots
                    Else
                        For Each newSpot In newModel.spots
                            spots.Add(newSpot)
                        Next
                    End If
                Else
                    spots = newModel.spots
                End If
            End If

            If newModel.intLichter.Count > 0 Then
                If intLichter.Count > 0 Then
                    Dim x As MsgBoxResult = MsgBox("Interiorlichter komplett überschreiben?", vbYesNo)
                    If x = MsgBoxResult.Yes Then
                        intLichter = newModel.intLichter
                    Else
                        For Each newIntLicht In newModel.intLichter
                            intLichter.Add(newIntLicht)
                        Next
                    End If
                Else
                    intLichter = newModel.intLichter
                End If
            End If

            If newModel.meshes.Count > 0 Then
                If meshes.Count > 0 Then
                    Dim x As MsgBoxResult = MsgBox("Meshes komplett überschreiben?", vbYesNo)
                    If x = MsgBoxResult.Yes Then
                        meshes = newModel.meshes
                    Else
                        For Each newMesh In newModel.meshes
                            meshes.Add(newMesh)
                        Next
                    End If
                Else
                    meshes = newModel.meshes
                End If
            End If

            If newModel.rauch.Count > 0 Then
                If rauch.Count > 0 Then
                    Dim x As MsgBoxResult = MsgBox("Rauch komplett überschreiben?", vbYesNo)
                    If x = MsgBoxResult.Yes Then
                        rauch = newModel.rauch
                    Else
                        For Each newRauch In newModel.rauch
                            rauch.Add(newRauch)
                        Next
                    End If
                Else
                    rauch = newModel.rauch
                End If
            End If
        End If
    End Sub

End Class
