<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm_Main
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Main))
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Achsen")
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Boundingbox")
        Dim TreeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Fahrerkameras")
        Dim TreeNode4 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Fahrgastkameras")
        Dim TreeNode5 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Kameras", New System.Windows.Forms.TreeNode() {TreeNode3, TreeNode4})
        Dim TreeNode6 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Kupplungspunkte")
        Dim TreeNode7 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Innenlichter")
        Dim TreeNode8 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Rauch")
        Dim TreeNode9 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Spiegel")
        Dim TreeNode10 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Sitz-/ Stehplätze")
        Dim TreeNode11 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Entwerter")
        Dim TreeNode12 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Ticketblöcke")
        Dim TreeNode13 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Geldablage")
        Dim TreeNode14 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Geldrückgabe")
        Dim TreeNode15 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Tickets", New System.Windows.Forms.TreeNode() {TreeNode11, TreeNode12, TreeNode13, TreeNode14})
        Dim TreeNode16 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Attachpoints")
        Dim TreeNode17 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Splinehelper")
        Dim TreeNode18 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Spots")
        Dim Point3D1 As O3D_Test.Point3D = New O3D_Test.Point3D()
        Dim RgbColor1 As O3D_Test.RGBColor = New O3D_Test.RGBColor()
        Dim Point3D2 As O3D_Test.Point3D = New O3D_Test.Point3D()
        Dim Point3D3 As O3D_Test.Point3D = New O3D_Test.Point3D()
        Dim Point3D4 As O3D_Test.Point3D = New O3D_Test.Point3D()
        Dim Point3D5 As O3D_Test.Point3D = New O3D_Test.Point3D()
        Dim Point3D6 As O3D_Test.Point3D = New O3D_Test.Point3D()
        Dim Point3D7 As O3D_Test.Point3D = New O3D_Test.Point3D()
        Dim RgbColor2 As O3D_Test.RGBColor = New O3D_Test.RGBColor()
        Dim Point3D8 As O3D_Test.Point3D = New O3D_Test.Point3D()
        Dim Point3D9 As O3D_Test.Point3D = New O3D_Test.Point3D()
        Me.SS1 = New System.Windows.Forms.StatusStrip()
        Me.PBMain = New System.Windows.Forms.ToolStripProgressBar()
        Me.SSLBStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TBTimer = New System.Windows.Forms.ToolStripStatusLabel()
        Me.MS1 = New System.Windows.Forms.MenuStrip()
        Me.DateiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NeuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ÖffnenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LetzteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NeuLadenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SpeichernToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AllesToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.NurProjektbusovhscoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NurModelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NurCabinToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NurPathsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NurToolUmgebungocdbToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SpeichernUnterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PackenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RarArchivToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LctLOTUSContentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem6 = New System.Windows.Forms.ToolStripSeparator()
        Me.EinstellungenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.BeendenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BearbeitenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SuchenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem18 = New System.Windows.Forms.ToolStripSeparator()
        Me.EigenschaftenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TextToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem13 = New System.Windows.Forms.ToolStripSeparator()
        Me.AmpelphaseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HofDateienToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RepaintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AnsichtToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WireframeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GitterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AlphaAnzeigenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripSeparator()
        Me.FensterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ObjekteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TextureToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EigenschaftenFensterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TimelineLogFensterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DarstellungToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AllesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OMSIAußenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OMSIInnenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OMSIAIBusToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PerspektiveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FahrrersichtToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PassagiersichtToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AußenansichtToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FreieKameraToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem7 = New System.Windows.Forms.ToolStripSeparator()
        Me.LODObjektToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem14 = New System.Windows.Forms.ToolStripSeparator()
        Me.PfadeInOriginalbreiteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem9 = New System.Windows.Forms.ToolStripSeparator()
        Me.LogfileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NeuesRepositoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NeuesRepoKlonenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem8 = New System.Windows.Forms.ToolStripSeparator()
        Me.CommitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PullToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PushToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SyncToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem19 = New System.Windows.Forms.ToolStripSeparator()
        Me.UnGitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ObjektToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EntfernenToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.VersteckenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DevelopmentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToDoListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReadmetxtToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RechnerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem17 = New System.Windows.Forms.ToolStripSeparator()
        Me.StatistikToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem12 = New System.Windows.Forms.ToolStripSeparator()
        Me.ProjektordnerÖffnenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ErstellenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AchseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.KameraToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FahrerkameraToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FahrgastkameraToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.KupplungspunktToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FrontToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HeckToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InnenlichtToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RauchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SpiegelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SitzplatzToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TicketblockToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EntwerterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TicketblockToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.RückgabefeldToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GeldrückgabeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AttachpointsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SplinehelperToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SpotToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem15 = New System.Windows.Forms.ToolStripSeparator()
        Me.LichtToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PfadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ModifikationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VeränderungAufnehmenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MitOriginalVergleichenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SoundToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ScriptToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VarlistsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StringvarlistToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ScriptsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConstfilesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem10 = New System.Windows.Forms.ToolStripSeparator()
        Me.VariablenTestToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImportierenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportiernToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HilfeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ForumToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ForumToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.WebseiteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LokaleHilfeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TestToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WagenteilToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NächsterWagenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VorherigerWagenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PanelMain = New System.Windows.Forms.Panel()
        Me.PanelTimeline = New System.Windows.Forms.Panel()
        Me.BTPanelTimelineClose = New System.Windows.Forms.Button()
        Me.TCTimeline = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TimelineCursor = New System.Windows.Forms.Panel()
        Me.SLTimeline = New System.Windows.Forms.Splitter()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.TBScriptLog = New System.Windows.Forms.TextBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TBLogfile = New System.Windows.Forms.TextBox()
        Me.PanelEigenschaften = New System.Windows.Forms.Panel()
        Me.BTEigenschafteResize = New System.Windows.Forms.Button()
        Me.BTPanelEingenschaftenClose = New System.Windows.Forms.Button()
        Me.PanelEigenschaften1 = New System.Windows.Forms.Panel()
        Me.GBSpot = New System.Windows.Forms.GroupBox()
        Me.Label84 = New System.Windows.Forms.Label()
        Me.Label82 = New System.Windows.Forms.Label()
        Me.Label81 = New System.Windows.Forms.Label()
        Me.Spot_TBAussen = New System.Windows.Forms.TextBox()
        Me.Spot_TBInner = New System.Windows.Forms.TextBox()
        Me.Label80 = New System.Windows.Forms.Label()
        Me.Spot_TBLeuchtweite = New System.Windows.Forms.TextBox()
        Me.Label79 = New System.Windows.Forms.Label()
        Me.GBPlatz = New System.Windows.Forms.GroupBox()
        Me.Platz_MinMax = New System.Windows.Forms.Button()
        Me.Platz_TBRichtung = New System.Windows.Forms.TextBox()
        Me.Label57 = New System.Windows.Forms.Label()
        Me.GBRauch = New System.Windows.Forms.GroupBox()
        Me.Rauch_MinMax = New System.Windows.Forms.Button()
        Me.Label56 = New System.Windows.Forms.Label()
        Me.Rauch_Geschw = New System.Windows.Forms.TextBox()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.GBPfade = New System.Windows.Forms.GroupBox()
        Me.Pfade_CBTaster = New System.Windows.Forms.CheckBox()
        Me.Pfade_CBVerkauf = New System.Windows.Forms.CheckBox()
        Me.Pfade_CBVorWagen = New System.Windows.Forms.CheckBox()
        Me.Pfade_CBNextWagen = New System.Windows.Forms.CheckBox()
        Me.Pfade_PBOrange = New System.Windows.Forms.PictureBox()
        Me.Pfade_BTHinzu = New System.Windows.Forms.Button()
        Me.Label69 = New System.Windows.Forms.Label()
        Me.Pfade_PVerb0 = New System.Windows.Forms.Panel()
        Me.Pfade_PBLila = New System.Windows.Forms.PictureBox()
        Me.Pfade_BTRem_0 = New System.Windows.Forms.Button()
        Me.Pfade_DDStepsound_0 = New System.Windows.Forms.ComboBox()
        Me.Pfade_TBStehh_0 = New System.Windows.Forms.TextBox()
        Me.Label61 = New System.Windows.Forms.Label()
        Me.Pfade_CBRichtung_0 = New System.Windows.Forms.CheckBox()
        Me.Label60 = New System.Windows.Forms.Label()
        Me.Label62 = New System.Windows.Forms.Label()
        Me.Pfade_DDNachste_0 = New System.Windows.Forms.ComboBox()
        Me.Pfade_MinMax = New System.Windows.Forms.Button()
        Me.Pfade_CBAusstieg = New System.Windows.Forms.CheckBox()
        Me.Pfade_CBEinstieg = New System.Windows.Forms.CheckBox()
        Me.Pfade_TBIndex = New System.Windows.Forms.TextBox()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.Label70 = New System.Windows.Forms.Label()
        Me.GBKupplPnt = New System.Windows.Forms.GroupBox()
        Me.Kuppl_LBHeck = New System.Windows.Forms.Label()
        Me.Kuppl_LBFront = New System.Windows.Forms.Label()
        Me.Label68 = New System.Windows.Forms.Label()
        Me.Label67 = New System.Windows.Forms.Label()
        Me.Kuppl_TBUp = New System.Windows.Forms.TextBox()
        Me.Kuppl_TBDown = New System.Windows.Forms.TextBox()
        Me.Kuppl_TBDrehwinkel = New System.Windows.Forms.TextBox()
        Me.Label66 = New System.Windows.Forms.Label()
        Me.Kuppl_DDKupplType = New System.Windows.Forms.ComboBox()
        Me.Label65 = New System.Windows.Forms.Label()
        Me.Kuppl_CBSound = New System.Windows.Forms.CheckBox()
        Me.Label64 = New System.Windows.Forms.Label()
        Me.Kuppl_DDRichtung = New System.Windows.Forms.ComboBox()
        Me.Label63 = New System.Windows.Forms.Label()
        Me.Kuppl_DDNextVehicle = New System.Windows.Forms.ComboBox()
        Me.Kupplung_MinMax = New System.Windows.Forms.Button()
        Me.GBKamera = New System.Windows.Forms.GroupBox()
        Me.Kamera_BTStd = New System.Windows.Forms.Button()
        Me.Kamera_CBVerkauf = New System.Windows.Forms.CheckBox()
        Me.Kamera_CBFahrplan = New System.Windows.Forms.CheckBox()
        Me.Label74 = New System.Windows.Forms.Label()
        Me.Label73 = New System.Windows.Forms.Label()
        Me.Kamera_TBVertikal = New System.Windows.Forms.TextBox()
        Me.Kamera_TBHorizont = New System.Windows.Forms.TextBox()
        Me.Label72 = New System.Windows.Forms.Label()
        Me.Kamera_TBSichtwinkel = New System.Windows.Forms.TextBox()
        Me.Label71 = New System.Windows.Forms.Label()
        Me.Kamera_TBDistRotPnt = New System.Windows.Forms.TextBox()
        Me.Kamera_MinMax = New System.Windows.Forms.Button()
        Me.Kamera_RBPassagier = New System.Windows.Forms.RadioButton()
        Me.Kamera_RBFahrer = New System.Windows.Forms.RadioButton()
        Me.GBBbox = New System.Windows.Forms.GroupBox()
        Me.BBox_MinMax = New System.Windows.Forms.Button()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.BBoxBTBerechnen = New System.Windows.Forms.Button()
        Me.GBAchse = New System.Windows.Forms.GroupBox()
        Me.Label59 = New System.Windows.Forms.Label()
        Me.Achse_TBDurchmesser = New System.Windows.Forms.TextBox()
        Me.Achse_MinMax = New System.Windows.Forms.Button()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.Achse_TBDaempfer = New System.Windows.Forms.TextBox()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.Achse_TBMaxforce = New System.Windows.Forms.TextBox()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.Achse_TBFeder = New System.Windows.Forms.TextBox()
        Me.Achse_CBAntrieb = New System.Windows.Forms.CheckBox()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.Achse_TBMinwidt = New System.Windows.Forms.TextBox()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.Achse_TBBreite = New System.Windows.Forms.TextBox()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.Achse_TBMaxwidt = New System.Windows.Forms.TextBox()
        Me.GBSplineHelper = New System.Windows.Forms.GroupBox()
        Me.SplineHelper_MinMax = New System.Windows.Forms.Button()
        Me.Splinehelper_BTLaden = New System.Windows.Forms.Button()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.Splinehelper_TBSpline = New System.Windows.Forms.TextBox()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.Splinehelper_TBDrehung = New System.Windows.Forms.TextBox()
        Me.GBPfad = New System.Windows.Forms.GroupBox()
        Me.Pfad_MinMax = New System.Windows.Forms.Button()
        Me.Pfad_CBParallelProblem = New System.Windows.Forms.CheckBox()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.Pfad_CBAmpel = New System.Windows.Forms.ComboBox()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.Pfad_CBBlinker = New System.Windows.Forms.ComboBox()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.Pfad_CBRichtung = New System.Windows.Forms.ComboBox()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Pfad_CBTyp = New System.Windows.Forms.ComboBox()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Pfad_TBEndWinkel = New System.Windows.Forms.TextBox()
        Me.Pfad_TBStartWinkel = New System.Windows.Forms.TextBox()
        Me.Pfad_TBBreite = New System.Windows.Forms.TextBox()
        Me.Pfad_TBWinkel = New System.Windows.Forms.TextBox()
        Me.Pfad_TBRadius = New System.Windows.Forms.TextBox()
        Me.Pfad_TBLänge = New System.Windows.Forms.TextBox()
        Me.Pfad_TBRot = New System.Windows.Forms.TextBox()
        Me.GBSpline = New System.Windows.Forms.GroupBox()
        Me.Spline_CBVisible = New System.Windows.Forms.CheckBox()
        Me.Splines_CBCollision = New System.Windows.Forms.CheckBox()
        Me.Label95 = New System.Windows.Forms.Label()
        Me.Label94 = New System.Windows.Forms.Label()
        Me.Spline_TBEndZ = New System.Windows.Forms.TextBox()
        Me.Spline_TBStartZ = New System.Windows.Forms.TextBox()
        Me.Label93 = New System.Windows.Forms.Label()
        Me.Spline_TBEndX = New System.Windows.Forms.TextBox()
        Me.Spline_TBStartX = New System.Windows.Forms.TextBox()
        Me.Label92 = New System.Windows.Forms.Label()
        Me.Spline_MinMax = New System.Windows.Forms.Button()
        Me.GBAllgemein = New System.Windows.Forms.GroupBox()
        Me.TBName = New System.Windows.Forms.TextBox()
        Me.Label = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GBMesh = New System.Windows.Forms.GroupBox()
        Me.Mesh_TBMeshident = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Mesh_MinMax = New System.Windows.Forms.Button()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Mesh_NUMax = New System.Windows.Forms.NumericUpDown()
        Me.Mesh_NUMin = New System.Windows.Forms.NumericUpDown()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Mesh_TBSichtbarkeitVal = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Mesh_DDViedpoint = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GBParent = New System.Windows.Forms.GroupBox()
        Me.Parent_MinMax = New System.Windows.Forms.Button()
        Me.Parent_CBParent = New System.Windows.Forms.ComboBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.GBBones = New System.Windows.Forms.GroupBox()
        Me.Bones_MinMax = New System.Windows.Forms.Button()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Bones_CBParent = New System.Windows.Forms.ComboBox()
        Me.Bones_TBName = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.GBBel = New System.Windows.Forms.GroupBox()
        Me.Label91 = New System.Windows.Forms.Label()
        Me.Label90 = New System.Windows.Forms.Label()
        Me.Label89 = New System.Windows.Forms.Label()
        Me.Label88 = New System.Windows.Forms.Label()
        Me.Bel_MinMax = New System.Windows.Forms.Button()
        Me.Bel_BTKeine = New System.Windows.Forms.Button()
        Me.Bel_BTBerechnen = New System.Windows.Forms.Button()
        Me.Bel_CB1 = New System.Windows.Forms.ComboBox()
        Me.Bel_CB2 = New System.Windows.Forms.ComboBox()
        Me.Bel_CB3 = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Bel_CB0 = New System.Windows.Forms.ComboBox()
        Me.GBLicht = New System.Windows.Forms.GroupBox()
        Me.Label83 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Licht_MinMax = New System.Windows.Forms.Button()
        Me.Licht_TBZeitkonst = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Licht_TBKegel = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Licht_CBEffekt = New System.Windows.Forms.ComboBox()
        Me.Licht_TBOffset = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Licht_TBFaktor = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Licht_TBOuterCone = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Licht_TBInnerCone = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Licht_TBGroesse = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Licht_CBRotAusr = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Licht_CBAusr = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Licht_TBTexture = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GBMat = New System.Windows.Forms.GroupBox()
        Me.Mat_MinMax = New System.Windows.Forms.Button()
        Me.Mat_CBZCheck = New System.Windows.Forms.CheckBox()
        Me.Mat_CBZWrite = New System.Windows.Forms.CheckBox()
        Me.Mat_TBAlphascale = New System.Windows.Forms.TextBox()
        Me.Label58 = New System.Windows.Forms.Label()
        Me.Mat_CBAlpha = New System.Windows.Forms.ComboBox()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.Mat_CBTextTex = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Mat_CBTex = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.GBAnimation = New System.Windows.Forms.GroupBox()
        Me.Label87 = New System.Windows.Forms.Label()
        Me.Anim_TBDelay = New System.Windows.Forms.TextBox()
        Me.Anim_TBMaxSpeed = New System.Windows.Forms.TextBox()
        Me.Label86 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Anim_RBPoint = New System.Windows.Forms.RadioButton()
        Me.Anim_RBMesh = New System.Windows.Forms.RadioButton()
        Me.Anim_PRBArt = New System.Windows.Forms.Panel()
        Me.Anim_RBVerschieben = New System.Windows.Forms.RadioButton()
        Me.Anim_RBDrehen = New System.Windows.Forms.RadioButton()
        Me.Label85 = New System.Windows.Forms.Label()
        Me.Label78 = New System.Windows.Forms.Label()
        Me.Label77 = New System.Windows.Forms.Label()
        Me.Label76 = New System.Windows.Forms.Label()
        Me.Label75 = New System.Windows.Forms.Label()
        Me.Anim_TBAnimGrp = New System.Windows.Forms.TextBox()
        Me.Anim_MinMax = New System.Windows.Forms.Button()
        Me.Anim_TBValue = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Anim_BTLöschen = New System.Windows.Forms.Button()
        Me.Anim_BTNeu = New System.Windows.Forms.Button()
        Me.Anim_DDList = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.LBEingenschaften = New System.Windows.Forms.Label()
        Me.PanelTexture = New System.Windows.Forms.Panel()
        Me.BTTexOkay = New System.Windows.Forms.Button()
        Me.BTTexBearb = New System.Windows.Forms.Button()
        Me.BTTexLoad = New System.Windows.Forms.Button()
        Me.BTTexNew = New System.Windows.Forms.Button()
        Me.DDAlleTexturen = New System.Windows.Forms.ComboBox()
        Me.PBTexture = New System.Windows.Forms.PictureBox()
        Me.PanelTextureFill = New System.Windows.Forms.Button()
        Me.LBPanelTexture = New System.Windows.Forms.Label()
        Me.BTPanelTextureClose = New System.Windows.Forms.Button()
        Me.MSTexturen = New System.Windows.Forms.MenuStrip()
        Me.AnsichtToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.FrühlingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SommernormalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HerbstToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WinterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PanelObjekte = New System.Windows.Forms.Panel()
        Me.BTObjekteResize = New System.Windows.Forms.Button()
        Me.BTPanelObjekteClose = New System.Windows.Forms.Button()
        Me.TCObjekte = New System.Windows.Forms.TabControl()
        Me.TCObjektePMeshes = New System.Windows.Forms.TabPage()
        Me.LBMeshes = New System.Windows.Forms.CheckedListBox()
        Me.CMSMeshes = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CMSObjekteNeuladen = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMSObjekteBearbeiten = New System.Windows.Forms.ToolStripMenuItem()
        Me.ZUpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LeftRightHandedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem11 = New System.Windows.Forms.ToolStripSeparator()
        Me.UmbenennenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me.CMSObjekteImport = New System.Windows.Forms.ToolStripMenuItem()
        Me.ErsetzenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMSObjekteExport = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripSeparator()
        Me.CMSObjekteEntfernen = New System.Windows.Forms.ToolStripMenuItem()
        Me.DateiLöschenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem16 = New System.Windows.Forms.ToolStripSeparator()
        Me.EigenschaftenToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.TCObjektePHelfer = New System.Windows.Forms.TabPage()
        Me.TVHelper = New System.Windows.Forms.TreeView()
        Me.CMSHelfer = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.NeuToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.DuplizierenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EntfernenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TCObjektePLichter = New System.Windows.Forms.TabPage()
        Me.LBLichter = New System.Windows.Forms.ListBox()
        Me.CMSLichter = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.NeuToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.DuplizierenToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.EntfernenToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.SortierenNachToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PositionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OriginalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VariablenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TCObjektePPfade = New System.Windows.Forms.TabPage()
        Me.LBPfade = New System.Windows.Forms.ListBox()
        Me.CMSPfade = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.NeuToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.DuplizierenToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.EntfernenToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.GlMain = New OpenTK.GLControl()
        Me.FDÖffnen = New System.Windows.Forms.OpenFileDialog()
        Me.TSave = New System.Windows.Forms.Timer(Me.components)
        Me.TReloadTextures = New System.Windows.Forms.Timer(Me.components)
        Me.GBSplinePfad = New System.Windows.Forms.GroupBox()
        Me.SplinePfad_MinMax = New System.Windows.Forms.Button()
        Me.Spot_PSRichtung = New O3D_Test.PointSelector()
        Me.Spot_CSFarbe = New O3D_Test.ColorSelector()
        Me.VarSelector1 = New O3D_Test.VarSelector()
        Me.PointSelector2 = New O3D_Test.PointSelector()
        Me.BBox_PSSize = New O3D_Test.PointSelector()
        Me.PSPos = New O3D_Test.PointSelector()
        Me.Mesh_VSKlickevent = New O3D_Test.VarSelector()
        Me.Mesh_VSSichtbarkeit = New O3D_Test.VarSelector()
        Me.Mesh_PSCenter = New O3D_Test.PointSelector()
        Me.Licht_VSVar = New O3D_Test.VarSelector()
        Me.Licht_PSVector = New O3D_Test.PointSelector()
        Me.Licht_PSRichtung = New O3D_Test.PointSelector()
        Me.Licht_CSFarbe = New O3D_Test.ColorSelector()
        Me.Anim_PSRichtung = New O3D_Test.PointSelector()
        Me.Anim_PSRotPnt = New O3D_Test.PointSelector()
        Me.Anim_VSVar = New O3D_Test.VarSelector()
        Me.SS1.SuspendLayout()
        Me.MS1.SuspendLayout()
        Me.PanelMain.SuspendLayout()
        Me.PanelTimeline.SuspendLayout()
        Me.TCTimeline.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.PanelEigenschaften.SuspendLayout()
        Me.PanelEigenschaften1.SuspendLayout()
        Me.GBSpot.SuspendLayout()
        Me.GBPlatz.SuspendLayout()
        Me.GBRauch.SuspendLayout()
        Me.GBPfade.SuspendLayout()
        CType(Me.Pfade_PBOrange, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pfade_PVerb0.SuspendLayout()
        CType(Me.Pfade_PBLila, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GBKupplPnt.SuspendLayout()
        Me.GBKamera.SuspendLayout()
        Me.GBBbox.SuspendLayout()
        Me.GBAchse.SuspendLayout()
        Me.GBSplineHelper.SuspendLayout()
        Me.GBPfad.SuspendLayout()
        Me.GBSpline.SuspendLayout()
        Me.GBAllgemein.SuspendLayout()
        Me.GBMesh.SuspendLayout()
        CType(Me.Mesh_NUMax, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Mesh_NUMin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GBParent.SuspendLayout()
        Me.GBBones.SuspendLayout()
        Me.GBBel.SuspendLayout()
        Me.GBLicht.SuspendLayout()
        Me.GBMat.SuspendLayout()
        Me.GBAnimation.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Anim_PRBArt.SuspendLayout()
        Me.PanelTexture.SuspendLayout()
        CType(Me.PBTexture, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MSTexturen.SuspendLayout()
        Me.PanelObjekte.SuspendLayout()
        Me.TCObjekte.SuspendLayout()
        Me.TCObjektePMeshes.SuspendLayout()
        Me.CMSMeshes.SuspendLayout()
        Me.TCObjektePHelfer.SuspendLayout()
        Me.CMSHelfer.SuspendLayout()
        Me.TCObjektePLichter.SuspendLayout()
        Me.CMSLichter.SuspendLayout()
        Me.TCObjektePPfade.SuspendLayout()
        Me.CMSPfade.SuspendLayout()
        Me.GBSplinePfad.SuspendLayout()
        Me.SuspendLayout()
        '
        'SS1
        '
        Me.SS1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.SS1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PBMain, Me.SSLBStatus, Me.TBTimer})
        Me.SS1.Location = New System.Drawing.Point(0, 1039)
        Me.SS1.Name = "SS1"
        Me.SS1.Size = New System.Drawing.Size(1264, 22)
        Me.SS1.TabIndex = 10
        Me.SS1.Text = "StatusStrip1"
        '
        'PBMain
        '
        Me.PBMain.Name = "PBMain"
        Me.PBMain.Size = New System.Drawing.Size(100, 16)
        Me.PBMain.Step = 1
        '
        'SSLBStatus
        '
        Me.SSLBStatus.Name = "SSLBStatus"
        Me.SSLBStatus.Size = New System.Drawing.Size(0, 17)
        '
        'TBTimer
        '
        Me.TBTimer.Name = "TBTimer"
        Me.TBTimer.Size = New System.Drawing.Size(1147, 17)
        Me.TBTimer.Spring = True
        Me.TBTimer.Text = "Timer"
        Me.TBTimer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'MS1
        '
        Me.MS1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MS1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DateiToolStripMenuItem, Me.BearbeitenToolStripMenuItem, Me.AnsichtToolStripMenuItem, Me.GitToolStripMenuItem, Me.ObjektToolStripMenuItem, Me.DevelopmentToolStripMenuItem, Me.ErstellenToolStripMenuItem, Me.ModifikationToolStripMenuItem, Me.SoundToolStripMenuItem, Me.ScriptToolStripMenuItem, Me.ImportierenToolStripMenuItem, Me.ExportiernToolStripMenuItem, Me.HilfeToolStripMenuItem, Me.TestToolStripMenuItem, Me.WagenteilToolStripMenuItem})
        Me.MS1.Location = New System.Drawing.Point(0, 0)
        Me.MS1.Name = "MS1"
        Me.MS1.Size = New System.Drawing.Size(1264, 24)
        Me.MS1.TabIndex = 11
        Me.MS1.Text = "MenuStrip1"
        '
        'DateiToolStripMenuItem
        '
        Me.DateiToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NeuToolStripMenuItem, Me.ToolStripMenuItem1, Me.ÖffnenToolStripMenuItem, Me.LetzteToolStripMenuItem, Me.NeuLadenToolStripMenuItem, Me.SpeichernToolStripMenuItem, Me.SpeichernUnterToolStripMenuItem, Me.PackenToolStripMenuItem, Me.ToolStripMenuItem6, Me.EinstellungenToolStripMenuItem, Me.ToolStripMenuItem2, Me.BeendenToolStripMenuItem})
        Me.DateiToolStripMenuItem.Name = "DateiToolStripMenuItem"
        Me.DateiToolStripMenuItem.Size = New System.Drawing.Size(46, 20)
        Me.DateiToolStripMenuItem.Text = "Datei"
        '
        'NeuToolStripMenuItem
        '
        Me.NeuToolStripMenuItem.Name = "NeuToolStripMenuItem"
        Me.NeuToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.NeuToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.NeuToolStripMenuItem.Text = "Neu"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(168, 6)
        '
        'ÖffnenToolStripMenuItem
        '
        Me.ÖffnenToolStripMenuItem.Name = "ÖffnenToolStripMenuItem"
        Me.ÖffnenToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.ÖffnenToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.ÖffnenToolStripMenuItem.Text = "Öffnen"
        '
        'LetzteToolStripMenuItem
        '
        Me.LetzteToolStripMenuItem.Name = "LetzteToolStripMenuItem"
        Me.LetzteToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.LetzteToolStripMenuItem.Text = "Zuletzt geöffnet..."
        '
        'NeuLadenToolStripMenuItem
        '
        Me.NeuLadenToolStripMenuItem.Name = "NeuLadenToolStripMenuItem"
        Me.NeuLadenToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.R), System.Windows.Forms.Keys)
        Me.NeuLadenToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.NeuLadenToolStripMenuItem.Text = "Neu laden"
        '
        'SpeichernToolStripMenuItem
        '
        Me.SpeichernToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AllesToolStripMenuItem1, Me.NurProjektbusovhscoToolStripMenuItem, Me.NurModelToolStripMenuItem, Me.NurCabinToolStripMenuItem, Me.NurPathsToolStripMenuItem, Me.NurToolUmgebungocdbToolStripMenuItem})
        Me.SpeichernToolStripMenuItem.Enabled = False
        Me.SpeichernToolStripMenuItem.Name = "SpeichernToolStripMenuItem"
        Me.SpeichernToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.SpeichernToolStripMenuItem.Text = "Speichern"
        '
        'AllesToolStripMenuItem1
        '
        Me.AllesToolStripMenuItem1.Name = "AllesToolStripMenuItem1"
        Me.AllesToolStripMenuItem1.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.AllesToolStripMenuItem1.Size = New System.Drawing.Size(260, 22)
        Me.AllesToolStripMenuItem1.Text = "Alles"
        '
        'NurProjektbusovhscoToolStripMenuItem
        '
        Me.NurProjektbusovhscoToolStripMenuItem.Name = "NurProjektbusovhscoToolStripMenuItem"
        Me.NurProjektbusovhscoToolStripMenuItem.Size = New System.Drawing.Size(260, 22)
        Me.NurProjektbusovhscoToolStripMenuItem.Text = "Nur Projekt (*.bus, *.ovh, *.sco *.sli)"
        '
        'NurModelToolStripMenuItem
        '
        Me.NurModelToolStripMenuItem.Name = "NurModelToolStripMenuItem"
        Me.NurModelToolStripMenuItem.Size = New System.Drawing.Size(260, 22)
        Me.NurModelToolStripMenuItem.Text = "Nur Model (model.cfg)"
        '
        'NurCabinToolStripMenuItem
        '
        Me.NurCabinToolStripMenuItem.Name = "NurCabinToolStripMenuItem"
        Me.NurCabinToolStripMenuItem.Size = New System.Drawing.Size(260, 22)
        Me.NurCabinToolStripMenuItem.Text = "Nur Sitz-/Stehplätze (cabin.cfg)"
        '
        'NurPathsToolStripMenuItem
        '
        Me.NurPathsToolStripMenuItem.Name = "NurPathsToolStripMenuItem"
        Me.NurPathsToolStripMenuItem.Size = New System.Drawing.Size(260, 22)
        Me.NurPathsToolStripMenuItem.Text = "Nur Pfade (path.cfg)"
        '
        'NurToolUmgebungocdbToolStripMenuItem
        '
        Me.NurToolUmgebungocdbToolStripMenuItem.Name = "NurToolUmgebungocdbToolStripMenuItem"
        Me.NurToolUmgebungocdbToolStripMenuItem.Size = New System.Drawing.Size(260, 22)
        Me.NurToolUmgebungocdbToolStripMenuItem.Text = "Nur Tool-Umgebung (*.ocdb)"
        '
        'SpeichernUnterToolStripMenuItem
        '
        Me.SpeichernUnterToolStripMenuItem.Name = "SpeichernUnterToolStripMenuItem"
        Me.SpeichernUnterToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.SpeichernUnterToolStripMenuItem.Text = "Speichern unter..."
        '
        'PackenToolStripMenuItem
        '
        Me.PackenToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RarArchivToolStripMenuItem, Me.LctLOTUSContentToolStripMenuItem})
        Me.PackenToolStripMenuItem.Enabled = False
        Me.PackenToolStripMenuItem.Name = "PackenToolStripMenuItem"
        Me.PackenToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.PackenToolStripMenuItem.Text = "Packen"
        '
        'RarArchivToolStripMenuItem
        '
        Me.RarArchivToolStripMenuItem.Name = "RarArchivToolStripMenuItem"
        Me.RarArchivToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.RarArchivToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
        Me.RarArchivToolStripMenuItem.Text = "*.rar Archiv"
        '
        'LctLOTUSContentToolStripMenuItem
        '
        Me.LctLOTUSContentToolStripMenuItem.Name = "LctLOTUSContentToolStripMenuItem"
        Me.LctLOTUSContentToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
        Me.LctLOTUSContentToolStripMenuItem.Text = "*.lob LOTUS-Objekt"
        '
        'ToolStripMenuItem6
        '
        Me.ToolStripMenuItem6.Name = "ToolStripMenuItem6"
        Me.ToolStripMenuItem6.Size = New System.Drawing.Size(168, 6)
        '
        'EinstellungenToolStripMenuItem
        '
        Me.EinstellungenToolStripMenuItem.Name = "EinstellungenToolStripMenuItem"
        Me.EinstellungenToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.EinstellungenToolStripMenuItem.Text = "Einstellungen"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(168, 6)
        '
        'BeendenToolStripMenuItem
        '
        Me.BeendenToolStripMenuItem.Name = "BeendenToolStripMenuItem"
        Me.BeendenToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.BeendenToolStripMenuItem.Text = "Beenden"
        '
        'BearbeitenToolStripMenuItem
        '
        Me.BearbeitenToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SuchenToolStripMenuItem, Me.ToolStripMenuItem18, Me.EigenschaftenToolStripMenuItem, Me.TextToolStripMenuItem, Me.ToolStripMenuItem13, Me.AmpelphaseToolStripMenuItem, Me.HofDateienToolStripMenuItem, Me.RepaintToolStripMenuItem})
        Me.BearbeitenToolStripMenuItem.Name = "BearbeitenToolStripMenuItem"
        Me.BearbeitenToolStripMenuItem.Size = New System.Drawing.Size(75, 20)
        Me.BearbeitenToolStripMenuItem.Text = "Bearbeiten"
        '
        'SuchenToolStripMenuItem
        '
        Me.SuchenToolStripMenuItem.Name = "SuchenToolStripMenuItem"
        Me.SuchenToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.SuchenToolStripMenuItem.Size = New System.Drawing.Size(273, 22)
        Me.SuchenToolStripMenuItem.Text = "Suchen"
        '
        'ToolStripMenuItem18
        '
        Me.ToolStripMenuItem18.Name = "ToolStripMenuItem18"
        Me.ToolStripMenuItem18.Size = New System.Drawing.Size(270, 6)
        '
        'EigenschaftenToolStripMenuItem
        '
        Me.EigenschaftenToolStripMenuItem.Name = "EigenschaftenToolStripMenuItem"
        Me.EigenschaftenToolStripMenuItem.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.E), System.Windows.Forms.Keys)
        Me.EigenschaftenToolStripMenuItem.Size = New System.Drawing.Size(273, 22)
        Me.EigenschaftenToolStripMenuItem.Text = "Eigenschaften"
        '
        'TextToolStripMenuItem
        '
        Me.TextToolStripMenuItem.Name = "TextToolStripMenuItem"
        Me.TextToolStripMenuItem.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.T), System.Windows.Forms.Keys)
        Me.TextToolStripMenuItem.Size = New System.Drawing.Size(273, 22)
        Me.TextToolStripMenuItem.Text = "Text-Texturen"
        '
        'ToolStripMenuItem13
        '
        Me.ToolStripMenuItem13.Name = "ToolStripMenuItem13"
        Me.ToolStripMenuItem13.Size = New System.Drawing.Size(270, 6)
        '
        'AmpelphaseToolStripMenuItem
        '
        Me.AmpelphaseToolStripMenuItem.Enabled = False
        Me.AmpelphaseToolStripMenuItem.Name = "AmpelphaseToolStripMenuItem"
        Me.AmpelphaseToolStripMenuItem.Size = New System.Drawing.Size(273, 22)
        Me.AmpelphaseToolStripMenuItem.Text = "Ampelphasen"
        '
        'HofDateienToolStripMenuItem
        '
        Me.HofDateienToolStripMenuItem.Enabled = False
        Me.HofDateienToolStripMenuItem.Name = "HofDateienToolStripMenuItem"
        Me.HofDateienToolStripMenuItem.Size = New System.Drawing.Size(273, 22)
        Me.HofDateienToolStripMenuItem.Text = "Hof-Dateien"
        '
        'RepaintToolStripMenuItem
        '
        Me.RepaintToolStripMenuItem.Enabled = False
        Me.RepaintToolStripMenuItem.Name = "RepaintToolStripMenuItem"
        Me.RepaintToolStripMenuItem.Size = New System.Drawing.Size(273, 22)
        Me.RepaintToolStripMenuItem.Text = "Repaints"
        '
        'AnsichtToolStripMenuItem
        '
        Me.AnsichtToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.WireframeToolStripMenuItem, Me.GitterToolStripMenuItem, Me.AlphaAnzeigenToolStripMenuItem, Me.ToolStripMenuItem5, Me.FensterToolStripMenuItem, Me.DarstellungToolStripMenuItem, Me.PerspektiveToolStripMenuItem, Me.ToolStripMenuItem7, Me.LODObjektToolStripMenuItem, Me.ToolStripMenuItem14, Me.PfadeInOriginalbreiteToolStripMenuItem, Me.ToolStripMenuItem9, Me.LogfileToolStripMenuItem})
        Me.AnsichtToolStripMenuItem.Name = "AnsichtToolStripMenuItem"
        Me.AnsichtToolStripMenuItem.Size = New System.Drawing.Size(59, 20)
        Me.AnsichtToolStripMenuItem.Text = "Ansicht"
        '
        'WireframeToolStripMenuItem
        '
        Me.WireframeToolStripMenuItem.Name = "WireframeToolStripMenuItem"
        Me.WireframeToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.WireframeToolStripMenuItem.Text = "Wireframe"
        '
        'GitterToolStripMenuItem
        '
        Me.GitterToolStripMenuItem.Name = "GitterToolStripMenuItem"
        Me.GitterToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.GitterToolStripMenuItem.Text = "Gitter"
        '
        'AlphaAnzeigenToolStripMenuItem
        '
        Me.AlphaAnzeigenToolStripMenuItem.Name = "AlphaAnzeigenToolStripMenuItem"
        Me.AlphaAnzeigenToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.AlphaAnzeigenToolStripMenuItem.Text = "Alpha anzeigen"
        Me.AlphaAnzeigenToolStripMenuItem.Visible = False
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(189, 6)
        '
        'FensterToolStripMenuItem
        '
        Me.FensterToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ObjekteToolStripMenuItem, Me.TextureToolStripMenuItem, Me.EigenschaftenFensterToolStripMenuItem, Me.TimelineLogFensterToolStripMenuItem})
        Me.FensterToolStripMenuItem.Name = "FensterToolStripMenuItem"
        Me.FensterToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.FensterToolStripMenuItem.Text = "Fenster"
        '
        'ObjekteToolStripMenuItem
        '
        Me.ObjekteToolStripMenuItem.Name = "ObjekteToolStripMenuItem"
        Me.ObjekteToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F6
        Me.ObjekteToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.ObjekteToolStripMenuItem.Text = "Objekte (Fenster)"
        '
        'TextureToolStripMenuItem
        '
        Me.TextureToolStripMenuItem.Name = "TextureToolStripMenuItem"
        Me.TextureToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F7
        Me.TextureToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.TextureToolStripMenuItem.Text = "Texturen (Fenster)"
        '
        'EigenschaftenFensterToolStripMenuItem
        '
        Me.EigenschaftenFensterToolStripMenuItem.Name = "EigenschaftenFensterToolStripMenuItem"
        Me.EigenschaftenFensterToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F8
        Me.EigenschaftenFensterToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.EigenschaftenFensterToolStripMenuItem.Text = "Eigenschaften (Fenster)"
        '
        'TimelineLogFensterToolStripMenuItem
        '
        Me.TimelineLogFensterToolStripMenuItem.Name = "TimelineLogFensterToolStripMenuItem"
        Me.TimelineLogFensterToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.TimelineLogFensterToolStripMenuItem.Text = "Timeline / Log (Fenster)"
        '
        'DarstellungToolStripMenuItem
        '
        Me.DarstellungToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AllesToolStripMenuItem, Me.OMSIAußenToolStripMenuItem, Me.OMSIInnenToolStripMenuItem, Me.OMSIAIBusToolStripMenuItem})
        Me.DarstellungToolStripMenuItem.Name = "DarstellungToolStripMenuItem"
        Me.DarstellungToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.DarstellungToolStripMenuItem.Text = "Darstellung"
        '
        'AllesToolStripMenuItem
        '
        Me.AllesToolStripMenuItem.Checked = True
        Me.AllesToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.AllesToolStripMenuItem.Name = "AllesToolStripMenuItem"
        Me.AllesToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
        Me.AllesToolStripMenuItem.Text = "Alles"
        '
        'OMSIAußenToolStripMenuItem
        '
        Me.OMSIAußenToolStripMenuItem.Name = "OMSIAußenToolStripMenuItem"
        Me.OMSIAußenToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
        Me.OMSIAußenToolStripMenuItem.Text = "OMSI-Außen"
        '
        'OMSIInnenToolStripMenuItem
        '
        Me.OMSIInnenToolStripMenuItem.Name = "OMSIInnenToolStripMenuItem"
        Me.OMSIInnenToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
        Me.OMSIInnenToolStripMenuItem.Text = "OMSI-Innen"
        '
        'OMSIAIBusToolStripMenuItem
        '
        Me.OMSIAIBusToolStripMenuItem.Name = "OMSIAIBusToolStripMenuItem"
        Me.OMSIAIBusToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
        Me.OMSIAIBusToolStripMenuItem.Text = "OMSI-AI-Bus"
        '
        'PerspektiveToolStripMenuItem
        '
        Me.PerspektiveToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FahrrersichtToolStripMenuItem, Me.PassagiersichtToolStripMenuItem, Me.AußenansichtToolStripMenuItem, Me.FreieKameraToolStripMenuItem})
        Me.PerspektiveToolStripMenuItem.Name = "PerspektiveToolStripMenuItem"
        Me.PerspektiveToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.PerspektiveToolStripMenuItem.Text = "Perspektive"
        '
        'FahrrersichtToolStripMenuItem
        '
        Me.FahrrersichtToolStripMenuItem.Name = "FahrrersichtToolStripMenuItem"
        Me.FahrrersichtToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1
        Me.FahrrersichtToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.FahrrersichtToolStripMenuItem.Text = "Fahrrersicht"
        '
        'PassagiersichtToolStripMenuItem
        '
        Me.PassagiersichtToolStripMenuItem.Name = "PassagiersichtToolStripMenuItem"
        Me.PassagiersichtToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me.PassagiersichtToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.PassagiersichtToolStripMenuItem.Text = "Passagiersicht"
        '
        'AußenansichtToolStripMenuItem
        '
        Me.AußenansichtToolStripMenuItem.Name = "AußenansichtToolStripMenuItem"
        Me.AußenansichtToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.AußenansichtToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.AußenansichtToolStripMenuItem.Text = "Außenansicht"
        '
        'FreieKameraToolStripMenuItem
        '
        Me.FreieKameraToolStripMenuItem.Name = "FreieKameraToolStripMenuItem"
        Me.FreieKameraToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.FreieKameraToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.FreieKameraToolStripMenuItem.Text = "Freie Kamera"
        '
        'ToolStripMenuItem7
        '
        Me.ToolStripMenuItem7.Name = "ToolStripMenuItem7"
        Me.ToolStripMenuItem7.Size = New System.Drawing.Size(189, 6)
        '
        'LODObjektToolStripMenuItem
        '
        Me.LODObjektToolStripMenuItem.Name = "LODObjektToolStripMenuItem"
        Me.LODObjektToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.LODObjektToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.LODObjektToolStripMenuItem.Text = "LOD-Filter"
        '
        'ToolStripMenuItem14
        '
        Me.ToolStripMenuItem14.Name = "ToolStripMenuItem14"
        Me.ToolStripMenuItem14.Size = New System.Drawing.Size(189, 6)
        '
        'PfadeInOriginalbreiteToolStripMenuItem
        '
        Me.PfadeInOriginalbreiteToolStripMenuItem.Name = "PfadeInOriginalbreiteToolStripMenuItem"
        Me.PfadeInOriginalbreiteToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.PfadeInOriginalbreiteToolStripMenuItem.Text = "Pfade in Originalbreite"
        '
        'ToolStripMenuItem9
        '
        Me.ToolStripMenuItem9.Name = "ToolStripMenuItem9"
        Me.ToolStripMenuItem9.Size = New System.Drawing.Size(189, 6)
        '
        'LogfileToolStripMenuItem
        '
        Me.LogfileToolStripMenuItem.Name = "LogfileToolStripMenuItem"
        Me.LogfileToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.L), System.Windows.Forms.Keys)
        Me.LogfileToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.LogfileToolStripMenuItem.Text = "Logfile"
        '
        'GitToolStripMenuItem
        '
        Me.GitToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NeuesRepositoryToolStripMenuItem, Me.NeuesRepoKlonenToolStripMenuItem, Me.ToolStripMenuItem8, Me.CommitToolStripMenuItem, Me.PullToolStripMenuItem, Me.PushToolStripMenuItem, Me.SyncToolStripMenuItem, Me.ToolStripMenuItem19, Me.UnGitToolStripMenuItem})
        Me.GitToolStripMenuItem.Name = "GitToolStripMenuItem"
        Me.GitToolStripMenuItem.Size = New System.Drawing.Size(34, 20)
        Me.GitToolStripMenuItem.Text = "Git"
        Me.GitToolStripMenuItem.Visible = False
        '
        'NeuesRepositoryToolStripMenuItem
        '
        Me.NeuesRepositoryToolStripMenuItem.Image = CType(resources.GetObject("NeuesRepositoryToolStripMenuItem.Image"), System.Drawing.Image)
        Me.NeuesRepositoryToolStripMenuItem.Name = "NeuesRepositoryToolStripMenuItem"
        Me.NeuesRepositoryToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
        Me.NeuesRepositoryToolStripMenuItem.Text = "Neues Repository"
        '
        'NeuesRepoKlonenToolStripMenuItem
        '
        Me.NeuesRepoKlonenToolStripMenuItem.Image = CType(resources.GetObject("NeuesRepoKlonenToolStripMenuItem.Image"), System.Drawing.Image)
        Me.NeuesRepoKlonenToolStripMenuItem.Name = "NeuesRepoKlonenToolStripMenuItem"
        Me.NeuesRepoKlonenToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
        Me.NeuesRepoKlonenToolStripMenuItem.Text = "Repository klonen"
        '
        'ToolStripMenuItem8
        '
        Me.ToolStripMenuItem8.Name = "ToolStripMenuItem8"
        Me.ToolStripMenuItem8.Size = New System.Drawing.Size(166, 6)
        '
        'CommitToolStripMenuItem
        '
        Me.CommitToolStripMenuItem.Image = CType(resources.GetObject("CommitToolStripMenuItem.Image"), System.Drawing.Image)
        Me.CommitToolStripMenuItem.Name = "CommitToolStripMenuItem"
        Me.CommitToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
        Me.CommitToolStripMenuItem.Text = "Commit"
        '
        'PullToolStripMenuItem
        '
        Me.PullToolStripMenuItem.Image = CType(resources.GetObject("PullToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PullToolStripMenuItem.Name = "PullToolStripMenuItem"
        Me.PullToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
        Me.PullToolStripMenuItem.Text = "Pull"
        '
        'PushToolStripMenuItem
        '
        Me.PushToolStripMenuItem.Image = CType(resources.GetObject("PushToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PushToolStripMenuItem.Name = "PushToolStripMenuItem"
        Me.PushToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
        Me.PushToolStripMenuItem.Text = "Push"
        '
        'SyncToolStripMenuItem
        '
        Me.SyncToolStripMenuItem.Image = CType(resources.GetObject("SyncToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SyncToolStripMenuItem.Name = "SyncToolStripMenuItem"
        Me.SyncToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
        Me.SyncToolStripMenuItem.Text = "Sync"
        '
        'ToolStripMenuItem19
        '
        Me.ToolStripMenuItem19.Name = "ToolStripMenuItem19"
        Me.ToolStripMenuItem19.Size = New System.Drawing.Size(166, 6)
        '
        'UnGitToolStripMenuItem
        '
        Me.UnGitToolStripMenuItem.Image = CType(resources.GetObject("UnGitToolStripMenuItem.Image"), System.Drawing.Image)
        Me.UnGitToolStripMenuItem.Name = "UnGitToolStripMenuItem"
        Me.UnGitToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
        Me.UnGitToolStripMenuItem.Text = "UnGit"
        Me.UnGitToolStripMenuItem.Visible = False
        '
        'ObjektToolStripMenuItem
        '
        Me.ObjektToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EntfernenToolStripMenuItem2, Me.VersteckenToolStripMenuItem})
        Me.ObjektToolStripMenuItem.Name = "ObjektToolStripMenuItem"
        Me.ObjektToolStripMenuItem.Size = New System.Drawing.Size(54, 20)
        Me.ObjektToolStripMenuItem.Text = "Objekt"
        Me.ObjektToolStripMenuItem.Visible = False
        '
        'EntfernenToolStripMenuItem2
        '
        Me.EntfernenToolStripMenuItem2.Name = "EntfernenToolStripMenuItem2"
        Me.EntfernenToolStripMenuItem2.ShortcutKeys = System.Windows.Forms.Keys.Delete
        Me.EntfernenToolStripMenuItem2.Size = New System.Drawing.Size(175, 22)
        Me.EntfernenToolStripMenuItem2.Text = "Entfernen"
        '
        'VersteckenToolStripMenuItem
        '
        Me.VersteckenToolStripMenuItem.Name = "VersteckenToolStripMenuItem"
        Me.VersteckenToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.H), System.Windows.Forms.Keys)
        Me.VersteckenToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
        Me.VersteckenToolStripMenuItem.Text = "Verstecken"
        '
        'DevelopmentToolStripMenuItem
        '
        Me.DevelopmentToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToDoListToolStripMenuItem, Me.ReadmetxtToolStripMenuItem, Me.RechnerToolStripMenuItem, Me.ToolStripMenuItem17, Me.StatistikToolStripMenuItem, Me.ToolStripMenuItem12, Me.ProjektordnerÖffnenToolStripMenuItem})
        Me.DevelopmentToolStripMenuItem.Name = "DevelopmentToolStripMenuItem"
        Me.DevelopmentToolStripMenuItem.Size = New System.Drawing.Size(90, 20)
        Me.DevelopmentToolStripMenuItem.Text = "Development"
        '
        'ToDoListToolStripMenuItem
        '
        Me.ToDoListToolStripMenuItem.Name = "ToDoListToolStripMenuItem"
        Me.ToDoListToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
        Me.ToDoListToolStripMenuItem.Text = "To-Do-List"
        '
        'ReadmetxtToolStripMenuItem
        '
        Me.ReadmetxtToolStripMenuItem.Name = "ReadmetxtToolStripMenuItem"
        Me.ReadmetxtToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
        Me.ReadmetxtToolStripMenuItem.Text = "Readme.txt"
        '
        'RechnerToolStripMenuItem
        '
        Me.RechnerToolStripMenuItem.Name = "RechnerToolStripMenuItem"
        Me.RechnerToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
        Me.RechnerToolStripMenuItem.Text = "Rechner"
        '
        'ToolStripMenuItem17
        '
        Me.ToolStripMenuItem17.Name = "ToolStripMenuItem17"
        Me.ToolStripMenuItem17.Size = New System.Drawing.Size(225, 6)
        '
        'StatistikToolStripMenuItem
        '
        Me.StatistikToolStripMenuItem.Enabled = False
        Me.StatistikToolStripMenuItem.Name = "StatistikToolStripMenuItem"
        Me.StatistikToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
        Me.StatistikToolStripMenuItem.Text = "Statistik"
        '
        'ToolStripMenuItem12
        '
        Me.ToolStripMenuItem12.Name = "ToolStripMenuItem12"
        Me.ToolStripMenuItem12.Size = New System.Drawing.Size(225, 6)
        '
        'ProjektordnerÖffnenToolStripMenuItem
        '
        Me.ProjektordnerÖffnenToolStripMenuItem.Name = "ProjektordnerÖffnenToolStripMenuItem"
        Me.ProjektordnerÖffnenToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D), System.Windows.Forms.Keys)
        Me.ProjektordnerÖffnenToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
        Me.ProjektordnerÖffnenToolStripMenuItem.Text = "Projektordner öffnen"
        '
        'ErstellenToolStripMenuItem
        '
        Me.ErstellenToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AchseToolStripMenuItem, Me.KameraToolStripMenuItem, Me.KupplungspunktToolStripMenuItem, Me.InnenlichtToolStripMenuItem, Me.RauchToolStripMenuItem, Me.SpiegelToolStripMenuItem, Me.SitzplatzToolStripMenuItem, Me.TicketblockToolStripMenuItem, Me.AttachpointsToolStripMenuItem, Me.SplinehelperToolStripMenuItem, Me.SpotToolStripMenuItem, Me.ToolStripMenuItem15, Me.LichtToolStripMenuItem, Me.PfadToolStripMenuItem})
        Me.ErstellenToolStripMenuItem.Name = "ErstellenToolStripMenuItem"
        Me.ErstellenToolStripMenuItem.Size = New System.Drawing.Size(63, 20)
        Me.ErstellenToolStripMenuItem.Text = "Erstellen"
        '
        'AchseToolStripMenuItem
        '
        Me.AchseToolStripMenuItem.Name = "AchseToolStripMenuItem"
        Me.AchseToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.AchseToolStripMenuItem.Text = "Achse"
        '
        'KameraToolStripMenuItem
        '
        Me.KameraToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FahrerkameraToolStripMenuItem, Me.FahrgastkameraToolStripMenuItem})
        Me.KameraToolStripMenuItem.Name = "KameraToolStripMenuItem"
        Me.KameraToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.KameraToolStripMenuItem.Text = "Kamera"
        '
        'FahrerkameraToolStripMenuItem
        '
        Me.FahrerkameraToolStripMenuItem.Name = "FahrerkameraToolStripMenuItem"
        Me.FahrerkameraToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.FahrerkameraToolStripMenuItem.Text = "Fahrerkamera"
        '
        'FahrgastkameraToolStripMenuItem
        '
        Me.FahrgastkameraToolStripMenuItem.Name = "FahrgastkameraToolStripMenuItem"
        Me.FahrgastkameraToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.FahrgastkameraToolStripMenuItem.Text = "Fahrgastkamera"
        '
        'KupplungspunktToolStripMenuItem
        '
        Me.KupplungspunktToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FrontToolStripMenuItem, Me.HeckToolStripMenuItem})
        Me.KupplungspunktToolStripMenuItem.Name = "KupplungspunktToolStripMenuItem"
        Me.KupplungspunktToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.KupplungspunktToolStripMenuItem.Text = "Kupplungspunkt"
        '
        'FrontToolStripMenuItem
        '
        Me.FrontToolStripMenuItem.Name = "FrontToolStripMenuItem"
        Me.FrontToolStripMenuItem.Size = New System.Drawing.Size(102, 22)
        Me.FrontToolStripMenuItem.Text = "Front"
        '
        'HeckToolStripMenuItem
        '
        Me.HeckToolStripMenuItem.Name = "HeckToolStripMenuItem"
        Me.HeckToolStripMenuItem.Size = New System.Drawing.Size(102, 22)
        Me.HeckToolStripMenuItem.Text = "Heck"
        '
        'InnenlichtToolStripMenuItem
        '
        Me.InnenlichtToolStripMenuItem.Name = "InnenlichtToolStripMenuItem"
        Me.InnenlichtToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.InnenlichtToolStripMenuItem.Text = "Innenlicht"
        '
        'RauchToolStripMenuItem
        '
        Me.RauchToolStripMenuItem.Name = "RauchToolStripMenuItem"
        Me.RauchToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.RauchToolStripMenuItem.Text = "Rauch"
        '
        'SpiegelToolStripMenuItem
        '
        Me.SpiegelToolStripMenuItem.Name = "SpiegelToolStripMenuItem"
        Me.SpiegelToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.SpiegelToolStripMenuItem.Text = "Spiegel"
        '
        'SitzplatzToolStripMenuItem
        '
        Me.SitzplatzToolStripMenuItem.Name = "SitzplatzToolStripMenuItem"
        Me.SitzplatzToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.SitzplatzToolStripMenuItem.Text = "Sitz-/ Stehplatz"
        '
        'TicketblockToolStripMenuItem
        '
        Me.TicketblockToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EntwerterToolStripMenuItem, Me.TicketblockToolStripMenuItem1, Me.RückgabefeldToolStripMenuItem, Me.GeldrückgabeToolStripMenuItem})
        Me.TicketblockToolStripMenuItem.Name = "TicketblockToolStripMenuItem"
        Me.TicketblockToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.TicketblockToolStripMenuItem.Text = "Tickes"
        '
        'EntwerterToolStripMenuItem
        '
        Me.EntwerterToolStripMenuItem.Name = "EntwerterToolStripMenuItem"
        Me.EntwerterToolStripMenuItem.Size = New System.Drawing.Size(147, 22)
        Me.EntwerterToolStripMenuItem.Text = "Entwerter"
        '
        'TicketblockToolStripMenuItem1
        '
        Me.TicketblockToolStripMenuItem1.Name = "TicketblockToolStripMenuItem1"
        Me.TicketblockToolStripMenuItem1.Size = New System.Drawing.Size(147, 22)
        Me.TicketblockToolStripMenuItem1.Text = "Ticketblock"
        '
        'RückgabefeldToolStripMenuItem
        '
        Me.RückgabefeldToolStripMenuItem.Name = "RückgabefeldToolStripMenuItem"
        Me.RückgabefeldToolStripMenuItem.Size = New System.Drawing.Size(147, 22)
        Me.RückgabefeldToolStripMenuItem.Text = "Geldablage"
        '
        'GeldrückgabeToolStripMenuItem
        '
        Me.GeldrückgabeToolStripMenuItem.Name = "GeldrückgabeToolStripMenuItem"
        Me.GeldrückgabeToolStripMenuItem.Size = New System.Drawing.Size(147, 22)
        Me.GeldrückgabeToolStripMenuItem.Text = "Geldrückgabe"
        '
        'AttachpointsToolStripMenuItem
        '
        Me.AttachpointsToolStripMenuItem.Name = "AttachpointsToolStripMenuItem"
        Me.AttachpointsToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.AttachpointsToolStripMenuItem.Text = "Attachpoint"
        '
        'SplinehelperToolStripMenuItem
        '
        Me.SplinehelperToolStripMenuItem.Enabled = False
        Me.SplinehelperToolStripMenuItem.Name = "SplinehelperToolStripMenuItem"
        Me.SplinehelperToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.SplinehelperToolStripMenuItem.Text = "Splinehelper"
        '
        'SpotToolStripMenuItem
        '
        Me.SpotToolStripMenuItem.Name = "SpotToolStripMenuItem"
        Me.SpotToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.SpotToolStripMenuItem.Text = "Spot"
        '
        'ToolStripMenuItem15
        '
        Me.ToolStripMenuItem15.Name = "ToolStripMenuItem15"
        Me.ToolStripMenuItem15.Size = New System.Drawing.Size(159, 6)
        '
        'LichtToolStripMenuItem
        '
        Me.LichtToolStripMenuItem.Name = "LichtToolStripMenuItem"
        Me.LichtToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.LichtToolStripMenuItem.Text = "Licht"
        '
        'PfadToolStripMenuItem
        '
        Me.PfadToolStripMenuItem.Name = "PfadToolStripMenuItem"
        Me.PfadToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.PfadToolStripMenuItem.Text = "Pfad(punkt)"
        '
        'ModifikationToolStripMenuItem
        '
        Me.ModifikationToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.VeränderungAufnehmenToolStripMenuItem, Me.MitOriginalVergleichenToolStripMenuItem})
        Me.ModifikationToolStripMenuItem.Name = "ModifikationToolStripMenuItem"
        Me.ModifikationToolStripMenuItem.Size = New System.Drawing.Size(87, 20)
        Me.ModifikationToolStripMenuItem.Text = "Modifikation"
        Me.ModifikationToolStripMenuItem.Visible = False
        '
        'VeränderungAufnehmenToolStripMenuItem
        '
        Me.VeränderungAufnehmenToolStripMenuItem.Name = "VeränderungAufnehmenToolStripMenuItem"
        Me.VeränderungAufnehmenToolStripMenuItem.Size = New System.Drawing.Size(205, 22)
        Me.VeränderungAufnehmenToolStripMenuItem.Text = "Veränderung aufnehmen"
        '
        'MitOriginalVergleichenToolStripMenuItem
        '
        Me.MitOriginalVergleichenToolStripMenuItem.Name = "MitOriginalVergleichenToolStripMenuItem"
        Me.MitOriginalVergleichenToolStripMenuItem.Size = New System.Drawing.Size(205, 22)
        Me.MitOriginalVergleichenToolStripMenuItem.Text = "Mit original vergleichen"
        '
        'SoundToolStripMenuItem
        '
        Me.SoundToolStripMenuItem.Name = "SoundToolStripMenuItem"
        Me.SoundToolStripMenuItem.Size = New System.Drawing.Size(53, 20)
        Me.SoundToolStripMenuItem.Text = "Sound"
        '
        'ScriptToolStripMenuItem
        '
        Me.ScriptToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.VarlistsToolStripMenuItem, Me.StringvarlistToolStripMenuItem, Me.ScriptsToolStripMenuItem, Me.ConstfilesToolStripMenuItem, Me.ToolStripMenuItem10, Me.VariablenTestToolStripMenuItem})
        Me.ScriptToolStripMenuItem.Name = "ScriptToolStripMenuItem"
        Me.ScriptToolStripMenuItem.Size = New System.Drawing.Size(49, 20)
        Me.ScriptToolStripMenuItem.Text = "Script"
        '
        'VarlistsToolStripMenuItem
        '
        Me.VarlistsToolStripMenuItem.Name = "VarlistsToolStripMenuItem"
        Me.VarlistsToolStripMenuItem.Size = New System.Drawing.Size(147, 22)
        Me.VarlistsToolStripMenuItem.Text = "Varlists"
        '
        'StringvarlistToolStripMenuItem
        '
        Me.StringvarlistToolStripMenuItem.Name = "StringvarlistToolStripMenuItem"
        Me.StringvarlistToolStripMenuItem.Size = New System.Drawing.Size(147, 22)
        Me.StringvarlistToolStripMenuItem.Text = "Stringvarlsits"
        '
        'ScriptsToolStripMenuItem
        '
        Me.ScriptsToolStripMenuItem.Name = "ScriptsToolStripMenuItem"
        Me.ScriptsToolStripMenuItem.Size = New System.Drawing.Size(147, 22)
        Me.ScriptsToolStripMenuItem.Text = "Scripts"
        '
        'ConstfilesToolStripMenuItem
        '
        Me.ConstfilesToolStripMenuItem.Name = "ConstfilesToolStripMenuItem"
        Me.ConstfilesToolStripMenuItem.Size = New System.Drawing.Size(147, 22)
        Me.ConstfilesToolStripMenuItem.Text = "Constfiles"
        '
        'ToolStripMenuItem10
        '
        Me.ToolStripMenuItem10.Name = "ToolStripMenuItem10"
        Me.ToolStripMenuItem10.Size = New System.Drawing.Size(144, 6)
        '
        'VariablenTestToolStripMenuItem
        '
        Me.VariablenTestToolStripMenuItem.Name = "VariablenTestToolStripMenuItem"
        Me.VariablenTestToolStripMenuItem.Size = New System.Drawing.Size(147, 22)
        Me.VariablenTestToolStripMenuItem.Text = "Variablen-Test"
        '
        'ImportierenToolStripMenuItem
        '
        Me.ImportierenToolStripMenuItem.Name = "ImportierenToolStripMenuItem"
        Me.ImportierenToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.I), System.Windows.Forms.Keys)
        Me.ImportierenToolStripMenuItem.Size = New System.Drawing.Size(55, 20)
        Me.ImportierenToolStripMenuItem.Text = "Import"
        '
        'ExportiernToolStripMenuItem
        '
        Me.ExportiernToolStripMenuItem.Name = "ExportiernToolStripMenuItem"
        Me.ExportiernToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.E), System.Windows.Forms.Keys)
        Me.ExportiernToolStripMenuItem.Size = New System.Drawing.Size(53, 20)
        Me.ExportiernToolStripMenuItem.Text = "Export"
        '
        'HilfeToolStripMenuItem
        '
        Me.HilfeToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ForumToolStripMenuItem, Me.ForumToolStripMenuItem1, Me.WebseiteToolStripMenuItem, Me.LokaleHilfeToolStripMenuItem})
        Me.HilfeToolStripMenuItem.Name = "HilfeToolStripMenuItem"
        Me.HilfeToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HilfeToolStripMenuItem.Text = "Hilfe"
        '
        'ForumToolStripMenuItem
        '
        Me.ForumToolStripMenuItem.Name = "ForumToolStripMenuItem"
        Me.ForumToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.ForumToolStripMenuItem.Text = "Info"
        '
        'ForumToolStripMenuItem1
        '
        Me.ForumToolStripMenuItem1.Name = "ForumToolStripMenuItem1"
        Me.ForumToolStripMenuItem1.Size = New System.Drawing.Size(136, 22)
        Me.ForumToolStripMenuItem1.Text = "Forum"
        '
        'WebseiteToolStripMenuItem
        '
        Me.WebseiteToolStripMenuItem.Name = "WebseiteToolStripMenuItem"
        Me.WebseiteToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.WebseiteToolStripMenuItem.Text = "Webseite"
        '
        'LokaleHilfeToolStripMenuItem
        '
        Me.LokaleHilfeToolStripMenuItem.Name = "LokaleHilfeToolStripMenuItem"
        Me.LokaleHilfeToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.LokaleHilfeToolStripMenuItem.Text = "Lokale Hilfe"
        '
        'TestToolStripMenuItem
        '
        Me.TestToolStripMenuItem.Name = "TestToolStripMenuItem"
        Me.TestToolStripMenuItem.Size = New System.Drawing.Size(39, 20)
        Me.TestToolStripMenuItem.Text = "Test"
        Me.TestToolStripMenuItem.Visible = False
        '
        'WagenteilToolStripMenuItem
        '
        Me.WagenteilToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.WagenteilToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NächsterWagenToolStripMenuItem, Me.VorherigerWagenToolStripMenuItem})
        Me.WagenteilToolStripMenuItem.Name = "WagenteilToolStripMenuItem"
        Me.WagenteilToolStripMenuItem.Size = New System.Drawing.Size(72, 20)
        Me.WagenteilToolStripMenuItem.Text = "Wagenteil"
        Me.WagenteilToolStripMenuItem.Visible = False
        '
        'NächsterWagenToolStripMenuItem
        '
        Me.NächsterWagenToolStripMenuItem.Enabled = False
        Me.NächsterWagenToolStripMenuItem.Name = "NächsterWagenToolStripMenuItem"
        Me.NächsterWagenToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Right), System.Windows.Forms.Keys)
        Me.NächsterWagenToolStripMenuItem.Size = New System.Drawing.Size(224, 22)
        Me.NächsterWagenToolStripMenuItem.Text = "nächster Wagen"
        '
        'VorherigerWagenToolStripMenuItem
        '
        Me.VorherigerWagenToolStripMenuItem.Enabled = False
        Me.VorherigerWagenToolStripMenuItem.Name = "VorherigerWagenToolStripMenuItem"
        Me.VorherigerWagenToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Left), System.Windows.Forms.Keys)
        Me.VorherigerWagenToolStripMenuItem.Size = New System.Drawing.Size(224, 22)
        Me.VorherigerWagenToolStripMenuItem.Text = "vorheriger Wagen"
        '
        'PanelMain
        '
        Me.PanelMain.Controls.Add(Me.PanelTimeline)
        Me.PanelMain.Controls.Add(Me.PanelEigenschaften)
        Me.PanelMain.Controls.Add(Me.PanelTexture)
        Me.PanelMain.Controls.Add(Me.PanelObjekte)
        Me.PanelMain.Controls.Add(Me.GlMain)
        Me.PanelMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelMain.Location = New System.Drawing.Point(0, 24)
        Me.PanelMain.Name = "PanelMain"
        Me.PanelMain.Size = New System.Drawing.Size(1264, 1015)
        Me.PanelMain.TabIndex = 12
        '
        'PanelTimeline
        '
        Me.PanelTimeline.BackColor = System.Drawing.SystemColors.HotTrack
        Me.PanelTimeline.Controls.Add(Me.BTPanelTimelineClose)
        Me.PanelTimeline.Controls.Add(Me.TCTimeline)
        Me.PanelTimeline.Location = New System.Drawing.Point(61, 882)
        Me.PanelTimeline.Name = "PanelTimeline"
        Me.PanelTimeline.Padding = New System.Windows.Forms.Padding(3)
        Me.PanelTimeline.Size = New System.Drawing.Size(820, 130)
        Me.PanelTimeline.TabIndex = 3
        '
        'BTPanelTimelineClose
        '
        Me.BTPanelTimelineClose.BackColor = System.Drawing.Color.Transparent
        Me.BTPanelTimelineClose.FlatAppearance.BorderSize = 0
        Me.BTPanelTimelineClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red
        Me.BTPanelTimelineClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTPanelTimelineClose.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.BTPanelTimelineClose.Location = New System.Drawing.Point(799, 0)
        Me.BTPanelTimelineClose.Name = "BTPanelTimelineClose"
        Me.BTPanelTimelineClose.Padding = New System.Windows.Forms.Padding(2, 0, 0, 0)
        Me.BTPanelTimelineClose.Size = New System.Drawing.Size(19, 19)
        Me.BTPanelTimelineClose.TabIndex = 3
        Me.BTPanelTimelineClose.Text = "✕"
        Me.BTPanelTimelineClose.UseVisualStyleBackColor = False
        '
        'TCTimeline
        '
        Me.TCTimeline.Controls.Add(Me.TabPage1)
        Me.TCTimeline.Controls.Add(Me.TabPage3)
        Me.TCTimeline.Controls.Add(Me.TabPage2)
        Me.TCTimeline.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TCTimeline.Location = New System.Drawing.Point(3, 3)
        Me.TCTimeline.Margin = New System.Windows.Forms.Padding(0)
        Me.TCTimeline.Name = "TCTimeline"
        Me.TCTimeline.SelectedIndex = 0
        Me.TCTimeline.Size = New System.Drawing.Size(814, 124)
        Me.TCTimeline.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.TimelineCursor)
        Me.TabPage1.Controls.Add(Me.SLTimeline)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(806, 98)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Timeline"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TimelineCursor
        '
        Me.TimelineCursor.BackColor = System.Drawing.Color.Firebrick
        Me.TimelineCursor.Location = New System.Drawing.Point(3, 3)
        Me.TimelineCursor.Name = "TimelineCursor"
        Me.TimelineCursor.Size = New System.Drawing.Size(3, 92)
        Me.TimelineCursor.TabIndex = 1
        '
        'SLTimeline
        '
        Me.SLTimeline.Location = New System.Drawing.Point(3, 3)
        Me.SLTimeline.Name = "SLTimeline"
        Me.SLTimeline.Size = New System.Drawing.Size(803, 92)
        Me.SLTimeline.TabIndex = 0
        Me.SLTimeline.TabStop = False
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.TBScriptLog)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(806, 98)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Script-Log"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'TBScriptLog
        '
        Me.TBScriptLog.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TBScriptLog.Location = New System.Drawing.Point(3, 3)
        Me.TBScriptLog.Multiline = True
        Me.TBScriptLog.Name = "TBScriptLog"
        Me.TBScriptLog.ReadOnly = True
        Me.TBScriptLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TBScriptLog.Size = New System.Drawing.Size(800, 92)
        Me.TBScriptLog.TabIndex = 0
        Me.TBScriptLog.Text = "- nicht verfügbar -"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.TBLogfile)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(806, 98)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Logfile"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TBLogfile
        '
        Me.TBLogfile.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TBLogfile.Location = New System.Drawing.Point(3, 3)
        Me.TBLogfile.Multiline = True
        Me.TBLogfile.Name = "TBLogfile"
        Me.TBLogfile.ReadOnly = True
        Me.TBLogfile.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TBLogfile.Size = New System.Drawing.Size(800, 92)
        Me.TBLogfile.TabIndex = 0
        '
        'PanelEigenschaften
        '
        Me.PanelEigenschaften.BackColor = System.Drawing.SystemColors.HotTrack
        Me.PanelEigenschaften.Controls.Add(Me.BTEigenschafteResize)
        Me.PanelEigenschaften.Controls.Add(Me.BTPanelEingenschaftenClose)
        Me.PanelEigenschaften.Controls.Add(Me.PanelEigenschaften1)
        Me.PanelEigenschaften.Controls.Add(Me.LBEingenschaften)
        Me.PanelEigenschaften.Location = New System.Drawing.Point(901, 3)
        Me.PanelEigenschaften.Name = "PanelEigenschaften"
        Me.PanelEigenschaften.Size = New System.Drawing.Size(360, 1009)
        Me.PanelEigenschaften.TabIndex = 2
        Me.PanelEigenschaften.Visible = False
        '
        'BTEigenschafteResize
        '
        Me.BTEigenschafteResize.BackColor = System.Drawing.SystemColors.WindowText
        Me.BTEigenschafteResize.Cursor = System.Windows.Forms.Cursors.SizeNS
        Me.BTEigenschafteResize.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTEigenschafteResize.Location = New System.Drawing.Point(2, 1006)
        Me.BTEigenschafteResize.Name = "BTEigenschafteResize"
        Me.BTEigenschafteResize.Size = New System.Drawing.Size(355, 3)
        Me.BTEigenschafteResize.TabIndex = 11
        Me.BTEigenschafteResize.UseVisualStyleBackColor = False
        '
        'BTPanelEingenschaftenClose
        '
        Me.BTPanelEingenschaftenClose.BackColor = System.Drawing.Color.Transparent
        Me.BTPanelEingenschaftenClose.FlatAppearance.BorderSize = 0
        Me.BTPanelEingenschaftenClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red
        Me.BTPanelEingenschaftenClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTPanelEingenschaftenClose.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.BTPanelEingenschaftenClose.Location = New System.Drawing.Point(335, 3)
        Me.BTPanelEingenschaftenClose.Name = "BTPanelEingenschaftenClose"
        Me.BTPanelEingenschaftenClose.Padding = New System.Windows.Forms.Padding(2, 0, 0, 0)
        Me.BTPanelEingenschaftenClose.Size = New System.Drawing.Size(19, 19)
        Me.BTPanelEingenschaftenClose.TabIndex = 10
        Me.BTPanelEingenschaftenClose.Text = "✕"
        Me.BTPanelEingenschaftenClose.UseVisualStyleBackColor = False
        '
        'PanelEigenschaften1
        '
        Me.PanelEigenschaften1.AutoScroll = True
        Me.PanelEigenschaften1.BackColor = System.Drawing.SystemColors.Window
        Me.PanelEigenschaften1.Controls.Add(Me.GBSplinePfad)
        Me.PanelEigenschaften1.Controls.Add(Me.GBSpot)
        Me.PanelEigenschaften1.Controls.Add(Me.GBPlatz)
        Me.PanelEigenschaften1.Controls.Add(Me.GBRauch)
        Me.PanelEigenschaften1.Controls.Add(Me.GBPfade)
        Me.PanelEigenschaften1.Controls.Add(Me.GBKupplPnt)
        Me.PanelEigenschaften1.Controls.Add(Me.GBKamera)
        Me.PanelEigenschaften1.Controls.Add(Me.GBBbox)
        Me.PanelEigenschaften1.Controls.Add(Me.GBAchse)
        Me.PanelEigenschaften1.Controls.Add(Me.GBSplineHelper)
        Me.PanelEigenschaften1.Controls.Add(Me.GBPfad)
        Me.PanelEigenschaften1.Controls.Add(Me.GBSpline)
        Me.PanelEigenschaften1.Controls.Add(Me.GBAllgemein)
        Me.PanelEigenschaften1.Controls.Add(Me.GBMesh)
        Me.PanelEigenschaften1.Controls.Add(Me.GBParent)
        Me.PanelEigenschaften1.Controls.Add(Me.GBBones)
        Me.PanelEigenschaften1.Controls.Add(Me.GBBel)
        Me.PanelEigenschaften1.Controls.Add(Me.GBLicht)
        Me.PanelEigenschaften1.Controls.Add(Me.GBMat)
        Me.PanelEigenschaften1.Controls.Add(Me.GBAnimation)
        Me.PanelEigenschaften1.Location = New System.Drawing.Point(3, 25)
        Me.PanelEigenschaften1.Name = "PanelEigenschaften1"
        Me.PanelEigenschaften1.Size = New System.Drawing.Size(353, 975)
        Me.PanelEigenschaften1.TabIndex = 1
        '
        'GBSpot
        '
        Me.GBSpot.Controls.Add(Me.Label84)
        Me.GBSpot.Controls.Add(Me.Label82)
        Me.GBSpot.Controls.Add(Me.Label81)
        Me.GBSpot.Controls.Add(Me.Spot_TBAussen)
        Me.GBSpot.Controls.Add(Me.Spot_TBInner)
        Me.GBSpot.Controls.Add(Me.Label80)
        Me.GBSpot.Controls.Add(Me.Spot_PSRichtung)
        Me.GBSpot.Controls.Add(Me.Spot_TBLeuchtweite)
        Me.GBSpot.Controls.Add(Me.Label79)
        Me.GBSpot.Controls.Add(Me.Spot_CSFarbe)
        Me.GBSpot.Location = New System.Drawing.Point(4, 2941)
        Me.GBSpot.Name = "GBSpot"
        Me.GBSpot.Size = New System.Drawing.Size(328, 129)
        Me.GBSpot.TabIndex = 36
        Me.GBSpot.TabStop = False
        Me.GBSpot.Text = "Spot"
        '
        'Label84
        '
        Me.Label84.AutoSize = True
        Me.Label84.Location = New System.Drawing.Point(3, 51)
        Me.Label84.Name = "Label84"
        Me.Label84.Size = New System.Drawing.Size(34, 13)
        Me.Label84.TabIndex = 9
        Me.Label84.Text = "Farbe"
        '
        'Label82
        '
        Me.Label82.AutoSize = True
        Me.Label82.Location = New System.Drawing.Point(175, 78)
        Me.Label82.Name = "Label82"
        Me.Label82.Size = New System.Drawing.Size(38, 13)
        Me.Label82.TabIndex = 8
        Me.Label82.Text = "Außen"
        '
        'Label81
        '
        Me.Label81.AutoSize = True
        Me.Label81.Location = New System.Drawing.Point(4, 78)
        Me.Label81.Name = "Label81"
        Me.Label81.Size = New System.Drawing.Size(34, 13)
        Me.Label81.TabIndex = 7
        Me.Label81.Text = "Innen"
        '
        'Spot_TBAussen
        '
        Me.Spot_TBAussen.Location = New System.Drawing.Point(224, 75)
        Me.Spot_TBAussen.Name = "Spot_TBAussen"
        Me.Spot_TBAussen.Size = New System.Drawing.Size(100, 20)
        Me.Spot_TBAussen.TabIndex = 6
        '
        'Spot_TBInner
        '
        Me.Spot_TBInner.Location = New System.Drawing.Point(69, 75)
        Me.Spot_TBInner.Name = "Spot_TBInner"
        Me.Spot_TBInner.Size = New System.Drawing.Size(100, 20)
        Me.Spot_TBInner.TabIndex = 5
        '
        'Label80
        '
        Me.Label80.AutoSize = True
        Me.Label80.Location = New System.Drawing.Point(4, 22)
        Me.Label80.Name = "Label80"
        Me.Label80.Size = New System.Drawing.Size(50, 13)
        Me.Label80.TabIndex = 4
        Me.Label80.Text = "Richtung"
        '
        'Spot_TBLeuchtweite
        '
        Me.Spot_TBLeuchtweite.Location = New System.Drawing.Point(69, 101)
        Me.Spot_TBLeuchtweite.Name = "Spot_TBLeuchtweite"
        Me.Spot_TBLeuchtweite.Size = New System.Drawing.Size(100, 20)
        Me.Spot_TBLeuchtweite.TabIndex = 2
        '
        'Label79
        '
        Me.Label79.AutoSize = True
        Me.Label79.Location = New System.Drawing.Point(4, 104)
        Me.Label79.Name = "Label79"
        Me.Label79.Size = New System.Drawing.Size(65, 13)
        Me.Label79.TabIndex = 1
        Me.Label79.Text = "Leuchtweite"
        '
        'GBPlatz
        '
        Me.GBPlatz.Controls.Add(Me.Platz_MinMax)
        Me.GBPlatz.Controls.Add(Me.Platz_TBRichtung)
        Me.GBPlatz.Controls.Add(Me.Label57)
        Me.GBPlatz.Location = New System.Drawing.Point(4, 2650)
        Me.GBPlatz.Name = "GBPlatz"
        Me.GBPlatz.Size = New System.Drawing.Size(327, 100)
        Me.GBPlatz.TabIndex = 35
        Me.GBPlatz.TabStop = False
        Me.GBPlatz.Text = "Sitz-/ Stehplatz"
        '
        'Platz_MinMax
        '
        Me.Platz_MinMax.Location = New System.Drawing.Point(302, 0)
        Me.Platz_MinMax.Name = "Platz_MinMax"
        Me.Platz_MinMax.Size = New System.Drawing.Size(26, 19)
        Me.Platz_MinMax.TabIndex = 37
        Me.Platz_MinMax.Text = "-"
        Me.Platz_MinMax.UseVisualStyleBackColor = True
        '
        'Platz_TBRichtung
        '
        Me.Platz_TBRichtung.Location = New System.Drawing.Point(70, 19)
        Me.Platz_TBRichtung.Name = "Platz_TBRichtung"
        Me.Platz_TBRichtung.Size = New System.Drawing.Size(100, 20)
        Me.Platz_TBRichtung.TabIndex = 1
        '
        'Label57
        '
        Me.Label57.AutoSize = True
        Me.Label57.Location = New System.Drawing.Point(4, 22)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(50, 13)
        Me.Label57.TabIndex = 0
        Me.Label57.Text = "Richtung"
        '
        'GBRauch
        '
        Me.GBRauch.Controls.Add(Me.Rauch_MinMax)
        Me.GBRauch.Controls.Add(Me.Label56)
        Me.GBRauch.Controls.Add(Me.VarSelector1)
        Me.GBRauch.Controls.Add(Me.Rauch_Geschw)
        Me.GBRauch.Controls.Add(Me.Label55)
        Me.GBRauch.Controls.Add(Me.Label54)
        Me.GBRauch.Controls.Add(Me.PointSelector2)
        Me.GBRauch.Location = New System.Drawing.Point(4, 1989)
        Me.GBRauch.Name = "GBRauch"
        Me.GBRauch.Size = New System.Drawing.Size(327, 100)
        Me.GBRauch.TabIndex = 34
        Me.GBRauch.TabStop = False
        Me.GBRauch.Text = "Rauch"
        '
        'Rauch_MinMax
        '
        Me.Rauch_MinMax.Location = New System.Drawing.Point(302, 0)
        Me.Rauch_MinMax.Name = "Rauch_MinMax"
        Me.Rauch_MinMax.Size = New System.Drawing.Size(26, 19)
        Me.Rauch_MinMax.TabIndex = 37
        Me.Rauch_MinMax.Text = "-"
        Me.Rauch_MinMax.UseVisualStyleBackColor = True
        '
        'Label56
        '
        Me.Label56.AutoSize = True
        Me.Label56.Location = New System.Drawing.Point(149, 48)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(68, 13)
        Me.Label56.TabIndex = 5
        Me.Label56.Text = "Geschw. Var"
        '
        'Rauch_Geschw
        '
        Me.Rauch_Geschw.Location = New System.Drawing.Point(70, 45)
        Me.Rauch_Geschw.Name = "Rauch_Geschw"
        Me.Rauch_Geschw.Size = New System.Drawing.Size(72, 20)
        Me.Rauch_Geschw.TabIndex = 3
        '
        'Label55
        '
        Me.Label55.AutoSize = True
        Me.Label55.Location = New System.Drawing.Point(6, 48)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(61, 13)
        Me.Label55.TabIndex = 2
        Me.Label55.Text = "Geschwdk."
        '
        'Label54
        '
        Me.Label54.AutoSize = True
        Me.Label54.Location = New System.Drawing.Point(6, 23)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(50, 13)
        Me.Label54.TabIndex = 1
        Me.Label54.Text = "Richtung"
        '
        'GBPfade
        '
        Me.GBPfade.Controls.Add(Me.Pfade_CBTaster)
        Me.GBPfade.Controls.Add(Me.Pfade_CBVerkauf)
        Me.GBPfade.Controls.Add(Me.Pfade_CBVorWagen)
        Me.GBPfade.Controls.Add(Me.Pfade_CBNextWagen)
        Me.GBPfade.Controls.Add(Me.Pfade_PBOrange)
        Me.GBPfade.Controls.Add(Me.Pfade_BTHinzu)
        Me.GBPfade.Controls.Add(Me.Label69)
        Me.GBPfade.Controls.Add(Me.Pfade_PVerb0)
        Me.GBPfade.Controls.Add(Me.Pfade_MinMax)
        Me.GBPfade.Controls.Add(Me.Pfade_CBAusstieg)
        Me.GBPfade.Controls.Add(Me.Pfade_CBEinstieg)
        Me.GBPfade.Controls.Add(Me.Pfade_TBIndex)
        Me.GBPfade.Controls.Add(Me.Label53)
        Me.GBPfade.Controls.Add(Me.Label70)
        Me.GBPfade.Location = New System.Drawing.Point(4, 1770)
        Me.GBPfade.Name = "GBPfade"
        Me.GBPfade.Size = New System.Drawing.Size(327, 213)
        Me.GBPfade.TabIndex = 33
        Me.GBPfade.TabStop = False
        Me.GBPfade.Text = "Pfade"
        '
        'Pfade_CBTaster
        '
        Me.Pfade_CBTaster.AutoSize = True
        Me.Pfade_CBTaster.Enabled = False
        Me.Pfade_CBTaster.Location = New System.Drawing.Point(163, 66)
        Me.Pfade_CBTaster.Name = "Pfade_CBTaster"
        Me.Pfade_CBTaster.Size = New System.Drawing.Size(93, 17)
        Me.Pfade_CBTaster.TabIndex = 54
        Me.Pfade_CBTaster.Text = "Fahrgasttaster"
        Me.Pfade_CBTaster.UseVisualStyleBackColor = True
        '
        'Pfade_CBVerkauf
        '
        Me.Pfade_CBVerkauf.AutoSize = True
        Me.Pfade_CBVerkauf.Enabled = False
        Me.Pfade_CBVerkauf.Location = New System.Drawing.Point(163, 45)
        Me.Pfade_CBVerkauf.Name = "Pfade_CBVerkauf"
        Me.Pfade_CBVerkauf.Size = New System.Drawing.Size(114, 17)
        Me.Pfade_CBVerkauf.TabIndex = 53
        Me.Pfade_CBVerkauf.Text = "Fahrscheinverkauf"
        Me.Pfade_CBVerkauf.UseVisualStyleBackColor = True
        '
        'Pfade_CBVorWagen
        '
        Me.Pfade_CBVorWagen.AutoSize = True
        Me.Pfade_CBVorWagen.Location = New System.Drawing.Point(10, 66)
        Me.Pfade_CBVorWagen.Name = "Pfade_CBVorWagen"
        Me.Pfade_CBVorWagen.Size = New System.Drawing.Size(133, 17)
        Me.Pfade_CBVorWagen.TabIndex = 52
        Me.Pfade_CBVorWagen.Text = "Vbdg. vorherig Wagen"
        Me.Pfade_CBVorWagen.UseVisualStyleBackColor = True
        '
        'Pfade_CBNextWagen
        '
        Me.Pfade_CBNextWagen.AutoSize = True
        Me.Pfade_CBNextWagen.Location = New System.Drawing.Point(10, 45)
        Me.Pfade_CBNextWagen.Name = "Pfade_CBNextWagen"
        Me.Pfade_CBNextWagen.Size = New System.Drawing.Size(136, 17)
        Me.Pfade_CBNextWagen.TabIndex = 51
        Me.Pfade_CBNextWagen.Text = "Vbdg. nächster Wagen"
        Me.Pfade_CBNextWagen.UseVisualStyleBackColor = True
        '
        'Pfade_PBOrange
        '
        Me.Pfade_PBOrange.BackColor = System.Drawing.Color.Orange
        Me.Pfade_PBOrange.Location = New System.Drawing.Point(51, 19)
        Me.Pfade_PBOrange.Name = "Pfade_PBOrange"
        Me.Pfade_PBOrange.Size = New System.Drawing.Size(20, 20)
        Me.Pfade_PBOrange.TabIndex = 49
        Me.Pfade_PBOrange.TabStop = False
        '
        'Pfade_BTHinzu
        '
        Me.Pfade_BTHinzu.Location = New System.Drawing.Point(256, 162)
        Me.Pfade_BTHinzu.Name = "Pfade_BTHinzu"
        Me.Pfade_BTHinzu.Size = New System.Drawing.Size(71, 23)
        Me.Pfade_BTHinzu.TabIndex = 48
        Me.Pfade_BTHinzu.Text = "Hinzufügen"
        Me.Pfade_BTHinzu.UseVisualStyleBackColor = True
        '
        'Label69
        '
        Me.Label69.AutoSize = True
        Me.Label69.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label69.Location = New System.Drawing.Point(6, 86)
        Me.Label69.Name = "Label69"
        Me.Label69.Size = New System.Drawing.Size(85, 13)
        Me.Label69.TabIndex = 48
        Me.Label69.Text = "Verbindungen"
        '
        'Pfade_PVerb0
        '
        Me.Pfade_PVerb0.BackColor = System.Drawing.SystemColors.Menu
        Me.Pfade_PVerb0.Controls.Add(Me.Pfade_PBLila)
        Me.Pfade_PVerb0.Controls.Add(Me.Pfade_BTRem_0)
        Me.Pfade_PVerb0.Controls.Add(Me.Pfade_DDStepsound_0)
        Me.Pfade_PVerb0.Controls.Add(Me.Pfade_TBStehh_0)
        Me.Pfade_PVerb0.Controls.Add(Me.Label61)
        Me.Pfade_PVerb0.Controls.Add(Me.Pfade_CBRichtung_0)
        Me.Pfade_PVerb0.Controls.Add(Me.Label60)
        Me.Pfade_PVerb0.Controls.Add(Me.Label62)
        Me.Pfade_PVerb0.Controls.Add(Me.Pfade_DDNachste_0)
        Me.Pfade_PVerb0.Location = New System.Drawing.Point(0, 102)
        Me.Pfade_PVerb0.Name = "Pfade_PVerb0"
        Me.Pfade_PVerb0.Size = New System.Drawing.Size(327, 61)
        Me.Pfade_PVerb0.TabIndex = 47
        '
        'Pfade_PBLila
        '
        Me.Pfade_PBLila.BackColor = System.Drawing.Color.Violet
        Me.Pfade_PBLila.Location = New System.Drawing.Point(50, 6)
        Me.Pfade_PBLila.Name = "Pfade_PBLila"
        Me.Pfade_PBLila.Size = New System.Drawing.Size(20, 21)
        Me.Pfade_PBLila.TabIndex = 50
        Me.Pfade_PBLila.TabStop = False
        '
        'Pfade_BTRem_0
        '
        Me.Pfade_BTRem_0.Location = New System.Drawing.Point(298, 6)
        Me.Pfade_BTRem_0.Name = "Pfade_BTRem_0"
        Me.Pfade_BTRem_0.Size = New System.Drawing.Size(23, 23)
        Me.Pfade_BTRem_0.TabIndex = 47
        Me.Pfade_BTRem_0.Text = "-"
        Me.Pfade_BTRem_0.UseVisualStyleBackColor = True
        '
        'Pfade_DDStepsound_0
        '
        Me.Pfade_DDStepsound_0.FormattingEnabled = True
        Me.Pfade_DDStepsound_0.Location = New System.Drawing.Point(220, 6)
        Me.Pfade_DDStepsound_0.Name = "Pfade_DDStepsound_0"
        Me.Pfade_DDStepsound_0.Size = New System.Drawing.Size(75, 21)
        Me.Pfade_DDStepsound_0.TabIndex = 41
        '
        'Pfade_TBStehh_0
        '
        Me.Pfade_TBStehh_0.Location = New System.Drawing.Point(220, 33)
        Me.Pfade_TBStehh_0.Name = "Pfade_TBStehh_0"
        Me.Pfade_TBStehh_0.Size = New System.Drawing.Size(75, 20)
        Me.Pfade_TBStehh_0.TabIndex = 40
        '
        'Label61
        '
        Me.Label61.AutoSize = True
        Me.Label61.Location = New System.Drawing.Point(149, 36)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(53, 13)
        Me.Label61.TabIndex = 39
        Me.Label61.Text = "Stehhöhe"
        '
        'Pfade_CBRichtung_0
        '
        Me.Pfade_CBRichtung_0.AutoSize = True
        Me.Pfade_CBRichtung_0.Location = New System.Drawing.Point(6, 35)
        Me.Pfade_CBRichtung_0.Name = "Pfade_CBRichtung_0"
        Me.Pfade_CBRichtung_0.Size = New System.Drawing.Size(93, 17)
        Me.Pfade_CBRichtung_0.TabIndex = 46
        Me.Pfade_CBRichtung_0.Text = "Eine Richtung"
        Me.Pfade_CBRichtung_0.UseVisualStyleBackColor = True
        '
        'Label60
        '
        Me.Label60.AutoSize = True
        Me.Label60.Location = New System.Drawing.Point(149, 9)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(58, 13)
        Me.Label60.TabIndex = 38
        Me.Label60.Text = "Stepsound"
        '
        'Label62
        '
        Me.Label62.AutoSize = True
        Me.Label62.Location = New System.Drawing.Point(6, 9)
        Me.Label62.Name = "Label62"
        Me.Label62.Size = New System.Drawing.Size(35, 13)
        Me.Label62.TabIndex = 42
        Me.Label62.Text = "Punkt"
        '
        'Pfade_DDNachste_0
        '
        Me.Pfade_DDNachste_0.FormattingEnabled = True
        Me.Pfade_DDNachste_0.Location = New System.Drawing.Point(69, 6)
        Me.Pfade_DDNachste_0.Name = "Pfade_DDNachste_0"
        Me.Pfade_DDNachste_0.Size = New System.Drawing.Size(75, 21)
        Me.Pfade_DDNachste_0.TabIndex = 43
        '
        'Pfade_MinMax
        '
        Me.Pfade_MinMax.Location = New System.Drawing.Point(302, 0)
        Me.Pfade_MinMax.Name = "Pfade_MinMax"
        Me.Pfade_MinMax.Size = New System.Drawing.Size(26, 19)
        Me.Pfade_MinMax.TabIndex = 37
        Me.Pfade_MinMax.Text = "-"
        Me.Pfade_MinMax.UseVisualStyleBackColor = True
        '
        'Pfade_CBAusstieg
        '
        Me.Pfade_CBAusstieg.AutoSize = True
        Me.Pfade_CBAusstieg.Location = New System.Drawing.Point(233, 21)
        Me.Pfade_CBAusstieg.Name = "Pfade_CBAusstieg"
        Me.Pfade_CBAusstieg.Size = New System.Drawing.Size(66, 17)
        Me.Pfade_CBAusstieg.TabIndex = 3
        Me.Pfade_CBAusstieg.Text = "Ausstieg"
        Me.Pfade_CBAusstieg.UseVisualStyleBackColor = True
        '
        'Pfade_CBEinstieg
        '
        Me.Pfade_CBEinstieg.AutoSize = True
        Me.Pfade_CBEinstieg.Location = New System.Drawing.Point(163, 21)
        Me.Pfade_CBEinstieg.Name = "Pfade_CBEinstieg"
        Me.Pfade_CBEinstieg.Size = New System.Drawing.Size(63, 17)
        Me.Pfade_CBEinstieg.TabIndex = 2
        Me.Pfade_CBEinstieg.Text = "Einstieg"
        Me.Pfade_CBEinstieg.UseVisualStyleBackColor = True
        '
        'Pfade_TBIndex
        '
        Me.Pfade_TBIndex.Location = New System.Drawing.Point(70, 19)
        Me.Pfade_TBIndex.Name = "Pfade_TBIndex"
        Me.Pfade_TBIndex.ReadOnly = True
        Me.Pfade_TBIndex.Size = New System.Drawing.Size(72, 20)
        Me.Pfade_TBIndex.TabIndex = 1
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.Location = New System.Drawing.Point(6, 22)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(33, 13)
        Me.Label53.TabIndex = 0
        Me.Label53.Text = "Index"
        '
        'Label70
        '
        Me.Label70.AutoSize = True
        Me.Label70.Location = New System.Drawing.Point(7, 105)
        Me.Label70.Name = "Label70"
        Me.Label70.Size = New System.Drawing.Size(47, 13)
        Me.Label70.TabIndex = 50
        Me.Label70.Text = "- kleine -"
        '
        'GBKupplPnt
        '
        Me.GBKupplPnt.Controls.Add(Me.Kuppl_LBHeck)
        Me.GBKupplPnt.Controls.Add(Me.Kuppl_LBFront)
        Me.GBKupplPnt.Controls.Add(Me.Label68)
        Me.GBKupplPnt.Controls.Add(Me.Label67)
        Me.GBKupplPnt.Controls.Add(Me.Kuppl_TBUp)
        Me.GBKupplPnt.Controls.Add(Me.Kuppl_TBDown)
        Me.GBKupplPnt.Controls.Add(Me.Kuppl_TBDrehwinkel)
        Me.GBKupplPnt.Controls.Add(Me.Label66)
        Me.GBKupplPnt.Controls.Add(Me.Kuppl_DDKupplType)
        Me.GBKupplPnt.Controls.Add(Me.Label65)
        Me.GBKupplPnt.Controls.Add(Me.Kuppl_CBSound)
        Me.GBKupplPnt.Controls.Add(Me.Label64)
        Me.GBKupplPnt.Controls.Add(Me.Kuppl_DDRichtung)
        Me.GBKupplPnt.Controls.Add(Me.Label63)
        Me.GBKupplPnt.Controls.Add(Me.Kuppl_DDNextVehicle)
        Me.GBKupplPnt.Controls.Add(Me.Kupplung_MinMax)
        Me.GBKupplPnt.Location = New System.Drawing.Point(4, 337)
        Me.GBKupplPnt.Name = "GBKupplPnt"
        Me.GBKupplPnt.Size = New System.Drawing.Size(327, 182)
        Me.GBKupplPnt.TabIndex = 32
        Me.GBKupplPnt.TabStop = False
        Me.GBKupplPnt.Text = "Kupplungspunkt"
        '
        'Kuppl_LBHeck
        '
        Me.Kuppl_LBHeck.AutoSize = True
        Me.Kuppl_LBHeck.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Kuppl_LBHeck.Location = New System.Drawing.Point(9, 25)
        Me.Kuppl_LBHeck.Name = "Kuppl_LBHeck"
        Me.Kuppl_LBHeck.Size = New System.Drawing.Size(37, 13)
        Me.Kuppl_LBHeck.TabIndex = 52
        Me.Kuppl_LBHeck.Text = "Heck"
        Me.Kuppl_LBHeck.Visible = False
        '
        'Kuppl_LBFront
        '
        Me.Kuppl_LBFront.AutoSize = True
        Me.Kuppl_LBFront.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Kuppl_LBFront.Location = New System.Drawing.Point(6, 25)
        Me.Kuppl_LBFront.Name = "Kuppl_LBFront"
        Me.Kuppl_LBFront.Size = New System.Drawing.Size(36, 13)
        Me.Kuppl_LBFront.TabIndex = 51
        Me.Kuppl_LBFront.Text = "Front"
        Me.Kuppl_LBFront.Visible = False
        '
        'Label68
        '
        Me.Label68.AutoSize = True
        Me.Label68.Location = New System.Drawing.Point(147, 101)
        Me.Label68.Name = "Label68"
        Me.Label68.Size = New System.Drawing.Size(61, 13)
        Me.Label68.TabIndex = 50
        Me.Label68.Text = "nach unten"
        '
        'Label67
        '
        Me.Label67.AutoSize = True
        Me.Label67.Location = New System.Drawing.Point(3, 102)
        Me.Label67.Name = "Label67"
        Me.Label67.Size = New System.Drawing.Size(61, 13)
        Me.Label67.TabIndex = 49
        Me.Label67.Text = "nach unten"
        '
        'Kuppl_TBUp
        '
        Me.Kuppl_TBUp.Enabled = False
        Me.Kuppl_TBUp.Location = New System.Drawing.Point(224, 98)
        Me.Kuppl_TBUp.Name = "Kuppl_TBUp"
        Me.Kuppl_TBUp.Size = New System.Drawing.Size(71, 20)
        Me.Kuppl_TBUp.TabIndex = 48
        '
        'Kuppl_TBDown
        '
        Me.Kuppl_TBDown.Enabled = False
        Me.Kuppl_TBDown.Location = New System.Drawing.Point(70, 99)
        Me.Kuppl_TBDown.Name = "Kuppl_TBDown"
        Me.Kuppl_TBDown.Size = New System.Drawing.Size(71, 20)
        Me.Kuppl_TBDown.TabIndex = 47
        '
        'Kuppl_TBDrehwinkel
        '
        Me.Kuppl_TBDrehwinkel.Enabled = False
        Me.Kuppl_TBDrehwinkel.Location = New System.Drawing.Point(224, 72)
        Me.Kuppl_TBDrehwinkel.Name = "Kuppl_TBDrehwinkel"
        Me.Kuppl_TBDrehwinkel.Size = New System.Drawing.Size(71, 20)
        Me.Kuppl_TBDrehwinkel.TabIndex = 46
        '
        'Label66
        '
        Me.Label66.AutoSize = True
        Me.Label66.Location = New System.Drawing.Point(147, 75)
        Me.Label66.Name = "Label66"
        Me.Label66.Size = New System.Drawing.Size(60, 13)
        Me.Label66.TabIndex = 45
        Me.Label66.Text = "Drehwinkel"
        '
        'Kuppl_DDKupplType
        '
        Me.Kuppl_DDKupplType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Kuppl_DDKupplType.Enabled = False
        Me.Kuppl_DDKupplType.FormattingEnabled = True
        Me.Kuppl_DDKupplType.Items.AddRange(New Object() {"LKW", "Bus"})
        Me.Kuppl_DDKupplType.Location = New System.Drawing.Point(70, 72)
        Me.Kuppl_DDKupplType.Name = "Kuppl_DDKupplType"
        Me.Kuppl_DDKupplType.Size = New System.Drawing.Size(71, 21)
        Me.Kuppl_DDKupplType.TabIndex = 44
        '
        'Label65
        '
        Me.Label65.AutoSize = True
        Me.Label65.Location = New System.Drawing.Point(3, 75)
        Me.Label65.Name = "Label65"
        Me.Label65.Size = New System.Drawing.Size(71, 13)
        Me.Label65.TabIndex = 43
        Me.Label65.Text = "Kupplungstyp"
        '
        'Kuppl_CBSound
        '
        Me.Kuppl_CBSound.AutoSize = True
        Me.Kuppl_CBSound.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Kuppl_CBSound.Enabled = False
        Me.Kuppl_CBSound.Location = New System.Drawing.Point(3, 52)
        Me.Kuppl_CBSound.Name = "Kuppl_CBSound"
        Me.Kuppl_CBSound.Size = New System.Drawing.Size(101, 17)
        Me.Kuppl_CBSound.TabIndex = 42
        Me.Kuppl_CBSound.Text = "Offen für Sound"
        Me.Kuppl_CBSound.UseVisualStyleBackColor = True
        '
        'Label64
        '
        Me.Label64.AutoSize = True
        Me.Label64.Location = New System.Drawing.Point(3, 155)
        Me.Label64.Name = "Label64"
        Me.Label64.Size = New System.Drawing.Size(95, 13)
        Me.Label64.TabIndex = 41
        Me.Label64.Text = "Kupplungsrichtung"
        '
        'Kuppl_DDRichtung
        '
        Me.Kuppl_DDRichtung.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Kuppl_DDRichtung.Enabled = False
        Me.Kuppl_DDRichtung.FormattingEnabled = True
        Me.Kuppl_DDRichtung.Items.AddRange(New Object() {"Normal", "Umgekehrt"})
        Me.Kuppl_DDRichtung.Location = New System.Drawing.Point(137, 152)
        Me.Kuppl_DDRichtung.Name = "Kuppl_DDRichtung"
        Me.Kuppl_DDRichtung.Size = New System.Drawing.Size(158, 21)
        Me.Kuppl_DDRichtung.TabIndex = 40
        '
        'Label63
        '
        Me.Label63.AutoSize = True
        Me.Label63.Location = New System.Drawing.Point(3, 128)
        Me.Label63.Name = "Label63"
        Me.Label63.Size = New System.Drawing.Size(99, 13)
        Me.Label63.TabIndex = 39
        Me.Label63.Text = "Nächstes Fahrzeug"
        '
        'Kuppl_DDNextVehicle
        '
        Me.Kuppl_DDNextVehicle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Kuppl_DDNextVehicle.Enabled = False
        Me.Kuppl_DDNextVehicle.FormattingEnabled = True
        Me.Kuppl_DDNextVehicle.Location = New System.Drawing.Point(137, 125)
        Me.Kuppl_DDNextVehicle.Name = "Kuppl_DDNextVehicle"
        Me.Kuppl_DDNextVehicle.Size = New System.Drawing.Size(158, 21)
        Me.Kuppl_DDNextVehicle.TabIndex = 38
        '
        'Kupplung_MinMax
        '
        Me.Kupplung_MinMax.Location = New System.Drawing.Point(302, 0)
        Me.Kupplung_MinMax.Name = "Kupplung_MinMax"
        Me.Kupplung_MinMax.Size = New System.Drawing.Size(26, 19)
        Me.Kupplung_MinMax.TabIndex = 37
        Me.Kupplung_MinMax.Text = "-"
        Me.Kupplung_MinMax.UseVisualStyleBackColor = True
        '
        'GBKamera
        '
        Me.GBKamera.Controls.Add(Me.Kamera_BTStd)
        Me.GBKamera.Controls.Add(Me.Kamera_CBVerkauf)
        Me.GBKamera.Controls.Add(Me.Kamera_CBFahrplan)
        Me.GBKamera.Controls.Add(Me.Label74)
        Me.GBKamera.Controls.Add(Me.Label73)
        Me.GBKamera.Controls.Add(Me.Kamera_TBVertikal)
        Me.GBKamera.Controls.Add(Me.Kamera_TBHorizont)
        Me.GBKamera.Controls.Add(Me.Label72)
        Me.GBKamera.Controls.Add(Me.Kamera_TBSichtwinkel)
        Me.GBKamera.Controls.Add(Me.Label71)
        Me.GBKamera.Controls.Add(Me.Kamera_TBDistRotPnt)
        Me.GBKamera.Controls.Add(Me.Kamera_MinMax)
        Me.GBKamera.Controls.Add(Me.Kamera_RBPassagier)
        Me.GBKamera.Controls.Add(Me.Kamera_RBFahrer)
        Me.GBKamera.Location = New System.Drawing.Point(4, 1533)
        Me.GBKamera.Name = "GBKamera"
        Me.GBKamera.Size = New System.Drawing.Size(327, 149)
        Me.GBKamera.TabIndex = 31
        Me.GBKamera.TabStop = False
        Me.GBKamera.Text = "Kamera"
        '
        'Kamera_BTStd
        '
        Me.Kamera_BTStd.Location = New System.Drawing.Point(11, 119)
        Me.Kamera_BTStd.Name = "Kamera_BTStd"
        Me.Kamera_BTStd.Size = New System.Drawing.Size(75, 23)
        Me.Kamera_BTStd.TabIndex = 51
        Me.Kamera_BTStd.Text = "Std. Kamera"
        Me.Kamera_BTStd.UseVisualStyleBackColor = True
        '
        'Kamera_CBVerkauf
        '
        Me.Kamera_CBVerkauf.AutoSize = True
        Me.Kamera_CBVerkauf.Location = New System.Drawing.Point(194, 96)
        Me.Kamera_CBVerkauf.Name = "Kamera_CBVerkauf"
        Me.Kamera_CBVerkauf.Size = New System.Drawing.Size(102, 17)
        Me.Kamera_CBVerkauf.TabIndex = 50
        Me.Kamera_CBVerkauf.Text = "Verkaufsansicht"
        Me.Kamera_CBVerkauf.UseVisualStyleBackColor = True
        '
        'Kamera_CBFahrplan
        '
        Me.Kamera_CBFahrplan.AutoSize = True
        Me.Kamera_CBFahrplan.Location = New System.Drawing.Point(10, 96)
        Me.Kamera_CBFahrplan.Name = "Kamera_CBFahrplan"
        Me.Kamera_CBFahrplan.Size = New System.Drawing.Size(101, 17)
        Me.Kamera_CBFahrplan.TabIndex = 49
        Me.Kamera_CBFahrplan.Text = "Fahrplanansicht"
        Me.Kamera_CBFahrplan.UseVisualStyleBackColor = True
        '
        'Label74
        '
        Me.Label74.AutoSize = True
        Me.Label74.Location = New System.Drawing.Point(149, 72)
        Me.Label74.Name = "Label74"
        Me.Label74.Size = New System.Drawing.Size(42, 13)
        Me.Label74.TabIndex = 44
        Me.Label74.Text = "Vertikal"
        '
        'Label73
        '
        Me.Label73.AutoSize = True
        Me.Label73.Location = New System.Drawing.Point(6, 72)
        Me.Label73.Name = "Label73"
        Me.Label73.Size = New System.Drawing.Size(54, 13)
        Me.Label73.TabIndex = 43
        Me.Label73.Text = "Horizontal"
        '
        'Kamera_TBVertikal
        '
        Me.Kamera_TBVertikal.Location = New System.Drawing.Point(224, 69)
        Me.Kamera_TBVertikal.Name = "Kamera_TBVertikal"
        Me.Kamera_TBVertikal.Size = New System.Drawing.Size(73, 20)
        Me.Kamera_TBVertikal.TabIndex = 42
        '
        'Kamera_TBHorizont
        '
        Me.Kamera_TBHorizont.Location = New System.Drawing.Point(69, 69)
        Me.Kamera_TBHorizont.Name = "Kamera_TBHorizont"
        Me.Kamera_TBHorizont.Size = New System.Drawing.Size(73, 20)
        Me.Kamera_TBHorizont.TabIndex = 41
        '
        'Label72
        '
        Me.Label72.AutoSize = True
        Me.Label72.Location = New System.Drawing.Point(149, 46)
        Me.Label72.Name = "Label72"
        Me.Label72.Size = New System.Drawing.Size(61, 13)
        Me.Label72.TabIndex = 40
        Me.Label72.Text = "Sichtwinkel"
        '
        'Kamera_TBSichtwinkel
        '
        Me.Kamera_TBSichtwinkel.Location = New System.Drawing.Point(224, 43)
        Me.Kamera_TBSichtwinkel.Name = "Kamera_TBSichtwinkel"
        Me.Kamera_TBSichtwinkel.Size = New System.Drawing.Size(73, 20)
        Me.Kamera_TBSichtwinkel.TabIndex = 40
        '
        'Label71
        '
        Me.Label71.AutoSize = True
        Me.Label71.Location = New System.Drawing.Point(6, 46)
        Me.Label71.Name = "Label71"
        Me.Label71.Size = New System.Drawing.Size(63, 13)
        Me.Label71.TabIndex = 39
        Me.Label71.Text = "Dist. Rotpnt"
        '
        'Kamera_TBDistRotPnt
        '
        Me.Kamera_TBDistRotPnt.Location = New System.Drawing.Point(69, 43)
        Me.Kamera_TBDistRotPnt.Name = "Kamera_TBDistRotPnt"
        Me.Kamera_TBDistRotPnt.Size = New System.Drawing.Size(73, 20)
        Me.Kamera_TBDistRotPnt.TabIndex = 38
        '
        'Kamera_MinMax
        '
        Me.Kamera_MinMax.Location = New System.Drawing.Point(302, 0)
        Me.Kamera_MinMax.Name = "Kamera_MinMax"
        Me.Kamera_MinMax.Size = New System.Drawing.Size(26, 19)
        Me.Kamera_MinMax.TabIndex = 37
        Me.Kamera_MinMax.Text = "-"
        Me.Kamera_MinMax.UseVisualStyleBackColor = True
        '
        'Kamera_RBPassagier
        '
        Me.Kamera_RBPassagier.AutoSize = True
        Me.Kamera_RBPassagier.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Kamera_RBPassagier.Location = New System.Drawing.Point(151, 20)
        Me.Kamera_RBPassagier.Name = "Kamera_RBPassagier"
        Me.Kamera_RBPassagier.Size = New System.Drawing.Size(101, 17)
        Me.Kamera_RBPassagier.TabIndex = 1
        Me.Kamera_RBPassagier.Text = "Fahrgastkamera"
        Me.Kamera_RBPassagier.UseVisualStyleBackColor = True
        '
        'Kamera_RBFahrer
        '
        Me.Kamera_RBFahrer.AutoSize = True
        Me.Kamera_RBFahrer.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Kamera_RBFahrer.Checked = True
        Me.Kamera_RBFahrer.Location = New System.Drawing.Point(6, 20)
        Me.Kamera_RBFahrer.Name = "Kamera_RBFahrer"
        Me.Kamera_RBFahrer.Size = New System.Drawing.Size(90, 17)
        Me.Kamera_RBFahrer.TabIndex = 0
        Me.Kamera_RBFahrer.TabStop = True
        Me.Kamera_RBFahrer.Text = "Fahrerkamera"
        Me.Kamera_RBFahrer.UseVisualStyleBackColor = True
        '
        'GBBbox
        '
        Me.GBBbox.Controls.Add(Me.BBox_MinMax)
        Me.GBBbox.Controls.Add(Me.Label52)
        Me.GBBbox.Controls.Add(Me.BBox_PSSize)
        Me.GBBbox.Controls.Add(Me.BBoxBTBerechnen)
        Me.GBBbox.Location = New System.Drawing.Point(4, 1268)
        Me.GBBbox.Name = "GBBbox"
        Me.GBBbox.Size = New System.Drawing.Size(327, 79)
        Me.GBBbox.TabIndex = 30
        Me.GBBbox.TabStop = False
        Me.GBBbox.Text = "Boundingbox"
        '
        'BBox_MinMax
        '
        Me.BBox_MinMax.Location = New System.Drawing.Point(302, 0)
        Me.BBox_MinMax.Name = "BBox_MinMax"
        Me.BBox_MinMax.Size = New System.Drawing.Size(26, 19)
        Me.BBox_MinMax.TabIndex = 38
        Me.BBox_MinMax.Text = "-"
        Me.BBox_MinMax.UseVisualStyleBackColor = True
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.Location = New System.Drawing.Point(6, 23)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(34, 13)
        Me.Label52.TabIndex = 24
        Me.Label52.Text = "Maße"
        '
        'BBoxBTBerechnen
        '
        Me.BBoxBTBerechnen.Location = New System.Drawing.Point(244, 45)
        Me.BBoxBTBerechnen.Name = "BBoxBTBerechnen"
        Me.BBoxBTBerechnen.Size = New System.Drawing.Size(75, 23)
        Me.BBoxBTBerechnen.TabIndex = 0
        Me.BBoxBTBerechnen.Text = "Berechnen"
        Me.BBoxBTBerechnen.UseVisualStyleBackColor = True
        '
        'GBAchse
        '
        Me.GBAchse.Controls.Add(Me.Label59)
        Me.GBAchse.Controls.Add(Me.Achse_TBDurchmesser)
        Me.GBAchse.Controls.Add(Me.Achse_MinMax)
        Me.GBAchse.Controls.Add(Me.Label51)
        Me.GBAchse.Controls.Add(Me.Achse_TBDaempfer)
        Me.GBAchse.Controls.Add(Me.Label50)
        Me.GBAchse.Controls.Add(Me.Achse_TBMaxforce)
        Me.GBAchse.Controls.Add(Me.Label49)
        Me.GBAchse.Controls.Add(Me.Achse_TBFeder)
        Me.GBAchse.Controls.Add(Me.Achse_CBAntrieb)
        Me.GBAchse.Controls.Add(Me.Label48)
        Me.GBAchse.Controls.Add(Me.Achse_TBMinwidt)
        Me.GBAchse.Controls.Add(Me.Label47)
        Me.GBAchse.Controls.Add(Me.Achse_TBBreite)
        Me.GBAchse.Controls.Add(Me.Label46)
        Me.GBAchse.Controls.Add(Me.Achse_TBMaxwidt)
        Me.GBAchse.Location = New System.Drawing.Point(4, 1353)
        Me.GBAchse.Name = "GBAchse"
        Me.GBAchse.Size = New System.Drawing.Size(327, 151)
        Me.GBAchse.TabIndex = 29
        Me.GBAchse.TabStop = False
        Me.GBAchse.Text = "Achse"
        '
        'Label59
        '
        Me.Label59.AutoSize = True
        Me.Label59.Location = New System.Drawing.Point(7, 100)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(60, 13)
        Me.Label59.TabIndex = 39
        Me.Label59.Text = "Durchmess"
        '
        'Achse_TBDurchmesser
        '
        Me.Achse_TBDurchmesser.Location = New System.Drawing.Point(70, 97)
        Me.Achse_TBDurchmesser.Name = "Achse_TBDurchmesser"
        Me.Achse_TBDurchmesser.Size = New System.Drawing.Size(72, 20)
        Me.Achse_TBDurchmesser.TabIndex = 38
        '
        'Achse_MinMax
        '
        Me.Achse_MinMax.Location = New System.Drawing.Point(302, 0)
        Me.Achse_MinMax.Name = "Achse_MinMax"
        Me.Achse_MinMax.Size = New System.Drawing.Size(26, 19)
        Me.Achse_MinMax.TabIndex = 37
        Me.Achse_MinMax.Text = "-"
        Me.Achse_MinMax.UseVisualStyleBackColor = True
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.Location = New System.Drawing.Point(149, 74)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(47, 13)
        Me.Label51.TabIndex = 35
        Me.Label51.Text = "Dämpfer"
        '
        'Achse_TBDaempfer
        '
        Me.Achse_TBDaempfer.Location = New System.Drawing.Point(224, 71)
        Me.Achse_TBDaempfer.Name = "Achse_TBDaempfer"
        Me.Achse_TBDaempfer.Size = New System.Drawing.Size(72, 20)
        Me.Achse_TBDaempfer.TabIndex = 34
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.Location = New System.Drawing.Point(149, 48)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(55, 13)
        Me.Label50.TabIndex = 33
        Me.Label50.Text = "Max. Kraft"
        '
        'Achse_TBMaxforce
        '
        Me.Achse_TBMaxforce.Location = New System.Drawing.Point(224, 45)
        Me.Achse_TBMaxforce.Name = "Achse_TBMaxforce"
        Me.Achse_TBMaxforce.Size = New System.Drawing.Size(72, 20)
        Me.Achse_TBMaxforce.TabIndex = 32
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.Location = New System.Drawing.Point(149, 22)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(54, 13)
        Me.Label49.TabIndex = 31
        Me.Label49.Text = "Federweg"
        '
        'Achse_TBFeder
        '
        Me.Achse_TBFeder.Location = New System.Drawing.Point(224, 19)
        Me.Achse_TBFeder.Name = "Achse_TBFeder"
        Me.Achse_TBFeder.Size = New System.Drawing.Size(72, 20)
        Me.Achse_TBFeder.TabIndex = 30
        '
        'Achse_CBAntrieb
        '
        Me.Achse_CBAntrieb.AutoSize = True
        Me.Achse_CBAntrieb.Location = New System.Drawing.Point(9, 123)
        Me.Achse_CBAntrieb.Name = "Achse_CBAntrieb"
        Me.Achse_CBAntrieb.Size = New System.Drawing.Size(83, 17)
        Me.Achse_CBAntrieb.TabIndex = 29
        Me.Achse_CBAntrieb.Text = "Angetrieben"
        Me.Achse_CBAntrieb.UseVisualStyleBackColor = True
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.Location = New System.Drawing.Point(6, 74)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(57, 13)
        Me.Label48.TabIndex = 28
        Me.Label48.Text = "Innenabst."
        '
        'Achse_TBMinwidt
        '
        Me.Achse_TBMinwidt.Location = New System.Drawing.Point(70, 71)
        Me.Achse_TBMinwidt.Name = "Achse_TBMinwidt"
        Me.Achse_TBMinwidt.Size = New System.Drawing.Size(72, 20)
        Me.Achse_TBMinwidt.TabIndex = 27
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.Location = New System.Drawing.Point(6, 48)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(64, 13)
        Me.Label47.TabIndex = 26
        Me.Label47.Text = "Reifenbreite"
        '
        'Achse_TBBreite
        '
        Me.Achse_TBBreite.Enabled = False
        Me.Achse_TBBreite.Location = New System.Drawing.Point(70, 45)
        Me.Achse_TBBreite.Name = "Achse_TBBreite"
        Me.Achse_TBBreite.Size = New System.Drawing.Size(72, 20)
        Me.Achse_TBBreite.TabIndex = 25
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.Location = New System.Drawing.Point(6, 22)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(34, 13)
        Me.Label46.TabIndex = 24
        Me.Label46.Text = "Breite"
        '
        'Achse_TBMaxwidt
        '
        Me.Achse_TBMaxwidt.Location = New System.Drawing.Point(70, 19)
        Me.Achse_TBMaxwidt.Name = "Achse_TBMaxwidt"
        Me.Achse_TBMaxwidt.Size = New System.Drawing.Size(72, 20)
        Me.Achse_TBMaxwidt.TabIndex = 23
        '
        'GBSplineHelper
        '
        Me.GBSplineHelper.Controls.Add(Me.SplineHelper_MinMax)
        Me.GBSplineHelper.Controls.Add(Me.Splinehelper_BTLaden)
        Me.GBSplineHelper.Controls.Add(Me.Label44)
        Me.GBSplineHelper.Controls.Add(Me.Splinehelper_TBSpline)
        Me.GBSplineHelper.Controls.Add(Me.Label43)
        Me.GBSplineHelper.Controls.Add(Me.Splinehelper_TBDrehung)
        Me.GBSplineHelper.Location = New System.Drawing.Point(4, 2570)
        Me.GBSplineHelper.Name = "GBSplineHelper"
        Me.GBSplineHelper.Size = New System.Drawing.Size(327, 74)
        Me.GBSplineHelper.TabIndex = 28
        Me.GBSplineHelper.TabStop = False
        Me.GBSplineHelper.Text = "Splinehelper"
        '
        'SplineHelper_MinMax
        '
        Me.SplineHelper_MinMax.Location = New System.Drawing.Point(302, 0)
        Me.SplineHelper_MinMax.Name = "SplineHelper_MinMax"
        Me.SplineHelper_MinMax.Size = New System.Drawing.Size(26, 19)
        Me.SplineHelper_MinMax.TabIndex = 37
        Me.SplineHelper_MinMax.Text = "-"
        Me.SplineHelper_MinMax.UseVisualStyleBackColor = True
        '
        'Splinehelper_BTLaden
        '
        Me.Splinehelper_BTLaden.Location = New System.Drawing.Point(224, 44)
        Me.Splinehelper_BTLaden.Name = "Splinehelper_BTLaden"
        Me.Splinehelper_BTLaden.Size = New System.Drawing.Size(72, 22)
        Me.Splinehelper_BTLaden.TabIndex = 26
        Me.Splinehelper_BTLaden.Text = "Laden"
        Me.Splinehelper_BTLaden.UseVisualStyleBackColor = True
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Location = New System.Drawing.Point(8, 48)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(36, 13)
        Me.Label44.TabIndex = 25
        Me.Label44.Text = "Spline"
        '
        'Splinehelper_TBSpline
        '
        Me.Splinehelper_TBSpline.Location = New System.Drawing.Point(70, 45)
        Me.Splinehelper_TBSpline.Name = "Splinehelper_TBSpline"
        Me.Splinehelper_TBSpline.Size = New System.Drawing.Size(155, 20)
        Me.Splinehelper_TBSpline.TabIndex = 24
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Location = New System.Drawing.Point(8, 22)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(48, 13)
        Me.Label43.TabIndex = 23
        Me.Label43.Text = "Drehung"
        '
        'Splinehelper_TBDrehung
        '
        Me.Splinehelper_TBDrehung.Location = New System.Drawing.Point(70, 19)
        Me.Splinehelper_TBDrehung.Name = "Splinehelper_TBDrehung"
        Me.Splinehelper_TBDrehung.Size = New System.Drawing.Size(72, 20)
        Me.Splinehelper_TBDrehung.TabIndex = 0
        '
        'GBPfad
        '
        Me.GBPfad.Controls.Add(Me.Pfad_MinMax)
        Me.GBPfad.Controls.Add(Me.Pfad_CBParallelProblem)
        Me.GBPfad.Controls.Add(Me.Label42)
        Me.GBPfad.Controls.Add(Me.Pfad_CBAmpel)
        Me.GBPfad.Controls.Add(Me.Label41)
        Me.GBPfad.Controls.Add(Me.Pfad_CBBlinker)
        Me.GBPfad.Controls.Add(Me.Label40)
        Me.GBPfad.Controls.Add(Me.Pfad_CBRichtung)
        Me.GBPfad.Controls.Add(Me.Label39)
        Me.GBPfad.Controls.Add(Me.Pfad_CBTyp)
        Me.GBPfad.Controls.Add(Me.Label38)
        Me.GBPfad.Controls.Add(Me.Label37)
        Me.GBPfad.Controls.Add(Me.Label36)
        Me.GBPfad.Controls.Add(Me.Label35)
        Me.GBPfad.Controls.Add(Me.Label34)
        Me.GBPfad.Controls.Add(Me.Label33)
        Me.GBPfad.Controls.Add(Me.Label32)
        Me.GBPfad.Controls.Add(Me.Pfad_TBEndWinkel)
        Me.GBPfad.Controls.Add(Me.Pfad_TBStartWinkel)
        Me.GBPfad.Controls.Add(Me.Pfad_TBBreite)
        Me.GBPfad.Controls.Add(Me.Pfad_TBWinkel)
        Me.GBPfad.Controls.Add(Me.Pfad_TBRadius)
        Me.GBPfad.Controls.Add(Me.Pfad_TBLänge)
        Me.GBPfad.Controls.Add(Me.Pfad_TBRot)
        Me.GBPfad.Location = New System.Drawing.Point(4, 1057)
        Me.GBPfad.Name = "GBPfad"
        Me.GBPfad.Size = New System.Drawing.Size(325, 205)
        Me.GBPfad.TabIndex = 27
        Me.GBPfad.TabStop = False
        Me.GBPfad.Text = "Pfad"
        '
        'Pfad_MinMax
        '
        Me.Pfad_MinMax.Location = New System.Drawing.Point(302, 0)
        Me.Pfad_MinMax.Name = "Pfad_MinMax"
        Me.Pfad_MinMax.Size = New System.Drawing.Size(26, 19)
        Me.Pfad_MinMax.TabIndex = 37
        Me.Pfad_MinMax.Text = "-"
        Me.Pfad_MinMax.UseVisualStyleBackColor = True
        '
        'Pfad_CBParallelProblem
        '
        Me.Pfad_CBParallelProblem.AutoSize = True
        Me.Pfad_CBParallelProblem.Location = New System.Drawing.Point(13, 179)
        Me.Pfad_CBParallelProblem.Name = "Pfad_CBParallelProblem"
        Me.Pfad_CBParallelProblem.Size = New System.Drawing.Size(144, 17)
        Me.Pfad_CBParallelProblem.TabIndex = 22
        Me.Pfad_CBParallelProblem.Text = "Parallel Crossing Problem"
        Me.Pfad_CBParallelProblem.UseVisualStyleBackColor = True
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Location = New System.Drawing.Point(149, 153)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(65, 13)
        Me.Label42.TabIndex = 21
        Me.Label42.Text = "Ampelphase"
        '
        'Pfad_CBAmpel
        '
        Me.Pfad_CBAmpel.FormattingEnabled = True
        Me.Pfad_CBAmpel.Items.AddRange(New Object() {"Kein", "Gerade", "Links", "Rechts"})
        Me.Pfad_CBAmpel.Location = New System.Drawing.Point(224, 150)
        Me.Pfad_CBAmpel.Name = "Pfad_CBAmpel"
        Me.Pfad_CBAmpel.Size = New System.Drawing.Size(72, 21)
        Me.Pfad_CBAmpel.TabIndex = 20
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Location = New System.Drawing.Point(6, 153)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(39, 13)
        Me.Label41.TabIndex = 19
        Me.Label41.Text = "Blinker"
        '
        'Pfad_CBBlinker
        '
        Me.Pfad_CBBlinker.FormattingEnabled = True
        Me.Pfad_CBBlinker.Items.AddRange(New Object() {"Kein", "Gerade", "Links", "Rechts"})
        Me.Pfad_CBBlinker.Location = New System.Drawing.Point(70, 150)
        Me.Pfad_CBBlinker.Name = "Pfad_CBBlinker"
        Me.Pfad_CBBlinker.Size = New System.Drawing.Size(72, 21)
        Me.Pfad_CBBlinker.TabIndex = 18
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Location = New System.Drawing.Point(149, 126)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(50, 13)
        Me.Label40.TabIndex = 17
        Me.Label40.Text = "Richtung"
        '
        'Pfad_CBRichtung
        '
        Me.Pfad_CBRichtung.FormattingEnabled = True
        Me.Pfad_CBRichtung.Items.AddRange(New Object() {"Vorwärts", "Rückwärts", "Beide"})
        Me.Pfad_CBRichtung.Location = New System.Drawing.Point(224, 123)
        Me.Pfad_CBRichtung.Name = "Pfad_CBRichtung"
        Me.Pfad_CBRichtung.Size = New System.Drawing.Size(72, 21)
        Me.Pfad_CBRichtung.TabIndex = 16
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Location = New System.Drawing.Point(6, 126)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(25, 13)
        Me.Label39.TabIndex = 15
        Me.Label39.Text = "Typ"
        '
        'Pfad_CBTyp
        '
        Me.Pfad_CBTyp.FormattingEnabled = True
        Me.Pfad_CBTyp.Items.AddRange(New Object() {"Straße", "Fußweg", "Schiene", "Luftweg"})
        Me.Pfad_CBTyp.Location = New System.Drawing.Point(70, 123)
        Me.Pfad_CBTyp.Name = "Pfad_CBTyp"
        Me.Pfad_CBTyp.Size = New System.Drawing.Size(72, 21)
        Me.Pfad_CBTyp.TabIndex = 14
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Location = New System.Drawing.Point(149, 74)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(61, 13)
        Me.Label38.TabIndex = 13
        Me.Label38.Text = "Grad. Ende"
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(149, 48)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(58, 13)
        Me.Label37.TabIndex = 12
        Me.Label37.Text = "Grad. Start"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(149, 22)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(34, 13)
        Me.Label36.TabIndex = 11
        Me.Label36.Text = "Breite"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(6, 100)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(40, 13)
        Me.Label35.TabIndex = 10
        Me.Label35.Text = "Winkel"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(6, 74)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(40, 13)
        Me.Label34.TabIndex = 9
        Me.Label34.Text = "Radius"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(6, 48)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(37, 13)
        Me.Label33.TabIndex = 8
        Me.Label33.Text = "Länge"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(6, 22)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(48, 13)
        Me.Label32.TabIndex = 7
        Me.Label32.Text = "Drehung"
        '
        'Pfad_TBEndWinkel
        '
        Me.Pfad_TBEndWinkel.Location = New System.Drawing.Point(224, 71)
        Me.Pfad_TBEndWinkel.Name = "Pfad_TBEndWinkel"
        Me.Pfad_TBEndWinkel.Size = New System.Drawing.Size(72, 20)
        Me.Pfad_TBEndWinkel.TabIndex = 6
        '
        'Pfad_TBStartWinkel
        '
        Me.Pfad_TBStartWinkel.Location = New System.Drawing.Point(224, 45)
        Me.Pfad_TBStartWinkel.Name = "Pfad_TBStartWinkel"
        Me.Pfad_TBStartWinkel.Size = New System.Drawing.Size(72, 20)
        Me.Pfad_TBStartWinkel.TabIndex = 5
        '
        'Pfad_TBBreite
        '
        Me.Pfad_TBBreite.Location = New System.Drawing.Point(224, 19)
        Me.Pfad_TBBreite.Name = "Pfad_TBBreite"
        Me.Pfad_TBBreite.Size = New System.Drawing.Size(72, 20)
        Me.Pfad_TBBreite.TabIndex = 4
        '
        'Pfad_TBWinkel
        '
        Me.Pfad_TBWinkel.Location = New System.Drawing.Point(70, 97)
        Me.Pfad_TBWinkel.Name = "Pfad_TBWinkel"
        Me.Pfad_TBWinkel.Size = New System.Drawing.Size(72, 20)
        Me.Pfad_TBWinkel.TabIndex = 3
        '
        'Pfad_TBRadius
        '
        Me.Pfad_TBRadius.Location = New System.Drawing.Point(70, 71)
        Me.Pfad_TBRadius.Name = "Pfad_TBRadius"
        Me.Pfad_TBRadius.Size = New System.Drawing.Size(72, 20)
        Me.Pfad_TBRadius.TabIndex = 2
        '
        'Pfad_TBLänge
        '
        Me.Pfad_TBLänge.Location = New System.Drawing.Point(70, 45)
        Me.Pfad_TBLänge.Name = "Pfad_TBLänge"
        Me.Pfad_TBLänge.Size = New System.Drawing.Size(72, 20)
        Me.Pfad_TBLänge.TabIndex = 1
        '
        'Pfad_TBRot
        '
        Me.Pfad_TBRot.Location = New System.Drawing.Point(70, 19)
        Me.Pfad_TBRot.Name = "Pfad_TBRot"
        Me.Pfad_TBRot.Size = New System.Drawing.Size(72, 20)
        Me.Pfad_TBRot.TabIndex = 0
        '
        'GBSpline
        '
        Me.GBSpline.Controls.Add(Me.Spline_CBVisible)
        Me.GBSpline.Controls.Add(Me.Splines_CBCollision)
        Me.GBSpline.Controls.Add(Me.Label95)
        Me.GBSpline.Controls.Add(Me.Label94)
        Me.GBSpline.Controls.Add(Me.Spline_TBEndZ)
        Me.GBSpline.Controls.Add(Me.Spline_TBStartZ)
        Me.GBSpline.Controls.Add(Me.Label93)
        Me.GBSpline.Controls.Add(Me.Spline_TBEndX)
        Me.GBSpline.Controls.Add(Me.Spline_TBStartX)
        Me.GBSpline.Controls.Add(Me.Label92)
        Me.GBSpline.Controls.Add(Me.Spline_MinMax)
        Me.GBSpline.Location = New System.Drawing.Point(4, 819)
        Me.GBSpline.Name = "GBSpline"
        Me.GBSpline.Size = New System.Drawing.Size(327, 102)
        Me.GBSpline.TabIndex = 26
        Me.GBSpline.TabStop = False
        Me.GBSpline.Text = "Spline"
        Me.GBSpline.Visible = False
        '
        'Spline_CBVisible
        '
        Me.Spline_CBVisible.AutoSize = True
        Me.Spline_CBVisible.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Spline_CBVisible.Checked = True
        Me.Spline_CBVisible.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Spline_CBVisible.Location = New System.Drawing.Point(86, 73)
        Me.Spline_CBVisible.Name = "Spline_CBVisible"
        Me.Spline_CBVisible.Size = New System.Drawing.Size(65, 17)
        Me.Spline_CBVisible.TabIndex = 46
        Me.Spline_CBVisible.Text = "Sichtbar"
        Me.Spline_CBVisible.UseVisualStyleBackColor = True
        '
        'Splines_CBCollision
        '
        Me.Splines_CBCollision.AutoSize = True
        Me.Splines_CBCollision.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Splines_CBCollision.Location = New System.Drawing.Point(7, 73)
        Me.Splines_CBCollision.Name = "Splines_CBCollision"
        Me.Splines_CBCollision.Size = New System.Drawing.Size(64, 17)
        Me.Splines_CBCollision.TabIndex = 45
        Me.Splines_CBCollision.Text = "Kollision"
        Me.Splines_CBCollision.UseVisualStyleBackColor = True
        '
        'Label95
        '
        Me.Label95.AutoSize = True
        Me.Label95.Location = New System.Drawing.Point(149, 50)
        Me.Label95.Name = "Label95"
        Me.Label95.Size = New System.Drawing.Size(36, 13)
        Me.Label95.TabIndex = 44
        Me.Label95.Text = "End Z"
        '
        'Label94
        '
        Me.Label94.AutoSize = True
        Me.Label94.Location = New System.Drawing.Point(4, 50)
        Me.Label94.Name = "Label94"
        Me.Label94.Size = New System.Drawing.Size(39, 13)
        Me.Label94.TabIndex = 43
        Me.Label94.Text = "Start Z"
        '
        'Spline_TBEndZ
        '
        Me.Spline_TBEndZ.Location = New System.Drawing.Point(224, 47)
        Me.Spline_TBEndZ.Name = "Spline_TBEndZ"
        Me.Spline_TBEndZ.Size = New System.Drawing.Size(71, 20)
        Me.Spline_TBEndZ.TabIndex = 42
        '
        'Spline_TBStartZ
        '
        Me.Spline_TBStartZ.Location = New System.Drawing.Point(69, 47)
        Me.Spline_TBStartZ.Name = "Spline_TBStartZ"
        Me.Spline_TBStartZ.Size = New System.Drawing.Size(72, 20)
        Me.Spline_TBStartZ.TabIndex = 41
        '
        'Label93
        '
        Me.Label93.AutoSize = True
        Me.Label93.Location = New System.Drawing.Point(149, 24)
        Me.Label93.Name = "Label93"
        Me.Label93.Size = New System.Drawing.Size(36, 13)
        Me.Label93.TabIndex = 40
        Me.Label93.Text = "End X"
        '
        'Spline_TBEndX
        '
        Me.Spline_TBEndX.Location = New System.Drawing.Point(224, 21)
        Me.Spline_TBEndX.Name = "Spline_TBEndX"
        Me.Spline_TBEndX.Size = New System.Drawing.Size(71, 20)
        Me.Spline_TBEndX.TabIndex = 39
        '
        'Spline_TBStartX
        '
        Me.Spline_TBStartX.Location = New System.Drawing.Point(69, 21)
        Me.Spline_TBStartX.Name = "Spline_TBStartX"
        Me.Spline_TBStartX.Size = New System.Drawing.Size(72, 20)
        Me.Spline_TBStartX.TabIndex = 38
        '
        'Label92
        '
        Me.Label92.AutoSize = True
        Me.Label92.Location = New System.Drawing.Point(4, 24)
        Me.Label92.Name = "Label92"
        Me.Label92.Size = New System.Drawing.Size(39, 13)
        Me.Label92.TabIndex = 37
        Me.Label92.Text = "Start X"
        '
        'Spline_MinMax
        '
        Me.Spline_MinMax.Location = New System.Drawing.Point(302, 0)
        Me.Spline_MinMax.Name = "Spline_MinMax"
        Me.Spline_MinMax.Size = New System.Drawing.Size(26, 19)
        Me.Spline_MinMax.TabIndex = 36
        Me.Spline_MinMax.Text = "-"
        Me.Spline_MinMax.UseVisualStyleBackColor = True
        '
        'GBAllgemein
        '
        Me.GBAllgemein.Controls.Add(Me.TBName)
        Me.GBAllgemein.Controls.Add(Me.Label)
        Me.GBAllgemein.Controls.Add(Me.Label3)
        Me.GBAllgemein.Controls.Add(Me.PSPos)
        Me.GBAllgemein.Location = New System.Drawing.Point(4, 3)
        Me.GBAllgemein.Name = "GBAllgemein"
        Me.GBAllgemein.Size = New System.Drawing.Size(327, 77)
        Me.GBAllgemein.TabIndex = 25
        Me.GBAllgemein.TabStop = False
        Me.GBAllgemein.Text = "Allgemein"
        '
        'TBName
        '
        Me.TBName.Location = New System.Drawing.Point(69, 19)
        Me.TBName.Name = "TBName"
        Me.TBName.ReadOnly = True
        Me.TBName.Size = New System.Drawing.Size(226, 20)
        Me.TBName.TabIndex = 1
        '
        'Label
        '
        Me.Label.AutoSize = True
        Me.Label.Location = New System.Drawing.Point(8, 21)
        Me.Label.Name = "Label"
        Me.Label.Size = New System.Drawing.Size(35, 13)
        Me.Label.TabIndex = 0
        Me.Label.Text = "Name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Position"
        '
        'GBMesh
        '
        Me.GBMesh.Controls.Add(Me.Mesh_TBMeshident)
        Me.GBMesh.Controls.Add(Me.Label17)
        Me.GBMesh.Controls.Add(Me.Mesh_MinMax)
        Me.GBMesh.Controls.Add(Me.Label31)
        Me.GBMesh.Controls.Add(Me.Mesh_NUMax)
        Me.GBMesh.Controls.Add(Me.Mesh_NUMin)
        Me.GBMesh.Controls.Add(Me.Label30)
        Me.GBMesh.Controls.Add(Me.Mesh_TBSichtbarkeitVal)
        Me.GBMesh.Controls.Add(Me.Mesh_VSKlickevent)
        Me.GBMesh.Controls.Add(Me.Mesh_VSSichtbarkeit)
        Me.GBMesh.Controls.Add(Me.Mesh_PSCenter)
        Me.GBMesh.Controls.Add(Me.Label5)
        Me.GBMesh.Controls.Add(Me.Label2)
        Me.GBMesh.Controls.Add(Me.Mesh_DDViedpoint)
        Me.GBMesh.Controls.Add(Me.Label1)
        Me.GBMesh.Controls.Add(Me.Label4)
        Me.GBMesh.Location = New System.Drawing.Point(4, 153)
        Me.GBMesh.Name = "GBMesh"
        Me.GBMesh.Size = New System.Drawing.Size(327, 178)
        Me.GBMesh.TabIndex = 21
        Me.GBMesh.TabStop = False
        Me.GBMesh.Text = "Mesh"
        Me.GBMesh.Visible = False
        '
        'Mesh_TBMeshident
        '
        Me.Mesh_TBMeshident.Location = New System.Drawing.Point(70, 152)
        Me.Mesh_TBMeshident.Name = "Mesh_TBMeshident"
        Me.Mesh_TBMeshident.Size = New System.Drawing.Size(225, 20)
        Me.Mesh_TBMeshident.TabIndex = 36
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(3, 155)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(56, 13)
        Me.Label17.TabIndex = 35
        Me.Label17.Text = "Meshident"
        '
        'Mesh_MinMax
        '
        Me.Mesh_MinMax.Location = New System.Drawing.Point(302, 0)
        Me.Mesh_MinMax.Name = "Mesh_MinMax"
        Me.Mesh_MinMax.Size = New System.Drawing.Size(26, 19)
        Me.Mesh_MinMax.TabIndex = 34
        Me.Mesh_MinMax.Text = "-"
        Me.Mesh_MinMax.UseVisualStyleBackColor = True
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(161, 128)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(54, 13)
        Me.Label31.TabIndex = 33
        Me.Label31.Text = "LOD max."
        '
        'Mesh_NUMax
        '
        Me.Mesh_NUMax.DecimalPlaces = 2
        Me.Mesh_NUMax.Increment = New Decimal(New Integer() {5, 0, 0, 131072})
        Me.Mesh_NUMax.Location = New System.Drawing.Point(224, 126)
        Me.Mesh_NUMax.Name = "Mesh_NUMax"
        Me.Mesh_NUMax.Size = New System.Drawing.Size(71, 20)
        Me.Mesh_NUMax.TabIndex = 32
        Me.Mesh_NUMax.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Mesh_NUMin
        '
        Me.Mesh_NUMin.DecimalPlaces = 2
        Me.Mesh_NUMin.Increment = New Decimal(New Integer() {5, 0, 0, 131072})
        Me.Mesh_NUMin.Location = New System.Drawing.Point(70, 126)
        Me.Mesh_NUMin.Maximum = New Decimal(New Integer() {2, 0, 0, 0})
        Me.Mesh_NUMin.Name = "Mesh_NUMin"
        Me.Mesh_NUMin.Size = New System.Drawing.Size(71, 20)
        Me.Mesh_NUMin.TabIndex = 31
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(3, 127)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(51, 13)
        Me.Label30.TabIndex = 30
        Me.Label30.Text = "LOD min."
        '
        'Mesh_TBSichtbarkeitVal
        '
        Me.Mesh_TBSichtbarkeitVal.Location = New System.Drawing.Point(224, 72)
        Me.Mesh_TBSichtbarkeitVal.Name = "Mesh_TBSichtbarkeitVal"
        Me.Mesh_TBSichtbarkeitVal.Size = New System.Drawing.Size(71, 20)
        Me.Mesh_TBSichtbarkeitVal.TabIndex = 29
        Me.Mesh_TBSichtbarkeitVal.Text = "0"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(3, 23)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(57, 13)
        Me.Label5.TabIndex = 24
        Me.Label5.Text = "Klickevent"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 75)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Sichtbarkeit"
        '
        'Mesh_DDViedpoint
        '
        Me.Mesh_DDViedpoint.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Mesh_DDViedpoint.FormattingEnabled = True
        Me.Mesh_DDViedpoint.Items.AddRange(New Object() {"Immer", "Außen", "Innen", "Außen + Innen", "AI-Bus", "AI-Bus + Außen", "AI-Bus + Innen"})
        Me.Mesh_DDViedpoint.Location = New System.Drawing.Point(69, 45)
        Me.Mesh_DDViedpoint.Name = "Mesh_DDViedpoint"
        Me.Mesh_DDViedpoint.Size = New System.Drawing.Size(226, 21)
        Me.Mesh_DDViedpoint.TabIndex = 21
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Viewpoint"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 103)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 13)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Center"
        '
        'GBParent
        '
        Me.GBParent.Controls.Add(Me.Parent_MinMax)
        Me.GBParent.Controls.Add(Me.Parent_CBParent)
        Me.GBParent.Controls.Add(Me.Label25)
        Me.GBParent.Location = New System.Drawing.Point(4, 94)
        Me.GBParent.Name = "GBParent"
        Me.GBParent.Size = New System.Drawing.Size(327, 53)
        Me.GBParent.TabIndex = 24
        Me.GBParent.TabStop = False
        Me.GBParent.Text = "Parent Objekt"
        '
        'Parent_MinMax
        '
        Me.Parent_MinMax.Location = New System.Drawing.Point(302, 0)
        Me.Parent_MinMax.Name = "Parent_MinMax"
        Me.Parent_MinMax.Size = New System.Drawing.Size(26, 19)
        Me.Parent_MinMax.TabIndex = 35
        Me.Parent_MinMax.Text = "-"
        Me.Parent_MinMax.UseVisualStyleBackColor = True
        '
        'Parent_CBParent
        '
        Me.Parent_CBParent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Parent_CBParent.FormattingEnabled = True
        Me.Parent_CBParent.Location = New System.Drawing.Point(69, 20)
        Me.Parent_CBParent.Name = "Parent_CBParent"
        Me.Parent_CBParent.Size = New System.Drawing.Size(226, 21)
        Me.Parent_CBParent.Sorted = True
        Me.Parent_CBParent.TabIndex = 60
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(3, 23)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(60, 13)
        Me.Label25.TabIndex = 59
        Me.Label25.Text = "Parent Obj."
        '
        'GBBones
        '
        Me.GBBones.Controls.Add(Me.Bones_MinMax)
        Me.GBBones.Controls.Add(Me.Label27)
        Me.GBBones.Controls.Add(Me.Bones_CBParent)
        Me.GBBones.Controls.Add(Me.Bones_TBName)
        Me.GBBones.Controls.Add(Me.Label26)
        Me.GBBones.Location = New System.Drawing.Point(3, 2857)
        Me.GBBones.Name = "GBBones"
        Me.GBBones.Size = New System.Drawing.Size(327, 78)
        Me.GBBones.TabIndex = 23
        Me.GBBones.TabStop = False
        Me.GBBones.Text = "Bones"
        Me.GBBones.Visible = False
        '
        'Bones_MinMax
        '
        Me.Bones_MinMax.Location = New System.Drawing.Point(302, 0)
        Me.Bones_MinMax.Name = "Bones_MinMax"
        Me.Bones_MinMax.Size = New System.Drawing.Size(26, 19)
        Me.Bones_MinMax.TabIndex = 35
        Me.Bones_MinMax.Text = "-"
        Me.Bones_MinMax.UseVisualStyleBackColor = True
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(4, 47)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(50, 13)
        Me.Label27.TabIndex = 28
        Me.Label27.Text = "Parent to"
        '
        'Bones_CBParent
        '
        Me.Bones_CBParent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Bones_CBParent.FormattingEnabled = True
        Me.Bones_CBParent.Location = New System.Drawing.Point(70, 44)
        Me.Bones_CBParent.Name = "Bones_CBParent"
        Me.Bones_CBParent.Size = New System.Drawing.Size(230, 21)
        Me.Bones_CBParent.Sorted = True
        Me.Bones_CBParent.TabIndex = 27
        '
        'Bones_TBName
        '
        Me.Bones_TBName.Location = New System.Drawing.Point(70, 20)
        Me.Bones_TBName.Name = "Bones_TBName"
        Me.Bones_TBName.Size = New System.Drawing.Size(230, 20)
        Me.Bones_TBName.TabIndex = 1
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(4, 21)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(35, 13)
        Me.Label26.TabIndex = 0
        Me.Label26.Text = "Name"
        '
        'GBBel
        '
        Me.GBBel.Controls.Add(Me.Label91)
        Me.GBBel.Controls.Add(Me.Label90)
        Me.GBBel.Controls.Add(Me.Label89)
        Me.GBBel.Controls.Add(Me.Label88)
        Me.GBBel.Controls.Add(Me.Bel_MinMax)
        Me.GBBel.Controls.Add(Me.Bel_BTKeine)
        Me.GBBel.Controls.Add(Me.Bel_BTBerechnen)
        Me.GBBel.Controls.Add(Me.Bel_CB1)
        Me.GBBel.Controls.Add(Me.Bel_CB2)
        Me.GBBel.Controls.Add(Me.Bel_CB3)
        Me.GBBel.Controls.Add(Me.Label11)
        Me.GBBel.Controls.Add(Me.Bel_CB0)
        Me.GBBel.Location = New System.Drawing.Point(4, 2756)
        Me.GBBel.Name = "GBBel"
        Me.GBBel.Size = New System.Drawing.Size(327, 78)
        Me.GBBel.TabIndex = 20
        Me.GBBel.TabStop = False
        Me.GBBel.Text = "Beleuchtung"
        Me.GBBel.Visible = False
        '
        'Label91
        '
        Me.Label91.AutoSize = True
        Me.Label91.Location = New System.Drawing.Point(144, 49)
        Me.Label91.Name = "Label91"
        Me.Label91.Size = New System.Drawing.Size(13, 13)
        Me.Label91.TabIndex = 41
        Me.Label91.Text = "3"
        '
        'Label90
        '
        Me.Label90.AutoSize = True
        Me.Label90.Location = New System.Drawing.Point(70, 49)
        Me.Label90.Name = "Label90"
        Me.Label90.Size = New System.Drawing.Size(13, 13)
        Me.Label90.TabIndex = 40
        Me.Label90.Text = "2"
        '
        'Label89
        '
        Me.Label89.AutoSize = True
        Me.Label89.Location = New System.Drawing.Point(144, 21)
        Me.Label89.Name = "Label89"
        Me.Label89.Size = New System.Drawing.Size(13, 13)
        Me.Label89.TabIndex = 39
        Me.Label89.Text = "1"
        '
        'Label88
        '
        Me.Label88.AutoSize = True
        Me.Label88.Location = New System.Drawing.Point(70, 21)
        Me.Label88.Name = "Label88"
        Me.Label88.Size = New System.Drawing.Size(13, 13)
        Me.Label88.TabIndex = 38
        Me.Label88.Text = "0"
        '
        'Bel_MinMax
        '
        Me.Bel_MinMax.Location = New System.Drawing.Point(302, 0)
        Me.Bel_MinMax.Name = "Bel_MinMax"
        Me.Bel_MinMax.Size = New System.Drawing.Size(26, 19)
        Me.Bel_MinMax.TabIndex = 37
        Me.Bel_MinMax.Text = "-"
        Me.Bel_MinMax.UseVisualStyleBackColor = True
        '
        'Bel_BTKeine
        '
        Me.Bel_BTKeine.Location = New System.Drawing.Point(220, 44)
        Me.Bel_BTKeine.Name = "Bel_BTKeine"
        Me.Bel_BTKeine.Size = New System.Drawing.Size(75, 23)
        Me.Bel_BTKeine.TabIndex = 32
        Me.Bel_BTKeine.Text = "Keine"
        Me.Bel_BTKeine.UseVisualStyleBackColor = True
        '
        'Bel_BTBerechnen
        '
        Me.Bel_BTBerechnen.Location = New System.Drawing.Point(220, 18)
        Me.Bel_BTBerechnen.Name = "Bel_BTBerechnen"
        Me.Bel_BTBerechnen.Size = New System.Drawing.Size(75, 23)
        Me.Bel_BTBerechnen.TabIndex = 31
        Me.Bel_BTBerechnen.Text = "Berechnen"
        Me.Bel_BTBerechnen.UseVisualStyleBackColor = True
        '
        'Bel_CB1
        '
        Me.Bel_CB1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Bel_CB1.FormattingEnabled = True
        Me.Bel_CB1.Items.AddRange(New Object() {"-1"})
        Me.Bel_CB1.Location = New System.Drawing.Point(160, 18)
        Me.Bel_CB1.Name = "Bel_CB1"
        Me.Bel_CB1.Size = New System.Drawing.Size(55, 21)
        Me.Bel_CB1.Sorted = True
        Me.Bel_CB1.TabIndex = 30
        '
        'Bel_CB2
        '
        Me.Bel_CB2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Bel_CB2.FormattingEnabled = True
        Me.Bel_CB2.Items.AddRange(New Object() {"-1"})
        Me.Bel_CB2.Location = New System.Drawing.Point(86, 45)
        Me.Bel_CB2.Name = "Bel_CB2"
        Me.Bel_CB2.Size = New System.Drawing.Size(55, 21)
        Me.Bel_CB2.Sorted = True
        Me.Bel_CB2.TabIndex = 29
        '
        'Bel_CB3
        '
        Me.Bel_CB3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Bel_CB3.FormattingEnabled = True
        Me.Bel_CB3.Items.AddRange(New Object() {"-1"})
        Me.Bel_CB3.Location = New System.Drawing.Point(160, 46)
        Me.Bel_CB3.Name = "Bel_CB3"
        Me.Bel_CB3.Size = New System.Drawing.Size(55, 21)
        Me.Bel_CB3.Sorted = True
        Me.Bel_CB3.TabIndex = 28
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(3, 35)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(64, 13)
        Me.Label11.TabIndex = 27
        Me.Label11.Text = "Lichtquellen"
        '
        'Bel_CB0
        '
        Me.Bel_CB0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Bel_CB0.FormattingEnabled = True
        Me.Bel_CB0.Items.AddRange(New Object() {"-1"})
        Me.Bel_CB0.Location = New System.Drawing.Point(86, 18)
        Me.Bel_CB0.Name = "Bel_CB0"
        Me.Bel_CB0.Size = New System.Drawing.Size(55, 21)
        Me.Bel_CB0.Sorted = True
        Me.Bel_CB0.TabIndex = 27
        '
        'GBLicht
        '
        Me.GBLicht.Controls.Add(Me.Label83)
        Me.GBLicht.Controls.Add(Me.Button2)
        Me.GBLicht.Controls.Add(Me.Licht_MinMax)
        Me.GBLicht.Controls.Add(Me.Licht_VSVar)
        Me.GBLicht.Controls.Add(Me.Licht_PSVector)
        Me.GBLicht.Controls.Add(Me.Licht_PSRichtung)
        Me.GBLicht.Controls.Add(Me.Licht_TBZeitkonst)
        Me.GBLicht.Controls.Add(Me.Label24)
        Me.GBLicht.Controls.Add(Me.Licht_TBKegel)
        Me.GBLicht.Controls.Add(Me.Label23)
        Me.GBLicht.Controls.Add(Me.Label22)
        Me.GBLicht.Controls.Add(Me.Licht_CBEffekt)
        Me.GBLicht.Controls.Add(Me.Licht_TBOffset)
        Me.GBLicht.Controls.Add(Me.Label21)
        Me.GBLicht.Controls.Add(Me.Licht_TBFaktor)
        Me.GBLicht.Controls.Add(Me.Label20)
        Me.GBLicht.Controls.Add(Me.Licht_TBOuterCone)
        Me.GBLicht.Controls.Add(Me.Label18)
        Me.GBLicht.Controls.Add(Me.Licht_TBInnerCone)
        Me.GBLicht.Controls.Add(Me.Label19)
        Me.GBLicht.Controls.Add(Me.Licht_TBGroesse)
        Me.GBLicht.Controls.Add(Me.Label16)
        Me.GBLicht.Controls.Add(Me.Label15)
        Me.GBLicht.Controls.Add(Me.Licht_CBRotAusr)
        Me.GBLicht.Controls.Add(Me.Label14)
        Me.GBLicht.Controls.Add(Me.Licht_CBAusr)
        Me.GBLicht.Controls.Add(Me.Label13)
        Me.GBLicht.Controls.Add(Me.Licht_CSFarbe)
        Me.GBLicht.Controls.Add(Me.Label8)
        Me.GBLicht.Controls.Add(Me.Label7)
        Me.GBLicht.Controls.Add(Me.Licht_TBTexture)
        Me.GBLicht.Controls.Add(Me.Label6)
        Me.GBLicht.Location = New System.Drawing.Point(4, 525)
        Me.GBLicht.Name = "GBLicht"
        Me.GBLicht.Size = New System.Drawing.Size(327, 288)
        Me.GBLicht.TabIndex = 8
        Me.GBLicht.TabStop = False
        Me.GBLicht.Text = "Licht"
        Me.GBLicht.Visible = False
        '
        'Label83
        '
        Me.Label83.AutoSize = True
        Me.Label83.Location = New System.Drawing.Point(3, 132)
        Me.Label83.Name = "Label83"
        Me.Label83.Size = New System.Drawing.Size(34, 13)
        Me.Label83.TabIndex = 61
        Me.Label83.Text = "Farbe"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(224, 258)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(72, 23)
        Me.Button2.TabIndex = 60
        Me.Button2.Text = "keine"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Licht_MinMax
        '
        Me.Licht_MinMax.Location = New System.Drawing.Point(302, 0)
        Me.Licht_MinMax.Name = "Licht_MinMax"
        Me.Licht_MinMax.Size = New System.Drawing.Size(26, 19)
        Me.Licht_MinMax.TabIndex = 59
        Me.Licht_MinMax.Text = "-"
        Me.Licht_MinMax.UseVisualStyleBackColor = True
        '
        'Licht_TBZeitkonst
        '
        Me.Licht_TBZeitkonst.Location = New System.Drawing.Point(224, 207)
        Me.Licht_TBZeitkonst.Name = "Licht_TBZeitkonst"
        Me.Licht_TBZeitkonst.Size = New System.Drawing.Size(72, 20)
        Me.Licht_TBZeitkonst.TabIndex = 56
        Me.Licht_TBZeitkonst.Text = "0"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(149, 210)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(54, 13)
        Me.Label24.TabIndex = 55
        Me.Label24.Text = "Zeitkonst."
        '
        'Licht_TBKegel
        '
        Me.Licht_TBKegel.Location = New System.Drawing.Point(70, 234)
        Me.Licht_TBKegel.Name = "Licht_TBKegel"
        Me.Licht_TBKegel.Size = New System.Drawing.Size(72, 20)
        Me.Licht_TBKegel.TabIndex = 54
        Me.Licht_TBKegel.Text = "0"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(3, 237)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(34, 13)
        Me.Label23.TabIndex = 53
        Me.Label23.Text = "Kegel"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(149, 236)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(35, 13)
        Me.Label22.TabIndex = 52
        Me.Label22.Text = "Effekt"
        '
        'Licht_CBEffekt
        '
        Me.Licht_CBEffekt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Licht_CBEffekt.FormattingEnabled = True
        Me.Licht_CBEffekt.Items.AddRange(New Object() {"beide", "kein Nebel", "keiner", "Stern"})
        Me.Licht_CBEffekt.Location = New System.Drawing.Point(224, 233)
        Me.Licht_CBEffekt.Name = "Licht_CBEffekt"
        Me.Licht_CBEffekt.Size = New System.Drawing.Size(72, 21)
        Me.Licht_CBEffekt.Sorted = True
        Me.Licht_CBEffekt.TabIndex = 51
        '
        'Licht_TBOffset
        '
        Me.Licht_TBOffset.Location = New System.Drawing.Point(224, 182)
        Me.Licht_TBOffset.Name = "Licht_TBOffset"
        Me.Licht_TBOffset.Size = New System.Drawing.Size(72, 20)
        Me.Licht_TBOffset.TabIndex = 50
        Me.Licht_TBOffset.Text = "0"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(149, 185)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(35, 13)
        Me.Label21.TabIndex = 49
        Me.Label21.Text = "Offset"
        '
        'Licht_TBFaktor
        '
        Me.Licht_TBFaktor.Location = New System.Drawing.Point(70, 208)
        Me.Licht_TBFaktor.Name = "Licht_TBFaktor"
        Me.Licht_TBFaktor.Size = New System.Drawing.Size(72, 20)
        Me.Licht_TBFaktor.TabIndex = 48
        Me.Licht_TBFaktor.Text = "0"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(4, 211)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(37, 13)
        Me.Label20.TabIndex = 47
        Me.Label20.Text = "Faktor"
        '
        'Licht_TBOuterCone
        '
        Me.Licht_TBOuterCone.Location = New System.Drawing.Point(224, 156)
        Me.Licht_TBOuterCone.Name = "Licht_TBOuterCone"
        Me.Licht_TBOuterCone.Size = New System.Drawing.Size(72, 20)
        Me.Licht_TBOuterCone.TabIndex = 46
        Me.Licht_TBOuterCone.Text = "0"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(149, 159)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(70, 13)
        Me.Label18.TabIndex = 45
        Me.Label18.Text = "Winkel (auß.)"
        '
        'Licht_TBInnerCone
        '
        Me.Licht_TBInnerCone.Location = New System.Drawing.Point(70, 182)
        Me.Licht_TBInnerCone.Name = "Licht_TBInnerCone"
        Me.Licht_TBInnerCone.Size = New System.Drawing.Size(72, 20)
        Me.Licht_TBInnerCone.TabIndex = 44
        Me.Licht_TBInnerCone.Text = "0"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(4, 185)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(60, 13)
        Me.Label19.TabIndex = 43
        Me.Label19.Text = "Winkel (in.)"
        '
        'Licht_TBGroesse
        '
        Me.Licht_TBGroesse.Location = New System.Drawing.Point(70, 156)
        Me.Licht_TBGroesse.Name = "Licht_TBGroesse"
        Me.Licht_TBGroesse.Size = New System.Drawing.Size(72, 20)
        Me.Licht_TBGroesse.TabIndex = 40
        Me.Licht_TBGroesse.Text = "0"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(4, 159)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(36, 13)
        Me.Label16.TabIndex = 39
        Me.Label16.Text = "Größe"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(148, 103)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(68, 13)
        Me.Label15.TabIndex = 38
        Me.Label15.Text = "Rot Ausricht."
        '
        'Licht_CBRotAusr
        '
        Me.Licht_CBRotAusr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Licht_CBRotAusr.FormattingEnabled = True
        Me.Licht_CBRotAusr.Items.AddRange(New Object() {"0 Vektor", "1 Sichtfeld", "2 Kamera"})
        Me.Licht_CBRotAusr.Location = New System.Drawing.Point(224, 100)
        Me.Licht_CBRotAusr.Name = "Licht_CBRotAusr"
        Me.Licht_CBRotAusr.Size = New System.Drawing.Size(72, 21)
        Me.Licht_CBRotAusr.Sorted = True
        Me.Licht_CBRotAusr.TabIndex = 37
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(4, 100)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(48, 13)
        Me.Label14.TabIndex = 36
        Me.Label14.Text = "Ausricht."
        '
        'Licht_CBAusr
        '
        Me.Licht_CBAusr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Licht_CBAusr.FormattingEnabled = True
        Me.Licht_CBAusr.Items.AddRange(New Object() {"alle Richtungen", "Gerichtet"})
        Me.Licht_CBAusr.Location = New System.Drawing.Point(70, 97)
        Me.Licht_CBAusr.Name = "Licht_CBAusr"
        Me.Licht_CBAusr.Size = New System.Drawing.Size(72, 21)
        Me.Licht_CBAusr.Sorted = True
        Me.Licht_CBAusr.TabIndex = 35
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(4, 73)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(38, 13)
        Me.Label13.TabIndex = 30
        Me.Label13.Text = "Vektor"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(4, 50)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(50, 13)
        Me.Label8.TabIndex = 26
        Me.Label8.Text = "Richtung"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(3, 263)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(43, 13)
        Me.Label7.TabIndex = 21
        Me.Label7.Text = "Texture"
        '
        'Licht_TBTexture
        '
        Me.Licht_TBTexture.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Licht_TBTexture.Location = New System.Drawing.Point(69, 260)
        Me.Licht_TBTexture.Name = "Licht_TBTexture"
        Me.Licht_TBTexture.Size = New System.Drawing.Size(156, 20)
        Me.Licht_TBTexture.TabIndex = 20
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(4, 22)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(45, 13)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "Variable"
        '
        'GBMat
        '
        Me.GBMat.Controls.Add(Me.Mat_MinMax)
        Me.GBMat.Controls.Add(Me.Mat_CBZCheck)
        Me.GBMat.Controls.Add(Me.Mat_CBZWrite)
        Me.GBMat.Controls.Add(Me.Mat_TBAlphascale)
        Me.GBMat.Controls.Add(Me.Label58)
        Me.GBMat.Controls.Add(Me.Mat_CBAlpha)
        Me.GBMat.Controls.Add(Me.Label45)
        Me.GBMat.Controls.Add(Me.Mat_CBTextTex)
        Me.GBMat.Controls.Add(Me.Label12)
        Me.GBMat.Controls.Add(Me.Mat_CBTex)
        Me.GBMat.Controls.Add(Me.Label10)
        Me.GBMat.Location = New System.Drawing.Point(4, 2095)
        Me.GBMat.Name = "GBMat"
        Me.GBMat.Size = New System.Drawing.Size(327, 189)
        Me.GBMat.TabIndex = 7
        Me.GBMat.TabStop = False
        Me.GBMat.Text = "Material"
        '
        'Mat_MinMax
        '
        Me.Mat_MinMax.Location = New System.Drawing.Point(302, 0)
        Me.Mat_MinMax.Name = "Mat_MinMax"
        Me.Mat_MinMax.Size = New System.Drawing.Size(26, 19)
        Me.Mat_MinMax.TabIndex = 37
        Me.Mat_MinMax.Text = "-"
        Me.Mat_MinMax.UseVisualStyleBackColor = True
        '
        'Mat_CBZCheck
        '
        Me.Mat_CBZCheck.AutoSize = True
        Me.Mat_CBZCheck.Location = New System.Drawing.Point(161, 106)
        Me.Mat_CBZCheck.Name = "Mat_CBZCheck"
        Me.Mat_CBZCheck.Size = New System.Drawing.Size(64, 17)
        Me.Mat_CBZCheck.TabIndex = 36
        Me.Mat_CBZCheck.Text = "ZCheck"
        Me.Mat_CBZCheck.UseVisualStyleBackColor = True
        '
        'Mat_CBZWrite
        '
        Me.Mat_CBZWrite.AutoSize = True
        Me.Mat_CBZWrite.Location = New System.Drawing.Point(69, 106)
        Me.Mat_CBZWrite.Name = "Mat_CBZWrite"
        Me.Mat_CBZWrite.Size = New System.Drawing.Size(58, 17)
        Me.Mat_CBZWrite.TabIndex = 35
        Me.Mat_CBZWrite.Text = "ZWrite"
        Me.Mat_CBZWrite.UseVisualStyleBackColor = True
        '
        'Mat_TBAlphascale
        '
        Me.Mat_TBAlphascale.Location = New System.Drawing.Point(224, 80)
        Me.Mat_TBAlphascale.Name = "Mat_TBAlphascale"
        Me.Mat_TBAlphascale.Size = New System.Drawing.Size(72, 20)
        Me.Mat_TBAlphascale.TabIndex = 34
        '
        'Label58
        '
        Me.Label58.AutoSize = True
        Me.Label58.Location = New System.Drawing.Point(161, 83)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(64, 13)
        Me.Label58.TabIndex = 33
        Me.Label58.Text = "Alpha-Scale"
        '
        'Mat_CBAlpha
        '
        Me.Mat_CBAlpha.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Mat_CBAlpha.FormattingEnabled = True
        Me.Mat_CBAlpha.Items.AddRange(New Object() {"keine", "volltransparent", "teiltransparent"})
        Me.Mat_CBAlpha.Location = New System.Drawing.Point(70, 77)
        Me.Mat_CBAlpha.Name = "Mat_CBAlpha"
        Me.Mat_CBAlpha.Size = New System.Drawing.Size(71, 21)
        Me.Mat_CBAlpha.TabIndex = 32
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Location = New System.Drawing.Point(6, 80)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(34, 13)
        Me.Label45.TabIndex = 31
        Me.Label45.Text = "Alpha"
        '
        'Mat_CBTextTex
        '
        Me.Mat_CBTextTex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Mat_CBTextTex.FormattingEnabled = True
        Me.Mat_CBTextTex.Location = New System.Drawing.Point(70, 50)
        Me.Mat_CBTextTex.Name = "Mat_CBTextTex"
        Me.Mat_CBTextTex.Size = New System.Drawing.Size(226, 21)
        Me.Mat_CBTextTex.Sorted = True
        Me.Mat_CBTextTex.TabIndex = 30
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(4, 53)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(50, 13)
        Me.Label12.TabIndex = 28
        Me.Label12.Text = "Use Font"
        '
        'Mat_CBTex
        '
        Me.Mat_CBTex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Mat_CBTex.FormattingEnabled = True
        Me.Mat_CBTex.Location = New System.Drawing.Point(70, 23)
        Me.Mat_CBTex.Name = "Mat_CBTex"
        Me.Mat_CBTex.Size = New System.Drawing.Size(225, 21)
        Me.Mat_CBTex.Sorted = True
        Me.Mat_CBTex.TabIndex = 28
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(3, 26)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(43, 13)
        Me.Label10.TabIndex = 27
        Me.Label10.Text = "Texture"
        '
        'GBAnimation
        '
        Me.GBAnimation.Controls.Add(Me.Label87)
        Me.GBAnimation.Controls.Add(Me.Anim_TBDelay)
        Me.GBAnimation.Controls.Add(Me.Anim_TBMaxSpeed)
        Me.GBAnimation.Controls.Add(Me.Label86)
        Me.GBAnimation.Controls.Add(Me.Panel1)
        Me.GBAnimation.Controls.Add(Me.Anim_PRBArt)
        Me.GBAnimation.Controls.Add(Me.Anim_PSRichtung)
        Me.GBAnimation.Controls.Add(Me.Label85)
        Me.GBAnimation.Controls.Add(Me.Label78)
        Me.GBAnimation.Controls.Add(Me.Label77)
        Me.GBAnimation.Controls.Add(Me.Label76)
        Me.GBAnimation.Controls.Add(Me.Label75)
        Me.GBAnimation.Controls.Add(Me.Anim_PSRotPnt)
        Me.GBAnimation.Controls.Add(Me.Anim_TBAnimGrp)
        Me.GBAnimation.Controls.Add(Me.Anim_MinMax)
        Me.GBAnimation.Controls.Add(Me.Anim_TBValue)
        Me.GBAnimation.Controls.Add(Me.Label29)
        Me.GBAnimation.Controls.Add(Me.Label28)
        Me.GBAnimation.Controls.Add(Me.Anim_VSVar)
        Me.GBAnimation.Controls.Add(Me.Anim_BTLöschen)
        Me.GBAnimation.Controls.Add(Me.Anim_BTNeu)
        Me.GBAnimation.Controls.Add(Me.Anim_DDList)
        Me.GBAnimation.Controls.Add(Me.Label9)
        Me.GBAnimation.Location = New System.Drawing.Point(4, 2288)
        Me.GBAnimation.Name = "GBAnimation"
        Me.GBAnimation.Size = New System.Drawing.Size(327, 256)
        Me.GBAnimation.TabIndex = 6
        Me.GBAnimation.TabStop = False
        Me.GBAnimation.Text = "Animation"
        Me.GBAnimation.Visible = False
        '
        'Label87
        '
        Me.Label87.AutoSize = True
        Me.Label87.Location = New System.Drawing.Point(147, 202)
        Me.Label87.Name = "Label87"
        Me.Label87.Size = New System.Drawing.Size(67, 13)
        Me.Label87.TabIndex = 65
        Me.Label87.Text = "Verzögerung"
        '
        'Anim_TBDelay
        '
        Me.Anim_TBDelay.Location = New System.Drawing.Point(224, 199)
        Me.Anim_TBDelay.Name = "Anim_TBDelay"
        Me.Anim_TBDelay.Size = New System.Drawing.Size(71, 20)
        Me.Anim_TBDelay.TabIndex = 64
        Me.Anim_TBDelay.Text = "0"
        '
        'Anim_TBMaxSpeed
        '
        Me.Anim_TBMaxSpeed.Location = New System.Drawing.Point(69, 199)
        Me.Anim_TBMaxSpeed.Name = "Anim_TBMaxSpeed"
        Me.Anim_TBMaxSpeed.Size = New System.Drawing.Size(72, 20)
        Me.Anim_TBMaxSpeed.TabIndex = 63
        Me.Anim_TBMaxSpeed.Text = "0"
        '
        'Label86
        '
        Me.Label86.AutoSize = True
        Me.Label86.Location = New System.Drawing.Point(4, 202)
        Me.Label86.Name = "Label86"
        Me.Label86.Size = New System.Drawing.Size(66, 13)
        Me.Label86.TabIndex = 62
        Me.Label86.Text = "Max Geshw."
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Anim_RBPoint)
        Me.Panel1.Controls.Add(Me.Anim_RBMesh)
        Me.Panel1.Location = New System.Drawing.Point(70, 121)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(176, 24)
        Me.Panel1.TabIndex = 61
        '
        'Anim_RBPoint
        '
        Me.Anim_RBPoint.AutoSize = True
        Me.Anim_RBPoint.Location = New System.Drawing.Point(82, 3)
        Me.Anim_RBPoint.Name = "Anim_RBPoint"
        Me.Anim_RBPoint.Size = New System.Drawing.Size(49, 17)
        Me.Anim_RBPoint.TabIndex = 41
        Me.Anim_RBPoint.TabStop = True
        Me.Anim_RBPoint.Text = "Point"
        Me.Anim_RBPoint.UseVisualStyleBackColor = True
        '
        'Anim_RBMesh
        '
        Me.Anim_RBMesh.AutoSize = True
        Me.Anim_RBMesh.Location = New System.Drawing.Point(3, 3)
        Me.Anim_RBMesh.Name = "Anim_RBMesh"
        Me.Anim_RBMesh.Size = New System.Drawing.Size(51, 17)
        Me.Anim_RBMesh.TabIndex = 40
        Me.Anim_RBMesh.TabStop = True
        Me.Anim_RBMesh.Text = "Mesh"
        Me.Anim_RBMesh.UseVisualStyleBackColor = True
        '
        'Anim_PRBArt
        '
        Me.Anim_PRBArt.Controls.Add(Me.Anim_RBVerschieben)
        Me.Anim_PRBArt.Controls.Add(Me.Anim_RBDrehen)
        Me.Anim_PRBArt.Location = New System.Drawing.Point(70, 47)
        Me.Anim_PRBArt.Name = "Anim_PRBArt"
        Me.Anim_PRBArt.Size = New System.Drawing.Size(231, 23)
        Me.Anim_PRBArt.TabIndex = 60
        '
        'Anim_RBVerschieben
        '
        Me.Anim_RBVerschieben.AutoSize = True
        Me.Anim_RBVerschieben.Location = New System.Drawing.Point(76, 2)
        Me.Anim_RBVerschieben.Name = "Anim_RBVerschieben"
        Me.Anim_RBVerschieben.Size = New System.Drawing.Size(84, 17)
        Me.Anim_RBVerschieben.TabIndex = 31
        Me.Anim_RBVerschieben.TabStop = True
        Me.Anim_RBVerschieben.Text = "Verschieben"
        Me.Anim_RBVerschieben.UseVisualStyleBackColor = True
        '
        'Anim_RBDrehen
        '
        Me.Anim_RBDrehen.AutoSize = True
        Me.Anim_RBDrehen.Location = New System.Drawing.Point(3, 2)
        Me.Anim_RBDrehen.Name = "Anim_RBDrehen"
        Me.Anim_RBDrehen.Size = New System.Drawing.Size(60, 17)
        Me.Anim_RBDrehen.TabIndex = 30
        Me.Anim_RBDrehen.TabStop = True
        Me.Anim_RBDrehen.Text = "Drehen"
        Me.Anim_RBDrehen.UseVisualStyleBackColor = True
        '
        'Label85
        '
        Me.Label85.AutoSize = True
        Me.Label85.Location = New System.Drawing.Point(4, 178)
        Me.Label85.Name = "Label85"
        Me.Label85.Size = New System.Drawing.Size(50, 13)
        Me.Label85.TabIndex = 58
        Me.Label85.Text = "Richtung"
        '
        'Label78
        '
        Me.Label78.AutoSize = True
        Me.Label78.Location = New System.Drawing.Point(4, 126)
        Me.Label78.Name = "Label78"
        Me.Label78.Size = New System.Drawing.Size(34, 13)
        Me.Label78.TabIndex = 45
        Me.Label78.Text = "Origin"
        '
        'Label77
        '
        Me.Label77.AutoSize = True
        Me.Label77.Location = New System.Drawing.Point(4, 51)
        Me.Label77.Name = "Label77"
        Me.Label77.Size = New System.Drawing.Size(20, 13)
        Me.Label77.TabIndex = 44
        Me.Label77.Text = "Art"
        '
        'Label76
        '
        Me.Label76.AutoSize = True
        Me.Label76.Location = New System.Drawing.Point(3, 27)
        Me.Label76.Name = "Label76"
        Me.Label76.Size = New System.Drawing.Size(46, 13)
        Me.Label76.TabIndex = 43
        Me.Label76.Text = "Nummer"
        '
        'Label75
        '
        Me.Label75.AutoSize = True
        Me.Label75.Location = New System.Drawing.Point(4, 151)
        Me.Label75.Name = "Label75"
        Me.Label75.Size = New System.Drawing.Size(57, 13)
        Me.Label75.TabIndex = 42
        Me.Label75.Text = "Drehpunkt"
        '
        'Anim_TBAnimGrp
        '
        Me.Anim_TBAnimGrp.BackColor = System.Drawing.SystemColors.Menu
        Me.Anim_TBAnimGrp.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Anim_TBAnimGrp.Location = New System.Drawing.Point(69, 226)
        Me.Anim_TBAnimGrp.Name = "Anim_TBAnimGrp"
        Me.Anim_TBAnimGrp.ReadOnly = True
        Me.Anim_TBAnimGrp.Size = New System.Drawing.Size(226, 20)
        Me.Anim_TBAnimGrp.TabIndex = 38
        '
        'Anim_MinMax
        '
        Me.Anim_MinMax.Location = New System.Drawing.Point(302, 0)
        Me.Anim_MinMax.Name = "Anim_MinMax"
        Me.Anim_MinMax.Size = New System.Drawing.Size(26, 19)
        Me.Anim_MinMax.TabIndex = 37
        Me.Anim_MinMax.Text = "-"
        Me.Anim_MinMax.UseVisualStyleBackColor = True
        '
        'Anim_TBValue
        '
        Me.Anim_TBValue.Location = New System.Drawing.Point(70, 98)
        Me.Anim_TBValue.Name = "Anim_TBValue"
        Me.Anim_TBValue.Size = New System.Drawing.Size(226, 20)
        Me.Anim_TBValue.TabIndex = 35
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(4, 101)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(30, 13)
        Me.Label29.TabIndex = 34
        Me.Label29.Text = "Wert"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(4, 76)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(45, 13)
        Me.Label28.TabIndex = 33
        Me.Label28.Text = "Variable"
        '
        'Anim_BTLöschen
        '
        Me.Anim_BTLöschen.Location = New System.Drawing.Point(223, 22)
        Me.Anim_BTLöschen.Name = "Anim_BTLöschen"
        Me.Anim_BTLöschen.Size = New System.Drawing.Size(72, 23)
        Me.Anim_BTLöschen.TabIndex = 29
        Me.Anim_BTLöschen.Text = "Löschen"
        Me.Anim_BTLöschen.UseVisualStyleBackColor = True
        '
        'Anim_BTNeu
        '
        Me.Anim_BTNeu.Location = New System.Drawing.Point(146, 22)
        Me.Anim_BTNeu.Name = "Anim_BTNeu"
        Me.Anim_BTNeu.Size = New System.Drawing.Size(72, 23)
        Me.Anim_BTNeu.TabIndex = 28
        Me.Anim_BTNeu.Text = "Neu"
        Me.Anim_BTNeu.UseVisualStyleBackColor = True
        '
        'Anim_DDList
        '
        Me.Anim_DDList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Anim_DDList.FormattingEnabled = True
        Me.Anim_DDList.Location = New System.Drawing.Point(69, 23)
        Me.Anim_DDList.Name = "Anim_DDList"
        Me.Anim_DDList.Size = New System.Drawing.Size(72, 21)
        Me.Anim_DDList.TabIndex = 27
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(3, 230)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(47, 13)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "AnimGrp"
        '
        'LBEingenschaften
        '
        Me.LBEingenschaften.AutoSize = True
        Me.LBEingenschaften.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBEingenschaften.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.LBEingenschaften.Location = New System.Drawing.Point(131, 6)
        Me.LBEingenschaften.Name = "LBEingenschaften"
        Me.LBEingenschaften.Size = New System.Drawing.Size(88, 13)
        Me.LBEingenschaften.TabIndex = 0
        Me.LBEingenschaften.Text = "Eigenschaften"
        '
        'PanelTexture
        '
        Me.PanelTexture.BackColor = System.Drawing.SystemColors.HotTrack
        Me.PanelTexture.Controls.Add(Me.BTTexOkay)
        Me.PanelTexture.Controls.Add(Me.BTTexBearb)
        Me.PanelTexture.Controls.Add(Me.BTTexLoad)
        Me.PanelTexture.Controls.Add(Me.BTTexNew)
        Me.PanelTexture.Controls.Add(Me.DDAlleTexturen)
        Me.PanelTexture.Controls.Add(Me.PBTexture)
        Me.PanelTexture.Controls.Add(Me.PanelTextureFill)
        Me.PanelTexture.Controls.Add(Me.LBPanelTexture)
        Me.PanelTexture.Controls.Add(Me.BTPanelTextureClose)
        Me.PanelTexture.Controls.Add(Me.MSTexturen)
        Me.PanelTexture.Location = New System.Drawing.Point(294, 3)
        Me.PanelTexture.Name = "PanelTexture"
        Me.PanelTexture.Size = New System.Drawing.Size(392, 338)
        Me.PanelTexture.TabIndex = 1
        Me.PanelTexture.Visible = False
        '
        'BTTexOkay
        '
        Me.BTTexOkay.Location = New System.Drawing.Point(314, 314)
        Me.BTTexOkay.Name = "BTTexOkay"
        Me.BTTexOkay.Size = New System.Drawing.Size(75, 22)
        Me.BTTexOkay.TabIndex = 10
        Me.BTTexOkay.Text = "Okay"
        Me.BTTexOkay.UseVisualStyleBackColor = True
        Me.BTTexOkay.Visible = False
        '
        'BTTexBearb
        '
        Me.BTTexBearb.Location = New System.Drawing.Point(157, 314)
        Me.BTTexBearb.Name = "BTTexBearb"
        Me.BTTexBearb.Size = New System.Drawing.Size(75, 22)
        Me.BTTexBearb.TabIndex = 9
        Me.BTTexBearb.Text = "Bearbeiten"
        Me.BTTexBearb.UseVisualStyleBackColor = True
        '
        'BTTexLoad
        '
        Me.BTTexLoad.Location = New System.Drawing.Point(81, 314)
        Me.BTTexLoad.Name = "BTTexLoad"
        Me.BTTexLoad.Size = New System.Drawing.Size(75, 22)
        Me.BTTexLoad.TabIndex = 8
        Me.BTTexLoad.Text = "Neu laden"
        Me.BTTexLoad.UseVisualStyleBackColor = True
        '
        'BTTexNew
        '
        Me.BTTexNew.Enabled = False
        Me.BTTexNew.Location = New System.Drawing.Point(5, 314)
        Me.BTTexNew.Name = "BTTexNew"
        Me.BTTexNew.Size = New System.Drawing.Size(75, 22)
        Me.BTTexNew.TabIndex = 7
        Me.BTTexNew.Text = "Neu"
        Me.BTTexNew.UseVisualStyleBackColor = True
        '
        'DDAlleTexturen
        '
        Me.DDAlleTexturen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.DDAlleTexturen.FormattingEnabled = True
        Me.DDAlleTexturen.Location = New System.Drawing.Point(5, 292)
        Me.DDAlleTexturen.Name = "DDAlleTexturen"
        Me.DDAlleTexturen.Size = New System.Drawing.Size(384, 21)
        Me.DDAlleTexturen.TabIndex = 6
        '
        'PBTexture
        '
        Me.PBTexture.BackColor = System.Drawing.Color.Transparent
        Me.PBTexture.BackgroundImage = Global.O3D_Test.My.Resources.Resources.Image_Background
        Me.PBTexture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PBTexture.Location = New System.Drawing.Point(5, 22)
        Me.PBTexture.Name = "PBTexture"
        Me.PBTexture.Size = New System.Drawing.Size(384, 270)
        Me.PBTexture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PBTexture.TabIndex = 5
        Me.PBTexture.TabStop = False
        '
        'PanelTextureFill
        '
        Me.PanelTextureFill.FlatAppearance.BorderSize = 0
        Me.PanelTextureFill.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.MenuHighlight
        Me.PanelTextureFill.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.PanelTextureFill.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PanelTextureFill.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.PanelTextureFill.Location = New System.Drawing.Point(351, 3)
        Me.PanelTextureFill.Name = "PanelTextureFill"
        Me.PanelTextureFill.Size = New System.Drawing.Size(19, 19)
        Me.PanelTextureFill.TabIndex = 4
        Me.PanelTextureFill.Text = "□"
        Me.PanelTextureFill.UseVisualStyleBackColor = True
        '
        'LBPanelTexture
        '
        Me.LBPanelTexture.AutoSize = True
        Me.LBPanelTexture.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBPanelTexture.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.LBPanelTexture.Location = New System.Drawing.Point(164, 6)
        Me.LBPanelTexture.Name = "LBPanelTexture"
        Me.LBPanelTexture.Size = New System.Drawing.Size(57, 13)
        Me.LBPanelTexture.TabIndex = 2
        Me.LBPanelTexture.Text = "Texturen"
        '
        'BTPanelTextureClose
        '
        Me.BTPanelTextureClose.BackColor = System.Drawing.Color.Transparent
        Me.BTPanelTextureClose.FlatAppearance.BorderSize = 0
        Me.BTPanelTextureClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red
        Me.BTPanelTextureClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTPanelTextureClose.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.BTPanelTextureClose.Location = New System.Drawing.Point(371, 3)
        Me.BTPanelTextureClose.Name = "BTPanelTextureClose"
        Me.BTPanelTextureClose.Padding = New System.Windows.Forms.Padding(2, 0, 0, 0)
        Me.BTPanelTextureClose.Size = New System.Drawing.Size(19, 19)
        Me.BTPanelTextureClose.TabIndex = 2
        Me.BTPanelTextureClose.Text = "✕"
        Me.BTPanelTextureClose.UseVisualStyleBackColor = False
        '
        'MSTexturen
        '
        Me.MSTexturen.BackColor = System.Drawing.Color.Transparent
        Me.MSTexturen.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AnsichtToolStripMenuItem1})
        Me.MSTexturen.Location = New System.Drawing.Point(0, 0)
        Me.MSTexturen.Name = "MSTexturen"
        Me.MSTexturen.Size = New System.Drawing.Size(392, 24)
        Me.MSTexturen.TabIndex = 11
        Me.MSTexturen.Text = "MenuStrip1"
        '
        'AnsichtToolStripMenuItem1
        '
        Me.AnsichtToolStripMenuItem1.BackColor = System.Drawing.SystemColors.Control
        Me.AnsichtToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FrühlingToolStripMenuItem, Me.SommernormalToolStripMenuItem, Me.HerbstToolStripMenuItem, Me.WinterToolStripMenuItem})
        Me.AnsichtToolStripMenuItem1.Name = "AnsichtToolStripMenuItem1"
        Me.AnsichtToolStripMenuItem1.Size = New System.Drawing.Size(59, 20)
        Me.AnsichtToolStripMenuItem1.Text = "Ansicht"
        '
        'FrühlingToolStripMenuItem
        '
        Me.FrühlingToolStripMenuItem.Enabled = False
        Me.FrühlingToolStripMenuItem.Name = "FrühlingToolStripMenuItem"
        Me.FrühlingToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.FrühlingToolStripMenuItem.Text = "Frühling"
        '
        'SommernormalToolStripMenuItem
        '
        Me.SommernormalToolStripMenuItem.Checked = True
        Me.SommernormalToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.SommernormalToolStripMenuItem.Enabled = False
        Me.SommernormalToolStripMenuItem.Name = "SommernormalToolStripMenuItem"
        Me.SommernormalToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.SommernormalToolStripMenuItem.Text = "Sommer (normal)"
        '
        'HerbstToolStripMenuItem
        '
        Me.HerbstToolStripMenuItem.Enabled = False
        Me.HerbstToolStripMenuItem.Name = "HerbstToolStripMenuItem"
        Me.HerbstToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.HerbstToolStripMenuItem.Text = "Herbst"
        '
        'WinterToolStripMenuItem
        '
        Me.WinterToolStripMenuItem.Enabled = False
        Me.WinterToolStripMenuItem.Name = "WinterToolStripMenuItem"
        Me.WinterToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.WinterToolStripMenuItem.Text = "Winter"
        '
        'PanelObjekte
        '
        Me.PanelObjekte.BackColor = System.Drawing.SystemColors.HotTrack
        Me.PanelObjekte.Controls.Add(Me.BTObjekteResize)
        Me.PanelObjekte.Controls.Add(Me.BTPanelObjekteClose)
        Me.PanelObjekte.Controls.Add(Me.TCObjekte)
        Me.PanelObjekte.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PanelObjekte.Location = New System.Drawing.Point(12, 3)
        Me.PanelObjekte.Name = "PanelObjekte"
        Me.PanelObjekte.Size = New System.Drawing.Size(277, 337)
        Me.PanelObjekte.TabIndex = 0
        Me.PanelObjekte.Visible = False
        '
        'BTObjekteResize
        '
        Me.BTObjekteResize.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.BTObjekteResize.Cursor = System.Windows.Forms.Cursors.SizeNWSE
        Me.BTObjekteResize.FlatAppearance.BorderSize = 0
        Me.BTObjekteResize.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTObjekteResize.Location = New System.Drawing.Point(14, 6)
        Me.BTObjekteResize.Name = "BTObjekteResize"
        Me.BTObjekteResize.Size = New System.Drawing.Size(5, 5)
        Me.BTObjekteResize.TabIndex = 2
        Me.BTObjekteResize.UseVisualStyleBackColor = False
        '
        'BTPanelObjekteClose
        '
        Me.BTPanelObjekteClose.BackColor = System.Drawing.Color.Transparent
        Me.BTPanelObjekteClose.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.BTPanelObjekteClose.FlatAppearance.BorderSize = 0
        Me.BTPanelObjekteClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red
        Me.BTPanelObjekteClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTPanelObjekteClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTPanelObjekteClose.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.BTPanelObjekteClose.Location = New System.Drawing.Point(254, 3)
        Me.BTPanelObjekteClose.Name = "BTPanelObjekteClose"
        Me.BTPanelObjekteClose.Padding = New System.Windows.Forms.Padding(2, 0, 0, 0)
        Me.BTPanelObjekteClose.Size = New System.Drawing.Size(19, 19)
        Me.BTPanelObjekteClose.TabIndex = 1
        Me.BTPanelObjekteClose.Text = "✕"
        Me.BTPanelObjekteClose.UseVisualStyleBackColor = False
        '
        'TCObjekte
        '
        Me.TCObjekte.Controls.Add(Me.TCObjektePMeshes)
        Me.TCObjekte.Controls.Add(Me.TCObjektePHelfer)
        Me.TCObjekte.Controls.Add(Me.TCObjektePLichter)
        Me.TCObjekte.Controls.Add(Me.TCObjektePPfade)
        Me.TCObjekte.Location = New System.Drawing.Point(3, 6)
        Me.TCObjekte.Name = "TCObjekte"
        Me.TCObjekte.SelectedIndex = 0
        Me.TCObjekte.Size = New System.Drawing.Size(271, 328)
        Me.TCObjekte.TabIndex = 3
        '
        'TCObjektePMeshes
        '
        Me.TCObjektePMeshes.BackColor = System.Drawing.SystemColors.Window
        Me.TCObjektePMeshes.Controls.Add(Me.LBMeshes)
        Me.TCObjektePMeshes.Location = New System.Drawing.Point(4, 22)
        Me.TCObjektePMeshes.Name = "TCObjektePMeshes"
        Me.TCObjektePMeshes.Padding = New System.Windows.Forms.Padding(3)
        Me.TCObjektePMeshes.Size = New System.Drawing.Size(263, 302)
        Me.TCObjektePMeshes.TabIndex = 0
        Me.TCObjektePMeshes.Text = "Meshes"
        '
        'LBMeshes
        '
        Me.LBMeshes.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.LBMeshes.ContextMenuStrip = Me.CMSMeshes
        Me.LBMeshes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LBMeshes.FormattingEnabled = True
        Me.LBMeshes.Location = New System.Drawing.Point(3, 3)
        Me.LBMeshes.Name = "LBMeshes"
        Me.LBMeshes.Size = New System.Drawing.Size(257, 296)
        Me.LBMeshes.TabIndex = 3
        '
        'CMSMeshes
        '
        Me.CMSMeshes.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.CMSMeshes.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CMSObjekteNeuladen, Me.CMSObjekteBearbeiten, Me.ToolStripMenuItem3, Me.CMSObjekteImport, Me.ErsetzenToolStripMenuItem, Me.CMSObjekteExport, Me.ToolStripMenuItem4, Me.CMSObjekteEntfernen, Me.DateiLöschenToolStripMenuItem, Me.ToolStripMenuItem16, Me.EigenschaftenToolStripMenuItem1})
        Me.CMSMeshes.Name = "CMSObjekte"
        Me.CMSMeshes.Size = New System.Drawing.Size(156, 198)
        '
        'CMSObjekteNeuladen
        '
        Me.CMSObjekteNeuladen.Name = "CMSObjekteNeuladen"
        Me.CMSObjekteNeuladen.Size = New System.Drawing.Size(155, 22)
        Me.CMSObjekteNeuladen.Text = "Neu laden"
        '
        'CMSObjekteBearbeiten
        '
        Me.CMSObjekteBearbeiten.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ZUpToolStripMenuItem, Me.LeftRightHandedToolStripMenuItem, Me.ToolStripMenuItem11, Me.UmbenennenToolStripMenuItem})
        Me.CMSObjekteBearbeiten.Name = "CMSObjekteBearbeiten"
        Me.CMSObjekteBearbeiten.Size = New System.Drawing.Size(155, 22)
        Me.CMSObjekteBearbeiten.Text = "Bearbeiten"
        '
        'ZUpToolStripMenuItem
        '
        Me.ZUpToolStripMenuItem.Name = "ZUpToolStripMenuItem"
        Me.ZUpToolStripMenuItem.Size = New System.Drawing.Size(174, 22)
        Me.ZUpToolStripMenuItem.Text = "Z-Up"
        '
        'LeftRightHandedToolStripMenuItem
        '
        Me.LeftRightHandedToolStripMenuItem.Name = "LeftRightHandedToolStripMenuItem"
        Me.LeftRightHandedToolStripMenuItem.Size = New System.Drawing.Size(174, 22)
        Me.LeftRightHandedToolStripMenuItem.Text = "Left/Right-Handed"
        '
        'ToolStripMenuItem11
        '
        Me.ToolStripMenuItem11.Name = "ToolStripMenuItem11"
        Me.ToolStripMenuItem11.Size = New System.Drawing.Size(171, 6)
        '
        'UmbenennenToolStripMenuItem
        '
        Me.UmbenennenToolStripMenuItem.Name = "UmbenennenToolStripMenuItem"
        Me.UmbenennenToolStripMenuItem.Size = New System.Drawing.Size(174, 22)
        Me.UmbenennenToolStripMenuItem.Text = "Umbenennen"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(152, 6)
        '
        'CMSObjekteImport
        '
        Me.CMSObjekteImport.Name = "CMSObjekteImport"
        Me.CMSObjekteImport.Size = New System.Drawing.Size(155, 22)
        Me.CMSObjekteImport.Text = "Importieren"
        '
        'ErsetzenToolStripMenuItem
        '
        Me.ErsetzenToolStripMenuItem.Name = "ErsetzenToolStripMenuItem"
        Me.ErsetzenToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.ErsetzenToolStripMenuItem.Text = "Ersetzen"
        '
        'CMSObjekteExport
        '
        Me.CMSObjekteExport.Name = "CMSObjekteExport"
        Me.CMSObjekteExport.Size = New System.Drawing.Size(155, 22)
        Me.CMSObjekteExport.Text = "Exportieren"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(152, 6)
        '
        'CMSObjekteEntfernen
        '
        Me.CMSObjekteEntfernen.Name = "CMSObjekteEntfernen"
        Me.CMSObjekteEntfernen.Size = New System.Drawing.Size(155, 22)
        Me.CMSObjekteEntfernen.Text = "Datei entfernen"
        '
        'DateiLöschenToolStripMenuItem
        '
        Me.DateiLöschenToolStripMenuItem.Name = "DateiLöschenToolStripMenuItem"
        Me.DateiLöschenToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.DateiLöschenToolStripMenuItem.Text = "Datei löschen"
        '
        'ToolStripMenuItem16
        '
        Me.ToolStripMenuItem16.Name = "ToolStripMenuItem16"
        Me.ToolStripMenuItem16.Size = New System.Drawing.Size(152, 6)
        '
        'EigenschaftenToolStripMenuItem1
        '
        Me.EigenschaftenToolStripMenuItem1.Name = "EigenschaftenToolStripMenuItem1"
        Me.EigenschaftenToolStripMenuItem1.Size = New System.Drawing.Size(155, 22)
        Me.EigenschaftenToolStripMenuItem1.Text = "Eigenschaften"
        '
        'TCObjektePHelfer
        '
        Me.TCObjektePHelfer.BackColor = System.Drawing.SystemColors.Window
        Me.TCObjektePHelfer.Controls.Add(Me.TVHelper)
        Me.TCObjektePHelfer.Location = New System.Drawing.Point(4, 22)
        Me.TCObjektePHelfer.Name = "TCObjektePHelfer"
        Me.TCObjektePHelfer.Padding = New System.Windows.Forms.Padding(3)
        Me.TCObjektePHelfer.Size = New System.Drawing.Size(263, 302)
        Me.TCObjektePHelfer.TabIndex = 1
        Me.TCObjektePHelfer.Text = "Helfer"
        '
        'TVHelper
        '
        Me.TVHelper.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TVHelper.ContextMenuStrip = Me.CMSHelfer
        Me.TVHelper.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TVHelper.Location = New System.Drawing.Point(3, 3)
        Me.TVHelper.Name = "TVHelper"
        TreeNode1.Name = "KAchsen"
        TreeNode1.Text = "Achsen"
        TreeNode1.ToolTipText = "Achsen für das Fahrverhalten des Fahrzeuges"
        TreeNode2.Name = "KBoundingbox"
        TreeNode2.Text = "Boundingbox"
        TreeNode2.ToolTipText = "Kollisionsbox um das Fahrzeug / Objekt"
        TreeNode3.Name = "KFahrerkameras"
        TreeNode3.Text = "Fahrerkameras"
        TreeNode3.ToolTipText = "Perspektiven in der F1 Ansicht"
        TreeNode4.Name = "KFahrgastkameras"
        TreeNode4.Text = "Fahrgastkameras"
        TreeNode4.ToolTipText = "Perspektiven in der F2 Ansicht"
        TreeNode5.Name = "KKameras"
        TreeNode5.Text = "Kameras"
        TreeNode5.ToolTipText = "Ansichten / Kameras"
        TreeNode6.Name = "KKupplung"
        TreeNode6.Text = "Kupplungspunkte"
        TreeNode6.ToolTipText = "Verbindungspunkte zu anderen Fahrzeug(teil)en"
        TreeNode7.Name = "KInnenlichter"
        TreeNode7.Text = "Innenlichter"
        TreeNode7.ToolTipText = "Innenbeleuchtung"
        TreeNode8.Name = "KRauch"
        TreeNode8.Text = "Rauch"
        TreeNode8.ToolTipText = "Partikelsystem"
        TreeNode9.Name = "KSpiegel"
        TreeNode9.Text = "Spiegel"
        TreeNode9.ToolTipText = "Reflexions Kameras"
        TreeNode10.Name = "KSitzSteh"
        TreeNode10.Text = "Sitz-/ Stehplätze"
        TreeNode10.ToolTipText = "Sitzplätze für Fahrgäste"
        TreeNode11.Name = "KTEntwerter"
        TreeNode11.Text = "Entwerter"
        TreeNode11.ToolTipText = "Ticket stempler"
        TreeNode12.Name = "KTicketblöcke"
        TreeNode12.Text = "Ticketblöcke"
        TreeNode12.ToolTipText = "Abreistickets"
        TreeNode13.Name = "KTGeldablage"
        TreeNode13.Text = "Geldablage"
        TreeNode13.ToolTipText = "Dort legen Fahrgäste ihr Geld ab"
        TreeNode14.Name = "KTGeldRückgabe"
        TreeNode14.Text = "Geldrückgabe"
        TreeNode14.ToolTipText = "Hier bekommen Fahrgäste ihr Wechselgeld"
        TreeNode15.Name = "KTTickets"
        TreeNode15.Text = "Tickets"
        TreeNode15.ToolTipText = "Tickets im Bus"
        TreeNode16.Name = "KAttach"
        TreeNode16.Text = "Attachpoints"
        TreeNode16.ToolTipText = "Befestigungspunkte"
        TreeNode17.Name = "KSplinehelper"
        TreeNode17.Text = "Splinehelper"
        TreeNode17.ToolTipText = "Splines zum Anpassen von Pfaden"
        TreeNode18.Name = "KSpots"
        TreeNode18.Text = "Spots"
        TreeNode18.ToolTipText = "Lichtschein auf der Karte"
        Me.TVHelper.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode1, TreeNode2, TreeNode5, TreeNode6, TreeNode7, TreeNode8, TreeNode9, TreeNode10, TreeNode15, TreeNode16, TreeNode17, TreeNode18})
        Me.TVHelper.Size = New System.Drawing.Size(257, 296)
        Me.TVHelper.TabIndex = 1
        '
        'CMSHelfer
        '
        Me.CMSHelfer.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NeuToolStripMenuItem1, Me.DuplizierenToolStripMenuItem, Me.EntfernenToolStripMenuItem})
        Me.CMSHelfer.Name = "CMSHelfer"
        Me.CMSHelfer.Size = New System.Drawing.Size(134, 70)
        '
        'NeuToolStripMenuItem1
        '
        Me.NeuToolStripMenuItem1.Name = "NeuToolStripMenuItem1"
        Me.NeuToolStripMenuItem1.Size = New System.Drawing.Size(133, 22)
        Me.NeuToolStripMenuItem1.Text = "Neu"
        '
        'DuplizierenToolStripMenuItem
        '
        Me.DuplizierenToolStripMenuItem.Enabled = False
        Me.DuplizierenToolStripMenuItem.Name = "DuplizierenToolStripMenuItem"
        Me.DuplizierenToolStripMenuItem.Size = New System.Drawing.Size(133, 22)
        Me.DuplizierenToolStripMenuItem.Text = "Duplizieren"
        '
        'EntfernenToolStripMenuItem
        '
        Me.EntfernenToolStripMenuItem.Name = "EntfernenToolStripMenuItem"
        Me.EntfernenToolStripMenuItem.Size = New System.Drawing.Size(133, 22)
        Me.EntfernenToolStripMenuItem.Text = "Entfernen"
        '
        'TCObjektePLichter
        '
        Me.TCObjektePLichter.BackColor = System.Drawing.SystemColors.Window
        Me.TCObjektePLichter.Controls.Add(Me.LBLichter)
        Me.TCObjektePLichter.Location = New System.Drawing.Point(4, 22)
        Me.TCObjektePLichter.Name = "TCObjektePLichter"
        Me.TCObjektePLichter.Padding = New System.Windows.Forms.Padding(3)
        Me.TCObjektePLichter.Size = New System.Drawing.Size(263, 302)
        Me.TCObjektePLichter.TabIndex = 2
        Me.TCObjektePLichter.Text = "Lichter"
        '
        'LBLichter
        '
        Me.LBLichter.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.LBLichter.ContextMenuStrip = Me.CMSLichter
        Me.LBLichter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LBLichter.FormattingEnabled = True
        Me.LBLichter.Location = New System.Drawing.Point(3, 3)
        Me.LBLichter.Name = "LBLichter"
        Me.LBLichter.Size = New System.Drawing.Size(257, 296)
        Me.LBLichter.TabIndex = 0
        '
        'CMSLichter
        '
        Me.CMSLichter.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NeuToolStripMenuItem2, Me.DuplizierenToolStripMenuItem1, Me.EntfernenToolStripMenuItem1, Me.SortierenNachToolStripMenuItem})
        Me.CMSLichter.Name = "CMSLichter"
        Me.CMSLichter.Size = New System.Drawing.Size(160, 92)
        '
        'NeuToolStripMenuItem2
        '
        Me.NeuToolStripMenuItem2.Name = "NeuToolStripMenuItem2"
        Me.NeuToolStripMenuItem2.Size = New System.Drawing.Size(159, 22)
        Me.NeuToolStripMenuItem2.Text = "Neu"
        '
        'DuplizierenToolStripMenuItem1
        '
        Me.DuplizierenToolStripMenuItem1.Enabled = False
        Me.DuplizierenToolStripMenuItem1.Name = "DuplizierenToolStripMenuItem1"
        Me.DuplizierenToolStripMenuItem1.Size = New System.Drawing.Size(159, 22)
        Me.DuplizierenToolStripMenuItem1.Text = "Duplizieren"
        '
        'EntfernenToolStripMenuItem1
        '
        Me.EntfernenToolStripMenuItem1.Enabled = False
        Me.EntfernenToolStripMenuItem1.Name = "EntfernenToolStripMenuItem1"
        Me.EntfernenToolStripMenuItem1.Size = New System.Drawing.Size(159, 22)
        Me.EntfernenToolStripMenuItem1.Text = "Entfernen"
        '
        'SortierenNachToolStripMenuItem
        '
        Me.SortierenNachToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PositionToolStripMenuItem, Me.OriginalToolStripMenuItem, Me.VariablenToolStripMenuItem})
        Me.SortierenNachToolStripMenuItem.Name = "SortierenNachToolStripMenuItem"
        Me.SortierenNachToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.SortierenNachToolStripMenuItem.Text = "Sortieren nach..."
        '
        'PositionToolStripMenuItem
        '
        Me.PositionToolStripMenuItem.Name = "PositionToolStripMenuItem"
        Me.PositionToolStripMenuItem.Size = New System.Drawing.Size(122, 22)
        Me.PositionToolStripMenuItem.Text = "Position"
        '
        'OriginalToolStripMenuItem
        '
        Me.OriginalToolStripMenuItem.Checked = True
        Me.OriginalToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.OriginalToolStripMenuItem.Name = "OriginalToolStripMenuItem"
        Me.OriginalToolStripMenuItem.Size = New System.Drawing.Size(122, 22)
        Me.OriginalToolStripMenuItem.Text = "Original"
        '
        'VariablenToolStripMenuItem
        '
        Me.VariablenToolStripMenuItem.Name = "VariablenToolStripMenuItem"
        Me.VariablenToolStripMenuItem.Size = New System.Drawing.Size(122, 22)
        Me.VariablenToolStripMenuItem.Text = "Variablen"
        '
        'TCObjektePPfade
        '
        Me.TCObjektePPfade.Controls.Add(Me.LBPfade)
        Me.TCObjektePPfade.Location = New System.Drawing.Point(4, 22)
        Me.TCObjektePPfade.Name = "TCObjektePPfade"
        Me.TCObjektePPfade.Padding = New System.Windows.Forms.Padding(3)
        Me.TCObjektePPfade.Size = New System.Drawing.Size(263, 302)
        Me.TCObjektePPfade.TabIndex = 3
        Me.TCObjektePPfade.Text = "Pfade"
        Me.TCObjektePPfade.UseVisualStyleBackColor = True
        '
        'LBPfade
        '
        Me.LBPfade.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.LBPfade.ContextMenuStrip = Me.CMSPfade
        Me.LBPfade.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LBPfade.FormattingEnabled = True
        Me.LBPfade.Location = New System.Drawing.Point(3, 3)
        Me.LBPfade.Name = "LBPfade"
        Me.LBPfade.Size = New System.Drawing.Size(257, 296)
        Me.LBPfade.TabIndex = 1
        '
        'CMSPfade
        '
        Me.CMSPfade.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NeuToolStripMenuItem3, Me.DuplizierenToolStripMenuItem2, Me.EntfernenToolStripMenuItem3})
        Me.CMSPfade.Name = "CMSPfade"
        Me.CMSPfade.Size = New System.Drawing.Size(134, 70)
        '
        'NeuToolStripMenuItem3
        '
        Me.NeuToolStripMenuItem3.Name = "NeuToolStripMenuItem3"
        Me.NeuToolStripMenuItem3.Size = New System.Drawing.Size(133, 22)
        Me.NeuToolStripMenuItem3.Text = "Neu"
        '
        'DuplizierenToolStripMenuItem2
        '
        Me.DuplizierenToolStripMenuItem2.Name = "DuplizierenToolStripMenuItem2"
        Me.DuplizierenToolStripMenuItem2.Size = New System.Drawing.Size(133, 22)
        Me.DuplizierenToolStripMenuItem2.Text = "Duplizieren"
        '
        'EntfernenToolStripMenuItem3
        '
        Me.EntfernenToolStripMenuItem3.Name = "EntfernenToolStripMenuItem3"
        Me.EntfernenToolStripMenuItem3.Size = New System.Drawing.Size(133, 22)
        Me.EntfernenToolStripMenuItem3.Text = "Entfernen"
        '
        'GlMain
        '
        Me.GlMain.BackColor = System.Drawing.Color.Black
        Me.GlMain.Cursor = System.Windows.Forms.Cursors.Cross
        Me.GlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GlMain.Location = New System.Drawing.Point(0, 0)
        Me.GlMain.Margin = New System.Windows.Forms.Padding(4)
        Me.GlMain.Name = "GlMain"
        Me.GlMain.Size = New System.Drawing.Size(1264, 1015)
        Me.GlMain.TabIndex = 0
        Me.GlMain.VSync = False
        '
        'TSave
        '
        Me.TSave.Interval = 1000
        '
        'TReloadTextures
        '
        Me.TReloadTextures.Interval = 2000
        '
        'GBSplinePfad
        '
        Me.GBSplinePfad.Controls.Add(Me.SplinePfad_MinMax)
        Me.GBSplinePfad.Location = New System.Drawing.Point(4, 927)
        Me.GBSplinePfad.Name = "GBSplinePfad"
        Me.GBSplinePfad.Size = New System.Drawing.Size(327, 124)
        Me.GBSplinePfad.TabIndex = 37
        Me.GBSplinePfad.TabStop = False
        Me.GBSplinePfad.Text = "Spline Pfad"
        '
        'SplinePfad_MinMax
        '
        Me.SplinePfad_MinMax.Location = New System.Drawing.Point(303, 0)
        Me.SplinePfad_MinMax.Name = "SplinePfad_MinMax"
        Me.SplinePfad_MinMax.Size = New System.Drawing.Size(26, 19)
        Me.SplinePfad_MinMax.TabIndex = 37
        Me.SplinePfad_MinMax.Text = "-"
        Me.SplinePfad_MinMax.UseVisualStyleBackColor = True
        '
        'Spot_PSRichtung
        '
        Me.Spot_PSRichtung.BackColor = System.Drawing.Color.Transparent
        Me.Spot_PSRichtung.Location = New System.Drawing.Point(70, 19)
        Me.Spot_PSRichtung.Max = 1.7976931348623157E+308R
        Me.Spot_PSRichtung.Min = -1.7976931348623157E+308R
        Me.Spot_PSRichtung.Name = "Spot_PSRichtung"
        Me.Spot_PSRichtung.Point = Point3D1
        Me.Spot_PSRichtung.Size = New System.Drawing.Size(254, 20)
        Me.Spot_PSRichtung.TabIndex = 3
        Me.Spot_PSRichtung.X = 0R
        Me.Spot_PSRichtung.Y = 0R
        Me.Spot_PSRichtung.Z = 0R
        '
        'Spot_CSFarbe
        '
        Me.Spot_CSFarbe.BackColor = System.Drawing.Color.Transparent
        Me.Spot_CSFarbe.Location = New System.Drawing.Point(69, 45)
        Me.Spot_CSFarbe.Name = "Spot_CSFarbe"
        RgbColor1.SelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Spot_CSFarbe.SelectedColor = RgbColor1
        Me.Spot_CSFarbe.Size = New System.Drawing.Size(253, 24)
        Me.Spot_CSFarbe.TabIndex = 0
        '
        'VarSelector1
        '
        Me.VarSelector1.Location = New System.Drawing.Point(224, 44)
        Me.VarSelector1.Name = "VarSelector1"
        Me.VarSelector1.Size = New System.Drawing.Size(72, 20)
        Me.VarSelector1.TabIndex = 4
        Me.VarSelector1.Variable = ""
        '
        'PointSelector2
        '
        Me.PointSelector2.BackColor = System.Drawing.Color.Transparent
        Me.PointSelector2.Location = New System.Drawing.Point(70, 19)
        Me.PointSelector2.Max = 1.7976931348623157E+308R
        Me.PointSelector2.Min = 0R
        Me.PointSelector2.Name = "PointSelector2"
        Me.PointSelector2.Point = Point3D2
        Me.PointSelector2.Size = New System.Drawing.Size(255, 20)
        Me.PointSelector2.TabIndex = 0
        Me.PointSelector2.X = 0R
        Me.PointSelector2.Y = 0R
        Me.PointSelector2.Z = 0R
        '
        'BBox_PSSize
        '
        Me.BBox_PSSize.BackColor = System.Drawing.Color.Transparent
        Me.BBox_PSSize.Location = New System.Drawing.Point(70, 19)
        Me.BBox_PSSize.Max = 1.7976931348623157E+308R
        Me.BBox_PSSize.Min = -1.7976931348623157E+308R
        Me.BBox_PSSize.Name = "BBox_PSSize"
        Me.BBox_PSSize.Point = Point3D3
        Me.BBox_PSSize.Size = New System.Drawing.Size(255, 20)
        Me.BBox_PSSize.TabIndex = 23
        Me.BBox_PSSize.X = 0R
        Me.BBox_PSSize.Y = 0R
        Me.BBox_PSSize.Z = 0R
        '
        'PSPos
        '
        Me.PSPos.BackColor = System.Drawing.Color.Transparent
        Me.PSPos.Location = New System.Drawing.Point(69, 44)
        Me.PSPos.Max = 1.7976931348623157E+308R
        Me.PSPos.Min = -1.7976931348623157E+308R
        Me.PSPos.Name = "PSPos"
        Me.PSPos.Point = Point3D4
        Me.PSPos.Size = New System.Drawing.Size(255, 20)
        Me.PSPos.TabIndex = 22
        Me.PSPos.X = 0R
        Me.PSPos.Y = 0R
        Me.PSPos.Z = 0R
        '
        'Mesh_VSKlickevent
        '
        Me.Mesh_VSKlickevent.Location = New System.Drawing.Point(69, 19)
        Me.Mesh_VSKlickevent.Name = "Mesh_VSKlickevent"
        Me.Mesh_VSKlickevent.Size = New System.Drawing.Size(226, 20)
        Me.Mesh_VSKlickevent.TabIndex = 28
        Me.Mesh_VSKlickevent.Variable = ""
        '
        'Mesh_VSSichtbarkeit
        '
        Me.Mesh_VSSichtbarkeit.Location = New System.Drawing.Point(69, 72)
        Me.Mesh_VSSichtbarkeit.Name = "Mesh_VSSichtbarkeit"
        Me.Mesh_VSSichtbarkeit.Size = New System.Drawing.Size(149, 20)
        Me.Mesh_VSSichtbarkeit.TabIndex = 27
        Me.Mesh_VSSichtbarkeit.Variable = ""
        '
        'Mesh_PSCenter
        '
        Me.Mesh_PSCenter.BackColor = System.Drawing.Color.Transparent
        Me.Mesh_PSCenter.Enabled = False
        Me.Mesh_PSCenter.Location = New System.Drawing.Point(69, 99)
        Me.Mesh_PSCenter.Max = 1.7976931348623157E+308R
        Me.Mesh_PSCenter.Min = -1.7976931348623157E+308R
        Me.Mesh_PSCenter.Name = "Mesh_PSCenter"
        Me.Mesh_PSCenter.Point = Point3D5
        Me.Mesh_PSCenter.Size = New System.Drawing.Size(255, 20)
        Me.Mesh_PSCenter.TabIndex = 26
        Me.Mesh_PSCenter.X = 0R
        Me.Mesh_PSCenter.Y = 0R
        Me.Mesh_PSCenter.Z = 0R
        '
        'Licht_VSVar
        '
        Me.Licht_VSVar.Location = New System.Drawing.Point(70, 19)
        Me.Licht_VSVar.Name = "Licht_VSVar"
        Me.Licht_VSVar.Size = New System.Drawing.Size(226, 20)
        Me.Licht_VSVar.TabIndex = 29
        Me.Licht_VSVar.Variable = ""
        '
        'Licht_PSVector
        '
        Me.Licht_PSVector.BackColor = System.Drawing.Color.Transparent
        Me.Licht_PSVector.Location = New System.Drawing.Point(70, 71)
        Me.Licht_PSVector.Max = 2.0R
        Me.Licht_PSVector.Min = 0R
        Me.Licht_PSVector.Name = "Licht_PSVector"
        Me.Licht_PSVector.Point = Point3D6
        Me.Licht_PSVector.Size = New System.Drawing.Size(255, 20)
        Me.Licht_PSVector.TabIndex = 58
        Me.Licht_PSVector.X = 0R
        Me.Licht_PSVector.Y = 0R
        Me.Licht_PSVector.Z = 0R
        '
        'Licht_PSRichtung
        '
        Me.Licht_PSRichtung.BackColor = System.Drawing.Color.Transparent
        Me.Licht_PSRichtung.Location = New System.Drawing.Point(70, 45)
        Me.Licht_PSRichtung.Max = 1.0R
        Me.Licht_PSRichtung.Min = -1.0R
        Me.Licht_PSRichtung.Name = "Licht_PSRichtung"
        Me.Licht_PSRichtung.Point = Point3D7
        Me.Licht_PSRichtung.Size = New System.Drawing.Size(255, 20)
        Me.Licht_PSRichtung.TabIndex = 57
        Me.Licht_PSRichtung.X = 0R
        Me.Licht_PSRichtung.Y = 0R
        Me.Licht_PSRichtung.Z = 0R
        '
        'Licht_CSFarbe
        '
        Me.Licht_CSFarbe.BackColor = System.Drawing.Color.Transparent
        Me.Licht_CSFarbe.Location = New System.Drawing.Point(70, 126)
        Me.Licht_CSFarbe.Name = "Licht_CSFarbe"
        RgbColor2.SelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Licht_CSFarbe.SelectedColor = RgbColor2
        Me.Licht_CSFarbe.Size = New System.Drawing.Size(257, 24)
        Me.Licht_CSFarbe.TabIndex = 22
        '
        'Anim_PSRichtung
        '
        Me.Anim_PSRichtung.BackColor = System.Drawing.Color.Transparent
        Me.Anim_PSRichtung.Enabled = False
        Me.Anim_PSRichtung.Location = New System.Drawing.Point(70, 173)
        Me.Anim_PSRichtung.Max = 360.0R
        Me.Anim_PSRichtung.Min = -360.0R
        Me.Anim_PSRichtung.Name = "Anim_PSRichtung"
        Me.Anim_PSRichtung.Point = Point3D8
        Me.Anim_PSRichtung.Size = New System.Drawing.Size(255, 20)
        Me.Anim_PSRichtung.TabIndex = 59
        Me.Anim_PSRichtung.X = 0R
        Me.Anim_PSRichtung.Y = 0R
        Me.Anim_PSRichtung.Z = 0R
        '
        'Anim_PSRotPnt
        '
        Me.Anim_PSRotPnt.BackColor = System.Drawing.Color.Transparent
        Me.Anim_PSRotPnt.Enabled = False
        Me.Anim_PSRotPnt.Location = New System.Drawing.Point(69, 147)
        Me.Anim_PSRotPnt.Max = 1.7976931348623157E+308R
        Me.Anim_PSRotPnt.Min = 0R
        Me.Anim_PSRotPnt.Name = "Anim_PSRotPnt"
        Me.Anim_PSRotPnt.Point = Point3D9
        Me.Anim_PSRotPnt.Size = New System.Drawing.Size(256, 20)
        Me.Anim_PSRotPnt.TabIndex = 39
        Me.Anim_PSRotPnt.X = 0R
        Me.Anim_PSRotPnt.Y = 0R
        Me.Anim_PSRotPnt.Z = 0R
        '
        'Anim_VSVar
        '
        Me.Anim_VSVar.Location = New System.Drawing.Point(70, 72)
        Me.Anim_VSVar.Name = "Anim_VSVar"
        Me.Anim_VSVar.Size = New System.Drawing.Size(226, 20)
        Me.Anim_VSVar.TabIndex = 32
        Me.Anim_VSVar.Variable = ""
        '
        'Frm_Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1264, 1061)
        Me.Controls.Add(Me.PanelMain)
        Me.Controls.Add(Me.SS1)
        Me.Controls.Add(Me.MS1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MS1
        Me.Name = "Frm_Main"
        Me.Text = "OMSI-Content-Tool"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.SS1.ResumeLayout(False)
        Me.SS1.PerformLayout()
        Me.MS1.ResumeLayout(False)
        Me.MS1.PerformLayout()
        Me.PanelMain.ResumeLayout(False)
        Me.PanelTimeline.ResumeLayout(False)
        Me.TCTimeline.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.PanelEigenschaften.ResumeLayout(False)
        Me.PanelEigenschaften.PerformLayout()
        Me.PanelEigenschaften1.ResumeLayout(False)
        Me.GBSpot.ResumeLayout(False)
        Me.GBSpot.PerformLayout()
        Me.GBPlatz.ResumeLayout(False)
        Me.GBPlatz.PerformLayout()
        Me.GBRauch.ResumeLayout(False)
        Me.GBRauch.PerformLayout()
        Me.GBPfade.ResumeLayout(False)
        Me.GBPfade.PerformLayout()
        CType(Me.Pfade_PBOrange, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pfade_PVerb0.ResumeLayout(False)
        Me.Pfade_PVerb0.PerformLayout()
        CType(Me.Pfade_PBLila, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GBKupplPnt.ResumeLayout(False)
        Me.GBKupplPnt.PerformLayout()
        Me.GBKamera.ResumeLayout(False)
        Me.GBKamera.PerformLayout()
        Me.GBBbox.ResumeLayout(False)
        Me.GBBbox.PerformLayout()
        Me.GBAchse.ResumeLayout(False)
        Me.GBAchse.PerformLayout()
        Me.GBSplineHelper.ResumeLayout(False)
        Me.GBSplineHelper.PerformLayout()
        Me.GBPfad.ResumeLayout(False)
        Me.GBPfad.PerformLayout()
        Me.GBSpline.ResumeLayout(False)
        Me.GBSpline.PerformLayout()
        Me.GBAllgemein.ResumeLayout(False)
        Me.GBAllgemein.PerformLayout()
        Me.GBMesh.ResumeLayout(False)
        Me.GBMesh.PerformLayout()
        CType(Me.Mesh_NUMax, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Mesh_NUMin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GBParent.ResumeLayout(False)
        Me.GBParent.PerformLayout()
        Me.GBBones.ResumeLayout(False)
        Me.GBBones.PerformLayout()
        Me.GBBel.ResumeLayout(False)
        Me.GBBel.PerformLayout()
        Me.GBLicht.ResumeLayout(False)
        Me.GBLicht.PerformLayout()
        Me.GBMat.ResumeLayout(False)
        Me.GBMat.PerformLayout()
        Me.GBAnimation.ResumeLayout(False)
        Me.GBAnimation.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Anim_PRBArt.ResumeLayout(False)
        Me.Anim_PRBArt.PerformLayout()
        Me.PanelTexture.ResumeLayout(False)
        Me.PanelTexture.PerformLayout()
        CType(Me.PBTexture, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MSTexturen.ResumeLayout(False)
        Me.MSTexturen.PerformLayout()
        Me.PanelObjekte.ResumeLayout(False)
        Me.TCObjekte.ResumeLayout(False)
        Me.TCObjektePMeshes.ResumeLayout(False)
        Me.CMSMeshes.ResumeLayout(False)
        Me.TCObjektePHelfer.ResumeLayout(False)
        Me.CMSHelfer.ResumeLayout(False)
        Me.TCObjektePLichter.ResumeLayout(False)
        Me.CMSLichter.ResumeLayout(False)
        Me.TCObjektePPfade.ResumeLayout(False)
        Me.CMSPfade.ResumeLayout(False)
        Me.GBSplinePfad.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SS1 As StatusStrip
    Friend WithEvents MS1 As MenuStrip
    Friend WithEvents DateiToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BearbeitenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ImportierenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExportiernToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HilfeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PanelMain As Panel
    Friend WithEvents NeuToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents ÖffnenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SpeichernToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SpeichernUnterToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripSeparator
    Friend WithEvents BeendenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EigenschaftenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PanelObjekte As Panel
    Friend WithEvents AnsichtToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BTPanelObjekteClose As Button
    Friend WithEvents CMSMeshes As ContextMenuStrip
    Friend WithEvents CMSObjekteNeuladen As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As ToolStripSeparator
    Friend WithEvents CMSObjekteEntfernen As ToolStripMenuItem
    Friend WithEvents CMSObjekteExport As ToolStripMenuItem
    Friend WithEvents CMSObjekteImport As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As ToolStripSeparator
    Friend WithEvents PanelTexture As Panel
    Friend WithEvents BTPanelTextureClose As Button
    Friend WithEvents LBPanelTexture As Label
    Friend WithEvents PanelTextureFill As Button
    Friend WithEvents PBTexture As PictureBox
    Friend WithEvents BTTexNew As Button
    Friend WithEvents DDAlleTexturen As ComboBox
    Friend WithEvents BTTexLoad As Button
    Friend WithEvents BTTexBearb As Button
    Friend WithEvents WireframeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As ToolStripSeparator
    Friend WithEvents GlMain As OpenTK.GLControl
    Friend WithEvents GitterToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BTObjekteResize As Button
    Friend WithEvents CMSObjekteBearbeiten As ToolStripMenuItem
    Friend WithEvents ZUpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LeftRightHandedToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem7 As ToolStripSeparator
    Friend WithEvents LetzteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem6 As ToolStripSeparator
    Friend WithEvents EinstellungenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PanelEigenschaften As Panel
    Friend WithEvents LBEingenschaften As Label
    Friend WithEvents PanelEigenschaften1 As Panel
    Friend WithEvents BTPanelEingenschaftenClose As Button
    Friend WithEvents TBName As TextBox
    Friend WithEvents Label As Label
    Friend WithEvents GBMat As GroupBox
    Friend WithEvents GBAnimation As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TextToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ScriptToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents VarlistsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StringvarlistToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ScriptsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ConstfilesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TCObjekte As TabControl
    Friend WithEvents TCObjektePMeshes As TabPage
    Friend WithEvents TCObjektePHelfer As TabPage
    Friend WithEvents Label4 As Label
    Friend WithEvents TCObjektePLichter As TabPage
    Friend WithEvents LBLichter As ListBox
    Friend WithEvents ErstellenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LichtToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AchseToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PfadToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SitzplatzToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CMSHelfer As ContextMenuStrip
    Friend WithEvents NeuToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents DuplizierenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EntfernenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TVHelper As TreeView
    Friend WithEvents CMSLichter As ContextMenuStrip
    Friend WithEvents NeuToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents DuplizierenToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents EntfernenToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents SortierenNachToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PositionToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OriginalToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents VariablenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BTEigenschafteResize As Button
    Friend WithEvents ToolStripMenuItem9 As ToolStripSeparator
    Friend WithEvents LogfileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FDÖffnen As OpenFileDialog
    Friend WithEvents ToolStripMenuItem10 As ToolStripSeparator
    Friend WithEvents VariablenTestToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PBMain As ToolStripProgressBar
    Friend WithEvents SSLBStatus As ToolStripStatusLabel
    Friend WithEvents TBTimer As ToolStripStatusLabel
    Friend WithEvents TSave As Timer
    Friend WithEvents LODObjektToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem11 As ToolStripSeparator
    Friend WithEvents UmbenennenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GBLicht As GroupBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Licht_TBTexture As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents GBMesh As GroupBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Mesh_DDViedpoint As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents GBBel As GroupBox
    Friend WithEvents Bel_BTBerechnen As Button
    Friend WithEvents Bel_CB1 As ComboBox
    Friend WithEvents Bel_CB2 As ComboBox
    Friend WithEvents Bel_CB3 As ComboBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Bel_CB0 As ComboBox
    Friend WithEvents Mat_CBTex As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Bel_BTKeine As Button
    Friend WithEvents Label12 As Label
    Friend WithEvents Mat_CBTextTex As ComboBox
    Friend WithEvents TCObjektePPfade As TabPage
    Friend WithEvents LBPfade As ListBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Licht_TBOuterCone As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents Licht_TBInnerCone As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents Licht_TBGroesse As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Licht_CBRotAusr As ComboBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Licht_CBAusr As ComboBox
    Friend WithEvents Licht_TBFaktor As TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents Licht_TBZeitkonst As TextBox
    Friend WithEvents Label24 As Label
    Friend WithEvents Licht_TBKegel As TextBox
    Friend WithEvents Label23 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents Licht_CBEffekt As ComboBox
    Friend WithEvents Licht_TBOffset As TextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents Mesh_PSCenter As PointSelector
    Friend WithEvents PSPos As PointSelector
    Friend WithEvents Licht_PSVector As PointSelector
    Friend WithEvents Licht_PSRichtung As PointSelector
    Friend WithEvents ForumToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents WebseiteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ForumToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem13 As ToolStripSeparator
    Friend WithEvents HofDateienToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Mesh_VSSichtbarkeit As VarSelector
    Friend WithEvents Mesh_VSKlickevent As VarSelector
    Friend WithEvents Licht_VSVar As VarSelector
    Friend WithEvents Parent_CBParent As ComboBox
    Friend WithEvents Label25 As Label
    Friend WithEvents GBBones As GroupBox
    Friend WithEvents Label27 As Label
    Friend WithEvents Bones_CBParent As ComboBox
    Friend WithEvents Bones_TBName As TextBox
    Friend WithEvents Label26 As Label
    Friend WithEvents ToolStripMenuItem14 As ToolStripSeparator
    Friend WithEvents GBParent As GroupBox
    Friend WithEvents DevelopmentToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToDoListToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RechnerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Anim_BTLöschen As Button
    Friend WithEvents Anim_BTNeu As Button
    Friend WithEvents Anim_DDList As ComboBox
    Friend WithEvents Anim_TBValue As TextBox
    Friend WithEvents Label29 As Label
    Friend WithEvents Label28 As Label
    Friend WithEvents Anim_VSVar As VarSelector
    Friend WithEvents Anim_RBVerschieben As RadioButton
    Friend WithEvents Anim_RBDrehen As RadioButton
    Friend WithEvents GBAllgemein As GroupBox
    Friend WithEvents Mesh_TBSichtbarkeitVal As TextBox
    Friend WithEvents TestToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GBSpline As GroupBox
    Friend WithEvents Label31 As Label
    Friend WithEvents Mesh_NUMax As NumericUpDown
    Friend WithEvents Mesh_NUMin As NumericUpDown
    Friend WithEvents Label30 As Label
    Friend WithEvents LokaleHilfeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem12 As ToolStripSeparator
    Friend WithEvents ProjektordnerÖffnenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PfadeInOriginalbreiteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NeuLadenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GBPfad As GroupBox
    Friend WithEvents Pfad_TBWinkel As TextBox
    Friend WithEvents Pfad_TBRadius As TextBox
    Friend WithEvents Pfad_TBLänge As TextBox
    Friend WithEvents Pfad_TBRot As TextBox
    Friend WithEvents Pfad_TBStartWinkel As TextBox
    Friend WithEvents Pfad_TBBreite As TextBox
    Friend WithEvents Pfad_TBEndWinkel As TextBox
    Friend WithEvents Label38 As Label
    Friend WithEvents Label37 As Label
    Friend WithEvents Label36 As Label
    Friend WithEvents Label35 As Label
    Friend WithEvents Label34 As Label
    Friend WithEvents Label33 As Label
    Friend WithEvents Label32 As Label
    Friend WithEvents Pfad_CBTyp As ComboBox
    Private WithEvents Label40 As Label
    Friend WithEvents Pfad_CBRichtung As ComboBox
    Private WithEvents Label39 As Label
    Private WithEvents Label41 As Label
    Friend WithEvents Pfad_CBBlinker As ComboBox
    Private WithEvents Label42 As Label
    Friend WithEvents Pfad_CBAmpel As ComboBox
    Friend WithEvents Pfad_CBParallelProblem As CheckBox
    Friend WithEvents GBSplineHelper As GroupBox
    Friend WithEvents Label43 As Label
    Friend WithEvents Splinehelper_TBDrehung As TextBox
    Friend WithEvents Label44 As Label
    Friend WithEvents Splinehelper_TBSpline As TextBox
    Friend WithEvents Splinehelper_BTLaden As Button
    Friend WithEvents GBAchse As GroupBox
    Friend WithEvents Label48 As Label
    Friend WithEvents Achse_TBMinwidt As TextBox
    Friend WithEvents Label47 As Label
    Friend WithEvents Achse_TBBreite As TextBox
    Friend WithEvents Label46 As Label
    Friend WithEvents Achse_TBMaxwidt As TextBox
    Friend WithEvents Achse_CBAntrieb As CheckBox
    Friend WithEvents Label49 As Label
    Friend WithEvents Achse_TBFeder As TextBox
    Friend WithEvents Label51 As Label
    Friend WithEvents Achse_TBDaempfer As TextBox
    Friend WithEvents Label50 As Label
    Friend WithEvents Achse_TBMaxforce As TextBox
    Friend WithEvents GBBbox As GroupBox
    Friend WithEvents BBoxBTBerechnen As Button
    Friend WithEvents Label52 As Label
    Friend WithEvents BBox_PSSize As PointSelector
    Friend WithEvents GBKamera As GroupBox
    Friend WithEvents Kamera_RBPassagier As RadioButton
    Friend WithEvents Kamera_RBFahrer As RadioButton
    Friend WithEvents GBKupplPnt As GroupBox
    Friend WithEvents GBPfade As GroupBox
    Friend WithEvents Pfade_TBIndex As TextBox
    Friend WithEvents Label53 As Label
    Friend WithEvents Pfade_CBAusstieg As CheckBox
    Friend WithEvents Pfade_CBEinstieg As CheckBox
    Friend WithEvents GBRauch As GroupBox
    Friend WithEvents Label54 As Label
    Friend WithEvents PointSelector2 As PointSelector
    Friend WithEvents Label56 As Label
    Friend WithEvents VarSelector1 As VarSelector
    Friend WithEvents Rauch_Geschw As TextBox
    Friend WithEvents Label55 As Label
    Friend WithEvents GBPlatz As GroupBox
    Friend WithEvents Platz_TBRichtung As TextBox
    Friend WithEvents Label57 As Label
    Friend WithEvents FensterToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ObjekteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TextureToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EigenschaftenFensterToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents KameraToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents KupplungspunktToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RauchToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SpiegelToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TicketblockToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AttachpointsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SplinehelperToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem15 As ToolStripSeparator
    Friend WithEvents Label45 As Label
    Friend WithEvents Mat_CBAlpha As ComboBox
    Friend WithEvents Mat_TBAlphascale As TextBox
    Friend WithEvents Label58 As Label
    Friend WithEvents Mat_CBZCheck As CheckBox
    Friend WithEvents Mat_CBZWrite As CheckBox
    Friend WithEvents Mesh_MinMax As Button
    Friend WithEvents Parent_MinMax As Button
    Friend WithEvents Licht_MinMax As Button
    Friend WithEvents Bones_MinMax As Button
    Friend WithEvents Spline_MinMax As Button
    Friend WithEvents Pfad_MinMax As Button
    Friend WithEvents Achse_MinMax As Button
    Friend WithEvents Kamera_MinMax As Button
    Friend WithEvents Kupplung_MinMax As Button
    Friend WithEvents Pfade_MinMax As Button
    Friend WithEvents Rauch_MinMax As Button
    Friend WithEvents Mat_MinMax As Button
    Friend WithEvents Anim_MinMax As Button
    Friend WithEvents SplineHelper_MinMax As Button
    Friend WithEvents Platz_MinMax As Button
    Friend WithEvents Bel_MinMax As Button
    Friend WithEvents BBox_MinMax As Button
    Friend WithEvents ToolStripMenuItem16 As ToolStripSeparator
    Friend WithEvents EigenschaftenToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ErsetzenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BTTexOkay As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Anim_TBAnimGrp As TextBox
    Friend WithEvents Mesh_TBMeshident As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents AmpelphaseToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SoundToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SpotToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label59 As Label
    Friend WithEvents Achse_TBDurchmesser As TextBox
    Friend WithEvents PackenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RarArchivToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LctLOTUSContentToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReadmetxtToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Pfade_DDStepsound_0 As ComboBox
    Friend WithEvents Pfade_TBStehh_0 As TextBox
    Friend WithEvents Label61 As Label
    Friend WithEvents Label60 As Label
    Friend WithEvents Label62 As Label
    Friend WithEvents Pfade_DDNachste_0 As ComboBox
    Friend WithEvents Pfade_CBRichtung_0 As CheckBox
    Friend WithEvents Pfade_PVerb0 As Panel
    Friend WithEvents WagenteilToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem17 As ToolStripSeparator
    Friend WithEvents StatistikToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SuchenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem18 As ToolStripSeparator
    Friend WithEvents DarstellungToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AllesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OMSIAußenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OMSIInnenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OMSIAIBusToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PerspektiveToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FahrrersichtToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PassagiersichtToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AußenansichtToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FreieKameraToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ObjektToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EntfernenToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents CMSPfade As ContextMenuStrip
    Friend WithEvents NeuToolStripMenuItem3 As ToolStripMenuItem
    Friend WithEvents DuplizierenToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents EntfernenToolStripMenuItem3 As ToolStripMenuItem
    Friend WithEvents Label63 As Label
    Friend WithEvents Kuppl_DDNextVehicle As ComboBox
    Friend WithEvents FrontToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HeckToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label64 As Label
    Friend WithEvents Kuppl_DDRichtung As ComboBox
    Friend WithEvents Kuppl_CBSound As CheckBox
    Friend WithEvents Kuppl_DDKupplType As ComboBox
    Friend WithEvents Label65 As Label
    Friend WithEvents Kuppl_TBDrehwinkel As TextBox
    Friend WithEvents Label66 As Label
    Friend WithEvents Label68 As Label
    Friend WithEvents Label67 As Label
    Friend WithEvents Kuppl_TBUp As TextBox
    Friend WithEvents Kuppl_TBDown As TextBox
    Friend WithEvents LBMeshes As CheckedListBox
    Friend WithEvents VersteckenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RepaintToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NächsterWagenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents VorherigerWagenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FahrerkameraToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FahrgastkameraToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents InnenlichtToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label69 As Label
    Friend WithEvents Pfade_BTHinzu As Button
    Friend WithEvents Pfade_BTRem_0 As Button
    Friend WithEvents Pfade_PBOrange As PictureBox
    Friend WithEvents Pfade_PBLila As PictureBox
    Friend WithEvents Label70 As Label
    Friend WithEvents Pfade_CBNextWagen As CheckBox
    Friend WithEvents Pfade_CBVorWagen As CheckBox
    Friend WithEvents Pfade_CBTaster As CheckBox
    Friend WithEvents Pfade_CBVerkauf As CheckBox
    Friend WithEvents EntwerterToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TicketblockToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents RückgabefeldToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GeldrückgabeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MSTexturen As MenuStrip
    Friend WithEvents AnsichtToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents FrühlingToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SommernormalToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HerbstToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents WinterToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AlphaAnzeigenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label74 As Label
    Friend WithEvents Label73 As Label
    Friend WithEvents Kamera_TBVertikal As TextBox
    Friend WithEvents Kamera_TBHorizont As TextBox
    Friend WithEvents Label72 As Label
    Friend WithEvents Kamera_TBSichtwinkel As TextBox
    Friend WithEvents Label71 As Label
    Friend WithEvents Kamera_TBDistRotPnt As TextBox
    Friend WithEvents Kamera_CBVerkauf As CheckBox
    Friend WithEvents Kamera_CBFahrplan As CheckBox
    Friend WithEvents Kamera_BTStd As Button
    Friend WithEvents NurProjektbusovhscoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NurModelToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NurCabinToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NurPathsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AllesToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ModifikationToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents VeränderungAufnehmenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MitOriginalVergleichenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Kuppl_LBHeck As Label
    Friend WithEvents Kuppl_LBFront As Label
    Friend WithEvents DateiLöschenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label78 As Label
    Friend WithEvents Label77 As Label
    Friend WithEvents Label76 As Label
    Friend WithEvents Label75 As Label
    Friend WithEvents Anim_RBPoint As RadioButton
    Friend WithEvents Anim_RBMesh As RadioButton
    Friend WithEvents Anim_PSRotPnt As PointSelector
    Friend WithEvents TReloadTextures As Timer
    Friend WithEvents GBSpot As GroupBox
    Friend WithEvents Spot_TBLeuchtweite As TextBox
    Friend WithEvents Label79 As Label
    Friend WithEvents Spot_CSFarbe As ColorSelector
    Friend WithEvents Spot_PSRichtung As PointSelector
    Friend WithEvents Label81 As Label
    Friend WithEvents Spot_TBAussen As TextBox
    Friend WithEvents Spot_TBInner As TextBox
    Friend WithEvents Label80 As Label
    Friend WithEvents Label82 As Label
    Friend WithEvents Licht_CSFarbe As ColorSelector
    Friend WithEvents Label84 As Label
    Private WithEvents Label83 As Label
    Friend WithEvents NurToolUmgebungocdbToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Anim_PSRichtung As PointSelector
    Friend WithEvents Label85 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Anim_PRBArt As Panel
    Friend WithEvents Label87 As Label
    Friend WithEvents Anim_TBDelay As TextBox
    Friend WithEvents Anim_TBMaxSpeed As TextBox
    Friend WithEvents Label86 As Label
    Friend WithEvents Label91 As Label
    Friend WithEvents Label90 As Label
    Friend WithEvents Label89 As Label
    Friend WithEvents Label88 As Label
    Friend WithEvents Label95 As Label
    Friend WithEvents Label94 As Label
    Friend WithEvents Spline_TBEndZ As TextBox
    Friend WithEvents Spline_TBStartZ As TextBox
    Friend WithEvents Label93 As Label
    Friend WithEvents Spline_TBEndX As TextBox
    Friend WithEvents Spline_TBStartX As TextBox
    Friend WithEvents Label92 As Label
    Friend WithEvents Spline_CBVisible As CheckBox
    Friend WithEvents Splines_CBCollision As CheckBox
    Friend WithEvents PanelTimeline As Panel
    Friend WithEvents TCTimeline As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents BTPanelTimelineClose As Button
    Friend WithEvents TBScriptLog As TextBox
    Friend WithEvents TBLogfile As TextBox
    Friend WithEvents TimelineLogFensterToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SLTimeline As Splitter
    Friend WithEvents TimelineCursor As Panel
    Friend WithEvents GitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NeuesRepoKlonenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem8 As ToolStripSeparator
    Friend WithEvents CommitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PullToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PushToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SyncToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NeuesRepositoryToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem19 As ToolStripSeparator
    Friend WithEvents UnGitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GBSplinePfad As GroupBox
    Friend WithEvents SplinePfad_MinMax As Button
End Class
