Public Class OMSI_ContactShoe
    Public boogieIndex As Integer
    Public xMin As Single
    Public xMax As Single
    Public YMin As Single
    Public YMax As Single
    Public type As Byte = SHOE_TYPE.NOT_SELECTED

    Public Structure SHOE_TYPE
        Const TOP As Byte = 1
        Const BUTTOM As Byte = 2
        Const SIDE As Byte = 4
        Const NOT_SELECTED As Byte = 255
    End Structure
End Class
