<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Math
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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
        Dim Point3D1 As O3D_Test.Point3D = New O3D_Test.Point3D()
        Dim Point3D2 As O3D_Test.Point3D = New O3D_Test.Point3D()
        Dim Point3D3 As O3D_Test.Point3D = New O3D_Test.Point3D()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Math))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CBAchse = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PSWinkel = New O3D_Test.PointSelector()
        Me.BTDrehen = New System.Windows.Forms.Button()
        Me.TBWinkel = New System.Windows.Forms.TextBox()
        Me.BTAbstand = New System.Windows.Forms.Button()
        Me.TBAbstand = New System.Windows.Forms.TextBox()
        Me.PSB = New O3D_Test.PointSelector()
        Me.PSA = New O3D_Test.PointSelector()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Punkt A"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Punkt B"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.CBAchse)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.PSWinkel)
        Me.GroupBox1.Controls.Add(Me.BTDrehen)
        Me.GroupBox1.Controls.Add(Me.TBWinkel)
        Me.GroupBox1.Controls.Add(Me.BTAbstand)
        Me.GroupBox1.Controls.Add(Me.TBAbstand)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 64)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(212, 252)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Berechnung"
        '
        'CBAchse
        '
        Me.CBAchse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBAchse.FormattingEnabled = True
        Me.CBAchse.Items.AddRange(New Object() {"X", "Y", "Z"})
        Me.CBAchse.Location = New System.Drawing.Point(87, 82)
        Me.CBAchse.Name = "CBAchse"
        Me.CBAchse.Size = New System.Drawing.Size(119, 21)
        Me.CBAchse.TabIndex = 22
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 113)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(27, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Neu"
        '
        'PSWinkel
        '
        Me.PSWinkel.BackColor = System.Drawing.Color.Transparent
        Me.PSWinkel.Location = New System.Drawing.Point(45, 109)
        Me.PSWinkel.Max = 1.7976931348623157E+308R
        Me.PSWinkel.Min = -1.7976931348623157E+308R
        Me.PSWinkel.Name = "PSWinkel"
        Me.PSWinkel.Point = Point3D1
        Me.PSWinkel.Size = New System.Drawing.Size(161, 20)
        Me.PSWinkel.TabIndex = 5
        Me.PSWinkel.X = 0R
        Me.PSWinkel.Y = 0R
        Me.PSWinkel.Z = 0R
        '
        'BTDrehen
        '
        Me.BTDrehen.Location = New System.Drawing.Point(6, 54)
        Me.BTDrehen.Name = "BTDrehen"
        Me.BTDrehen.Size = New System.Drawing.Size(75, 23)
        Me.BTDrehen.TabIndex = 8
        Me.BTDrehen.Text = "Drehen"
        Me.BTDrehen.UseVisualStyleBackColor = True
        '
        'TBWinkel
        '
        Me.TBWinkel.Location = New System.Drawing.Point(87, 56)
        Me.TBWinkel.Name = "TBWinkel"
        Me.TBWinkel.Size = New System.Drawing.Size(119, 20)
        Me.TBWinkel.TabIndex = 7
        '
        'BTAbstand
        '
        Me.BTAbstand.Location = New System.Drawing.Point(6, 19)
        Me.BTAbstand.Name = "BTAbstand"
        Me.BTAbstand.Size = New System.Drawing.Size(75, 23)
        Me.BTAbstand.TabIndex = 5
        Me.BTAbstand.Text = "Abstand"
        Me.BTAbstand.UseVisualStyleBackColor = True
        '
        'TBAbstand
        '
        Me.TBAbstand.Location = New System.Drawing.Point(87, 21)
        Me.TBAbstand.Name = "TBAbstand"
        Me.TBAbstand.Size = New System.Drawing.Size(119, 20)
        Me.TBAbstand.TabIndex = 1
        '
        'PSB
        '
        Me.PSB.BackColor = System.Drawing.Color.Transparent
        Me.PSB.Location = New System.Drawing.Point(63, 38)
        Me.PSB.Max = 1.7976931348623157E+308R
        Me.PSB.Min = -1.7976931348623157E+308R
        Me.PSB.Name = "PSB"
        Me.PSB.Point = Point3D2
        Me.PSB.Size = New System.Drawing.Size(161, 20)
        Me.PSB.TabIndex = 2
        Me.PSB.X = 0R
        Me.PSB.Y = 0R
        Me.PSB.Z = 0R
        '
        'PSA
        '
        Me.PSA.BackColor = System.Drawing.Color.Transparent
        Me.PSA.Location = New System.Drawing.Point(63, 12)
        Me.PSA.Max = 1.7976931348623157E+308R
        Me.PSA.Min = -1.7976931348623157E+308R
        Me.PSA.Name = "PSA"
        Me.PSA.Point = Point3D3
        Me.PSA.Size = New System.Drawing.Size(161, 20)
        Me.PSA.TabIndex = 0
        Me.PSA.X = 0R
        Me.PSA.Y = 0R
        Me.PSA.Z = 0R
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 85)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 13)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "Achse"
        '
        'Frm_Math
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(239, 329)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PSB)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PSA)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimumSize = New System.Drawing.Size(255, 368)
        Me.Name = "Frm_Math"
        Me.Text = "Rechner"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PSA As PointSelector
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents PSB As PointSelector
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents BTAbstand As Button
    Friend WithEvents TBAbstand As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents PSWinkel As PointSelector
    Friend WithEvents BTDrehen As Button
    Friend WithEvents TBWinkel As TextBox
    Friend WithEvents CBAchse As ComboBox
    Friend WithEvents Label4 As Label
End Class
