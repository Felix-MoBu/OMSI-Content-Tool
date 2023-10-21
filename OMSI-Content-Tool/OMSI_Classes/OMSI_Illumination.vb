'by Felix Modellbusse ;) (MoBu) 2019
Public Class OMSI_Illumination
    Public values As New List(Of Int16)
    Public index As Integer

    Public Sub addValidated(newVal As Integer)
        If newVal < -1 Then newVal = -1
        values.Add(newVal)
    End Sub

End Class
