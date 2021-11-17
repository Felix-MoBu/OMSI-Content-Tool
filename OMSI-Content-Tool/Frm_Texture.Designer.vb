<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm_Texture
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Texture))
        Me.PBMain = New System.Windows.Forms.PictureBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.AndereToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AnsichtToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WireframeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ZentrierenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BearbeitenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LBTexturen = New System.Windows.Forms.ListBox()
        Me.PMain = New System.Windows.Forms.Panel()
        CType(Me.PBMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.PMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'PBMain
        '
        Me.PBMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PBMain.Location = New System.Drawing.Point(0, 0)
        Me.PBMain.Name = "PBMain"
        Me.PBMain.Padding = New System.Windows.Forms.Padding(200, 0, 0, 0)
        Me.PBMain.Size = New System.Drawing.Size(205, 258)
        Me.PBMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PBMain.TabIndex = 0
        Me.PBMain.TabStop = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AndereToolStripMenuItem, Me.AnsichtToolStripMenuItem, Me.BearbeitenToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(840, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'AndereToolStripMenuItem
        '
        Me.AndereToolStripMenuItem.Name = "AndereToolStripMenuItem"
        Me.AndereToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.AndereToolStripMenuItem.Text = "Andere"
        '
        'AnsichtToolStripMenuItem
        '
        Me.AnsichtToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.WireframeToolStripMenuItem, Me.ToolStripMenuItem1, Me.ZentrierenToolStripMenuItem})
        Me.AnsichtToolStripMenuItem.Name = "AnsichtToolStripMenuItem"
        Me.AnsichtToolStripMenuItem.Size = New System.Drawing.Size(59, 20)
        Me.AnsichtToolStripMenuItem.Text = "Ansicht"
        '
        'WireframeToolStripMenuItem
        '
        Me.WireframeToolStripMenuItem.Checked = True
        Me.WireframeToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.WireframeToolStripMenuItem.Name = "WireframeToolStripMenuItem"
        Me.WireframeToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.W), System.Windows.Forms.Keys)
        Me.WireframeToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
        Me.WireframeToolStripMenuItem.Text = "Wireframe"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(173, 6)
        '
        'ZentrierenToolStripMenuItem
        '
        Me.ZentrierenToolStripMenuItem.Name = "ZentrierenToolStripMenuItem"
        Me.ZentrierenToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.B), System.Windows.Forms.Keys)
        Me.ZentrierenToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
        Me.ZentrierenToolStripMenuItem.Text = "Zentrieren"
        '
        'BearbeitenToolStripMenuItem
        '
        Me.BearbeitenToolStripMenuItem.Name = "BearbeitenToolStripMenuItem"
        Me.BearbeitenToolStripMenuItem.Size = New System.Drawing.Size(75, 20)
        Me.BearbeitenToolStripMenuItem.Text = "Bearbeiten"
        '
        'LBTexturen
        '
        Me.LBTexturen.Dock = System.Windows.Forms.DockStyle.Left
        Me.LBTexturen.FormattingEnabled = True
        Me.LBTexturen.Location = New System.Drawing.Point(0, 24)
        Me.LBTexturen.Name = "LBTexturen"
        Me.LBTexturen.Size = New System.Drawing.Size(266, 570)
        Me.LBTexturen.TabIndex = 2
        Me.LBTexturen.Visible = False
        '
        'PMain
        '
        Me.PMain.Controls.Add(Me.PBMain)
        Me.PMain.Location = New System.Drawing.Point(332, 97)
        Me.PMain.Name = "PMain"
        Me.PMain.Size = New System.Drawing.Size(205, 258)
        Me.PMain.TabIndex = 4
        '
        'Frm_Texture
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(840, 594)
        Me.Controls.Add(Me.LBTexturen)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.PMain)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Frm_Texture"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Texture"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PBMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.PMain.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PBMain As PictureBox
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents BearbeitenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LBTexturen As ListBox
    Friend WithEvents AndereToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AnsichtToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents WireframeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ZentrierenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PMain As Panel
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
End Class
