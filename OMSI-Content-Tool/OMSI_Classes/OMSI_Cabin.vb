'by Felix Modellbusse ;) (MoBu) 2019
Public Class OMSI_Cabin
    Public isloaded As Boolean
    Public filename As Filename
    Public changed As Boolean = True '#####  Wieder raus nehmen!  ######

    Public doors As New List(Of OMSI_Door)

    Public linkToPrevVeh As Int16 = -1      'Kommt in Main
    Public linkToNextVeh As Int16 = -1      'Kommt in Trail

    Public stamperInd As Byte
    Public stamperPnt As Point3D

    Public ticketSaleInd As Integer
    Public ticketSalePnt As New Point3D

    Public ticketSaleMoneyPnt As OMSI_TicketPnt
    Public ticketSaleChangePnt As OMSI_TicketPnt

    Public driverPos As OMSI_Seat
    Public passPos As New List(Of OMSI_Seat)

    Public Sub New()
        Dim newName As String = "cabin_" & Frm_Main.actProj.Filename.nameNoEnding & ".cfg"
        Do
            newName = InputBox("Es muss zunächst eine Datei für Sitz-/ Stehplätze angelegt werden. Wie soll die Datei heißen?", "Neue Datei anlegen...", newName)
        Loop Until newName <> ""
        filename = New Filename(newName, Frm_Main.actProj.filename.path & "\Model")
        Log.Add("Cabin-Datei hinzugefügt (Datei: " & newName & ")")
    End Sub

    Public Sub New(filename As Filename)
        Me.filename = filename

        If System.IO.File.Exists(filename) Then
            Log.Add("Cabin-Datei """ & filename.name & """ laden...")
            Dim allLines As String() = System.IO.File.ReadAllLines(filename)

            For linect = 0 To allLines.Count - 1
                Select Case allLines(linect)
                    Case "[entry]"
                        doors.Add(New OMSI_Door(allLines(linect + 1), OMSI_Door.IS_ENTRY))
                        For i = linect + 2 To allLines.Count - 1
                            If InStr(allLines(i), "[") Then
                                linect = i - 1
                                Exit For
                            End If
                            Select Case allLines(i)
                                Case "{withbutton}"
                                    doors(doors.Count - 1).withButton = True
                                Case "{noticketsale}"
                                    doors(doors.Count - 1).noticketsale = True
                            End Select
                        Next

                    Case "[exit]"
                        doors.Add(New OMSI_Door(allLines(linect + 1), OMSI_Door.IS_EXIT))
                        For i = linect + 2 To allLines.Count - 1
                            If InStr(allLines(i), "[") Then
                                linect = i - 1
                                Exit For
                            End If
                            If allLines(i) = "{withbutton}" Then
                                doors(doors.Count - 1).withButton = True
                            End If
                        Next

                    Case "[linkToPrevVeh]"
                        linkToPrevVeh = allLines(linect + 1)

                    Case "[linkToNextVeh]"
                        linkToNextVeh = allLines(linect + 1)

                    Case "[stamper]"
                        stamperInd = allLines(linect + 1)
                        stamperPnt = New Point3D(-Replace(allLines(linect + 2), ".", ","), Replace(allLines(linect + 3), ".", ","), Replace(allLines(linect + 4), ".", ","))
                        linect += 4

                    Case "[ticket_sale]"
                        ticketSaleInd = allLines(linect + 1)
                        ticketSalePnt = New Point3D(-Replace(allLines(linect + 2), ".", ","), Replace(allLines(linect + 3), ".", ","), Replace(allLines(linect + 4), ".", ","))
                        linect += 4

                    Case "[ticket_sale_money_point]"
                        ticketSaleMoneyPnt = New OMSI_TicketPnt
                        With ticketSaleMoneyPnt
                            .position = New Point3D(Replace(allLines(linect + 1), ".", ","), Replace(allLines(linect + 2), ".", ","), Replace(allLines(linect + 3), ".", ","))
                            .variationX = Replace(allLines(linect + 4), ".", ",")
                            .variationY = Replace(allLines(linect + 5), ".", ",")
                        End With
                        linect += 5

                    Case "[ticket_sale_money_point_2]"
                        ticketSaleMoneyPnt = New OMSI_TicketPnt
                        With ticketSaleMoneyPnt
                            .position = New Point3D(Replace(allLines(linect + 1), ".", ","), Replace(allLines(linect + 2), ".", ","), Replace(allLines(linect + 3), ".", ","))
                            .variationX = Replace(allLines(linect + 4), ".", ",")
                            .variationY = Replace(allLines(linect + 5), ".", ",")
                            .anim = allLines(linect + 6)
                        End With
                        linect += 6

                    Case "[ticket_sale_change_point]"
                        Dim ticketSaleChangePnt As New OMSI_TicketPnt
                        With ticketSaleChangePnt
                            .position = New Point3D(Replace(allLines(linect + 1), ".", ","), Replace(allLines(linect + 2), ".", ","), Replace(allLines(linect + 3), ".", ","))
                            .variationX = Replace(allLines(linect + 4), ".", ",")
                            .variationY = Replace(allLines(linect + 5), ".", ",")
                        End With
                        linect += 5

                    Case "[ticket_sale_change_point_2]"
                        Dim ticketSaleChangePnt As New OMSI_TicketPnt
                        With ticketSaleChangePnt
                            .position = New Point3D(Replace(allLines(linect + 1), ".", ","), Replace(allLines(linect + 2), ".", ","), Replace(allLines(linect + 3), ".", ","))
                            .variationX = Replace(allLines(linect + 4), ".", ",")
                            .variationY = Replace(allLines(linect + 5), ".", ",")
                            .anim = allLines(linect + 6)
                        End With
                        linect += 6

                    Case "[drivpos]"
                        Dim tmpSeat As New OMSI_Seat
                        With tmpSeat
                            .position = New Point3D(Replace(allLines(linect + 1), ".", ","), Replace(allLines(linect + 2), ".", ","), Replace(allLines(linect + 3), ".", ","))
                            .sitheight = Replace(allLines(linect + 4), ".", ",")
                            .rot = Replace(allLines(linect + 5), ".", ",")
                        End With
                        linect += 5

                        For i = linect + 1 To allLines.Count - 1
                            If allLines(i).Contains("[") Then
                                If allLines(i) = "[illumination_interior]" Then
                                    Dim newIllumination As New OMSI_Illumination
                                    With newIllumination
                                        .values.Add(allLines(i + 1))
                                        .values.Add(allLines(i + 2))
                                        .values.Add(allLines(i + 3))
                                        .values.Add(allLines(i + 4))
                                        .index = passPos.Count
                                        linect = i + 4
                                    End With
                                    tmpSeat.illumination = newIllumination
                                    Exit For
                                Else
                                    linect = i - 1
                                    Exit For
                                End If
                            End If
                        Next
                        driverPos = tmpSeat

                    Case "[passpos]"
                        Dim tmpSeat As New OMSI_Seat
                        With tmpSeat
                            .position = New Point3D(Replace(allLines(linect + 1), ".", ","), Replace(allLines(linect + 2), ".", ","), Replace(allLines(linect + 3), ".", ","))
                            .sitheight = Replace(allLines(linect + 4), ".", ",")
                            .rot = Replace(allLines(linect + 5), ".", ",")
                        End With
                        linect += 5
                        For i = linect + 1 To allLines.Count - 1
                            If allLines(i).Contains("[") Then
                                If allLines(i) = "[illumination_interior]" Then
                                    Dim newIllumination As New OMSI_Illumination
                                    With newIllumination
                                        .values.Add(allLines(i + 1))
                                        .values.Add(allLines(i + 2))
                                        .values.Add(allLines(i + 3))
                                        .values.Add(allLines(i + 4))
                                        .index = passPos.Count
                                        linect = i + 4
                                    End With
                                    tmpSeat.illumination = newIllumination
                                    Exit For
                                Else
                                    linect = i - 1
                                    Exit For
                                End If
                            End If
                        Next

                        passPos.Add(tmpSeat)
                End Select
            Next

            Log.Add(passPos.Count & " Sitzpositionen geldaden!")
            Log.Add("Cabin-Datei """ & filename.name & """ fertig geladen.")
        Else
            Log.Add("Cabin-Datei """ & filename.name & """ kann nicht gefunden werden!")
        End If

    End Sub

    Public Sub Add(newCabin As OMSI_Cabin)
        If Not newCabin Is Nothing Then

            If Not newCabin.doors.Count Then
                If doors.Count > 0 Then
                Else

                End If
            Else

            End If



        End If


        'Public doors As New List(Of OMSI_Door)

        'Public linkToPrevVeh As Int16 = -1      'Kommt in Main
        'Public linkToNextVeh As Int16 = -1      'Kommt in Trail

        'Public stamperInd As Byte
        'Public stamperPos As Point3D

        'Public ticketSaleInd As Integer
        'Public ticketSalePnt As New Point3D

        'Public ticketSaleMoneyPnts As New List(Of OMSI_TicketPnt)
        'Public ticketSaleChangePnts As New List(Of OMSI_TicketPnt)

        'Public driverPos As OMSI_Seat
        'Public passPos As New List(Of OMSI_Seat)
    End Sub

    Public Sub save()
        If Not changed Then Exit Sub
        Dim fw As New FileWriter(filename)
        With fw
            .teilüberschrift("Ein-/Ausstiege")

            For Each door In doors
                If door.direction = OMSI_Door.IS_ENTRY Then
                    .Add("[entry]")
                Else
                    .Add("[exit]")
                End If
                .Add(door.pathindex, True)

                If door.noticketsale Then .Add("{noticketsale}", True)
                If door.withButton Then .Add("{withButton}", True)
            Next

            If linkToNextVeh > -1 Then
                .Add("[linkToNextVeh]")
                .Add(linkToNextVeh, True)
            End If

            If linkToPrevVeh > -1 Then
                .Add("[linkToPrevVeh]")
                .Add(linkToPrevVeh, True)
            End If

            .teilüberschrift("Interaktionspunkte")

            If Not stamperPnt Is Nothing Then
                .Add("[stamper]")
                .Add(stamperInd)
                .Add(stamperPnt.X)
                .Add(stamperPnt.Y)
                .Add(stamperPnt.Z, True)
            End If

            If Not ticketSalePnt Is Nothing Then
                .Add("[ticket_sale]")
                .Add(ticketSaleInd)
                .Add(ticketSalePnt.X)
                .Add(ticketSalePnt.Y)
                .Add(ticketSalePnt.Z, True)
            End If

            If Not ticketSaleMoneyPnt Is Nothing Then
                If ticketSaleMoneyPnt.anim = "" Then
                    .Add("[ticket_sale_money_point]")
                Else
                    .Add("[ticket_sale_money_point_2]")
                End If
                .Add(ticketSaleMoneyPnt.position.X)
                .Add(ticketSaleMoneyPnt.position.X)
                .Add(ticketSaleMoneyPnt.position.X)
                .Add(ticketSaleMoneyPnt.variationX)
                .Add(ticketSaleMoneyPnt.variationY)
                If ticketSaleMoneyPnt.anim <> "" Then
                    .Add(ticketSaleMoneyPnt.anim, True)
                Else
                    .Add(vbCrLf)
                End If
            End If


            If Not ticketSaleChangePnt Is Nothing Then
                If ticketSaleChangePnt.anim = "" Then
                    .Add("[ticket_sale_money_point]")
                Else
                    .Add("[ticket_sale_money_point_2]")
                End If
                .Add(ticketSaleChangePnt.position.X)
                .Add(ticketSaleChangePnt.position.X)
                .Add(ticketSaleChangePnt.position.X)
                .Add(ticketSaleChangePnt.variationX)
                .Add(ticketSaleChangePnt.variationY)
                If ticketSaleChangePnt.anim <> "" Then
                    .Add(ticketSaleChangePnt.anim, True)
                Else
                    .Add(vbCrLf)
                End If
            End If
            If Not driverPos Is Nothing Then
                .teilüberschrift("Fahrersitz")

                .Add("[drivpos]")
                .Add(driverPos.position.X)
                .Add(driverPos.position.Y)
                .Add(driverPos.position.Z)
                .Add(driverPos.sitheight)
                .Add(driverPos.rot, True)

                If Not driverPos.illumination Is Nothing Then
                    .Add("[illumination_interior]")
                    For Each illVal In driverPos.illumination.values
                        .Add(illVal)
                    Next
                    .Add(vbCrLf)
                End If
            End If

            .teilüberschrift("Sitze")

            Dim counter As Integer = 0
            For Each seat In passPos
                .Add(counter)
                .Add("[passpos]")
                .Add(seat.position.X)
                .Add(seat.position.Y)
                .Add(seat.position.Z)
                .Add(seat.sitheight)
                .Add(seat.rot, True)

                If Not seat.illumination Is Nothing Then
                    .Add("[illumination_interior]")
                    For Each illVal In seat.illumination.values
                        .Add(illVal)
                    Next
                    .Add(vbCrLf)
                End If
                counter += 1
            Next

            .Write()
        End With
        Log.Add("Cabin-Datei gespeichert! (Datei: " & filename.name & ")")
    End Sub
End Class

'	[passpos]	erstellt neue Passenger-Position
'	x
'   y
'	z		x, y, z-Koordinaten des Attachpunktes "Arsch" bzw. "Fuß"
'	h		Sitzhöhe über Boden (0 = Stehplatz)
'	rot		Drehung um z-Achse (Grad, 0 = Fahrtrichtung)

'	[drivpos]	erstellt eine neue Fahrer-Position
'	x
'   y
'	z		x, y, z-Koordinaten des Attachpunktes "Arsch" bzw. "Fuß"
'	h		Sitzhöhe über Boden (0 = Stehplatz)
'	rot		Drehung um z-Achse (Grad, 0 = Fahrtrichtung)

'	[entry]		definiert Eingang
'	num		Nr. des Pathpoints, welcher Eingang sein soll. Es können
'			mittels mehrerer [Entry]-Befehle mehrere Eingänge definiert
'			werden.

'    [exit]
'	num		analog für Ausgang



'	[stamper]	definiert, an welchem Pfadpunkt ein Entwerter angebracht ist
'	num		Nr. des Pathpoints
'	x
'   y
'	z		Position des Entwerterschlitzes oder des Punktes, wohin die Fahrkarte geführt werden soll


'	[ticket_sale]
'	num		Pfadpunkt
'	x		Position der Ticketausgabe
'	y
'   z

'[ticket_sale_money_point]
'	pos_x		Position der Geldabgabe
'	pos_y
'   pos_z
'	var_x		Variation der Koordinaten
'	var_y

'[ticket_sale_change_point]
'	pos_x		Position der Geldrückgabe
'	pos_y
'   pos_z
'	var_x		Variation der Koordinaten
'	var_y