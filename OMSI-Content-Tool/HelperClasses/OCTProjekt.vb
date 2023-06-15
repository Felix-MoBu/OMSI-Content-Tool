Public Class OCTProjekt
    Private Projekt_Emt As Proj_Emt
    Private Projekt_Bus As Proj_Bus
    Private Projekt_Ovh As Proj_Ovh
    Private Projekt_Sco As Proj_Sco
    Private Projekt_Sli As Proj_Sli

    Public ReadOnly getProjType As Byte = Proj_Emt.TYPE

    Public alleMeshes As New List(Of Mesh)
    Public alleTexturen As New List(Of String)
    Public alleVarValues As New Dictionary(Of String, Single)

    Public Sub New()
        Projekt_Emt = New Proj_Emt
    End Sub

    Public Sub New(newProj As Object)
        Select Case newProj.TYPE
            Case Proj_Bus.TYPE
                Projekt_Bus = newProj
                getProjType = Proj_Bus.TYPE
                Exit Sub
            Case Proj_Sco.TYPE
                Projekt_Sco = newProj
                getProjType = Proj_Sco.TYPE
                Exit Sub
            Case Proj_Ovh.TYPE
                Projekt_Ovh = newProj
                getProjType = Proj_Ovh.TYPE
                Exit Sub
            Case Proj_Sli.TYPE
                Projekt_Sli = newProj
                getProjType = Proj_Sli.TYPE
                Exit Sub
            Case Else
                Projekt_Emt = New Proj_Emt
                getProjType = Proj_Emt.TYPE
        End Select
    End Sub

    Public Function actProj() As Object
        If Not Projekt_Bus Is Nothing Then Return Projekt_Bus
        If Not Projekt_Sco Is Nothing Then Return Projekt_Sco
        If Not Projekt_Ovh Is Nothing Then Return Projekt_Ovh
        If Not Projekt_Sli Is Nothing Then Return Projekt_Sli
        Return Projekt_Emt
    End Function

    'Public Function getProjType() As Byte
    '    If Not Projekt_Bus Is Nothing Then Return Proj_Bus.TYPE
    '    If Not Projekt_Sco Is Nothing Then Return Proj_Sco.TYPE
    '    If Not Projekt_Ovh Is Nothing Then Return Proj_Ovh.TYPE
    '    If Not Projekt_Sli Is Nothing Then Return Proj_Sli.TYPE
    '    Return Proj_Emt.TYPE
    'End Function

    Public Sub reset()
        Projekt_Bus = Nothing
        Projekt_Ovh = Nothing
        Projekt_Sco = Nothing
        Projekt_Sli = Nothing
        Projekt_Emt = New Proj_Emt
    End Sub

    Public Sub addVarValues(var As String, value As Integer)
        If Not alleVarValues.ContainsKey(var) Then
            alleVarValues.Add(var, value)
        End If
    End Sub

    Public Sub addVarValues(listOfVars As List(Of String), value As Integer)
        For Each var In listOfVars
            If Not alleVarValues.ContainsKey(var) Then
                alleVarValues.Add(var, value)
            End If
        Next
    End Sub

    Public Sub addVarValues(listOfVars As List(Of String), listOfValues As List(Of Integer))
        If listOfVars.Count > listOfValues.Count Then
            Log.Add("Fehler beim Versuch eine Liste mit Variablen zum Projekt hinzuzufügen. (no length match)", Log.TYPE_DEBUG)
            Exit Sub
        End If

        For i = 0 To listOfVars.Count
            If Not alleVarValues.ContainsKey(listOfVars(i)) Then
                alleVarValues.Add(listOfVars(i), listOfValues(i))
            End If
        Next
    End Sub
End Class
