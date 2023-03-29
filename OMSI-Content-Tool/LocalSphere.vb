Public Class LocalSphere
    Private location_int As New Point3D
    Private size_int As Single = 1

    Public vertices As Double()
    Public edges As Integer()

    Public Sub New(location As Point3D, size As Single)
        location_int = location
        size_int = size
        positionSphere()
    End Sub

    Public Property location As Point3D
        Get
            Return location_int
        End Get
        Set(value As Point3D)
            location_int = value
            positionSphere()
        End Set
    End Property

    Public Property size As Single
        Get
            Return size_int
        End Get
        Set(value As Single)
            size_int = value
        End Set
    End Property

    Private Sub positionSphere()
        vertices = dwarCircle(New Point3D(location_int.X, location_int.Z - size, location_int.Y), New Point3D(location_int.X, location_int.Z, location_int.Y))
    End Sub

    Private Function dwarCircle(point As Point3D, center As Point3D) As Double()
        Dim newVerts As New List(Of Double)
        Dim steps As Integer = 6
        Dim tmpEdges As New List(Of Integer)


        tmpEdges.Add(0)
        For i = 0 To 360 / steps - 1
            point.rotate(steps, Point3D.ACHSE_X, center)
            newVerts.AddRange(point.toList)
            tmpEdges.Add(i + 1)
        Next

        'WEITEREN RING ERGÄNZEN!
        'For i = 0 To 360 / steps - 1
        '    point.rotate(steps, Point3D.ACHSE_Z, center)
        '    newVerts.AddRange(point.toList)
        '    tmpEdges.Add(i + 361)
        'Next

        edges = tmpEdges.ToArray
        Return newVerts.ToArray
    End Function

End Class
