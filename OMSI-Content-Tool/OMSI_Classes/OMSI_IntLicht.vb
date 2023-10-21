﻿'by Felix Modellbusse ;) (MoBu) 2019
Public Class OMSI_IntLicht
    Public name As String
    Public var As String
    Public reichweite As Double
    Public color As New RGBColor
    Public position_int As New Point3D
    Public parent As String

    Public vertices As Double()
    Public edges As Integer() = {0, 1, 2, 3, 4, 5, 6, 1, 0, 7, 8, 9, 10, 11, 12, 7,
                                 0, 1, 6, 5, 4, 3, 2, 1, 0, 7, 12, 11, 10, 9, 8, 7} '-> draw TriangeFan!

    Public Property position As Point3D
        Get
            Return position_int
        End Get
        Set(value As Point3D)
            position_int = value
            positionLicht()
        End Set
    End Property

    Private Sub positionLicht()
        Dim size As Double = 0.2
        vertices = {-position_int.X, position_int.Z, position_int.Y,
                    -position_int.X + size / 4, position_int.Z - size / 2, position_int.Y,
                    -position_int.X - size / 4, position_int.Z - size / 2, position_int.Y,
                    -position_int.X - size / 2, position_int.Z, position_int.Y,
                    -position_int.X - size / 4, position_int.Z + size / 2, position_int.Y,
                    -position_int.X + size / 4, position_int.Z + size / 2, position_int.Y,
                    -position_int.X + size / 2, position_int.Z, position_int.Y,
                    -position_int.X, position_int.Z - size / 2, position_int.Y + size / 4,
                    -position_int.X, position_int.Z - size / 2, position_int.Y - size / 4,
                    -position_int.X, position_int.Z, position_int.Y - size / 2,
                    -position_int.X, position_int.Z + size / 2, position_int.Y - size / 4,
                    -position_int.X, position_int.Z + size / 2, position_int.Y + size / 4,
                    -position_int.X, position_int.Z, position_int.Y + size / 2}
    End Sub
End Class
