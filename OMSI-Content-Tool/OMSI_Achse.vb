Public Class OMSI_Achse
    Private achse_long_int As Single
    Private achse_maxwidth_int As Single
    Private achse_minwidth_int As Single
    Private achse_raddurchmesser_int As Single
    Public achse_feder As Single
    Public achse_maxforce As Integer
    Public achse_daempfer As Integer
    Public achse_antrieb As Boolean

    Public vertices As Double()
    Public edges As Integer()
    Public edges_init As Integer() = {0, 1}

    Public Property achse_long As Single
        Get
            Return achse_long_int
        End Get
        Set(value As Single)
            achse_long_int = value
            PositionAchse()
        End Set
    End Property

    Public Property achse_maxwidth As Single
        Get
            Return achse_maxwidth_int
        End Get
        Set(value As Single)
            achse_maxwidth_int = value
            PositionAchse()
        End Set
    End Property

    Public Property achse_minwidth As Single
        Get
            Return achse_minwidth_int
        End Get
        Set(value As Single)
            achse_minwidth_int = value
            PositionAchse()
        End Set
    End Property

    Public Property achse_raddurchmesser As Single
        Get
            Return achse_raddurchmesser_int
        End Get
        Set(value As Single)
            achse_raddurchmesser_int = value
            PositionAchse()
        End Set
    End Property


    Private Sub PositionAchse()
        If achse_minwidth_int = 0 Then Exit Sub
        If achse_maxwidth_int = 0 Then Exit Sub

        Dim vert As New List(Of Double)
        Dim edg As New List(Of Integer)

        'Achse an sich
        vert.Add(-achse_maxwidth_int / 2 - 0.5)
        vert.Add(achse_raddurchmesser_int / 2)
        vert.Add(achse_long_int)

        vert.Add(achse_maxwidth_int / 2 + 0.5)
        vert.Add(achse_raddurchmesser_int / 2)
        vert.Add(achse_long_int)

        edges = edges_init

        'Außenringe
        vert.AddRange(dwarCircle(New Point3D(achse_maxwidth_int / 2, 0, achse_long_int), New Point3D(achse_maxwidth_int / 2, achse_raddurchmesser_int / 2, achse_long_int)))
        vert.AddRange(dwarCircle(New Point3D(-achse_maxwidth_int / 2, 0, achse_long_int), New Point3D(-achse_maxwidth_int / 2, achse_raddurchmesser_int / 2, achse_long_int)))

        'Innenringe
        vert.AddRange(dwarCircle(New Point3D(achse_minwidth_int / 2, 0, achse_long_int), New Point3D(achse_minwidth_int / 2, achse_raddurchmesser_int / 2, achse_long_int)))
        vert.AddRange(dwarCircle(New Point3D(-achse_minwidth_int / 2, 0, achse_long_int), New Point3D(-achse_minwidth_int / 2, achse_raddurchmesser_int / 2, achse_long_int)))

        vert.Add(0) '-> Damit der Speicherfehler nicht auftritt
        vertices = vert.ToArray
    End Sub

    Private Function dwarCircle(point As Point3D, center As Point3D) As Double()
        Dim newVerts As New List(Of Double)
        Dim steps As Integer = 6
        Dim tmpEdges As New List(Of Integer)

        tmpEdges.AddRange(edges)

        For i = 0 To 360 / steps - 1
            point.rotate(steps, Point3D.ACHSE_X, center)
            newVerts.AddRange(point.toList)
            tmpEdges.Add(edges(edges.Count - 1) + i + 1)
        Next

        edges = tmpEdges.ToArray
        Return newVerts.ToArray
    End Function

    'Public Sub New(Y As Single, maxwidth As Single, minwidth As Single, raddurchmesser1 As Single, raddurchmesser2 As Single, feder As Integer, maxforce As Integer, daempfer As Integer, antrieb As Boolean)
    '    achse_long = Y
    '    achse_maxwidth = maxwidth
    '    achse_minwidth = minwidth
    '    achse_raddurchmesser1 = raddurchmesser1
    '    achse_raddurchmesser2 = raddurchmesser2
    '    achse_feder = feder
    '    achse_maxforce = maxforce
    '    achse_daempfer = daempfer
    '    achse_antrieb = antrieb
    'End Sub
End Class
