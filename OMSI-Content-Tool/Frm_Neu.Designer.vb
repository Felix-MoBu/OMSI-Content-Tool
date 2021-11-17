<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Neu
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Neu))
        Me.LBName = New System.Windows.Forms.Label()
        Me.LBSpeicherort = New System.Windows.Forms.Label()
        Me.TBName = New System.Windows.Forms.TextBox()
        Me.TBSpeicherort = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.PBBus = New System.Windows.Forms.PictureBox()
        Me.PBOvh = New System.Windows.Forms.PictureBox()
        Me.PBSli = New System.Windows.Forms.PictureBox()
        Me.PBSco = New System.Windows.Forms.PictureBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TBAussehen = New System.Windows.Forms.TextBox()
        Me.LBAussehen = New System.Windows.Forms.Label()
        Me.LBTyp = New System.Windows.Forms.Label()
        Me.LBHersteller = New System.Windows.Forms.Label()
        Me.CBTyp = New System.Windows.Forms.ComboBox()
        Me.CBHersteller = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GBAblageort = New System.Windows.Forms.GroupBox()
        Me.BTDurchsuchen = New System.Windows.Forms.Button()
        Me.BTErstellen = New System.Windows.Forms.Button()
        Me.BTAbbrechen = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PBBus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PBOvh, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PBSli, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PBSco, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GBAblageort.SuspendLayout()
        Me.SuspendLayout()
        '
        'LBName
        '
        Me.LBName.AutoSize = True
        Me.LBName.Location = New System.Drawing.Point(12, 22)
        Me.LBName.Name = "LBName"
        Me.LBName.Size = New System.Drawing.Size(35, 13)
        Me.LBName.TabIndex = 0
        Me.LBName.Text = "Name"
        '
        'LBSpeicherort
        '
        Me.LBSpeicherort.AutoSize = True
        Me.LBSpeicherort.Location = New System.Drawing.Point(12, 48)
        Me.LBSpeicherort.Name = "LBSpeicherort"
        Me.LBSpeicherort.Size = New System.Drawing.Size(61, 13)
        Me.LBSpeicherort.TabIndex = 1
        Me.LBSpeicherort.Text = "Speicherort"
        '
        'TBName
        '
        Me.TBName.Location = New System.Drawing.Point(78, 19)
        Me.TBName.Name = "TBName"
        Me.TBName.Size = New System.Drawing.Size(366, 20)
        Me.TBName.TabIndex = 4
        '
        'TBSpeicherort
        '
        Me.TBSpeicherort.Location = New System.Drawing.Point(78, 45)
        Me.TBSpeicherort.Name = "TBSpeicherort"
        Me.TBSpeicherort.Size = New System.Drawing.Size(366, 20)
        Me.TBSpeicherort.TabIndex = 5
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.PBBus)
        Me.GroupBox1.Controls.Add(Me.PBOvh)
        Me.GroupBox1.Controls.Add(Me.PBSli)
        Me.GroupBox1.Controls.Add(Me.PBSco)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(545, 157)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "1. Projekttyp"
        '
        'PBBus
        '
        Me.PBBus.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PBBus.Image = Global.O3D_Test.My.Resources.Resources.Bus
        Me.PBBus.Location = New System.Drawing.Point(6, 19)
        Me.PBBus.Name = "PBBus"
        Me.PBBus.Size = New System.Drawing.Size(128, 128)
        Me.PBBus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PBBus.TabIndex = 2
        Me.PBBus.TabStop = False
        Me.PBBus.Tag = "1"
        '
        'PBOvh
        '
        Me.PBOvh.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PBOvh.Image = Global.O3D_Test.My.Resources.Resources.Ovh
        Me.PBOvh.Location = New System.Drawing.Point(140, 19)
        Me.PBOvh.Name = "PBOvh"
        Me.PBOvh.Size = New System.Drawing.Size(128, 128)
        Me.PBOvh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PBOvh.TabIndex = 3
        Me.PBOvh.TabStop = False
        Me.PBOvh.Tag = "2"
        '
        'PBSli
        '
        Me.PBSli.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PBSli.Image = Global.O3D_Test.My.Resources.Resources.sli
        Me.PBSli.Location = New System.Drawing.Point(408, 19)
        Me.PBSli.Name = "PBSli"
        Me.PBSli.Size = New System.Drawing.Size(128, 128)
        Me.PBSli.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PBSli.TabIndex = 7
        Me.PBSli.TabStop = False
        Me.PBSli.Tag = "4"
        '
        'PBSco
        '
        Me.PBSco.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PBSco.Image = Global.O3D_Test.My.Resources.Resources.Sco
        Me.PBSco.Location = New System.Drawing.Point(274, 19)
        Me.PBSco.Name = "PBSco"
        Me.PBSco.Size = New System.Drawing.Size(128, 128)
        Me.PBSco.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PBSco.TabIndex = 6
        Me.PBSco.TabStop = False
        Me.PBSco.Tag = "3"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TBAussehen)
        Me.GroupBox2.Controls.Add(Me.LBAussehen)
        Me.GroupBox2.Controls.Add(Me.LBTyp)
        Me.GroupBox2.Controls.Add(Me.LBHersteller)
        Me.GroupBox2.Controls.Add(Me.CBTyp)
        Me.GroupBox2.Controls.Add(Me.CBHersteller)
        Me.GroupBox2.Controls.Add(Me.Button1)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 175)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(545, 100)
        Me.GroupBox2.TabIndex = 10
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "2. OMSI Kategorie"
        '
        'TBAussehen
        '
        Me.TBAussehen.Location = New System.Drawing.Point(78, 73)
        Me.TBAussehen.Name = "TBAussehen"
        Me.TBAussehen.Size = New System.Drawing.Size(366, 20)
        Me.TBAussehen.TabIndex = 12
        Me.TBAussehen.Text = "Standard"
        '
        'LBAussehen
        '
        Me.LBAussehen.AutoSize = True
        Me.LBAussehen.Location = New System.Drawing.Point(12, 76)
        Me.LBAussehen.Name = "LBAussehen"
        Me.LBAussehen.Size = New System.Drawing.Size(54, 13)
        Me.LBAussehen.TabIndex = 11
        Me.LBAussehen.Text = "Aussehen"
        '
        'LBTyp
        '
        Me.LBTyp.AutoSize = True
        Me.LBTyp.Location = New System.Drawing.Point(12, 49)
        Me.LBTyp.Name = "LBTyp"
        Me.LBTyp.Size = New System.Drawing.Size(25, 13)
        Me.LBTyp.TabIndex = 10
        Me.LBTyp.Text = "Typ"
        '
        'LBHersteller
        '
        Me.LBHersteller.AutoSize = True
        Me.LBHersteller.Location = New System.Drawing.Point(12, 22)
        Me.LBHersteller.Name = "LBHersteller"
        Me.LBHersteller.Size = New System.Drawing.Size(51, 13)
        Me.LBHersteller.TabIndex = 9
        Me.LBHersteller.Text = "Hersteller"
        '
        'CBTyp
        '
        Me.CBTyp.FormattingEnabled = True
        Me.CBTyp.Location = New System.Drawing.Point(78, 46)
        Me.CBTyp.Name = "CBTyp"
        Me.CBTyp.Size = New System.Drawing.Size(366, 21)
        Me.CBTyp.Sorted = True
        Me.CBTyp.TabIndex = 8
        '
        'CBHersteller
        '
        Me.CBHersteller.FormattingEnabled = True
        Me.CBHersteller.Location = New System.Drawing.Point(78, 19)
        Me.CBHersteller.Name = "CBHersteller"
        Me.CBHersteller.Size = New System.Drawing.Size(366, 21)
        Me.CBHersteller.Sorted = True
        Me.CBHersteller.TabIndex = 7
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(450, 71)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(89, 23)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Testen"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'GBAblageort
        '
        Me.GBAblageort.Controls.Add(Me.BTDurchsuchen)
        Me.GBAblageort.Controls.Add(Me.LBName)
        Me.GBAblageort.Controls.Add(Me.LBSpeicherort)
        Me.GBAblageort.Controls.Add(Me.TBName)
        Me.GBAblageort.Controls.Add(Me.TBSpeicherort)
        Me.GBAblageort.Enabled = False
        Me.GBAblageort.Location = New System.Drawing.Point(12, 281)
        Me.GBAblageort.Name = "GBAblageort"
        Me.GBAblageort.Size = New System.Drawing.Size(545, 75)
        Me.GBAblageort.TabIndex = 11
        Me.GBAblageort.TabStop = False
        Me.GBAblageort.Text = "3. Ablageort"
        '
        'BTDurchsuchen
        '
        Me.BTDurchsuchen.Location = New System.Drawing.Point(450, 43)
        Me.BTDurchsuchen.Name = "BTDurchsuchen"
        Me.BTDurchsuchen.Size = New System.Drawing.Size(89, 23)
        Me.BTDurchsuchen.TabIndex = 7
        Me.BTDurchsuchen.Text = "Durchsuchen"
        Me.BTDurchsuchen.UseVisualStyleBackColor = True
        '
        'BTErstellen
        '
        Me.BTErstellen.Enabled = False
        Me.BTErstellen.Location = New System.Drawing.Point(482, 362)
        Me.BTErstellen.Name = "BTErstellen"
        Me.BTErstellen.Size = New System.Drawing.Size(75, 23)
        Me.BTErstellen.TabIndex = 0
        Me.BTErstellen.Text = "Erstellen"
        Me.BTErstellen.UseVisualStyleBackColor = True
        '
        'BTAbbrechen
        '
        Me.BTAbbrechen.Location = New System.Drawing.Point(401, 362)
        Me.BTAbbrechen.Name = "BTAbbrechen"
        Me.BTAbbrechen.Size = New System.Drawing.Size(75, 23)
        Me.BTAbbrechen.TabIndex = 13
        Me.BTAbbrechen.Text = "Abbrechen"
        Me.BTAbbrechen.UseVisualStyleBackColor = True
        '
        'Frm_Neu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(569, 395)
        Me.Controls.Add(Me.BTAbbrechen)
        Me.Controls.Add(Me.BTErstellen)
        Me.Controls.Add(Me.GBAblageort)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(585, 434)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(585, 434)
        Me.Name = "Frm_Neu"
        Me.ShowInTaskbar = False
        Me.Text = "Neues Projekt"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.PBBus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PBOvh, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PBSli, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PBSco, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GBAblageort.ResumeLayout(False)
        Me.GBAblageort.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LBName As Label
    Friend WithEvents LBSpeicherort As Label
    Friend WithEvents PBBus As PictureBox
    Friend WithEvents PBOvh As PictureBox
    Friend WithEvents TBName As TextBox
    Friend WithEvents TBSpeicherort As TextBox
    Friend WithEvents PBSco As PictureBox
    Friend WithEvents PBSli As PictureBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GBAblageort As GroupBox
    Friend WithEvents Button1 As Button
    Friend WithEvents BTDurchsuchen As Button
    Friend WithEvents BTErstellen As Button
    Friend WithEvents BTAbbrechen As Button
    Friend WithEvents CBTyp As ComboBox
    Friend WithEvents CBHersteller As ComboBox
    Friend WithEvents TBAussehen As TextBox
    Friend WithEvents LBAussehen As Label
    Friend WithEvents LBTyp As Label
    Friend WithEvents LBHersteller As Label
End Class
