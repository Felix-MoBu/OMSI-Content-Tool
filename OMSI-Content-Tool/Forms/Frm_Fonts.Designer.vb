<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Fonts
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Fonts))
        Me.PMain = New System.Windows.Forms.Panel()
        Me.CBUsedOnly = New System.Windows.Forms.CheckBox()
        Me.PKeine = New System.Windows.Forms.Panel()
        Me.PBKeine = New System.Windows.Forms.PictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TBSuche = New System.Windows.Forms.TextBox()
        Me.PMain.SuspendLayout()
        Me.PKeine.SuspendLayout()
        CType(Me.PBKeine, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PMain
        '
        Me.PMain.AutoScroll = True
        Me.PMain.Controls.Add(Me.CBUsedOnly)
        Me.PMain.Controls.Add(Me.PKeine)
        Me.PMain.Controls.Add(Me.Label1)
        Me.PMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PMain.Location = New System.Drawing.Point(0, 0)
        Me.PMain.Name = "PMain"
        Me.PMain.Size = New System.Drawing.Size(864, 561)
        Me.PMain.TabIndex = 0
        '
        'CBUsedOnly
        '
        Me.CBUsedOnly.AutoSize = True
        Me.CBUsedOnly.BackColor = System.Drawing.Color.Green
        Me.CBUsedOnly.Location = New System.Drawing.Point(673, 8)
        Me.CBUsedOnly.Name = "CBUsedOnly"
        Me.CBUsedOnly.Size = New System.Drawing.Size(166, 17)
        Me.CBUsedOnly.TabIndex = 3
        Me.CBUsedOnly.Text = "(Bereits im Projekt verwendet)"
        Me.CBUsedOnly.UseVisualStyleBackColor = False
        '
        'PKeine
        '
        Me.PKeine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PKeine.Controls.Add(Me.PBKeine)
        Me.PKeine.Controls.Add(Me.Label3)
        Me.PKeine.Location = New System.Drawing.Point(10, 32)
        Me.PKeine.Name = "PKeine"
        Me.PKeine.Size = New System.Drawing.Size(200, 120)
        Me.PKeine.TabIndex = 2
        '
        'PBKeine
        '
        Me.PBKeine.BackColor = System.Drawing.Color.White
        Me.PBKeine.Location = New System.Drawing.Point(-1, 0)
        Me.PBKeine.Name = "PBKeine"
        Me.PBKeine.Size = New System.Drawing.Size(200, 90)
        Me.PBKeine.TabIndex = 1
        Me.PBKeine.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(78, 95)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(34, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Keine"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(141, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Zur Auswahl doppelt klicken"
        '
        'TBSuche
        '
        Me.TBSuche.Location = New System.Drawing.Point(320, 6)
        Me.TBSuche.Name = "TBSuche"
        Me.TBSuche.Size = New System.Drawing.Size(200, 20)
        Me.TBSuche.TabIndex = 1
        '
        'Frm_Fonts
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(864, 561)
        Me.Controls.Add(Me.TBSuche)
        Me.Controls.Add(Me.PMain)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(880, 4096)
        Me.MinimumSize = New System.Drawing.Size(880, 300)
        Me.Name = "Frm_Fonts"
        Me.Text = "Fonts"
        Me.PMain.ResumeLayout(False)
        Me.PMain.PerformLayout()
        Me.PKeine.ResumeLayout(False)
        Me.PKeine.PerformLayout()
        CType(Me.PBKeine, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PMain As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents PKeine As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents PBKeine As PictureBox
    Friend WithEvents TBSuche As TextBox
    Friend WithEvents CBUsedOnly As CheckBox
End Class
