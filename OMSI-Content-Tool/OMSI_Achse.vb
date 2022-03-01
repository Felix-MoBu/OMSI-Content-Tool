'by Felix Modellbusse ;) (MoBu) 2019
Public Class OMSI_Achse
    Private Y_int As Single
    Private maxwidth_int As Single
    Private minwidth_int As Single
    Private raddurchmesser_int As Single
    Public feder As Single
    Public maxforce As Integer
    Public daempfer As Integer
    Public antrieb As Boolean

    Public vertices As Double()
    Public edges As Integer()
    Public edges_init As Integer() = {0, 1}

    Public Property Y As Single
        Get
            Return Y_int
        End Get
        Set(value As Single)
            Y_int = value
            PositionAchse()
        End Set
    End Property

    Public Property maxwidth As Single
        Get
            Return maxwidth_int
        End Get
        Set(value As Single)
            maxwidth_int = value
            PositionAchse()
        End Set
    End Property

    Public Property minwidth As Single
        Get
            Return minwidth_int
        End Get
        Set(value As Single)
            minwidth_int = value
            PositionAchse()
        End Set
    End Property

    Public Property raddurchmesser As Single
        Get
            Return raddurchmesser_int
        End Get
        Set(value As Single)
            raddurchmesser_int = value
            PositionAchse()
        End Set
    End Property


    Private Sub PositionAchse()
        If minwidth_int = 0 Then Exit Sub
        If maxwidth_int = 0 Then Exit Sub

        Dim vert As New List(Of Double)
        Dim edg As New List(Of Integer)

        'Achse an sich
        vert.Add(-maxwidth_int / 2 - 0.5)
        vert.Add(raddurchmesser_int / 2)
        vert.Add(Y_int)

        vert.Add(maxwidth_int / 2 + 0.5)
        vert.Add(raddurchmesser_int / 2)
        vert.Add(Y_int)

        edges = edges_init

        'Außenringe
        vert.AddRange(dwarCircle(New Point3D(maxwidth_int / 2, 0, Y_int), New Point3D(maxwidth_int / 2, raddurchmesser_int / 2, Y_int)))
        vert.AddRange(dwarCircle(New Point3D(-maxwidth_int / 2, 0, Y_int), New Point3D(-maxwidth_int / 2, raddurchmesser_int / 2, Y_int)))

        'Innenringe
        vert.AddRange(dwarCircle(New Point3D(minwidth_int / 2, 0, Y_int), New Point3D(minwidth_int / 2, raddurchmesser_int / 2, Y_int)))
        vert.AddRange(dwarCircle(New Point3D(-minwidth_int / 2, 0, Y_int), New Point3D(-minwidth_int / 2, raddurchmesser_int / 2, Y_int)))

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
