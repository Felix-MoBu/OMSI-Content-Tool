Public Class Model
    Public filename As String

    Public bbox As List(Of Point3D)
    Public detailfaktor As Single

    Public TexChangeName As String
    Public TexChangeFolder As String
    Public TexChangeInt As Integer
    Public TexChangeTexs As List(Of Texture_Change)

    'TextTexturen
    'Lichter
    'Innenlichter

    Public lod_norm As Byte
    Public meshes As List(Of OMSI_Mesh)
    Public rauch As List(Of OMSI_Rauch)

    Public lod_einfach As Byte
    Public meshes_einfach As List(Of OMSI_Mesh)

End Class
