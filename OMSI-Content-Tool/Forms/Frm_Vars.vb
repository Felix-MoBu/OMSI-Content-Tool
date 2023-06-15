'by Felix Modellbusse ;) (MoBu) 2019
Imports System.ComponentModel

Public Class Frm_Vars
    Public SelectedVar As String = ""

    Private Sub TBFilter_TextChanged(sender As Object, e As EventArgs) Handles TBFilter.TextChanged
        LoadFromFolder(TBFilter.Text)
        If LBAlleVars.Items.Contains(SelectedVar) Then
            LBAlleVars.SelectedItem = SelectedVar
        End If
    End Sub

    Private Sub LoadFromFolder(Optional search As String = "")
        LBAlleVars.Items.Clear()
        If search <> "" Then
            For Each var In Frm_Main.getOCTProj.alleVarValues.Keys
                If LCase(var).Contains(LCase(search)) Then
                    LBAlleVars.Items.Add(var)
                End If
            Next
        Else
            LBAlleVars.Items.AddRange(Frm_Main.getOCTProj.alleVarValues.Keys.ToArray)
        End If
    End Sub

    Private Sub Frm_Vars_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LBAlleVars.Items.Clear()
        LBAlleVars.Items.AddRange(Frm_Main.getOCTProj.alleVarValues.Keys.ToArray)
    End Sub

    Private Sub LBAlleVars_Click(sender As Object, e As EventArgs) Handles LBAlleVars.Click
        If LBAlleVars.Items.Count > 0 Then
            takeSelected(sender)
        End If
    End Sub

    Private Sub LBLetzteVars_Click(sender As Object, e As EventArgs) Handles LBLetzteVars.Click
        If LBLetzteVars.Items.Count > 0 Then
            takeSelected(sender)
        End If
    End Sub

    Private Sub takeSelected(LB As ListBox)
        If LB.SelectedItem = "" Then Exit Sub
        SelectedVar = LB.SelectedItem

        If SelectedVar.Contains("#") Then
            SelectedVar = SelectedVar.Replace("#", InputBox("Nummerierung mit 0 beginnend wählen!", "Variable mit Nummerierung"))
        End If

        Dim tempList As New List(Of String)
        tempList.Add(SelectedVar)

        If LBLetzteVars.Items.Count > 0 Then
            For Each var In LBLetzteVars.Items
                If Not tempList.Contains(var) Then
                    tempList.Add(var)
                End If
            Next

            LBLetzteVars.Items.Clear()
            LBLetzteVars.Items.AddRange(tempList.ToArray)
            TBFilter.Text = ""
        Else
            LBLetzteVars.Items.Add(SelectedVar)
        End If
        Me.Hide()
    End Sub

    Private Sub Frm_Vars_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.Location = New Point(Frm_Main.Width / 2 - Me.Width / 2, Frm_Main.Height / 2 - Me.Height / 2)

        If SelectedVar <> "" Then
            If varsContainVar(SelectedVar) Then
                LBAlleVars.SelectedItem = SelectedVar
            Else
                Log.Add("Variable existiert nicht im Scriptsystem! (Variable: " & SelectedVar & ")")
                MsgBox("Die Variable """ & SelectedVar & """ existiert nicht! Bitte eine andere Variable wählen.")
            End If
        End If
    End Sub

    Private Function varsContainVar(myVar As String) As Boolean
        If LBAlleVars.Items.Contains(myVar) Or LBLetzteVars.Items.Contains(myVar) Then Return True

        For Each varItem As String In LBAlleVars.Items
            If varItem.Contains("#") Then
                For i = 0 To 9
                    If varItem.Replace("#", i) = myVar Then Return True
                Next
            End If
        Next

        Return False
    End Function

    Private Sub Frm_Vars_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        TBFilter.Text = ""
    End Sub

    Private Sub BTKeine_Click(sender As Object, e As EventArgs) Handles BTKeine.Click
        SelectedVar = ""
        TBFilter.Text = ""
        Me.Hide()
    End Sub
End Class