<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_ToDo
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
        Me.GBOffen = New System.Windows.Forms.GroupBox()
        Me.GBFertig = New System.Windows.Forms.GroupBox()
        Me.BTClose = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'GBOffen
        '
        Me.GBOffen.Location = New System.Drawing.Point(12, 12)
        Me.GBOffen.Name = "GBOffen"
        Me.GBOffen.Size = New System.Drawing.Size(250, 552)
        Me.GBOffen.TabIndex = 0
        Me.GBOffen.TabStop = False
        Me.GBOffen.Text = "Offen"
        '
        'GBFertig
        '
        Me.GBFertig.Location = New System.Drawing.Point(268, 12)
        Me.GBFertig.Name = "GBFertig"
        Me.GBFertig.Size = New System.Drawing.Size(250, 552)
        Me.GBFertig.TabIndex = 1
        Me.GBFertig.TabStop = False
        Me.GBFertig.Text = "Fertig"
        '
        'BTClose
        '
        Me.BTClose.Location = New System.Drawing.Point(443, 570)
        Me.BTClose.Name = "BTClose"
        Me.BTClose.Size = New System.Drawing.Size(75, 23)
        Me.BTClose.TabIndex = 2
        Me.BTClose.Text = "Schließen"
        Me.BTClose.UseVisualStyleBackColor = True
        '
        'Frm_ToDo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(525, 597)
        Me.Controls.Add(Me.BTClose)
        Me.Controls.Add(Me.GBFertig)
        Me.Controls.Add(Me.GBOffen)
        Me.Name = "Frm_ToDo"
        Me.Text = "ToDo-Liste"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GBOffen As GroupBox
    Friend WithEvents GBFertig As GroupBox
    Friend WithEvents BTClose As Button
End Class
