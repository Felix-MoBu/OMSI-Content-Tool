'by Felix Modellbusse ;) (MoBu) 2019
Public Class RGBColor
    Public R As Byte
    Public G As Byte
    Public B As Byte

    Public Property SelectedColor As Color
        Get
            Return Color.FromArgb(R, G, B)
        End Get
        Set(value As Color)
            R = value.R
            G = value.G
            B = value.B
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub New(rot As Byte, grün As Byte, blau As Byte)
        R = rot
        G = grün
        B = blau
    End Sub

    Public Sub New(rot As Single, grün As Single, blau As Single)
        R = Helper.toByte(255 * rot)
        G = Helper.toByte(255 * grün)
        B = Helper.toByte(255 * blau)
    End Sub
End Class
