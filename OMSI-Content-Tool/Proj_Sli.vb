'by Felix Modellbusse ;) (MoBu) 2019
Public Class Proj_Sli
    Public Const TYPE = Frm_Main.PROJ_TYPE_SLI
    Public Const EXTENSION As String = "sli"

    Public isloaded As Boolean
    Public filename As Filename
    Public changed As Boolean = True '#####  Wieder raus nehmen!  ######

    Public position As New Point3D

    Public objIDs As New List(Of Integer)
    Public subobjekte As New List(Of Integer())
    Public vertices As Double()
    Public lines As Integer()
    Public texCoords As Double()

    Public length As Double = 10
    Public halfcantwidth As Double
    Public onlyeditor As Boolean

    Public heightProfile As New List(Of ProfilePnt)
    Public textures As New List(Of LocalTexture)
    Public patchwork_chains As New List(Of Sli_PatchworkChain)

    Public profiles As New List(Of Sli_Profile)
    Public paths As New List(Of KI_Path)

    Public ProjDataBase As DataBase

    Public Sub New()
        'Hier das rein was zum erstellen eines Busses vorhanden sein muss!
    End Sub


    Public Sub New(filepath As String)
        filename = New Filename(filepath)
        If My.Computer.FileSystem.FileExists(filename.path & "\" & filename.name) Then
            Dim allLines = Split(My.Computer.FileSystem.ReadAllText(filename), vbCrLf)

            If Not allLines.Contains("[profilepnt]") Then
                Log.Add("Spline hat keine Profilpunkte!", Log.TYPE_WARNUNG)
                Exit Sub
            End If

            Dim texturesTemp As New List(Of LocalTexture)

            For linect = 0 To allLines.Count - 1
                Select Case allLines(linect)
                    Case "[length]"
                        length = allLines(linect + 1)
                    Case "[halfcantwidth]"
                        halfcantwidth = allLines(linect + 1)
                    Case "[onlyeditor]"
                        onlyeditor = True
                    Case "[heightprofile]"
                        Dim newProfilePnt As New ProfilePnt
                        With newProfilePnt
                            .X = Replace(allLines(linect + 1), ".", ",")
                            .Y = Replace(allLines(linect + 2), ".", ",")
                            .U = Replace(allLines(linect + 3), ".", ",")
                            .V = Replace(allLines(linect + 4), ".", ",")
                            linect += 4
                        End With
                        heightProfile.Add(newProfilePnt)
                    Case "[texture]"
                        Dim newTex As New LocalTexture
                        With newTex
                            .filename = New Filename(allLines(linect + 1), filename.path & "\Texture")
                            .matName = Split(allLines(linect + 1), ".")(0)
                            For i As Integer = linect + 1 To allLines.Count - 1
                                If allLines(i).Length > 0 Then
                                    If allLines(i).Substring(0, 1) = "[" Then
                                        Select Case allLines(i)
                                            Case "[matl_alpha]"
                                                .sli_alpha = toByte(allLines(i))
                                            Case "[patchwork_chain]"
                                                Dim newChain As New Sli_PatchworkChain
                                                With newChain
                                                    .index = texturesTemp.Count + 1
                                                    .length = toSingle(allLines(i + 1))
                                                    .parts = allLines(i + 2).ToList
                                                    For n As Integer = 0 To allLines(i + 3).Length - 1
                                                        .frequenz.Add(toByte(allLines(i + 3).Substring(n, 1)))
                                                    Next
                                                    For n As Integer = 0 To allLines(i + 4).Length - 1
                                                        If allLines(i + 4).Substring(n, 1) = "1" Then
                                                            .spiegelbar.Add(True)
                                                        Else
                                                            .spiegelbar.Add(False)
                                                        End If
                                                    Next
                                                End With
                                                patchwork_chains.Add(newChain)
                                            Case Else
                                                linect = i - 1
                                                Exit For
                                        End Select
                                    End If
                                End If
                            Next
                        End With
                        texturesTemp.Add(newTex)
                    Case "[profile]"
                        Dim newProfile As New Sli_Profile
                        newProfile.texIndex = allLines(linect + 1)
                        For n = linect To allLines.Count - 1
                            If allLines(n) = "[profilepnt]" Then

                                Dim newPnt As New ProfilePnt
                                With newPnt
                                    .X = Replace(allLines(n + 1), ".", ",")
                                    .Y = Replace(allLines(n + 2), ".", ",")
                                    .U = Replace(allLines(n + 3), ".", ",")
                                    .V = Replace(allLines(n + 4), ".", ",")
                                End With
                                newProfile.profilePnts.Add(newPnt)
                            End If

                            If n = allLines.Count - 1 Then
                                linect = n - 1
                                Exit For
                            End If
                            If allLines(n + 1) = "[profile]" Or allLines(n + 1) = "[path]" Then
                                linect = n - 1
                                Exit For
                            End If
                        Next
                        profiles.Add(newProfile)
                    Case "[path]"
                        Dim newPath As New KI_Path
                        With newPath
                            .type = allLines(linect + 1)
                            .position = New Point3D(toSingle(allLines(linect + 2)), 0, toSingle(allLines(linect + 3)))
                            .width = toSingle(allLines(linect + 4))
                            .direction = allLines(linect + 5)
                            .length = length
                        End With
                        linect += 5
                        paths.Add(newPath)
                End Select

                If linect > allLines.Count - 1 Then Exit For
            Next


            If length = 0 Then length = 10

            Dim verticesTemp As New List(Of Double)
            Dim linesTemp As New List(Of Integer)
            Dim texCoordsTemp As New List(Of Double)

            Dim ct As Integer = 0

            For Each profile In profiles
                Dim edgesTemp As New List(Of Integer)
                Dim ct2 As Integer = 0

                For Each profilePoint In profile.profilePnts
                    verticesTemp.Add(-profilePoint.X)
                    verticesTemp.Add(profilePoint.Y)
                    verticesTemp.Add(0)

                    texCoordsTemp.Add(profilePoint.U)
                    texCoordsTemp.Add(0)

                    verticesTemp.Add(-profilePoint.X)
                    verticesTemp.Add(profilePoint.Y)
                    verticesTemp.Add(-length)

                    texCoordsTemp.Add(profilePoint.U)
                    texCoordsTemp.Add(1 / profilePoint.V)

                    If ct2 > 1 Then
                        edgesTemp.Add(ct - 1)
                        edgesTemp.Add(ct - 2)
                    End If

                    If ct2 = 0 Then
                        edgesTemp.Add(ct + 1)
                        edgesTemp.Add(ct)

                        linesTemp.Add(ct)
                        linesTemp.Add(ct + 1)
                    Else
                        edgesTemp.Add(ct)
                        edgesTemp.Add(ct - 1)
                        edgesTemp.Add(ct)
                        edgesTemp.Add(ct + 1)


                        linesTemp.Add(ct)
                        linesTemp.Add(ct + 1)
                        linesTemp.Add(ct)
                        linesTemp.Add(ct - 2)
                        linesTemp.Add(ct - 1)
                        linesTemp.Add(ct + 1)
                        linesTemp.Add(ct)
                        linesTemp.Add(ct - 1)
                    End If
                    ct2 += 1
                    ct += 2
                Next
                textures.Add(texturesTemp(profile.texIndex))
                subobjekte.Add(edgesTemp.toarray)
            Next

            vertices = verticesTemp.ToArray

            lines = linesTemp.ToArray
            texCoords = texCoordsTemp.ToArray
            Log.Add("Projekt """ & filename.name & """ fertig geladen.")
            ProjDataBase = New DataBase(filename)
            isloaded = True
        Else
            Log.Add("Spline nicht gefunden! (" & filename & ")")
        End If
    End Sub

    Public Sub Save()
        If filename = "" Then
            Log.Add("Kein Speicherort für Bus-Datei festgelegt!", Log.TYPE_ERROR)
            Exit Sub
        End If

        'If Not changed Then Exit Sub       #####################     MUSS WIEDER REIN!!!    ######################

        Dim filename_n As New Filename(filename)
        filename_n.nameNoEnding &= "_neu"

        Dim newFile As New FileWriter(filename_n)
        With newFile
            If onlyeditor Then .Add("[onlyeditor]", True)

            If halfcantwidth > 0 Then
                .Add("[halfcantwidth]")
                .Add(halfcantwidth, True)
            End If

            If length > 0 Then
                .Add("[length]")
                .Add(length, True)
            End If

            If heightProfile.Count > 0 Then
                .teilüberschrift("Height Profiles")

                For Each profile In heightProfile
                    .Add("[heightprofile]")
                    .Add(profile.X)
                    .Add(profile.Y)
                    .Add(profile.U)
                    .Add(profile.V, True)
                Next
            End If

            If textures.Count > 0 Then
                .teilüberschrift("Textures")

                For i As Integer = 0 To textures.Count - 1
                    .Add("[texture]")
                    .Add(textures(i).filename.name, True)

                    If textures(i).sli_alpha > 0 Then
                        .Add("[matl_alpha]")
                        .Add(textures(i).sli_alpha, True)
                    End If

                    For Each chain In patchwork_chains
                        If chain.index = i Then
                            .Add("[patchwork_chain]")
                            .Add(chain.length)
                            .Add(New String(chain.parts.ToArray))

                            Dim frequenz As String = ""
                            For Each item In chain.frequenz
                                frequenz &= Convert.ToString(item)
                            Next
                            .Add(frequenz)

                            Dim spigelungen As String = ""
                            For Each item In chain.spiegelbar
                                If item Then
                                    spigelungen &= "1"
                                Else
                                    spigelungen &= "0"
                                End If
                            Next
                            .Add(spigelungen, True)
                        End If
                    Next
                Next
            End If

            If profiles.Count > 0 Then
                .teilüberschrift("Graphical Lanes")

                Dim actIndex As Integer = -1
                For Each profile In profiles
                    .Add("[profile]")
                    .Add(profile.texIndex, True)

                    For Each proPoint In profile.profilePnts
                        .Add("[profilepnt]")
                        .Add(proPoint.X)
                        .Add(proPoint.Y)
                        .Add(proPoint.U)
                        .Add(proPoint.V, True)
                    Next
                Next
            End If

            If paths.Count > 0 Then
                .teilüberschrift("Paths")

                For Each path In paths
                    .Add("[path]")
                    .Add(path.type)
                    .Add(path.position.X)
                    .Add(path.position.Z)
                    .Add(path.width)
                    .Add(path.direction, True)
                Next
            End If

        End With

        Dim linesCount As Integer
        linesCount = newFile.Write()

        Log.Add("Projekt gespeichert! (Datei: " & filename_n.name & ", Zeilen: " & linesCount & ")")
        ProjDataBase.Save()
    End Sub
End Class
