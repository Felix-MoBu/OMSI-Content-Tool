<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Eig_Mesh
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Eig_Mesh))
        Me.LBLabels = New System.Windows.Forms.ListBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.KopierenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LBProps = New System.Windows.Forms.ListBox()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'LBLabels
        '
        Me.LBLabels.ContextMenuStrip = Me.ContextMenuStrip1
        Me.LBLabels.FormattingEnabled = True
        Me.LBLabels.Location = New System.Drawing.Point(12, 12)
        Me.LBLabels.Name = "LBLabels"
        Me.LBLabels.Size = New System.Drawing.Size(147, 459)
        Me.LBLabels.TabIndex = 0
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.KopierenToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(193, 26)
        '
        'KopierenToolStripMenuItem
        '
        Me.KopierenToolStripMenuItem.Name = "KopierenToolStripMenuItem"
        Me.KopierenToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.KopierenToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.KopierenToolStripMenuItem.Text = "Wert kopieren"
        '
        'LBProps
        '
        Me.LBProps.ContextMenuStrip = Me.ContextMenuStrip1
        Me.LBProps.FormattingEnabled = True
        Me.LBProps.Location = New System.Drawing.Point(158, 12)
        Me.LBProps.Name = "LBProps"
        Me.LBProps.Size = New System.Drawing.Size(165, 459)
        Me.LBProps.TabIndex = 1
        '
        'Frm_Eig_Mesh
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(332, 479)
        Me.Controls.Add(Me.LBProps)
        Me.Controls.Add(Me.LBLabels)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Frm_Eig_Mesh"
        Me.Text = "Mesh Eigenschaften"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LBLabels As ListBox
    Friend WithEvents LBProps As ListBox
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents KopierenToolStripMenuItem As ToolStripMenuItem
End Class
