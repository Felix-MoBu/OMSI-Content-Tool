<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Einst
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Einst))
        Me.OBUebernehmen = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TBOmsiPfad = New System.Windows.Forms.TextBox()
        Me.BTPfadSuchen = New System.Windows.Forms.Button()
        Me.BTAbbrechen = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.GroupBox10 = New System.Windows.Forms.GroupBox()
        Me.CBGitInMenue = New System.Windows.Forms.CheckBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.TBNickname = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.TBCreatorID = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.BTEinstReset = New System.Windows.Forms.Button()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.CBautoO3d = New System.Windows.Forms.CheckBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.CBLogDebug = New System.Windows.Forms.CheckBox()
        Me.CBBackup = New System.Windows.Forms.CheckBox()
        Me.CBTimerAuto = New System.Windows.Forms.CheckBox()
        Me.CBTimerActive = New System.Windows.Forms.CheckBox()
        Me.TBSaveTimerInterval = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.BTRepToolSuchen = New System.Windows.Forms.Button()
        Me.TBRepTool = New System.Windows.Forms.TextBox()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.CBShowAllParts = New System.Windows.Forms.CheckBox()
        Me.CBTexAutoReload = New System.Windows.Forms.CheckBox()
        Me.GBPerformance = New System.Windows.Forms.GroupBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.TBMaxFPS = New System.Windows.Forms.TextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.TBColorFenster = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.BTResetTimeline = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.BTResetEig = New System.Windows.Forms.Button()
        Me.BTResetTex = New System.Windows.Forms.Button()
        Me.BTResetObj = New System.Windows.Forms.Button()
        Me.TBColor3D = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.TBColorSelectedObj = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TBColorAchsen = New System.Windows.Forms.TextBox()
        Me.TBColorPassengers = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TBColorDriver = New System.Windows.Forms.TextBox()
        Me.TBColorReflexCam = New System.Windows.Forms.TextBox()
        Me.TBColorPaxCam = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TBColorDriverCam = New System.Windows.Forms.TextBox()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.GroupBox9 = New System.Windows.Forms.GroupBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.TBX3dScale = New System.Windows.Forms.TextBox()
        Me.DDX3dUp = New System.Windows.Forms.ComboBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.DDXUp = New System.Windows.Forms.ComboBox()
        Me.TBXScale = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.CBO3dRemSpec = New System.Windows.Forms.CheckBox()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.BTAbmelden = New System.Windows.Forms.Button()
        Me.BTAnmelden = New System.Windows.Forms.Button()
        Me.TBPassword = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TBMail = New System.Windows.Forms.TextBox()
        Me.CDCamDriver = New System.Windows.Forms.ColorDialog()
        Me.CDCamPax = New System.Windows.Forms.ColorDialog()
        Me.CDCamReflex = New System.Windows.Forms.ColorDialog()
        Me.CDColor3D = New System.Windows.Forms.ColorDialog()
        Me.CDColorPassenger = New System.Windows.Forms.ColorDialog()
        Me.CDColorDriver = New System.Windows.Forms.ColorDialog()
        Me.CDColorAchsen = New System.Windows.Forms.ColorDialog()
        Me.CDColorFenster = New System.Windows.Forms.ColorDialog()
        Me.CBGitAutoCommit = New System.Windows.Forms.CheckBox()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox10.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.GBPerformance.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'OBUebernehmen
        '
        Me.OBUebernehmen.Location = New System.Drawing.Point(566, 352)
        Me.OBUebernehmen.Name = "OBUebernehmen"
        Me.OBUebernehmen.Size = New System.Drawing.Size(84, 23)
        Me.OBUebernehmen.TabIndex = 0
        Me.OBUebernehmen.Text = "Übernehmen"
        Me.OBUebernehmen.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "OMSI-Verzeichnis"
        '
        'TBOmsiPfad
        '
        Me.TBOmsiPfad.Location = New System.Drawing.Point(103, 9)
        Me.TBOmsiPfad.Name = "TBOmsiPfad"
        Me.TBOmsiPfad.Size = New System.Drawing.Size(445, 20)
        Me.TBOmsiPfad.TabIndex = 2
        '
        'BTPfadSuchen
        '
        Me.BTPfadSuchen.Location = New System.Drawing.Point(554, 7)
        Me.BTPfadSuchen.Name = "BTPfadSuchen"
        Me.BTPfadSuchen.Size = New System.Drawing.Size(84, 23)
        Me.BTPfadSuchen.TabIndex = 3
        Me.BTPfadSuchen.Text = "Durchsuchen"
        Me.BTPfadSuchen.UseVisualStyleBackColor = True
        '
        'BTAbbrechen
        '
        Me.BTAbbrechen.Location = New System.Drawing.Point(485, 352)
        Me.BTAbbrechen.Name = "BTAbbrechen"
        Me.BTAbbrechen.Size = New System.Drawing.Size(75, 23)
        Me.BTAbbrechen.TabIndex = 4
        Me.BTAbbrechen.Text = "Abbrechen"
        Me.BTAbbrechen.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage5)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(654, 350)
        Me.TabControl1.TabIndex = 5
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GroupBox10)
        Me.TabPage1.Controls.Add(Me.GroupBox6)
        Me.TabPage1.Controls.Add(Me.BTEinstReset)
        Me.TabPage1.Controls.Add(Me.GroupBox5)
        Me.TabPage1.Controls.Add(Me.GroupBox3)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(646, 324)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Allgemein"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'GroupBox10
        '
        Me.GroupBox10.Controls.Add(Me.CBGitAutoCommit)
        Me.GroupBox10.Controls.Add(Me.CBGitInMenue)
        Me.GroupBox10.Location = New System.Drawing.Point(214, 162)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Size = New System.Drawing.Size(199, 126)
        Me.GroupBox10.TabIndex = 9
        Me.GroupBox10.TabStop = False
        Me.GroupBox10.Text = "Git"
        '
        'CBGitInMenue
        '
        Me.CBGitInMenue.AutoSize = True
        Me.CBGitInMenue.Location = New System.Drawing.Point(6, 21)
        Me.CBGitInMenue.Name = "CBGitInMenue"
        Me.CBGitInMenue.Size = New System.Drawing.Size(152, 30)
        Me.CBGitInMenue.TabIndex = 0
        Me.CBGitInMenue.Text = "Git im Menüband anzeigen" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(wenn installiert)"
        Me.CBGitInMenue.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.TBNickname)
        Me.GroupBox6.Controls.Add(Me.Label20)
        Me.GroupBox6.Controls.Add(Me.TBCreatorID)
        Me.GroupBox6.Controls.Add(Me.Label15)
        Me.GroupBox6.Location = New System.Drawing.Point(8, 162)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(200, 126)
        Me.GroupBox6.TabIndex = 8
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Content-Management"
        '
        'TBNickname
        '
        Me.TBNickname.Location = New System.Drawing.Point(67, 45)
        Me.TBNickname.Name = "TBNickname"
        Me.TBNickname.Size = New System.Drawing.Size(124, 20)
        Me.TBNickname.TabIndex = 3
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(6, 48)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(55, 13)
        Me.Label20.TabIndex = 2
        Me.Label20.Text = "Nickname"
        '
        'TBCreatorID
        '
        Me.TBCreatorID.Location = New System.Drawing.Point(67, 19)
        Me.TBCreatorID.Name = "TBCreatorID"
        Me.TBCreatorID.Size = New System.Drawing.Size(124, 20)
        Me.TBCreatorID.TabIndex = 1
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(6, 22)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(55, 13)
        Me.Label15.TabIndex = 0
        Me.Label15.Text = "Creator-ID"
        '
        'BTEinstReset
        '
        Me.BTEinstReset.Location = New System.Drawing.Point(530, 6)
        Me.BTEinstReset.Name = "BTEinstReset"
        Me.BTEinstReset.Size = New System.Drawing.Size(110, 23)
        Me.BTEinstReset.TabIndex = 7
        Me.BTEinstReset.Text = "Einst. Zurücksetzen"
        Me.BTEinstReset.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.CBautoO3d)
        Me.GroupBox5.Location = New System.Drawing.Point(213, 6)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(200, 150)
        Me.GroupBox5.TabIndex = 4
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Import / Export"
        '
        'CBautoO3d
        '
        Me.CBautoO3d.AutoSize = True
        Me.CBautoO3d.Location = New System.Drawing.Point(6, 19)
        Me.CBautoO3d.Name = "CBautoO3d"
        Me.CBautoO3d.Size = New System.Drawing.Size(179, 17)
        Me.CBautoO3d.TabIndex = 0
        Me.CBautoO3d.Text = "O3D immer automatisch anlegen"
        Me.CBautoO3d.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.CBLogDebug)
        Me.GroupBox3.Controls.Add(Me.CBBackup)
        Me.GroupBox3.Controls.Add(Me.CBTimerAuto)
        Me.GroupBox3.Controls.Add(Me.CBTimerActive)
        Me.GroupBox3.Controls.Add(Me.TBSaveTimerInterval)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Location = New System.Drawing.Point(8, 6)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(199, 150)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Speichern"
        '
        'CBLogDebug
        '
        Me.CBLogDebug.AutoSize = True
        Me.CBLogDebug.Location = New System.Drawing.Point(11, 115)
        Me.CBLogDebug.Name = "CBLogDebug"
        Me.CBLogDebug.Size = New System.Drawing.Size(163, 17)
        Me.CBLogDebug.TabIndex = 6
        Me.CBLogDebug.Text = "Debug-Einträge in der Logfile"
        Me.CBLogDebug.UseVisualStyleBackColor = True
        '
        'CBBackup
        '
        Me.CBBackup.AutoSize = True
        Me.CBBackup.Location = New System.Drawing.Point(11, 92)
        Me.CBBackup.Name = "CBBackup"
        Me.CBBackup.Size = New System.Drawing.Size(144, 17)
        Me.CBBackup.TabIndex = 5
        Me.CBBackup.Text = "Backup-Dateien anlegen"
        Me.CBBackup.UseVisualStyleBackColor = True
        '
        'CBTimerAuto
        '
        Me.CBTimerAuto.AutoSize = True
        Me.CBTimerAuto.Location = New System.Drawing.Point(11, 42)
        Me.CBTimerAuto.Name = "CBTimerAuto"
        Me.CBTimerAuto.Size = New System.Drawing.Size(133, 17)
        Me.CBTimerAuto.TabIndex = 4
        Me.CBTimerAuto.Text = "Automatisch speichern"
        Me.CBTimerAuto.UseVisualStyleBackColor = True
        '
        'CBTimerActive
        '
        Me.CBTimerActive.AutoSize = True
        Me.CBTimerActive.Location = New System.Drawing.Point(11, 19)
        Me.CBTimerActive.Name = "CBTimerActive"
        Me.CBTimerActive.Size = New System.Drawing.Size(78, 17)
        Me.CBTimerActive.TabIndex = 3
        Me.CBTimerActive.Text = "Timer aktiv"
        Me.CBTimerActive.UseVisualStyleBackColor = True
        '
        'TBSaveTimerInterval
        '
        Me.TBSaveTimerInterval.Location = New System.Drawing.Point(121, 63)
        Me.TBSaveTimerInterval.Name = "TBSaveTimerInterval"
        Me.TBSaveTimerInterval.Size = New System.Drawing.Size(45, 20)
        Me.TBSaveTimerInterval.TabIndex = 1
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(168, 66)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(23, 13)
        Me.Label9.TabIndex = 2
        Me.Label9.Text = "min"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(8, 66)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(111, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Speichertimer-Intervall"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Label14)
        Me.TabPage2.Controls.Add(Me.BTRepToolSuchen)
        Me.TabPage2.Controls.Add(Me.TBRepTool)
        Me.TabPage2.Controls.Add(Me.Label1)
        Me.TabPage2.Controls.Add(Me.TBOmsiPfad)
        Me.TabPage2.Controls.Add(Me.BTPfadSuchen)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(646, 324)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "OMSI"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(6, 38)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(97, 13)
        Me.Label14.TabIndex = 6
        Me.Label14.Text = "Repaint-Toop-Pfad"
        '
        'BTRepToolSuchen
        '
        Me.BTRepToolSuchen.Location = New System.Drawing.Point(554, 36)
        Me.BTRepToolSuchen.Name = "BTRepToolSuchen"
        Me.BTRepToolSuchen.Size = New System.Drawing.Size(84, 23)
        Me.BTRepToolSuchen.TabIndex = 5
        Me.BTRepToolSuchen.Text = "Durchsuchen"
        Me.BTRepToolSuchen.UseVisualStyleBackColor = True
        '
        'TBRepTool
        '
        Me.TBRepTool.Location = New System.Drawing.Point(103, 35)
        Me.TBRepTool.Name = "TBRepTool"
        Me.TBRepTool.Size = New System.Drawing.Size(445, 20)
        Me.TBRepTool.TabIndex = 4
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.CBShowAllParts)
        Me.TabPage3.Controls.Add(Me.CBTexAutoReload)
        Me.TabPage3.Controls.Add(Me.GBPerformance)
        Me.TabPage3.Controls.Add(Me.GroupBox4)
        Me.TabPage3.Controls.Add(Me.TBColor3D)
        Me.TabPage3.Controls.Add(Me.Label5)
        Me.TabPage3.Controls.Add(Me.GroupBox1)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(646, 324)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Darstellung"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'CBShowAllParts
        '
        Me.CBShowAllParts.AutoSize = True
        Me.CBShowAllParts.Enabled = False
        Me.CBShowAllParts.Location = New System.Drawing.Point(449, 9)
        Me.CBShowAllParts.Name = "CBShowAllParts"
        Me.CBShowAllParts.Size = New System.Drawing.Size(195, 17)
        Me.CBShowAllParts.TabIndex = 10
        Me.CBShowAllParts.Text = "Angekuppelte Wagenteile anzeigen"
        Me.CBShowAllParts.UseVisualStyleBackColor = True
        '
        'CBTexAutoReload
        '
        Me.CBTexAutoReload.AutoSize = True
        Me.CBTexAutoReload.Location = New System.Drawing.Point(265, 8)
        Me.CBTexAutoReload.Name = "CBTexAutoReload"
        Me.CBTexAutoReload.Size = New System.Drawing.Size(178, 17)
        Me.CBTexAutoReload.TabIndex = 9
        Me.CBTexAutoReload.Text = "Texturen automatisch neu laden"
        Me.CBTexAutoReload.UseVisualStyleBackColor = True
        '
        'GBPerformance
        '
        Me.GBPerformance.Controls.Add(Me.Label21)
        Me.GBPerformance.Controls.Add(Me.TBMaxFPS)
        Me.GBPerformance.Location = New System.Drawing.Point(8, 251)
        Me.GBPerformance.Name = "GBPerformance"
        Me.GBPerformance.Size = New System.Drawing.Size(251, 56)
        Me.GBPerformance.TabIndex = 8
        Me.GBPerformance.TabStop = False
        Me.GBPerformance.Text = "Performance"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(9, 22)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(115, 13)
        Me.Label21.TabIndex = 0
        Me.Label21.Text = "maximale FPS (<1.000)"
        '
        'TBMaxFPS
        '
        Me.TBMaxFPS.Location = New System.Drawing.Point(139, 19)
        Me.TBMaxFPS.Name = "TBMaxFPS"
        Me.TBMaxFPS.Size = New System.Drawing.Size(100, 20)
        Me.TBMaxFPS.TabIndex = 0
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.TBColorFenster)
        Me.GroupBox4.Controls.Add(Me.Label23)
        Me.GroupBox4.Controls.Add(Me.BTResetTimeline)
        Me.GroupBox4.Controls.Add(Me.Label10)
        Me.GroupBox4.Controls.Add(Me.BTResetEig)
        Me.GroupBox4.Controls.Add(Me.BTResetTex)
        Me.GroupBox4.Controls.Add(Me.BTResetObj)
        Me.GroupBox4.Location = New System.Drawing.Point(8, 165)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(426, 80)
        Me.GroupBox4.TabIndex = 7
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Fenster"
        '
        'TBColorFenster
        '
        Me.TBColorFenster.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBColorFenster.Location = New System.Drawing.Point(332, 40)
        Me.TBColorFenster.Name = "TBColorFenster"
        Me.TBColorFenster.Size = New System.Drawing.Size(75, 20)
        Me.TBColorFenster.TabIndex = 11
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(329, 16)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(75, 13)
        Me.Label23.TabIndex = 5
        Me.Label23.Text = "Fenster Farbe:"
        '
        'BTResetTimeline
        '
        Me.BTResetTimeline.Location = New System.Drawing.Point(251, 40)
        Me.BTResetTimeline.Name = "BTResetTimeline"
        Me.BTResetTimeline.Size = New System.Drawing.Size(75, 23)
        Me.BTResetTimeline.TabIndex = 4
        Me.BTResetTimeline.Text = "Timeline"
        Me.BTResetTimeline.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(9, 16)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(113, 13)
        Me.Label10.TabIndex = 3
        Me.Label10.Text = "Fenster Zurücksetzen:"
        '
        'BTResetEig
        '
        Me.BTResetEig.Location = New System.Drawing.Point(170, 40)
        Me.BTResetEig.Name = "BTResetEig"
        Me.BTResetEig.Size = New System.Drawing.Size(75, 23)
        Me.BTResetEig.TabIndex = 2
        Me.BTResetEig.Text = "Eigenschaft"
        Me.BTResetEig.UseVisualStyleBackColor = True
        '
        'BTResetTex
        '
        Me.BTResetTex.Location = New System.Drawing.Point(90, 40)
        Me.BTResetTex.Name = "BTResetTex"
        Me.BTResetTex.Size = New System.Drawing.Size(75, 23)
        Me.BTResetTex.TabIndex = 1
        Me.BTResetTex.Text = "Texturen"
        Me.BTResetTex.UseVisualStyleBackColor = True
        '
        'BTResetObj
        '
        Me.BTResetObj.Location = New System.Drawing.Point(9, 40)
        Me.BTResetObj.Name = "BTResetObj"
        Me.BTResetObj.Size = New System.Drawing.Size(75, 23)
        Me.BTResetObj.TabIndex = 0
        Me.BTResetObj.Text = "Objekte"
        Me.BTResetObj.UseVisualStyleBackColor = True
        '
        'TBColor3D
        '
        Me.TBColor3D.Location = New System.Drawing.Point(147, 6)
        Me.TBColor3D.Name = "TBColor3D"
        Me.TBColor3D.Size = New System.Drawing.Size(100, 20)
        Me.TBColor3D.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(5, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(141, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Hintergrundfarbe 3D-Fenster"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label22)
        Me.GroupBox1.Controls.Add(Me.TBColorSelectedObj)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.TBColorAchsen)
        Me.GroupBox1.Controls.Add(Me.TBColorPassengers)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.TBColorDriver)
        Me.GroupBox1.Controls.Add(Me.TBColorReflexCam)
        Me.GroupBox1.Controls.Add(Me.TBColorPaxCam)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.TBColorDriverCam)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(8, 32)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(426, 127)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "3D-Objekte"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(6, 100)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(91, 13)
        Me.Label22.TabIndex = 12
        Me.Label22.Text = "Markierte Objekte"
        '
        'TBColorSelectedObj
        '
        Me.TBColorSelectedObj.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBColorSelectedObj.Location = New System.Drawing.Point(139, 97)
        Me.TBColorSelectedObj.Name = "TBColorSelectedObj"
        Me.TBColorSelectedObj.Size = New System.Drawing.Size(100, 20)
        Me.TBColorSelectedObj.TabIndex = 12
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(254, 74)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(43, 13)
        Me.Label13.TabIndex = 11
        Me.Label13.Text = "Achsen"
        '
        'TBColorAchsen
        '
        Me.TBColorAchsen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBColorAchsen.Location = New System.Drawing.Point(317, 71)
        Me.TBColorAchsen.Name = "TBColorAchsen"
        Me.TBColorAchsen.Size = New System.Drawing.Size(100, 20)
        Me.TBColorAchsen.TabIndex = 10
        '
        'TBColorPassengers
        '
        Me.TBColorPassengers.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBColorPassengers.Location = New System.Drawing.Point(317, 19)
        Me.TBColorPassengers.Name = "TBColorPassengers"
        Me.TBColorPassengers.Size = New System.Drawing.Size(100, 20)
        Me.TBColorPassengers.TabIndex = 9
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(254, 48)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(57, 13)
        Me.Label12.TabIndex = 8
        Me.Label12.Text = "Fahrerfigur"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(254, 22)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(54, 13)
        Me.Label11.TabIndex = 7
        Me.Label11.Text = "Fahrgäste"
        '
        'TBColorDriver
        '
        Me.TBColorDriver.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBColorDriver.Location = New System.Drawing.Point(317, 45)
        Me.TBColorDriver.Name = "TBColorDriver"
        Me.TBColorDriver.Size = New System.Drawing.Size(100, 20)
        Me.TBColorDriver.TabIndex = 6
        '
        'TBColorReflexCam
        '
        Me.TBColorReflexCam.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBColorReflexCam.Location = New System.Drawing.Point(139, 71)
        Me.TBColorReflexCam.Name = "TBColorReflexCam"
        Me.TBColorReflexCam.Size = New System.Drawing.Size(100, 20)
        Me.TBColorReflexCam.TabIndex = 5
        '
        'TBColorPaxCam
        '
        Me.TBColorPaxCam.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBColorPaxCam.Location = New System.Drawing.Point(139, 45)
        Me.TBColorPaxCam.Name = "TBColorPaxCam"
        Me.TBColorPaxCam.Size = New System.Drawing.Size(100, 20)
        Me.TBColorPaxCam.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, 74)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(87, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Kamera (Spiegel)"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(127, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Kamera (Fahrgastansicht)"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(116, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Kamera (Fahreransicht)"
        '
        'TBColorDriverCam
        '
        Me.TBColorDriverCam.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBColorDriverCam.Location = New System.Drawing.Point(139, 19)
        Me.TBColorDriverCam.Name = "TBColorDriverCam"
        Me.TBColorDriverCam.Size = New System.Drawing.Size(100, 20)
        Me.TBColorDriverCam.TabIndex = 0
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.GroupBox9)
        Me.TabPage5.Controls.Add(Me.GroupBox8)
        Me.TabPage5.Controls.Add(Me.GroupBox7)
        Me.TabPage5.Location = New System.Drawing.Point(4, 22)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage5.Size = New System.Drawing.Size(646, 324)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "3D-Formate"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'GroupBox9
        '
        Me.GroupBox9.Controls.Add(Me.Label18)
        Me.GroupBox9.Controls.Add(Me.TBX3dScale)
        Me.GroupBox9.Controls.Add(Me.DDX3dUp)
        Me.GroupBox9.Controls.Add(Me.Label19)
        Me.GroupBox9.Location = New System.Drawing.Point(400, 6)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(190, 315)
        Me.GroupBox9.TabIndex = 2
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Text = "X3D"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(6, 48)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(54, 13)
        Me.Label18.TabIndex = 6
        Me.Label18.Text = "Up-Achse"
        '
        'TBX3dScale
        '
        Me.TBX3dScale.Location = New System.Drawing.Point(84, 19)
        Me.TBX3dScale.Name = "TBX3dScale"
        Me.TBX3dScale.Size = New System.Drawing.Size(100, 20)
        Me.TBX3dScale.TabIndex = 5
        Me.TBX3dScale.Text = "1"
        '
        'DDX3dUp
        '
        Me.DDX3dUp.FormattingEnabled = True
        Me.DDX3dUp.Items.AddRange(New Object() {"X", "Y", "Z"})
        Me.DDX3dUp.Location = New System.Drawing.Point(84, 45)
        Me.DDX3dUp.Name = "DDX3dUp"
        Me.DDX3dUp.Size = New System.Drawing.Size(100, 21)
        Me.DDX3dUp.TabIndex = 4
        Me.DDX3dUp.Text = "Z"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(6, 22)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(57, 13)
        Me.Label19.TabIndex = 3
        Me.Label19.Text = "Skalierung"
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.Label17)
        Me.GroupBox8.Controls.Add(Me.DDXUp)
        Me.GroupBox8.Controls.Add(Me.TBXScale)
        Me.GroupBox8.Controls.Add(Me.Label16)
        Me.GroupBox8.Location = New System.Drawing.Point(204, 6)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(190, 315)
        Me.GroupBox8.TabIndex = 1
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "X"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(6, 48)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(54, 13)
        Me.Label17.TabIndex = 2
        Me.Label17.Text = "Up-Achse"
        '
        'DDXUp
        '
        Me.DDXUp.FormattingEnabled = True
        Me.DDXUp.Items.AddRange(New Object() {"X", "Y", "Z"})
        Me.DDXUp.Location = New System.Drawing.Point(84, 45)
        Me.DDXUp.Name = "DDXUp"
        Me.DDXUp.Size = New System.Drawing.Size(100, 21)
        Me.DDXUp.TabIndex = 1
        Me.DDXUp.Text = "Z"
        '
        'TBXScale
        '
        Me.TBXScale.Location = New System.Drawing.Point(84, 19)
        Me.TBXScale.Name = "TBXScale"
        Me.TBXScale.Size = New System.Drawing.Size(100, 20)
        Me.TBXScale.TabIndex = 1
        Me.TBXScale.Text = "1"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(6, 22)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(57, 13)
        Me.Label16.TabIndex = 0
        Me.Label16.Text = "Skalierung"
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.CBO3dRemSpec)
        Me.GroupBox7.Location = New System.Drawing.Point(8, 6)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(190, 315)
        Me.GroupBox7.TabIndex = 0
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "O3D"
        '
        'CBO3dRemSpec
        '
        Me.CBO3dRemSpec.AutoSize = True
        Me.CBO3dRemSpec.Location = New System.Drawing.Point(6, 21)
        Me.CBO3dRemSpec.Name = "CBO3dRemSpec"
        Me.CBO3dRemSpec.Size = New System.Drawing.Size(111, 17)
        Me.CBO3dRemSpec.TabIndex = 0
        Me.CBO3dRemSpec.Text = "Remove Specular"
        Me.CBO3dRemSpec.UseVisualStyleBackColor = True
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.GroupBox2)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(646, 324)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Online"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.BTAbmelden)
        Me.GroupBox2.Controls.Add(Me.BTAnmelden)
        Me.GroupBox2.Controls.Add(Me.TBPassword)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.TBMail)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 6)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(306, 105)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Anmelden"
        '
        'BTAbmelden
        '
        Me.BTAbmelden.Enabled = False
        Me.BTAbmelden.Location = New System.Drawing.Point(139, 71)
        Me.BTAbmelden.Name = "BTAbmelden"
        Me.BTAbmelden.Size = New System.Drawing.Size(75, 23)
        Me.BTAbmelden.TabIndex = 5
        Me.BTAbmelden.Text = "Abmelden"
        Me.BTAbmelden.UseVisualStyleBackColor = True
        '
        'BTAnmelden
        '
        Me.BTAnmelden.Enabled = False
        Me.BTAnmelden.Location = New System.Drawing.Point(220, 71)
        Me.BTAnmelden.Name = "BTAnmelden"
        Me.BTAnmelden.Size = New System.Drawing.Size(75, 23)
        Me.BTAnmelden.TabIndex = 4
        Me.BTAnmelden.Text = "Anmelden"
        Me.BTAnmelden.UseVisualStyleBackColor = True
        '
        'TBPassword
        '
        Me.TBPassword.Location = New System.Drawing.Point(65, 45)
        Me.TBPassword.Name = "TBPassword"
        Me.TBPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(8226)
        Me.TBPassword.Size = New System.Drawing.Size(230, 20)
        Me.TBPassword.TabIndex = 2
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(9, 48)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(50, 13)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "Passwort"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(9, 22)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(36, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "E-Mail"
        '
        'TBMail
        '
        Me.TBMail.Location = New System.Drawing.Point(65, 19)
        Me.TBMail.Name = "TBMail"
        Me.TBMail.Size = New System.Drawing.Size(230, 20)
        Me.TBMail.TabIndex = 1
        '
        'CDCamPax
        '
        Me.CDCamPax.Color = System.Drawing.Color.Green
        '
        'CDCamReflex
        '
        Me.CDCamReflex.Color = System.Drawing.Color.Blue
        '
        'CDColor3D
        '
        Me.CDColor3D.Color = System.Drawing.Color.White
        '
        'CBGitAutoCommit
        '
        Me.CBGitAutoCommit.AutoSize = True
        Me.CBGitAutoCommit.Location = New System.Drawing.Point(6, 47)
        Me.CBGitAutoCommit.Name = "CBGitAutoCommit"
        Me.CBGitAutoCommit.Size = New System.Drawing.Size(159, 17)
        Me.CBGitAutoCommit.TabIndex = 1
        Me.CBGitAutoCommit.Text = "Auto Commit beim speichern"
        Me.CBGitAutoCommit.UseVisualStyleBackColor = True
        '
        'Frm_Einst
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(654, 383)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.BTAbbrechen)
        Me.Controls.Add(Me.OBUebernehmen)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(670, 422)
        Me.MinimumSize = New System.Drawing.Size(670, 422)
        Me.Name = "Frm_Einst"
        Me.Text = "Einstellungen"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBox10.ResumeLayout(False)
        Me.GroupBox10.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.GBPerformance.ResumeLayout(False)
        Me.GBPerformance.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabPage5.ResumeLayout(False)
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox9.PerformLayout()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.TabPage4.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents OBUebernehmen As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents TBOmsiPfad As TextBox
    Friend WithEvents BTPfadSuchen As Button
    Friend WithEvents BTAbbrechen As Button
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents TBColorReflexCam As TextBox
    Friend WithEvents TBColorPaxCam As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TBColorDriverCam As TextBox
    Friend WithEvents CDCamDriver As ColorDialog
    Friend WithEvents CDCamPax As ColorDialog
    Friend WithEvents CDCamReflex As ColorDialog
    Friend WithEvents TBColor3D As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents CDColor3D As ColorDialog
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents Label7 As Label
    Friend WithEvents TBPassword As TextBox
    Friend WithEvents TBMail As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents BTAnmelden As Button
    Friend WithEvents BTAbmelden As Button
    Friend WithEvents Label9 As Label
    Friend WithEvents TBSaveTimerInterval As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents CBTimerActive As CheckBox
    Friend WithEvents CBTimerAuto As CheckBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents Label10 As Label
    Friend WithEvents BTResetEig As Button
    Friend WithEvents BTResetTex As Button
    Friend WithEvents BTResetObj As Button
    Friend WithEvents TBColorPassengers As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents TBColorDriver As TextBox
    Friend WithEvents CDColorPassenger As ColorDialog
    Friend WithEvents CDColorDriver As ColorDialog
    Friend WithEvents Label13 As Label
    Friend WithEvents TBColorAchsen As TextBox
    Friend WithEvents CDColorAchsen As ColorDialog
    Friend WithEvents CBBackup As CheckBox
    Friend WithEvents Label14 As Label
    Friend WithEvents BTRepToolSuchen As Button
    Friend WithEvents TBRepTool As TextBox
    Friend WithEvents CBLogDebug As CheckBox
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents CBautoO3d As CheckBox
    Friend WithEvents BTEinstReset As Button
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents TBCreatorID As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents TabPage5 As TabPage
    Friend WithEvents GroupBox9 As GroupBox
    Friend WithEvents GroupBox8 As GroupBox
    Friend WithEvents TBXScale As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents GroupBox7 As GroupBox
    Friend WithEvents CBO3dRemSpec As CheckBox
    Friend WithEvents Label18 As Label
    Friend WithEvents TBX3dScale As TextBox
    Friend WithEvents DDX3dUp As ComboBox
    Friend WithEvents Label19 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents DDXUp As ComboBox
    Friend WithEvents TBNickname As TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents GBPerformance As GroupBox
    Friend WithEvents Label21 As Label
    Friend WithEvents TBMaxFPS As TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents TBColorSelectedObj As TextBox
    Friend WithEvents CBTexAutoReload As CheckBox
    Friend WithEvents CBShowAllParts As CheckBox
    Friend WithEvents BTResetTimeline As Button
    Friend WithEvents TBColorFenster As TextBox
    Friend WithEvents Label23 As Label
    Friend WithEvents CDColorFenster As ColorDialog
    Friend WithEvents GroupBox10 As GroupBox
    Friend WithEvents CBGitInMenue As CheckBox
    Friend WithEvents CBGitAutoCommit As CheckBox
End Class
