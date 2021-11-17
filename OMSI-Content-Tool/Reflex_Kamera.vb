Public Class Reflex_Kamera
    Public typ As Byte = 0
    Public index As Byte
    Public position As Point3D
    Public dist As Single
    Public sichtwinkel As Single
    Public rotX As Single
    Public rotY As Single
    Public renderDist As Single

    Public vertices As Double() = {0, 0, 0,
                               0.2, -0.1, 0.5,
                               0.2, 0.1, 0.5,
                               -0.2, -0.1, 0.5,
                               -0.2, 0.1, 0.5,
                               0.1, 0.11, 0.5,
                               -0.1, 0.11, 0.5,
                               0, 0.21, 0.5}
    Public edges As Integer() = {0, 1, 0, 2, 0, 3, 0, 4, 1, 2, 2, 4, 4, 3, 3, 1, 5, 6, 6, 7, 7, 5}

    Public Sub PositionCam()
        'totest()
        Dim tmpPt As New Point3D
        For i = 0 To vertices.Count - 1 Step 3

            tmpPt.Y = vertices(i + 2) * Math.Cos(rotY * Math.PI / 180) + vertices(i + 1) * -Math.Sin(rotY * Math.PI / 180)
            tmpPt.Z = vertices(i + 2) * Math.Sin(rotY * Math.PI / 180) + vertices(i + 1) * Math.Cos(rotY * Math.PI / 180)


            tmpPt.X = vertices(i) * Math.Cos(rotX * Math.PI / 180) + tmpPt.Y * -Math.Sin(rotX * Math.PI / 180)
            tmpPt.Y = vertices(i) * Math.Sin(rotX * Math.PI / 180) + tmpPt.Y * Math.Cos(rotX * Math.PI / 180)

            vertices(i) = tmpPt.X
            vertices(i + 2) = tmpPt.Y
            vertices(i + 1) = tmpPt.Z


            vertices(i) += -position.X
            vertices(i + 1) += position.Z
            vertices(i + 2) += position.Y
        Next
        'totest()
    End Sub
End Class



'[add_camera_reflexion_2]
'-1.332
'5.327
'1.831
'0
'52
'169
'5

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
