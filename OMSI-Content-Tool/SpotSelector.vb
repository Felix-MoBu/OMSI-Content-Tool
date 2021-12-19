Public Class SpotSelector

    Public Event Changed As EventHandler
    Public Event MinMax As EventHandler

    Public Property spot As OMSI_Spot
        Get
            spot = New OMSI_Spot
            With spot
                .richtung = PSRichtung.Point
                .color = CSFarbe.SelectedColor
                .innerCone = TBInner.Text
                .outerCone = TBAussen.Text
                .range = TBLeuchtweite.Text
            End With
        End Get
        Set(value As OMSI_Spot)
            With value
                PSRichtung.Point = .richtung
                CSFarbe.SelectedColor = .color
                TBInner.Text = .innerCone
                TBAussen.Text = .outerCone
                TBLeuchtweite.Text = .range
            End With
        End Set
    End Property

    Public Overrides Property Text As String
        Get
            Text = GBSpot.Text
        End Get
        Set(value As String)
            GBSpot.Text = value
        End Set
    End Property

    Private Sub GBSpot_Resize(sender As Object, e As EventArgs) Handles GBSpot.Resize
        Height = GBSpot.Height
        Width = GBSpot.Width
    End Sub

    Private Sub TB_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TBInner.KeyPress, TBAussen.KeyPress, TBLeuchtweite.KeyPress
        e.Handled = helper.NumbersOnly(e, sender)
        RaiseEvent Changed(sender, EventArgs.Empty)
    End Sub

    Private Sub PSRichtung_Changed(sender As Object, e As EventArgs) Handles PSRichtung.KeyPress
        RaiseEvent Changed(sender, EventArgs.Empty)
    End Sub

    Private Sub CSFarbe_Changed(sender As Object, e As EventArgs) Handles CSFarbe.Changed
        RaiseEvent Changed(sender, EventArgs.Empty)
    End Sub

    Private Sub BTMinMax_Click(sender As Object, e As EventArgs) Handles BTMinMax.Click
        RaiseEvent MinMax(Me, EventArgs.Empty)
    End Sub
End Class
