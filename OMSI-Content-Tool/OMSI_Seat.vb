Public Class OMSI_Seat
    Private position_int As New Point3D
    Private sitheight_int As Single = 0
    Private rot_int As Single

    Private staticVertices As Double() = {0.0405, 0.035852, -0.1117, 0.0405, 0.835852, -0.1117, 0.2025, 0.035852, -0.1117, 0.2025, 0.835852, -0.1117, 0.0405, 0.035852, 0.0883, 0.0405, 0.835852, 0.0883, 0.2025, 0.035852, 0.0883, 0.2025, 0.835852, 0.0883, -0.2025, 0.035852, -0.1117, -0.2025, 0.835852, -0.1117, -0.0405, 0.035852, -0.1117, -0.0405, 0.835852, -0.1117, -0.2025, 0.035852, 0.0883, -0.2025, 0.835852, 0.0883, -0.0405, 0.035852, 0.0883, -0.0405, 0.835852, 0.0883, 0.2025, 1.635852, -0.1117, 0.2025, 1.635852, 0.0883, -0.2025, 1.635852, -0.1117, -0.2025, 1.635852, 0.0883, 0.10125, 1.635852, -0.1117, 0.10125, 1.635852, 0.0883, -0.10125, 1.635852, -0.1117, -0.10125, 1.635852, 0.0883, 0.10125, 1.935852, -0.1117, 0.10125, 1.935852, 0.0883, -0.10125, 1.935852, -0.1117, -0.10125, 1.935852, 0.0883, -0.192415, 0.976134, 0.487215, -0.271982, 1.54182, -0.069876, -0.112646, 0.976134, 0.46985, -0.192212, 1.54182, -0.087241, -0.182469, 1.046845, 0.556851, -0.262036, 1.61253, -0.00024, -0.1027, 1.046845, 0.539487, -0.182266, 1.61253, -0.017605, 0.112646, 0.976134, 0.46985, 0.192212, 1.54182, -0.087241, 0.192415, 0.976134, 0.487215, 0.271982, 1.54182, -0.069877, 0.1027, 1.046845, 0.539487, 0.182266, 1.61253, -0.017605, 0.182469, 1.046845, 0.556851, 0.262036, 1.61253, -0.00024, 0.0405, 0.435852, -0.1117, 0.2025, 0.435852, -0.1117, 0.2025, 0.435852, 0.0883, 0.0405, 0.435852, 0.0883, -0.2025, 0.435852, -0.1117, -0.0405, 0.435852, -0.1117, -0.0405, 0.435852, 0.0883, -0.2025, 0.435852, 0.0883}

    Public illumination As OMSI_Illumination

    Public vertices As Double()
    Public edges As Integer() = {1, 44, 45, 3, 45, 46, 7, 46, 47, 5, 47, 44, 6, 2, 0, 9, 48, 49, 11, 49, 50, 15, 50, 51, 13, 51, 48, 14, 10, 8, 7, 16, 3, 17, 18, 16, 13, 17, 7, 9, 19, 13, 3, 18, 9, 25, 26, 24, 20, 26, 22, 21, 24, 20, 23, 25, 21, 22, 27, 23, 28, 30, 31, 30, 34, 35, 35, 34, 32, 32, 28, 29, 34, 30, 28, 35, 33, 29, 37, 36, 38, 38, 42, 43, 43, 42, 40, 40, 36, 37, 38, 36, 40, 39, 43, 41, 51, 12, 8, 50, 14, 12, 49, 10, 14, 48, 8, 10, 47, 4, 0, 46, 6, 4, 45, 2, 6, 44, 0, 2, 1, 45, 3, 3, 46, 7, 7, 47, 5, 5, 44, 1, 6, 0, 4, 9, 49, 11, 11, 50, 15, 15, 51, 13, 13, 48, 9, 14, 8, 12, 7, 17, 16, 17, 19, 18, 13, 19, 17, 9, 18, 19, 3, 16, 18, 25, 27, 26, 20, 24, 26, 21, 25, 24, 23, 27, 25, 22, 26, 27, 28, 31, 29, 30, 35, 31, 35, 32, 33, 32, 29, 33, 34, 28, 32, 35, 29, 31, 37, 38, 39, 38, 43, 39, 43, 40, 41, 40, 37, 41, 38, 40, 42, 39, 41, 37, 51, 8, 48, 50, 12, 51, 49, 14, 50, 48, 10, 49, 47, 0, 44, 46, 4, 47, 45, 6, 46, 44, 2, 45}
    Public lines As Integer()

    Public Property sitheight() As Single
        Get
            Return sitheight_int
        End Get
        Set(value As Single)
            If Not sitheight_int = value Then
                sitheight_int = value
                recalc()
            End If
        End Set
    End Property

    Public Property rot() As Single
        Get
            Return rot_int
        End Get
        Set(value As Single)
            If Not rot_int = value Then
                rot_int = value
                recalc()
            End If
        End Set
    End Property

    Public Property position() As Point3D
        Get
            Return position_int
        End Get
        Set(value As Point3D)
            If Not position_int = value Then
                position_int = value
                recalc()
            End If
        End Set
    End Property

    Private Sub recalc()

        'Linien berechnen
        Dim tempLines As New List(Of Integer)
        Dim tempPoints As New List(Of Point)
        For i = 0 To edges.Count - 1 Step 3
            Dim newPoint As New Point(edges(i), edges(i + 1))
            If Not tempPoints.Contains(newPoint) Then
                tempLines.Add(newPoint.X)
                tempLines.Add(newPoint.Y)
                tempPoints.Add(newPoint)
            End If

            newPoint = New Point(edges(i + 1), edges(i + 2))
            If Not tempPoints.Contains(newPoint) Then
                tempLines.Add(newPoint.X)
                tempLines.Add(newPoint.Y)
                tempPoints.Add(newPoint)
            End If

            newPoint = New Point(edges(i + 2), edges(i))
            If Not tempPoints.Contains(newPoint) Then
                tempLines.Add(newPoint.X)
                tempLines.Add(newPoint.Y)
                tempPoints.Add(newPoint)
            End If
        Next
        lines = tempLines.ToArray

        'Mit den Ausgangswerten rechnen
        Dim x As New List(Of Double)
        x.AddRange(staticVertices.ToArray)

        vertices = x.ToArray

        'Alle Positionen durch gehen
        For i = 0 To vertices.Count - 1 Step 3
            Dim origPos As New Point3D(vertices(i), vertices(i + 2), vertices(i + 1))

            'Figuren animieren
            If vertices(i + 1) < 0.8 And sitheight_int > 0 Then
                vertices(i + 2) += (0.83585 - sitheight_int)
            End If

            If sitheight_int > 0 Then
                vertices(i + 1) -= 0.83585
                If origPos.Z < 0.8 Then
                    vertices(i + 1) += 0.83585 - sitheight_int
                End If

                If origPos.Y > 0 And origPos.Z > 0.1 And origPos.Z < 0.9 Then
                    vertices(i + 1) += origPos.Y * 2
                End If
            End If

            origPos = New Point3D(vertices(i), vertices(i + 2), vertices(i + 1))

            'Figuren drehen
            origPos.rotate(rot_int, Point3D.ACHSE_Z)
            vertices(i) = origPos.X
            vertices(i + 2) = origPos.Y
            vertices(i + 1) = origPos.Z

            'Figuren positionieren
            vertices(i) -= position_int.X
            vertices(i + 2) += position_int.Y
            vertices(i + 1) += position_int.Z
        Next

    End Sub
End Class
