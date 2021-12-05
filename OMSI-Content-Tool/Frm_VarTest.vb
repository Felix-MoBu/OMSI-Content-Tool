'by Felix Modellbusse ;) (MoBu) 2019
Imports System.ComponentModel

Public Class Frm_VarTest
    Dim ListCount As Integer = 0

    Private Sub Frm_Var_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Location = New Point(Frm_Main.Width / 2 - Me.Width / 2, Frm_Main.Height / 2 - Me.Height / 2)
        ListCount = 1
    End Sub

    Private Sub valueChanged(sender As Object, e As EventArgs) Handles TB_0.TextChanged
        If sender.text = "" Then Exit Sub
        If sender.text = "-" Then Exit Sub
        If sender.text = "." Then Exit Sub
        For Each control In Me.Controls
            If control.name.Contains("VS_") Then
                If control.name.split("_")(1) = sender.name.split("_")(1) Then
                    For i = 0 To Frm_Main.AlleVariablen.Count - 1
                        If control.variable = Frm_Main.AlleVariablen(i) Then
                            Frm_Main.AlleVarValues(i) = sender.text
                            Frm_Main.RecalcVis(control.variable, sender.text)
                            Frm_Main.RecalcAlpha(control.variable, sender.text)
                            Frm_Main.GlMain.Invalidate()
                            Exit Sub
                        End If
                    Next
                End If
            End If
        Next
    End Sub

    Private Sub MouseDownBT(sender As Object, e As MouseEventArgs) Handles BT_0.MouseDown
        For Each control In Me.Controls
            If control.name = "TB_" & sender.name.split("_")(1) Then
                control.text = 1
                Exit For
            End If
        Next
    End Sub

    Private Sub MouseUpBT(sender As Object, e As MouseEventArgs) Handles BT_0.MouseUp
        For Each control In Me.Controls
            If control.name = "TB_" & sender.name.split("_")(1) Then
                control.text = 0
                Exit For
            End If
        Next
    End Sub

    Private Sub keyPressTB(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TB_0.KeyPress
        e.Handled = helper.NumbersOnly(e, sender, True)
    End Sub

    Private Sub ClickRM(sender As Object, e As MouseEventArgs) Handles RM_0.Click
        Dim id As Integer = sender.name.split("_")(1)
        Me.Controls.RemoveByKey("VS_" & id)
        Me.Controls.RemoveByKey("BT_" & id)
        Me.Controls.RemoveByKey("TB_" & id)
        Me.Controls.Remove(sender)

        For Each control In Me.Controls
            If control.Name.contains("_") Then
                If control.Name.Split("_")(1) > id Then
                    control.Name.Split("_")(1) = control.Name.Split("_")(1) - 1
                    control.top = control.top - 28
                End If
            End If
        Next
        ListCount -= 1
        BTHinzu.Top = BTHinzu.Top - 28
    End Sub

    Private Sub BTHinzu_Click(sender As Object, e As EventArgs) Handles BTHinzu.Click
        Dim VS As New VarSelector
        With VS
            .Top = ListCount * 28 + 12
            .Left = 12
            .Width = 178
            .Height = 20
            .Name = "VS_" & ListCount
            AddHandler .Click, AddressOf VBClick '-> Wenn sich die Var ändert muss der Wert geladen werden.
        End With
        Me.Controls.Add(VS)
        VS = Nothing

        Dim BT As New Button
        With BT
            .Top = ListCount * 28 + 11
            .Left = 196
            .Width = 75
            .Height = 23
            .Text = "Trigger"
            .Name = "BT_" & ListCount
            AddHandler .MouseDown, AddressOf MouseDownBT
            AddHandler .MouseUp, AddressOf MouseUpBT
        End With
        Me.Controls.Add(BT)
        BT = Nothing

        Dim TB As New TextBox
        With TB
            .Top = ListCount * 28 + 12
            .Left = 277
            .Width = 75
            .Height = 20
            .Text = "0"
            .Name = "TB_" & ListCount
            AddHandler .TextChanged, AddressOf valueChanged
            AddHandler .MouseDown, AddressOf TB_MouseDown
            AddHandler .MouseMove, AddressOf TB_MouseMove
            AddHandler .MouseUp, AddressOf TB_MouseUp
        End With
        Me.Controls.Add(TB)

        Dim RM As New Button
        With RM
            .Top = ListCount * 28 + 11
            .Left = 358
            .Width = 19
            .Height = 23
            .Text = "-"
            .Name = "RM_" & ListCount
            AddHandler .Click, AddressOf ClickRM
        End With
        Me.Controls.Add(RM)

        ListCount += 1
        BTHinzu.Top = BTHinzu.Top + 28

    End Sub

    Private Sub VBClick(sender As Object, e As EventArgs)
        If sender.text <> "" Then
            MsgBox(sender.text)
        Else
            MsgBox("Garnix")
        End If
        'Wert laden wenn sich die Var ändert!
    End Sub

    Private Sub Frm_VarTest_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Me.Hide()
        e.Cancel = True
    End Sub

    Dim mouseIsDown As Boolean
    Private Sub TB_MouseDown(sender As Object, e As MouseEventArgs) Handles TB_0.MouseDown
        mouseIsDown = True
    End Sub

    Private Sub TB_MouseUp(sender As Object, e As MouseEventArgs) Handles TB_0.MouseUp
        mouseIsDown = False
    End Sub

    Private Sub TB_MouseMove(sender As Object, e As MouseEventArgs) Handles TB_0.MouseMove
        If mouseIsDown Then
            sender.text = Format((MousePosition.X + 5 - Me.Location.X - sender.Location.X) / (sender.width + 5), "#0.###")
        End If
    End Sub
End Class