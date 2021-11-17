Module History
    Private liste As New List(Of Item)

    Public Sub add(obj As Object, prop As String, val_old As String, val_new As String)
        liste.Add(New Item(obj, prop, val_old, val_new))
    End Sub

    Public Sub reverse()

    End Sub

    Public Class Item
            Public obj As Object
            Public prop As String
            Public val_old As String
            Public val_new As String

            Public Sub New(obj As Object, prop As String, val_old As String, val_new As String)
                Me.obj = obj
                Me.prop = prop
                Me.val_old = val_old
                Me.val_new = val_new
            End Sub
        End Class
    End Module
