'by Felix Modellbusse ;) (MoBu) 2019
Public Class Local3DObjekt
    Public id As Integer
    Public position As New Point3D
    Public center As New Point3D
    Public scale As Double = 1
    Public visible As Boolean = True
    Public tempHidden As Boolean = False

    Public A1 As New Point3D
    Public A2 As Double
    Public B1 As New Point3D
    Public B2 As Double
    Public C1 As New Point3D
    Public C2 As Double

    Public vertices As Double()
    Public normals As Double()
    Public lines As Integer()
    Public texCoords As Double()
    Public subObjekte As New List(Of Integer())

    Public texturen As New List(Of LocalTexture)
End Class
