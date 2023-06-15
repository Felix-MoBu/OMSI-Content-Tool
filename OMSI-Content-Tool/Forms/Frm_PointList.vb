Imports System.ComponentModel

Public Class Frm_PointList
    Private Sub Frm_PointList_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        TB0.Text = Frm_Main.actProj.ProjDataBase.storedPointNames(0)
        PS0.Point = Frm_Main.actProj.ProjDataBase.storedPoints(0)

        For i = 1 To 20
            Dim newTB As New TextBox
            copyProps(TB0, newTB, i)
            If i < Frm_Main.actProj.ProjDataBase.storedPointNames.count Then
                newTB.Text = Frm_Main.actProj.ProjDataBase.storedPointNames(i)
            End If
            Me.Controls.Add(newTB)

            Dim newPS As New PointSelector
            copyProps(PS0, newPS, i)
            If i < Frm_Main.actProj.ProjDataBase.storedPoints.count Then
                newPS.Point = Frm_Main.actProj.ProjDataBase.storedPoints(i)
            End If
            Me.Controls.Add(newPS)
        Next
    End Sub

    Private Sub copyProps(ByRef fromObj As Object, ByRef toObj As Object, index As Integer)
        toObj.width = fromObj.width
        toObj.left = fromObj.left
        toObj.top = fromObj.top + index * 23
        toObj.tag = index
    End Sub

    Private Sub Frm_PointList_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If MsgBox("Sollen die änderungen gespeichert werden?", vbYesNo) = vbYes Then
            BTSpeichern_Click(BTSpeichern, EventArgs.Empty)
        End If
    End Sub

    Private Sub BTSpeichern_Click(sender As Object, e As EventArgs) Handles BTSpeichern.Click
        For Each control In Me.Controls
            If IsNumeric(control.tag) Then
                If control.GetType Is TB0.GetType Then
                    If control.text <> "" Then
                        For i As Integer = Frm_Main.actProj.ProjDataBase.storedPointNames.count - 1 To control.tag
                            Frm_Main.actProj.ProjDataBase.storedPointNames.add("")
                        Next
                        Frm_Main.actProj.ProjDataBase.storedPointNames(control.tag) = control.text
                    End If
                ElseIf control.GetType Is PS0.GetType Then
                    If Not control.point = New Point3D Then
                        For i As Integer = Frm_Main.actProj.ProjDataBase.storedPoints.count - 1 To control.tag
                            Frm_Main.actProj.ProjDataBase.storedPoints.add(New Point3D)
                        Next
                        Frm_Main.actProj.ProjDataBase.storedPoints(control.tag) = control.Point
                    End If
                End If
            End If
        Next
        Frm_Main.actProj.ProjDataBase.Save()
    End Sub
End Class