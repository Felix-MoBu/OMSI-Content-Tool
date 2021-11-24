'by Felix Modellbusse ;) (MoBu) 2019
Public Class OMSI_BBox
    Public position As Point3D()
    Public expansion As Point3D()

    Public vertices As Double()
    Public edges As Integer() = {0, 2, 2, 6, 6, 4, 4, 0, 0, 6, 1, 3, 3, 7, 7, 5, 5, 1, 3, 5, 0, 1, 2, 3, 6, 7, 4, 5, 1, 4, 3, 0, 7, 2, 5, 6}

    Public Sub New(X As Double, Y As Double, Z As Double, A As Double, B As Double, C As Double)
        vertices = {A + X / 2, C + Z / 2, B + Y / 2,
                    A + X / 2, C - Z / 2, B + Y / 2,
                    A + X / 2, C + Z / 2, B - Y / 2,
                    A + X / 2, C - Z / 2, B - Y / 2,
                    A - X / 2, C + Z / 2, B + Y / 2,
                    A - X / 2, C - Z / 2, B + Y / 2,
                    A - X / 2, C + Z / 2, B - Y / 2,
                    A - X / 2, C - Z / 2, B - Y / 2}
    End Sub
End Class
