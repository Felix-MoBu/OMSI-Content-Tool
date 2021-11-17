Public Class Kamera
    Public name As String
    Public position As Point3D
    Public type As Byte
    Public dist As Single
    Public sichtwinkel As Single
    Public rotX As Single
    Public rotY As Single
    Public schedule As Boolean
    Public selling As Boolean

    Public vertices_orig As Double() = {0, 0, 0,
                                   0.2, -0.1, 0.5,
                                   0.2, 0.1, 0.5,
                                   -0.2, -0.1, 0.5,
                                   -0.2, 0.1, 0.5,
                                   0.1, 0.11, 0.5,
                                   -0.1, 0.11, 0.5,
                                   0, 0.21, 0.5}
    Public vertices As Double()
    Public edges As Integer() = {0, 1, 0, 2, 0, 3, 0, 4, 1, 2, 2, 4, 4, 3, 3, 1, 5, 6, 6, 7, 7, 5}

    Public Sub New()
        vertices = vertices_orig
    End Sub

    Public Sub PositionCam()
        'totest()
        Dim tmpPt As New Point3D
        For i = 0 To vertices_orig.Count - 1 Step 3

            tmpPt.Y = vertices_orig(i + 2) * Math.Cos(rotY * Math.PI / 180) + vertices_orig(i + 1) * -Math.Sin(rotY * Math.PI / 180)
            tmpPt.Z = vertices_orig(i + 2) * Math.Sin(rotY * Math.PI / 180) + vertices_orig(i + 1) * Math.Cos(rotY * Math.PI / 180)


            tmpPt.X = vertices_orig(i) * Math.Cos(rotX * Math.PI / 180) + tmpPt.Y * -Math.Sin(rotX * Math.PI / 180)
            tmpPt.Y = vertices_orig(i) * Math.Sin(rotX * Math.PI / 180) + tmpPt.Y * Math.Cos(rotX * Math.PI / 180)

            vertices(i) = tmpPt.X
            vertices(i + 2) = tmpPt.Y
            vertices(i + 1) = tmpPt.Z


            vertices(i) += -position.X
            vertices(i + 1) += position.Z
            vertices(i + 2) += position.Y
        Next
        'totest()
    End Sub

    Function cam_type() As String
        Select Case type
            Case 0
                Return "driver"
            Case Else
                Return "pax"
        End Select
    End Function
End Class

'0: Blick nach ganz links
'[add_camera_driver]
'-0.9
'4.80
'2.13
'-0.06
'48
'-120
'-5

'x (lateral)
'y (longitudinal)
'z (vertikal)
'dist, d.h. wie weit befindet sich das Auge vor dem Halsgelenk ;-) vgl. Außensicht:
'	hier ist die Distanz variabel und normalerweise einige Dekameter positiv, sodass
'	der Mittelpunkt(durch x, y, z) In Form des Busses sichtbar und zentriert ist.
'	Beim Fahrer sollte der Wert ein wenig negativ sein, da sich der Kopf nicht ums Auge sondern
'	um eine Punkt, ca. 6cm dahinter dreht ;-)
'sichtwinkel: Bildausschnitt in Grad, für Fahrer normalerweise 52°, normal ist jedoch 45°.
'Normale Sichtausrichtung in Querrichtung in °
'Normale Sichtausrichtung in vertikale Richtung in °
'Abstand Kamera - Spiegel in Metern, wenn größer als angegebener Wert wird die Kamera nicht mehr gerendert (spart performance)