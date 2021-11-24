'by Felix Modellbusse ;) (MoBu) 2019
Module Exporter
    Public Sub write(Objekt As Local3DObjekt, filename As Filename)
        Select Case filename.extension
            Case "o3d"
                writeO3D(Objekt, filename)
            Case "x"
                writeX(Objekt, filename)
            Case "x3d"
                writeX3D(Objekt, filename)
        End Select
    End Sub

    Private Sub writeX3D(Objekt As Local3DObjekt, filename As Filename)
        MsgBox("X3D-Datei Gespeichert ;) #nicht   (" & filename & ")")
    End Sub

    Private Function intToHex(val As Integer) As List(Of Byte)
        intToHex = New List(Of Byte)
        Dim x As Integer = Convert.ToInt16(val / 256)
        If x > val / 256 Then
            x -= 1
        End If
        intToHex.Add(val - x * 256)
        intToHex.Add(x)

        If x > 255 Then Return Nothing
    End Function

    Private Sub writeO3D(Objekt As Local3DObjekt, filename As Filename)
        Dim bytes As New List(Of Byte)
        With bytes
            .AddRange({&H84, &H19, &H1, &H17})

            'Anzahl der Vertices
            .AddRange(intToHex(Objekt.vertices.Count / 3))

            '3D-Koordinaten
            For counter = 0 To Objekt.vertices.Count - 1 Step 3
                .AddRange(ToHex(-Objekt.vertices(counter)))
                .AddRange(ToHex(Objekt.vertices(counter + 1)))
                .AddRange(ToHex(Objekt.vertices(counter + 2)))
                For i = 0 To 2
                    .AddRange(ToHex(Objekt.normals(counter + i)))
                Next
                .AddRange(ToHex(Objekt.texCoords(counter / 3 * 2)))
                .AddRange(ToHex(Objekt.texCoords((counter / 3 * 2) + 1)))
            Next

            'Muss da rein, warum auch immer
            .Add(&H49)

            'Anzahl der Flächen
            Dim counterSubobjekte As Integer = 0
            For Each subobjekt In Objekt.subObjekte
                counterSubobjekte += subobjekt.Count
            Next
            .AddRange(intToHex(counterSubobjekte / 3))

            counterSubobjekte = 0
            For Each subobjekt In Objekt.subObjekte
                '.AddRange(intToHex(subobjekt.Count / 3))

                For counter = 0 To subobjekt.Count - 1 Step 3
                    For i = 0 To 2
                        .AddRange(intToHex(subobjekt(counter + i)))
                    Next
                    .AddRange(intToHex(counterSubobjekte))
                Next

                counterSubobjekte += 1
            Next

            'Muss da rein, warum auch immer
            .Add(&H26)

            .AddRange(intToHex(Objekt.texturen.Count))

            For Each texture In Objekt.texturen
                .AddRange(ToHex(texture.diffuse.R / 255))
                .AddRange(ToHex(texture.diffuse.G / 255))
                .AddRange(ToHex(texture.diffuse.B / 255))
                .AddRange(ToHex(texture.diffuseAlpha))
                If Not My.Settings.o3dRemoveSpec Then
                    .AddRange(ToHex(texture.specular.R / 255))
                    .AddRange(ToHex(texture.specular.G / 255))
                    .AddRange(ToHex(texture.specular.B / 255))
                Else
                    .AddRange(ToHex(0))
                    .AddRange(ToHex(0))
                    .AddRange(ToHex(0))
                End If
                .AddRange(ToHex(texture.emissive.R / 255))
                .AddRange(ToHex(texture.emissive.G / 255))
                .AddRange(ToHex(texture.emissive.B / 255))
                .AddRange(ToHex(texture.power))

                .Add(texture.filename.name.Length)
                For Each character In texture.filename.name
                    .Add(Convert.ToByte(CChar(character)))
                Next
            Next

            'Muss da rein, warum auch immer
            .Add(&H79)

            .AddRange(ToHex(Objekt.A1.X))
            .AddRange(ToHex(Objekt.A1.Y))
            .AddRange(ToHex(Objekt.A1.Z))
            .AddRange(ToHex(Objekt.A2))

            .AddRange(ToHex(Objekt.B1.X))
            .AddRange(ToHex(Objekt.B1.Y))
            .AddRange(ToHex(Objekt.B1.Z))
            .AddRange(ToHex(Objekt.B2))

            .AddRange(ToHex(Objekt.C1.X))
            .AddRange(ToHex(Objekt.C1.Y))
            .AddRange(ToHex(Objekt.C1.Z))
            .AddRange(ToHex(Objekt.C2))

            .AddRange(ToHex(Objekt.center.X))
            .AddRange(ToHex(Objekt.center.Z))
            .AddRange(ToHex(Objekt.center.Y))
            .AddRange(ToHex(Objekt.scale))


            My.Computer.FileSystem.WriteAllBytes(filename, .ToArray, False)
        End With

        Log.Add("Export erfolgreich! (Datei:" & filename & ", Format: O3D)")
        Frm_Main.SSLBStatus.Text = "Export erfogreich"
    End Sub

    Private Sub writeX(Objekt As Local3DObjekt, filename As Filename)

        Dim fw As New FileWriter(filename, True)
        With fw
            .Add("xof 0303txt 0032", True)
            .Add("Frame Root {")
            .Add("  FrameTransformMatrix {")
            .Add("     1.000000, 0.000000, 0.000000, 0.000000,")
            .Add("     0.000000, 1.000000, 0.000000, 0.000000,")
            .Add("     0.000000, 0.000000, 1.000000, 0.000000,")
            .Add("     " & fromSingle(Objekt.position.X, 6) & ", " & fromSingle(Objekt.position.Y, 6) & ", " & fromSingle(Objekt.position.Z, 6) & ", 1.000000;;")
            .Add("  }")

            .Add("  Frame " & filename.nameNoEnding & " {")
            .Add("    FrameTransformMatrix {")
            .Add("       " & fromSingle(Objekt.A1.X, 6) & ", " & fromSingle(Objekt.A1.Y, 6) & ", " & fromSingle(Objekt.A1.Z, 6) & ", " & fromSingle(Objekt.A2, 6) & ",")
            .Add("       " & fromSingle(Objekt.B1.X, 6) & ", " & fromSingle(Objekt.B1.Y, 6) & ", " & fromSingle(Objekt.B1.Z, 6) & ", " & fromSingle(Objekt.B2, 6) & ",")
            .Add("       " & fromSingle(Objekt.C1.X, 6) & ", " & fromSingle(Objekt.C1.Y, 6) & ", " & fromSingle(Objekt.C1.Z, 6) & ", " & fromSingle(Objekt.C2, 6) & ",")
            .Add("       " & fromSingle(Objekt.center.X, 6) & ", " & fromSingle(Objekt.center.Y, 6) & ", " & fromSingle(Objekt.center.Z, 6) & ", " & fromSingle(Objekt.scale, 6) & ";;")
            .Add("    }")


            .Add("    Mesh {")
            .Add("      " & Objekt.vertices.Count / 3 & ";")
            Dim zeilenEnde As String = ";,"
            For ctVerts As Integer = 0 To Objekt.vertices.Count - 1 Step 3
                If ctVerts = Objekt.vertices.Count - 3 Then zeilenEnde = ";;"
                .Add("       " & fromSingle(-Objekt.vertices(ctVerts) - Objekt.center.X, 6) & ";" & fromSingle(Objekt.vertices(ctVerts + 2) - Objekt.center.Y, 6) & ";" & fromSingle(Objekt.vertices(ctVerts + 1) - Objekt.center.Z, 6) & zeilenEnde)
            Next


            zeilenEnde = ";,"
            Dim faceCount As Integer = 0
            Dim tmpLines As New List(Of String)
            For Each subobjekt In Objekt.subObjekte
                faceCount += subobjekt.Count
                For ctFace As Integer = 0 To subobjekt.Count - 1 Step 3
                    tmpLines.Add("      3;" & subobjekt(ctFace) & "," & subobjekt(ctFace + 2) & "," & subobjekt(ctFace + 1) & zeilenEnde)
                Next
            Next

            'Nachbearbeitung
            tmpLines(tmpLines.Count - 1) = Replace(tmpLines(tmpLines.Count - 1), ";,", ";;")
            faceCount = faceCount / 3

            .Add("      " & faceCount & ";")
            .AddRange(tmpLines)     'Flächen


            zeilenEnde = ";,"
            .Add("      MeshNormals {")
            .Add("        " & Objekt.normals.Count / 3 & ";")
            For ctNorm As Integer = 0 To Objekt.normals.Count - 1 Step 3
                If ctNorm >= Objekt.normals.Count - 3 Then zeilenEnde = ";;"
                .Add("         " & fromSingle(Objekt.normals(ctNorm), 6) & ";" & fromSingle(Objekt.normals(ctNorm + 2), 6) & ";" & fromSingle(Objekt.normals(ctNorm + 1), 6) & zeilenEnde)
            Next

            .Add("      " & faceCount & ";")
            .AddRange(tmpLines)     'Flächen nochmal für die Normals
            .Add("      }")


            zeilenEnde = ";,"
            .Add("      MeshTextureCoords {")
            .Add("        " & Objekt.texCoords.Count / 2 & ";")
            For ctCoord As Integer = 0 To Objekt.texCoords.Count - 1 Step 2
                If ctCoord >= Objekt.texCoords.Count - 2 Then zeilenEnde = ";;"
                .Add("         " & fromSingle(Objekt.texCoords(ctCoord), 6) & ";" & fromSingle(Objekt.texCoords(ctCoord + 1), 6) & zeilenEnde)
            Next
            .Add("      }")

            .Add("      MeshMaterialList {")
            .Add("        " & Objekt.texturen.Count & ";")
            .Add("        " & faceCount & ";")

            zeilenEnde = ","
            Dim counter As Integer = 0
            For Each subobjekt In Objekt.subObjekte
                For Each x In Objekt.texturen
                    If x.id - 1 = counter Then
                        For i As Integer = 0 To subobjekt.Count - 1 Step 3
                            If counter = Objekt.subObjekte.Count - 1 And i >= subobjekt.Count - 3 Then zeilenEnde = ";"
                            .Add("        " & counter & zeilenEnde)
                        Next
                    End If
                Next
                counter += 1
            Next

            For Each Texture In Objekt.texturen
                If Texture.matName <> "" Then
                    .Add("        Material " & Texture.matName & " {")
                Else
                    .Add("        Material " & Texture.filename.name & " {")
                End If
                .Add("           " & fromSingle(Texture.diffuse.R / 255, 6) & "; " & fromSingle(Texture.diffuse.G / 255, 6) & "; " & fromSingle(Texture.diffuse.B / 255, 6) & "; " & fromSingle(Texture.diffuseAlpha, 6) & ";;")
                .Add("           " & fromSingle(Texture.power, 6) & ";")
                .Add("           " & fromSingle(Texture.specular.R / 255, 6) & "; " & fromSingle(Texture.specular.G / 255, 6) & "; " & fromSingle(Texture.specular.B / 255, 6) & ";;")
                .Add("           " & fromSingle(Texture.emissive.R / 255, 6) & "; " & fromSingle(Texture.emissive.G / 255, 6) & "; " & fromSingle(Texture.emissive.B / 255, 6) & ";;")
                .Add("          TextureFilename {""" & Texture.filename.name & """;}")
                .Add("        }")
            Next

            .Add("      }")
            .Add("    }")
            .Add("  }")
            .Add("}", True)

            .Write()
        End With

        Log.Add("Export erfolgreich! (Datei:" & filename & ", Format: X303)")
        Frm_Main.SSLBStatus.Text = "Export erfogreich"
    End Sub

    Private Function ToHex(ByVal SngValue As Single) As List(Of Byte)
        Dim tmpBytes() As Byte
        Dim tmpHex As New List(Of Byte)
        tmpBytes = BitConverter.GetBytes(SngValue)
        For b As Integer = 0 To tmpBytes.GetUpperBound(0)
            tmpHex.Add(tmpBytes(b))
        Next
        Return tmpHex
    End Function
End Module
