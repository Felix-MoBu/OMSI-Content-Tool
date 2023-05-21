Public Class OCTProjekt
    Private Projekt_Emt As Proj_Emt
    Private Projekt_Bus As Proj_Bus
    Private Projekt_Ovh As Proj_Ovh
    Private Projekt_Sco As Proj_Sco
    Private Projekt_Sli As Proj_Sli

    Public Sub New()
        Projekt_Emt = New Proj_Emt
    End Sub

    Public Sub New(newProj As Object)
        Select Case newProj.TYPE
            Case Proj_Bus.TYPE
                Projekt_Bus = newProj
                Exit Sub
            Case Proj_Sco.TYPE
                Projekt_Sco = newProj
                Exit Sub
            Case Proj_Ovh.TYPE
                Projekt_Ovh = newProj
                Exit Sub
            Case Proj_Sli.TYPE
                Projekt_Sli = newProj
                Exit Sub
            Case Else
                Projekt_Emt = New Proj_Emt
        End Select
    End Sub

    Public Function getProj() As Object
        If Not Projekt_Bus Is Nothing Then Return Projekt_Bus
        If Not Projekt_Sco Is Nothing Then Return Projekt_Sco
        If Not Projekt_Ovh Is Nothing Then Return Projekt_Ovh
        If Not Projekt_Sli Is Nothing Then Return Projekt_Sli
        Return Projekt_Emt
    End Function

    Public Function getProjType() As Byte
        If Not Projekt_Bus Is Nothing Then Return Proj_Bus.TYPE
        If Not Projekt_Sco Is Nothing Then Return Proj_Sco.TYPE
        If Not Projekt_Ovh Is Nothing Then Return Proj_Ovh.TYPE
        If Not Projekt_Sli Is Nothing Then Return Proj_Sli.TYPE
        Return Proj_Emt.TYPE
    End Function

    Public Sub reset()
        Projekt_Bus = Nothing
        Projekt_Ovh = Nothing
        Projekt_Sco = Nothing
        Projekt_Sli = Nothing
        Projekt_Emt = New Proj_Emt
    End Sub
End Class
