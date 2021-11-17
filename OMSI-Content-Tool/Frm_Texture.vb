'Option Strict On
Imports System.ComponentModel

Public Class Frm_Texture
    Dim texCoords_int As Double()
    Dim subObjekt_int As Integer()

    Private Sub Frm_Texture_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Frm_Main.PanelTexture.Visible = True
    End Sub

    Private Sub LBTexture_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LBTexturen.SelectedIndexChanged
        LBTexturen.Visible = False
    End Sub

    Private Sub Frm_Texture_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PMain.Size = Size
        PMain.Location = New Point(0, 0)
    End Sub

    Private Sub AndereToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles AndereToolStripMenuItem.Click
        LBTexturen.Visible = Not LBTexturen.Visible
        PBMain.Invalidate()
    End Sub

    Private Sub PBMain_Click(sender As Object, e As EventArgs) Handles PBMain.Click
        LBTexturen.Visible = False
    End Sub

    Private Sub WireframeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WireframeToolStripMenuItem.Click
        WireframeToolStripMenuItem.Checked = Not WireframeToolStripMenuItem.Checked
    End Sub

    Public Property ImageTag As Filename
        Get
            Return PBMain.Tag
        End Get
        Set(value As Filename)
            PBMain.Tag = value
            DisplayImage(PBMain)
        End Set
    End Property

    Public Sub drawUV(texCoords As Double(), subObjekt As Integer())
        For Each element In Frm_Main.Mat_CBTex.Items
            LBTexturen.Items.Add(element)
        Next


        texCoords_int = texCoords
        subObjekt_int = subObjekt
    End Sub

    Private Sub PBMain_Paint(sender As Object, e As PaintEventArgs) Handles PBMain.Paint, Me.Paint
        If Not WireframeToolStripMenuItem.Checked Then Exit Sub

        If texCoords_int Is Nothing Or subObjekt_int Is Nothing Then Exit Sub

        Dim myPen As Pen
        myPen = New Pen(Brushes.Orange, 1)


        Dim formatMp As Double = Math.Min(sender.Width / PBMain.Image.Width, sender.Height / PBMain.Image.Height)
        Dim mp As New Point(formatMp * PBMain.Image.Width, formatMp * PBMain.Image.Height)
        Dim off As New Point((sender.Width - mp.X) / 2, (sender.Height - mp.Y) / 2)

        For i As Integer = 0 To subObjekt_int.Count - 2 Step 1
            Dim pointA As New Point(Convert.ToInt32(off.X + texCoords_int(subObjekt_int(i) * 2) * mp.X), Convert.ToInt32(off.Y + texCoords_int((subObjekt_int(i) * 2) + 1) * mp.Y))
            Dim pointB As New Point(Convert.ToInt32(off.X + texCoords_int(subObjekt_int(i + 1) * 2) * mp.X), Convert.ToInt32(off.Y + texCoords_int((subObjekt_int(i + 1) * 2) + 1) * mp.Y))
            e.Graphics.DrawLine(myPen, pointA.X, pointA.Y, pointB.X, pointB.Y)
            'e.Graphics.DrawLine(myPen, Convert.ToSingle(texCoords_int(subObjekt_int(i) * 2) * mp.X), Convert.ToSingle(texCoords_int((subObjekt_int(i) * 2) + 1) * mp.Y), Convert.ToSingle(texCoords_int(subObjekt_int(i + 1) * 2) * mp.X), Convert.ToSingle(texCoords_int(subObjekt_int(i + 1) * 2) + 1) * mp.Y)
        Next
    End Sub

    Private Sub Me_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        If Not WireframeToolStripMenuItem.Checked Then Exit Sub

        If texCoords_int Is Nothing Or subObjekt_int Is Nothing Then Exit Sub

        Dim myPen As Pen
        myPen = New Pen(Brushes.Orange, 1)


        Dim formatMp As Double = Math.Min(sender.Width / PBMain.Image.Width, sender.Height / PBMain.Image.Height)
        Dim mp As New Point(formatMp * PBMain.Image.Width * PBMain.Width / Width, formatMp * PBMain.Image.Height * PBMain.Height / Height)
        Dim off As New Point(PMain.Left + (PBMain.Width - mp.X) / 2, PMain.Top + (PBMain.Height - mp.Y) / 2)

        For i As Integer = 0 To subObjekt_int.Count - 2 Step 1
            If texCoords_int(subObjekt_int(i) * 2) < 0 Or texCoords_int(subObjekt_int(i) * 2) > 1 Or texCoords_int((subObjekt_int(i) * 2) + 1) < 0 Or texCoords_int((subObjekt_int(i) * 2) + 1) > 1 Then
                Dim pointA As New Point(Convert.ToInt32(off.X + texCoords_int(subObjekt_int(i) * 2) * mp.X), Convert.ToInt32(off.Y + texCoords_int((subObjekt_int(i) * 2) + 1) * mp.Y))
                Dim pointB As New Point(Convert.ToInt32(off.X + texCoords_int(subObjekt_int(i + 1) * 2) * mp.X), Convert.ToInt32(off.Y + texCoords_int((subObjekt_int(i + 1) * 2) + 1) * mp.Y))
                e.Graphics.DrawLine(myPen, pointA.X, pointA.Y, pointB.X, pointB.Y)
            End If
        Next
    End Sub

    Private Sub BearbeitenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BearbeitenToolStripMenuItem.Click
        If Not PBMain.Tag Is Nothing Then
            Process.Start(PBMain.Tag)
        End If
    End Sub

    Private Sub ZentrierenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ZentrierenToolStripMenuItem.Click
        PMain.Location = New Point(0, 0)
        PMain.Size = Size
    End Sub

    Dim scrollControl As Boolean
    Dim scrollShift As Boolean
    Private Sub PBMain_MouseWheel(sender As Object, e As MouseEventArgs) Handles PBMain.MouseWheel, Me.MouseWheel
        If scrollControl Then
            If e.Delta > 0 Then
                PMain.Width = PMain.Width * 1.05
                PMain.Height = PMain.Height * 1.05
            Else
                If PMain.Width > 32 Then
                    PMain.Width = PMain.Width / 1.05
                    PMain.Height = PMain.Height / 1.05
                End If
            End If
        ElseIf scrollShift Then
            If e.Delta > 0 Then
                PMain.Left = PMain.Left + 20
            Else
                PMain.Left = PMain.Left - 20
            End If
        Else
            If e.Delta > 0 Then
                PMain.Top = PMain.Top + 20
            Else
                PMain.Top = PMain.Top - 20
            End If
        End If
        Me.Refresh()
    End Sub

    Private Sub PBMain_KeyDown(sender As Object, e As KeyEventArgs) Handles PBMain.KeyDown, Me.KeyDown
        scrollControl = e.Control
        scrollShift = e.Shift
    End Sub

    Private Sub PBMain_KeyUp(sender As Object, e As KeyEventArgs) Handles PBMain.KeyUp, Me.KeyUp
        scrollControl = e.Control
        scrollShift = e.Shift
    End Sub

    Private Sub Frm_Texture_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize

    End Sub
End Class