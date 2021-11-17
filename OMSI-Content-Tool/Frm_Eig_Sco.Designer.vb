<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Eig_Sco
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Eig_Sco))
        Me.GBOrg = New System.Windows.Forms.GroupBox()
        Me.CBModel = New System.Windows.Forms.CheckBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TBModel = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.TBSound = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.BTSound = New System.Windows.Forms.Button()
        Me.BTPfad = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TBPath = New System.Windows.Forms.TextBox()
        Me.TBDateiname = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TBCabin = New System.Windows.Forms.TextBox()
        Me.BTSitze = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TBGruppen = New System.Windows.Forms.TextBox()
        Me.TBName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GBSichtbar = New System.Windows.Forms.GroupBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.CBRendertype = New System.Windows.Forms.ComboBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TBDetailfaktor = New System.Windows.Forms.TextBox()
        Me.CBonlyEditor = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CBComplexcity = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.CBNightMapMode = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TBCrashmodeKraft = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TBCrashmodeWinkel = New System.Windows.Forms.TextBox()
        Me.CBFixed = New System.Windows.Forms.CheckBox()
        Me.CBSurface = New System.Windows.Forms.CheckBox()
        Me.CBJoinable = New System.Windows.Forms.CheckBox()
        Me.CBNocollision = New System.Windows.Forms.CheckBox()
        Me.CBAbsHeight = New System.Windows.Forms.CheckBox()
        Me.CBLightmapMapping = New System.Windows.Forms.CheckBox()
        Me.CBShadow = New System.Windows.Forms.CheckBox()
        Me.GBBel = New System.Windows.Forms.GroupBox()
        Me.CBNormalBel = New System.Windows.Forms.CheckBox()
        Me.GBPhysik = New System.Windows.Forms.GroupBox()
        Me.CBTankstelle = New System.Windows.Forms.CheckBox()
        Me.CBBusstop = New System.Windows.Forms.CheckBox()
        Me.GBGeneric = New System.Windows.Forms.GroupBox()
        Me.CBHilfspfeil = New System.Windows.Forms.CheckBox()
        Me.CBEntrypoint = New System.Windows.Forms.CheckBox()
        Me.CBCarpark = New System.Windows.Forms.CheckBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.RBHilfsobj = New System.Windows.Forms.RadioButton()
        Me.RBStrael = New System.Windows.Forms.RadioButton()
        Me.RBGeb = New System.Windows.Forms.RadioButton()
        Me.BTOrdner = New System.Windows.Forms.Button()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.BTSchließen = New System.Windows.Forms.Button()
        Me.GBOrg.SuspendLayout()
        Me.GBSichtbar.SuspendLayout()
        Me.GBBel.SuspendLayout()
        Me.GBPhysik.SuspendLayout()
        Me.GBGeneric.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'GBOrg
        '
        Me.GBOrg.Controls.Add(Me.CBModel)
        Me.GBOrg.Controls.Add(Me.Button1)
        Me.GBOrg.Controls.Add(Me.TBModel)
        Me.GBOrg.Controls.Add(Me.Label27)
        Me.GBOrg.Controls.Add(Me.TBSound)
        Me.GBOrg.Controls.Add(Me.Label26)
        Me.GBOrg.Controls.Add(Me.BTSound)
        Me.GBOrg.Controls.Add(Me.BTPfad)
        Me.GBOrg.Controls.Add(Me.Label10)
        Me.GBOrg.Controls.Add(Me.TBPath)
        Me.GBOrg.Controls.Add(Me.TBDateiname)
        Me.GBOrg.Controls.Add(Me.Label14)
        Me.GBOrg.Controls.Add(Me.TBCabin)
        Me.GBOrg.Controls.Add(Me.BTSitze)
        Me.GBOrg.Controls.Add(Me.Label2)
        Me.GBOrg.Controls.Add(Me.TBGruppen)
        Me.GBOrg.Controls.Add(Me.TBName)
        Me.GBOrg.Controls.Add(Me.Label1)
        Me.GBOrg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GBOrg.Location = New System.Drawing.Point(12, 58)
        Me.GBOrg.Name = "GBOrg"
        Me.GBOrg.Size = New System.Drawing.Size(762, 158)
        Me.GBOrg.TabIndex = 0
        Me.GBOrg.TabStop = False
        Me.GBOrg.Text = "Organisatorisches"
        '
        'CBModel
        '
        Me.CBModel.AutoSize = True
        Me.CBModel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBModel.Location = New System.Drawing.Point(313, 48)
        Me.CBModel.Name = "CBModel"
        Me.CBModel.Size = New System.Drawing.Size(85, 17)
        Me.CBModel.TabIndex = 50
        Me.CBModel.Text = "Modell-Datei"
        Me.CBModel.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(678, 43)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 49
        Me.Button1.Text = "Auswählen"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TBModel
        '
        Me.TBModel.Enabled = False
        Me.TBModel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBModel.Location = New System.Drawing.Point(419, 45)
        Me.TBModel.Name = "TBModel"
        Me.TBModel.Size = New System.Drawing.Size(253, 20)
        Me.TBModel.TabIndex = 47
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(331, 74)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(29, 13)
        Me.Label27.TabIndex = 42
        Me.Label27.Text = "Pfad"
        '
        'TBSound
        '
        Me.TBSound.Enabled = False
        Me.TBSound.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBSound.Location = New System.Drawing.Point(419, 124)
        Me.TBSound.Name = "TBSound"
        Me.TBSound.Size = New System.Drawing.Size(253, 20)
        Me.TBSound.TabIndex = 46
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(331, 22)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(58, 13)
        Me.Label26.TabIndex = 40
        Me.Label26.Text = "Dateiname"
        '
        'BTSound
        '
        Me.BTSound.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTSound.Location = New System.Drawing.Point(678, 121)
        Me.BTSound.Name = "BTSound"
        Me.BTSound.Size = New System.Drawing.Size(75, 23)
        Me.BTSound.TabIndex = 45
        Me.BTSound.Text = "Auswählen"
        Me.BTSound.UseVisualStyleBackColor = True
        '
        'BTPfad
        '
        Me.BTPfad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTPfad.Location = New System.Drawing.Point(678, 69)
        Me.BTPfad.Name = "BTPfad"
        Me.BTPfad.Size = New System.Drawing.Size(75, 23)
        Me.BTPfad.TabIndex = 38
        Me.BTPfad.Text = "Auswählen"
        Me.BTPfad.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(331, 127)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(66, 13)
        Me.Label10.TabIndex = 44
        Me.Label10.Text = "Sound-Datei"
        '
        'TBPath
        '
        Me.TBPath.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBPath.Location = New System.Drawing.Point(419, 71)
        Me.TBPath.Name = "TBPath"
        Me.TBPath.Size = New System.Drawing.Size(253, 20)
        Me.TBPath.TabIndex = 37
        '
        'TBDateiname
        '
        Me.TBDateiname.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBDateiname.Location = New System.Drawing.Point(419, 19)
        Me.TBDateiname.Name = "TBDateiname"
        Me.TBDateiname.Size = New System.Drawing.Size(334, 20)
        Me.TBDateiname.TabIndex = 36
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(331, 101)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(85, 13)
        Me.Label14.TabIndex = 39
        Me.Label14.Text = "Sitz-/ Stehplätze"
        '
        'TBCabin
        '
        Me.TBCabin.Enabled = False
        Me.TBCabin.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBCabin.Location = New System.Drawing.Point(419, 98)
        Me.TBCabin.Name = "TBCabin"
        Me.TBCabin.Size = New System.Drawing.Size(253, 20)
        Me.TBCabin.TabIndex = 43
        '
        'BTSitze
        '
        Me.BTSitze.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTSitze.Location = New System.Drawing.Point(678, 95)
        Me.BTSitze.Name = "BTSitze"
        Me.BTSitze.Size = New System.Drawing.Size(75, 23)
        Me.BTSitze.TabIndex = 41
        Me.BTSitze.Text = "Auswählen"
        Me.BTSitze.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Gruppen"
        '
        'TBGruppen
        '
        Me.TBGruppen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBGruppen.Location = New System.Drawing.Point(83, 45)
        Me.TBGruppen.Multiline = True
        Me.TBGruppen.Name = "TBGruppen"
        Me.TBGruppen.Size = New System.Drawing.Size(224, 83)
        Me.TBGruppen.TabIndex = 2
        '
        'TBName
        '
        Me.TBName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBName.Location = New System.Drawing.Point(83, 19)
        Me.TBName.Name = "TBName"
        Me.TBName.Size = New System.Drawing.Size(224, 20)
        Me.TBName.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Anzeigename"
        '
        'GBSichtbar
        '
        Me.GBSichtbar.Controls.Add(Me.Label9)
        Me.GBSichtbar.Controls.Add(Me.CBRendertype)
        Me.GBSichtbar.Controls.Add(Me.Label25)
        Me.GBSichtbar.Controls.Add(Me.Label4)
        Me.GBSichtbar.Controls.Add(Me.TBDetailfaktor)
        Me.GBSichtbar.Controls.Add(Me.CBonlyEditor)
        Me.GBSichtbar.Controls.Add(Me.Label5)
        Me.GBSichtbar.Controls.Add(Me.CBComplexcity)
        Me.GBSichtbar.Controls.Add(Me.Label6)
        Me.GBSichtbar.Location = New System.Drawing.Point(12, 221)
        Me.GBSichtbar.Name = "GBSichtbar"
        Me.GBSichtbar.Size = New System.Drawing.Size(313, 191)
        Me.GBSichtbar.TabIndex = 1
        Me.GBSichtbar.TabStop = False
        Me.GBSichtbar.Text = "Sichtbarkeit"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(107, 44)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(138, 13)
        Me.Label9.TabIndex = 34
        Me.Label9.Text = "Terrainhole + Deformation!!!"
        '
        'CBRendertype
        '
        Me.CBRendertype.FormattingEnabled = True
        Me.CBRendertype.Items.AddRange(New Object() {"Vor Terrain", "Mit Terrain", "Nach Terrain", "Vor normalen Objekten", "Standardwert", "Nach normalen Objekten", "Nach Fahrzeugen"})
        Me.CBRendertype.Location = New System.Drawing.Point(83, 153)
        Me.CBRendertype.Name = "CBRendertype"
        Me.CBRendertype.Size = New System.Drawing.Size(224, 21)
        Me.CBRendertype.TabIndex = 33
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(80, 92)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(180, 26)
        Me.Label25.TabIndex = 32
        Me.Label25.Text = "von 0.5 [Objekt wird früh dargestellt] " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "bis 2.0 [Objekt wird spät dargestellt]"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 156)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Rendertype"
        '
        'TBDetailfaktor
        '
        Me.TBDetailfaktor.Location = New System.Drawing.Point(83, 69)
        Me.TBDetailfaktor.Name = "TBDetailfaktor"
        Me.TBDetailfaktor.Size = New System.Drawing.Size(76, 20)
        Me.TBDetailfaktor.TabIndex = 18
        '
        'CBonlyEditor
        '
        Me.CBonlyEditor.AutoSize = True
        Me.CBonlyEditor.Location = New System.Drawing.Point(9, 19)
        Me.CBonlyEditor.Name = "CBonlyEditor"
        Me.CBonlyEditor.Size = New System.Drawing.Size(150, 17)
        Me.CBonlyEditor.TabIndex = 0
        Me.CBonlyEditor.Text = "Nur im Map-Editor sichtbar"
        Me.CBonlyEditor.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(3, 76)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 13)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Detailfaktor"
        '
        'CBComplexcity
        '
        Me.CBComplexcity.FormattingEnabled = True
        Me.CBComplexcity.Items.AddRange(New Object() {"sehr wichtig (z.B. Kreuzung)", "wichtig (z.B. Bushaltestelle)", "normal (z.B. Telefonzelle)", "unwichtig (z.B. Parkbank)"})
        Me.CBComplexcity.Location = New System.Drawing.Point(83, 126)
        Me.CBComplexcity.Name = "CBComplexcity"
        Me.CBComplexcity.Size = New System.Drawing.Size(224, 21)
        Me.CBComplexcity.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(3, 129)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(57, 13)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Complexity"
        '
        'CBNightMapMode
        '
        Me.CBNightMapMode.FormattingEnabled = True
        Me.CBNightMapMode.Items.AddRange(New Object() {"wie Straßenbeleuchtung", "Gebäude mit durchgehender Beleuchtung", "Wohngebäude (nicht zwischen ungefähr 23 und 6 Uhr inkl. Variation)", "Gewerbegebäude (nicht zwischen ungefähr 18 und 7 Uhr inkl. Variation)", "Schule (nicht zwischen ungefähr 15 und 7 Uhr inkl. Variation)"})
        Me.CBNightMapMode.Location = New System.Drawing.Point(106, 88)
        Me.CBNightMapMode.Name = "CBNightMapMode"
        Me.CBNightMapMode.Size = New System.Drawing.Size(241, 21)
        Me.CBNightMapMode.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 91)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "NightMapMode"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 137)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(85, 13)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "Crashmode Kraft"
        '
        'TBCrashmodeKraft
        '
        Me.TBCrashmodeKraft.Location = New System.Drawing.Point(136, 134)
        Me.TBCrashmodeKraft.Name = "TBCrashmodeKraft"
        Me.TBCrashmodeKraft.Size = New System.Drawing.Size(100, 20)
        Me.TBCrashmodeKraft.TabIndex = 9
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 165)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(123, 13)
        Me.Label8.TabIndex = 10
        Me.Label8.Text = "Crashmode Abreißwinkel"
        '
        'TBCrashmodeWinkel
        '
        Me.TBCrashmodeWinkel.Location = New System.Drawing.Point(136, 160)
        Me.TBCrashmodeWinkel.Name = "TBCrashmodeWinkel"
        Me.TBCrashmodeWinkel.Size = New System.Drawing.Size(100, 20)
        Me.TBCrashmodeWinkel.TabIndex = 11
        '
        'CBFixed
        '
        Me.CBFixed.AutoSize = True
        Me.CBFixed.Location = New System.Drawing.Point(6, 19)
        Me.CBFixed.Name = "CBFixed"
        Me.CBFixed.Size = New System.Drawing.Size(204, 17)
        Me.CBFixed.TabIndex = 1
        Me.CBFixed.Text = "fixed (kann nicht verschoben werden)"
        Me.CBFixed.UseVisualStyleBackColor = True
        '
        'CBSurface
        '
        Me.CBSurface.AutoSize = True
        Me.CBSurface.Location = New System.Drawing.Point(6, 42)
        Me.CBSurface.Name = "CBSurface"
        Me.CBSurface.Size = New System.Drawing.Size(157, 17)
        Me.CBSurface.TabIndex = 2
        Me.CBSurface.Text = "surface (Oberflächenobjekt)"
        Me.CBSurface.UseVisualStyleBackColor = True
        '
        'CBJoinable
        '
        Me.CBJoinable.AutoSize = True
        Me.CBJoinable.Location = New System.Drawing.Point(6, 65)
        Me.CBJoinable.Name = "CBJoinable"
        Me.CBJoinable.Size = New System.Drawing.Size(62, 17)
        Me.CBJoinable.TabIndex = 3
        Me.CBJoinable.Text = "joinable"
        Me.CBJoinable.UseVisualStyleBackColor = True
        '
        'CBNocollision
        '
        Me.CBNocollision.AutoSize = True
        Me.CBNocollision.Location = New System.Drawing.Point(6, 88)
        Me.CBNocollision.Name = "CBNocollision"
        Me.CBNocollision.Size = New System.Drawing.Size(93, 17)
        Me.CBNocollision.TabIndex = 4
        Me.CBNocollision.Text = "keine Kollision"
        Me.CBNocollision.UseVisualStyleBackColor = True
        '
        'CBAbsHeight
        '
        Me.CBAbsHeight.AutoSize = True
        Me.CBAbsHeight.Location = New System.Drawing.Point(6, 111)
        Me.CBAbsHeight.Name = "CBAbsHeight"
        Me.CBAbsHeight.Size = New System.Drawing.Size(95, 17)
        Me.CBAbsHeight.TabIndex = 5
        Me.CBAbsHeight.Text = "absolute Höhe"
        Me.CBAbsHeight.UseVisualStyleBackColor = True
        '
        'CBLightmapMapping
        '
        Me.CBLightmapMapping.AutoSize = True
        Me.CBLightmapMapping.Location = New System.Drawing.Point(12, 19)
        Me.CBLightmapMapping.Name = "CBLightmapMapping"
        Me.CBLightmapMapping.Size = New System.Drawing.Size(110, 17)
        Me.CBLightmapMapping.TabIndex = 6
        Me.CBLightmapMapping.Text = "LightmapMapping"
        Me.CBLightmapMapping.UseVisualStyleBackColor = True
        '
        'CBShadow
        '
        Me.CBShadow.AutoSize = True
        Me.CBShadow.Location = New System.Drawing.Point(12, 42)
        Me.CBShadow.Name = "CBShadow"
        Me.CBShadow.Size = New System.Drawing.Size(125, 17)
        Me.CBShadow.TabIndex = 7
        Me.CBShadow.Text = "Objekt wirft Schatten"
        Me.CBShadow.UseVisualStyleBackColor = True
        '
        'GBBel
        '
        Me.GBBel.Controls.Add(Me.CBNormalBel)
        Me.GBBel.Controls.Add(Me.CBLightmapMapping)
        Me.GBBel.Controls.Add(Me.CBShadow)
        Me.GBBel.Controls.Add(Me.CBNightMapMode)
        Me.GBBel.Controls.Add(Me.Label3)
        Me.GBBel.Location = New System.Drawing.Point(340, 418)
        Me.GBBel.Name = "GBBel"
        Me.GBBel.Size = New System.Drawing.Size(434, 128)
        Me.GBBel.TabIndex = 12
        Me.GBBel.TabStop = False
        Me.GBBel.Text = "Beleuchtung"
        '
        'CBNormalBel
        '
        Me.CBNormalBel.AutoSize = True
        Me.CBNormalBel.Location = New System.Drawing.Point(12, 65)
        Me.CBNormalBel.Name = "CBNormalBel"
        Me.CBNormalBel.Size = New System.Drawing.Size(118, 17)
        Me.CBNormalBel.TabIndex = 12
        Me.CBNormalBel.Text = "Normalbeleuchtung"
        Me.CBNormalBel.UseVisualStyleBackColor = True
        '
        'GBPhysik
        '
        Me.GBPhysik.Controls.Add(Me.CBNocollision)
        Me.GBPhysik.Controls.Add(Me.CBFixed)
        Me.GBPhysik.Controls.Add(Me.CBSurface)
        Me.GBPhysik.Controls.Add(Me.CBJoinable)
        Me.GBPhysik.Controls.Add(Me.TBCrashmodeWinkel)
        Me.GBPhysik.Controls.Add(Me.Label8)
        Me.GBPhysik.Controls.Add(Me.CBAbsHeight)
        Me.GBPhysik.Controls.Add(Me.TBCrashmodeKraft)
        Me.GBPhysik.Controls.Add(Me.Label7)
        Me.GBPhysik.Location = New System.Drawing.Point(340, 222)
        Me.GBPhysik.Name = "GBPhysik"
        Me.GBPhysik.Size = New System.Drawing.Size(434, 190)
        Me.GBPhysik.TabIndex = 13
        Me.GBPhysik.TabStop = False
        Me.GBPhysik.Text = "Physik"
        '
        'CBTankstelle
        '
        Me.CBTankstelle.AutoSize = True
        Me.CBTankstelle.Location = New System.Drawing.Point(6, 17)
        Me.CBTankstelle.Name = "CBTankstelle"
        Me.CBTankstelle.Size = New System.Drawing.Size(75, 17)
        Me.CBTankstelle.TabIndex = 8
        Me.CBTankstelle.Text = "Tankstelle"
        Me.CBTankstelle.UseVisualStyleBackColor = True
        '
        'CBBusstop
        '
        Me.CBBusstop.AutoSize = True
        Me.CBBusstop.Location = New System.Drawing.Point(6, 40)
        Me.CBBusstop.Name = "CBBusstop"
        Me.CBBusstop.Size = New System.Drawing.Size(239, 17)
        Me.CBBusstop.TabIndex = 11
        Me.CBBusstop.Text = "Busstop-Würfel (nicht Haltestelle oder -bucht)"
        Me.CBBusstop.UseVisualStyleBackColor = True
        '
        'GBGeneric
        '
        Me.GBGeneric.Controls.Add(Me.CBHilfspfeil)
        Me.GBGeneric.Controls.Add(Me.CBEntrypoint)
        Me.GBGeneric.Controls.Add(Me.CBCarpark)
        Me.GBGeneric.Controls.Add(Me.CBBusstop)
        Me.GBGeneric.Controls.Add(Me.CBTankstelle)
        Me.GBGeneric.Enabled = False
        Me.GBGeneric.Location = New System.Drawing.Point(12, 418)
        Me.GBGeneric.Name = "GBGeneric"
        Me.GBGeneric.Size = New System.Drawing.Size(313, 128)
        Me.GBGeneric.TabIndex = 37
        Me.GBGeneric.TabStop = False
        Me.GBGeneric.Text = "Generic"
        '
        'CBHilfspfeil
        '
        Me.CBHilfspfeil.AutoSize = True
        Me.CBHilfspfeil.Location = New System.Drawing.Point(6, 109)
        Me.CBHilfspfeil.Name = "CBHilfspfeil"
        Me.CBHilfspfeil.Size = New System.Drawing.Size(63, 17)
        Me.CBHilfspfeil.TabIndex = 14
        Me.CBHilfspfeil.Text = "Hifspfeil"
        Me.CBHilfspfeil.UseVisualStyleBackColor = True
        '
        'CBEntrypoint
        '
        Me.CBEntrypoint.AutoSize = True
        Me.CBEntrypoint.Location = New System.Drawing.Point(6, 86)
        Me.CBEntrypoint.Name = "CBEntrypoint"
        Me.CBEntrypoint.Size = New System.Drawing.Size(73, 17)
        Me.CBEntrypoint.TabIndex = 13
        Me.CBEntrypoint.Text = "Entrypoint"
        Me.CBEntrypoint.UseVisualStyleBackColor = True
        '
        'CBCarpark
        '
        Me.CBCarpark.AutoSize = True
        Me.CBCarpark.Location = New System.Drawing.Point(6, 63)
        Me.CBCarpark.Name = "CBCarpark"
        Me.CBCarpark.Size = New System.Drawing.Size(63, 17)
        Me.CBCarpark.TabIndex = 12
        Me.CBCarpark.Text = "Carpark"
        Me.CBCarpark.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.RBHilfsobj)
        Me.GroupBox4.Controls.Add(Me.RBStrael)
        Me.GroupBox4.Controls.Add(Me.RBGeb)
        Me.GroupBox4.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(764, 40)
        Me.GroupBox4.TabIndex = 38
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Objekttyp"
        '
        'RBHilfsobj
        '
        Me.RBHilfsobj.AutoSize = True
        Me.RBHilfsobj.Location = New System.Drawing.Point(214, 17)
        Me.RBHilfsobj.Name = "RBHilfsobj"
        Me.RBHilfsobj.Size = New System.Drawing.Size(74, 17)
        Me.RBHilfsobj.TabIndex = 2
        Me.RBHilfsobj.Text = "Hilfsobjekt"
        Me.RBHilfsobj.UseVisualStyleBackColor = True
        '
        'RBStrael
        '
        Me.RBStrael.AutoSize = True
        Me.RBStrael.Location = New System.Drawing.Point(95, 17)
        Me.RBStrael.Name = "RBStrael"
        Me.RBStrael.Size = New System.Drawing.Size(99, 17)
        Me.RBStrael.TabIndex = 1
        Me.RBStrael.Text = "Straßenelement"
        Me.RBStrael.UseVisualStyleBackColor = True
        '
        'RBGeb
        '
        Me.RBGeb.AutoSize = True
        Me.RBGeb.Checked = True
        Me.RBGeb.Location = New System.Drawing.Point(6, 17)
        Me.RBGeb.Name = "RBGeb"
        Me.RBGeb.Size = New System.Drawing.Size(69, 17)
        Me.RBGeb.TabIndex = 0
        Me.RBGeb.TabStop = True
        Me.RBGeb.Text = "Gebäude"
        Me.RBGeb.UseVisualStyleBackColor = True
        '
        'BTOrdner
        '
        Me.BTOrdner.Location = New System.Drawing.Point(21, 552)
        Me.BTOrdner.Name = "BTOrdner"
        Me.BTOrdner.Size = New System.Drawing.Size(80, 23)
        Me.BTOrdner.TabIndex = 39
        Me.BTOrdner.Text = "Ordner öffnen"
        Me.BTOrdner.UseVisualStyleBackColor = True
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(485, 557)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(199, 13)
        Me.Label30.TabIndex = 41
        Me.Label30.Text = "Änderungen werden direkt übernommen!"
        '
        'BTSchließen
        '
        Me.BTSchließen.Location = New System.Drawing.Point(690, 552)
        Me.BTSchließen.Name = "BTSchließen"
        Me.BTSchließen.Size = New System.Drawing.Size(75, 23)
        Me.BTSchließen.TabIndex = 40
        Me.BTSchließen.Text = "Schließen"
        Me.BTSchließen.UseVisualStyleBackColor = True
        '
        'Frm_Eig_Sco
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(781, 581)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.BTSchließen)
        Me.Controls.Add(Me.BTOrdner)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GBGeneric)
        Me.Controls.Add(Me.GBPhysik)
        Me.Controls.Add(Me.GBBel)
        Me.Controls.Add(Me.GBSichtbar)
        Me.Controls.Add(Me.GBOrg)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Eig_Sco"
        Me.Text = "Eigenschaften"
        Me.GBOrg.ResumeLayout(False)
        Me.GBOrg.PerformLayout()
        Me.GBSichtbar.ResumeLayout(False)
        Me.GBSichtbar.PerformLayout()
        Me.GBBel.ResumeLayout(False)
        Me.GBBel.PerformLayout()
        Me.GBPhysik.ResumeLayout(False)
        Me.GBPhysik.PerformLayout()
        Me.GBGeneric.ResumeLayout(False)
        Me.GBGeneric.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GBOrg As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TBGruppen As TextBox
    Friend WithEvents TBName As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents GBSichtbar As GroupBox
    Friend WithEvents CBonlyEditor As CheckBox
    Friend WithEvents CBNightMapMode As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents CBComplexcity As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents CBTankstelle As CheckBox
    Friend WithEvents CBShadow As CheckBox
    Friend WithEvents CBLightmapMapping As CheckBox
    Friend WithEvents CBAbsHeight As CheckBox
    Friend WithEvents CBNocollision As CheckBox
    Friend WithEvents CBJoinable As CheckBox
    Friend WithEvents CBSurface As CheckBox
    Friend WithEvents CBFixed As CheckBox
    Friend WithEvents TBCrashmodeKraft As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents TBCrashmodeWinkel As TextBox
    Friend WithEvents GBBel As GroupBox
    Friend WithEvents GBPhysik As GroupBox
    Friend WithEvents CBNormalBel As CheckBox
    Friend WithEvents CBBusstop As CheckBox
    Friend WithEvents TBDetailfaktor As TextBox
    Friend WithEvents Label25 As Label
    Friend WithEvents GBGeneric As GroupBox
    Friend WithEvents CBHilfspfeil As CheckBox
    Friend WithEvents CBEntrypoint As CheckBox
    Friend WithEvents CBCarpark As CheckBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents RBHilfsobj As RadioButton
    Friend WithEvents RBStrael As RadioButton
    Friend WithEvents RBGeb As RadioButton
    Friend WithEvents CBRendertype As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label27 As Label
    Friend WithEvents TBSound As TextBox
    Friend WithEvents Label26 As Label
    Friend WithEvents BTSound As Button
    Friend WithEvents BTPfad As Button
    Friend WithEvents Label10 As Label
    Friend WithEvents TBPath As TextBox
    Friend WithEvents TBDateiname As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents TBCabin As TextBox
    Friend WithEvents BTSitze As Button
    Friend WithEvents BTOrdner As Button
    Friend WithEvents Label30 As Label
    Friend WithEvents BTSchließen As Button
    Friend WithEvents TBModel As TextBox
    Friend WithEvents CBModel As CheckBox
    Friend WithEvents Button1 As Button
End Class
