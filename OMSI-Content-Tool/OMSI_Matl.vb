'by Felix Modellbusse ;) (MoBu) 2019
Public Class OMSI_Matl
    Public name As String
    Public index As Byte

    Public alpha As Single = -1
    Public alphascale As String
    Public zWrite As Boolean
    Public zCheck As Boolean
    Public transmap As Boolean
    Public transmapVar As String
    Public item As Boolean

    Public lightmap As New List(Of OMSI_Lightmap)

    Public nightmap_name As String '-> Nur für [matl_change]

    Public env_map As String
    Public env_scalce As String
    Public envmask As String
    Public envval As Single

    Public texTex As Boolean
    Public texTexVal As Integer
    Public bumpmap_file As String
    Public bumpmap_val As Single

    Public freetexFile As String
    Public freetexVar As String

    Public transX As String
    Public transY As String

    Public adressBorder As List(Of Byte)
    Public asressClamp As Boolean

    Public matlChange As OMSI_MatlChange

    'Public patchWorkChain As OMSI_MatlPatchWorkChain
    '...


End Class
