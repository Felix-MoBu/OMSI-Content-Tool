Public Class OMSI_Door
    Public pathindex As Integer

    Public direction As Boolean

    Public withButton As Boolean
    Public noticketsale As Boolean

    Public Const IS_ENTRY As Boolean = 0
    Public Const IS_EXIT As Boolean = 1

    Public Sub New(index As Int16, entryExit As Boolean)
        pathindex = index
        direction = entryExit

    End Sub
End Class
