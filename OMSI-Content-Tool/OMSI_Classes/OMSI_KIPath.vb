'by Felix Modellbusse ;) (MoBu) 2019
Public Class OMSI_KIPath
    Public position As Point3D

    Public vertices As Double()
    Public edges As Integer()
    Private edges_orig As Integer() = {0, 1, 0, 2, 0, 3, 1, 3, 3, 2}

    Public rot_z As Single
    Public radius As Single
    Public length As Single
    Public start_grad As Single
    Public end_grad As Single

    Public type As Byte         '0: Street, 1: Sidewalk, 2: Rail, 3: Airway
    Public width As Single
    Public direction As Byte    '0: vor, 1: zurück, 2: beide
    Public blinker As Byte      '0: nix, 1: gerade, 2: links, 3: rechts

    Public traffic_light As Integer = -1
    Public crossingproblem As Boolean = False

    Public Const TYPE_CAR As Byte = 0
    Public Const TYPE_HUM As Byte = 1
    Public Const TYPE_RAIL As Byte = 2
    Public Const TYPE_AIR As Byte = 3

    Public Const DIR_FOR As Byte = 0
    Public Const DIR_BACK As Byte = 1
    Public Const DIR_BOTH As Byte = 2

    'Siehe Modul OMSI_Const für Texturenamen

    Public Sub recalc()

        edges = edges_orig

        Dim points As New List(Of Point3D)
        Dim startPoint As Point3D

        startPoint = New Point3D(position.getWithInvertAchse(Point3D.ACHSE_X))
        startPoint.move(width / 2, Point3D.ACHSE_X)
        startPoint.rotate(rot_z, Point3D.ACHSE_Z, position.getWithInvertAchse(Point3D.ACHSE_X))
        points.Add(startPoint)

        startPoint = New Point3D(position.getWithInvertAchse(Point3D.ACHSE_X))
        startPoint.move(-(width / 2), Point3D.ACHSE_X)
        startPoint.rotate(rot_z, Point3D.ACHSE_Z, position.getWithInvertAchse(Point3D.ACHSE_X))
        points.Add(startPoint)

        If Not radius = 0 Then
            points.AddRange(divisionsCalc())

        Else
            Dim endPoint As Point3D
            endPoint = New Point3D(position.getWithInvertAchse(Point3D.ACHSE_X))
            endPoint.move(length, Point3D.ACHSE_Y)
            endPoint.move(width / 2, Point3D.ACHSE_X)
            endPoint.rotate(rot_z, Point3D.ACHSE_Z, position.getWithInvertAchse(Point3D.ACHSE_X))
            points.Add(endPoint)

            endPoint = New Point3D(position.getWithInvertAchse(Point3D.ACHSE_X))
            endPoint.move(length, Point3D.ACHSE_Y)
            endPoint.move(-(width / 2), Point3D.ACHSE_X)
            endPoint.rotate(rot_z, Point3D.ACHSE_Z, position.getWithInvertAchse(Point3D.ACHSE_X))
            points.Add(endPoint)
        End If

        Dim tmpvertices As New List(Of Double)
        For Each pnt In points
            tmpvertices.Add(pnt.X)
            tmpvertices.Add(pnt.Z)
            tmpvertices.Add(pnt.Y)
        Next
        Me.vertices = tmpvertices.ToArray
    End Sub

    Private Function divisionsCalc()
        Dim points As New List(Of Point3D)
        Dim tmpedges As New List(Of Integer)
        Dim center As New Point3D(radius, 0, 0)
        Dim midPoint As Point3D
        tmpedges.AddRange({0, 1})

        center.move(position.getWithInvertAchse(Point3D.ACHSE_X))

        For i = 2 To winkel() Step 2
            midPoint = New Point3D(position.getWithInvertAchse(Point3D.ACHSE_X))
            midPoint.move(-(width / 2), Point3D.ACHSE_X)
            midPoint.rotate(i, Point3D.ACHSE_Z, center)
            midPoint.rotate(-rot_z, Point3D.ACHSE_Z, position.getWithInvertAchse(Point3D.ACHSE_X))

            points.Add(midPoint)

            midPoint = New Point3D(position.getWithInvertAchse(Point3D.ACHSE_X))

            midPoint.move(width / 2, Point3D.ACHSE_X)
            midPoint.rotate(i, Point3D.ACHSE_Z, center)
            midPoint.rotate(-rot_z, Point3D.ACHSE_Z, position.getWithInvertAchse(Point3D.ACHSE_X))


            points.Add(midPoint)

            '{0, 1, 0, 2, 0, 3, 1, 3, 3, 2}
            Dim y = i - 2
            tmpedges.AddRange({y, y + 2, y, y + 3, y + 1, y + 3, y + 2, y + 3})
        Next
        edges = tmpedges.ToArray
        Return points
    End Function

    Private Function winkel()
        Return length / (2 * Math.PI * radius) * 360
    End Function
End Class
