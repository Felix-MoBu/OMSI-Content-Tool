<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class PointSelector
    Inherits System.Windows.Forms.UserControl

    'UserControl überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.CBBPoint = New System.Windows.Forms.HScrollBar()
        Me.TBZ = New System.Windows.Forms.TextBox()
        Me.TBY = New System.Windows.Forms.TextBox()
        Me.TBX = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'CBBPoint
        '
        Me.CBBPoint.Location = New System.Drawing.Point(135, 0)
        Me.CBBPoint.Name = "CBBPoint"
        Me.CBBPoint.Size = New System.Drawing.Size(26, 20)
        Me.CBBPoint.TabIndex = 38
        Me.CBBPoint.Value = 50
        '
        'TBZ
        '
        Me.TBZ.Location = New System.Drawing.Point(92, 0)
        Me.TBZ.Name = "TBZ"
        Me.TBZ.Size = New System.Drawing.Size(40, 20)
        Me.TBZ.TabIndex = 37
        Me.TBZ.Text = "0"
        '
        'TBY
        '
        Me.TBY.Location = New System.Drawing.Point(46, 0)
        Me.TBY.Name = "TBY"
        Me.TBY.Size = New System.Drawing.Size(40, 20)
        Me.TBY.TabIndex = 36
        Me.TBY.Text = "0"
        '
        'TBX
        '
        Me.TBX.Location = New System.Drawing.Point(0, 0)
        Me.TBX.Name = "TBX"
        Me.TBX.Size = New System.Drawing.Size(40, 20)
        Me.TBX.TabIndex = 35
        Me.TBX.Text = "0"
        '
        'PointSelector
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.CBBPoint)
        Me.Controls.Add(Me.TBZ)
        Me.Controls.Add(Me.TBY)
        Me.Controls.Add(Me.TBX)
        Me.Name = "PointSelector"
        Me.Size = New System.Drawing.Size(161, 20)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents CBBPoint As HScrollBar
    Private WithEvents TBZ As TextBox
    Private WithEvents TBY As TextBox
    Private WithEvents TBX As TextBox
End Class
