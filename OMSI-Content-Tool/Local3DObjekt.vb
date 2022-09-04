'by Felix Modellbusse ;) (MoBu) 2019
Public Class Local3DObjekt
    Public id As Integer
    Public parentMesh As String

    Public position As New Point3D
    Public center As New Point3D
    Public scale As Double = 1
    Public visible As Boolean = True
    Public tempHidden As Boolean = False

    Public scaleX As New Point3D
    Public scaleY As New Point3D
    Public scaleZ As New Point3D

    Public A1 As New Point3D
    Public A2 As Double
    Public B1 As New Point3D
    Public B2 As Double
    Public origin As New Point3D
    Public origin_scale As Double

    Public vertices As Double()
    Public normals As Double()
    Public lines As Integer()
    Public texCoords As Double()
    Public subObjekte As New List(Of Integer())

    Public texturen As New List(Of LocalTexture)
End Class
