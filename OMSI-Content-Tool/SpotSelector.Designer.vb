<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SpotSelector
    Inherits System.Windows.Forms.UserControl

    'UserControl überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim RgbColor1 As O3D_Test.RGBColor = New O3D_Test.RGBColor()
        Dim Point3D1 As O3D_Test.Point3D = New O3D_Test.Point3D()
        Me.GBSpot = New System.Windows.Forms.GroupBox()
        Me.CSFarbe = New O3D_Test.ColorSelector()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BTMinMax = New System.Windows.Forms.Button()
        Me.Label82 = New System.Windows.Forms.Label()
        Me.Label81 = New System.Windows.Forms.Label()
        Me.TBAussen = New System.Windows.Forms.TextBox()
        Me.TBInner = New System.Windows.Forms.TextBox()
        Me.Label80 = New System.Windows.Forms.Label()
        Me.PSRichtung = New O3D_Test.PointSelector()
        Me.TBLeuchtweite = New System.Windows.Forms.TextBox()
        Me.Label79 = New System.Windows.Forms.Label()
        Me.GBSpot.SuspendLayout()
        Me.SuspendLayout()
        '
        'GBSpot
        '
        Me.GBSpot.Controls.Add(Me.CSFarbe)
        Me.GBSpot.Controls.Add(Me.Label1)
        Me.GBSpot.Controls.Add(Me.BTMinMax)
        Me.GBSpot.Controls.Add(Me.Label82)
        Me.GBSpot.Controls.Add(Me.Label81)
        Me.GBSpot.Controls.Add(Me.TBAussen)
        Me.GBSpot.Controls.Add(Me.TBInner)
        Me.GBSpot.Controls.Add(Me.Label80)
        Me.GBSpot.Controls.Add(Me.PSRichtung)
        Me.GBSpot.Controls.Add(Me.TBLeuchtweite)
        Me.GBSpot.Controls.Add(Me.Label79)
        Me.GBSpot.Location = New System.Drawing.Point(0, 0)
        Me.GBSpot.Name = "GBSpot"
        Me.GBSpot.Size = New System.Drawing.Size(328, 129)
        Me.GBSpot.TabIndex = 37
        Me.GBSpot.TabStop = False
        Me.GBSpot.Text = "Spot"
        '
        'CSFarbe
        '
        Me.CSFarbe.BackColor = System.Drawing.Color.Transparent
        Me.CSFarbe.Location = New System.Drawing.Point(70, 45)
        Me.CSFarbe.Name = "CSFarbe"
        RgbColor1.SelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.CSFarbe.SelectedColor = RgbColor1
        Me.CSFarbe.Size = New System.Drawing.Size(254, 24)
        Me.CSFarbe.TabIndex = 39
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 13)
        Me.Label1.TabIndex = 38
        Me.Label1.Text = "Farbe"
        '
        'BTMinMax
        '
        Me.BTMinMax.Location = New System.Drawing.Point(303, 0)
        Me.BTMinMax.Name = "BTMinMax"
        Me.BTMinMax.Size = New System.Drawing.Size(26, 19)
        Me.BTMinMax.TabIndex = 36
        Me.BTMinMax.Text = "-"
        Me.BTMinMax.UseVisualStyleBackColor = True
        '
        'Label82
        '
        Me.Label82.AutoSize = True
        Me.Label82.Location = New System.Drawing.Point(175, 78)
        Me.Label82.Name = "Label82"
        Me.Label82.Size = New System.Drawing.Size(38, 13)
        Me.Label82.TabIndex = 8
        Me.Label82.Text = "Außen"
        '
        'Label81
        '
        Me.Label81.AutoSize = True
        Me.Label81.Location = New System.Drawing.Point(4, 78)
        Me.Label81.Name = "Label81"
        Me.Label81.Size = New System.Drawing.Size(34, 13)
        Me.Label81.TabIndex = 7
        Me.Label81.Text = "Innen"
        '
        'TBAussen
        '
        Me.TBAussen.Location = New System.Drawing.Point(224, 75)
        Me.TBAussen.Name = "TBAussen"
        Me.TBAussen.Size = New System.Drawing.Size(100, 20)
        Me.TBAussen.TabIndex = 6
        Me.TBAussen.Text = "0"
        '
        'TBInner
        '
        Me.TBInner.Location = New System.Drawing.Point(69, 75)
        Me.TBInner.Name = "TBInner"
        Me.TBInner.Size = New System.Drawing.Size(100, 20)
        Me.TBInner.TabIndex = 5
        Me.TBInner.Text = "0"
        '
        'Label80
        '
        Me.Label80.AutoSize = True
        Me.Label80.Location = New System.Drawing.Point(3, 23)
        Me.Label80.Name = "Label80"
        Me.Label80.Size = New System.Drawing.Size(50, 13)
        Me.Label80.TabIndex = 4
        Me.Label80.Text = "Richtung"
        '
        'PSRichtung
        '
        Me.PSRichtung.BackColor = System.Drawing.Color.Transparent
        Me.PSRichtung.Location = New System.Drawing.Point(70, 19)
        Me.PSRichtung.Max = 1.7976931348623157E+308R
        Me.PSRichtung.Min = -1.7976931348623157E+308R
        Me.PSRichtung.Name = "PSRichtung"
        Me.PSRichtung.Point = Point3D1
        Me.PSRichtung.Size = New System.Drawing.Size(254, 20)
        Me.PSRichtung.TabIndex = 3
        Me.PSRichtung.X = 0R
        Me.PSRichtung.Y = 0R
        Me.PSRichtung.Z = 0R
        '
        'TBLeuchtweite
        '
        Me.TBLeuchtweite.Location = New System.Drawing.Point(69, 101)
        Me.TBLeuchtweite.Name = "TBLeuchtweite"
        Me.TBLeuchtweite.Size = New System.Drawing.Size(100, 20)
        Me.TBLeuchtweite.TabIndex = 2
        Me.TBLeuchtweite.Text = "0"
        '
        'Label79
        '
        Me.Label79.AutoSize = True
        Me.Label79.Location = New System.Drawing.Point(4, 104)
        Me.Label79.Name = "Label79"
        Me.Label79.Size = New System.Drawing.Size(65, 13)
        Me.Label79.TabIndex = 1
        Me.Label79.Text = "Leuchtweite"
        '
        'SpotSelector
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GBSpot)
        Me.Name = "SpotSelector"
        Me.Size = New System.Drawing.Size(332, 133)
        Me.GBSpot.ResumeLayout(False)
        Me.GBSpot.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GBSpot As GroupBox
    Friend WithEvents Label82 As Label
    Friend WithEvents Label81 As Label
    Friend WithEvents TBAussen As TextBox
    Friend WithEvents TBInner As TextBox
    Friend WithEvents Label80 As Label
    Friend WithEvents PSRichtung As PointSelector
    Friend WithEvents TBLeuchtweite As TextBox
    Friend WithEvents Label79 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents CSFarbe As ColorSelector
    Public WithEvents BTMinMax As Button
End Class
