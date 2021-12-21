<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ColorSelector
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
        Me.CBBColor = New System.Windows.Forms.HScrollBar()
        Me.ColorB = New System.Windows.Forms.TextBox()
        Me.ColorG = New System.Windows.Forms.TextBox()
        Me.ColorR = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.PBColor = New System.Windows.Forms.PictureBox()
        Me.CD1 = New System.Windows.Forms.ColorDialog()
        CType(Me.PBColor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CBBColor
        '
        Me.CBBColor.Location = New System.Drawing.Point(238, 2)
        Me.CBBColor.Name = "CBBColor"
        Me.CBBColor.Size = New System.Drawing.Size(26, 21)
        Me.CBBColor.TabIndex = 33
        Me.CBBColor.Value = 50
        '
        'ColorB
        '
        Me.ColorB.Location = New System.Drawing.Point(197, 2)
        Me.ColorB.Name = "ColorB"
        Me.ColorB.Size = New System.Drawing.Size(40, 20)
        Me.ColorB.TabIndex = 32
        Me.ColorB.Text = "0"
        '
        'ColorG
        '
        Me.ColorG.Location = New System.Drawing.Point(151, 2)
        Me.ColorG.Name = "ColorG"
        Me.ColorG.Size = New System.Drawing.Size(40, 20)
        Me.ColorG.TabIndex = 31
        Me.ColorG.Text = "0"
        '
        'ColorR
        '
        Me.ColorR.Location = New System.Drawing.Point(105, 2)
        Me.ColorR.Name = "ColorR"
        Me.ColorR.Size = New System.Drawing.Size(40, 20)
        Me.ColorR.TabIndex = 30
        Me.ColorR.Text = "0"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(0, 6)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(34, 13)
        Me.Label8.TabIndex = 29
        Me.Label8.Text = "Farbe"
        '
        'PBColor
        '
        Me.PBColor.BackColor = System.Drawing.Color.White
        Me.PBColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PBColor.Location = New System.Drawing.Point(59, 2)
        Me.PBColor.Name = "PBColor"
        Me.PBColor.Size = New System.Drawing.Size(40, 20)
        Me.PBColor.TabIndex = 34
        Me.PBColor.TabStop = False
        '
        'ColorSelector
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.PBColor)
        Me.Controls.Add(Me.CBBColor)
        Me.Controls.Add(Me.ColorB)
        Me.Controls.Add(Me.ColorG)
        Me.Controls.Add(Me.ColorR)
        Me.Controls.Add(Me.Label8)
        Me.Name = "ColorSelector"
        Me.Size = New System.Drawing.Size(281, 24)
        CType(Me.PBColor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents CBBColor As HScrollBar
    Friend WithEvents ColorB As TextBox
    Friend WithEvents ColorG As TextBox
    Friend WithEvents ColorR As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents PBColor As PictureBox
    Friend WithEvents CD1 As ColorDialog
End Class
