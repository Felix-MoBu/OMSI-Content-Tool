<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Export
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Export))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BTDatei = New System.Windows.Forms.Button()
        Me.BTEig = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(137, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Was soll exportiert werden?"
        '
        'BTDatei
        '
        Me.BTDatei.Location = New System.Drawing.Point(12, 63)
        Me.BTDatei.Name = "BTDatei"
        Me.BTDatei.Size = New System.Drawing.Size(105, 23)
        Me.BTDatei.TabIndex = 1
        Me.BTDatei.Text = "Mesh-Datei"
        Me.BTDatei.UseVisualStyleBackColor = True
        '
        'BTEig
        '
        Me.BTEig.Location = New System.Drawing.Point(123, 63)
        Me.BTEig.Name = "BTEig"
        Me.BTEig.Size = New System.Drawing.Size(105, 23)
        Me.BTEig.TabIndex = 2
        Me.BTEig.Text = "Mesh-Eigenschaften"
        Me.BTEig.UseVisualStyleBackColor = True
        '
        'Frm_Export
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(243, 98)
        Me.Controls.Add(Me.BTEig)
        Me.Controls.Add(Me.BTDatei)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Export"
        Me.Text = "Export"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents BTDatei As Button
    Friend WithEvents BTEig As Button
End Class
