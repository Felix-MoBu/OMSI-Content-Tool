Public Class CheckListPoint
    Private int_Text As String
    Private int_Checked As Boolean = False

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
        If line.Contains(";") Then
            int_Checked = intToBool(line.Split(";")(0))
            int_Text = line.Split(";")(1)
        Else
            int_Text = line
        End If
    End Sub

    Public Function toLine() As String
        Return boolToInt(int_Checked) & ";" & int_Text
    End Function
End Class
