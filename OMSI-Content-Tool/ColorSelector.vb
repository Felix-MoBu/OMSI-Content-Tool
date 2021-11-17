Public Class ColorSelector
    Public WidthOfTB As Integer = 100
    Public StartOfTB As Integer = 59

    Private Sub PBColor_Click(sender As Object, e As EventArgs) Handles PBColor.Click
        With CD1
            .Color = PBColor.BackColor
            .FullOpen = True
            .ShowDialog()
            PBColor.BackColor = .Color
            ColorR.Text = .Color.R
            ColorG.Text = .Color.G
            ColorB.Text = .Color.B
        End With
    End Sub

    Private Sub Mat_CBBColor_Scroll(sender As Object, e As ScrollEventArgs) Handles CBBColor.Scroll
        If e.OldValue > e.NewValue Then
            ColorR.Text = Frm_Main.Clipboard3D.X
            ColorG.Text = Frm_Main.Clipboard3D.Y
            ColorB.Text = Frm_Main.Clipboard3D.Z
        End If
        If e.NewValue > e.OldValue Then Frm_Main.Clipboard3D = New Point3D(ColorR.Text, ColorG.Text, ColorB.Text)
        e.NewValue = 50
    End Sub

    Private Sub ColorSelector_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Reload()
    End Sub

    Public Sub Reload()
        Dim tempWidth As Integer = (WidthOfTB / 4) - 4
        Me.Width = StartOfTB + (tempWidth * 4) + 24 + 26

        PBColor.Left = StartOfTB
        PBColor.Width = tempWidth

        ColorR.Left = StartOfTB + tempWidth + 6
        ColorR.Width = tempWidth

        ColorG.Left = StartOfTB + (tempWidth * 2) + 12
        ColorG.Width = tempWidth

        ColorB.Left = StartOfTB + (tempWidth * 3) + 18
        ColorB.Width = tempWidth

        CBBColor.Left = StartOfTB + (tempWidth * 4) + 24
        recalcColor()
    End Sub

    Public Property SelectedColor As RGBColor
        Get
            Dim newColor As New RGBColor
            newColor.SelectedColor = PBColor.BackColor
            Return newColor
        End Get
        Set(value As RGBColor)
            ColorR.Text = value.R
            ColorG.Text = value.G
            ColorB.Text = value.B
        End Set
    End Property

    Private Sub TBColorR_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ColorR.KeyPress
        e.Handled = helper.NumbersOnly(e)
        If sender.Text = "" Then sender.Text = "0"
        recalcColor()
    End Sub

    Private Sub TBColorG_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ColorG.KeyPress
        e.Handled = helper.NumbersOnly(e)
        If sender.Text = "" Then sender.Text = "0"
        recalcColor()
    End Sub

    Private Sub TBColorB_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ColorB.KeyPress
        e.Handled = helper.NumbersOnly(e)
        If sender.Text = "" Then sender.Text = "0"
        recalcColor()
    End Sub

    Public Sub recalcColor()
        Dim tmpColor = New Color
        tmpColor = Color.FromArgb(ColorR.Text, ColorG.Text, ColorB.Text)
        PBColor.BackColor = tmpColor
    End Sub

    Private Sub ColorR_TextChanged(sender As Object, e As EventArgs) Handles ColorR.TextChanged
        If ColorR.Text <> "" And ColorG.Text <> "" And ColorB.Text <> "" Then
            recalcColor()
            RaiseEvent Changed(sender, EventArgs.Empty)
        End If
    End Sub

    Private Sub ColorG_TextChanged(sender As Object, e As EventArgs) Handles ColorG.TextChanged
        If ColorR.Text <> "" And ColorG.Text <> "" And ColorB.Text <> "" Then
            recalcColor()
            RaiseEvent Changed(sender, EventArgs.Empty)
        End If
    End Sub

    Private Sub ColorB_TextChanged(sender As Object, e As EventArgs) Handles ColorB.TextChanged
        If ColorR.Text <> "" And ColorG.Text <> "" And ColorB.Text <> "" Then
            recalcColor()
            RaiseEvent Changed(sender, EventArgs.Empty)
        End If
    End Sub

    Public Event Changed As EventHandler
End Class
