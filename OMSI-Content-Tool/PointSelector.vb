Option Strict On

Public Class PointSelector
    Dim intPoint As New Point3D
    Dim intMin As Double
    Dim intMax As Double

    Public Property Min As Double
        Get
            Return intMin
        End Get
        Set(value As Double)
            If Not value = Max Then
                intMin = value
            Else
                intMin = Double.MinValue
            End If
        End Set
    End Property

    Public Property Max As Double
        Get
            Return intMax
        End Get
        Set(value As Double)
            If Not value = Min Then
                intMax = value
            Else
                intMax = Double.MaxValue
            End If
        End Set
    End Property

    Public Property X As Double
        Get
            Return intPoint.X
        End Get
        Set(value As Double)
            TBX.Text = Convert.ToString(value)
        End Set
    End Property

    Public Property Y As Double
        Get
            Return intPoint.Y
        End Get
        Set(value As Double)
            TBY.Text = Convert.ToString(value)
        End Set
    End Property

    Public Property Z As Double
        Get
            Return intPoint.Z
        End Get
        Set(value As Double)
            TBZ.Text = Convert.ToString(value)
        End Set
    End Property

    Public Property Point As Point3D
        Get
            Return intPoint
        End Get
        Set(value As Point3D)
            If value Is Nothing Then
                Log.Add("Es wurde veruscht einen leeren Punkt anzuzeigen!", Log.TYPE_DEBUG)
                value = New Point3D
            End If
            TBX.Text = FormatNumber(value.X, 3)
            TBY.Text = FormatNumber(value.Y, 3)
            TBZ.Text = FormatNumber(value.Z, 3)

            intPoint.X = value.X
            intPoint.Y = value.Y
            intPoint.Z = value.Z
        End Set
    End Property

    Private Sub recalc()
        Dim tmpWidth As Integer = Convert.ToInt16((Width - 25) / 3 - 6)

        TBX.Left = 0
        TBX.Width = tmpWidth

        TBY.Left = tmpWidth + 6
        TBY.Width = tmpWidth

        TBZ.Left = (tmpWidth + 6) * 2
        TBZ.Width = tmpWidth

        CBBPoint.Left = (tmpWidth + 5) * 3
    End Sub

    Private Sub CBBPoint_Scroll(sender As Object, e As ScrollEventArgs) Handles CBBPoint.Scroll
        If e.OldValue > e.NewValue Then
            TBX.Text = Convert.ToString(Frm_Main.Clipboard3D.X)
            TBY.Text = Convert.ToString(Frm_Main.Clipboard3D.Y)
            TBZ.Text = Convert.ToString(Frm_Main.Clipboard3D.Z)
        Else
            Frm_Main.Clipboard3D = intPoint

            'Dim newEventarg As KeyPressEventArgs
            'newEventarg.KeyChar = ChrW(Keys.Enter)
            'RaiseEvent KeyPress(Me, newEventarg)
        End If
        e.NewValue = 50
    End Sub

    Private Sub PointSelector_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Height = 20
        recalc()
    End Sub

    Private Sub TBX_TextChanged(sender As Object, e As EventArgs) Handles TBX.TextChanged
        If IsNumeric(TBX.Text) Then
            If Convert.ToDouble(TBX.Text) > intMax Then
                TBX.Text = Convert.ToString(intMax)
                TBX.SelectionStart = TBX.Text.Length
            Else
                If Convert.ToDouble(TBX.Text) < intMin Then
                    TBX.Text = Convert.ToString(intMin)
                    TBX.SelectionStart = TBX.Text.Length
                End If
            End If
            intPoint.X = Convert.ToDouble(TBX.Text)
            RaiseEvent Changed(sender, e)
        End If
    End Sub

    Private Sub TBY_TextChanged(sender As Object, e As EventArgs) Handles TBY.TextChanged
        If IsNumeric(TBY.Text) Then
            If Convert.ToDouble(TBY.Text) > intMax Then
                TBY.Text = Convert.ToString(intMax)
                TBY.SelectionStart = TBY.Text.Length
            Else
                If Convert.ToDouble(TBY.Text) < intMin Then
                    TBY.Text = Convert.ToString(intMin)
                    TBY.SelectionStart = TBY.Text.Length
                End If
            End If
            intPoint.Y = Convert.ToDouble(TBY.Text)
            RaiseEvent Changed(sender, e)
        End If
    End Sub

    Private Sub TBZ_TextChanged(sender As Object, e As EventArgs) Handles TBZ.TextChanged
        If IsNumeric(TBZ.Text) Then
            If Convert.ToDouble(TBZ.Text) > intMax Then
                TBZ.Text = Convert.ToString(intMax)
                TBZ.SelectionStart = TBZ.Text.Length
            Else
                If Convert.ToDouble(TBZ.Text) < intMin Then
                    TBZ.Text = Convert.ToString(intMin)
                    TBZ.SelectionStart = TBZ.Text.Length
                End If
            End If
            intPoint.Z = Convert.ToDouble(TBZ.Text)

            RaiseEvent Changed(sender, e)
        End If
    End Sub

    Private Sub TBX_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TBX.KeyPress
        e.Handled = helper.NumbersOnly(e, TBX, True, intMax, intMin)
        RaiseEvent KeyPress(sender, e)
    End Sub

    Private Sub TBY_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TBY.KeyPress
        e.Handled = helper.NumbersOnly(e, TBY, True, intMax, intMin)
        RaiseEvent KeyPress(sender, e)
    End Sub

    Private Sub TBZ_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TBZ.KeyPress
        e.Handled = helper.NumbersOnly(e, TBZ, True, intMax, intMin)
        RaiseEvent KeyPress(sender, e)
    End Sub

    Private Sub PointSelector_Leave(sender As Object, e As EventArgs) Handles Me.Leave
        If TBX.Text = "" Then TBX.Text = "0"
        If TBY.Text = "" Then TBY.Text = "0"
        If TBZ.Text = "" Then TBZ.Text = "0"
    End Sub

    Protected Overrides Sub Finalize()

        MyBase.Finalize()
        CBBPoint.Enabled = True
    End Sub

    Public Event Changed As EventHandler
    Public Shadows Event KeyPress As EventHandler
End Class