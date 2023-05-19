<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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
        Me.BTTauschen = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.LBMeshes = New System.Windows.Forms.ListBox()
        Me.LBSelected = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.DateiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BTTauschen
        '
        Me.BTTauschen.Location = New System.Drawing.Point(41, 34)
        Me.BTTauschen.Name = "BTTauschen"
        Me.BTTauschen.Size = New System.Drawing.Size(75, 23)
        Me.BTTauschen.TabIndex = 0
        Me.BTTauschen.Text = "Tauschen"
        Me.BTTauschen.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(41, 63)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBox1.Size = New System.Drawing.Size(420, 475)
        Me.TextBox1.TabIndex = 1
        '
        'LBMeshes
        '
        Me.LBMeshes.FormattingEnabled = True
        Me.LBMeshes.Items.AddRange(New Object() {"100", "101", "102", "103", "104", "105", "106", "107", "108", "109", "110", "111", "112", "113", "114", "115", "116", "117", "118", "119", "120"})
        Me.LBMeshes.Location = New System.Drawing.Point(515, 63)
        Me.LBMeshes.Name = "LBMeshes"
        Me.LBMeshes.Size = New System.Drawing.Size(231, 212)
        Me.LBMeshes.TabIndex = 2
        '
        'LBSelected
        '
        Me.LBSelected.AutoSize = True
        Me.LBSelected.Location = New System.Drawing.Point(512, 292)
        Me.LBSelected.Name = "LBSelected"
        Me.LBSelected.Size = New System.Drawing.Size(39, 13)
        Me.LBSelected.TabIndex = 3
        Me.LBSelected.Text = "Label1"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DateiToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(803, 24)
        Me.MenuStrip1.TabIndex = 5
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'DateiToolStripMenuItem
        '
        Me.DateiToolStripMenuItem.Name = "DateiToolStripMenuItem"
        Me.DateiToolStripMenuItem.Size = New System.Drawing.Size(46, 20)
        Me.DateiToolStripMenuItem.Text = "Datei"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(803, 550)
        Me.Controls.Add(Me.LBSelected)
        Me.Controls.Add(Me.LBMeshes)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.BTTauschen)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BTTauschen As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents LBMeshes As ListBox
    Friend WithEvents LBSelected As Label
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents DateiToolStripMenuItem As ToolStripMenuItem
End Class
