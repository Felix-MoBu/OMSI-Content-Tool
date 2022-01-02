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
    Public edges As Integer() = {0, 1, 2, 3, 4, 5, 6, 7, 0, 8, 9, 10, 11, 12, 13, 14,
                                 0, 7, 6, 5, 4, 3, 2, 1, 0, 14, 13, 12, 11, 10, 9, 8} '-> draw TriangeFan!
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
        Dim tmpPoint As New Point3D(0, 0, size_int / 2) ' / 4)
        Dim tmpList As New List(Of Point3D)
        tmpList.Add(New Point3D(tmpPoint))

        For i As Integer = 1 To 7
            tmpPoint.rotate(45, Point3D.ACHSE_X)
            tmpList.Add(New Point3D(tmpPoint))
        Next
        tmpPoint.rotate(45, Point3D.ACHSE_X)

        For i As Integer = 1 To 7
            tmpPoint.rotate(45, Point3D.ACHSE_Y)
            tmpList.Add(New Point3D(tmpPoint))
        Next

        Dim tmpList2 As New List(Of Double)
        For Each pnt In tmpList
            tmpList2.Add(-position.X + pnt.X)
            tmpList2.Add(position.Z + pnt.Z)
            tmpList2.Add(position.Y + pnt.Y)
        Next
        vertices = tmpList2.ToArray
    End Sub

End Class
