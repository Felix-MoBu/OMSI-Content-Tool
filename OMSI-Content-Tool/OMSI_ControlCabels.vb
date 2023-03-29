Public Class OMSI_ControlCabels
    Public LRC_position As Byte = POSITION.NOT_CONNECTED
    Public index As Integer
    Public read_var As String
    Public write_var As String
    Public connector_var As String

    Public Structure POSITION
        Const LEFT As Byte = 0
        Const RIGHT As Byte = 1
        Const CENTER As Byte = 2
        Const NOT_CONNECTED As Byte = 255
    End Structure
End Class
