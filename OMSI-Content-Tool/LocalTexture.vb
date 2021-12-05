'by Felix Modellbusse ;) (MoBu) 2019
Public Class LocalTexture
    Public filename As Filename
    Public matName As String
    Public id As Integer

    Public diffuse As New RGBColor
    Public diffuseAlpha As Single
    Public specular As New RGBColor
    Public emissive As New RGBColor
    Public power As Single

    Public lastChangeDate As Date

    'Public R As Double
    'Public G As Double
    'Public B As Double
    'Public A As Double

    Public E As Double

    Public X1 As Double
    Public Y1 As Double
    Public Z1 As Double

    Public X2 As Double
    Public Y2 As Double
    Public Z2 As Double

    Public alpha As Double = 1
    Public sli_alpha As Byte
End Class
