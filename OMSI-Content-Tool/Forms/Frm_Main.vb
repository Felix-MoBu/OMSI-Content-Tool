'by Felix Modellbusse ;) (MoBu) 2019
'Option Strict On   'No Way of doing this shit!

Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.IO
Imports OpenTK
Imports OpenTK.Graphics
Imports OpenTK.Graphics.OpenGL

Class Frm_Main
    Declare Auto Sub CopyMemory Lib "Kernel32.dll" (ByVal dest As IntPtr, ByVal src As IntPtr, ByVal size As Integer)

    'Version ändern in Einstellungen -> Anwendung -> Assemblyinformationen...

    Public Shared ReadOnly OMSI_ImageFormats As String() = {"bmp", "dds", "jpg", "jpeg", "png", "tga"}
    Public Shared ReadOnly LOTUS_ImageFormats As String() = {"bmp", "dds"}

    Public Shared ReadOnly OMSI_SYS_VARS As String() = {"Timegap", "GetTime", "NoSound", "Pause", "Time", "Day", "Month", "Year", "DayOfYear", "mouse_x", "mouse_y", "PrecipType", "PrecipRate", "coll_pos_x", "coll_pos_y", "coll_pos_z", "coll_energy", "Weather_Temperature", "Weather_AbsHum", "AutoClutch", "wearlifespan", "SunAlt"}
    Public Shared ReadOnly OMSI_SCO_VARS As String() = {"NightLightA", "InUse", "TrafficLightPhase", "TrafficLightApproach", "Colorscheme", "Signal", "NextSignal", "Refresh_Strings", "Switch"}
    Public Shared ReadOnly OMSI_BUS_VARS As String() = {"Refresh_Strings", "Envir_Brightness", "StreetCond", "Spot_Select", "Colorscheme", "M_Wheel", "n_Wheel", "Throttle", "Brake", "Clutch", "Brakeforce", "Velocity", "Velocity_Ground", "tank_percent", "kmcounter_km", "kmcounter_m", "relrange", "Driver_Seat_VertTransl", "Wheel_Rotation_#_L", "Wheel_Rotation_#_R", "Wheel_RotationSpeed_#_L", "Wheel_RotationSpeed_#_R", "Axle_Suspension_#_L", "Axle_Suspension_#_R", "Axle_Steering_#_L", "Axle_Steering_#_R", "Axle_Springfactor_#_L", "Axle_Springfactor_#_R", "Axle_Brakeforce_#_L", "Axle_Brakeforce_#_R", "Axle_SurfaceID_#_L", "Axle_SurfaceID_#__R", "Debug_#", "A_Trans_X", "A_Trans_Z", "AI_Blinker_L", "AI_Blinker_R", "AI_Light", "AI_Interiorlight", "AI_Brakelight", "AI_Engine", "AI_target_index", "target_index_int", "AI_Scheduled_AtStation", "AI_Scheduled_AtStation_Side", "AI", "PAX_Entry#_Open", "PAX_Exit#_Open", "PAX_Entry#_Req", "PAX_Exit#_Req", "GivenTicket", "humans_count", "FF_Vib_Period", "FF_Vib_Amp", "Snd_OutsideVol", "Snd_Microphone", "Snd_Radio", "Cabinair_Temp", "Cabinair_absHum", "Cabinair_relHum", "PrecipRate", "PrecipType", "Dirt_Norm", "DirtRate", "schedule_active", "train_frontcoupling", "train_backcoupling", "train_me_reverse", "TrafficPriority", "wearlifespan", "articulation_#_alpha", "articulation_#_beta", "boogie_#_wheel_at_limit", "boogie_#_invradius", "contactshoe_#_rail_pos_x", "contactshoe_#_rail_pos_y", "contactshoe_#_rail_index", "contactshoe_#_volt_rail", "contactshoe_#_volt_veh", "contactshoe_#_freq"}
    Public Shared ReadOnly OMSI_STR_VARS As String() = {"ident", "number", "act_route", "act_busstop", "SetLineTo", "yard", "file_schedule"}
    Public Shared ReadOnly OMSI_HUM_VARS As String() = {"LastMovedDist", "PAX_State", "HeightOfSeat", "Colorscheme"}

    Dim saveStaus As Boolean
    Dim movePanelObjekte As Boolean
    Dim movePanelTexture As Boolean
    Dim movePanelEigenschaften As Boolean
    Dim movePanelTimeline As Boolean
    Dim resizePanelObjekte As Boolean
    Dim rotateObjekt As Boolean
    Dim mainShift As Boolean
    Dim mainStrg As Boolean
    Dim mausPos2D As New Point
    Dim temMousePos As New Point
    Dim tempPos2D As New Point
    Dim GlLoaded As Boolean = False
    Dim ModelLoaded As Boolean = False
    Dim scale3D As Double
    Dim scale3DOld As Double
    Dim CamLocation As New Point3D
    Dim CamLocationOld As New Point3D

    Public OpenProjects As New List(Of OCTProjekt)
    Public actProj As Object

    Public selectedMeshes As List(Of OMSI_Mesh)
    Public selectedMesh As OMSI_Mesh
    Public lastSelectedMesh As OMSI_Mesh
    Public lastSelectedLight As Integer = -1
    Private selectedMeshesChanged As Boolean = False
    Public Clipboard3D As Point3D
    Public Sprachen As List(Of String)
    Public selectedRepaint As OMSI_Repaint

    Public lodVal As Single

    Public viewMode As Byte = viewModes.ALLES
    Public viewPoint As Byte = 4
    Public selectedDriverCam As Integer = 0
    Public selectedPassCam As Integer = 0

    Dim timerMin As Integer
    Dim timerSec As Integer
    Dim timerBool As Boolean

    Dim activeImageSelector As Object

    Dim resizePanelEigenschaften As Boolean = False
    Dim PanelEigenschaften_height As Integer
    Dim PanelObjecte_size As Point
    Dim meshesDragStart As Integer = 0

    Dim dotTexture As Material
    Dim softDotTexture As Material

    Private Structure viewModes
        Const ALLES As Byte = 0
        Const AUSSEN As Byte = 1
        Const INNEN As Byte = 2
        Const AI As Byte = 4
        'Summieren zum kombinieren!
    End Structure

    Private Sub Frm_Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Log.Clear()
        Log.Add("Editor gestartet!")

        addOCTProj(New OCTProjekt)

        movePanelObjekte = False
        movePanelTexture = False
        movePanelEigenschaften = False
        saveStaus = True
        scale3D = 20
        Clipboard3D = New Point3D
        lodVal = 1

        Settings.Load()
        loadPositions()

        If Settings.EMail = Frm_Einst.stdMail Then
            TestToolStripMenuItem.Visible = True
        End If

        timerMin = Settings.SaveInterval
        timerSec = 0
        timerBool = False
        TSave.Start()
        GlMain.Select()

        TCObjekte_SelectedIndexChanged(TCObjekte, Nothing)

        Mesh_DDViedpoint.SelectedIndex = 0
        TVHelper.SelectedNode = TVHelper.Nodes(0)

        redrawLetzte()

        If Settings.TexAutoReload Then TReloadTextures.Start()

        If Git.isInstalled And Settings.GitShowInMenue Then
            GitToolStripMenuItem.Visible = True
        End If


        If My.Application.CommandLineArgs.Count > 0 Then
            Dim newFile As New Filename(My.Application.CommandLineArgs(0))
            If projectExtensions.Contains(newFile.extension) Then
                If My.Application.CommandLineArgs.Count > 1 Then
                    If My.Application.CommandLineArgs(1) = "newTab" Then
                        TCProjekte.TabPages.Add("   +   ")
                        addOCTProj(New OCTProjekt)
                        TCProjekte.SelectTab(TCProjekte.TabCount - 2)
                    End If
                End If
                ProjÖffnen(newFile)
            ElseIf Importer.KNOWN_FILE_TYPES.Contains(newFile.extension) Then
                Dim newMesh As New OMSI_Mesh
                newMesh = fileimport2(newFile)
                If Not newMesh Is Nothing Then
                    If My.Application.CommandLineArgs.Count > 2 Then
                        If My.Application.CommandLineArgs(1) = "convert" Then
                            If Exporter.KNOWN_FILE_TYPES.Contains(LCase(My.Application.CommandLineArgs(2))) Then
                                fileExport2(newMesh, My.Application.CommandLineArgs(2))
                                Me.Close()
                            End If
                        End If
                    End If

                    actProj.model.meshes.add(newMesh)
                    LBMeshes.Items.Add(newMesh.filename.name)
                    LBMeshes.SetItemChecked(LBMeshes.Items.Count - 1, True)
                    Parent_CBParent.Items.Add(newMesh.filename.name)


                    If newFile.extension.ToLower <> "o3d" Then
                        newMesh.isProtected = False
                    End If
                End If
            ElseIf newFile.extension = DataBase.FILETYPE Then
                For Each extension In projectExtensions()
                    If IO.File.Exists(newFile.path & "\" & newFile.nameNoEnding & "." & extension) Then
                        ProjÖffnen(newFile.path & "\" & newFile.nameNoEnding & "." & extension)
                        Exit For
                    End If
                Next
            Else
                MsgBox("Datei " & newFile & " wird nicht unterstützt!")
            End If

        End If
    End Sub


    Public Sub addOCTProj(project As OCTProjekt)
        OpenProjects.Add(project)
        actProj = OpenProjects.Last.actProj
        If actProj.filename.name <> "" Then
            TCProjekte.SelectedTab.Text = actProj.filename.name
        Else
            TCProjekte.SelectedTab.Text = "Neues Projekt"
        End If
    End Sub


    Private Function projectExtensions() As List(Of String)
        projectExtensions = New List(Of String)
        With projectExtensions
            .Add(Proj_Bus.EXTENSION)
            .Add(Proj_Ovh.EXTENSION)
            .Add(Proj_Sco.EXTENSION)
            .Add(Proj_Sli.EXTENSION)
        End With
        Return projectExtensions
    End Function

    Private Sub Frm_Main_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        'If exitApplication() = False Then e.Cancel = True
        Log.Add("Editor normal beendet!")
        Log.Close()
    End Sub

    Private Function getFilePath(path As String) As String
        Dim s() As String = Split(path, "\")
        Dim sTmp As String = ""
        For i = 0 To s.Count - 2
            sTmp &= s(i) & "\"
        Next
        Return sTmp
    End Function

    Private Sub settexport()
        For Each mesh In getSelectedMeshes()
            Dim fd As New SaveFileDialog
            SSLBStatus.Text = "Export..."
            With fd
                .Title = "Export"
                .FileName = mesh.filename.nameNoEnding
                .Filter = "OMSI-CFG (*.cfg)|*.cfg|Mesh-Eigenschaften (*.txt)|*.txt"

                If .ShowDialog = DialogResult.OK Then
                    Settings.ExportPfad = .FileName
                    Dim fw As New FileWriter(New Filename(.FileName))
                    fw.AddRange(mesh.getpropertys())
                    fw.Write()
                    Log.Add("Mesh-Eigenschaften Exportiert (Datei: " & .FileName & ")")
                Else
                    SSLBStatus.Text = "Export abgebrochen"
                    Exit Sub
                End If
            End With
        Next
    End Sub


    Private Sub fileExport()
        For Each mesh In getSelectedMeshes()
            For Each objekt In getOCTProj.alleMeshes
                If mesh.ObjIds.Contains(objekt.id) Then
                    If Not actProj.filename Is Nothing Then
                        Dim fd As New SaveFileDialog
                        SSLBStatus.Text = "Export..."
                        With fd
                            .Title = "Export"
                            .FileName = mesh.filename.nameNoEnding

                            '########################
                            '   Muss wieder raus!
                            '########################
                            mesh.isProtected = False

                            If mesh.isProtected Then
                                .Filter = "OMSI-3D (*.o3d)|*.o3d"
                            Else
                                .Filter = "OMSI-3D (*.o3d)|*.o3d|DirectX (*.x)|*.x|Extensible 3D (*.x3d)|*.x3d"
                                .FilterIndex = Settings.LastExportFormat
                            End If


                            If .ShowDialog = DialogResult.OK Then
                                Settings.ExportPfad = .FileName
                                Settings.LastExportFormat = .FilterIndex
                                Exporter.write(objekt, New Filename(.FileName))
                            Else
                                SSLBStatus.Text = "Export abgebrochen"
                                Exit Sub
                            End If
                        End With
                    Else
                        Exporter.write(objekt, mesh.filename)
                    End If
                End If
            Next
        Next
    End Sub

    Private Sub fileExport2(mesh As OMSI_Mesh, Optional newExtension As String = "")
        For Each objekt In getOCTProj.alleMeshes
            If mesh.ObjIds.Contains(objekt.id) Then
                If newExtension <> "" Then
                    mesh.filename.extension = newExtension
                End If
                Exporter.write(objekt, mesh.filename)
            End If
        Next
    End Sub

    Private Sub fileImport()
        Dim fd As New OpenFileDialog
        SSLBStatus.Text = "Import..."
        With fd

            .Title = "Import"
            .Filter = "Alle Formate (*.*)|*.*|" &
                      "OMSI-3D (*.o3d)|*.o3d|" &
                      "DirectX (*.x)|*.x|" &
                      "Extensible 3D (*.x3d)|*.x3d|" &
                      "Modell-Datei (*.cfg)|*.cfg|" &
                      "Mesh-Eigenschaften (*.txt)|*.txt|" &
                      "Map-Kachel (*.rdy)|*.rdy|" &
                      "Hof-Datei (*.hof)|*.hof"
            .FilterIndex = Settings.LastImportFormat
            .Multiselect = True
            If actProj.filename.path <> "" Then
                .InitialDirectory = actProj.filename.path & "\Model\"
            Else
                .InitialDirectory = Settings.ImportPfad
            End If

            .ShowDialog()
            If .FileNames.Count > 0 Then

                For Each file In .FileNames
                    Dim success As Boolean = False
                    Dim newFilename As Filename
                    If file.ToLower.Contains("\model\") And actProj.filename.path <> "" Then
                        newFilename = New Filename(file, actProj.filename.path & "\Model\")
                    Else
                        If InStr(file, actProj.filename.path) Then
                            newFilename = New Filename(file, actProj.filename.path)
                        Else
                            newFilename = New Filename(file)
                        End If
                    End If

                    If newFilename.extension.ToLower = "o3d" Or newFilename.extension.ToLower = "x" Or newFilename.extension.ToLower = "x3d" Or newFilename.extension.ToLower = "rdy" Then
                        If actProj.model Is Nothing Then
                            actProj.model = New OMSI_Model
                        End If

                        Dim newMesh As New OMSI_Mesh
                        newMesh = fileimport2(New Filename(newFilename), True)

                        If Not newMesh Is Nothing Then
                            actProj.model.meshes.add(newMesh)
                            LBMeshes.Items.Add(newMesh.filename.name)
                            LBMeshes.SetItemChecked(LBMeshes.Items.Count - 1, True)
                            Parent_CBParent.Items.Add(newMesh.filename.name)

                            If newFilename.extension.ToLower <> "o3d" Then
                                newMesh.isProtected = False
                            End If
                        End If
                    ElseIf newFilename.extension.ToLower = "cfg" Then

                        If System.IO.File.Exists(newFilename) Then
                            Dim fileContent As String = My.Computer.FileSystem.ReadAllText(newFilename)

                            If fileContent.Contains("[mesh]") Or fileContent.Contains("[smoke]") _
                                Or fileContent.Contains("[texttexture") Or fileContent.Contains("[light") Then '<- WICHTIG ohne Klammer zu für _enh!!!
                                If Not actProj.model Is Nothing Then
                                    Dim x As MsgBoxResult = MsgBox("Modell-Datei ersetzen? (Sonst wird das bestehende Modell ergänzt)", MsgBoxStyle.YesNoCancel)
                                    Select Case x
                                        Case MsgBoxResult.Yes
                                            actProj.model = New OMSI_Model(newFilename)
                                        Case MsgBoxResult.No
                                            actProj.model.add(New OMSI_Model(newFilename))
                                    End Select
                                Else
                                    actProj.filename = newFilename
                                    actProj.model = New OMSI_Model(newFilename)
                                End If
                                loadModelPrefs(actProj.model)
                                showModel(actProj.model.meshes)
                                success = True

                            ElseIf fileContent.Contains("[pathpnt]") Then   '# Funktioniert nicht!
                                If Not getProjType() = Proj_Sli.TYPE Or getProjType() = Proj_Sco.TYPE Then
                                    actProj.paths = New OMSI_Paths(newFilename)
                                    loadPathsPrefs(actProj.paths)
                                    success = True
                                Else
                                    MsgBox("Der Projekttyp Spline unterstützt die importierte Pfad-Datei nicht!")
                                End If

                            ElseIf fileContent.Contains("[passpos]") Then   '# Funktioniert nicht!
                                If Not getProjType() = Proj_Sli.TYPE Then
                                    actProj.cabin = New OMSI_Cabin(newFilename)
                                    loadCabinPrefs(actProj.cabin)
                                    success = True
                                Else
                                    MsgBox("Der Projekttyp Spline unterstützt die importierte Cabin-Datei nicht!")
                                End If
                            End If
                        End If

                        If Not success Then
                            Log.Add("Datei konnte beim Import nicht gefunden werden! (Datei: " & newFilename & ")")
                            MsgBox("Datei konnte nicht gefunden werden! (Datei: " & newFilename & ")")
                        End If

                    ElseIf newFilename.extension.ToLower = "hof" Then
                        Frm_Hof.copyNewHof(newFilename)
                        SSLBStatus.Text = "Hofdatei importiert"
                    End If

                Next
                GlMain.Invalidate()

                Settings.ImportPfad = getFilePath(.FileName)
                Settings.LastImportFormat = .FilterIndex

                TCObjektePMeshes.Text = "Meshes (" & getOCTProj.alleMeshes.Count & ")"
            End If
        End With
    End Sub

    Public Function fileimport2(filename As Filename, Optional convert As Boolean = False) As OMSI_Mesh
        Dim newObjekt As Object = Importer.readFile(filename)

        If TypeOf newObjekt Is Mesh Then
            Dim newMesh As New OMSI_Mesh
            newMesh.filename = filename
            newMesh.position = newObjekt.position
            newMesh.center = newObjekt.center
            newMesh.origin = newObjekt.origin
            newMesh.index = getOCTProj.alleMeshes.Count
            newMesh.o3dVersion = newObjekt.o3dVersion


            newObjekt.parentMesh = newMesh.filename.name
            newObjekt.id = getOCTProj.alleMeshes.Count
            newMesh.ObjIds.Add(newObjekt.id)

            'Wenn automatisch eine o3d angelegt werden soll
            If convert Then
                If Not newMesh.filename.extension = "o3d" And Settings.o3dAutoConvert Then
                    newMesh.filename.extension = "o3d"
                    Exporter.write(newObjekt, newMesh.filename)
                End If
            End If

            getOCTProj.alleMeshes.Add(newObjekt)

            If actProj.model Is Nothing Then actProj.model = New OMSI_Model

            loadTextures(newObjekt.texturen, newMesh.filename.path)
            ModelLoaded = True


            Return newMesh
        ElseIf TypeOf newObjekt Is OMSI_Model Then
            actProj.model = newObjekt
            Return Nothing
        Else

            Log.Add("Datei nicht geaden! (Datei: " & filename.name & ")", Log.TYPE_DEBUG)
            Return Nothing
        End If
    End Function

    Private Sub resetTextures()
        For i = 0 To getOCTProj.alleTexturen.Count
            GL.DeleteTexture(i)
        Next
        getOCTProj.alleTexturen.Clear()
        DDAlleTexturen.Items.Clear()
    End Sub


    Private Sub calcMirrors(mirrorID As Integer)
        If getProjType() = Proj_Bus.TYPE Then
            Dim texID As Integer = -1
            For i As Integer = 0 To getOCTProj.alleTexturen.Count - 1
                If getOCTProj.alleTexturen(i).ToLower = "reflexion" & mirrorID & ".bmp" Then
                    texID = i + 1
                    Exit For
                End If
            Next
            If texID = -1 Then
                Log.Add("Spiegelüberlauf!", Log.TYPE_ERROR)
                Exit Sub
            End If

            'GL.Rotate() Auf Spiegelposition bringen!
            Dim bmp As New Bitmap(GlMain.ClientSize.Width, GlMain.ClientSize.Height)
            Dim Data As Imaging.BitmapData = bmp.LockBits(GlMain.ClientRectangle, Imaging.ImageLockMode.WriteOnly, Imaging.PixelFormat.Format24bppRgb)
            GL.ReadPixels(0, 0, GlMain.ClientSize.Width, GlMain.ClientSize.Height, PixelFormat.Bgr, PixelType.UnsignedByte, Data.Scan0)
            bmp.UnlockBits(Data)
            bmp.RotateFlip(RotateFlipType.RotateNoneFlipY)

            'Hier Spiegelung Horizontal!
            bmp.RotateFlip(RotateFlipType.RotateNoneFlipX)


            Dim rect = New Rectangle(0, 0, bmp.Width, bmp.Height)
            Dim bmpdata As Imaging.BitmapData = bmp.LockBits(rect, Imaging.ImageLockMode.ReadOnly, bmp.PixelFormat)
            bmp.UnlockBits(bmpdata)

            GL.BindTexture(TextureTarget.Texture2D, texID)
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, bmpdata.Width, bmpdata.Height, 0, PixelFormat.Bgra, PixelType.UnsignedByte, bmpdata.Scan0)
            GL.GenerateMipmap(GenerateMipmapTarget.Texture2D)
        End If
    End Sub


    Public Sub loadTexture(ByRef texture As Material, Optional overWrite As Boolean = False)

        If getOCTProj.alleTexturen.Contains(texture.filename.name) And Not overWrite Then
            texture.id = getOCTProj.alleTexturen.IndexOf(texture.filename.name) + 1
            texture.lastChangeDate = IO.File.GetLastWriteTime(texture.filename)
        Else
            Try
                texture.id = getOCTProj.alleTexturen.Count + 1
                texture.lastChangeDate = IO.File.GetLastWriteTime(texture.filename)
                GL.GenTextures(1, texture.id)
                GL.BindTexture(TextureTarget.Texture2D, texture.id)

                Dim texData As Imaging.BitmapData = loadImage(texture)

                Select Case texData.PixelFormat
                    Case Imaging.PixelFormat.Format32bppArgb        'Mit Alpha
                        GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, texData.Width, texData.Height, 0, PixelFormat.Bgra, PixelType.UnsignedByte, texData.Scan0)
                    Case Imaging.PixelFormat.Format8bppIndexed      'Ohne Alpha
                        GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgb, texData.Width, texData.Height, 0, PixelFormat.ColorIndex, PixelType.UnsignedByte, texData.Scan0)
                    Case Imaging.PixelFormat.Format4bppIndexed      'spezielle PNG
                        GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgb, texData.Width, texData.Height, 0, PixelFormat.UnsignedInt, PixelType.UnsignedByte, texData.Scan0)
                        Log.Add("Textureformat nicht unterstützt! (Datei: " & texture.filename.name & ")", Log.TYPE_WARNUNG)
                    Case Else                                       'Normale
                        GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgb, texData.Width, texData.Height, 0, PixelFormat.Bgr, PixelType.UnsignedByte, texData.Scan0)
                End Select


                GL.GenerateMipmap(GenerateMipmapTarget.Texture2D)
                If Not getOCTProj.alleTexturen.Contains(texture.filename.name) Then getOCTProj.alleTexturen.Add(texture.filename.name)
                If Not DDAlleTexturen.Items.Contains(texture.filename.name) Then DDAlleTexturen.Items.Add(texture.filename.name)
                If overWrite Then Log.Add("Bilddatei neu geladen! (Datei: " & texture.filename.name & ")")

            Catch ex As Exception
                Log.Add("Bilddatei beschädigt oder im falschen Format gespeichert! (Fehler: T999, Datei: " & texture.filename.name & ")", Log.TYPE_ERROR)
            End Try
        End If
    End Sub

    Private Sub loadTextures(Texturen As List(Of Material), objPfad As String, Optional overWrite As Boolean = False)
        For Each texture In Texturen
            findTexture(texture, objPfad)
            loadTexture(texture, overWrite)
        Next
    End Sub


    Function loadImage(ByRef Texture As Material) As Imaging.BitmapData
        Dim bmp As Bitmap
        If Texture.filename.name = "keine" Then
            bmp = New Bitmap(My.Resources.weiss)
            Log.Add("Texture nicht gefunden! (Fehler: T998, Datei: " & Texture.filename.name & ")", Log.TYPE_WARNUNG)
        Else
            If Texture.filename.path = "" Then
                bmp = New Bitmap(My.Resources.pink2)
            Else
                Select Case LCase(Texture.filename.extension)
                    Case "tga"
                        bmp = TGA_Tool.readTGA(Texture.filename.path & "\" & Texture.filename.name)
                        'MsgBox(bmp.PixelFormat.ToString)
                    Case "dds"
                        Dim bytes = My.Computer.FileSystem.ReadAllBytes(Texture.filename.path & "\" & Texture.filename.name)
                        If Chr(bytes(0)) = "B" And Chr(bytes(1)) = "M" And Chr(bytes(2)) = "8" Then
                            bmp = New Bitmap(Texture.filename.path & "\" & Texture.filename.name)
                        Else
                            Log.Add("Textureformat nicht unterstützt! (Fehler: T997, Datei: " & Texture.filename.name & ")", Log.TYPE_WARNUNG)
                            bmp = New Bitmap(My.Resources.pink2)
                        End If
                        bytes = Nothing
                    Case Else
                        bmp = New Bitmap(Texture.filename.path & "\" & Texture.filename.name)
                End Select
            End If
        End If
        Dim rect = New Rectangle(0, 0, bmp.Width, bmp.Height)
        Dim bmpdata = bmp.LockBits(rect, Imaging.ImageLockMode.ReadOnly, bmp.PixelFormat)
        bmp.UnlockBits(bmpdata)
        Return bmpdata
    End Function

    Private Sub findTexture(texture As Material, objektpfad As String)
        Dim ctsub As Integer
        Dim tmppath = Split(objektpfad, "\")
        objektpfad = ""
        For i = 0 To tmppath.Count - 1 'HIER!!!!!!!!!!!!!!!!!!!!!!!!!!!
            If LCase(tmppath(i)) = "model" Then ctsub = i
        Next i
        For i = 0 To ctsub - 1
            objektpfad &= tmppath(i) & "\"
        Next i
        objektpfad &= "Texture"
        texture.filename.path = objektpfad

        If System.IO.File.Exists(objektpfad & "\" & texture.filename.name) Then
            texture.filename.path = objektpfad
        Else
            If System.IO.File.Exists(Join(tmppath, "\") & "\" & texture.filename.name) Then
                texture.filename.path = Join(tmppath, "\")
            Else
                If System.IO.File.Exists(Join(tmppath, "\") & "\Texture\" & texture.filename.name) Then
                    texture.filename.path = Join(tmppath, "\") & "\Texture\"
                Else
                    texture.filename.path = ""
                    Log.Add("Texture nicht gefunden! (Fehler: T999, Datei: " & texture.filename.name & ")", Log.TYPE_WARNUNG)
                End If
            End If
        End If
    End Sub

    Private Sub save()

        Select Case TCObjekte.SelectedIndex
            Case 0
                saveMeshProbs(getSelectedMesh)
            Case 2
                saveLightProps(LBLichter.SelectedIndex)
        End Select

        actProj.save()
        addProjectlist(actProj.filename.ToString)


        If Settings.SaveIntervalActive Then
            TimerReset()
            TSave.Start()
        End If

        If Git.isRepo And Settings.GitAutoCommit Then
            Git.Commit(Now)
        End If

        SSLBStatus.Text = "Speichern abgeschlossen"
    End Sub

    Private Function exitApplication() As Boolean
        If saveStaus = False Then
            Dim Input As Integer = MsgBox("Möchten sie die Änderungen Speichern?", vbYesNoCancel, "Beenden")
            Select Case Input
                Case vbYes
                    save()
                    saveStaus = True
                    Return True
                Case vbNo
                    Return True
            End Select
        Else
            Return True
        End If
        Return False
    End Function

    '#####  Timer  #####
    Private Sub TSave_Tick(sender As Object, e As EventArgs) Handles TSave.Tick
        timerBool = Not timerBool
        GlMain.Invalidate()

        If Settings.SaveIntervalActive Then
            If timerSec > 0 Then
                timerSec -= 1
            Else
                If timerMin > 0 Then
                    timerMin -= 1
                Else
                    If Settings.SaveIntervalAuto Then
                        save()
                    Else
                        TBTimer.ForeColor = Color.Red
                        TBTimer.Text = "Jetzt speichern!"
                        Exit Sub
                    End If
                End If
                timerSec = 59
            End If

            TBTimer.ForeColor = Color.Black
            TBTimer.Text = "Wieder speichern in: " & timerMin & ":"
            If timerSec < 10 Then TBTimer.Text &= "0"
            TBTimer.Text &= timerSec
        Else
            TBTimer.Text = ""
        End If
    End Sub

    Public Sub TimerReset()
        timerMin = Settings.SaveInterval
        timerSec = 0
    End Sub

    Public Sub RecalcLod()
        For Each mesh In actProj.model.meshes
            For Each objekt In getOCTProj.alleMeshes
                If mesh.ObjIds.Contains(objekt.id) Then
                    If mesh.lodMin <= lodVal And mesh.lodMax >= lodVal Then
                        objekt.visible = True
                    Else
                        objekt.visible = False
                    End If
                End If
            Next
        Next
        GlMain.Invalidate()
    End Sub

    Public Sub RecalcVis(var As String, val As Double)
        For Each mesh In actProj.model.meshes
            If Not mesh.visibleVar = Nothing Then
                If mesh.visibleVar = var Then
                    For Each objekt In getOCTProj.alleMeshes
                        If mesh.ObjIds.Contains(objekt.id) Then
                            If Not mesh.visibleInt = Nothing Then
                                If mesh.visibleInt = val Then
                                    objekt.visible = True
                                Else
                                    objekt.visible = False
                                End If
                            Else
                                objekt.visible = True
                            End If
                        End If
                    Next
                End If
            End If
        Next
    End Sub

    Public Sub resetVis()
        For Each mesh In actProj.model.meshes
            If Not mesh.visibleVar = Nothing Then
                For Each objekt In getOCTProj.alleMeshes
                    If mesh.ObjIds.Contains(objekt.id) Then
                        objekt.visible = False
                    End If
                Next
            End If
        Next
    End Sub

    Public Sub RecalcAlpha(var As String, val As Single)
        Dim alleMeshesTemp As List(Of Mesh) = getOCTProj.alleMeshes
        Dim modelMeshes As List(Of OMSI_Mesh) = actProj.model.meshes
        If getProjType() = Proj_Bus.TYPE Then
            For Each mesh In modelMeshes
                For Each objekt In alleMeshesTemp
                    If mesh.ObjIds.Contains(objekt.id) Then
                        For Each material In mesh.materials
                            If var = material.alphascale Then
                                For Each texture In objekt.texturen
                                    If texture.filename.name.ToLower = material.name.ToLower Then
                                        texture.alpha = val
                                        Exit Sub
                                    End If
                                Next
                            End If
                        Next
                    End If
                Next
            Next
        End If

        If getProjType() = Proj_Sco.TYPE Then           'Unnötig, aber geht nicht besser, dauert sonst zu lange!
            For Each mesh In actProj.model.meshes
                For Each objekt In getOCTProj.alleMeshes
                    If mesh.ObjIds.Contains(objekt.id) Then
                        For Each material In mesh.materials
                            If var = material.alphascale Then
                                For Each texture In objekt.texturen
                                    If texture.filename.name.ToLower = material.name.ToLower Then
                                        texture.alpha = val
                                        Exit Sub
                                    End If
                                Next
                            End If
                        Next
                    End If
                Next
            Next
        End If
    End Sub

    Public Function getOCTProj() As OCTProjekt
        Return OpenProjects(TCProjekte.SelectedIndex)
    End Function

    Public Function getProjType() As Byte
        If actProj Is Nothing Then Return Proj_Emt.TYPE
        Return actProj.TYPE
    End Function

    Public Sub clearProject()
        resetTextures()
        getOCTProj.alleMeshes = New List(Of Mesh)
        LBMeshes.Items.Clear()
        TCObjekte.TabPages(0).Text = "Meshes"
        resetTVHelper()
        LBLichter.Items.Clear()
        LBPfade.Items.Clear()
        TCProjekte.SelectedTab.Text = "Neues Projekt"
        OpenProjects(TCProjekte.SelectedIndex).reset()
    End Sub

    Private Sub resetTVHelper()

        For i As Integer = 0 To TVHelper.Nodes.Count - 1
            If i = 2 Or i = 8 Then
                For n As Integer = 0 To TVHelper.Nodes(i).Nodes.Count - 1
                    TVHelper.Nodes(i).Nodes(n).Nodes.Clear()
                Next
            Else
                TVHelper.Nodes(i).Nodes.Clear()
            End If
        Next
    End Sub


    'Menüband
    '###########

    Private Sub ÖffnenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ÖffnenToolStripMenuItem.Click
        Dim fd As New OpenFileDialog
        SSLBStatus.Text = "Projekt öffnen..."

        With fd
            .Title = "Öffnen"
            .Filter = "Unterstützte Formate (*.bus, *.ovh, *.sco, *.sli)|*.bus; *.ovh; *.sco; *.sli|Bus (*.bus)|*.bus|Fahrzeug (*.ovh)|*.ovh|Scenerieobjekt (*.sco)|*.sco|Spline (*.sli)|*.sli"
            .InitialDirectory = Settings.OpenPath
            If .ShowDialog() = DialogResult.OK Then
                If .FileName <> "" Then
                    ProjÖffnen(.FileName)
                End If
            End If
        End With
    End Sub

    Private Sub öffneLetzte(ByVal sender As Object, ByVal e As EventArgs)
        If System.IO.File.Exists(sender.text) Then
            ProjÖffnen(sender.Text)
        Else
            Dim result = MsgBox("Die Datei existiert nicht! Soll sie von der Liste entfernt werden?", MsgBoxStyle.YesNo)
            If result = vbYes Then
                If Settings.LetzteProjekte.Contains(sender.Text) Then
                    Settings.LetzteProjekte.Remove(sender.Text)
                End If
                redrawLetzte()
            End If
        End If
    End Sub

    Private Sub redrawLetzte()
        With LetzteToolStripMenuItem
            .DropDownItems.Clear()
            For i = Settings.LetzteProjekte.Count - 1 To 0 Step -1
                Dim item As String = Settings.LetzteProjekte(i)
                If item <> "" Then
                    Dim newitem As New ToolStripMenuItem()
                    AddHandler newitem.Click, AddressOf öffneLetzte
                    newitem.Text = item
                    Select Case item.Substring(item.Length - 3).ToLower
                        Case "bus"
                            newitem.Image = My.Resources.Bus
                        Case "ovh"
                            newitem.Image = My.Resources.Ovh
                        Case "sco"
                            newitem.Image = My.Resources.Sco
                        Case "sli"
                            newitem.Image = My.Resources.sli
                    End Select
                    .DropDownItems.Add(newitem)
                End If
            Next
            If .DropDownItems.Count = 0 Then
                .Enabled = False
            Else
                .Enabled = True
            End If
        End With
    End Sub

    Private Sub resetProj(Optional ProjIndex As Integer = -1)
        If ProjIndex = -1 Then ProjIndex = TCProjekte.SelectedIndex

        OpenProjects(ProjIndex).reset()
        resetTextures()
        getOCTProj.alleMeshes = New List(Of Mesh)
        getOCTProj.alleTexturen = New List(Of String)
        getOCTProj.alleVarValues = New Dictionary(Of String, Single)
        HofDateienToolStripMenuItem.Enabled = False     'Nur Busse haben Hof-Dateien
        RepaintToolStripMenuItem.Enabled = False        'Splines haben keine Repaints

        Text = My.Application.Info.Title
    End Sub

    Private Sub ProjÖffnen(filename As String, Optional ProjIndex As Integer = -1)
        Dim newProj As Object

        If ProjIndex = -1 Then ProjIndex = TCProjekte.SelectedIndex
        resetProj(ProjIndex)

        Select Case LCase(filename.Substring(filename.Length - 3))
            Case "bus"
                clearProject()
                newProj = New Proj_Bus(filename)
                OpenProjects(ProjIndex) = New OCTProjekt(newProj)
                actProj = OpenProjects(ProjIndex).actProj
                Settings.OpenPath = getFilePath(filename)
                If newProj.couple_back_file <> "" Then
                    TCProjekte.TabPages.Add("   +   ")
                    OpenProjects.Add(New OCTProjekt)
                    ProjÖffnen(newProj.couple_back_file.ToString, OpenProjects.Count - 1)
                End If
                LoadProjectBus(newProj)
                RepaintToolStripMenuItem.Enabled = True
            Case "sco"
                clearProject()
                OpenProjects(ProjIndex) = New OCTProjekt(New Proj_Sco(filename))
                actProj = OpenProjects(ProjIndex).actProj
                Settings.OpenPath = getFilePath(filename)
                LoadProjectSco()
            Case "sli"
                clearProject()
                OpenProjects(ProjIndex) = New OCTProjekt(New Proj_Sli(filename))
                actProj = OpenProjects(ProjIndex).actProj
                Settings.OpenPath = getFilePath(filename)
                LoadProjectSli()
            Case Else
                MsgBox("Projektdatei nicht unterstützt!")
                SSLBStatus.Text = ""
                Exit Sub
        End Select
        addProjectlist(filename)
        loadProjDataBase()
        GlMain.Invalidate()
        TCObjekte_SelectedIndexChanged(TCObjekte, Nothing)
        Git.tryFindRepoAt(New Filename(filename).path)

        If Not Importer.stopImport Then
            Text = filename & " - " & My.Application.Info.Title
            TCProjekte.TabPages(ProjIndex).Text = actProj.filename.name
        End If
        Importer.stopImport = False
    End Sub

    Public Sub addProjectlist(filename As String)
        If filename = "" Then Exit Sub
        If Settings.LetzteProjekte.Count > 0 Then
            If Settings.LetzteProjekte(Settings.LetzteProjekte.Count - 1) = filename Then Exit Sub
        End If

        Dim tmpList As New List(Of String)
        For i As Integer = Settings.LetzteProjekte.Count - 1 To 0 Step -1
            If Settings.LetzteProjekte(i) <> filename Then
                tmpList.Add(Settings.LetzteProjekte(i))
            End If
            If tmpList.Count = 5 Then Exit For
        Next
        tmpList.Add(filename)
        Settings.LetzteProjekte = tmpList

        Settings.Save()
        redrawLetzte()
    End Sub

    Private Sub LoadProjectSco()
        With actProj

            SplinehelperToolStripMenuItem.Enabled = True

            loadModelPrefs(.model)
            showModel(.model.meshes)

            TVHelper.Nodes(7).Nodes.Clear()
            If Not .cabin Is Nothing Then
                For i = 0 To .cabin.passPos.Count - 1
                    TVHelper.Nodes(7).Nodes.Add("Platz " & i)
                Next
            End If

            LBPfade.Items.Clear()
            For i = 0 To .ki_paths.Count - 1
                LBPfade.Items.Add("Pfad_" & i)
            Next

            TVHelper.Nodes(9).Nodes.Clear()
            For i As Integer = 0 To .attachPnts.count - 1
                If .attachPnts(i).name <> "" Then
                    TVHelper.Nodes(9).Nodes.Add(.attachPnts(i).name)
                Else
                    TVHelper.Nodes(9).Nodes.Add("AttachPoint_" & i)
                End If
            Next

            TVHelper.Nodes(10).Nodes.Clear()
            For Each spline In .splinehelpers
                TVHelper.Nodes(10).Nodes.Add(spline.spline.name)
            Next

            .isloaded = True
            AmpelphaseToolStripMenuItem.Enabled = True


            VariablenAusOrdnerLaden(.varlists, .filename)


            projectReady()
        End With
    End Sub

    Private Sub loadProjDataBase()
        If Not actProj.ProjDataBase Is Nothing Then
            With actProj.ProjDataBase

                If Not .selectedRepaint Is Nothing Then
                    Frm_Rep.showInitialRepaint(.selectedRepaint)
                End If

                For Each item As KeyValuePair(Of String, Single) In .alleVarValues
                    If getOCTProj.alleVarValues.ContainsKey(item.Key) Then
                        getOCTProj.alleVarValues(item.Key) = item.Value
                        Frm_VarTest.addVar(item.Key, item.Value)
                    End If
                Next

            End With
        End If
    End Sub


    Private Sub LoadProjectSli()
        With actProj
            For Each texture In .textures
                Mat_CBTex.Items.Add(texture.filename)
            Next

            Dim i As Integer = 0
            For Each subobjekt In .subobjekte
                Dim newObjekt As New Mesh
                With newObjekt
                    .vertices = actProj.vertices
                    .texCoords = actProj.texCoords
                    .lines = actProj.lines
                    .subObjekte.Add(subobjekt)
                    .id = getOCTProj.alleMeshes.Count
                    .texturen.Add(actProj.textures(i))

                    loadTextures(.texturen, actProj.filename.path)

                    getOCTProj.alleMeshes.Add(newObjekt)
                    'mesh.ObjIds.Add(newObjekt.id)

                    LBMeshes.Items.Add(actProj.filename.name & "_" & i)
                    LBMeshes.SetItemChecked(LBMeshes.Items.Count - 1, True)
                End With
                i += 1
            Next
        End With

        projectReady()
        GlMain.Invalidate()
    End Sub

    Private Sub LoadProjectBus(Projekt_Bus_temp As Proj_Bus)
        Dim tmp As String = ""
        With Projekt_Bus_temp

            PBMain.Value = 0

            TVHelper.Nodes(0).Nodes.Clear()
            For i = 0 To .achsen.Count - 1
                TVHelper.Nodes(0).Nodes.Add("Achse " & i)
            Next

            TVHelper.Nodes(2).Nodes(0).Nodes.Clear()
            For i = 0 To .driver_cam_list.Count - 1

                If .driver_cam_list(i).name <> "" Then
                    TVHelper.Nodes(2).Nodes(0).Nodes.Add(.driver_cam_list(i).name)
                Else
                    If .driver_cam_list(i).selling Then tmp = " (Verkaufsansicht)"
                    If .driver_cam_list(i).schedule Then tmp = " (Fahrplanansicht)"
                    TVHelper.Nodes(2).Nodes(0).Nodes.Add("Fahrer Kamera " & i & tmp)
                    tmp = ""
                End If
            Next

            TVHelper.Nodes(2).Nodes(1).Nodes.Clear()
            selectedDriverCam = .cam_std
            For i = 0 To .pax_cam_list.Count - 1
                If .pax_cam_list(i).name <> "" Then
                    TVHelper.Nodes(2).Nodes(1).Nodes.Add(.pax_cam_list(i).name)
                Else
                    TVHelper.Nodes(2).Nodes(1).Nodes.Add("Passagier Kamera " & i)
                End If
            Next

            TVHelper.Nodes(3).Nodes.Clear()
            If .couple_back Then
                TVHelper.Nodes(3).Nodes.Add("Heck")
            End If

            If .couple_front Then
                TVHelper.Nodes(3).Nodes.Add("Front")
            End If

            Kuppl_DDNextVehicle.Items.Clear()
            Kuppl_DDNextVehicle.Items.Add("")
            For Each file As Filename In My.Computer.FileSystem.GetFiles(.filename.path, FileIO.SearchOption.SearchTopLevelOnly, "*.bus")
                Kuppl_DDNextVehicle.Items.Add(file.name)
            Next

            If Not .couple_back_file Is Nothing Then
                If Not Kuppl_DDNextVehicle.Items.Contains(.couple_back_file.name) Then
                    Kuppl_DDNextVehicle.Items.Add(.couple_back_file.name)
                    Log.Add("Angehängter Fahrzeugteil (" & .couple_back_file.name & ") konnte nicht gefunden werden!", Log.TYPE_ERROR, True)
                End If
            End If


            TVHelper.Nodes(6).Nodes.Clear()
            For i = 0 To .spiegel.Count - 1
                TVHelper.Nodes(6).Nodes.Add("Spiegel      (Reflexion_" & .spiegel(i).index & ".bmp)")
            Next

            loadCabinPrefs(.cabin)

            For i = 0 To TVHelper.Nodes(8).Nodes.Count - 1
                TVHelper.Nodes(8).Nodes(i).Nodes.Clear()
            Next

            For i = 0 To .ticketblöcke.Count - 1
                If .ticketblöcke(i).name <> "" Then
                    TVHelper.Nodes(8).Nodes(1).Nodes.Add(.ticketblöcke(i).name)
                Else
                    TVHelper.Nodes(8).Nodes(1).Nodes.Add("Ticket " & i)
                End If
            Next


            'DDAlleTexturen.Items.Clear()
            If IO.Directory.Exists(Projekt_Bus_temp.filename.path & "\Texture") Then
                For Each file In IO.Directory.GetFiles(Projekt_Bus_temp.filename.path & "\Texture", "*.*", IO.SearchOption.TopDirectoryOnly)
                    Dim tmpname As New Filename(file)
                    If OMSI_ImageFormats.Contains(tmpname.extension) Then
                        If Not DDAlleTexturen.Items.Contains(tmpname.name) Then
                            DDAlleTexturen.Items.Add(tmpname.name)
                        End If
                    End If
                Next
            End If

            loadPathsPrefs(.paths)
            loadModelPrefs(.model)
            If Not .model Is Nothing Then
                showModel(.model.meshes)
                If Importer.stopImport Then Exit Sub
                For Each mesh In .model.meshes
                    For Each anim In mesh.animations
                        If anim.origin_from_mesh Then
                            anim.mesh_center = mesh.center
                            anim.mesh_origin = New Point3D(mesh.origin.X * 90, mesh.origin.Y * 90, mesh.origin.Z * 90)
                        End If
                    Next
                Next

            End If



            VariablenAusOrdnerLaden(.varlists, .filename)


            PBMain.Value = 0
            If actProj.model Is Nothing Then
                Log.Add("Projekt ohne Modell wurde geladen!", Log.TYPE_WARNUNG, True)
            Else
                Log.Add(.model.meshes.Count & " Objekte des Projekts importiert!")
            End If


            HofDateienToolStripMenuItem.Enabled = True
            projectReady()
        End With
    End Sub

    Private Sub loadModelPrefs(model As OMSI_Model)
        If Not model Is Nothing Then
            LBLichter.Items.Clear()
            For i = 0 To model.lichter.Count - 1
                If model.lichter(i).name <> "" Then
                    LBLichter.Items.Add(model.lichter(i).name)
                Else
                    LBLichter.Items.Add("Licht " & i)
                End If
            Next

            TVHelper.Nodes(11).Nodes.Clear()
            For i = 0 To model.spots.Count - 1
                If model.spots(i).name <> "" Then
                    TVHelper.Nodes(11).Nodes.Add(model.spots(i).name)
                Else
                    TVHelper.Nodes(11).Nodes.Add("Spot " & i)
                End If
            Next

            Mat_CBTextTex.Items.Clear()
            Mat_CBTextTex.Items.Add("")
            For Each TextTex In model.TextTexturen
                Mat_CBTextTex.Items.Add(TextTex.name)
            Next

            TVHelper.Nodes(4).Nodes.Clear()
            For i = 0 To model.intLichter.Count - 1
                If model.intLichter(i).name <> "" Then
                    TVHelper.Nodes(4).Nodes.Add(model.intLichter(i).name)
                Else
                    TVHelper.Nodes(4).Nodes.Add("Innen Licht " & i)
                End If
            Next

            TVHelper.Nodes(5).Nodes.Clear()
            For i = 0 To model.rauch.Count - 1
                TVHelper.Nodes(5).Nodes.Add("Rauch " & i)
            Next

            loadIntLichter()

        End If
    End Sub

    Private Sub loadIntLichter()
        With actProj.model
            IntLichterToListBox(Bel_CB0, .intLichter.Count)
            IntLichterToListBox(Bel_CB1, .intLichter.Count)
            IntLichterToListBox(Bel_CB2, .intLichter.Count)
            IntLichterToListBox(Bel_CB3, .intLichter.Count)
        End With
    End Sub

    Private Sub IntLichterToListBox(CB As ComboBox, count As Integer)
        Dim tmpIndex As Integer = CB.SelectedIndex
        CB.Items.Clear()
        For i = -1 To count - 1
            CB.Items.Add(i)
        Next
        CB.SelectedIndex = tmpIndex
    End Sub

    Private Sub showModel(meshes As List(Of OMSI_Mesh))
        getOCTProj.alleMeshes.Clear()
        LBMeshes.Items.Clear()
        Parent_CBParent.Items.Clear()

        Dim ctMesh As Integer = 0
        Dim items_temp As New List(Of String)

        For i As Integer = 0 To meshes.Count - 1
            'If mesh.filename.extension = "o3d" Then
            If Importer.stopImport Then
                resetProj()
                Exit Sub
            End If
            Dim newMesh As OMSI_Mesh = fileimport2(New Filename(meshes(i).filename.name, actProj.filename.path & "\Model"))
            If Not newMesh Is Nothing Then
                items_temp.Add(newMesh.filename.name)
                meshes(i).index = newMesh.index
                meshes(i).ObjIds = newMesh.ObjIds
                meshes(i).center = newMesh.center
                meshes(i).origin = newMesh.origin
                If meshes(i).lodMin <= lodVal And meshes(i).lodMax >= lodVal Then
                    getOCTProj.alleMeshes(getOCTProj.alleMeshes.Count - 1).visible = True
                Else
                    getOCTProj.alleMeshes(getOCTProj.alleMeshes.Count - 1).visible = False
                End If
            End If

            ctMesh += 1
            PBMain.Value = Convert.ToInt16(ctMesh / meshes.Count * 100)
        Next

        For iMeshes As Integer = 0 To meshes.Count - 1
            LBMeshes.Items.Add(meshes(iMeshes).filename.name)
            LBMeshes.SetItemChecked(iMeshes, True)
        Next

        'Dim newMeshesStart As Integer = LBMeshes.Items.Count
        'LBMeshes.Items.AddRange(items_temp.ToArray)
        'For iMeshes As Integer = newMeshesStart To LBMeshes.Items.Count - 1
        '    LBMeshes.SetItemChecked(iMeshes, True)
        'Next

        Parent_CBParent.Items.AddRange(items_temp.ToArray)
        GlMain.Invalidate()
        TCObjektePMeshes.Text = "Meshes (" & LBMeshes.Items.Count & ")"
    End Sub

    Public Sub loadNewModel(model As OMSI_Model)
        actProj.model = model

        loadModelPrefs(model)
        showModel(model.meshes)
    End Sub

    Public Sub loadPathsPrefs(paths As OMSI_Paths)
        LBPfade.Items.Clear()
        Pfade_DDNachste_0.Items.Clear()
        If Not paths Is Nothing Then
            For i = 0 To paths.pathPoints.Count - 1
                If Not paths.pathPoints(i).Tag Is Nothing Then
                    LBPfade.Items.Add(paths.pathPoints(i).Tag)
                    Pfade_DDNachste_0.Items.Add(paths.pathPoints(i).Tag)
                Else
                    LBPfade.Items.Add("Punkt_" & i)
                    Pfade_DDNachste_0.Items.Add("Punkt_" & i)
                End If
            Next
        End If
        doorsRecalc()
    End Sub

    Public Sub loadCabinPrefs(cabin As OMSI_Cabin)
        TVHelper.Nodes(7).Nodes.Clear()
        If Not cabin Is Nothing Then
            For i = 0 To cabin.passPos.Count - 1
                TVHelper.Nodes(7).Nodes.Add("Platz " & i)
            Next
        End If
        doorsRecalc()
    End Sub

    Private Sub doorsRecalc()
        If Not actProj.cabin Is Nothing Then
            If Not actProj.paths Is Nothing Then

                Dim links As New List(Of Point)
                Dim directions As New List(Of Boolean)

                For Each door In actProj.cabin.doors
                    For Each link In actProj.paths.pathLinks
                        If door.pathindex = link.X Then
                            links.Add(link)
                            directions.Add(door.direction)
                        End If
                        If door.pathindex = link.y Then
                            links.Add(New Point(link.y, link.x))
                            directions.Add(door.direction)
                        End If
                    Next
                Next
                For Each link In actProj.paths.pathLinks
                    If link.x = actProj.cabin.linkToNextVeh Then
                        links.Add(link)
                        directions.Add(False)
                    End If

                    If link.Y = actProj.cabin.linkToNextVeh Then
                        links.Add(New Point(link.y, link.x))
                        directions.Add(False)
                    End If

                    If link.x = actProj.cabin.linkToPrevVeh Then
                        links.Add(link)
                        directions.Add(True)
                    End If

                    If link.Y = actProj.cabin.linkToPrevVeh Then
                        links.Add(New Point(link.y, link.x))
                        directions.Add(True)
                    End If
                Next

                actProj.paths.calcArrows(links, directions)
            End If
        End If
    End Sub

    Public Sub VariablenAusOrdnerLaden(varlists As List(Of String), filename As Filename)

        getOCTProj.alleVarValues.Clear()

        Select Case getProjType()
            Case Proj_Bus.TYPE
                getOCTProj.addVarValues(OMSI_BUS_VARS.ToList, 0)
            Case Proj_Sco.TYPE
                getOCTProj.addVarValues(OMSI_SCO_VARS.ToList, 0)
        End Select

        getOCTProj.addVarValues(OMSI_SYS_VARS.ToList, 0)

        For Each file In varlists
            Dim lines() As String = Split(My.Computer.FileSystem.ReadAllText(filename.path & "\" & file), vbCrLf)
            For Each line In lines
                If Trim(line) <> "" Then                         'Leerzeilen überspringen
                    If Not Trim(line).Substring(0, 1) = "'" Then 'auskommentierte überspringen
                        getOCTProj.addVarValues(Trim(line), 0)
                    End If
                End If
            Next
        Next

        For i As Integer = 0 To getOCTProj.alleVarValues.Count
            Dim var As String = getOCTProj.alleVarValues.Keys(i)
            Dim val As Single = getOCTProj.alleVarValues.Values(i)
            RecalcVis(var, val)
            RecalcAlpha(var, val)
        Next
    End Sub

    Private Sub projectReady()
        SpeichernToolStripMenuItem.Enabled = True
        NurProjektbusovhscoToolStripMenuItem.Enabled = True

        If getProjType() = Proj_Bus.TYPE Or getProjType() = Proj_Ovh.TYPE Then
            NurModelToolStripMenuItem.Enabled = True
            NurPathsToolStripMenuItem.Enabled = True
            NurCabinToolStripMenuItem.Enabled = True
        End If

        SSLBStatus.Text = "Projekt geladen"
        ModelLoaded = True
    End Sub

    Private Sub BeendenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BeendenToolStripMenuItem.Click
        If exitApplication() Then Me.Close()
    End Sub

    Private Sub ProjektSchließenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProjektSchließenToolStripMenuItem.Click
        If OpenProjects.Count = 1 Then
            OpenProjects(0) = New OCTProjekt
            actProj = OpenProjects(0).actProj
            clearProject()
        End If
    End Sub

    Public Sub EigenschaftenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EigenschaftenToolStripMenuItem.Click
        Select Case getProjType()
            Case Proj_Emt.TYPE
                MsgBox("Bitte erst ein Projekt öffnen oder erstellen!")
            Case Proj_Bus.TYPE
                Frm_Eig_Bus.Projekt_Bus = actProj
                Frm_Eig_Bus.Show()
            Case Proj_Sco.TYPE
                Frm_Eig_Sco.Projekt_Sco = actProj
                Frm_Eig_Sco.Show()
            Case Proj_Sli.TYPE
                Frm_Eig_Sli.Projekt_Sli = actProj
                Frm_Eig_Sli.Show()
            Case Else
                MsgBox("Für diesen Projekttyp stehen keine Eigenschaften zur Verfügung!")
        End Select
    End Sub

    Private Sub WireframeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WireframeToolStripMenuItem.Click
        sender.checked = Not sender.checked
        savePositions()
        GlMain.Invalidate()
    End Sub

    Private Sub GitterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GitterToolStripMenuItem.Click
        sender.checked = Not sender.checked
        savePositions()
        GlMain.Invalidate()
    End Sub

    Private Sub ObjekteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ObjekteToolStripMenuItem.Click
        PanelObjekte.Visible = Not PanelObjekte.Visible
        savePositions()
    End Sub

    Private Sub TextureToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TextureToolStripMenuItem.Click
        PanelTexture.Visible = Not PanelTexture.Visible
        savePositions()
    End Sub

    Private Sub EigenschaftenFensterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EigenschaftenFensterToolStripMenuItem.Click
        PanelEigenschaften.Visible = Not PanelEigenschaften.Visible
        savePositions()
    End Sub


    Private Sub TimelineLogFensterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TimelineLogFensterToolStripMenuItem.Click
        PanelTimeline.Visible = Not PanelTimeline.Visible
        savePositions()
    End Sub

    Private Sub TCTimeline_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TCTimeline.SelectedIndexChanged
        savePositions()
    End Sub

    Private Sub SoundToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SoundToolStripMenuItem.Click
        If getProjType() = Proj_Bus.TYPE Or getProjType() = Proj_Ovh.TYPE Then
            Frm_Sounds.Show()
        Else
            If getProjType() = Proj_Emt.TYPE Then
                MsgNoProj()
            Else
                MsgBox("Für diesen Projekttyp stehen keine Eigenschaften zur Verfügung!")
            End If

        End If
    End Sub

    Private Sub ImportierenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportierenToolStripMenuItem.Click
        fileImport()
        mainStrg = False
    End Sub

    Private Sub ExportiernToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportiernToolStripMenuItem.Click
        If LBMeshes.SelectedItems.Count > 0 Then
            Frm_Export.ShowDialog()

            Select Case Frm_Export.choice
                Case Frm_Export.CHOICE_EIG
                    settexport()
                Case Frm_Export.CHOICE_DATA
                    fileExport()
            End Select
        Else
            MsgBox("Kein Mesh ausgewählt!")
        End If
        mainStrg = False
    End Sub

    Private Sub ForumToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ForumToolStripMenuItem.Click
        MsgBox("Version " & My.Application.Info.Version.ToString, 0, My.Application.Info.Title)
    End Sub

    Private Sub RechnerToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Frm_Math.Show()
    End Sub

    Private Sub NeuToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NeuToolStripMenuItem.Click
        Frm_Neu.Show()
    End Sub

    Private Sub NeuLadenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NeuLadenToolStripMenuItem.Click
        If Not getProjType() = Proj_Emt.TYPE Then
            If Not actProj.filename Is Nothing Then ProjÖffnen(actProj.filename.ToString)
        Else
            If Settings.LetzteProjekte.Count > 0 Then
                ProjÖffnen(Settings.LetzteProjekte.Last)
            End If
        End If
    End Sub

    Private Sub AllesToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AllesToolStripMenuItem1.Click
        save()
    End Sub

    Private Sub NurProjektbusovhscoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NurProjektbusovhscoToolStripMenuItem.Click
        actProj.save(True)
        SSLBStatus.Text = "Projektdatei gespeichert"
    End Sub

    Private Sub NurToolUmgebungocdbToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NurToolUmgebungocdbToolStripMenuItem.Click
        If Not getProjType() = Proj_Emt.TYPE Then
            actProj.ProjDataBase.Save()
            SSLBStatus.Text = "Umgebung gespeichert"
        End If
    End Sub

    Private Sub NurModelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NurModelToolStripMenuItem.Click
        actProj.model.save()
        SSLBStatus.Text = "Model-Datei gespeichert"
    End Sub

    Private Sub NurCabinToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NurCabinToolStripMenuItem.Click
        If getProjType() = Proj_Bus.TYPE Or getProjType() = Proj_Ovh.TYPE Then
            actProj.cabin.save()
            SSLBStatus.Text = "Cabin-Datei gespeichert"
        End If
    End Sub

    Private Sub NurPathsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NurPathsToolStripMenuItem.Click
        If getProjType() = Proj_Bus.TYPE Or getProjType() = Proj_Ovh.TYPE Then
            actProj.paths.save()
            SSLBStatus.Text = "Path-Datei gespeichert"
        End If
    End Sub

    Private Sub SpeichernUnterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SpeichernUnterToolStripMenuItem.Click
        Frm_Save.ShowDialog()
        Me.Text = actProj.filename.ToString & " - " & My.Application.Info.Title
        SSLBStatus.Text = "Speichern abgeschlossen"
    End Sub

    Private Sub EinstellungenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EinstellungenToolStripMenuItem.Click
        Frm_Einst.Show()
    End Sub


    '### View Modes ###'

    Private Sub drawVieSelection()
        AllesToolStripMenuItem.Checked = False
        OMSIAußenToolStripMenuItem.Checked = False
        OMSIInnenToolStripMenuItem.Checked = False
        OMSIAIBusToolStripMenuItem.Checked = False

        Select Case viewMode
            Case viewModes.ALLES
                AllesToolStripMenuItem.Checked = True
            Case viewModes.AUSSEN
                OMSIAußenToolStripMenuItem.Checked = True
            Case viewModes.INNEN
                OMSIInnenToolStripMenuItem.Checked = True
            Case viewModes.AI
                OMSIAIBusToolStripMenuItem.Checked = True
        End Select
    End Sub

    Private Sub AllesToolStripMenuItem_Click(sender As Object, e As EventArgs)
        viewMode = viewModes.ALLES
        drawVieSelection()
    End Sub

    Private Sub OMSIInnenToolStripMenuItem_Click(sender As Object, e As EventArgs)
        viewMode = viewModes.INNEN
        drawVieSelection()
    End Sub

    Private Sub OMSIAußenToolStripMenuItem_Click(sender As Object, e As EventArgs)
        viewMode = viewModes.AUSSEN
        drawVieSelection()
    End Sub

    Private Sub OMSIAIBusToolStripMenuItem_Click(sender As Object, e As EventArgs)
        viewMode = viewModes.AI
        drawVieSelection()
    End Sub

    Private Sub SuchenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SuchenToolStripMenuItem.Click
        Frm_FindMesh.Show(Me)
        mainStrg = False
    End Sub

    Private Sub FahrrersichtToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FahrrersichtToolStripMenuItem.Click
        If getProjType() = Proj_Bus.TYPE Or getProjType() = Proj_Ovh.TYPE Then
            If actProj.driver_cam_list.Count > 0 Then
                viewPoint = 1
                GlMain.Invalidate()
            End If
        End If
    End Sub

    Private Sub PassagiersichtToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PassagiersichtToolStripMenuItem.Click
        If getProjType() = Proj_Bus.TYPE Or getProjType() = Proj_Ovh.TYPE Then
            If actProj.pax_cam_list.Count > 0 Then
                viewPoint = 2
                GlMain.Invalidate()
            End If
        End If
    End Sub

    Private Sub AußenansichtToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AußenansichtToolStripMenuItem.Click
        viewPoint = 3
        GlMain.Invalidate()
    End Sub

    Private Sub FreieKameraToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FreieKameraToolStripMenuItem.Click
        viewPoint = 4
        GlMain.Invalidate()
    End Sub

    Private Sub LODObjektToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LODObjektToolStripMenuItem.Click
        Frm_LOD.Show()
    End Sub

    Private Sub EntfernenToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles EntfernenToolStripMenuItem2.Click
        Select Case TCObjekte.SelectedIndex
            Case 0
                CMSObjekteEntfernen_Click(Me, Nothing)
            Case 1
                EntfernenToolStripMenuItem_Click(Me, Nothing)
            Case 2
                EntfernenToolStripMenuItem1_Click(Me, Nothing)
            Case 3
                EntfernenToolStripMenuItem3_Click(Me, Nothing)
        End Select
    End Sub


    Private Sub PfadeInOriginalbreiteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PfadeInOriginalbreiteToolStripMenuItem.Click
        sender.checked = Not sender.checked
        Settings.PfadeOrigBreite = sender.checked
        Settings.Save()
    End Sub

    Private Sub LogfileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogfileToolStripMenuItem.Click
        Shell("C:\WINDOWS\Notepad.exe " & Application.StartupPath & "\" & Log.logfile, 1)
        mainStrg = False
    End Sub


    Private Sub NeuesRepoKlonenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NeuesRepoKlonenToolStripMenuItem.Click
        Git.Connect(InputBox("Repository URL:"))
    End Sub

    Private Sub CommitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CommitToolStripMenuItem.Click
        Dim message As String = InputBox("Kommentar:")
        If message <> "" Then Git.Commit(message)
    End Sub

    Private Sub PullToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PullToolStripMenuItem.Click
        Git.Pull()
    End Sub

    Private Sub PushToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PushToolStripMenuItem.Click
        Git.Push()
    End Sub

    Private Sub SyncToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SyncToolStripMenuItem.Click
        Git.Sync()
    End Sub

    Private Sub NeuesRepositoryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NeuesRepositoryToolStripMenuItem.Click
        If actProj.filename <> "" Then
            Git.NewRepoAt(actProj.filename.Path)
        Else
            Log.Add("Es kann kein neues Repository erstellt werden. Bitte erst ein Projekt öffnen oder erstellen")
        End If
    End Sub

    Private Sub UnGitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UnGitToolStripMenuItem.Click
        If MsgBox("Dieses Projekt aus der Nachverfolgung mit Git entfernen?" & vbCrLf & "(alle Dateien und Änderungen bleiben erhalten)", vbYesNo) = vbYes Then
            Git.delete()
        End If
    End Sub

    Private Sub EinstellungenToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles OptionenToolStripMenuItem1.Click
        Frm_Git.ShowDialog()
    End Sub

    Private Sub ReadmetxtToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReadmetxtToolStripMenuItem.Click
        If Not actProj Is Nothing Then
            Dim readmeFile As String = actProj.filename.path & "\readme.txt"
            If Not System.IO.File.Exists(readmeFile) Then
                Dim fw As New FileWriter(New Filename(readmeFile))
                fw.Write()
            End If
            Shell("C:\WINDOWS\Notepad.exe " & readmeFile, 1)
        Else
            MsgNoProj()
        End If
    End Sub

    Private Sub ToDoListToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToDoListToolStripMenuItem.Click
        If actProj.ProjDataBase Is Nothing Then
            actProj.ProjDataBase = New DataBase(actProj.filename)
        End If
        Frm_ToDo.Show()
    End Sub

    Private Sub RechnerToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles RechnerToolStripMenuItem.Click
        Frm_Math.Show()
    End Sub

    Private Sub ProjektordnerÖffnenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProjektordnerÖffnenToolStripMenuItem.Click
        If actProj.filename.path <> "" Then
            Process.Start(actProj.filename.path)
        Else
            MsgNoProj()
        End If
        mainStrg = False
    End Sub

    Private Sub VarlistsToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles VarlistsToolStripMenuItem.Click
        If getProjType() = Proj_Bus.TYPE Or getProjType() = Proj_Ovh.TYPE Or getProjType() = Proj_Sco.TYPE Then
            Frm_Listen.LoadFilled(actProj, "Varlists", actProj.filename.path, "txt")
        End If
    End Sub

    Private Sub VarnamelistToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StringvarlistToolStripMenuItem.Click
        If getProjType() = Proj_Bus.TYPE Or getProjType() = Proj_Ovh.TYPE Or getProjType() = Proj_Sco.TYPE Then
            Frm_Listen.LoadFilled(actProj, "Stringvarlists", actProj.filename.path, "txt")
        End If
    End Sub

    Private Sub ScriptsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ScriptsToolStripMenuItem.Click
        If getProjType() = Proj_Bus.TYPE Or getProjType() = Proj_Ovh.TYPE Or getProjType() = Proj_Sco.TYPE Then
            Frm_Listen.LoadFilled(actProj, "Scripts", actProj.filename.path, "osc")
        End If
    End Sub

    Private Sub ConstfilesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConstfilesToolStripMenuItem.Click
        If getProjType() = Proj_Bus.TYPE Or getProjType() = Proj_Ovh.TYPE Or getProjType() = Proj_Sco.TYPE Then
            Frm_Listen.LoadFilled(actProj, "Constfiles", actProj.filename.path, "txt")
        End If
    End Sub

    Private Sub ScriptToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ScriptToolStripMenuItem.Click
        If getProjType() = Proj_Bus.TYPE Or getProjType() = Proj_Sco.TYPE Or getProjType() = Proj_Ovh.TYPE Then
            If Not actProj.varlists Is Nothing Then VarlistsToolStripMenuItem.Text = "Varlists (" & actProj.varlists.Count & ")"
            If Not actProj.stringvarlists Is Nothing Then StringvarlistToolStripMenuItem.Text = "Stringvarlists (" & actProj.stringvarlists.Count & ")"
            If Not actProj.scripts Is Nothing Then ScriptsToolStripMenuItem.Text = "Scripts (" & actProj.scripts.Count & ")"
            If Not actProj.constfiles Is Nothing Then ConstfilesToolStripMenuItem.Text = "Constfiles (" & actProj.constfiles.Count & ")"
        End If
    End Sub

    Private Sub VariablenTestToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VariablenTestToolStripMenuItem.Click
        If getOCTProj.alleVarValues.Count > 0 Then
            Frm_VarTest.Show()
        Else
            MsgBox("Bitte zunächst Varlisten importieren!", , "Warnung!")
        End If
    End Sub

    Private Sub SitzplatzToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SitzplatzToolStripMenuItem.Click
        If getProjType() = Proj_Bus.TYPE Then

            Dim cabincount As Integer = 0
            If actProj.cabin Is Nothing Then
                actProj.cabin = New OMSI_Cabin
            Else
                cabincount = actProj.cabin.passPos.Count

            End If
        End If
    End Sub

    Private Sub PfadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PfadToolStripMenuItem.Click
        If getProjType() = Proj_Bus.TYPE Then

            Dim pathcount As Integer = 0
            If actProj.paths Is Nothing Then
                actProj.paths = New OMSI_Paths
            Else
                pathcount = actProj.paths.pathPoints.Count
            End If

            Dim newName As String = InputBox("Pfadpunkt benennen:", "Neuer Pfadpunkt", "Punkt_" & pathcount)

            If newName = "" Then
                Exit Sub
            End If

            actProj.paths.pathPoints.Add(New Point3D)
            actProj.paths.recalc()

            LBPfade.Items.Add(newName)
            Pfade_DDNachste_0.Items.Add(newName)
        End If
    End Sub

    Public Sub RepaintToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RepaintToolStripMenuItem.Click
        Frm_Rep.Show()
    End Sub

    Private Sub NeuToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles NeuToolStripMenuItem2.Click
        LichtToolStripMenuItem_Click(sender, e)
        mainStrg = False
    End Sub

    Private Sub LichtToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LichtToolStripMenuItem.Click
        If getProjType() = Proj_Bus.TYPE Or getProjType() = Proj_Sco.TYPE Then
            Dim newName As String = InputBox("Licht benennen:", "Neues Licht", "Licht_" & actProj.model.lichter.count)

            If newName = "" Then
                Exit Sub
            End If

            Dim newLicht As New OMSI_Licht
            newLicht.name = newName
            newLicht.size = 0.2

            If getSelectedMesh() Is Nothing Then
                If LBMeshes.Items.Count > 0 Then
                    newLicht.parent = LBMeshes.Items(0).ToString
                Else
                    MsgBox("Es kann kein Licht angelegt werden wenn kein Mesh geladen ist!")
                    Log.Add("Licht anlegen ohne vorhandenes Mesh nicht möglich: Lichter brauchen immer ein Mesh als Parent!", Log.TYPE_WARNUNG)
                    Exit Sub
                End If

            Else
                If Not getSelectedMesh() Is Nothing Then
                    newLicht.parent = getSelectedMesh.filename.name
                Else
                    newLicht.parent = actProj.model.meshes(0).filename.name
                End If
            End If

            actProj.model.lichter.Add(newLicht)
            LBLichter.Items.Add(newLicht.name)
            LBLichter.SelectedIndex = LBLichter.Items.Count - 1

        Else
            MsgNoProj()
        End If
    End Sub

    Private Sub SpotToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SpotToolStripMenuItem.Click
        If getProjType() = Proj_Bus.TYPE Or getProjType() = Proj_Sco.TYPE Then
            Dim newName As String = InputBox("Spot benennen: (leer = laufende Nummer)", "Neuer Spot", "Spot_" & actProj.model.spots.count)

            If newName = "" Then
                Exit Sub
            End If

            Dim newSpot As New OMSI_Spot
            newSpot.name = newName
            newSpot.richtung = New Point3D(0, 1, 0)
            newSpot.range = 50
            newSpot.outerCone = 70
            newSpot.innerCone = 30

            actProj.model.spots.Add(newSpot)
            TVHelper.Nodes(11).Nodes.Add(newSpot.name)
            TVHelper.Nodes(11).Expand()

        Else
            MsgNoProj()
        End If
    End Sub

    Private Sub FontToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Frm_Fonts.Show()
    End Sub



    'Dartsellung
    '###########

    Private Sub savePositions()

        Settings.PObjekteL = PanelObjekte.Location
        Settings.PObjekteS = PanelObjekte.Size
        Settings.PObjekteV = PanelObjekte.Visible

        Settings.PTextureL = PanelTexture.Location
        Settings.PTextureS = PanelTexture.Size
        Settings.PTextureV = PanelTexture.Visible

        Settings.PEigenschaftenL = PanelEigenschaften.Location
        Settings.PEigenschaftenS = PanelEigenschaften.Size
        Settings.PEigenschaftenV = PanelEigenschaften.Visible

        Settings.PTimelineL = PanelTimeline.Location
        Settings.PTimelineS = PanelTimeline.Size
        Settings.PTimelineV = PanelTimeline.Visible
        Settings.PTimelineSelTab = TCTimeline.SelectedIndex

        Settings.WireframeV = WireframeToolStripMenuItem.Checked
        Settings.GitterV = GitterToolStripMenuItem.Checked
        ObjekteToolStripMenuItem.Checked = PanelObjekte.Visible
        TextureToolStripMenuItem.Checked = PanelTexture.Visible
        TimelineLogFensterToolStripMenuItem.Checked = PanelTimeline.Visible
        EigenschaftenFensterToolStripMenuItem.Checked = PanelEigenschaften.Visible

        Settings.Save()
    End Sub

    Public Sub loadPositions()
        checkForStdPos()

        Dim CaptionColor As Color = Color.White
        Dim colorMidVal As Double = Settings.EditorColor.R
        colorMidVal += Settings.EditorColor.G
        colorMidVal += Settings.EditorColor.B
        colorMidVal = colorMidVal / 3
        If colorMidVal > 128 Then
            CaptionColor = Color.Black
        End If

        PanelObjekte.Location = Settings.PObjekteL
        PanelObjekte.Size = Settings.PObjekteS
        BTObjekteResize.Left = Settings.PObjekteS.X - 5
        BTObjekteResize.Top = Settings.PObjekteS.Y - 5
        PanelObjekte.Visible = Settings.PObjekteV
        PanelObjekte.BackColor = Settings.EditorColor

        PanelTexture.Location = Settings.PTextureL
        PanelTexture.Size = Settings.PTextureS
        PanelTexture.Visible = Settings.PTextureV
        PanelTexture.BackColor = Settings.EditorColor
        LBPanelTexture.ForeColor = CaptionColor
        BTPanelTextureFill.BackColor = Settings.EditorColor

        PanelEigenschaften.Location = Settings.PEigenschaftenL
        PanelEigenschaften.Size = Settings.PEigenschaftenS
        PanelEigenschaften.Visible = Settings.PEigenschaftenV
        BTEigenschafteResize.Top = Settings.PEigenschaftenS.Y - 3
        PanelEigenschaften1.Height = Settings.PEigenschaftenS.Y - 28
        PanelEigenschaften.BackColor = Settings.EditorColor
        LBEingenschaften.ForeColor = CaptionColor

        WireframeToolStripMenuItem.Checked = Settings.WireframeV
        GitterToolStripMenuItem.Checked = Settings.GitterV
        ObjekteToolStripMenuItem.Checked = PanelObjekte.Visible
        TextureToolStripMenuItem.Checked = PanelTexture.Visible
        TimelineLogFensterToolStripMenuItem.Checked = PanelTimeline.Visible
        EigenschaftenFensterToolStripMenuItem.Checked = PanelEigenschaften.Visible

        PfadeInOriginalbreiteToolStripMenuItem.Checked = Settings.PfadeOrigBreite

        PanelTimeline.Location = Settings.PTimelineL
        PanelTimeline.Size = Settings.PTimelineS
        PanelTimeline.Visible = Settings.PTimelineV
        TCTimeline.SelectedIndex = Settings.PTimelineSelTab
        PanelTimeline.BackColor = Settings.EditorColor

        checkPanelPosition(PanelEigenschaften)
        checkPanelPosition(PanelTexture)
        checkPanelPosition(PanelObjekte)
        checkPanelPosition(PanelTimeline)

    End Sub

    Private Sub checkForStdPos()
        If Settings.PEigenschaftenV Then
            If Settings.PEigenschaftenL.X = 410 Then
                Settings.PEigenschaftenL.X = Width - PanelEigenschaften.Width - 3
            End If
        End If

        If Settings.PTextureV Then
            If Settings.PTextureL.Y = 338 Then
                Settings.PTextureL.Y = Height - PanelTexture.Height - 3
            End If
        End If
        Settings.Save()
    End Sub


    Private Sub checkPanelPosition(e As Panel)
        If e.Visible = False Then Exit Sub
        If e.Top < 27 Then e.Top = 27
        If e.Left < 5 Then e.Left = 5
        If e.Top + e.Height > PanelMain.Height Then e.Top = PanelMain.Height - e.Height - 5
        If e.Left + e.Width > PanelMain.Width Then e.Left = PanelMain.Width - e.Width - 5

        panelCollision(e, PanelTexture)
        panelCollision(e, PanelObjekte)
        panelCollision(e, PanelEigenschaften)
        panelCollision(e, PanelTimeline)
    End Sub

    Private Sub panelCollision(e As Panel, o As Panel)
        If Not e Is o Then
            If o.Visible Then
                If e.Top <= o.Top + o.Height And e.Top + e.Height >= o.Top Then
                    If o.Left + o.Width >= e.Left And o.Left <= e.Left Then
                        e.Left = o.Left + o.Width + 3
                    End If
                    If e.Left <= o.Left And e.Left + e.Width >= o.Left Then
                        e.Left = o.Left - e.Width - 3
                    End If
                    If e.Left + e.Width > PanelMain.Width Then
                        e.Left = PanelMain.Width - e.Width - 5
                        o.Left = e.Left - o.Width - 3
                    End If
                    If e.Top + e.Height > PanelMain.Height Then
                        e.Top = PanelMain.Height - e.Height - 5
                        o.Top = e.Top - o.Height - 3
                    End If
                End If
            End If
        End If
    End Sub

    'Panel Objekte ##########

    Private Sub PanelObjekte_MouseMove(sender As Object, e As MouseEventArgs) Handles PanelObjekte.MouseMove
        If movePanelObjekte Then
            Dim ctl As Control = CType(sender, Control)
            ctl.Location = PointToClient(Cursor.Position - New Point(ctl.Width \ 2, 30))
        End If
    End Sub

    Private Sub PanelObjekte_MouseDown(sender As Object, e As MouseEventArgs) Handles PanelObjekte.MouseDown
        movePanelObjekte = True
    End Sub

    Private Sub PanelObjekte_MouseUp(sender As Object, e As MouseEventArgs) Handles PanelObjekte.MouseUp
        checkPanelPosition(PanelObjekte)
        savePositions()
        movePanelObjekte = False
    End Sub

    Private Sub LBPanelObjekte_MouseDown(sender As Object, e As MouseEventArgs)
        movePanelObjekte = True
    End Sub

    Private Sub LBPanelObjekte_MouseUp(sender As Object, e As MouseEventArgs)
        checkPanelPosition(PanelObjekte)
        savePositions()
        movePanelObjekte = False
    End Sub

    Private Sub LBPanelObjekte_MouseMove(sender As Object, e As MouseEventArgs)
        If movePanelObjekte Then
            Dim ctl As Control = CType(PanelObjekte, Control)
            ctl.Location = PointToClient(Cursor.Position - New Point(ctl.Width \ 2, 30))
        End If
    End Sub

    Private Sub BTPanelObjekteClose_Click(sender As Object, e As EventArgs) Handles BTPanelObjekteClose.Click
        PanelObjekte.Visible = False
        savePositions()
    End Sub

    Private Sub Frm_Main_SizeChanged(sender As Object, e As EventArgs) Handles MyBase.SizeChanged
        If GBAllgemein.Top > 10 Then
            Log.Add("Eigenschaften-Panel: Item-Position größer 10!", Log.TYPE_ERROR, True)
            Me.Close()
            Exit Sub
        End If

        checkPanelPosition(PanelObjekte)
    End Sub

    Private Sub PanelObjekte_SizeChanged(sender As Object, e As EventArgs) Handles PanelObjekte.SizeChanged
        LBMeshes.Height = PanelObjekte.Height - 23
        LBMeshes.Width = PanelObjekte.Width - 2
        BTPanelObjekteClose.Left = PanelObjekte.Width - 22
    End Sub

    Private Sub CMSObjekte_Opening(sender As Object, e As CancelEventArgs) Handles CMSMeshes.Opening
        If LBMeshes.Items.Count = 0 Then
            CMSObjekteNeuladen.Enabled = False
            CMSObjekteExport.Enabled = False
            CMSObjekteEntfernen.Enabled = False
            CMSObjekteBearbeiten.Enabled = False
        Else
            CMSObjekteNeuladen.Enabled = True
            CMSObjekteExport.Enabled = True
            CMSObjekteEntfernen.Enabled = True
            CMSObjekteBearbeiten.Enabled = True
        End If
    End Sub

    Private Sub CMSObjekteImport_Click(sender As Object, e As EventArgs) Handles CMSObjekteImport.Click
        fileImport()
    End Sub

    Private Sub ErsetzenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ErsetzenToolStripMenuItem.Click
        MsgBox("Funktion nicht verfügbar!")
    End Sub

    Private Sub CMSObjekteExport_Click(sender As Object, e As EventArgs) Handles CMSObjekteExport.Click
        fileExport()
    End Sub

    Private Sub CMSObjekteEntfernen_Click(sender As Object, e As EventArgs) Handles CMSObjekteEntfernen.Click
        For Each objekt In getOCTProj.alleMeshes
            For Each mesh In actProj.model.meshes
                If mesh.filename.name = LBMeshes.SelectedItem Then
                    If mesh.ObjIds.Contains(objekt.id) Then
                        getOCTProj.alleMeshes.Remove(objekt)
                        LBMeshes.Items.Remove(LBMeshes.SelectedItem)
                        GlMain.Invalidate()
                        actProj.model.meshes.Remove(mesh)

                        If getOCTProj.alleMeshes.Count > 0 Then
                            TCObjektePMeshes.Text = "Meshes (" & getOCTProj.alleMeshes.Count & ")"
                        Else
                            TCObjektePMeshes.Text = "Meshes"
                        End If

                        Exit Sub
                    End If
                End If
            Next
        Next
    End Sub

    Private Sub DateiLöschenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DateiLöschenToolStripMenuItem.Click
        If MsgBox("Soll die Datei unwiderruflich gelöscht werden?", vbYesNo) = vbYes Then
            Dim meshname As String = ""
            For Each objekt In getOCTProj.alleMeshes
                For Each mesh In actProj.model.meshes
                    If mesh.filename.name = LBMeshes.SelectedItem Then
                        meshname = mesh.filename.ToString
                        Exit For
                    End If
                Next
            Next
            CMSObjekteEntfernen_Click(sender, e)
            If meshname <> "" And IO.File.Exists(meshname) Then
                IO.File.Delete(meshname)
            End If
        End If
    End Sub

    Private Sub BTObjekteResize_MouseDown(sender As Object, e As MouseEventArgs) Handles BTObjekteResize.MouseDown
        resizePanelObjekte = True
        BTObjekteResize.Size = New Point(0, 0)
        PanelObjecte_size = New Point(PanelObjekte.Width, PanelObjekte.Height)
    End Sub

    Private Sub BTObjekteResize_MouseUp(sender As Object, e As MouseEventArgs) Handles BTObjekteResize.MouseUp
        resizePanelObjekte = False
        BTObjekteResize.Location = New Point(PanelObjekte.Width - 6, PanelObjekte.Height - 6)
        BTObjekteResize.Size = New Point(5, 5)
        PanelObjecte_size = Nothing
        savePositions()
    End Sub

    Private Sub BTObjekteResize_MouseMove(sender As Object, e As MouseEventArgs) Handles BTObjekteResize.MouseMove
        Dim x, y As Integer
        If resizePanelObjekte Then
            If e.X + PanelObjecte_size.X < 175 Then x = 175 Else x = e.X + PanelObjecte_size.X
            If e.Y + PanelObjecte_size.Y < 175 Then y = 175 Else y = e.Y + PanelObjecte_size.Y
            PanelObjekte.Size = New Point(x, y)
        End If
    End Sub

    Private Sub PanelObjekte_Resize(sender As Object, e As EventArgs) Handles PanelObjekte.Resize
        TCObjekte.Size = New Point(PanelObjekte.Width - 6, PanelObjekte.Height - 9)
    End Sub
    Private Sub ZUpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ZUpToolStripMenuItem.Click
        For Each mesh In actProj.model.meshes
            For Each Objekt In getOCTProj.alleMeshes
                If mesh.ObjIds.Contains(Objekt.id) Then
                    Modifier.flipZ(Objekt)
                End If
            Next
        Next
        GlMain.Invalidate()
    End Sub

    Private Sub LeftRightHandetToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LeftRightHandedToolStripMenuItem.Click
        For Each mesh In actProj.model.meshes
            For Each Objekt In getOCTProj.alleMeshes
                If mesh.ObjIds.Contains(Objekt.id) Then
                    Modifier.leftRightHanded(Objekt)
                End If
            Next
        Next
        GlMain.Invalidate()
    End Sub

    Private Sub UmbenennenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UmbenennenToolStripMenuItem.Click
        Dim altName As String = LBMeshes.SelectedItem.ToString
        Dim newName As String = InputBox("Neuen Namen für die Datei """ & altName & """ eingeben.", "Meshes umbenennen", altName)

        If newName <> "" Then
            For Each node In LBMeshes.Items
                If node.text = altName Then
                    MsgBox("Dieser Name existiert bereits!")
                    Exit Sub
                End If
            Next

            LBMeshes.SelectedItem = newName
        End If
    End Sub

    '####  Spiegel  ###

    Private Function getSelectedSpiegel() As OMSI_ReflexCamera
        If getProjType() = Proj_Bus.TYPE Then
            If TVHelper.SelectedNode.FullPath.Contains("\") Then
                If TVHelper.SelectedNode.FullPath.Split("\")(0) = TVHelper.Nodes(6).Text Then
                    If TVHelper.SelectedNode.Index > -1 Then
                        Return actProj.spiegel(TVHelper.SelectedNode.Index)
                    End If
                End If
            End If
        End If
        Return Nothing
    End Function


    '####  Achse  ####

    Private Function getSelectedAchse() As OMSI_Achse
        If getProjType() = Proj_Bus.TYPE Or getProjType() = Proj_Ovh.TYPE Then
            If TVHelper.SelectedNode.FullPath.Contains("\") Then
                If TVHelper.SelectedNode.FullPath.Split("\")(0) = TVHelper.Nodes(0).Text Then
                    If TVHelper.SelectedNode.Index > -1 Then
                        Return actProj.achsen(TVHelper.SelectedNode.Index)
                    End If
                End If
            End If
        End If
        Return Nothing
    End Function

    Private Sub AchseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AchseToolStripMenuItem.Click
        If getProjType() = Proj_Bus.TYPE Or getProjType() = Proj_Ovh.TYPE Then
            Dim newAchse As New OMSI_Achse
            With newAchse
                .maxwidth = 2.5
                .minwidth = 2
                .raddurchmesser = 1.2
            End With
            actProj.achsen.add(newAchse)
            TVHelper.Nodes(0).Nodes.Add("Achse_" & actProj.achsen.count - 1)
        End If
    End Sub

    Private Sub Achse_TBMaxwidt_KeyDown(sender As Object, e As KeyEventArgs) Handles Achse_TBMaxwidt.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Not getSelectedAchse() Is Nothing Then
                With getSelectedAchse()
                    .maxwidth = sender.Text
                    Achse_TBBreite.Text = Convert.ToString((.maxwidth - .minwidth) / 2)
                End With
            End If
        End If
    End Sub

    Private Sub Achse_TBMinwidt_KeyDown(sender As Object, e As KeyEventArgs) Handles Achse_TBMinwidt.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Not getSelectedAchse() Is Nothing Then
                With getSelectedAchse()
                    .minwidth = sender.Text
                    Achse_TBBreite.Text = Convert.ToString((.maxwidth - .minwidth) / 2)
                End With
            End If
        End If
    End Sub

    Private Sub Achse_TBDaempfer_KeyDown(sender As Object, e As KeyEventArgs) Handles Achse_TBDaempfer.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Not getSelectedAchse() Is Nothing Then
                With getSelectedAchse()
                    .daempfer = sender.Text
                End With
            End If
        End If
    End Sub

    Private Sub Achse_CBAntrieb_Click(sender As Object, e As EventArgs) Handles Achse_CBAntrieb.Click
        If Not getSelectedAchse() Is Nothing Then
            With getSelectedAchse()
                .antrieb = sender.checked
            End With
        End If
    End Sub

    Private Sub Achse_TBDurchmesser_KeyDown(sender As Object, e As KeyEventArgs) Handles Achse_TBDurchmesser.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Not getSelectedAchse() Is Nothing Then
                With getSelectedAchse()
                    .raddurchmesser = sender.Text
                End With
            End If
        End If
    End Sub

    Private Sub Achse_TBFeder_KeyDown(sender As Object, e As KeyEventArgs) Handles Achse_TBFeder.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Not getSelectedAchse() Is Nothing Then
                With getSelectedAchse()
                    .feder = sender.Text
                End With
            End If
        End If
    End Sub

    Private Sub Achse_TBMaxforce_KeyDown(sender As Object, e As KeyEventArgs) Handles Achse_TBMaxforce.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Not getSelectedAchse() Is Nothing Then
                With getSelectedAchse()
                    .maxforce = sender.Text
                End With
            End If
        End If
    End Sub

    '###  Kupplungspunkte  ###

    Private Sub FrontToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FrontToolStripMenuItem.Click
        If getProjType() = Proj_Bus.TYPE Then
            If Not actProj.couple_front Then
                actProj.couple_front = True
                actProj.couple_front_char = New Point3D(0, 0, 0)
                actProj.couple_front_point = New Point3D(0, 0, 0)
                TVHelper.Nodes(3).Nodes.Add("Front")
            Else
                MsgBox("Es existiert bereits ein Kupplungspunkt an der Front!")
            End If
        End If
    End Sub

    Private Sub HerckToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HeckToolStripMenuItem.Click
        If getProjType() = Proj_Bus.TYPE Then
            If Not actProj.couple_back Then
                actProj.couple_back = True
                actProj.couple_back_file = New Filename
                actProj.couple_back_point = New Point3D(0, 0, 0)
                TVHelper.Nodes(3).Nodes.Add("Heck")
            Else
                MsgBox("Es existiert bereits ein Kupplungspunkt am Heck!")
            End If
        End If
    End Sub

    '###  Kameras  ###

    Private Sub FahrerkameraToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FahrerkameraToolStripMenuItem.Click
        If getProjType() = Proj_Bus.TYPE Or getProjType() = Proj_Ovh.TYPE Then
            Dim newCam As New OMSI_Camera
            newCam.position = New Point3D()
            actProj.driver_cam_list.Add(newCam)
            TVHelper.Nodes(2).Nodes(0).Nodes.Add("Kamera_" & actProj.pax_cam_list.Count)
        Else
            MsgBox("Dieser Projekttyp unterstützt keine Kameras!")
        End If
    End Sub

    Private Sub FahrgastkameraToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FahrgastkameraToolStripMenuItem.Click
        If getProjType() = Proj_Bus.TYPE Or getProjType() = Proj_Ovh.TYPE Then
            Dim newCam As New OMSI_Camera
            newCam.position = New Point3D()
            actProj.pax_cam_list.Add(newCam)
            TVHelper.Nodes(2).Nodes(1).Nodes.Add("Kamera_" & actProj.pax_cam_list.Count)
        Else
            MsgBox("Dieser Projekttyp unterstützt keine Kameras!")
        End If
    End Sub

    Private Function getSelectedKamera() As OMSI_Camera
        If TVHelper.SelectedNode.FullPath.Contains("Fahrerkameras\") Then
            Return actProj.driver_cam_list(TVHelper.SelectedNode.Index)
        ElseIf TVHelper.SelectedNode.FullPath.Contains("Fahrgastkameras\") Then
            Return actProj.pax_cam_list(TVHelper.SelectedNode.Index)
        Else
            Return Nothing
        End If
    End Function

    Private Sub Kamera_TBDistRotPnt_KeyDown(sender As Object, e As KeyEventArgs) Handles Kamera_TBDistRotPnt.KeyDown
        If e.KeyCode = Keys.Enter Then
            getSelectedKamera.dist = Kamera_TBDistRotPnt.Text
        End If
    End Sub

    Private Sub Kamera_TBSichtwinkel_KeyDown(sender As Object, e As KeyEventArgs) Handles Kamera_TBSichtwinkel.KeyDown
        If e.KeyCode = Keys.Enter Then
            getSelectedKamera.sichtwinkel = Kamera_TBSichtwinkel.Text
        End If
    End Sub

    Private Sub Kamera_TBHorizont_KeyDown(sender As Object, e As KeyEventArgs) Handles Kamera_TBHorizont.KeyDown
        If e.KeyCode = Keys.Enter Then
            getSelectedKamera.rotX = Kamera_TBHorizont.Text
            getSelectedKamera.PositionCam()                     'Dreht um den Wert weiter
        End If
    End Sub

    Private Sub Kamera_TBVertikal_KeyDown(sender As Object, e As KeyEventArgs) Handles Kamera_TBVertikal.KeyDown
        If e.KeyCode = Keys.Enter Then
            getSelectedKamera.rotY = Kamera_TBVertikal.Text
            getSelectedKamera.PositionCam()                     'Dreht um den Wert weiter
        End If
    End Sub

    Private Sub Kamera_BTStd_Click(sender As Object, e As EventArgs) Handles Kamera_BTStd.Click
        actProj.cam_std = TVHelper.SelectedNode.Index
    End Sub

    Private Sub Kamera_CBVerkauf_Click(sender As Object, e As EventArgs) Handles Kamera_CBVerkauf.Click
        For index = 0 To actProj.driver_cam_list.Count - 1
            actProj.driver_cam_list(index).selling = False
            If index = TVHelper.SelectedNode.Index Then actProj.driver_cam_list(index).selling = Kamera_CBVerkauf.Checked
        Next
    End Sub

    Private Sub Kamera_CBFahrplan_Click(sender As Object, e As EventArgs) Handles Kamera_CBFahrplan.Click
        For index = 0 To actProj.driver_cam_list.Count - 1
            actProj.driver_cam_list(index).schedule = False
            If index = TVHelper.SelectedNode.Index Then actProj.driver_cam_list(index).schedule = Kamera_CBFahrplan.Checked
        Next
    End Sub


    '####  Achse  ####

    Private Sub Achse_TBDurchmesser_TextChanged(sender As Object, e As EventArgs) Handles Achse_TBDurchmesser.TextChanged
        If Not getSelectedAchse() Is Nothing Then
            PSPos.Point = New Point3D(0, getSelectedAchse.Y, getSelectedAchse.raddurchmesser / 2)
        End If
    End Sub

    Private Sub Achse_TBMaxwidt_TextChanged(sender As Object, e As EventArgs) Handles Achse_TBMaxwidt.TextChanged
        If Not getSelectedAchse() Is Nothing Then
            Achse_TBBreite.Text = Convert.ToString((getSelectedAchse.maxwidth - getSelectedAchse.minwidth) / 2)
        End If
    End Sub

    Private Sub Achse_TBMinwidt_TextChanged(sender As Object, e As EventArgs) Handles Achse_TBMinwidt.TextChanged
        If Not getSelectedAchse() Is Nothing Then
            Achse_TBBreite.Text = Convert.ToString((getSelectedAchse.maxwidth - getSelectedAchse.minwidth) / 2)
        End If
    End Sub

    '####  Kupplung  ####

    Private Function isKupplSelected(direction As String) As Boolean
        If getProjType() = Proj_Bus.TYPE Or getProjType() = Proj_Ovh.TYPE Then
            If TVHelper.SelectedNode.FullPath.Contains("\") Then
                If LCase(TVHelper.SelectedNode.FullPath.Split("\")(1)) = LCase(direction) Then
                    Return True
                End If
            End If
        End If
        Return False
    End Function

    Private Sub Kuppl_CBSound_CheckedChanged(sender As Object, e As EventArgs) Handles Kuppl_CBSound.CheckedChanged
        If isKupplSelected("front") Then
            actProj.couple_front_sound = Kuppl_CBSound.Checked
        End If
    End Sub

    Private Sub Kuppl_DDKupplType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Kuppl_DDKupplType.SelectedIndexChanged
        If isKupplSelected("front") Then
            actProj.couple_front_type = intToBool(Kuppl_DDKupplType.SelectedIndex)
        End If
    End Sub

    Private Sub Kuppl_TBDrehwinkel_TextChanged(sender As Object, e As EventArgs) Handles Kuppl_TBDrehwinkel.TextChanged
        If isKupplSelected("front") Then
            If actProj.couple_front_char Is Nothing Then actProj.couple_front_char = New Point3D
            If sender.text <> "" Then
                actProj.couple_front_char.X = toSingle(sender.Text)
            End If
        End If
    End Sub

    Private Sub Kuppl_TBDown_TextChanged(sender As Object, e As EventArgs) Handles Kuppl_TBDown.TextChanged
        If isKupplSelected("front") Then
            If actProj.couple_front_char Is Nothing Then actProj.couple_front_char = New Point3D
            If sender.text <> "" Then
                actProj.couple_front_char.Y = toSingle(sender.Text)
            End If
        End If
    End Sub

    Private Sub Kuppl_TBUp_TextChanged(sender As Object, e As EventArgs) Handles Kuppl_TBUp.TextChanged
        If isKupplSelected("front") Then
            If actProj.couple_front_char Is Nothing Then actProj.couple_front_char = New Point3D
            If sender.text <> "" Then
                actProj.couple_front_char.Z = toSingle(sender.Text)
            End If
        End If
    End Sub

    Private Sub Kuppl_DDNextVehicle_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Kuppl_DDNextVehicle.SelectedIndexChanged
        If isKupplSelected("heck") Then
            If Kuppl_DDNextVehicle.SelectedItem = "" Then
                actProj.couple_back_file = Nothing
            Else
                actProj.couple_back_file = New Filename(Kuppl_DDNextVehicle.Text, actProj.filename.path)
            End If
        End If
    End Sub

    Private Sub Kuppl_DDRichtung_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Kuppl_DDRichtung.SelectedIndexChanged
        If isKupplSelected("heck") Then
            actProj.couple_back_dir = intToBool(Kuppl_DDRichtung.SelectedIndex)
        End If
    End Sub


    ' #### TV Helper ####

    Private Sub TVHelper_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TVHelper.AfterSelect
        If TVHelper.SelectedNode.ToolTipText = "" Then
            TBName.Text = TVHelper.SelectedNode.Text
        End If
        If getProjType() = Proj_Emt.TYPE Then Exit Sub

        Dim index As Integer = TVHelper.SelectedNode.Index

        If TVHelper.SelectedNode.Text = TVHelper.Nodes(1).Text Then     'Boundingbox Then
            If Not getProjType() = Proj_Emt.TYPE Then
                showSettings({GBBbox})
                If Not actProj.bbox Is Nothing Then
                    PSPos.Point = actProj.bbox.pos
                    BBox_PSSize.Point = actProj.bbox.size
                End If
            End If
            Exit Sub
        End If

        If TVHelper.SelectedNode.FullPath.Contains("\") Then
            Select Case TVHelper.SelectedNode.FullPath.Split("\")(0)
                Case TVHelper.Nodes(0).Text     'Achsen
                    showSettings({GBAchse})
                    With actProj.achsen(index)
                        PSPos.Point = New Point3D(0, .Y, .raddurchmesser / 2)
                        Achse_TBMaxwidt.Text = .maxwidth
                        Achse_TBMinwidt.Text = .minwidth
                        Achse_TBFeder.Text = .feder
                        Achse_TBMaxforce.Text = .maxforce
                        Achse_TBDaempfer.Text = .daempfer
                        Achse_TBDurchmesser.Text = .raddurchmesser
                        Achse_CBAntrieb.Checked = .antrieb
                    End With

                Case TVHelper.Nodes(1).Text     'Attachpoint
                    'noch nix

                Case TVHelper.Nodes(2).Text     'Kameras
                    showSettings({GBKamera})
                    Dim selectedCamTmp As New OMSI_Camera
                    If TVHelper.SelectedNode.FullPath.Split("\")(1) = TVHelper.Nodes(2).Nodes(0).Text And actProj.driver_cam_list.Count > 0 Then
                        Kamera_RBFahrer.Checked = True
                        selectedCamTmp = actProj.driver_cam_list(index)
                        Kamera_BTStd.Enabled = True
                        Kamera_CBVerkauf.Enabled = True
                        Kamera_CBFahrplan.Enabled = True

                    ElseIf TVHelper.SelectedNode.FullPath.Split("\")(1) = TVHelper.Nodes(2).Nodes(1).Text And actProj.pax_cam_list.Count > 0 Then
                        Kamera_RBPassagier.Checked = True
                        selectedCamTmp = actProj.pax_cam_list(index)
                        Kamera_BTStd.Enabled = False
                        Kamera_CBVerkauf.Enabled = False
                        Kamera_CBFahrplan.Enabled = False
                    End If

                    With selectedCamTmp
                        PSPos.Point = .position
                        Kamera_TBDistRotPnt.Text = .dist
                        Kamera_TBSichtwinkel.Text = .sichtwinkel
                        Kamera_TBHorizont.Text = .rotX
                        Kamera_TBVertikal.Text = .rotY
                        Kamera_CBFahrplan.Checked = .schedule
                        Kamera_CBVerkauf.Checked = .selling
                    End With


                Case TVHelper.Nodes(3).Text     'Kupplungspunkte
                    showSettings({GBKupplPnt})
                    With actProj
                        If TVHelper.SelectedNode.Text = "Front" Then
                            Kuppl_LBFront.Visible = True
                            Kuppl_LBHeck.Visible = False
                            PSPos.Point = .couple_front_point
                            Kuppl_CBSound.Checked = .couple_front_sound
                            Kuppl_TBDrehwinkel.Text = .couple_front_char.X
                            Kuppl_TBDown.Text = .couple_front_char.Y
                            Kuppl_TBUp.Text = .couple_front_char.Z
                            Kuppl_DDKupplType.SelectedIndex = boolToInt(.couple_front_type)

                        ElseIf TVHelper.SelectedNode.Text = "Heck" Then
                            Kuppl_LBFront.Visible = False
                            Kuppl_LBHeck.Visible = True
                            PSPos.Point = .couple_back_point
                            If Not .couple_back_file Is Nothing Then Kuppl_DDNextVehicle.SelectedItem = .couple_back_file.name
                            Kuppl_DDRichtung.SelectedIndex = boolToInt(.couple_back_dir)
                        End If
                    End With

                Case TVHelper.Nodes(4).Text     'Innenlichter
                    showSettings({GBLicht})
                    PSPos.Point = actProj.model.intLichter(index).position

                Case TVHelper.Nodes(5).Text     'Rauch
                    showSettings({GBParent, GBRauch})
                    PSPos.Point = actProj.model.rauch(index).position
                    Parent_CBParent.SelectedItem = actProj.model.rauch(index).parent

                Case TVHelper.Nodes(6).Text     'Spiegel
                    showSettings({GBKamera})
                    PSPos.Point = actProj.spiegel(index).position

                Case TVHelper.Nodes(7).Text     'Sitz-/Stehplatz
                    showSettings({GBPlatz, GBBel})
                    With actProj
                        PSPos.Point = .cabin.passPos(index).position
                    End With

                Case TVHelper.Nodes(10).Text     'Splinehelper
                    With actProj.splinehelpers(index)
                        PSPos.Point = .position
                        Splinehelper_TBDrehung.Text = .rotation.X
                        Splinehelper_TBSpline.Text = .spline.name
                    End With
                Case TVHelper.Nodes(11).Text    'Spots
                    showSettings({GBSpot})
                    With actProj.model.spots(index) 'actProj.model.spots(index)
                        PSPos.Point = .position
                        Spot_PSRichtung.Point = .richtung
                        Spot_CSFarbe.SelectedColor = .color
                        Spot_TBAussen.Text = .outerCone
                        Spot_TBInner.Text = .innerCone
                        Spot_TBLeuchtweite.Text = .range
                    End With

            End Select
        End If
        GlMain.Invalidate()
    End Sub

    Private Sub EntfernenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EntfernenToolStripMenuItem.Click

        Dim index As Integer = TVHelper.SelectedNode.Index

        If TVHelper.SelectedNode.FullPath.Contains("\") Then
            Select Case TVHelper.SelectedNode.FullPath.Split("\")(0)
                Case TVHelper.Nodes(0).Text     'Achsen
                    actProj.achsen.RemoveAt(index)

                Case TVHelper.Nodes(2).Text     'Kameras
                    If TVHelper.SelectedNode.FullPath.Split("\")(1) = TVHelper.Nodes(2).Nodes(0).Text Then
                        actProj.driver_cam_list.RemoveAt(index)
                    ElseIf TVHelper.SelectedNode.FullPath.Split("\")(1) = TVHelper.Nodes(2).Nodes(1).Text Then
                        actProj.pax_cam_list.RemoveAt(index)
                    End If

                Case TVHelper.Nodes(3).Text     'Kupplungspunkte
                    If index = 0 Then
                        actProj.couple_front = False
                        actProj.couple_front_sound = False
                    Else
                        actProj.couple_back = False
                        actProj.couple_back_file.name = ""
                    End If

                Case TVHelper.Nodes(4).Text     'Innenlichter
                    actProj.model.intLichter.RemoveAt(index)

                Case TVHelper.Nodes(5).Text     'Rauch
                    actProj.model.rauch.removeAt(index)

                Case TVHelper.Nodes(6).Text     'Spiegel
                    actProj.spiegel.RemoveAt(index)

                Case TVHelper.Nodes(7).Text     'Sitz-/Stehplatz
                    actProj.cabin.passPos.RemoveAt(index)

                                                'Tickets

                                                'Attachpoints

                Case TVHelper.Nodes(10).Text     'Splinehelper
                    actProj.splinehelpers.RemoveAt(index)

                Case TVHelper.Nodes(11).Text    'Spots
                    actProj.model.spots.RemoveAt(index)
            End Select

            TVHelper.Nodes.Remove(TVHelper.SelectedNode)
            GlMain.Invalidate()
        Else
            Select Case TVHelper.SelectedNode.FullPath
                Case TVHelper.Nodes(1).Text     'Boundingbox
                    BBox_PSSize.Point = New Point3D()
                    PSPos.Point = New Point3D
                    actProj.bbox = Nothing
            End Select
        End If
    End Sub

    Private Sub NeuToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles NeuToolStripMenuItem1.Click
        Dim index As Integer = TVHelper.SelectedNode.Index

        If TVHelper.SelectedNode.FullPath.Contains("\") Then
            Select Case TVHelper.SelectedNode.FullPath.Split("\")(0)
                Case TVHelper.Nodes(0).Text     'Achsen
                    AchseToolStripMenuItem.PerformClick()

                Case TVHelper.Nodes(1).Text     'Attachpoint
                    AttachpointsToolStripMenuItem.PerformClick()

                Case TVHelper.Nodes(2).Text     'Kameras
                    If TVHelper.SelectedNode.FullPath.Split("\")(1) = TVHelper.Nodes(2).Nodes(0).Text Then
                        FahrerkameraToolStripMenuItem.PerformClick()
                    Else
                        PassagiersichtToolStripMenuItem.PerformClick()
                    End If

                Case TVHelper.Nodes(3).Text     'Kupplungspunkte
                    If index = 0 Then
                        FrontToolStripMenuItem.PerformClick()
                    ElseIf index = 1 Then
                        HeckToolStripMenuItem.PerformClick()
                    End If

                Case TVHelper.Nodes(4).Text     'Innenlichter
                    InnenlichtToolStripMenuItem.PerformClick()

                Case TVHelper.Nodes(5).Text     'Rauch
                    RauchToolStripMenuItem.PerformClick()

                Case TVHelper.Nodes(6).Text     'Spiegel
                    SpiegelToolStripMenuItem.PerformClick()

                Case TVHelper.Nodes(7).Text     'Sitz-/Stehplatz
                    SitzplatzToolStripMenuItem.PerformClick()

                Case TVHelper.Nodes(10).Text     'Splinehelper
                    SplinehelperToolStripMenuItem.PerformClick()

                Case TVHelper.Nodes(11).Text    'Spots
                    SpotToolStripMenuItem.PerformClick()
            End Select
        End If
    End Sub

    Private Sub TCObjekte_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TCObjekte.SelectedIndexChanged
        Select Case TCObjekte.SelectedIndex
            Case 0
                If Not getProjType() = Proj_Sli.TYPE Then
                    showSettings({GBMesh, GBMat, GBAnimation, GBBones, GBBel})
                Else
                    showSettings({GBSpline, GBMat})
                End If
            Case 1
                showSettings(Nothing)
            Case 2
                showSettings({GBParent, GBLicht})
            Case 3
                If Not getProjType() = Proj_Sli.TYPE Then
                    showSettings({GBPfade})
                Else
                    showSettings({GBPfad})
                End If

        End Select
        getOCTProj.TCObjkteSelected = TCObjekte.SelectedIndex
        GlMain.Invalidate()
    End Sub

    Private Sub showSettings(boxen As GroupBox())
        For Each GB As GroupBox In PanelEigenschaften1.Controls
            If Not GB.Text = "Allgemein" Then
                GB.Visible = False
            End If
        Next

        If boxen Is Nothing Then Exit Sub

        Dim top As Integer = GBAllgemein.Height + GBAllgemein.Top + 6
        For Each box In boxen
            box.Top = top
            top += box.Height + 6
            box.Visible = True
        Next
    End Sub

    Private Sub LBLichter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LBLichter.SelectedIndexChanged
        If LBLichter.SelectedIndex > -1 Then
            If LBLichter.SelectedIndex < actProj.model.lichter.Count Then
                Licht_VSVar.Enabled = True
                Licht_TBTexture.Enabled = True
                Licht_PSVector.Enabled = True
                Licht_CBAusr.Enabled = True
                Licht_CBRotAusr.Enabled = True
                Licht_TBFaktor.Enabled = True
                Licht_TBOffset.Enabled = True
                Licht_CBEffekt.Enabled = True
                Licht_TBKegel.Enabled = True
                Licht_TBZeitkonst.Enabled = True

                If lastSelectedLight >= 0 Then saveLightProps(lastSelectedLight)
                LoadLightProps()
            End If
            lastSelectedLight = LBLichter.SelectedIndex
        End If
    End Sub

    Private Sub LoadLightProps()
        With actProj.model.lichter(LBLichter.SelectedIndex)
            TBName.Text = LBLichter.SelectedItem.ToString
            PSPos.Point = .position
            Licht_PSRichtung.Point = .richtung
            Licht_PSVector.Point = .upVector

            Try
                Licht_CBAusr.SelectedIndex = .ausrichtung
            Catch ex As Exception
                Log.Add("Der Wert enstpricht nicht dem gültigen Werteberich (Wert: " & .ausrichtung & " Bereich: Ausrichtung)", Log.TYPE_ERROR)
            End Try

            Try
                Licht_CBRotAusr.SelectedIndex = .rotating
            Catch ex As Exception
                Log.Add("Der Wert enstpricht nicht dem gültigen Werteberich (Wert: " & .rotating & " Bereich: Rotation)", Log.TYPE_ERROR)
            End Try

            Licht_CSFarbe.SelectedColor = .Color
            Licht_TBGroesse.Text = FormatNumber(.size, 3)
            Licht_TBInnerCone.Text = .innerCone
            Licht_TBOuterCone.Text = .outerCone

            Try
                Licht_VSVar.Variable = .var
            Catch ex As Exception
                Log.Add("Der Wert enstpricht nicht dem gültigen Werteberich (Wert: " & .var & " Bereich: Variable)", Log.TYPE_ERROR)
            End Try

            Licht_TBFaktor.Text = .faktor
            Licht_TBOffset.Text = .offset

            Try
                Licht_CBEffekt.SelectedIndex = .effekt
            Catch ex As Exception
                Log.Add("Der Wert enstpricht nicht dem gültigen Werteberich (Wert: " & .effekt & " Bereich: Effekt)", Log.TYPE_ERROR)
            End Try

            Licht_TBKegel.Text = .cone
            Licht_TBZeitkonst.Text = .timeconst
            Licht_TBTexture.Text = .bitmap
            If .bitmap = "" Or System.IO.File.Exists(actProj.filename.path & "\Texture\" & .bitmap) Then
                Licht_TBTexture.BackColor = SystemColors.Control
            Else
                Licht_TBTexture.BackColor = Color.Red
            End If
            Parent_CBParent.Text = .parent
        End With
    End Sub

    Private Sub saveLightProps(index As Integer)
        If Not index < 0 And Not index > actProj.model.lichter.count - 1 Then
            With actProj.model.lichter(index)
                .name = TBName.Text
                .position = New Point3D(PSPos.Point)
                .richtung = New Point3D(Licht_PSRichtung.Point)
                .upVector = New Point3D(Licht_PSVector.Point)
                Try
                    .ausrichtung = Licht_CBAusr.SelectedIndex
                Catch ex As Exception
                    .ausrichtung = 0
                End Try
                Try
                    .rotating = Licht_CBRotAusr.SelectedIndex
                Catch ex As Exception
                    .rotating = 0
                End Try

                .Color = Licht_CSFarbe.SelectedColor
                .size = Licht_TBGroesse.Text
                .innerCone = Licht_TBInnerCone.Text
                .outerCone = Licht_TBOuterCone.Text
                .var = Licht_VSVar.Variable
                If Licht_TBFaktor.Text <> "" Then .faktor = Licht_TBFaktor.Text
                If Licht_TBOffset.Text <> "" Then .offset = Licht_TBOffset.Text
                Try
                    .effekt = Licht_CBEffekt.SelectedIndex
                Catch ex As Exception
                    .effekt = 0
                End Try

                .cone = Licht_TBKegel.Text
                .timeconst = Licht_TBZeitkonst.Text
                .bitmap = Licht_TBTexture.Text
                .parent = Parent_CBParent.Text
            End With
        End If
    End Sub

    Private Function TrySet(OBJ1 As Object, OBJ2 As Object) As Object
        Try
            OBJ1 = OBJ2
            Return OBJ2
        Catch ex As Exception
            Log.Add("Der Wert enstpricht nicht dem gültigen Werteberich: " & OBJ2.Name, Log.TYPE_ERROR)
            Return Nothing
        End Try
    End Function

    Private Sub LBMeshes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LBMeshes.SelectedIndexChanged
        Dim selectedMesh As OMSI_Mesh = getSelectedMesh()
        selectedMeshesChanged = True
        If Not selectedMesh Is Nothing Then
            If Not getProjType() = Proj_Sli.TYPE Then
                saveMeshProbs(lastSelectedMesh)
                showMeshProps(selectedMesh)
                getOCTProj.LBMeshesSelected = LBMeshes.SelectedIndex
            Else
                'saveSliPartProps(lastSelectedMesh)
                showSliPartProps(selectedMesh)
            End If

        End If
        GlMain.Invalidate()
        lastSelectedMesh = getSelectedMesh()
    End Sub

    Private Sub showSliPartProps(mesh As OMSI_Mesh)
        If Not mesh Is Nothing Then
            Dim index As Integer = LBMeshes.SelectedIndex
            With mesh

                Spline_TBStartX.Text = actProj.profiles(index).profilePnts(0).X
                Spline_TBStartZ.Text = actProj.profiles(index).profilePnts(0).Y

                Spline_TBEndX.Text = actProj.profiles(index).profilePnts(1).X
                Spline_TBEndZ.Text = actProj.profiles(index).profilePnts(1).Y

                'U ist X auf der Texture und V ist Texture pro Meter (0,16 macht 1,6 Mal die Texture für 10m Spline)

                DDAlleTexturen.SelectedItem = actProj.textures(actProj.profiles(index).texIndex).filename.name

                'hier weiter!
            End With
        End If
    End Sub

    Private Sub showMeshProps(mesh As OMSI_Mesh)
        If mesh IsNot Nothing Then
            With mesh
                'Allgemein
                TBName.Text = .filename.name
                PSPos.Point = .position

                'Mesh
                Mesh_DDViedpoint.SelectedIndex = .viewpoint
                Mesh_VSSichtbarkeit.Variable = .visibleVar
                Mesh_TBSichtbarkeitVal.Text = Convert.ToString(.visibleInt)
                Mesh_VSKlickevent.Variable = .mouseEvent
                Mesh_PSCenter.Point = .center
                Mesh_NUMin.Value = Convert.ToDecimal(.lodMin)
                Mesh_NUMax.Value = Convert.ToDecimal(.lodMax)
                Mesh_TBMeshident.Text = .meshIdent

                'Parent
                Parent_CBParent.Text = .animParent

                'Materialien
                Mat_CBTex.Items.Clear()
                For Each id In getSelectedObjektIds()
                    If getOCTProj.alleMeshes.Count > id Then
                        For Each texture In getOCTProj.alleMeshes(id).texturen
                            Mat_CBTex.Items.Add(texture.filename.name)
                        Next
                    End If
                Next
                'Weitere Mat eig werden mit dem verändern der Texture geladen

                If Mat_CBTex.Items.Count > 0 Then
                    Mat_CBTex.SelectedIndex = 0
                    'Mat_CBTextTex.SelectedItem = Projekt_Bus.model.TextTexturen(Mat_CBTex.SelectedIndex).name
                Else
                    Mat_CBTextTex.SelectedIndex = 0
                End If

                'Animation
                Anim_TBAnimGrp.Text = .animParent
                Anim_DDList.Items.Clear()
                If .animations.Count > 0 Then
                    For i = 0 To .animations.Count - 1
                        Anim_DDList.Items.Add(i)
                    Next
                    Anim_DDList.SelectedIndex = 0
                    AnimDetails(mesh, 0)
                End If

                'Innenbeleuchtung
                Bel_CB0.SelectedIndex = 0
                Bel_CB1.SelectedIndex = 0
                Bel_CB2.SelectedIndex = 0
                Bel_CB3.SelectedIndex = 0

                If Not .illumination Is Nothing Then
                    If .illumination.values.Count = 4 Then
                        Bel_CB0.SelectedIndex = .illumination.values(0) + 1
                        Bel_CB1.SelectedIndex = .illumination.values(1) + 1
                        Bel_CB2.SelectedIndex = .illumination.values(2) + 1
                        Bel_CB3.SelectedIndex = .illumination.values(3) + 1
                    End If
                End If

                If .lodMin > lodVal Or .lodMax < lodVal Then
                    MsgBox("Das Objekt wir auf Grund der LOD Filterung nicht angezeigt. Der Filter kann unter Ansicht -> LOD-Filter verändert werden.")
                End If
            End With
        End If
    End Sub

    Private Sub saveMeshProbs(mesh As OMSI_Mesh)
        If Not mesh Is Nothing Then
            With mesh
                'Allgemein
                '.filename.name = TBName.Text   -> Name darf nicht hier geändert werden!
                .position = PSPos.Point

                'Mesh
                .viewpoint = Convert.ToByte(Mesh_DDViedpoint.SelectedIndex)
                .visibleVar = Mesh_VSSichtbarkeit.Variable
                .visibleInt = Convert.ToInt32(Mesh_TBSichtbarkeitVal.Text)
                .mouseEvent = Mesh_VSKlickevent.Variable
                .lodMin = Mesh_NUMin.Value
                .lodMax = Mesh_NUMax.Value
                .meshIdent = Mesh_TBMeshident.Text

                'Animation
                .animParent = Anim_TBAnimGrp.Text

            End With
        End If
    End Sub

    'Panel Animation ###########

    Private Sub Anim_CBList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Anim_DDList.SelectedIndexChanged
        AnimDetails(getSelectedMesh, Anim_DDList.SelectedIndex)
    End Sub

    Private Sub AnimDetails(mesh As OMSI_Mesh, id As Integer)
        If mesh.animations.Count - 1 < id Then Exit Sub
        With mesh.animations(id)
            If .anim_type = OMSI_Anim.TYPE_ROTATION Then
                Anim_RBDrehen.Checked = True
                Anim_RBVerschieben.Checked = False
            Else
                Anim_RBDrehen.Checked = False
                Anim_RBVerschieben.Checked = True
            End If

            Anim_VSVar.Variable = .anim_var
            Anim_TBValue.Text = fromSingle(.anim_val)
            If .origin_from_mesh Then
                Anim_RBMesh.Checked = True
                Anim_RBPoint.Checked = False
                Anim_PSRotPnt.Point = .mesh_center
                Anim_PSRichtung.Point = .mesh_origin
            Else
                Anim_RBMesh.Checked = False
                Anim_RBPoint.Checked = True
                Anim_PSRotPnt.Point = .origin_trans
                Anim_PSRichtung.Point = .origin_rot
            End If

            Anim_TBMaxSpeed.Text = fromSingle(.maxspeed)
            Anim_TBDelay.Text = fromSingle(.delay)
        End With
    End Sub

    Private Sub Anim_RBPoint_CheckedChanged(sender As Object, e As EventArgs) Handles Anim_RBPoint.CheckedChanged
        Anim_PSRotPnt.Enabled = Anim_RBPoint.Checked
        Anim_PSRichtung.Enabled = Anim_RBPoint.Checked
        getSelectedAnim.origin_from_mesh = Not Anim_RBPoint.Checked
    End Sub

    Private Sub Anim_BTNeu_Click(sender As Object, e As EventArgs) Handles Anim_BTNeu.Click
        If Not getProjType() = Proj_Sli.TYPE Then
            If Not getSelectedMesh() Is Nothing Then
                Dim newAnim As New OMSI_Anim
                With newAnim
                    .anim_type = OMSI_Anim.TYPE_ROTATION
                    .anim_val = 1
                    .origin_from_mesh = True
                    .mesh_center = getSelectedMesh.center
                End With
                getSelectedMesh.animations.Add(newAnim)
                Anim_DDList.Items.Add(Anim_DDList.Items.Count)
                Anim_DDList.SelectedIndex = Anim_DDList.Items.Count - 1
            End If
        End If
    End Sub

    Private Sub Anim_BTLöschen_Click(sender As Object, e As EventArgs) Handles Anim_BTLöschen.Click
        If Not getSelectedMesh() Is Nothing Then
            selectedMesh.animations.RemoveAt(Anim_DDList.SelectedIndex)
            Anim_DDList.Items.RemoveAt(Anim_DDList.Items.Count - 1)
        End If
    End Sub

    Private Sub Anim_VSVar_Changed(sender As Object, e As EventArgs) Handles Anim_VSVar.Changed
        getSelectedAnim.anim_var = Anim_VSVar.Variable
    End Sub

    Private Sub Anim_TBValue_Leave(sender As Object, e As EventArgs) Handles Anim_TBValue.Leave
        If Not IsNumeric(Anim_TBValue.Text) Then
            Anim_TBValue.Text = "0"
        End If
        getSelectedAnim.anim_val = toSingle(Anim_TBValue.Text)
    End Sub

    Private Sub Anim_RBDrehen_Click(sender As Object, e As EventArgs) Handles Anim_RBDrehen.Click
        getSelectedAnim.anim_type = Not Anim_RBDrehen.Checked
    End Sub

    Private Sub Anim_PSRichtung_Changed(sender As Object, e As EventArgs) Handles Anim_PSRichtung.Changed
        If Anim_PSRichtung.Enabled Then
            getSelectedAnim.origin_rot = Anim_PSRichtung.Point
        End If
    End Sub

    Private Sub Anim_PSRotPnt_Changed(sender As Object, e As EventArgs) Handles Anim_PSRotPnt.Changed
        If Anim_PSRotPnt.Enabled Then
            If Not getSelectedAnim() Is Nothing Then
                getSelectedAnim.origin_trans = Anim_PSRotPnt.Point
            End If
        End If
    End Sub

    Private Sub Anim_TBMaxSpeed_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs) Handles Anim_TBMaxSpeed.KeyPress
        If Helper.NumbersOnly(e, sender, True, Double.MinValue, Double.MaxValue) Then
            If Not getSelectedAnim() Is Nothing Then
                getSelectedAnim.maxspeed = toSingle(Anim_TBMaxSpeed.Text)
            End If
            e.Handled = True
        End If
    End Sub

    Private Sub Anim_TBDelay_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs) Handles Anim_TBDelay.KeyPress
        If Helper.NumbersOnly(e, sender, True, Double.MinValue, Double.MaxValue) Then
            If Not getSelectedAnim() Is Nothing Then
                getSelectedAnim.delay = toSingle(Anim_TBDelay.Text)
            End If
            e.Handled = True
        End If
    End Sub

    Private Function getSelectedAnim() As OMSI_Anim
        If Not getSelectedMesh() Is Nothing Then
            If Anim_DDList.SelectedIndex < getSelectedMesh.animations.Count Then
                Return getSelectedMesh.animations(Anim_DDList.SelectedIndex)
            End If
        End If
        Return Nothing
    End Function


    'Panel Texture ##########

    Private Sub PanelTextureFill_Click(sender As Object, e As EventArgs) Handles BTPanelTextureFill.Click
        With Frm_Texture
            If PBTexture.Tag <> "" Then
                .ImageTag = PBTexture.Tag
                .Text = "Texture - """ & PBTexture.Tag & """"

                If getProjType() = Proj_Bus.TYPE Or Proj_Ovh.TYPE Or Proj_Sco.TYPE Then
                    Dim allSubObjekte As New List(Of Integer)
                    Dim allTexCoords As Double() = {}
                    For Each Objekt In getOCTProj.alleMeshes
                        If selectedMesh.ObjIds.Contains(Objekt.id) Then
                            For subObjID As Integer = 0 To Objekt.texturen.Count - 1
                                If Objekt.texturen(subObjID).filename = New Filename(PBTexture.Tag.ToString) Then
                                    allSubObjekte.AddRange(Objekt.subObjekte(subObjID).ToList)
                                    allTexCoords = Objekt.texCoords
                                End If
                            Next

                        End If
                    Next
                    .drawUV(allTexCoords, allSubObjekte.ToArray)
                ElseIf getProjType() = Proj_Sli.TYPE Then
                    'hier weiter für SLI
                End If


                PanelTexture.Visible = False
            End If
            .Show()
        End With
    End Sub

    Private Sub BTPanelTextureClose_Click(sender As Object, e As EventArgs) Handles BTPanelTextureClose.Click
        PanelTexture.Dock = DockStyle.None
        PanelTexture.Visible = False
        savePositions()
    End Sub

    Private Sub LBPanelTexture_MouseDown(sender As Object, e As MouseEventArgs) Handles LBPanelTexture.MouseDown, MSTexturen.MouseDown
        movePanelTexture = True
    End Sub

    Private Sub LBPanelTexture_MouseUp(sender As Object, e As MouseEventArgs) Handles LBPanelTexture.MouseUp, MSTexturen.MouseUp
        movePanelTexture = False
        checkPanelPosition(PanelTexture)
        savePositions()
    End Sub

    Private Sub LBPanelTexture_MouseMove(sender As Object, e As MouseEventArgs) Handles LBPanelTexture.MouseMove, MSTexturen.MouseMove
        If movePanelTexture Then
            Dim ctl As Control = CType(PanelTexture, Control)
            ctl.Location = PointToClient(Cursor.Position - New Point(ctl.Width \ 2, 30))
        End If
    End Sub

    Private Sub SelectedTextureChanged(file As String)
        If file = "keine" Or file = "" Then
            PBTexture.Image = My.Resources.weiss
            DDAlleTexturen.Text = "keine"
        Else
            For Each Objekt In getOCTProj.alleMeshes
                For Each texture In Objekt.texturen
                    If texture.filename.name = file Then
                        If System.IO.File.Exists(texture.filename) Then
                            PBTexture.Tag = texture.filename
                            DisplayImage(PBTexture)

                            Exit Sub
                        End If
                    End If
                Next
            Next
            PBTexture.Image = My.Resources.pink
            If IO.File.Exists(actProj.filename.path & "\Texture\" & file) Then
                PBTexture.Tag = actProj.filename.path & "\Texture\" & file
            End If
        End If
    End Sub



    Private Sub BTTexBearb_Click(sender As Object, e As EventArgs) Handles BTTexBearb.Click
        If Not PBTexture.Tag Is Nothing Then
            Process.Start(PBTexture.Tag)
        End If
    End Sub

    Private Sub BTTexOkay_Click(sender As Object, e As EventArgs) Handles BTTexOkay.Click
        loadPositions()
        BTTexOkay.Visible = False
        activeImageSelector.Text = DDAlleTexturen.Text
    End Sub

    Private Sub BTTexLoad_Click(sender As Object, e As EventArgs) Handles BTTexLoad.Click
        allTexturesCheckLastChange()
    End Sub

    Private Sub TReloadTextures_Tick(sender As Object, e As EventArgs) Handles TReloadTextures.Tick
        allTexturesCheckLastChange()
    End Sub

    Private Sub allTexturesCheckLastChange()

        For Each localObject In getOCTProj.alleMeshes
            For Each texture In localObject.texturen
                TextureCheckLastChange(texture)
            Next
        Next
        For Each texture In overWriteTextures
            TextureCheckLastChange(texture)
        Next
        GlMain.Invalidate()
    End Sub

    Dim lastReloadedTexture As New Material
    Private Sub TextureCheckLastChange(ByRef texture As Material)
        If IO.File.Exists(texture.filename) Then

            'If lastReloadedTexture = texture Then Exit Sub
            'lastReloadedTexture = texture

            Dim lastChangedate As Date = IO.File.GetLastWriteTime(texture.filename)
            If Not lastChangedate = texture.lastChangeDate Then
                texture.lastChangeDate = lastChangedate
                loadTexture(texture, True)
                If texture.filename.name = DDAlleTexturen.Text Then
                    SelectedTextureChanged(DDAlleTexturen.Text)
                End If
            End If
        End If
    End Sub


    Private Function getSelectedLight() As OMSI_Licht
        If LBLichter.SelectedIndex >= 0 Then
            If Not actProj.model Is Nothing Then
                For Each light In actProj.model.lichter
                    If light.name = LBLichter.SelectedItem Or light.name = "Licht " & LBLichter.SelectedIndex Then
                        Return light
                    End If
                Next
            End If
        End If

        Return Nothing
    End Function

    Private Function getSelectedMesh() As OMSI_Mesh
        If Not selectedMeshesChanged And Not selectedMesh Is Nothing Then
            Return selectedMesh
        End If

        If LBMeshes.SelectedIndex >= 0 Then
            If Not getProjType() = Proj_Sli.TYPE Then
                If Not actProj.model Is Nothing Then
                    selectedMesh = actProj.model.meshes(LBMeshes.SelectedIndex)
                    Return selectedMesh
                End If
            Else
                Dim newMesh As New OMSI_Mesh
                With newMesh
                    .filename = New Filename(LBMeshes.SelectedItem, actProj.filename.path)
                    .ObjIds.Add(LBMeshes.SelectedIndex)
                End With
                Return newMesh
            End If
        End If

        Return Nothing
    End Function

    Private Function getSelectedMeshes() As List(Of OMSI_Mesh)
        If Not selectedMeshesChanged And Not selectedMeshes Is Nothing Then
            Return selectedMeshes
        End If

        selectedMeshesChanged = False
        Dim counter As Integer = 0

        If LBMeshes.SelectedIndex >= 0 Then
            selectedMeshes = New List(Of OMSI_Mesh)
            If getProjType() = Proj_Bus.TYPE Or getProjType() = Proj_Emt.TYPE Or getProjType() = Proj_Sco.TYPE Then
                If Not actProj.model Is Nothing Then
                    For Each mesh In actProj.model.meshes
                        If LBMeshes.SelectedItems.Contains(mesh.filename.name) Then
                            selectedMeshes.Add(mesh)

                            counter += 1
                            If counter >= LBMeshes.SelectedItems.Count Then
                                Return selectedMeshes
                            End If
                        End If
                    Next
                End If
            End If

            If getProjType() = Proj_Sli.TYPE Then
                Dim newMesh As New OMSI_Mesh
                With newMesh
                    .filename = New Filename(LBMeshes.SelectedItem, actProj.filename.path)
                    .ObjIds.Add(LBMeshes.SelectedIndex)
                End With
                selectedMeshes.Add(newMesh)
            End If
        End If

        Return Nothing
    End Function

    Private Function getSelectedObjektIds() As List(Of Int16)
        If LBMeshes.SelectedIndex >= 0 Then
            If Not getProjType() = Proj_Sli.TYPE Then
                If Not actProj.model Is Nothing Then
                    For Each mesh In actProj.model.meshes
                        For Each Objekt In LBMeshes.SelectedItems
                            If Objekt = mesh.filename.name Then
                                Return mesh.ObjIds
                                Exit Function
                            End If
                        Next
                    Next
                End If
            End If
        End If
        Dim temlist As New List(Of Int16)
        temlist.Add(0)
        Return temlist
    End Function

    '####################
    'Eigenschaften Panel
    '####################


    '### Panelfunktionen ###
    Private Sub PanelEigenschaften_MouseDown(sender As Object, e As MouseEventArgs) Handles PanelEigenschaften.MouseDown
        movePanelEigenschaften = True
    End Sub

    Private Sub PanelEigenschaften_MouseMove(sender As Object, e As MouseEventArgs) Handles PanelEigenschaften.MouseMove
        If movePanelEigenschaften Then
            Dim ctl As Control = CType(PanelEigenschaften, Control)
            ctl.Location = PointToClient(Cursor.Position - New Point(ctl.Width \ 2, 30))
        End If
    End Sub

    Private Sub PanelEigenschaften_MouseUp(sender As Object, e As MouseEventArgs) Handles PanelEigenschaften.MouseUp
        checkPanelPosition(PanelEigenschaften)
        savePositions()
        movePanelEigenschaften = False
    End Sub

    Private Sub BTPanelEingenschaftenClose_Click(sender As Object, e As EventArgs) Handles BTPanelEingenschaftenClose.Click
        PanelEigenschaften.Visible = False
        savePositions()
    End Sub


    Private Sub LBEingenschaften_MouseDown(sender As Object, e As MouseEventArgs) Handles LBEingenschaften.MouseDown
        movePanelEigenschaften = True
    End Sub


    Private Sub LBEingenschaften_MouseUp(sender As Object, e As MouseEventArgs) Handles LBEingenschaften.MouseUp
        checkPanelPosition(PanelEigenschaften)
        savePositions()
        movePanelEigenschaften = False
    End Sub

    Private Sub LBEingenschaften_MouseMove(sender As Object, e As MouseEventArgs) Handles LBEingenschaften.MouseMove
        PanelEigenschaften_MouseMove(sender, e)

    End Sub

    Private Sub BTEigenschafteResize_MouseDown(sender As Object, e As MouseEventArgs) Handles BTEigenschafteResize.MouseDown
        PanelEigenschaften_height = PanelEigenschaften.Height
        resizePanelEigenschaften = True
        BTEigenschafteResize.Height = 0
    End Sub

    Private Sub BTEigenschafteResize_MouseMove(sender As Object, e As MouseEventArgs) Handles BTEigenschafteResize.MouseMove
        If resizePanelEigenschaften Then
            Dim y As Integer = e.Y + PanelEigenschaften_height
            If y < 300 Then
                y = 300
            Else
                If y + PanelEigenschaften.Top + 5 > GlMain.Height Then
                    y = GlMain.Height - PanelEigenschaften.Top - 5
                Else
                    y = e.Y + PanelEigenschaften_height
                End If
            End If

            PanelEigenschaften.Height = y
            PanelEigenschaften1.Height = y - 28
        End If
    End Sub

    Private Sub BTEigenschafteResize_MouseUp(sender As Object, e As MouseEventArgs) Handles BTEigenschafteResize.MouseUp
        resizePanelEigenschaften = False
        PanelEigenschaften_height = 0
        BTEigenschafteResize.Top = PanelEigenschaften.Height - 3
        BTEigenschafteResize.Height = 3
        savePositions()
    End Sub

    Private Sub BTEigenschafteResize_Leave(sender As Object, e As EventArgs) Handles BTEigenschafteResize.Leave
        resizePanelEigenschaften = False
        PanelEigenschaften_height = 0
        BTEigenschafteResize.Top = PanelEigenschaften.Height - 3
        BTEigenschafteResize.Height = 3
        savePositions()
    End Sub

    Private Sub GBMinMaxButton(sender As Object, GB As GroupBox)
        If sender.text = "+" Then
            sender.text = "-"
            GB.Height = sender.tag
            GB.BackColor = Color.White
        Else
            sender.text = "+"
            sender.tag = GB.Height
            GB.Height = 19
            GB.BackColor = Form.DefaultBackColor
        End If

        Dim tempGBList As New List(Of GroupBox)
        Dim top As Integer = GBAllgemein.Height + GBAllgemein.Top + 6
        For i = 0 To PanelEigenschaften1.Controls.Count - 1
            Dim minTop As Integer = Height + 500
            For Each control In PanelEigenschaften1.Controls
                If control.visible Then
                    If Not tempGBList.Contains(control) Then
                        If control.top < minTop Then
                            minTop = control.top
                        End If
                    End If
                End If
            Next
            For Each control In PanelEigenschaften1.Controls
                If control.top = minTop Then
                    tempGBList.Add(control)
                    Exit For
                End If
            Next
        Next

        For Each control In tempGBList
            If Not control.Text = "Allgemein" Then
                If control.Visible Then
                    control.Top = top
                    top += control.Height + 6
                End If
            End If
        Next
    End Sub

    Private Sub MeshMinMax_Click(sender As Object, e As EventArgs) Handles Mesh_MinMax.Click
        GBMinMaxButton(sender, GBMesh)
    End Sub

    Private Sub Parent_MinMax_Click(sender As Object, e As EventArgs) Handles Parent_MinMax.Click
        GBMinMaxButton(sender, GBParent)
    End Sub

    Private Sub Licht_MinMax_Click(sender As Object, e As EventArgs) Handles Licht_MinMax.Click
        GBMinMaxButton(sender, GBLicht)
    End Sub

    Private Sub Bones_MinMax_Click(sender As Object, e As EventArgs) Handles Bones_MinMax.Click
        GBMinMaxButton(sender, GBBones)
    End Sub

    Private Sub Spline_MinMax_Click(sender As Object, e As EventArgs) Handles Spline_MinMax.Click
        GBMinMaxButton(sender, GBSpline)
    End Sub

    Private Sub Pfad_MinMax_Click(sender As Object, e As EventArgs) Handles Pfad_MinMax.Click
        GBMinMaxButton(sender, GBPfad)
    End Sub

    Private Sub Achse_MinMax_Click(sender As Object, e As EventArgs) Handles Achse_MinMax.Click
        GBMinMaxButton(sender, GBAchse)
    End Sub

    Private Sub Kamera_MinMax_Click(sender As Object, e As EventArgs) Handles Kamera_MinMax.Click
        GBMinMaxButton(sender, GBKamera)
    End Sub

    Private Sub Kupplung_MinMax_Click(sender As Object, e As EventArgs) Handles Kupplung_MinMax.Click
        GBMinMaxButton(sender, GBKupplPnt)
    End Sub

    Private Sub Pfade_MinMax_Click(sender As Object, e As EventArgs) Handles Pfade_MinMax.Click
        GBMinMaxButton(sender, GBPfade)
    End Sub

    Private Sub Rauch_MinMax_Click(sender As Object, e As EventArgs) Handles Rauch_MinMax.Click
        GBMinMaxButton(sender, GBRauch)
    End Sub

    Private Sub Mat_MinMax_Click(sender As Object, e As EventArgs) Handles Mat_MinMax.Click
        GBMinMaxButton(sender, GBMat)
    End Sub

    Private Sub Anim_MinMax_Click(sender As Object, e As EventArgs) Handles Anim_MinMax.Click
        GBMinMaxButton(sender, GBAnimation)
    End Sub

    Private Sub SplineHelper_MinMax_Click(sender As Object, e As EventArgs) Handles SplineHelper_MinMax.Click
        GBMinMaxButton(sender, GBSplineHelper)
    End Sub

    Private Sub Platz_MinMax_Click(sender As Object, e As EventArgs) Handles Platz_MinMax.Click
        GBMinMaxButton(sender, GBPlatz)
    End Sub

    Private Sub Bel_MinMax_Click(sender As Object, e As EventArgs) Handles Bel_MinMax.Click
        GBMinMaxButton(sender, GBBel)
    End Sub

    Private Sub BBox_MinMax_Click(sender As Object, e As EventArgs) Handles BBox_MinMax.Click
        GBMinMaxButton(sender, GBBbox)
    End Sub


    '### Panel Allgemein ###
    Private Sub TBName_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs) Handles TBName.KeyPress

    End Sub

    Private Sub PSPos_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs) Handles PSPos.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then '-> Tab geht nicht!
            Select Case TCObjekte.SelectedIndex
                Case 1
                    Dim helperSelection As String
                    If TVHelper.SelectedNode.FullPath.Contains("\") Then
                        helperSelection = TVHelper.SelectedNode.FullPath.Split("\")(0)
                    Else
                        helperSelection = TVHelper.SelectedNode.FullPath
                    End If

                    Select Case helperSelection
                        Case TVHelper.Nodes(0).Text       'Achsen
                            If Not getSelectedAchse() Is Nothing Then
                                If sender.name = "TBX" Then sender.text = "0.000"
                                If sender.name = "TBY" Then getSelectedAchse.Y = PSPos.Y
                                If sender.name = "TBZ" Then
                                    getSelectedAchse.raddurchmesser = PSPos.Z * 2
                                    Achse_TBDurchmesser.Text = PSPos.Z * 2
                                End If
                            End If

                        Case TVHelper.Nodes(1).Text     'Boundingbox
                            If Not actProj.bbox Is Nothing Then
                                actProj.bbox.pos = PSPos.Point
                            End If

                        Case TVHelper.Nodes(2).Text     'Kameras
                            If Not getSelectedKamera() Is Nothing Then
                                getSelectedKamera.position = New Point3D(PSPos.Point)
                            End If

                        Case TVHelper.Nodes(3).Text     'Kupplung
                            If TVHelper.SelectedNode.FullPath.Split("\")(1) = "Front" Then
                                actProj.couple_front_point = PSPos.Point
                            ElseIf TVHelper.SelectedNode.FullPath.Split("\")(1) = "Heck" Then
                                actProj.couple_back_point = PSPos.Point
                            End If

                        Case TVHelper.Nodes(6).Text     'Spiegel
                            If Not getSelectedSpiegel() Is Nothing Then
                                getSelectedSpiegel.position = PSPos.Point
                            End If

                        Case TVHelper.Nodes(11).Text    'Spot
                            If Not getSelectedSpot() Is Nothing Then
                                getSelectedSpot.position = New Point3D(PSPos.Point)
                            End If

                    End Select



                Case 2
                    If Not getSelectedLight() Is Nothing Then
                        getSelectedLight.position = PSPos.Point
                    End If
                Case 3
                    If LBPfade.SelectedIndex >= 0 Then
                        actProj.paths.pathPoints(LBPfade.SelectedIndex) = PSPos.Point
                        actProj.paths.recalc
                        doorsRecalc()
                    End If
            End Select
            GlMain.Invalidate()
        End If
    End Sub

    Private Sub PSPos_Changed(sender As Object, e As EventArgs) Handles PSPos.Changed

    End Sub


    '### Panel Material ###
    Private Sub Mat_TBColorR_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs)
        e.Handled = NumbersOnly(e)
    End Sub

    Private Sub Mat_TBColorG_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs)
        e.Handled = NumbersOnly(e)
    End Sub

    Private Sub Mat_TBColorB_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs)
        e.Handled = NumbersOnly(e)
    End Sub


    '### Panel Mesh ###
    Private Sub TBCenterX_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs)
        e.Handled = NumbersOnly(e, sender, True)
    End Sub

    Private Sub TBCenterY_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs)
        e.Handled = NumbersOnly(e, sender, True)
    End Sub

    Private Sub TBCenterZ_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs)
        e.Handled = NumbersOnly(e, sender, True)
    End Sub

    Private Sub TBPosX_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs)
        e.Handled = NumbersOnly(e, sender, True)
    End Sub

    Private Sub TBPosY_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs)
        e.Handled = NumbersOnly(e, sender, True)
    End Sub

    Private Sub TBPosZ_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs)
        e.Handled = NumbersOnly(e, sender, True)
    End Sub

    Private Sub Mesh_TBSichtbarkeitVal_Leave(sender As Object, e As EventArgs) Handles Mesh_TBSichtbarkeitVal.Leave
        If Not IsNumeric(Mesh_TBSichtbarkeitVal.Text) Then
            Mesh_TBSichtbarkeitVal.Text = "0"
        End If
        getSelectedMesh.visibleInt = Mesh_TBSichtbarkeitVal.Text
    End Sub

    Private Sub Mesh_VSKlickevent_Changed(sender As Object, e As EventArgs) Handles Mesh_VSKlickevent.Changed
        getSelectedMesh.mouseEvent = Mesh_VSKlickevent.Variable
    End Sub

    Private Sub Mesh_VSSichtbarkeit_Changed(sender As Object, e As EventArgs) Handles Mesh_VSSichtbarkeit.Changed
        getSelectedMesh.visibleVar = Mesh_VSSichtbarkeit.Variable
    End Sub


    '### Panel Parent ###


    '### Panel Licht ###

    Private Sub Licht_TBTexture_Click(sender As Object, e As EventArgs) Handles Licht_TBTexture.Click
        activeImageSelector = sender
        PanelTexture.Location = New Point(Convert.ToInt16(GlMain.Width / 2 - PanelTexture.Width / 2), Convert.ToInt16(GlMain.Height / 2 - PanelTexture.Height / 2))
        PanelTexture.Visible = True
        BTTexOkay.Visible = True
    End Sub

    Private Sub Licht_CSFarbe_Changed(sender As Object, e As EventArgs) Handles Licht_CSFarbe.Changed
        If Not getSelectedLight() Is Nothing Then
            getSelectedLight.color = Licht_CSFarbe.SelectedColor
        End If
    End Sub

    '### Panel Spot ###

    Public Function getSelectedSpot() As OMSI_Spot
        If actProj Is Nothing Then Return Nothing
        If getProjType() = Proj_Bus.TYPE Or getProjType() = Proj_Ovh.TYPE Then
            If TVHelper.SelectedNode.FullPath.Contains(TVHelper.Nodes(11).Text & "\") Then
                If TVHelper.SelectedNode.Index < actProj.model.spots.Count Then
                    If TVHelper.SelectedNode.Index > -1 Then
                        Return actProj.model.spots(TVHelper.SelectedNode.Index)
                    End If
                End If
            End If
        End If
        Return Nothing
    End Function

    Private Sub Spot_CSFarbe_ColorChanged(sender As Object, e As EventArgs) Handles Spot_CSFarbe.ColorChanged
        If Not getSelectedSpot() Is Nothing Then
            getSelectedSpot.color = Spot_CSFarbe.SelectedColor
        End If
    End Sub

    Private Sub Spot_PSRichtung_Changed(sender As Object, e As EventArgs) Handles Spot_PSRichtung.Changed
        If Not getSelectedSpot() Is Nothing Then
            getSelectedSpot.richtung = Spot_PSRichtung.Point
        End If
    End Sub

    Private Sub Spot_TBAussen_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs) Handles Spot_TBAussen.KeyPress
        If Helper.NumbersOnly(e, sender, True, Double.MinValue, Double.MaxValue) Then
            If Not getSelectedSpot() Is Nothing Then
                getSelectedSpot.outerCone = Spot_TBAussen.Text
            End If
            e.Handled = True
        End If
    End Sub

    Private Sub Spot_TBInner_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs) Handles Spot_TBInner.KeyPress
        If Helper.NumbersOnly(e, sender, True, Double.MinValue, Double.MaxValue) Then
            If Not getSelectedSpot() Is Nothing Then
                getSelectedSpot.innerCone = Spot_TBInner.Text
            End If
            e.Handled = True
        End If
    End Sub

    Private Sub Spot_TBLeuchtweite_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs) Handles Spot_TBLeuchtweite.KeyPress
        If Helper.NumbersOnly(e, sender, True, Double.MinValue, Double.MaxValue) Then
            If Not getSelectedSpot() Is Nothing Then
                getSelectedSpot.range = Spot_TBLeuchtweite.Text
            End If
            e.Handled = True
        End If
    End Sub


    '### Panel Timeline ###

    Private Sub PanelTimeline_MouseDown(sender As Object, e As MouseEventArgs) Handles PanelTimeline.MouseDown
        movePanelTimeline = True
    End Sub

    Private Sub PanelTimeline_MouseUp(sender As Object, e As MouseEventArgs) Handles PanelTimeline.MouseUp
        checkPanelPosition(PanelTimeline)
        savePositions()
        movePanelTimeline = False
    End Sub

    Private Sub PanelTimeline_MouseMove(sender As Object, e As MouseEventArgs) Handles PanelTimeline.MouseMove
        If movePanelTimeline Then
            Dim ctl As Control = CType(PanelTimeline, Control)
            ctl.Location = PointToClient(Cursor.Position - New Point(ctl.Width \ 2, 30))
        End If
    End Sub

    Private Sub BTPanelTimelineClose_Click(sender As Object, e As EventArgs) Handles BTPanelTimelineClose.Click
        PanelTimeline.Visible = Not PanelTimeline.Visible
        savePositions()
    End Sub

    Private Sub PanelTimeline_Resize(sender As Object, e As EventArgs) Handles PanelTimeline.Resize
        BTPanelTimelineClose.Left = PanelTimeline.Width - 22
    End Sub


    '################
    '3D-Panel
    '################
    Private Sub GlMain_MouseDown(sender As Object, e As MouseEventArgs) Handles GlMain.MouseDown
        If e.Button = MouseButtons.Middle Then
            tempPos2D = New Point(mausPos2D.X - e.X, mausPos2D.Y - e.Y)
            temMousePos = New Point(e.Location.X, e.Location.Y)
            If mainShift Then CamLocationOld = New Point3D(CamLocation)
            If mainStrg Then scale3DOld = scale3D
            rotateObjekt = True
        End If
    End Sub

    Private Sub GlMain_MouseUp(sender As Object, e As MouseEventArgs) Handles GlMain.MouseUp
        rotateObjekt = False
    End Sub

    Private Sub GlMain_MouseMove(sender As Object, e As MouseEventArgs) Handles GlMain.MouseMove
        If rotateObjekt Then
            If mainShift Then
                CamLocation.Z = CamLocationOld.Z - ((e.Y - temMousePos.Y) * 0.02)
                CamLocation.X = CamLocationOld.X + ((e.X - temMousePos.X) * 0.02) * Math.Cos((mausPos2D.X + 225) / 180 * Math.PI)
                'CamLocation.Y = CamLocationOld.Y - ((e.X - temMousePos.X) * 0.02) * Math.Sin((mausPos2D.X + 225) / 180 * Math.PI)
            Else
                If mainStrg Then
                    scale3D = scale3DOld - ((e.Y + temMousePos.Y) * 0.02)
                    If scale3D < 0.5 Then scale3D = 0.5
                Else
                    mausPos2D = New Point(e.X + tempPos2D.X, e.Y + tempPos2D.Y)
                End If
            End If
            'SSLBStatus.Text = (Math.Sin((mausPos2D.X - 225) / 180 * Math.PI) * -1)
            GlMain.Invalidate()
        End If
    End Sub

    Private Sub GlMain_MouseWheel(sender As Object, e As MouseEventArgs) Handles GlMain.MouseWheel
        scale3D = scale3D - e.Delta * 0.003
        If scale3D < 0.5 Then scale3D = 0.5
        GlMain.Invalidate()
    End Sub

    Private Sub GlMain_MouseClick(sender As Object, e As MouseEventArgs) Handles GlMain.MouseClick
        'Glu.unprojet(sender.x, sender.y) '-> oder so... um den "ray" in der Szene zu finden und jedes Objekt auf Kollision testen!
        'Selbst machen und anhand der Projektionsmatrix den ray selbst berechnen und testweise einzeichnen
    End Sub


    'Wichtig sonst funktionieren die Pfeiltasten nicht!
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        If ActiveControl Is GlMain Then
            If viewPoint = 1 Or viewPoint = 2 Then
                If keyData = Keys.Left Then
                    GlMain_KeyDown(GlMain, New KeyEventArgs(Keys.Left))
                    Return True
                ElseIf keyData = Keys.Right Then
                    GlMain_KeyDown(GlMain, New KeyEventArgs(Keys.Right))
                    Return True
                End If
            End If
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Private Sub GlMain_KeyDown(sender As Object, e As KeyEventArgs) Handles GlMain.KeyDown, LBMeshes.KeyDown
        If e.KeyCode = Keys.NumPad5 Then
            If Settings.OrtoScale = 3 Then
                Settings.OrtoScale = 4
            Else
                Settings.OrtoScale = 3
            End If
            Settings.Save()
            Settings.Load()
            GlMain.Invalidate()
        End If


        Select Case e.KeyCode
            Case Keys.NumPad1
                mausPos2D = New Point(225, -207)
                GlMain.Invalidate()
            Case Keys.NumPad3
                mausPos2D = New Point(675, -207)
                GlMain.Invalidate()
            Case Keys.NumPad7
                mausPos2D = New Point(225, 243)
                GlMain.Invalidate()
            Case Keys.NumPad0
                mausPos2D = New Point(0, 0)
                GlMain.Invalidate()

            Case Keys.A
                LBMeshes.SelectedIndex = -1
                GlMain.Invalidate()
                selectedMesh = Nothing
                selectedMeshes = Nothing
            Case Keys.H
                hideTemp(LBMeshes.SelectedIndex)

            Case Keys.Up
                If e.Control Then
                    swapMeshOrder(LBMeshes.SelectedIndex, LBMeshes.SelectedIndex - 1)
                    e.Handled = True
                End If

            Case Keys.Down
                If e.Control Then
                    swapMeshOrder(LBMeshes.SelectedIndex, LBMeshes.SelectedIndex + 1)
                    e.Handled = True
                End If

            Case Keys.Right
                If viewPoint = 1 Then
                    selectedDriverCam += 1
                    If selectedDriverCam > actProj.driver_cam_list.Count - 1 Then selectedDriverCam = 0
                ElseIf viewPoint = 2 Then
                    selectedPassCam += 1
                    If selectedPassCam > actProj.pax_cam_list.Count - 1 Then selectedPassCam = 0
                End If
                GlMain.Invalidate()
            Case Keys.Left
                If viewPoint = 1 Then
                    selectedDriverCam -= 1
                    If selectedDriverCam < 0 Then selectedDriverCam = actProj.driver_cam_list.Count - 1
                ElseIf viewPoint = 2 Then
                    selectedPassCam -= 1
                    If selectedPassCam < 0 Then selectedPassCam = actProj.pax_cam_list.Count - 1
                End If
                GlMain.Invalidate()
            Case Else
                'für Mausbewegung
                mainShift = e.Shift
                mainStrg = e.Control
        End Select
    End Sub

    Private Sub swapMeshOrder(oldIndex As Integer, newIndex As Integer)
        If newIndex >= 0 And oldIndex >= 0 And LBMeshes.Items.Count > 0 Then
            If newIndex > LBMeshes.Items.Count - 1 Then newIndex = LBMeshes.Items.Count - 1
            Dim newStep As Integer = 1
            If newIndex < oldIndex Then newStep = -1
            For meshCt As Integer = oldIndex To newIndex - newStep Step newStep
                Dim tmpOldIndex As Integer = meshCt
                Dim tmpNewIndex As Integer = meshCt + newStep
                With actProj.model
                    Dim tempMesh As OMSI_Mesh = .meshes(tmpOldIndex)
                    .meshes(tmpOldIndex) = .meshes(tmpNewIndex)
                    LBMeshes.Items(tmpOldIndex) = .meshes(tmpOldIndex).filename.name

                    .meshes(tmpNewIndex) = tempMesh
                    LBMeshes.Items(tmpNewIndex) = .meshes(tmpNewIndex).filename.name
                End With
            Next
            LBMeshes.SelectedIndex = newIndex
        End If
    End Sub

    Private Sub hideTemp(index As Integer)
        If index > -1 Then
            If LBMeshes.GetItemCheckState(index) Then
                LBMeshes.SetItemCheckState(index, CheckState.Unchecked)
            Else
                LBMeshes.SetItemCheckState(index, CheckState.Checked)
            End If
        End If
        GlMain.Invalidate()
    End Sub

    Private Sub Frm_Main_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        GlMain_KeyDown(sender, e)
    End Sub

    Private Sub GlMain_KeyUp(sender As Object, e As KeyEventArgs) Handles GlMain.KeyUp
        'für Mausbewegung
        mainShift = e.Shift
        mainStrg = e.Control
    End Sub

    Private Sub Bel_BTKeine_Click(sender As Object, e As EventArgs) Handles Bel_BTKeine.Click
        Bel_CB0.SelectedIndex = 0
        Bel_CB1.SelectedIndex = 0
        Bel_CB2.SelectedIndex = 0
        Bel_CB3.SelectedIndex = 0
    End Sub



    '##############
    '3D-Teil
    '##############


    Private Sub GlMain_Load(sender As Object, e As EventArgs) Handles GlMain.Load
        GL.ClearColor(Settings.BackColor3D)
        GL.Enable(EnableCap.DepthTest) 'Enable correct Z Drawings
        GL.DepthFunc(DepthFunction.Less) 'Enable correct Z Drawings

        GL.Enable(EnableCap.Texture2D)
        GL.Enable(EnableCap.Blend)
        GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha)

        GL.EnableClientState(ArrayCap.VertexArray)
        GL.EnableClientState(ArrayCap.TextureCoordArray)
        'GL.Enable(EnableCap.ColorMaterial)
        GL.PolygonMode(MaterialFace.Front, PolygonMode.Line)

        GlLoaded = True
    End Sub


    Dim last_draw As Long = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()
    Private Sub GlMain_Paint(sender As Object, e As PaintEventArgs, Optional mirrorRender As Boolean = False, Optional mirrorID As Integer = 0) Handles GlMain.Paint
        If Not GlLoaded Then Exit Sub

        'FPS Limiter
        If Not mirrorRender Then
            If DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() - last_draw < 1000 / Settings.fpsLimit Then Exit Sub
            last_draw = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()
        End If

        GL.Clear(ClearBufferMask.ColorBufferBit)
        GL.Clear(ClearBufferMask.DepthBufferBit)
        GL.Clear(ClearBuffer.Color)

        'Basic Setup for viewing
        Dim perspective As Matrix4 = Matrix4.CreatePerspectiveFieldOfView(1.04, Convert.ToSingle(GlMain.Width / GlMain.Height), 0.2, 10000) 'Setup Perspective
        Dim lookat As Matrix4 = Matrix4.LookAt(Convert.ToSingle(scale3D), Convert.ToSingle(scale3D / 5), 0, 0, 0, 0, 0, 1, 0) 'Setup camera
        GL.MatrixMode(MatrixMode.Projection) 'Load Perspective
        GL.LoadIdentity()
        GL.LoadMatrix(perspective)
        GL.MatrixMode(MatrixMode.Modelview) 'Load Camera
        GL.LoadIdentity()
        GL.ClearColor(Settings.BackColor3D)
        GL.LoadMatrix(lookat)
        GL.Viewport(0, 0, GlMain.Width, GlMain.Height) 'Size of window


        'Offset der Kamera zum Mittelpunkt der Szene
        If getProjType() = Proj_Bus.TYPE And viewPoint < 3 Then
            lookat = Matrix4.LookAt(Convert.ToSingle(0.0000001), Convert.ToSingle(0.000001), 0, 0, 0, 0, 0, 1, 0) 'Setup camera
            GL.LoadMatrix(lookat)
            If viewPoint = 1 Then
                With actProj.driver_cam_list(selectedDriverCam)
                    'Spiegelberechnung nur in der Fahreransicht
                    If mirrorRender Then
                        With actProj.spiegel(1) 'mirrorID
                            GL.Translate(New Vector3(- .position.X, - .position.Y, - .position.Z))
                            'GL.Translate(New Vector3(-1, 0, 0))
                            'GL.Rotate(-(.rotX - 90), 0, 1, 0)
                            'GL.Rotate(-(.rotY + 90), 0, 0, 1)


                            'GL.Translate(New Vector3(0, -6, -2))
                            GL.Rotate(90 + .rotY, 0, 0, 1)
                            GL.Rotate(90, 0, 1, 0)

                        End With
                    Else
                        For i As Integer = 0 To actProj.spiegel.Count - 1
                            GlMain_Paint(GlMain, Nothing, True, i)

                            With actProj.spiegel(1) 'i

                                GL.Rotate(-90, 0, 1, 0) '-90
                                GL.Rotate(-(.rotY + 90), 0, 0, 1) '45
                                'GL.Translate(New Vector3(0, 6, 2))

                                'GL.Rotate(.rotY + 90, 0, 0, 1)
                                'GL.Rotate(.rotX - 90, 0, 1, 0)
                                'GL.Translate(New Vector3(1, 0, 0))
                                GL.Translate(New Vector3(.position.X, .position.Y, .position.Z))

                            End With
                        Next

                        GL.Rotate(.rotY + 90, 0, 0, 1)
                        GL.Rotate(.rotX - 90, 0, 1, 0)

                        GL.Translate(New Vector3(actProj.position.X, actProj.position.Y, actProj.position.Z))
                    End If


                End With
            ElseIf viewPoint = 2 Then
                With actProj.pax_cam_list(selectedPassCam)
                    GL.Rotate(.rotY + 90, 0, 0, 1)
                    GL.Rotate(.rotX - 90, 0, 1, 0)
                    GL.Translate(New Vector3(actProj.position.X, actProj.position.Y, actProj.position.Z))
                End With
            End If
        Else
            'Mouse Rotating Y befor Global
            GL.Rotate(mausPos2D.Y * 0.2, 0, 0, -1)

            'Rotating Global
            GL.Rotate(-30, 0, 0, 1)
            GL.Rotate(135, 0, 1, 0)

            'Mouse Rotating X after Global
            GL.Rotate(mausPos2D.X * 0.2, 0, 1, 0)
            Select Case viewPoint
                Case 3
                    If getProjType() = Proj_Bus.TYPE Then
                        GL.Translate(New Vector3(actProj.cam_outeside.X, actProj.cam_outeside.Y, actProj.cam_outeside.Z))
                    End If
                Case 4
                    GL.Translate(New Vector3(CamLocation.X, CamLocation.Z, CamLocation.Y))
            End Select

        End If



        If Settings.GitterV Then
            GL.BindTexture(TextureTarget.Texture2D, 0)
            GL.Begin(PrimitiveType.Lines)
            GL.Color3(Settings.LineColor3D)

            For i As Integer = -10 To 10
                If i = 0 Then GL.Color3(Color.Green) Else GL.Color3(Settings.LineColor3D)
                GL.Vertex3(i, 0, -10)
                GL.Vertex3(i, 0, 10)
                If i = 0 Then GL.Color3(Color.Red) Else GL.Color3(Settings.LineColor3D)
                GL.Vertex3(-10, 0, i)
                GL.Vertex3(10, 0, i)
            Next i
            GL.End()
        End If






        If ModelLoaded Then
            GL.DepthFunc(DepthFunction.Less)        'Tiefenkorrektur einschalten (ist für Helfer abgeschaltet)
            For Each objekt In getOCTProj.alleMeshes
                drawL3D(objekt)
            Next
        End If


        If getProjType() = Proj_Emt.TYPE Then
            Select Case TCObjekte.SelectedIndex
                Case 0
                Case 1
                    drawCabin(actProj.cabin)
                Case 2
                    If getProjType() = Proj_Emt.TYPE Then
                        GL.BindTexture(TextureTarget.Texture2D, 0)
                        Dim i As Integer = 0
                        For Each licht In actProj.model.lichter
                            With licht
                                GL.Color3(.color.R, .color.G, .color.B)
                                If i = LBLichter.SelectedIndex Then
                                    If timerBool Then
                                        GL.Color3(Color.Black)
                                    End If
                                End If

                                GL.VertexPointer(3, VertexPointerType.Double, 0, .vertices)
                                GL.DrawElements(PrimitiveType.TriangleFan, .edges.GetUpperBound(0), DrawElementsType.UnsignedInt, .edges)
                            End With
                            i += 1
                        Next
                    End If
                Case 3
                    drawPaths(actProj.paths)
            End Select



            '################
            ' Sceneryobjekte
            '################
        ElseIf getProjType() = Proj_Sco.TYPE Then
            If actProj.isloaded Then
                With actProj
                    GL.LineWidth(3)
                    GL.BindTexture(TextureTarget.Texture2D, 0)
                    GL.DepthFunc(DepthFunction.Always)              'Alles wird in den Vordergrund gezeichnet
                    GL.LineWidth(1)

                    Select Case TCObjekte.SelectedIndex
                        Case 0
                        Case 1

                            If Not .cabin Is Nothing Then
                                For Each seat In .cabin.passPos
                                    GL.Color3(Settings.PaxColor)

                                    GL.VertexPointer(3, VertexPointerType.Double, 0, seat.vertices)
                                    GL.DrawElements(PrimitiveType.Triangles, seat.edges.GetUpperBound(0), DrawElementsType.UnsignedInt, seat.edges)
                                    GL.Color3(Color.Black)
                                    GL.DrawElements(PrimitiveType.Lines, seat.lines.GetUpperBound(0), DrawElementsType.UnsignedInt, seat.lines)
                                Next
                            End If

                            For Each attPnt In .attachPnts
                                GL.Color3(Settings.AchsenColor)
                                GL.VertexPointer(3, VertexPointerType.Double, 0, attPnt.vertices)
                                GL.DrawElements(PrimitiveType.Triangles, attPnt.edges.GetUpperBound(0), DrawElementsType.UnsignedInt, attPnt.edges)
                            Next

                        Case 2
                            GL.BindTexture(TextureTarget.Texture2D, 0)
                            Dim i As Integer = 0
                            For Each licht In .model.lichter
                                With licht
                                    GL.Color3(.color.R, .color.G, .color.B)
                                    If i = LBLichter.SelectedIndex Then
                                        If timerBool Then
                                            GL.Color3(Color.Black)
                                        End If
                                    End If

                                    GL.VertexPointer(3, VertexPointerType.Double, 0, .vertices)
                                    GL.DrawElements(PrimitiveType.Triangles, .edges.GetUpperBound(0), DrawElementsType.UnsignedInt, .edges)
                                End With
                                i += 1
                            Next
                        Case 3
                            If Not .ki_paths Is Nothing Then
                                Dim i As Integer = 0
                                For Each path In .ki_paths
                                    If LBPfade.SelectedIndex = i Then
                                        GL.Color3(Settings.SelectionColor)
                                    End If
                                    With path
                                        GL.VertexPointer(3, VertexPointerType.Double, 0, .vertices)
                                        GL.DrawElements(PrimitiveType.Lines, .edges.GetUpperBound(0), DrawElementsType.UnsignedInt, .edges)
                                    End With
                                    GL.Color3(Color.Black)
                                    i += 1
                                Next
                            End If
                    End Select
                End With
            End If

            '################
            ' Fahrzeuge
            '################
        ElseIf getProjType() = Proj_Bus.TYPE Or getProjType() = Proj_Ovh.TYPE Then
            GL.LineWidth(3)
            GL.BindTexture(TextureTarget.Texture2D, 0)
            GL.DepthFunc(DepthFunction.Always)              'Alles wird in den Vordergrund gezeichnet
            With actProj
                Select Case TCObjekte.SelectedIndex
                    Case 0
                        If Not .model Is Nothing Then
                            If Not getSelectedMesh() Is Nothing Then
                                For i As Integer = 0 To getSelectedMesh.animations.Count - 1
                                    With getSelectedMesh.animations(i)
                                        If i = Anim_DDList.SelectedIndex Then
                                            GL.Color3(Settings.SelectionColor)
                                        Else
                                            GL.Color3(Settings.AchsenColor)
                                        End If
                                        GL.VertexPointer(3, VertexPointerType.Double, 0, .vertices)
                                        GL.DrawElements(PrimitiveType.Lines, .edges.GetUpperBound(0), DrawElementsType.UnsignedInt, .edges)
                                    End With
                                Next
                            End If
                        End If
                    Case 1
                        If Not .model Is Nothing Then
                            GL.VertexPointer(3, VertexPointerType.Double, 0, {0, 0, 0})
                            GL.TexCoordPointer(2, TexCoordPointerType.Double, 0, {0, 0})
                            For index As Integer = 0 To .driver_cam_list.Count - 1
                                GL.Color3(Settings.CamDriverColor)
                                If TVHelper.SelectedNode.FullPath.Contains("Fahrerkameras\") And index = TVHelper.SelectedNode.Index Then GL.Color3(Settings.SelectionColor)
                                With .driver_cam_list(index)
                                    GL.VertexPointer(3, VertexPointerType.Double, 0, .vertices)
                                    GL.DrawElements(PrimitiveType.Lines, .edges.GetUpperBound(0), DrawElementsType.UnsignedInt, .edges)
                                End With
                            Next


                            For i As Integer = 0 To .pax_cam_list.Count - 1
                                GL.Color3(Settings.CamPaxColor)
                                If TVHelper.SelectedNode.FullPath.Contains("Fahrgastkameras\") And i = TVHelper.SelectedNode.Index Then GL.Color3(Settings.SelectionColor)
                                With .pax_cam_list(i)
                                    GL.VertexPointer(3, VertexPointerType.Double, 0, .vertices)
                                    GL.DrawElements(PrimitiveType.Lines, .edges.GetUpperBound(0), DrawElementsType.UnsignedInt, .edges)
                                End With
                            Next

                            If .couple_back Then
                                GL.Color3(Settings.AchsenColor)
                                If TVHelper.SelectedNode.FullPath.Contains("Kupplungspunkte\") Then GL.Color3(Settings.SelectionColor)
                                If Not .couple_back_sphere Is Nothing Then
                                    With .couple_back_sphere
                                        GL.VertexPointer(3, VertexPointerType.Double, 0, .vertices)
                                        GL.DrawElements(PrimitiveType.Lines, .edges.GetUpperBound(0), DrawElementsType.UnsignedInt, .edges)
                                    End With
                                End If
                            End If


                            For i As Integer = 0 To .achsen.Count - 1
                                GL.Color3(Settings.AchsenColor)
                                If InStr(TVHelper.SelectedNode.FullPath, "Achsen\") And i = TVHelper.SelectedNode.Index Then GL.Color3(Settings.SelectionColor)
                                With .achsen(i)
                                    GL.VertexPointer(3, VertexPointerType.Double, 0, .vertices)
                                    GL.DrawElements(PrimitiveType.Lines, .edges.GetUpperBound(0), DrawElementsType.UnsignedInt, .edges)
                                End With
                            Next


                            For i As Integer = 0 To .spiegel.Count - 1
                                GL.Color3(Settings.CamReflexColor)
                                If TVHelper.SelectedNode.FullPath.Contains("Spiegel\") And i = TVHelper.SelectedNode.Index Then GL.Color3(Settings.SelectionColor)
                                With .spiegel(i)
                                    GL.VertexPointer(3, VertexPointerType.Double, 0, .vertices)
                                    GL.DrawElements(PrimitiveType.Lines, .edges.GetUpperBound(0), DrawElementsType.UnsignedInt, .edges)
                                End With
                            Next


                            If Not .bbox Is Nothing Then
                                With .bbox
                                    GL.Color3(Color.Black)
                                    GL.VertexPointer(3, VertexPointerType.Double, 0, .vertices)
                                    GL.DrawElements(PrimitiveType.Lines, .edges.GetUpperBound(0), DrawElementsType.UnsignedInt, .edges)
                                End With
                            End If

                            GL.DepthFunc(DepthFunction.Less)    'Im Vordergrund Zeichnen abschalten
                            If Not .model.spots Is Nothing Then
                                If InStr(TVHelper.SelectedNode.FullPath, TVHelper.Nodes(11).Text & "\") Then
                                    If TVHelper.SelectedNode.Index < .model.spots.Count Then
                                        With .model.spots(TVHelper.SelectedNode.Index)
                                            GL.Color3(.color.R, .color.G, .color.B)
                                            GL.VertexPointer(3, VertexPointerType.Double, 0, .vertices)
                                            GL.DrawElements(PrimitiveType.Triangles, .edges.GetUpperBound(0), DrawElementsType.UnsignedInt, .edges)
                                            GL.Color3(Color.Black)
                                            GL.DrawElements(PrimitiveType.LineLoop, .lines.GetUpperBound(0), DrawElementsType.UnsignedInt, .lines)
                                        End With
                                    End If
                                End If
                            End If
                        End If
                        GL.DepthFunc(DepthFunction.Less)    'Im Vordergrund Zeichnen abschalten

                        If getProjType() = Proj_Bus.TYPE Then
                            drawCabin(.cabin)
                        ElseIf getProjType() = Proj_Ovh.TYPE Then
                            drawCabin(.cabin)
                        End If

                    Case 2
                        GL.BindTexture(TextureTarget.Texture2D, 0)
                        Dim i As Integer = 0
                        For Each licht In .model.lichter
                            With licht
                                GL.Color3(.color.R, .color.G, .color.B)
                                If i = LBLichter.SelectedIndex Then
                                    If timerBool Then
                                        GL.Color3(Color.Black)
                                    End If
                                End If

                                GL.VertexPointer(3, VertexPointerType.Double, 0, .vertices)
                                GL.DrawElements(PrimitiveType.TriangleFan, .edges.GetUpperBound(0), DrawElementsType.UnsignedInt, .edges)
                            End With
                            i += 1
                        Next
                    Case 3
                        If getProjType() = Proj_Bus.TYPE Then
                            drawPaths(.paths)
                        ElseIf getProjType() = Proj_Ovh.TYPE Then
                            drawPaths(.paths)
                        End If
                End Select
            End With
        ElseIf getProjType() = Proj_Sli.TYPE Then

            '############################################################
            'Hier Darstellung Spline!
            '############################################################


        End If

        GL.LineWidth(1)


        If mirrorRender Then
            calcMirrors(mirrorID)
            GL.Clear(ClearBufferMask.ColorBufferBit)
            GL.Clear(ClearBufferMask.DepthBufferBit)
            GL.Clear(ClearBuffer.Color)
            Exit Sub
        End If


        'Finally...
        'GraphicsContext.CurrentContext.VSync = True
        GL.Flush()
        GL.PopMatrix()



        GlMain.SwapBuffers()

    End Sub

    Private Sub drawCabin(ByRef cabin As OMSI_Cabin)
        If Not cabin Is Nothing Then
            GL.LineWidth(1)
            For i As Integer = 0 To cabin.passPos.Count - 1
                With cabin.passPos(i)
                    GL.Color3(Settings.PaxColor)
                    If InStr(TVHelper.SelectedNode.FullPath, TVHelper.Nodes(7).Text & "\") Then
                        If TVHelper.SelectedNode.Index = i Then
                            GL.Color3(Settings.SelectionColor)
                        End If
                    End If
                    GL.VertexPointer(3, VertexPointerType.Double, 0, .vertices)
                    GL.DrawElements(PrimitiveType.Triangles, .edges.GetUpperBound(0), DrawElementsType.UnsignedInt, .edges)
                    GL.Color3(Color.Black)
                    GL.DrawElements(PrimitiveType.Lines, .lines.GetUpperBound(0), DrawElementsType.UnsignedInt, .lines)
                End With
            Next

            If Not cabin.driverPos Is Nothing Then
                With cabin.driverPos
                    GL.Color3(Settings.DriverColor)
                    GL.VertexPointer(3, VertexPointerType.Double, 0, .vertices)
                    GL.DrawElements(PrimitiveType.Triangles, .edges.GetUpperBound(0), DrawElementsType.UnsignedInt, .edges)
                    GL.Color3(Color.Black)
                    GL.DrawElements(PrimitiveType.Lines, .lines.GetUpperBound(0), DrawElementsType.UnsignedInt, .lines)
                End With
            End If
        End If
    End Sub

    Private Sub drawPaths(ByRef paths As OMSI_Paths)
        If Not paths Is Nothing Then
            With paths
                If .pathPoints.Count > 0 Then

                    GL.Color3(Color.Pink)
                    GL.VertexPointer(3, VertexPointerType.Double, 0, .vertices)
                    GL.DrawElements(PrimitiveType.Lines, .edges.GetUpperBound(0), DrawElementsType.UnsignedInt, .edges)

                    GL.Color3(Color.Black)
                    GL.PointSize(20)
                    GL.BindTexture(TextureTarget.Texture2D, 0) 'dotTexture.id)

                    For i = 0 To .dots.Count - 1
                        If i = LBPfade.SelectedIndex Then
                            GL.Color3(Settings.SelectionColor)
                        ElseIf InStr(GBPfade.Tag, ";" & i & ";") Then
                            GL.Color3(Color.Violet)
                        Else
                            GL.Color3(Color.Black)
                        End If
                        GL.VertexPointer(3, VertexPointerType.Double, 0, .dots(i).vertices)
                        GL.DrawElements(PrimitiveType.TriangleFan, .dots(i).lines.GetUpperBound(0), DrawElementsType.UnsignedInt, .dots(i).lines)
                    Next
                    GL.BindTexture(TextureTarget.Texture2D, 0)
                    GL.LineWidth(3)

                    For Each arrow In .arrows
                        GL.Color3(Color.Pink)
                        GL.VertexPointer(3, VertexPointerType.Double, 0, arrow.vertices)
                        GL.DrawElements(PrimitiveType.Triangles, arrow.edges.GetUpperBound(0), DrawElementsType.UnsignedInt, arrow.edges)
                    Next
                End If
            End With
        End If
    End Sub


    Public origTexturen As New List(Of String)
    Public overWriteTextures As New List(Of Material)

    Private Sub drawL3D(objekt As Mesh)
        With objekt
            If .visible And Not .tempHidden Then
                For i = 0 To .subObjekte.Count - 1
                    GL.Color3(Color.White)

                    If Not origTexturen.Contains(.texturen(i).filename, StringComparer.OrdinalIgnoreCase) Then '-> Hier CaseInsensitiveComparer einfügen!
                        GL.BindTexture(TextureTarget.Texture2D, .texturen(i).id)
                    Else
                        'GL.BindTexture(TextureTarget.Texture2D, overWriteTextures(origTexturen.IndexOf(.texturen(i).filename)).id)
                        Dim texturename As String = .texturen(i).filename
                        GL.BindTexture(TextureTarget.Texture2D, overWriteTextures(origTexturen.FindIndex(Function(s) s.Equals(texturename, StringComparison.CurrentCultureIgnoreCase))).id)
                    End If


                    'GL.BindTexture(TextureTarget.Texture2D, .Texturen(i).id)
                    GL.VertexPointer(3, VertexPointerType.Double, 0, .vertices)
                    GL.TexCoordPointer(2, TexCoordPointerType.Double, 0, .texCoords)
                    GL.DrawElements(PrimitiveType.Triangles, .subObjekte(i).Count, DrawElementsType.UnsignedInt, .subObjekte(i))
                Next


                GL.BindTexture(TextureTarget.Texture2D, 0)
                If Not getSelectedMeshes() Is Nothing Then
                    For Each mesh In getSelectedMeshes()
                        If mesh.ObjIds.Contains(objekt.id) Then
                            GL.Color3(Settings.SelectionColor)
                            GL.LineWidth(2)
                            GL.DrawElements(PrimitiveType.Lines, .lines.GetUpperBound(0), DrawElementsType.UnsignedInt, .lines)
                            GL.LineWidth(1)
                        Else
                            If Settings.WireframeV Then
                                GL.Color3(Settings.LineColor3D)
                                GL.DrawElements(PrimitiveType.Lines, .lines.GetUpperBound(0), DrawElementsType.UnsignedInt, .lines)
                            End If
                        End If
                    Next
                Else
                    If Settings.WireframeV Then
                        GL.Color3(Settings.LineColor3D)
                        GL.DrawElements(PrimitiveType.Lines, .lines.GetUpperBound(0), DrawElementsType.UnsignedInt, .lines)
                    End If
                End If
            End If
        End With
    End Sub

    Private Function StringCount(ByVal Text As String, ByVal Find As String, ByVal CompareType As StringComparison) As Integer
        Text = Replace(Text, vbCrLf, " ")
        ' Wenn Such-String leer, Funktion verlassen
        If IsNothing(Find) OrElse Find.Length = 0 Then Return -1

        Dim count As Integer = 0
        Dim pos As Integer = -1

        ' Solange nach gesuchtem Zeichen/Zeichenfolge
        ' suchen, bis keine Fundstelle mehr vorhanden
        Do
            pos = Text.IndexOf(Find, pos + 1, CompareType)
            If pos >= 0 Then count += 1
        Loop Until pos < 0

        ' Rückgabewert: Anzahl Fundstellen
        Return (count)
    End Function

    Private Function NumbersOnly(e As Windows.Forms.KeyPressEventArgs, Optional TB As TextBox = Nothing, Optional asDouble As Boolean = False) As Boolean
        If asDouble Then '44 = Komma | 45 = Minus | 46 = Punkt
            If Asc(e.KeyChar) = 45 Then
                If TB.Text <> "" Then
                    If TB.Text(0) = "-" Then
                        TB.Text = TB.Text.Substring(1, TB.Text.Length - 1)
                    Else

                        TB.Text = "-" & TB.Text
                    End If
                Else
                    TB.Text = "-"
                End If
                TB.SelectionStart = TB.Text.Length
                Return True
            End If

            If Asc(e.KeyChar) = 44 Then
                TB.Text = TB.Text & "."
                TB.SelectionStart = TB.Text.Length
                Return True
            End If
        End If


        If (Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) Or Asc(e.KeyChar) = 8 Then
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub TextToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TextToolStripMenuItem.Click
        If getProjType() = Proj_Bus.TYPE Or getProjType() = Proj_Sco.TYPE Or getProjType() = Proj_Ovh.TYPE Then
            Frm_TextTex.Show()
        Else
            If getProjType() = Proj_Sli.TYPE Then
                MsgBox("Splines könne keine Text-Texturen haben.")
            Else
                MsgNoProj()
            End If
        End If
    End Sub

    Private Sub HofDateienToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HofDateienToolStripMenuItem.Click
        If getProjType() = Proj_Bus.TYPE Then
            Frm_Hof.ShowDialog()
        Else
            MsgBox("Dieser Projekttyp unterstützt keine Hofdateien!")
        End If
    End Sub

    Private Sub Mat_CBTex_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Mat_CBTex.SelectedIndexChanged
        DDAlleTexturen.Text = sender.text
        For Each material In getSelectedMesh.materials
            If Mat_CBTex.SelectedIndex = material.index Then
                With material
                    If .texTex Then
                        Mat_CBTextTex.Text = actProj.model.TextTexturen(.texTexVal).name
                    Else
                        Mat_CBTextTex.Text = ""
                    End If

                    If .alpha <= 2 And .alpha >= 0 Then
                        Mat_CBAlpha.SelectedIndex = .alpha
                    Else
                        Mat_CBAlpha.SelectedIndex = 0
                    End If

                    Mat_TBAlphascale.Text = .alphascale
                    Mat_CBZCheck.Checked = .zCheck
                    Mat_CBZWrite.Checked = .zWrite
                End With
            End If
        Next
    End Sub

    Private Sub DDAlleTexturen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DDAlleTexturen.SelectedIndexChanged
        SelectedTextureChanged(sender.text)
    End Sub

    Private Sub DDAlleTexturen_Click(sender As Object, e As EventArgs) Handles DDAlleTexturen.Click
        fillAlleTexturen()
    End Sub


    Private Sub fillAlleTexturen()
        If actProj.filename.path = "" Then Exit Sub
        If DDAlleTexturen.SelectedItem Is Nothing Then Exit Sub

        Dim selectedFile As String = DDAlleTexturen.SelectedItem.ToString
        Dim tmpList As New List(Of String)
        For Each file As String In IO.Directory.GetFiles(actProj.filename.path & "/Texture", "*.*", IO.SearchOption.TopDirectoryOnly)
            Dim tmpname As New Filename(file)
            If OMSI_ImageFormats.Contains(tmpname.extension) Then
                tmpList.Add(tmpname.name)
            End If
        Next

        If Not (DDAlleTexturen.Items.Contains(tmpList.ToArray) Or DDAlleTexturen.Items.Count = tmpList.Count) Then
            DDAlleTexturen.Items.Clear()
            DDAlleTexturen.Items.AddRange(tmpList.ToArray)
            DDAlleTexturen.SelectedItem = selectedFile
        End If
    End Sub

    Private Sub Parent_CBParent_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Parent_CBParent.SelectedIndexChanged
        Select Case TCObjekte.SelectedIndex
            Case 2
                If Not getSelectedLight() Is Nothing Then
                    getSelectedLight.parent = Parent_CBParent.SelectedItem.ToString
                End If
        End Select
    End Sub

    Private Sub readalltags()
        Dim newline As String
        Dim alleBef As New List(Of String)
        Dim alleFiles As New List(Of String)
        For Each folder In My.Computer.FileSystem.GetDirectories(Settings.OmsiPfad & "\Sceneryobjects")
            For Each file In My.Computer.FileSystem.GetFiles(folder)
                If file.Contains(".sco") Then
                    For Each line In Split(My.Computer.FileSystem.ReadAllText(file), vbCrLf)
                        If line.Contains("[") And line.Contains("]") Then
                            newline = Trim(Replace(line, vbTab, ""))
                            If Not alleBef.Contains(newline & ";") Then
                                alleBef.Add(newline & ";")
                                alleFiles.Add(file)
                            End If
                        End If
                    Next
                End If
            Next
        Next
        For i = 0 To alleBef.Count - 1
            alleBef(i) &= alleFiles(i) & ";"
        Next
        My.Computer.FileSystem.WriteAllText(Settings.OmsiPfad & "\alleBef.csv", Join(alleBef.ToArray, vbCrLf), False)
    End Sub

    Private Sub BBox_PSSize_Changed(sender As Object, e As EventArgs) Handles BBox_PSSize.Changed
        If getProjType() = Proj_Bus.TYPE Or getProjType() = Proj_Sco.TYPE Then
            If actProj.bbox Is Nothing Then
                actProj.bbox = New OMSI_BBox()
            End If
            actProj.bbox.size = BBox_PSSize.Point
        End If
    End Sub

    Private Sub BBoxBTBerechnen_Click(sender As Object, e As EventArgs) Handles BBoxBTBerechnen.Click
        If getProjType() = Proj_Bus.TYPE Or getProjType() = Proj_Sco.TYPE Then
            If actProj.bbox Is Nothing Then actProj.bbox = New OMSI_BBox
            With actProj.bbox
                Dim min As New Point3D
                Dim max As New Point3D
                For Each objekt In getOCTProj.alleMeshes
                    For i = 0 To objekt.vertices.Count - 1 Step 3
                        If objekt.vertices(i) > max.X Then max.X = objekt.vertices(i)
                        If objekt.vertices(i + 2) > max.Y Then max.Y = objekt.vertices(i + 2)
                        If objekt.vertices(i + 1) > max.Z Then max.Z = objekt.vertices(i + 1)

                        If objekt.vertices(i) < min.X Then min.X = objekt.vertices(i)
                        If objekt.vertices(i + 2) < min.Y Then min.Y = objekt.vertices(i + 2)
                        If objekt.vertices(i + 1) < min.Z Then min.Z = objekt.vertices(i + 1)
                    Next
                Next

                .pos = New Point3D(max.X + min.X, max.Y + min.Y, (max.Z + min.Z) / 2)
                .size = New Point3D(max.X - min.X, max.Y - min.Y, max.Z - min.Z)

                PSPos.Point = .pos
                BBox_PSSize.Point = .size
            End With
            GlMain.Invalidate()
        End If
    End Sub

    Private Sub LokaleHilfeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LokaleHilfeToolStripMenuItem.Click
        Frm_Help.Show()
    End Sub

    Private Sub EigenschaftenToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles EigenschaftenToolStripMenuItem1.Click
        Frm_Eig_Mesh.actMesh = getSelectedMesh()
        Frm_Eig_Mesh.Show()
    End Sub

    Private Sub Anim_TBAnimGrp_Click(sender As Object, e As EventArgs) Handles Anim_TBAnimGrp.Click
        If Not getSelectedMesh() Is Nothing Then
            Frm_AnimGrp.ShowDialog()
        Else
            MsgBox("Kein Mesh ausgewählt!")
        End If
    End Sub

    Private Sub Anim_TBAnimGrp_Leave(sender As Object, e As EventArgs) Handles Anim_TBAnimGrp.Leave
        getSelectedMesh.animParent = Anim_TBAnimGrp.Text
    End Sub

    Private Sub CMSLichter_Opening(sender As Object, e As CancelEventArgs) Handles CMSLichter.Opening
        If LBLichter.SelectedIndex >= 0 Then
            DuplizierenToolStripMenuItem1.Enabled = True
            EntfernenToolStripMenuItem1.Enabled = True
        Else
            DuplizierenToolStripMenuItem1.Enabled = False
            EntfernenToolStripMenuItem1.Enabled = False
        End If
    End Sub

    Private Sub EntfernenToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles EntfernenToolStripMenuItem1.Click
        For i = 0 To actProj.model.lichter.count - 1
            If actProj.model.lichter(i).name = LBLichter.SelectedItem Then
                actProj.model.lichter.removeat(i)
                Exit For
            End If
        Next
        LBLichter.Items.Remove(LBLichter.SelectedItem)
    End Sub

    Private Sub Mesh_TBMeshident_Leave(sender As Object, e As EventArgs) Handles Mesh_TBMeshident.Leave
        If getSelectedMesh() Is Nothing Then Exit Sub
        If Mesh_TBMeshident.Text = "" Then
            getSelectedMesh.meshIdent = ""
        ElseIf Not Mesh_TBMeshident.Text.Contains(" ") Then
            getSelectedMesh.meshIdent = Mesh_TBMeshident.Text
        Else
            MsgBox("Der Meshident darf kein Leerzeichen enthalten!")
            Mesh_TBMeshident.Select()
            Mesh_TBMeshident.SelectAll()
        End If
    End Sub

    Private Sub TestToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TestToolStripMenuItem.Click
        'checkForStdPos()
        'MsgBox(ToDouble("8180003F"))
        'MsgBox(getOCTProj.alleTexturen.Count)
    End Sub

    Dim selectedPathChanging As Boolean = True
    Private Sub LBPfade_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LBPfade.SelectedIndexChanged

        If Not actProj Is Nothing Then
            If getProjType() = Proj_Bus.TYPE Or getProjType() = Proj_Ovh.TYPE Then
                selectedPathChanging = True
                TBName.Text = LBPfade.SelectedItem
                PSPos.Point = actProj.paths.pathPoints(LBPfade.SelectedIndex)

                Pfade_TBIndex.Text = LBPfade.SelectedIndex

                Pfade_CBAusstieg.Checked = False
                Pfade_CBEinstieg.Checked = False

                Pfade_CBVerkauf.Checked = False
                Pfade_CBTaster.Checked = False

                Pfade_CBVerkauf.Enabled = False
                Pfade_CBTaster.Enabled = False

                If Not actProj.cabin Is Nothing Then
                    With actProj.cabin
                        For Each door In .doors
                            If LBPfade.SelectedIndex = door.pathindex Then
                                If OMSI_Door.IS_ENTRY = door.direction Then
                                    Pfade_CBEinstieg.Checked = True

                                    Pfade_CBVerkauf.Enabled = True
                                    Pfade_CBVerkauf.Checked = Not door.noticketsale
                                Else
                                    Pfade_CBAusstieg.Checked = True
                                End If


                                Pfade_CBTaster.Enabled = True
                                Pfade_CBTaster.Checked = door.withButton

                            End If
                        Next



                        If .linkToNextVeh = LBPfade.SelectedIndex Then
                            Pfade_CBNextWagen.Checked = True
                        Else
                            Pfade_CBNextWagen.Checked = False
                        End If

                        If .linkToPrevVeh = LBPfade.SelectedIndex Then
                            Pfade_CBVorWagen.Checked = True
                        Else
                            Pfade_CBVorWagen.Checked = False
                        End If
                    End With
                Else
                    MsgBox("Es können keine Türen definiert werden da keine Cabin-Datei ausgewählt wurde!")
                End If


                For Each control In GBPfade.Controls
                    If control.name.contains("Pfade_PVerb") And Not control.name = "Pfade_PVerb0" Then
                        GBPfade.Controls.Remove(control)
                        GBPfade.Height -= Pfade_PVerb0.Height
                        Pfade_BTHinzu.Top -= Pfade_PVerb0.Height
                    End If
                Next

                GBPfade.Tag = ";"
                Pfade_DDNachste_0.Text = ""
                Pfade_PVerb0.Height = 0
                Pfade_BTRem_0.Enabled = False

                Dim counter As Integer = 0
                For i = actProj.paths.pathLinks.count - 1 To 0 Step -1

                    If actProj.paths.pathLinks(i).X = LBPfade.SelectedIndex Then
                        counter += 1
                        GBPfade.Tag = GBPfade.Tag & actProj.paths.pathLinks(i).Y & ";"
                        If Not Pfade_DDNachste_0.Text = "" Then
                            With actProj
                                addPathPntProperty(counter - 1, .paths.pathLinks(i).Y, .paths.roomheight(i), .paths.stemsounds(i), .paths.oneways.Contains(i))
                            End With

                        Else
                            Dim pntName As String = actProj.paths.pathPoints(actProj.paths.pathLinks(i).Y).Tag
                            If Not pntName Is Nothing Then
                                Pfade_DDNachste_0.Text = pntName
                            Else
                                Pfade_DDNachste_0.Text = "Punkt_" & actProj.paths.pathLinks(i).Y
                            End If
                            Pfade_TBStehh_0.Text = actProj.paths.roomheight(i)
                            Pfade_DDStepsound_0.Text = actProj.paths.stemsounds(i)
                            Pfade_PVerb0.Height = 60
                        End If
                    End If

                Next

                Pfade_BTHinzu.Top = Pfade_PVerb0.Top + (Pfade_PVerb0.Height * counter)
                GBPfade.Height = Pfade_BTHinzu.Height + Pfade_PVerb0.Top + (Pfade_PVerb0.Height * counter)
                'Pfade_TBStehh.Text = actProj.paths.roomheight(LBPfade.SelectedIndex)
                'Pfade_DDStepsound.Text = actProj.paths.stemsounds(LBPfade.SelectedIndex)



                GlMain.Invalidate()
                selectedPathChanging = False
            ElseIf getProjType() = Proj_Sli.TYPE Or getProjType() = Proj_Sco.TYPE Then
                ' KI-Paths von Spline und Sco
            End If

        End If
    End Sub

    Private Sub addPathPntProperty(index As Integer, nextPnt As Integer, roomheight As Double, stepsound As Integer, oneway As Boolean)
        Dim newPanel As New Panel
        With newPanel
            .Size = Pfade_PVerb0.Size
            .Location = Pfade_PVerb0.Location
            .Top += .Height + 1
            .BackColor = Pfade_PVerb0.BackColor
            .Name = "Pfade_PVerb" & index

            Dim newPBLila As New PictureBox
            With newPBLila
                .Location = Pfade_PBLila.Location
                .Size = Pfade_PBLila.Size
                .BackColor = Pfade_PBLila.BackColor
            End With
            .Controls.Add(newPBLila)

            Dim newDDNaechste As New ComboBox
            With newDDNaechste
                .Location = Pfade_DDNachste_0.Location
                .Size = Pfade_DDNachste_0.Size
                .Name = "Pfade_DDNachste_" & index
                For Each item In Pfade_DDNachste_0.Items
                    .Items.Add(item)
                Next
                .Text = nextPnt
                AddHandler .SelectedIndexChanged, AddressOf Pfade_DDNachste_0_SelectedIndexChanged
            End With
            .Controls.Add(newDDNaechste)

            Dim newDDStepsound As New ComboBox
            With newDDStepsound
                .Location = Pfade_DDStepsound_0.Location
                .Size = Pfade_DDStepsound_0.Size
                .Name = "Pfade_DDStepsound_" & index
                .Text = stepsound
                AddHandler .SelectedIndexChanged, AddressOf Pfade_DDStepsound_0_SelectedIndexChanged
            End With
            .Controls.Add(newDDStepsound)

            Dim newCBOneway As New CheckBox
            With newCBOneway
                .Location = Pfade_CBRichtung_0.Location
                .Size = Pfade_CBRichtung_0.Size
                .Name = "Pfade_CBRichtung_" & index
                .Text = Pfade_CBRichtung_0.Text
                .Checked = oneway
                AddHandler .Click, AddressOf Pfade_CBRichtung_0_Click
            End With
            .Controls.Add(newCBOneway)

            Dim newTBStehh As New TextBox
            With newTBStehh
                .Location = Pfade_TBStehh_0.Location
                .Size = Pfade_TBStehh_0.Size
                .Name = "Pfade_TBStehh_" & index
                .Text = roomheight
                AddHandler .KeyDown, AddressOf Pfade_TBStehh_0_KeyDown
            End With
            .Controls.Add(newTBStehh)

            Dim newButton As New Button
            With newButton
                .Location = Pfade_BTRem_0.Location
                .Size = Pfade_BTRem_0.Size
                .Text = Pfade_BTRem_0.Text
                .Name = "Pfade_BTRem_" & index
                AddHandler .Click, AddressOf Pfade_BTRem_0_Click
            End With
            .Controls.Add(newButton)
            Pfade_BTRem_0.Enabled = True

        End With

        GBPfade.Controls.Add(newPanel)
        GBPfade.Height += newPanel.Height
        Pfade_BTHinzu.Top += newPanel.Height
    End Sub

    Private Sub Pfade_BTHinzu_Click(sender As Object, e As EventArgs) Handles Pfade_BTHinzu.Click
        If Not actProj.paths Is Nothing Then
            With actProj

                .paths.pathLinks.Add(New Point(LBPfade.SelectedIndex, 0))
                .paths.recalc()

                If .paths.roomheight.count = 0 Then
                    .paths.roomheight.add(0)
                Else
                    .paths.roomheight.Add(.paths.roomheight(LBPfade.SelectedIndex))
                End If

                If .paths.stemsounds.count = 0 Then
                    .paths.stemsounds.Add(0)
                Else
                    .paths.stemsounds.Add(.paths.stemsounds(LBPfade.SelectedIndex))
                End If

                LBPfade_SelectedIndexChanged(LBPfade, Nothing)
            End With
        End If
    End Sub

    Private Sub Pfade_DDNachste_0_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Pfade_DDNachste_0.SelectedIndexChanged
        If Not selectedPathChanging Then
            Dim counter As Integer = 0
            With actProj.paths
                For i = 0 To .pathLinks.Count - 1
                    If .pathLinks(i).X = LBPfade.SelectedIndex Then
                        If counter = sender.name.split("_")(2) Then
                            GBPfade.Tag = GBPfade.Tag.replace(";" & .pathLinks(i).Y & ";", ";" & sender.selectedIndex & ";")
                            .pathLinks(i) = New Point(LBPfade.SelectedIndex, sender.selectedIndex)
                            .recalc()
                            GlMain.Invalidate()
                            Exit Sub
                        End If
                        counter += 1
                    End If
                Next
            End With
        End If
    End Sub

    Private Sub Pfade_TBStehh_0_KeyDown(sender As Object, e As KeyEventArgs) Handles Pfade_TBStehh_0.KeyDown
        If e.KeyCode = Keys.Enter Then
            MsgBox(sender.name.split("_")(2))
        End If
    End Sub

    Private Sub Pfade_CBRichtung_0_Click(sender As Object, e As EventArgs) Handles Pfade_CBRichtung_0.Click
        MsgBox(sender.name.split("_")(2))
    End Sub

    Private Sub Pfade_DDStepsound_0_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Pfade_DDStepsound_0.SelectedIndexChanged
        MsgBox(sender.name.split("_")(2))
    End Sub

    Private Sub Pfade_BTRem_0_Click(sender As Object, e As EventArgs) Handles Pfade_BTRem_0.Click
        Dim counter As Integer = 0
        With actProj.paths
            For i = 0 To .pathLinks.Count - 1
                If .pathLinks(i).X = LBPfade.SelectedIndex Then
                    If counter = sender.name.split("_")(2) Then
                        .pathLinks.removeAt(i)
                        Exit For
                    End If
                End If
            Next
        End With
    End Sub


    Private Sub Pfade_CBEinstieg_Click(sender As Object, e As EventArgs) Handles Pfade_CBEinstieg.Click
        If getProjType() = Proj_Bus.TYPE Then
            With actProj.cabin
                If Pfade_CBEinstieg.Checked Then
                    Dim newDoor As New OMSI_Door(LBPfade.SelectedIndex, OMSI_Door.IS_ENTRY)
                    .doors.Add(newDoor)
                    Pfade_CBTaster.Enabled = True
                Else
                    For Each door In .doors
                        If door.pathindex = LBPfade.SelectedIndex Then
                            If door.direction = OMSI_Door.IS_ENTRY Then
                                .doors.Remove(door)
                                Pfade_CBVerkauf.Checked = False
                                If Not Pfade_CBAusstieg.Checked Then
                                    Pfade_CBTaster.Enabled = False
                                End If
                                Exit For
                            End If
                        End If
                    Next
                End If
                Pfade_CBVerkauf.Enabled = Pfade_CBEinstieg.Checked
            End With
            doorsRecalc()
            GlMain.Invalidate()
        End If
    End Sub

    Private Sub Pfade_CBAusstieg_Click(sender As Object, e As EventArgs) Handles Pfade_CBAusstieg.Click
        If getProjType() = Proj_Bus.TYPE Then
            With actProj.cabin
                If Pfade_CBAusstieg.Checked Then
                    Dim newDoor As New OMSI_Door(LBPfade.SelectedIndex, OMSI_Door.IS_EXIT)
                    .doors.Add(newDoor)
                    Pfade_CBTaster.Enabled = True
                Else
                    For Each door In .doors
                        If door.pathindex = LBPfade.SelectedIndex Then
                            If door.direction = OMSI_Door.IS_EXIT Then
                                .doors.Remove(door)
                                If Not Pfade_CBEinstieg.Checked Then
                                    Pfade_CBTaster.Enabled = False
                                End If
                                Exit For
                            End If
                        End If
                    Next
                End If
            End With
            doorsRecalc()
            GlMain.Invalidate()
        End If
    End Sub

    Private Sub Pfade_CBVerkauf_Click(sender As Object, e As EventArgs) Handles Pfade_CBVerkauf.Click
        If getProjType() = Proj_Bus.TYPE Then
            For i = 0 To actProj.cabin.doors.Count - 1
                If actProj.cabin.doors(i).pathindex = LBPfade.SelectedIndex Then
                    actProj.cabin.doors(i).noticketsale = Not Pfade_CBVerkauf.Checked
                    Exit Sub
                End If
            Next
        End If
    End Sub

    Private Sub Pfade_CBTaster_Click(sender As Object, e As EventArgs) Handles Pfade_CBTaster.Click
        If getProjType() = Proj_Bus.TYPE Then
            With actProj
                For i = 0 To .cabin.doors.Count - 1
                    If .cabin.doors(i).pathindex = LBPfade.SelectedIndex Then
                        .cabin.doors(i).withButton = Pfade_CBTaster.Checked
                        Exit Sub
                    End If
                Next
            End With
        End If
    End Sub


    Private Sub Pfade_CBNextWagen_Click(sender As Object, e As EventArgs) Handles Pfade_CBNextWagen.Click
        If getProjType() = Proj_Bus.TYPE Then
            If Pfade_CBNextWagen.Checked Then
                actProj.cabin.linkToNextVeh = LBPfade.SelectedIndex
                Pfade_CBVorWagen.Checked = False
                actProj.cabin.linkToPrevVeh = -1
            Else
                actProj.cabin.linkToNextVeh = -1
            End If
        End If
    End Sub

    Private Sub Pfade_CBVorWagen_Click(sender As Object, e As EventArgs) Handles Pfade_CBVorWagen.Click
        If getProjType() = Proj_Bus.TYPE Then
            If Pfade_CBVorWagen.Checked Then
                actProj.cabin.linkToPrevVeh = LBPfade.SelectedIndex
                Pfade_CBNextWagen.Checked = False
                actProj.cabin.linkToNextVeh = -1
            Else
                actProj.cabin.linkToPrevVeh = -1
            End If
        End If
    End Sub



    '#########################
    '   Lichter
    '#########################

    Private Sub DuplizierenToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles DuplizierenToolStripMenuItem1.Click
        If Not actProj.model Is Nothing Then
            Dim newLicht As New OMSI_Licht(getSelectedLight)
            newLicht.name = "Licht_" & actProj.model.lichter.Count
            actProj.model.lichter.add(newLicht)
            LBLichter.Items.Add(newLicht.name)
        End If
    End Sub

    Private Sub Licht_TBGroesse_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs) Handles Licht_TBGroesse.KeyPress
        e.Handled = Helper.NumbersOnly(e, sender, True)
        If Not getSelectedLight() Is Nothing Then
            getSelectedLight.size = sender.Text
        End If
    End Sub

    Private Sub Licht_PSRichtung_Changed(sender As Object, e As EventArgs) Handles Licht_PSRichtung.Changed
        If Not getSelectedLight() Is Nothing Then
            getSelectedLight.richtung = Licht_PSRichtung.Point
        End If
    End Sub

    Private Sub Licht_PSVector_Changed(sender As Object, e As EventArgs) Handles Licht_PSVector.Changed
        If Not getSelectedLight() Is Nothing Then
            getSelectedLight.upVector = Licht_PSVector.Point
        End If
    End Sub

    Private Sub Licht_CBAusr_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Licht_CBAusr.SelectedIndexChanged
        If Not getSelectedLight() Is Nothing Then
            getSelectedLight.ausrichtung = toByte(Licht_CBAusr.SelectedIndex)
        End If
    End Sub

    Private Sub Licht_CBRotAusr_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Licht_CBRotAusr.SelectedIndexChanged
        If Not getSelectedLight() Is Nothing Then
            getSelectedLight.rotating = toByte(Licht_CBRotAusr.SelectedIndex)
        End If
    End Sub

    Private Sub Licht_TBOuterCone_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs) Handles Licht_TBOuterCone.KeyPress
        e.Handled = NumbersOnly(e, sender, False)
        If Not getSelectedLight() Is Nothing Then
            getSelectedLight.outerCone = CInt(Licht_TBOuterCone.Text)
        End If
    End Sub

    Private Sub Licht_TBInnerCone_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs) Handles Licht_TBInnerCone.KeyPress
        If Not getSelectedLight() Is Nothing Then
            getSelectedLight.innerCone = CInt(Licht_TBInnerCone.Text)
        End If
    End Sub

    Private Sub Licht_TBOffset_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs) Handles Licht_TBOffset.KeyPress
        e.Handled = NumbersOnly(e, sender, True)
        If Not getSelectedLight() Is Nothing Then
            getSelectedLight.offset = Convert.ToDouble(Licht_TBOffset.Text)
        End If
    End Sub

    Private Sub Licht_TBFaktor_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs) Handles Licht_TBFaktor.KeyPress
        e.Handled = NumbersOnly(e, sender, True)
        If Not getSelectedLight() Is Nothing Then
            getSelectedLight.faktor = Licht_TBFaktor.Text
        End If
    End Sub

    Private Sub Licht_TBZeitkonst_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs) Handles Licht_TBZeitkonst.KeyPress
        e.Handled = NumbersOnly(e, sender, True)
        If Not getSelectedLight() Is Nothing Then
            getSelectedLight.timeconst = Licht_TBZeitkonst.Text
        End If
    End Sub

    Private Sub Licht_TBKegel_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs) Handles Licht_TBKegel.KeyPress
        e.Handled = NumbersOnly(e, sender, True)
        If Not getSelectedLight() Is Nothing Then
            getSelectedLight.cone = Licht_TBKegel.Text
        End If
    End Sub

    Private Sub Licht_CBEffekt_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Licht_CBEffekt.SelectedIndexChanged
        If Not getSelectedLight() Is Nothing Then
            getSelectedLight.effekt = Licht_CBEffekt.SelectedIndex
        End If
    End Sub

    Private Sub Licht_TBTexture_TextChanged(sender As Object, e As EventArgs) Handles Licht_TBTexture.TextChanged
        Try
            DDAlleTexturen.Text = Licht_TBTexture.Text
        Catch ex As Exception
            MsgBox("Die ausgewählte Texture existiert nicht (Datei: " & Licht_TBTexture.Text & ")")
        End Try
    End Sub

    Private Sub EntfernenToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles EntfernenToolStripMenuItem3.Click

    End Sub

    Private Sub Kuppl_LBFront_VisibleChanged(sender As Object, e As EventArgs) Handles Kuppl_LBFront.VisibleChanged
        Kuppl_CBSound.Enabled = Kuppl_LBFront.Visible
        Kuppl_DDKupplType.Enabled = Kuppl_LBFront.Visible
        Kuppl_TBDrehwinkel.Enabled = Kuppl_LBFront.Visible
        Kuppl_TBDown.Enabled = Kuppl_LBFront.Visible
        Kuppl_TBUp.Enabled = Kuppl_LBFront.Visible
    End Sub

    Private Sub Kuppl_LBHeck_VisibleChanged(sender As Object, e As EventArgs) Handles Kuppl_LBHeck.VisibleChanged
        Kuppl_DDNextVehicle.Enabled = Kuppl_LBHeck.Visible
        Kuppl_DDRichtung.Enabled = Kuppl_LBHeck.Visible
    End Sub

    Private Sub LBMeshes_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles LBMeshes.ItemCheck
        If LBMeshes.SelectedIndex > -1 Then
            If Not getProjType() = Proj_Sli.TYPE Then
                If Not actProj.model.meshes Is Nothing Then
                    For Each objektIDs In actProj.model.meshes(e.Index).ObjIds
                        If e.NewValue Then
                            getOCTProj.alleMeshes(objektIDs).tempHidden = False
                        Else
                            getOCTProj.alleMeshes(objektIDs).tempHidden = True
                        End If
                    Next
                End If
            End If
        End If
    End Sub

    Private Sub PSPos_KeyPress(sender As Object, e As EventArgs) Handles PSPos.KeyPress

    End Sub

    Private Sub InnenlichtToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InnenlichtToolStripMenuItem.Click
        If getProjType() = Proj_Bus.TYPE Or getProjType() = Proj_Ovh.TYPE Then
            If Not actProj.model Is Nothing Then
                Dim newIntLicht As New OMSI_IntLicht
                newIntLicht.position = New Point3D
                actProj.model.intLichter.Add(newIntLicht)
                TVHelper.Nodes(4).Nodes.Add("Innen Licht " & actProj.model.intLichter.Count - 1)
                loadIntLichter()
            End If
        End If
    End Sub

    Private Sub PunkteListeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PunkteListeToolStripMenuItem.Click
        Frm_PointList.Show()
    End Sub

    Private Sub TCProjekte_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TCProjekte.SelectedIndexChanged
        If TCProjekte.SelectedIndex = TCProjekte.TabCount - 1 Then
            TCProjekte.TabPages.Add("   +   ")
            TCProjekte.SelectedIndex = TCProjekte.TabCount - 2
            addOCTProj(New OCTProjekt)
        End If
        getOCTProj.TVHelper = TVHelper
        getOCTProj.TVHelperSelected = TVHelper.SelectedNode
        getOCTProj.LBLichter = LBLichter.Items
        getOCTProj.LBLichterSelected = LBLichter.SelectedIndex
        getOCTProj.LBPfade = LBPfade.Items
        getOCTProj.LBPfadeSelected = LBPfade.SelectedIndex

        'projekt wird hier gewechselt
        actProj = OpenProjects(TCProjekte.SelectedIndex).actProj
        showSelectetProject()
        GlMain.Invalidate()
    End Sub

    Private Sub showSelectetProject()
        With getOCTProj()
            LBMeshes.Items.Clear()
            LBLichter.Items.Clear()
            LBPfade.Items.Clear()

            If Not getProjType() = Proj_Sli.TYPE Then
                If actProj.model IsNot Nothing Then
                    For Each mesh In actProj.model.meshes
                        LBMeshes.Items.Add(mesh.filename.name)
                        LBMeshes.SetItemChecked(LBMeshes.Items.Count - 1, True)
                    Next
                    If .LBMeshesSelected > -1 Then
                        LBMeshes.SelectedIndex = .LBMeshesSelected
                    End If
                End If
                Else
                Dim i As Integer = 0
                For Each subobjekt In actProj.subobjekte
                    LBMeshes.Items.Add(actProj.filename.name & "_" & i)
                    LBMeshes.SetItemChecked(LBMeshes.Items.Count - 1, True)
                    i += 1
                Next
            End If
            TCObjekte.SelectedIndex = .TCObjkteSelected
            TCObjektePMeshes.Text = "Meshes (" & LBMeshes.Items.Count & ")"
            TVHelper = .TVHelper
            TVHelper.SelectedNode = .TVHelperSelected
            LBLichter.Items.AddRange(.LBLichter)
            LBLichter.SelectedIndex = .LBLichterSelected
            LBPfade.Items.AddRange(.LBPfade)
            LBPfade.SelectedIndex = .LBPfadeSelected
        End With
    End Sub

    Private Sub Mesh_TBSichtbarkeitVal_TextChanged(sender As Object, e As EventArgs) Handles Mesh_TBSichtbarkeitVal.TextChanged
        If Mesh_VSSichtbarkeit.Variable <> "" Then
            If IsNumeric(Convert.ToDouble(Mesh_TBSichtbarkeitVal.Text)) Then
                RecalcVis(Mesh_VSSichtbarkeit.Variable, Convert.ToDouble(Mesh_TBSichtbarkeitVal.Text))
            End If
        End If
    End Sub
End Class

