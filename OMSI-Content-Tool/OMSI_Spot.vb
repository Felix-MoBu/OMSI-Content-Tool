'by Felix Modellbusse ;) (MoBu) 2019
Public Class OMSI_Spot
    Public name As String
    Private position_int As New Point3D
    Public richtung As New Point3D
    Public color As New RGBColor
    Private range_int As Double
    Private innerCone_int As Integer
    Private outerCone_int As Integer
    Public parent As String

    Public vertices As Double()
    Public edges As Integer() = {0, 1, 2}

    Public Property range As Double
        Get
            Return range_int
        End Get
        Set(value As Double)
            range_int = value
            positionSpot()
        End Set
    End Property

    Public Property innerCone As Integer
        Get
            Return innerCone_int
        End Get
        Set(value As Integer)
            innerCone_int = value
            positionSpot()
        End Set
    End Property

    Public Property outerCone As Integer
        Get
            Return outerCone_int
        End Get
        Set(value As Integer)
            outerCone_int = value
            positionSpot
        End Set
    End Property

    Public Property position As Point3D
        Get
            Return position_int
        End Get
        Set(value As Point3D)
            position_int = value
            positionSpot()
        End Set
    End Property

    Private Sub positionSpot()
        Dim tmp_vert As New List(Of Double)

        tmp_vert.Add(position.X)
        tmp_vert.Add(0)             '<- Hier vlt Z einsetzen!
        tmp_vert.Add(position.Y)


        tmp_vert.Add(position.X - Math.Cos(outerCone_int / 2) * range / 2)
        tmp_vert.Add(0)             '<- Hier vlt Z einsetzen!
        tmp_vert.Add(position.Y + range / 2)


        tmp_vert.Add(position.X + Math.Cos(outerCone_int / 2) * range / 2)
        tmp_vert.Add(0)             '<- Hier vlt Z einsetzen!
        tmp_vert.Add(position.Y + range / 2)

        vertices = tmp_vert.ToArray
    End Sub

End Class
