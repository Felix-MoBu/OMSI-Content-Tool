Public Class CheckListPoint
    Private int_Text As String
    Private int_Checked As Boolean = False

    Dim LISTSEPARATOR As Char() = {";"}

    Public Property Text As String
        Get
            Return int_Text
        End Get
        Set(value As String)
            int_Text = value
        End Set
    End Property

    Public Property Checked As Boolean
        Get
            Return int_Checked
        End Get
        Set(value As Boolean)
            int_Checked = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub New(line As String)
        Dim list As String() = line.Split(LISTSEPARATOR, 2)
        If line.Count = 2 Then
            int_Checked = intToBool(list(0))
            int_Text = list(1)
        Else
            int_Text = line
        End If
    End Sub

    Public Function toLine() As String
        Return boolToInt(int_Checked) & ";" & int_Text
    End Function
End Class
