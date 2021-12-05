'by Felix Modellbusse ;) (MoBu) 2019
Public Class OMSI_Licht
    Public name As String
    Private position_int As New Point3D
    Public richtung As New Point3D
    Public upVector As New Point3D
    Public ausrichtung As Byte
    Public rotating As Byte
    Public color As New RGBColor
    Private size_int As Double
    Public innerCone As Integer
    Public outerCone As Integer
    Public var As String
    Public faktor As Double
    Public offset As Double
    Public effekt As Byte
    Public cone As Double
    Public timeconst As Double
    Public bitmap As String
    Public parent As String

    Public vertices As Double()
    Public edges As Integer() = {0, 1, 2, 0, 2, 3, 0, 3, 4, 0, 4, 5, 0, 5, 6, 0, 6, 1,
                                 0, 2, 1, 0, 3, 2, 0, 4, 3, 0, 5, 4, 0, 6, 5, 0, 1, 6,
                                 0, 7, 8, 0, 8, 9, 0, 9, 10, 0, 10, 11, 0, 11, 12, 0, 12, 7,
                                 0, 8, 7, 0, 9, 8, 0, 10, 9, 0, 11, 10, 0, 12, 11, 0, 7, 12}
    Public Sub New()
        'nur damit man ein leeres Licht anlegen kann
    End Sub

    Public Sub New(altesLicht As OMSI_Licht)
        With altesLicht
            name = .name

            richtung = .richtung
            upVector = .upVector
            ausrichtung = .ausrichtung
            rotating = .rotating
            color = .color
            innerCone = .innerCone
            outerCone = .outerCone
            var = .var
            faktor = .faktor
            offset = .offset
            effekt = .effekt
            cone = .cone
            timeconst = .timeconst
            bitmap = .bitmap
            parent = .parent

            size = .size
            position = .position
        End With
    End Sub

    Public Property position As Point3D
        Get
            Return position_int
        End Get
        Set(value As Point3D)
            position_int = value
            positionLicht()
        End Set
    End Property

    Public Property size As Double
        Get
            Return size_int
        End Get
        Set(value As Double)
            size_int = value
            positionLicht()
        End Set
    End Property

    Private Sub positionLicht()
        vertices = {-position_int.X, position_int.Z, position_int.Y,
                    -position_int.X + size_int / 4, position_int.Z - size_int / 2, position_int.Y,
                    -position_int.X - size_int / 4, position_int.Z - size_int / 2, position_int.Y,
                    -position_int.X - size_int / 2, position_int.Z, position_int.Y,
                    -position_int.X - size_int / 4, position_int.Z + size_int / 2, position_int.Y,
                    -position_int.X + size_int / 4, position_int.Z + size_int / 2, position_int.Y,
                    -position_int.X + size_int / 2, position_int.Z, position_int.Y,
                    -position_int.X, position_int.Z - size_int / 2, position_int.Y + size_int / 4,
                    -position_int.X, position_int.Z - size_int / 2, position_int.Y - size_int / 4,
                    -position_int.X, position_int.Z, position_int.Y - size_int / 2,
                    -position_int.X, position_int.Z + size_int / 2, position_int.Y - size_int / 4,
                    -position_int.X, position_int.Z + size_int / 2, position_int.Y + size_int / 4,
                    -position_int.X, position_int.Z, position_int.Y + size_int / 2}
    End Sub
End Class
