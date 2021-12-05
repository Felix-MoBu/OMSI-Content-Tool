<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Hof
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Hof))
        Me.LBHofdateien = New System.Windows.Forms.ListBox()
        Me.BTImport = New System.Windows.Forms.Button()
        Me.BTEntfernen = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'LBHofdateien
        '
        Me.LBHofdateien.FormattingEnabled = True
        Me.LBHofdateien.Location = New System.Drawing.Point(12, 12)
        Me.LBHofdateien.Name = "LBHofdateien"
        Me.LBHofdateien.Size = New System.Drawing.Size(230, 459)
        Me.LBHofdateien.TabIndex = 0
        '
        'BTImport
        '
        Me.BTImport.Location = New System.Drawing.Point(12, 477)
        Me.BTImport.Name = "BTImport"
        Me.BTImport.Size = New System.Drawing.Size(75, 23)
        Me.BTImport.TabIndex = 1
        Me.BTImport.Text = "Importieren"
        Me.BTImport.UseVisualStyleBackColor = True
        '
        'BTEntfernen
        '
        Me.BTEntfernen.Location = New System.Drawing.Point(167, 477)
        Me.BTEntfernen.Name = "BTEntfernen"
        Me.BTEntfernen.Size = New System.Drawing.Size(75, 23)
        Me.BTEntfernen.TabIndex = 2
        Me.BTEntfernen.Text = "Entfernen"
        Me.BTEntfernen.UseVisualStyleBackColor = True
        '
        'Frm_Hof
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(256, 512)
        Me.Controls.Add(Me.BTEntfernen)
        Me.Controls.Add(Me.BTImport)
        Me.Controls.Add(Me.LBHofdateien)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Hof"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "Hofdateien"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LBHofdateien As ListBox
    Friend WithEvents BTImport As Button
    Friend WithEvents BTEntfernen As Button
End Class
