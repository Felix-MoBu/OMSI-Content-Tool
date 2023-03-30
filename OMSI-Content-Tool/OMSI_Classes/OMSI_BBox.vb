'by Felix Modellbusse ;) (MoBu) 2019
Option Strict On

Public Class OMSI_BBox
    Private size_int As New Point3D
    Private pos_int As New Point3D
    Public vertices As Double()
    Public edges As Integer() = {0, 2, 2, 6, 6, 4, 4, 0, 0, 6, 1, 3, 3, 7, 7, 5, 5, 1, 3, 5, 0, 1, 2, 3, 6, 7, 4, 5, 1, 4, 3, 0, 7, 2, 5, 6}

    Public Property size As Point3D
        Get
            Return size_int
        End Get
        Set(value As Point3D)
            size_int = value
            recalc()
        End Set
    End Property

    Public Property pos As Point3D
        Get
            Return pos_int
        End Get
        Set(value As Point3D)
            pos_int = value
            recalc()
        End Set
    End Property

    Public Sub New()
        Dim tmpVert As New List(Of Double)
        For i = 0 To edges.Max
            tmpVert.Add(0)
            tmpVert.Add(0)
            tmpVert.Add(0)
        Next
        vertices = tmpVert.ToArray
    End Sub

    Public Sub New(x1 As Double, y1 As Double, z1 As Double, x2 As Double, y2 As Double, z2 As Double)
        size_int.X = x1
        size_int.Y = y1
        size_int.Z = z1

        pos_int.X = x2
        pos_int.Y = y2
        pos_int.Z = z2

        recalc()
    End Sub

    Private Sub recalc()
        vertices = {((pos_int.X + size_int.X) / 2), (pos_int.Z + size_int.Z / 2), ((pos_int.Y + size_int.Y) / 2),
                    ((pos_int.X + size_int.X) / 2), (pos_int.Z - size_int.Z / 2), ((pos_int.Y + size_int.Y) / 2),
                    ((pos_int.X + size_int.X) / 2), (pos_int.Z + size_int.Z / 2), ((pos_int.Y - size_int.Y) / 2),
                    ((pos_int.X + size_int.X) / 2), (pos_int.Z - size_int.Z / 2), ((pos_int.Y - size_int.Y) / 2),
                    ((pos_int.X - size_int.X) / 2), (pos_int.Z + size_int.Z / 2), ((pos_int.Y + size_int.Y) / 2),
                    ((pos_int.X - size_int.X) / 2), (pos_int.Z - size_int.Z / 2), ((pos_int.Y + size_int.Y) / 2),
                    ((pos_int.X - size_int.X) / 2), (pos_int.Z + size_int.Z / 2), ((pos_int.Y - size_int.Y) / 2),
                    ((pos_int.X - size_int.X) / 2), (pos_int.Z - size_int.Z / 2), ((pos_int.Y - size_int.Y) / 2)}
    End Sub
End Class
