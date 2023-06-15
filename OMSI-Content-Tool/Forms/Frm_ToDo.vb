Public Class Frm_ToDo
    Dim ProjDataBase As DataBase
    Private Sub Frm_ToDo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Location = New Point(Frm_Main.Width / 2 - Me.Width / 2, Frm_Main.Height / 2 - Me.Height / 2)
        ProjDataBase = Frm_Main.actProj.ProjDataBase
        loadList()
    End Sub

    Private Sub loadList()
        For ct As Integer = 0 To ProjDataBase.todoList.Count - 1
            Dim cb As New CheckBox
            With cb
                .Size = New Size(18, 18)
                .Top = 12 + (25 * ct)
                .Left = 7
                .Name = "cb_" & ct
                .Checked = ProjDataBase.todoList(ct).Checked
                AddHandler .Click, AddressOf cbClick
            End With
            GBOffen.Controls.Add(cb)

            Dim lb As New Label
            With lb
                .Size = New Size(GBOffen.Width - 30, 20)
                .Top = 16 + (25 * ct)
                .Left = 25
                .Name = "lb_" & ct
                .Text = ProjDataBase.todoList(ct).Text
                AddHandler .Click, AddressOf lbClick
            End With
            GBOffen.Controls.Add(lb)
        Next
    End Sub

    Private Sub lbClick(sender As Object, e As EventArgs)
        sender.visible = False
        Dim tb As New TextBox
        With tb
            .Size = sender.Size
            .Location = New Point(sender.left, sender.top - 3)
            .Text = sender.Text
            .Name = "tb_" & sender.Name.Split("_")(1)
            AddHandler .KeyDown, AddressOf tbKeyDown
            AddHandler .Leave, AddressOf tbLeave
        End With
        GBOffen.Controls.Add(tb)
        tb.Select()
    End Sub

    Private Sub cbClick(sender As Object, e As EventArgs)
        ProjDataBase.todoList(sender.Name.Split("_")(1)).Checked = sender.checked
    End Sub

    Private Sub tbKeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            tbToLb(sender)
            e.Handled = True
        End If
        GBOffen.Controls.Remove(sender)
    End Sub

    Private Sub tbLeave(sender As Object, e As EventArgs)
        tbToLb(sender)
        GBOffen.Controls.Remove(sender)
    End Sub

    Private Sub tbToLb(sender As Object)
        For Each control In GBOffen.Controls
            If control.name = "lb_" & sender.name.split("_")(1) Then
                control.text = sender.text
                control.visible = True
            End If
        Next
    End Sub

    Private Sub BTClose_Click(sender As Object, e As EventArgs) Handles BTClose.Click
        Frm_Main.actProj.ProjDataBase = ProjDataBase
        Me.Close()
    End Sub
End Class