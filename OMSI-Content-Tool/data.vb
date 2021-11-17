Module data
    Public x3 As New List(Of Single)
    Public y3 As New List(Of Single)
    Public z3 As New List(Of Single)
    Public x2 As New List(Of Single)
    Public y2 As New List(Of Single)
    Public xN As New List(Of Single)
    Public yN As New List(Of Single)
    Public zN As New List(Of Single)
    Public F1 As New List(Of Single)
    Public F2 As New List(Of Single)
    Public F3 As New List(Of Single)
    Public globalPos As List(Of Single)
    Public Matlist As New List(Of Integer)
    Public TextureNames As New List(Of String)
    Public ctMesh As Integer
    Public ctFaces As Integer
    Public ctTexture As Integer
    Public path As String

    Public Sub exportXFile(fileName As String)
        Dim zeile As String
        Dim ctSpace As Byte
        Dim ctMat As Byte
        Dim file As System.IO.StreamWriter
        file = My.Computer.FileSystem.OpenTextFileWriter(fileName, False, System.Text.Encoding.ASCII)


        file.WriteLine("xof 0303txt 0032" & vbCrLf & vbCrLf _
                        & "Frame Root {" & vbCrLf _
                        & "  FrameTransformMatrix {" & vbCrLf _
                        & "     1.000000, 0.000000, 0.000000, 0.000000," & vbCrLf _
                        & "     0.000000, 1.000000, 0.000000, 0.000000," & vbCrLf _
                        & "     0.000000, 0.000000, 1.000000, 0.000000," & vbCrLf _
                        & "     0.000000, 0.000000, 0.000000, 1.000000;;" & vbCrLf _
                        & "  }" & vbCrLf _
                        & "  Frame Cube {" & vbCrLf _
                        & "    FrameTransformMatrix {" & vbCrLf _
                        & "       1.000000, 0.000000, 0.000000, 0.000000," & vbCrLf _
                        & "       0.000000, 1.000000, 0.000000, 0.000000," & vbCrLf _
                        & "       0.000000, 0.000000, 1.000000, 0.000000," & vbCrLf _
                        & "       " & globalPos(0) & ", " & globalPos(2) & ", " & globalPos(1) & ", 1.000000;;" & vbCrLf _
                        & "    }")
        file.WriteLine("    Mesh { // Cube mesh")
        file.WriteLine("      " & ctMesh & ";")
        ctSpace = 6
        For i = 0 To ctMesh - 1
            zeile = ""
            For t = 1 To ctSpace
                zeile = " " & zeile
            Next t

            If x3(i) >= 0 Then
                zeile = zeile & " " & Replace(Format(x3(i), "0.000000"), ",", ".") & ";"
            Else
                zeile = zeile & Replace(Format(x3(i), "0.000000"), ",", ".") & ";"
            End If
            If y3(i) >= 0 Then
                zeile = zeile & " " & Replace(Format(y3(i), "0.000000"), ",", ".") & ";"
            Else
                zeile = zeile & Replace(Format(y3(i), "0.000000"), ",", ".") & ";"
            End If

            If z3(i) >= 0 Then
                zeile = zeile & " " & Replace(Format(z3(i), "0.000000"), ",", ".") & ";,"
            Else
                zeile = zeile & Replace(Format(z3(i), "0.000000"), ",", ".") & ";,"
            End If
            If i = ctMesh - 1 Then zeile = Replace(zeile, ",", ";")
            file.WriteLine(zeile)
        Next i

        file.WriteLine("      " & ctFaces & ";")
        For i = 0 To ctFaces - 1
            zeile = ""
            If i = ctMesh Then
                ctFaces = i
                Exit For
            End If

            For t = 1 To ctSpace
                zeile = " " & zeile
            Next t
            zeile = zeile & "3;" & F1(i) & "," & F2(i) & "," & F3(i) & ";,"
            If i = ctFaces - 1 Then
                zeile = Replace(zeile, ",", ";")
            End If
            file.WriteLine(zeile)
        Next i

        file.WriteLine("      MeshNormals { // Cube normals")
        ctSpace = ctSpace + 2
        file.WriteLine("        " & ctFaces & ";")
        For i = 0 To ctFaces - 1
            zeile = ""
            For t = 1 To ctSpace
                zeile = " " & zeile
            Next t
            If xN(F1(i)) >= 0 Then
                zeile = zeile & " " & Replace(Format(xN(F1(i)), "0.000000"), ",", ".") & ";"
            Else
                zeile = zeile & Replace(Format(xN(F1(i)), "0.000000"), ",", ".") & ";"
            End If
            If yN(F1(i)) >= 0 Then
                zeile = zeile & " " & Replace(Format(yN(F1(i)), "0.000000"), ",", ".") & ";"
            Else
                zeile = zeile & Replace(Format(yN(F1(i)), "0.000000"), ",", ".") & ";"
            End If
            If zN(F1(i)) >= 0 Then
                zeile = zeile & " " & Replace(Format(zN(F1(i)), "0.000000"), ",", ".") & ";,"
            Else
                zeile = zeile & Replace(Format(zN(F1(i)), "0.000000"), ",", ".") & ";,"
            End If
            If i = ctFaces - 1 Then zeile = Replace(zeile, ",", ";")
            file.WriteLine(zeile)
        Next

        file.WriteLine("        " & ctFaces & ";")
        For i = 0 To ctFaces - 1
            zeile = ""
            For t = 1 To ctSpace
                zeile = " " & zeile
            Next t
            zeile = zeile & "3;" & i & "," & i & "," & i & ";,"
            If i = ctFaces - 1 Then zeile = Mid(zeile, 1, Len(zeile) - 2) & Replace(zeile, ",", ";", Len(zeile) - 1)
            file.WriteLine(zeile)
        Next i

        file.WriteLine("      } // End of Cube normals")
        file.WriteLine("      MeshTextureCoords { // Cube UV coordinates")
        file.WriteLine("        " & ctMesh & ";")
        For i = 0 To ctMesh - 1
            zeile = ""
            For t = 1 To ctSpace
                zeile = " " & zeile
            Next t
            If x2(i) >= 0 Then
                zeile = zeile & " " & Replace(Format(x2(i), "0.000000"), ",", ".") & ";"
            Else
                zeile = zeile & Replace(Format(x2(i), "0.000000"), ",", ".") & ";"
            End If
            If y2(i) >= 0 Then
                zeile = zeile & " " & Replace(Format(y2(i), "0.000000"), ",", ".") & ";,"
            Else
                zeile = zeile & Replace(Format(y2(i), "0.000000"), ",", ".") & ";,"
            End If
            If i = ctMesh - 1 Then zeile = Replace(zeile, ",", ";")
            file.WriteLine(zeile)
        Next i

        file.WriteLine("      } // End of Cube UV coordinates")
        file.WriteLine("      MeshMaterialList { // Cube material list")

        ctMat = 0
        For i = 0 To ctFaces - 1
            If Matlist(i) > ctMat Then ctMat = Matlist(i)
        Next
        ctMat = ctMat + 1
        file.WriteLine("        " & ctMat & ";")

        file.WriteLine("        " & ctFaces & ";")
        For i = 0 To ctFaces - 1
            zeile = ""
            For t = 1 To ctSpace
                zeile = " " & zeile
            Next t
            zeile = zeile & Matlist(i) & ","
            If i = ctFaces - 1 Then zeile = Replace(zeile, ",", ";")
            file.WriteLine(zeile)
        Next i

        For i = 0 To ctTexture - 1
            file.WriteLine("        Material " & Split(TextureNames(i), ".")(0) & " {" & vbCrLf _
                         & "           0.640000; 0.640000; 0.640000; 1.000000;;" & vbCrLf _
                         & "           96.078431;" & vbCrLf _
                         & "           0.500000; 0.500000; 0.500000;;" & vbCrLf _
                         & "           0.000000; 0.000000; 0.000000;;" & vbCrLf _
                         & "          TextureFilename {""" & TextureNames(i) & """;}" & vbCrLf _
                         & "        }")
        Next i

        file.WriteLine("      } // End of Cube material list" & vbCrLf _
                     & "    } // End of Cube mesh" & vbCrLf _
                     & "  } // End of Cube" & vbCrLf _
                     & "} // End of Root")
        file.Close()
        Form1.SSLB1.Text = "Export erfogreich"
    End Sub


    Public Sub readO3DFile(fileName As String)
        path = ""
        Dim tempPath = Split(fileName, "\")
        For i As Integer = 0 To tempPath.Count - 2
            If i > 0 Then path = path & "\"
            path = path & tempPath(i)
        Next i
        Dim bytes = My.Computer.FileSystem.ReadAllBytes(fileName)

        Dim AByte As Byte
        Dim LByte As Byte
        Dim ctZeile As Integer
        Dim ctGlobal As Integer
        Dim tempstr As String
        Dim ctTemp As Integer
        Dim lenTemp As Integer = 0
        ctZeile = 1
        ctGlobal = 0
        ctMesh = 1
        ctFaces = 1
        LByte = 0
        tempstr = ""

        globalPos(0) = 0
        globalPos(1) = 0
        globalPos(2) = 0

        For Each AByte In bytes
            If ctGlobal = 0 And ctZeile = 5 Then
                ctMesh = AByte
            End If

            If ctGlobal < ctMesh + 1 And ctGlobal > 0 Then
                '3D und 2D Daten bereich
                If AByte < 16 Then
                    tempstr = tempstr & "0" & Hex(AByte)
                Else
                    tempstr = tempstr & Hex(AByte)
                End If

                If ctZeile = 4 Then x3.Add(ToSingle(tempstr))
                If ctZeile = 8 Then z3.Add(ToSingle(tempstr))
                If ctZeile = 12 Then y3.Add(ToSingle(tempstr))
                If ctZeile = 16 Then xN.Add(ToSingle(tempstr))
                If ctZeile = 20 Then zN.Add(ToSingle(tempstr))
                If ctZeile = 24 Then yN.Add(ToSingle(tempstr))
                If ctZeile = 28 Then x2.Add(ToSingle(tempstr))
                If ctZeile = 32 Then y2.Add(ToSingle(tempstr))

                If ctZeile = 4 Or ctZeile = 8 Or ctZeile = 12 Or ctZeile = 16 Or ctZeile = 20 Or ctZeile = 24 Or ctZeile = 28 Or ctZeile = 32 Then
                    'output.appendtext(Replace(Format(ToSingle(tempstr), "0.00000"), ",", ".") & "; ")
                    tempstr = ""
                End If
            Else
                'Face Bereich
                If ctGlobal >= ctMesh And ctGlobal < ctMesh + ctFaces + 2 Then
                    If ctGlobal = ctMesh + 1 Then
                        If ctFaces = 1 And ctZeile = 1 Then
                            ctFaces = AByte
                            ctZeile = ctZeile + 1
                            Continue For
                        Else
                            If ctZeile = 2 Then
                                ctZeile = 8
                            End If
                        End If
                    End If

                    If ctZeile = 1 Then F3.Add(AByte)
                    If ctZeile = 3 Then F2.Add(AByte)
                    If ctZeile = 7 Then Matlist.Add(AByte)
                    If ctZeile = 5 Then F1.Add(AByte)

                    If ctZeile >= 8 Then
                        ctZeile = 0
                        ctGlobal = ctGlobal + 1
                    End If
                Else
                    'Texture Bereich

                    If ctGlobal = ctMesh + ctFaces + 2 And ctZeile = 2 Then
                        ctTexture = AByte
                        ctZeile = ctZeile + 1
                    End If

                    If ctGlobal >= ctMesh + ctFaces + 2 Then

                        If ctZeile = 4 Then
                            ctZeile = 0
                            ctGlobal = ctGlobal + 1
                        End If
                    End If


                    If lenTemp > 0 Then
                        If ctTemp >= lenTemp Then
                            TextureNames.Add(tempstr)
                            tempstr = ""
                            ctZeile = 1
                            lenTemp = 0
                            ctTemp = 0
                        End If
                        ctZeile = ctZeile + 1
                        tempstr = tempstr & Chr(AByte)
                        ctTemp = ctTemp + 1
                    End If

                    'Anfang des Texturenamens finden
                    If LByte = 40 And AByte = 40 Then
                        tempstr = "4040"
                        ctZeile = 1
                    Else
                        If Len(tempstr) = 4 And LByte = 192 And AByte = 66 Then
                            tempstr = tempstr & LByte & AByte
                            ctZeile = ctZeile + 1
                        Else
                            If Len(tempstr) = 9 Then
                                If LByte = 66 Then
                                    lenTemp = AByte
                                    ctTemp = 0
                                    tempstr = ""
                                    ctZeile = 0
                                End If
                            End If
                        End If
                    End If


                    'Ende der Datei
                    If LByte = 121 And AByte = 0 Then
                        tempstr = "1210"
                    Else
                        If Len(tempstr) = 5 And AByte = 128 Then
                            tempstr = tempstr & AByte
                        Else
                            If Len(tempstr) = 8 And AByte = 63 Then
                                tempstr = ""
                                Exit For
                            End If

                        End If
                    End If
                End If
            End If


            If ctZeile = 32 And ctGlobal = ctMesh Then
                ctZeile = -1
                ctGlobal = ctGlobal + 1
            End If

            If ctZeile >= 32 Then
                ctZeile = 0
                ctGlobal = ctGlobal + 1
            End If

            If ctGlobal = 0 And ctZeile = 6 Then
                ctZeile = 0
                ctGlobal = ctGlobal + 1
            End If

            If ctZeile = 0 Then tempstr = ""
            LByte = AByte
            ctZeile = ctZeile + 1
        Next
        Form1.LBObjekte.Items.Add(Replace(Split(fileName, "\")(Split(fileName, "\").Count - 1), ".", " (") & ")")
        Form1.SSLB1.Text = "Import erfogreich"
        'n=byte.Parse(test, Globalization.NumberStyles.HexNumber)
    End Sub

    Private Function ToHex(ByVal SngValue As Single) As String
        Dim tmpBytes() As Byte
        Dim tmpHex As String = ""
        tmpBytes = BitConverter.GetBytes(SngValue)
        For b As Integer = tmpBytes.GetUpperBound(0) To 0 Step -1
            If Hex(tmpBytes(b)).Length = 1 Then tmpHex = "0" & tmpHex '0..F -> 00..0F 
            tmpHex = Hex(tmpBytes(b)) & tmpHex
        Next
        Return tmpHex
    End Function

    Private Function ToSingle(ByVal hexValue As String) As Single
        Try
            Dim iOutputIndex As Integer = 0
            Dim bArray(3) As Byte
            For iInputIndex As Integer = 0 To 6 Step 2 ' comparing with 0 is faster 
                bArray(iOutputIndex) = Byte.Parse(hexValue.Substring(iInputIndex, 2), Globalization.NumberStyles.HexNumber)
                iOutputIndex += 1
            Next
            Return BitConverter.ToSingle(bArray, 0)
        Catch ex As Exception
        End Try
        Return Single.NaN ' something invalid was provided 
    End Function
End Module
