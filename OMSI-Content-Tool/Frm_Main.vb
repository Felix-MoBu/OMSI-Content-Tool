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

    Public AlleObjekte As New List(Of Local3DObjekt)
    Public AlleTexturen As New List(Of String)
    Public AlleVariablen As New List(Of String)
    Public AlleVarValues As New List(Of Double)

    Private Projekt_Emt As New Proj_Emt
    Private Projekt_Bus As Proj_Bus
    Private Projekt_Ovh As Proj_Ovh
    Private Projekt_Sco As Proj_Sco
    Private Projekt_Sli As Proj_Sli

    Public selectedMeshes As List(Of OMSI_Mesh)
    Public selectedMesh As OMSI_Mesh
    Public lastSelectedMesh As OMSI_Mesh
    Public lastSelectedLight As Integer = -1
    Private selectedMeshesChanged As Boolean = False
    Public Clipboard3D As Point3D
    Public Sprachen As List(Of String)
    Public repName As String

    Public lodVal As Single

    Public viewMode As Byte = viewModes.ALLES
    Public viewPoint As Byte = 4
    Public selectedDriverCam As Integer = 0
    Public selectedPassCam As Integer = 0

    Public Const PROJ_TYPE_EMT As Byte = 0
    Public Const PROJ_TYPE_BUS As Byte = 1
    Public Const PROJ_TYPE_OVH As Byte = 2
    Public Const PROJ_TYPE_SCO As Byte = 3
    Public Const PROJ_TYPE_SLI As Byte = 4

    Dim timerMin As Integer
    Dim timerSec As Integer
    Dim timerBool As Boolean

    Dim activeImageSelector As Object

    Dim resizePanelEigenschaften As Boolean = False
    Dim PanelEigenschaften_height As Integer
    Dim PanelObjecte_size As Point
    Dim meshesDragStart As Integer = 0
    Dim vorherigesProj As Filename

    Dim dotTexture As LocalTexture
    Dim softDotTexture As LocalTexture

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

        movePanelObjekte = False
        movePanelTexture = False
        movePanelEigenschaften = False
        saveStaus = True
        scale3D = 20
        Clipboard3D = New Point3D
        lodVal = 1

        AlleObjekte.Clear()
        loadPositions()

        If My.Settings.eMail = Frm_Einst.stdMail Then
            TestToolStripMenuItem.Visible = True
        End If

        timerMin = My.Settings.SaveInterval
        timerSec = 0
        timerBool = False
        TSave.Start()
        GlMain.Select()

        TCObjekte_SelectedIndexChanged(TCObjekte, Nothing)

        Mesh_DDViedpoint.SelectedIndex = 0
        TVHelper.SelectedNode = TVHelper.Nodes(0)

        redrawLetzte()

        If My.Settings.TexAutoReload Then TReloadTextures.Start()

        'Datei laden die übergeben wurde
        Try
            If My.Application.CommandLineArgs.Count > 0 Then
                Dim newFile As New Filename(My.Application.CommandLineArgs(0))
                If Proj_Bus.EXTENSION = newFile.extension Or Proj_Ovh.EXTENSION = newFile.extension Or Proj_Sco.EXTENSION = newFile.extension Or Proj_Sli.EXTENSION = newFile.extension Then
                    ProjÖffnen(newFile)
                ElseIf Importer.KNOWN_FILE_TYPES.Contains(newFile.extension) Then
                    Dim newMesh As New OMSI_Mesh
                    newMesh = fileimport2(newFile)

                    If Not newMesh Is Nothing Then
                        getProj.model.meshes.add(newMesh)
                        LBMeshes.Items.Add(newMesh.filename.name)
                        LBMeshes.SetItemChecked(LBMeshes.Items.Count - 1, True)
                        Parent_CBParent.Items.Add(newMesh.filename.name)

                        If newFile.extension.ToLower <> "o3d" Then
                            newMesh.isProtected = False
                        End If
                    End If
                Else
                    MsgBox("Datei " & newFile & " wird nicht unterstützt!")
                End If

            End If
        Catch ex As Exception
        End Try
    End Sub





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
                    My.Settings.ExpPfad = .FileName
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
            For Each objekt In AlleObjekte
                If mesh.ObjIds.Contains(objekt.id) Then
                    If Not getProj.filename Is Nothing Then
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
                                .FilterIndex = My.Settings.lastExportFormat
                            End If


                            If .ShowDialog = DialogResult.OK Then
                                My.Settings.ExpPfad = .FileName
                                My.Settings.lastExportFormat = .FilterIndex
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

    Private Sub fileImport()
        Dim fd As New OpenFileDialog
        SSLBStatus.Text = "Import..."
        With fd

            .Title = "Import"
            .Filter = "Alle Formate (*.*)|*.*|OMSI-3D (*.o3d)|*.o3d|DirectX (*.x)|*.x|Extensible 3D (*.x3d)|*.x3d|Modell-Datei(*.cfg)|*.cfg|Mesh-Eigenschaften(*.txt)|*.txt"
            .FilterIndex = My.Settings.lastImportFormat
            .Multiselect = True
            If getProj.filename.path <> "" Then
                .InitialDirectory = getProj.filename.path & "\Model\"
            Else
                .InitialDirectory = My.Settings.ImportPath
            End If

            .ShowDialog()
            If .FileNames.Count > 0 Then

                For Each file In .FileNames

                    Dim newFilename As Filename
                    If file.ToLower.Contains("\model\") And getProj.filename.path <> "" Then
                        newFilename = New Filename(file, getProj.filename.path & "\Model\")
                    Else
                        newFilename = New Filename(file, getProj.filename.path)
                    End If

                    If newFilename.extension.ToLower = "o3d" Or newFilename.extension.ToLower = "x" Or newFilename.extension.ToLower = "x3d" Then
                        If getProj.model Is Nothing Then
                            getProj.model = New OMSI_Model
                        End If

                        Dim newMesh As New OMSI_Mesh
                        newMesh = fileimport2(New Filename(newFilename), True)

                        If Not newMesh Is Nothing Then
                            getProj.model.meshes.add(newMesh)
                            LBMeshes.Items.Add(newMesh.filename.name)
                            LBMeshes.SetItemChecked(LBMeshes.Items.Count - 1, True)
                            Parent_CBParent.Items.Add(newMesh.filename.name)

                            If newFilename.extension.ToLower <> "o3d" Then
                                newMesh.isProtected = False
                            End If
                        End If
                    ElseIf newFilename.extension.ToLower = "cfg" Then

                        If My.Computer.FileSystem.FileExists(newFilename) Then
                            Dim fileContent As String = My.Computer.FileSystem.ReadAllText(newFilename)
                            If Not getProj.model Is Nothing Then
                                If fileContent.Contains("[mesh]") Or fileContent.Contains("[smoke]") _
                                Or fileContent.Contains("[texttexture") Or fileContent.Contains("[light_enh") Then '<- WICHTIG ohne Klammer zu für _enh!!!

                                    Dim x As MsgBoxResult = MsgBox("Modell-Datei ersetzen? (Sonst wird das bestehende Modell ergänzt)", MsgBoxStyle.YesNoCancel)
                                    Select Case x
                                        Case MsgBoxResult.Yes
                                            getProj.model = New OMSI_Model(newFilename)
                                        Case MsgBoxResult.No
                                            getProj.model.add(New OMSI_Model(newFilename))
                                    End Select
                                Else
                                    getProj.model = New OMSI_Model(newFilename)
                                End If
                            End If

                        Else
                            MsgBox("Datei konnte nicht gefunden werden! (Datei: " & newFilename & ")")
                        End If
                    End If
                Next
                GlMain.Invalidate()

                My.Settings.ImportPath = getFilePath(.FileName)
                My.Settings.lastImportFormat = .FilterIndex

                TCObjektePMeshes.Text = "Meshes (" & AlleObjekte.Count & ")"
            End If
        End With
    End Sub

    Public Function fileimport2(filename As Filename, Optional convert As Boolean = False) As OMSI_Mesh
        Dim newObjekt As Local3DObjekt = Importer.readFile(filename)

        If Not newObjekt Is Nothing Then
            Dim newMesh As New OMSI_Mesh
            newMesh.filename = filename
            newMesh.position = newObjekt.position
            newMesh.center = newObjekt.center
            newMesh.index = AlleObjekte.Count


            newObjekt.id = AlleObjekte.Count
            newMesh.ObjIds.Add(newObjekt.id)

            'Wenn automatisch eine o3d angelegt werden soll
            If convert Then
                If Not newMesh.filename.extension = "o3d" And My.Settings.AutoConvertO3D Then
                    newMesh.filename.extension = "o3d"
                    Exporter.write(newObjekt, newMesh.filename)
                End If
            End If

            AlleObjekte.Add(newObjekt)

            If getProj.model Is Nothing Then getProj.model = New OMSI_Model

            loadTextures(newObjekt.texturen, newMesh.filename.path)
            ModelLoaded = True


            Return newMesh
        Else
            Log.Add("Datei nicht geaden! (Datei: " & filename.name & ")", Log.TYPE_DEBUG)
            Return Nothing
        End If
    End Function

    Private Sub resetTextures()
        For i = 0 To AlleTexturen.Count
            GL.DeleteTexture(i)
        Next
        AlleTexturen.Clear()
        DDAlleTexturen.Items.Clear()
    End Sub


    Private Sub calcMirrors(mirrorID As Integer)
        If getProj() Is Projekt_Bus Then
            Dim texID As Integer = -1
            For i As Integer = 0 To AlleTexturen.Count - 1
                If AlleTexturen(i).ToLower = "reflexion" & mirrorID & ".bmp" Then
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
            'bmp.RotateFlip(RotateFlipType.RotateNoneFlipX)



            Dim rect = New Rectangle(0, 0, bmp.Width, bmp.Height)
            Dim bmpdata As Imaging.BitmapData = bmp.LockBits(rect, Imaging.ImageLockMode.ReadOnly, bmp.PixelFormat)
            bmp.UnlockBits(bmpdata)

            GL.BindTexture(TextureTarget.Texture2D, texID)
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, bmpdata.Width, bmpdata.Height, 0, PixelFormat.Bgra, PixelType.UnsignedByte, bmpdata.Scan0)
            GL.GenerateMipmap(GenerateMipmapTarget.Texture2D)
        End If
    End Sub





    Public Sub loadTexture(ByRef texture As LocalTexture, Optional overWrite As Boolean = False)

        If AlleTexturen.Contains(texture.filename.name) And Not overWrite Then
            texture.id = AlleTexturen.IndexOf(texture.filename.name) + 1
            texture.lastChangeDate = IO.File.GetLastWriteTime(texture.filename)
        Else
            Try
                texture.id = AlleTexturen.Count + 1
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
                If Not AlleTexturen.Contains(texture.filename.name) Then AlleTexturen.Add(texture.filename.name)
                If Not DDAlleTexturen.Items.Contains(texture.filename.name) Then DDAlleTexturen.Items.Add(texture.filename.name)
                If overWrite Then Log.Add("Bilddatei neu geladen! (Datei: " & texture.filename.name & ")")
            Catch ex As Exception
                Log.Add("Bilddatei beschädigt oder im falschen Format gespeichert! (Fehler: T999, Datei: " & texture.filename.name & ")", Log.TYPE_ERROR)
            End Try
        End If
    End Sub

    Private Sub loadTextures(Texturen As List(Of LocalTexture), objPfad As String, Optional overWrite As Boolean = False)
        For Each texture In Texturen
            findTexture(texture, objPfad)
            loadTexture(texture, overWrite)
        Next
    End Sub


    Function loadImage(ByRef Texture As LocalTexture) As Imaging.BitmapData
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

    Private Sub findTexture(texture As LocalTexture, objektpfad As String)
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

        If My.Computer.FileSystem.FileExists(objektpfad & "\" & texture.filename.name) Then
            texture.filename.path = objektpfad
        Else
            If My.Computer.FileSystem.FileExists(Join(tmppath, "\") & "\" & texture.filename.name) Then
                texture.filename.path = Join(tmppath, "\")
            Else
                If My.Computer.FileSystem.FileExists(Join(tmppath, "\") & "\Texture\" & texture.filename.name) Then
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

        getProj.save()
        addProjectlist(getProj.filename.ToString)


        If My.Settings.SaveIntervalActive Then
            TimerReset()
            TSave.Start()
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

        If My.Settings.SaveIntervalActive Then
            If timerSec > 0 Then
                timerSec -= 1
            Else
                If timerMin > 0 Then
                    timerMin -= 1
                Else
                    If My.Settings.SaveIntervalAuto Then
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
        timerMin = My.Settings.SaveInterval
        timerSec = 0
    End Sub

    Public Sub RecalcLod()
        For Each mesh In getProj.model.meshes
            For Each objekt In AlleObjekte
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
        If var = "" Then Exit Sub
        If getProj.model Is Nothing Then Exit Sub
        For Each mesh In getProj.model.meshes
            If Not mesh.visibleVar = Nothing Then
                If mesh.visibleVar = var Then
                    For Each objekt In AlleObjekte
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
        For Each mesh In getProj.model.meshes
            If Not mesh.visibleVar = Nothing Then
                For Each objekt In AlleObjekte
                    If mesh.ObjIds.Contains(objekt.id) Then
                        objekt.visible = False
                    End If
                Next
            End If
        Next
    End Sub

    Public Sub RecalcAlpha(var As String, val As Double)
        If getProj.model Is Nothing Then Exit Sub
        If getProj() Is Projekt_Bus Then
            For Each mesh In Projekt_Bus.model.meshes
                For Each objekt In AlleObjekte
                    If mesh.ObjIds.Contains(objekt.id) Then
                        For Each material In mesh.materials
                            If var = material.alphascale Then
                                For Each texture In objekt.texturen
                                    If texture.filename.name.ToLower = material.name.ToLower Then
                                        texture.alpha = val
                                    End If
                                Next
                            End If
                        Next
                    End If
                Next
            Next
        End If

        'Unnötig, aber geht nicht besser, dauert sonst zu lange!
        If getProj() Is Projekt_Sco Then
            For Each mesh In Projekt_Sco.model.meshes
                For Each objekt In AlleObjekte
                    If mesh.ObjIds.Contains(objekt.id) Then
                        For Each material In mesh.materials
                            If var = material.alphascale Then
                                For Each texture In objekt.texturen
                                    If texture.filename.name.ToLower = material.name.ToLower Then
                                        texture.alpha = val
                                    End If
                                Next
                            End If
                        Next
                    End If
                Next
            Next
        End If
    End Sub

    Public Function getProj() As Object
        If Not Projekt_Bus Is Nothing Then Return Projekt_Bus
        If Not Projekt_Sco Is Nothing Then Return Projekt_Sco
        If Not Projekt_Ovh Is Nothing Then Return Projekt_Ovh
        If Not Projekt_Sli Is Nothing Then Return Projekt_Sli
        Return Projekt_Emt
    End Function

    Public Function getProjTyp() As Byte
        If Not Projekt_Bus Is Nothing Then Return PROJ_TYPE_BUS
        If Not Projekt_Sco Is Nothing Then Return PROJ_TYPE_SCO
        If Not Projekt_Ovh Is Nothing Then Return PROJ_TYPE_OVH
        If Not Projekt_Sli Is Nothing Then Return PROJ_TYPE_SLI
        Return PROJ_TYPE_EMT
    End Function

    Public Sub clearProjects()
        resetTextures()
        AlleObjekte = New List(Of Local3DObjekt)
        LBMeshes.Items.Clear()
        Projekt_Bus = Nothing
        Projekt_Sco = Nothing
        Projekt_Ovh = Nothing
        Projekt_Sli = Nothing
        Projekt_Emt = New Proj_Emt
    End Sub

    Public Sub ProjNew(proj As Object)
        Select Case proj.type
            Case PROJ_TYPE_BUS
                Projekt_Bus = proj
            Case PROJ_TYPE_SCO
                Projekt_Sco = proj
            Case PROJ_TYPE_OVH
                Projekt_Ovh = proj
            Case PROJ_TYPE_SLI
                Projekt_Sli = proj
            Case PROJ_TYPE_EMT
                Projekt_Emt = proj
        End Select

    End Sub


    'Menüband
    '###########

    Private Sub ÖffnenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ÖffnenToolStripMenuItem.Click
        Dim fd As New OpenFileDialog
        SSLBStatus.Text = "Projekt öffnen..."

        With fd
            .Title = "Öffnen"
            .Filter = "Unterstützte Formate (*.bus, *.ovh, *.sco, *.sli)|*.bus; *.ovh; *.sco; *.sli|Bus (*.bus)|*.bus|Fahrzeug (*.ovh)|*.ovh|Scenerieobjekt (*.sco)|*.sco|Spline (*.sli)|*.sli"
            .InitialDirectory = My.Settings.OpenPath
            If .ShowDialog() = DialogResult.OK Then
                If .FileName <> "" Then
                    ProjÖffnen(.FileName)
                End If
            End If
        End With
    End Sub

    Private Sub öffneLetzte(ByVal sender As Object, ByVal e As EventArgs)
        If My.Computer.FileSystem.FileExists(sender.text) Then
            ProjÖffnen(sender.Text)
        Else
            Dim result = MsgBox("Die Datei existiert nicht! Soll sie von der Liste entfernt werden?", MsgBoxStyle.YesNo)
            If result = vbYes Then
                Dim tempList As String = ""
                For i = 0 To Split(My.Settings.Letzte, ";").Count - 1
                    If Not Split(My.Settings.Letzte, ";")(i) = sender.text Then
                        tempList &= ";" & Split(My.Settings.Letzte, ";")(i)
                    End If
                    If i = 5 Then Exit For
                Next
                My.Settings.Letzte = tempList
                redrawLetzte()
            End If
        End If
    End Sub

    Private Sub redrawLetzte()
        LetzteToolStripMenuItem.DropDownItems.Clear()
        For Each item In Split(My.Settings.Letzte, ";")
            Dim newitem As New ToolStripMenuItem()
            AddHandler newitem.Click, AddressOf öffneLetzte
            newitem.Text = item
            If item <> "" Then LetzteToolStripMenuItem.DropDownItems.Add(newitem)
        Next
    End Sub

    Private Sub resetProj()
        Projekt_Bus = Nothing
        Projekt_Ovh = Nothing
        Projekt_Sco = Nothing
        Projekt_Sli = Nothing
        AlleObjekte = New List(Of Local3DObjekt)
        AlleTexturen = New List(Of String)
        AlleVariablen = New List(Of String)
        AlleVarValues = New List(Of Double)
        HofDateienToolStripMenuItem.Enabled = False     'Nur Busse haben Hof-Dateien
        RepaintToolStripMenuItem.Enabled = False        'Splines haben keine Repaints
        Text = My.Application.Info.Title
    End Sub

    Private Sub ProjÖffnen(filename As String)

        resetProj()

        Select Case LCase(filename.Substring(filename.Length - 3))
            Case "bus"
                clearProjects()
                Projekt_Bus = New Proj_Bus(filename)
                My.Settings.OpenPath = getFilePath(filename)
                LoadProjectBus(Projekt_Bus)
                RepaintToolStripMenuItem.Enabled = True
            Case "sco"
                clearProjects()
                Projekt_Sco = New Proj_Sco(filename)
                My.Settings.OpenPath = getFilePath(filename)
                LoadProjectSco(Projekt_Sco)
            Case "sli"
                clearProjects()
                Projekt_Sli = New Proj_Sli(filename)
                My.Settings.OpenPath = getFilePath(filename)
                LoadProjectSli()
            Case Else
                MsgBox("Projektdatei nicht unterstützt!")
                SSLBStatus.Text = ""
                Exit Sub
        End Select
        addProjectlist(filename)
        GlMain.Invalidate()
        TCObjekte_SelectedIndexChanged(TCObjekte, Nothing)
        If Not Importer.stopImport Then
            Text = filename & " - " & My.Application.Info.Title
        End If
        Importer.stopImport = False
    End Sub

    Public Sub addProjectlist(filename As String)
        If My.Settings.Letzte = filename Then Exit Sub

        Dim tempList As String = filename

        For i = 0 To Split(My.Settings.Letzte, ";").Count - 1
            If Not Split(My.Settings.Letzte, ";")(i) = filename Then
                tempList &= ";" & Split(My.Settings.Letzte, ";")(i)
            End If
            If i = 5 Then Exit For
        Next
        My.Settings.Letzte = tempList
        My.Settings.Save()
        redrawLetzte()
    End Sub

    Private Sub LoadProjectSco(Proj_Sco_temp As Proj_Sco)
        With Proj_Sco_temp

            SplinehelperToolStripMenuItem.Enabled = True

            loadModelPrefs(.model)
            showModel(.model.meshes)

            TVHelper.Nodes(7).Nodes.Clear()
            If Not .cabin Is Nothing Then
                For i = 0 To .cabin.passPos.Count - 1
                    TVHelper.Nodes(7).Nodes.Add("Platz " & i)
                Next
            End If

            TVHelper.Nodes(4).Nodes.Clear()
            For i = 0 To .ki_paths.Count - 1
                TVHelper.Nodes(4).Nodes.Add("Pfad_" & i)
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


    Private Sub LoadProjectSli()
        With Projekt_Sli
            For Each texture In .textures
                Mat_CBTex.Items.Add(texture.filename)
            Next

            Dim i As Integer = 0
            For Each subobjekt In Projekt_Sli.subobjekte
                Dim newObjekt As New Local3DObjekt
                With newObjekt
                    .vertices = Projekt_Sli.vertices
                    .texCoords = Projekt_Sli.texCoords
                    .lines = Projekt_Sli.lines
                    .subObjekte.Add(subobjekt)
                    .id = AlleObjekte.Count
                    .texturen.Add(Projekt_Sli.textures(i))

                    loadTextures(.texturen, Projekt_Sli.filename.path)

                    AlleObjekte.Add(newObjekt)
                    'mesh.ObjIds.Add(newObjekt.id)

                    LBMeshes.Items.Add(Projekt_Sli.filename.name & "_" & i)
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
            NächsterWagenToolStripMenuItem.Enabled = False
            VorherigerWagenToolStripMenuItem.Enabled = False
            If .couple_back Then
                TVHelper.Nodes(3).Nodes.Add("Heck")
                WagenteilToolStripMenuItem.Visible = True
                NächsterWagenToolStripMenuItem.Enabled = True
            End If

            If .couple_front Then
                TVHelper.Nodes(3).Nodes.Add("Front")
                WagenteilToolStripMenuItem.Visible = True
                VorherigerWagenToolStripMenuItem.Enabled = True
            End If

            Kuppl_DDNextVehicle.Items.Clear()
            Kuppl_DDNextVehicle.Items.Add("")
            For Each file As Filename In My.Computer.FileSystem.GetFiles(.filename.path)
                If file.extension = "bus" Then
                    Kuppl_DDNextVehicle.Items.Add(file.name)
                End If
                If Not getProj.couple_back_file Is Nothing Then
                    If Not Kuppl_DDNextVehicle.Items.Contains(getProj.couple_back_file.name) Then
                        Kuppl_DDNextVehicle.Items.Add(getProj.couple_back_file.name)
                        Log.Add("Angehängter Fahrzeugteil (" & getProj.couple_back_file.name & ") konnte nicht gefunden werden!", Log.TYPE_ERROR, True)
                    End If
                End If
            Next



            TVHelper.Nodes(6).Nodes.Clear()
            For i = 0 To .spiegel.Count - 1
                TVHelper.Nodes(6).Nodes.Add("Spiegel      (Reflexion_" & .spiegel(i).index & ".bmp)")
            Next

            loadCabinPrefs(.cabin)

            TVHelper.Nodes(8).Nodes.Clear()
            For i = 0 To .ticketblöcke.Count - 1
                If .ticketblöcke(i).name <> "" Then
                    TVHelper.Nodes(8).Nodes.Add(.ticketblöcke(i).name)
                Else
                    TVHelper.Nodes(8).Nodes.Add("Ticket " & i)
                End If
            Next


            'DDAlleTexturen.Items.Clear()
            If IO.Directory.Exists(Projekt_Bus_temp.filename.path & "/Texture") Then
                For Each file In IO.Directory.GetFiles(Projekt_Bus_temp.filename.path & "/Texture", "*.*", IO.SearchOption.TopDirectoryOnly)
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
                        End If
                    Next
                Next

            End If



            VariablenAusOrdnerLaden(.varlists, .filename)


            PBMain.Value = 0
            If getProj.model Is Nothing Then
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
                TVHelper.Nodes(11).Nodes.Add("Spot " & i)
            Next

            Mat_CBTextTex.Items.Clear()
            Mat_CBTextTex.Items.Add("")
            For Each TextTex In model.TextTexturen
                Mat_CBTextTex.Items.Add(TextTex.name)
            Next

            TVHelper.Nodes(4).Nodes.Clear()
            For i = 0 To model.intLichter.Count - 1
                TVHelper.Nodes(4).Nodes.Add("Innen Licht " & i)
            Next

            TVHelper.Nodes(5).Nodes.Clear()
            For i = 0 To model.rauch.Count - 1
                TVHelper.Nodes(5).Nodes.Add("Rauch " & i)
            Next


            loadIntLichter(Bel_CB0, model.intLichter.Count)
            loadIntLichter(Bel_CB1, model.intLichter.Count)
            loadIntLichter(Bel_CB2, model.intLichter.Count)
            loadIntLichter(Bel_CB3, model.intLichter.Count)
        End If
    End Sub

    Private Sub showModel(ByRef meshes As List(Of OMSI_Mesh))
        AlleObjekte.Clear()
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
            Dim newMesh As OMSI_Mesh = fileimport2(New Filename(meshes(i).filename.name, getProj.filename.path & "\Model"))
            If Not newMesh Is Nothing Then
                items_temp.Add(newMesh.filename.name)
                meshes(i).index = newMesh.index
                meshes(i).ObjIds = newMesh.ObjIds
                meshes(i).center = newMesh.center
                If meshes(i).lodMin <= lodVal And meshes(i).lodMax >= lodVal Then
                    AlleObjekte(AlleObjekte.Count - 1).visible = True
                Else
                    AlleObjekte(AlleObjekte.Count - 1).visible = False
                End If
            End If

            ctMesh += 1
            PBMain.Value = Convert.ToInt16(ctMesh / meshes.Count * 100)
        Next

        Dim newMeshesStart As Integer = LBMeshes.Items.Count
        LBMeshes.Items.AddRange(items_temp.ToArray)
        For iMeshes As Integer = newMeshesStart To LBMeshes.Items.Count - 1
            LBMeshes.SetItemChecked(iMeshes, True)
        Next

        Parent_CBParent.Items.AddRange(items_temp.ToArray)
        GlMain.Invalidate()
        TCObjektePMeshes.Text = "Meshes (" & AlleObjekte.Count & ")"
    End Sub

    Public Sub loadNewModel(model As OMSI_Model)
        getProj.model = model

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
        If Not getProj.cabin Is Nothing Then
            If Not getProj.paths Is Nothing Then

                Dim links As New List(Of Point)
                Dim directions As New List(Of Boolean)

                For Each door In getProj.cabin.doors
                    For Each link In getProj.paths.pathLinks
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
                For Each link In getProj.paths.pathLinks
                    If link.x = Projekt_Bus.cabin.linkToNextVeh Then
                        links.Add(link)
                        directions.Add(False)
                    End If

                    If link.Y = Projekt_Bus.cabin.linkToNextVeh Then
                        links.Add(New Point(link.y, link.x))
                        directions.Add(False)
                    End If

                    If link.x = Projekt_Bus.cabin.linkToPrevVeh Then
                        links.Add(link)
                        directions.Add(True)
                    End If

                    If link.Y = Projekt_Bus.cabin.linkToPrevVeh Then
                        links.Add(New Point(link.y, link.x))
                        directions.Add(True)
                    End If
                Next

                getProj.paths.calcArrows(links, directions)
            End If
        End If
    End Sub

    Public Sub VariablenAusOrdnerLaden(varlists As List(Of String), filename As Filename)

        AlleVariablen.Clear()
        AlleVarValues.Clear()

        Select Case getProjTyp()
            Case PROJ_TYPE_BUS
                AlleVariablen.AddRange(OMSI_BUS_VARS)
                For i = 0 To OMSI_BUS_VARS.Count - 1
                    AlleVarValues.Add(0)
                Next
            Case PROJ_TYPE_SCO
                AlleVariablen.AddRange(OMSI_SCO_VARS)
                For i = 0 To OMSI_SCO_VARS.Count - 1
                    AlleVarValues.Add(0)
                Next
        End Select

        AlleVariablen.AddRange(OMSI_SYS_VARS)
        For i = 0 To OMSI_SYS_VARS.Count - 1
            AlleVarValues.Add(0)
        Next

        For Each file In varlists
            Dim lines() As String = Split(My.Computer.FileSystem.ReadAllText(filename.path & "\" & file), vbCrLf)
            For Each line In lines
                If Trim(line) <> "" Then
                    If Not Trim(line).Substring(0, 1) = "'" Then
                        AlleVariablen.Add(Trim(line))
                        AlleVarValues.Add(0)
                    End If
                End If
            Next
        Next

        Dim actProj As Object = getProj()
        For i = 0 To AlleVariablen.Count - 1
            RecalcVis(AlleVariablen(i), AlleVarValues(i))
            RecalcAlpha(AlleVariablen(i), AlleVarValues(i))
        Next
    End Sub

    Private Sub projectReady()
        SpeichernToolStripMenuItem.Enabled = True
        NurProjektbusovhscoToolStripMenuItem.Enabled = True

        If getProjTyp() = PROJ_TYPE_BUS Or getProjTyp() = PROJ_TYPE_OVH Then
            NurModelToolStripMenuItem.Enabled = True
            NurPathsToolStripMenuItem.Enabled = True
            NurCabinToolStripMenuItem.Enabled = True
        End If

        SSLBStatus.Text = "Projekt geladen"
        ModelLoaded = True
    End Sub

    Private Sub loadIntLichter(CB As ComboBox, count As Integer)
        CB.Items.Clear()
        For i = -1 To count - 1
            CB.Items.Add(i)
        Next
    End Sub

    Private Sub BeendenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BeendenToolStripMenuItem.Click
        If exitApplication() Then Me.Close()
    End Sub

    Public Sub EigenschaftenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EigenschaftenToolStripMenuItem.Click
        Select Case getProjTyp()
            Case PROJ_TYPE_EMT
                MsgBox("Bitte erst ein Projekt öffnen oder erstellen!")
            Case PROJ_TYPE_BUS
                Frm_Eig_Bus.Projekt_Bus = getProj()
                Frm_Eig_Bus.Show()
            Case PROJ_TYPE_SCO
                Frm_Eig_Sco.Projekt_Sco = getProj()
                Frm_Eig_Sco.Show()
            Case PROJ_TYPE_SLI
                Frm_Eig_Sli.Projekt_Sli = getProj()
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

    Private Sub AlphaAnzeigenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AlphaAnzeigenToolStripMenuItem.Click
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

    Private Sub SoundToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SoundToolStripMenuItem.Click
        If getProj() Is Projekt_Bus Or getProj() Is Projekt_Ovh Then
            Frm_Sounds.Show()
        Else
            If getProj() Is Projekt_Emt Then
                MsgNoProj()
            Else
                MsgBox("Für diesen Projekttyp stehen keine Eigenschaften zur Verfügung!")
            End If

        End If
    End Sub

    Private Sub ImportierenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportierenToolStripMenuItem.Click
        fileImport()
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
        If Not getProj() Is Projekt_Emt Then
            If Not getProj.filename Is Nothing Then ProjÖffnen(getProj.filename.ToString)
        End If
    End Sub

    Private Sub AllesToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AllesToolStripMenuItem1.Click
        save()
    End Sub

    Private Sub NurProjektbusovhscoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NurProjektbusovhscoToolStripMenuItem.Click
        getProj.save(True)
        SSLBStatus.Text = "Projektdatei gespeichert"
    End Sub

    Private Sub NurModelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NurModelToolStripMenuItem.Click
        getProj.model.save()
        SSLBStatus.Text = "Model-Datei gespeichert"
    End Sub

    Private Sub NurCabinToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NurCabinToolStripMenuItem.Click
        If getProjTyp() = PROJ_TYPE_BUS Or getProjTyp() = PROJ_TYPE_OVH Then
            getProj.cabin.save()
            SSLBStatus.Text = "Cabin-Datei gespeichert"
        End If
    End Sub

    Private Sub NurPathsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NurPathsToolStripMenuItem.Click
        If getProjTyp() = PROJ_TYPE_BUS Or getProjTyp() = PROJ_TYPE_OVH Then
            getProj.paths.save()
            SSLBStatus.Text = "Path-Datei gespeichert"
        End If
    End Sub

    Private Sub SpeichernUnterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SpeichernUnterToolStripMenuItem.Click
        Frm_Save.ShowDialog()
        Me.Text = getProj.filename.ToString & " - " & My.Application.Info.Title
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
        Frm_FindMesh.Show()
    End Sub

    Private Sub FahrrersichtToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FahrrersichtToolStripMenuItem.Click
        viewPoint = 1
        GlMain.Invalidate()
    End Sub

    Private Sub PassagiersichtToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PassagiersichtToolStripMenuItem.Click
        viewPoint = 2
        GlMain.Invalidate()
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
        Frm_lod.Show()
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
        My.Settings.PfadeOrigBreite = sender.checked
        My.Settings.Save()
    End Sub

    Private Sub LogfileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogfileToolStripMenuItem.Click
        Shell("C:\WINDOWS\Notepad.exe " & Application.StartupPath & "\" & Log.logfile, 1)
    End Sub

    Private Sub ReadmetxtToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReadmetxtToolStripMenuItem.Click
        If Not getProj() Is Nothing Then
            Dim readmeFile As String = getProj.filename.path & "\readme.txt"
            If Not My.Computer.FileSystem.FileExists(readmeFile) Then
                Dim fw As New FileWriter(New Filename(readmeFile))
                fw.Write()
            End If
            Shell("C:\WINDOWS\Notepad.exe " & readmeFile, 1)
        Else
            MsgNoProj()
        End If
    End Sub

    Private Sub RechnerToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles RechnerToolStripMenuItem.Click
        Frm_Math.Show()
    End Sub

    Private Sub ProjektordnerÖffnenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProjektordnerÖffnenToolStripMenuItem.Click
        If getProj.filename.path <> "" Then
            Process.Start(getProj.filename.path)
        Else
            MsgNoProj()
        End If
    End Sub

    Private Sub VarlistsToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles VarlistsToolStripMenuItem.Click
        If getProjTyp() = PROJ_TYPE_BUS Or getProjTyp() = PROJ_TYPE_OVH Or getProjTyp() = PROJ_TYPE_SCO Then
            Frm_Listen.LoadFilled(getProj(), "Varlists", getProj().filename.path, "txt")
        End If
    End Sub

    Private Sub VarnamelistToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StringvarlistToolStripMenuItem.Click
        If getProjTyp() = PROJ_TYPE_BUS Or getProjTyp() = PROJ_TYPE_OVH Or getProjTyp() = PROJ_TYPE_SCO Then
            Frm_Listen.LoadFilled(getProj(), "Stringvarlists", getProj().filename.path, "txt")
        End If
    End Sub

    Private Sub ScriptsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ScriptsToolStripMenuItem.Click
        If getProjTyp() = PROJ_TYPE_BUS Or getProjTyp() = PROJ_TYPE_OVH Or getProjTyp() = PROJ_TYPE_SCO Then
            Frm_Listen.LoadFilled(getProj(), "Scripts", getProj().filename.path, "osc")
        End If
    End Sub

    Private Sub ConstfilesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConstfilesToolStripMenuItem.Click
        If getProjTyp() = PROJ_TYPE_BUS Or getProjTyp() = PROJ_TYPE_OVH Or getProjTyp() = PROJ_TYPE_SCO Then
            Frm_Listen.LoadFilled(getProj(), "Constfiles", getProj().filename.path, "txt")
        End If
    End Sub

    Private Sub ScriptToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ScriptToolStripMenuItem.Click
        If getProj() Is Projekt_Bus Or getProj() Is Projekt_Sco Or getProj() Is Projekt_Ovh Then
            If Not getProj.varlists Is Nothing Then VarlistsToolStripMenuItem.Text = "Varlists (" & getProj.varlists.Count & ")"
            If Not getProj.stringvarlists Is Nothing Then StringvarlistToolStripMenuItem.Text = "Stringvarlists (" & getProj.stringvarlists.Count & ")"
            If Not getProj.scripts Is Nothing Then ScriptsToolStripMenuItem.Text = "Scripts (" & getProj.scripts.Count & ")"
            If Not getProj.constfiles Is Nothing Then ConstfilesToolStripMenuItem.Text = "Constfiles (" & getProj.constfiles.Count & ")"
        End If
    End Sub

    Private Sub VariablenTestToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VariablenTestToolStripMenuItem.Click
        If AlleVariablen.Count > 0 Then
            Frm_VarTest.Show()
        Else
            MsgBox("Bitte zunächst Varlisten importieren!", , "Warnung!")
        End If
    End Sub

    Private Sub SitzplatzToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SitzplatzToolStripMenuItem.Click
        If getProjTyp() = PROJ_TYPE_BUS Then

            Dim cabincount As Integer = 0
            If Projekt_Bus.cabin Is Nothing Then
                Projekt_Bus.cabin = New OMSI_Cabin
            Else
                cabincount = Projekt_Bus.cabin.passPos.Count

            End If
        End If
    End Sub

    Private Sub PfadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PfadToolStripMenuItem.Click
        If getProjTyp() = PROJ_TYPE_BUS Then

            Dim pathcount As Integer = 0
            If getProj.paths Is Nothing Then
                getProj.paths = New OMSI_Paths
            Else
                pathcount = getProj.paths.pathPoints.Count
            End If

            Dim newName As String = InputBox("Pfadpunkt benennen:", "Neuer Pfadpunkt", "Punkt_" & pathcount)

            If newName = "" Then
                Exit Sub
            End If

            getProj.paths.pathPoints.Add(New Point3D)
            getProj.paths.recalc()

            LBPfade.Items.Add(newName)
            Pfade_DDNachste_0.Items.Add(newName)
        End If
    End Sub

    Public Sub RepaintToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RepaintToolStripMenuItem.Click
        Frm_Rep.Projekt_Bus = getProj()
        Frm_Rep.Show()
    End Sub

    Private Sub NeuToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles NeuToolStripMenuItem2.Click
        LichtToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub LichtToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LichtToolStripMenuItem.Click
        If getProjTyp() = PROJ_TYPE_BUS Or getProjTyp() = PROJ_TYPE_SCO Then
            Dim newName As String = InputBox("Licht benennen:", "Neues Licht", "Licht_" & getProj.model.lichter.count)

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
                    newLicht.parent = getProj.model.meshes(0).filename.name
                End If
            End If

            getProj.model.lichter.Add(newLicht)
            LBLichter.Items.Add(newLicht.name)
            LBLichter.SelectedIndex = LBLichter.Items.Count - 1

        Else
            MsgNoProj()
        End If
    End Sub

    Private Sub SpotToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SpotToolStripMenuItem.Click
        If getProjTyp() = PROJ_TYPE_BUS Or getProjTyp() = PROJ_TYPE_SCO Then
            Dim newName As String = InputBox("Spot benennen: (leer = laufende Nummer)", "Neuer Spot", "Spot_" & getProj.model.spots.count)

            If newName = "" Then
                Exit Sub
            End If

            Dim newSpot As New OMSI_Spot
            newSpot.name = newName
            newSpot.range = 50
            newSpot.outerCone = 70
            newSpot.innerCone = 30

            getProj.model.spots.Add(newSpot)
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
        With My.Settings
            .PObjekteX = PanelObjekte.Left
            .PObjekteY = PanelObjekte.Top
            .PObjekteW = PanelObjekte.Width
            .PObjekteH = PanelObjekte.Height
            .PObjekteV = PanelObjekte.Visible

            .PTextureX = PanelTexture.Left
            .PTextureY = PanelTexture.Top
            .PTextureW = PanelTexture.Width
            .PTextureH = PanelTexture.Height
            .PTextureV = PanelTexture.Visible

            .PEigenschaftenX = PanelEigenschaften.Left
            .PEigenschaftenY = PanelEigenschaften.Top
            .PEigenschaftenH = PanelEigenschaften.Height
            .PEigenschaftenV = PanelEigenschaften.Visible


            .WireframeV = WireframeToolStripMenuItem.Checked
            .GitterV = GitterToolStripMenuItem.Checked
            .ShowAlpha = AlphaAnzeigenToolStripMenuItem.Checked
            ObjekteToolStripMenuItem.Checked = PanelObjekte.Visible
            TextureToolStripMenuItem.Checked = PanelTexture.Visible
            EigenschaftenFensterToolStripMenuItem.Checked = PanelEigenschaften.Visible

        End With
    End Sub

    Public Sub loadPositions()
        checkForStdPos()

        With My.Settings
            PanelObjekte.Left = .PObjekteX
            PanelObjekte.Top = .PObjekteY
            PanelObjekte.Width = .PObjekteW
            PanelObjekte.Height = .PObjekteH
            BTObjekteResize.Left = .PObjekteW - 5
            BTObjekteResize.Top = .PObjekteH - 5
            PanelObjekte.Visible = .PObjekteV

            PanelTexture.Left = .PTextureX
            PanelTexture.Top = .PTextureY
            PanelTexture.Width = .PTextureW
            PanelTexture.Height = .PTextureH
            PanelTexture.Visible = .PTextureV

            PanelEigenschaften.Left = .PEigenschaftenX
            PanelEigenschaften.Top = .PEigenschaftenY
            PanelEigenschaften.Height = .PEigenschaftenH
            PanelEigenschaften.Visible = .PEigenschaftenV
            BTEigenschafteResize.Top = .PEigenschaftenH - 3
            PanelEigenschaften1.Height = .PEigenschaftenH - 28

            WireframeToolStripMenuItem.Checked = .WireframeV
            GitterToolStripMenuItem.Checked = .GitterV
            AlphaAnzeigenToolStripMenuItem.Checked = .ShowAlpha
            ObjekteToolStripMenuItem.Checked = PanelObjekte.Visible
            TextureToolStripMenuItem.Checked = PanelTexture.Visible
            EigenschaftenFensterToolStripMenuItem.Checked = PanelEigenschaften.Visible

            PfadeInOriginalbreiteToolStripMenuItem.Checked = .PfadeOrigBreite

            checkPanelPosition(PanelEigenschaften)
            checkPanelPosition(PanelTexture)
            checkPanelPosition(PanelObjekte)
        End With
    End Sub

    Private Sub checkForStdPos()
        With My.Settings
            If .PEigenschaftenV Then
                If .PEigenschaftenX = 410 Then
                    .PEigenschaftenX = Width - PanelEigenschaften.Width - 3
                End If
            End If

            If .PTextureV Then
                If .PTextureY = 338 Then
                    .PTextureY = Height - PanelTexture.Height - 3
                End If
            End If
        End With
        My.Settings.Save()
    End Sub


    Private Sub checkPanelPosition(e As Panel)
        If e.Visible = False Then Exit Sub
        If e.Top < 0 Then e.Top = 5
        If e.Left < 0 Then e.Left = 5
        If e.Top + e.Height > PanelMain.Height Then e.Top = PanelMain.Height - e.Height - 5
        If e.Left + e.Width > PanelMain.Width Then e.Left = PanelMain.Width - e.Width - 5

        panelCollision(e, PanelTexture)
        panelCollision(e, PanelObjekte)
        panelCollision(e, PanelEigenschaften)
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
                    If e.Left < 5 Then
                        e.Left = 5
                        o.Left = e.Width + 8
                    End If
                    If e.Top < 5 Then
                        e.Top = 3
                        o.Top = e.Height + 8
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
        For Each objekt In AlleObjekte
            For Each mesh In getProj.model.meshes
                If mesh.filename.name = LBMeshes.SelectedItem Then
                    If mesh.ObjIds.Contains(objekt.id) Then
                        AlleObjekte.Remove(objekt)
                        LBMeshes.Items.Remove(LBMeshes.SelectedItem)
                        GlMain.Invalidate()
                        getProj.model.meshes.Remove(mesh)

                        If AlleObjekte.Count > 0 Then
                            TCObjektePMeshes.Text = "Meshes (" & AlleObjekte.Count & ")"
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
            For Each objekt In AlleObjekte
                For Each mesh In getProj.model.meshes
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
        For Each mesh In getProj.model.meshes
            For Each Objekt In AlleObjekte
                If mesh.ObjIds.Contains(Objekt.id) Then
                    Modifier.flipZ(Objekt)
                End If
            Next
        Next
        GlMain.Invalidate()
    End Sub

    Private Sub LeftRightHandetToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LeftRightHandedToolStripMenuItem.Click
        For Each mesh In getProj.model.meshes
            For Each Objekt In AlleObjekte
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

    Private Function getSelectedSpiegel() As Reflex_Kamera
        If Not Projekt_Bus Is Nothing Then
            If TVHelper.SelectedNode.FullPath.Contains("\") Then
                If TVHelper.SelectedNode.FullPath.Split("\")(0) = TVHelper.Nodes(6).Text Then
                    If TVHelper.SelectedNode.Index > -1 Then
                        Return Projekt_Bus.spiegel(TVHelper.SelectedNode.Index)
                    End If
                End If
            End If
        End If
        Return Nothing
    End Function


    '####  Achse  ####

    Private Function getSelectedAchse() As OMSI_Achse
        If getProjTyp() = PROJ_TYPE_BUS Or getProjTyp() = PROJ_TYPE_OVH Then
            If TVHelper.SelectedNode.FullPath.Contains("\") Then
                If TVHelper.SelectedNode.FullPath.Split("\")(0) = TVHelper.Nodes(0).Text Then
                    If TVHelper.SelectedNode.Index > -1 Then
                        Return getProj.achsen(TVHelper.SelectedNode.Index)
                    End If
                End If
            End If
        End If
        Return Nothing
    End Function

    Private Sub AchseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AchseToolStripMenuItem.Click
        If getProjTyp() = PROJ_TYPE_BUS Or getProjTyp() = PROJ_TYPE_OVH Then
            Dim newAchse As New OMSI_Achse
            With newAchse
                .achse_maxwidth = 2.5
                .achse_minwidth = 2
                .achse_raddurchmesser = 1.2
            End With
            getProj.achsen.add(newAchse)
            TVHelper.Nodes(0).Nodes.Add("Achse_" & getProj.achsen.count - 1)
        End If
    End Sub

    Private Sub Achse_TBMaxwidt_KeyDown(sender As Object, e As KeyEventArgs) Handles Achse_TBMaxwidt.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Not getSelectedAchse() Is Nothing Then
                With getSelectedAchse()
                    .achse_maxwidth = sender.Text
                    Achse_TBBreite.Text = Convert.ToString((.achse_maxwidth - .achse_minwidth) / 2)
                End With
            End If
        End If
    End Sub

    Private Sub Achse_TBMinwidt_KeyDown(sender As Object, e As KeyEventArgs) Handles Achse_TBMinwidt.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Not getSelectedAchse() Is Nothing Then
                With getSelectedAchse()
                    .achse_minwidth = sender.Text
                    Achse_TBBreite.Text = Convert.ToString((.achse_maxwidth - .achse_minwidth) / 2)
                End With
            End If
        End If
    End Sub

    Private Sub Achse_TBDaempfer_KeyDown(sender As Object, e As KeyEventArgs) Handles Achse_TBDaempfer.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Not getSelectedAchse() Is Nothing Then
                With getSelectedAchse()
                    .achse_daempfer = sender.Text
                End With
            End If
        End If
    End Sub

    Private Sub Achse_CBAntrieb_Click(sender As Object, e As EventArgs) Handles Achse_CBAntrieb.Click
        If Not getSelectedAchse() Is Nothing Then
            With getSelectedAchse()
                .achse_antrieb = sender.checked
            End With
        End If
    End Sub

    Private Sub Achse_TBDurchmesser_KeyDown(sender As Object, e As KeyEventArgs) Handles Achse_TBDurchmesser.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Not getSelectedAchse() Is Nothing Then
                With getSelectedAchse()
                    .achse_raddurchmesser = sender.Text
                End With
            End If
        End If
    End Sub

    Private Sub Achse_TBFeder_KeyDown(sender As Object, e As KeyEventArgs) Handles Achse_TBFeder.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Not getSelectedAchse() Is Nothing Then
                With getSelectedAchse()
                    .achse_feder = sender.Text
                End With
            End If
        End If
    End Sub

    Private Sub Achse_TBMaxforce_KeyDown(sender As Object, e As KeyEventArgs) Handles Achse_TBMaxforce.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Not getSelectedAchse() Is Nothing Then
                With getSelectedAchse()
                    .achse_maxforce = sender.Text
                End With
            End If
        End If
    End Sub

    '###  Kupplungspunkte  ###

    Private Sub FrontToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FrontToolStripMenuItem.Click
        If getProj() Is Projekt_Bus Then
            If Not getProj.couple_front Then
                getProj.couple_front = True
                getProj.couple_front_char = New Point3D(0, 0, 0)
                getProj.couple_front_point = New Point3D(0, 0, 0)
                TVHelper.Nodes(3).Nodes.Add("Front")
            Else
                MsgBox("Es existiert bereits ein Kupplungspunkt an der Front!")
            End If
        End If
    End Sub

    Private Sub HerckToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HeckToolStripMenuItem.Click
        If getProj() Is Projekt_Bus Then
            If Not getProj.couple_back Then
                getProj.couple_back = True
                getProj.couple_back_file = New Filename
                getProj.couple_back_point = New Point3D(0, 0, 0)
                TVHelper.Nodes(3).Nodes.Add("Heck")
            Else
                MsgBox("Es existiert bereits ein Kupplungspunkt am Heck!")
            End If
        End If
    End Sub

    Private Sub NächsterWagenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NächsterWagenToolStripMenuItem.Click
        If Not getProj.couple_back_file Is Nothing Then
            vorherigesProj = getProj.filename
            ProjÖffnen(getProj.couple_back_file.ToString)
        Else
            MsgBox("Es wurde noch kein Fahrzeugteil angekuppelt!")
        End If
    End Sub

    Private Sub VorherigerWagenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VorherigerWagenToolStripMenuItem.Click
        If Not vorherigesProj Is Nothing Then
            ProjÖffnen(vorherigesProj)
        Else
            MsgBox("Diese Funktion ist nicht verfügbar wenn der Wagen davor nicht geladen war!")
        End If
    End Sub

    '###  Kameras  ###

    Private Sub FahrerkameraToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FahrerkameraToolStripMenuItem.Click
        If getProj() Is Projekt_Bus Or getProj() Is Projekt_Ovh Then
            Dim newCam As New Kamera
            newCam.position = New Point3D()
            Projekt_Bus.driver_cam_list.Add(newCam)
            TVHelper.Nodes(2).Nodes(0).Nodes.Add("Kamera_" & Projekt_Bus.pax_cam_list.Count - 1)
        Else
            MsgBox("Dieser Projekttyp unterstützt keine Kameras!")
        End If
    End Sub

    Private Sub FahrgastkameraToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FahrgastkameraToolStripMenuItem.Click
        If getProj() Is Projekt_Bus Or getProj() Is Projekt_Ovh Then
            Dim newCam As New Kamera
            newCam.position = New Point3D()
            Projekt_Bus.pax_cam_list.Add(newCam)
            TVHelper.Nodes(2).Nodes(1).Nodes.Add("Kamera_" & Projekt_Bus.pax_cam_list.Count - 1)
        Else
            MsgBox("Dieser Projekttyp unterstützt keine Kameras!")
        End If
    End Sub

    Private Function getSelectedKamera() As Kamera
        If TVHelper.SelectedNode.FullPath.Contains("Fahrerkameras\") Then
            Return getProj().driver_cam_list(TVHelper.SelectedNode.Index)
        ElseIf TVHelper.SelectedNode.FullPath.Contains("Fahrgastkameras\") Then
            Return getProj().pax_cam_list(TVHelper.SelectedNode.Index)
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
        getProj.cam_std = TVHelper.SelectedNode.Index
    End Sub

    Private Sub Kamera_CBVerkauf_Click(sender As Object, e As EventArgs) Handles Kamera_CBVerkauf.Click
        For index = 0 To Projekt_Bus.driver_cam_list.Count - 1
            getProj().driver_cam_list(index).selling = False
            If index = TVHelper.SelectedNode.Index Then getProj.driver_cam_list(index).selling = Kamera_CBVerkauf.Checked
        Next
    End Sub

    Private Sub Kamera_CBFahrplan_Click(sender As Object, e As EventArgs) Handles Kamera_CBFahrplan.Click
        For index = 0 To Projekt_Bus.driver_cam_list.Count - 1
            getProj().driver_cam_list(index).schedule = False
            If index = TVHelper.SelectedNode.Index Then getProj.driver_cam_list(index).schedule = Kamera_CBFahrplan.Checked
        Next
    End Sub


    '####  Achse  ####

    Private Sub Achse_TBDurchmesser_TextChanged(sender As Object, e As EventArgs) Handles Achse_TBDurchmesser.TextChanged
        If Not getSelectedAchse() Is Nothing Then
            PSPos.Point = New Point3D(0, getSelectedAchse.achse_long, getSelectedAchse.achse_raddurchmesser / 2)
        End If
    End Sub

    Private Sub Achse_TBMaxwidt_TextChanged(sender As Object, e As EventArgs) Handles Achse_TBMaxwidt.TextChanged
        If Not getSelectedAchse() Is Nothing Then
            Achse_TBBreite.Text = Convert.ToString((getSelectedAchse.achse_maxwidth - getSelectedAchse.achse_minwidth) / 2)
        End If
    End Sub

    Private Sub Achse_TBMinwidt_TextChanged(sender As Object, e As EventArgs) Handles Achse_TBMinwidt.TextChanged
        If Not getSelectedAchse() Is Nothing Then
            Achse_TBBreite.Text = Convert.ToString((getSelectedAchse.achse_maxwidth - getSelectedAchse.achse_minwidth) / 2)
        End If
    End Sub

    '####  Kupplung  ####

    Private Function isKupplSelected(direction As String) As Boolean
        If getProjTyp() = PROJ_TYPE_BUS Or getProjTyp() = PROJ_TYPE_OVH Then
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
            getProj.couple_front_sound = Kuppl_CBSound.Checked
        End If
    End Sub

    Private Sub Kuppl_DDKupplType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Kuppl_DDKupplType.SelectedIndexChanged
        If isKupplSelected("front") Then
            getProj.couple_front_type = intToBool(Kuppl_DDKupplType.SelectedIndex)
        End If
    End Sub

    Private Sub Kuppl_TBDrehwinkel_TextChanged(sender As Object, e As EventArgs) Handles Kuppl_TBDrehwinkel.TextChanged
        If isKupplSelected("front") Then
            If getProj.couple_front_char Is Nothing Then getProj.couple_front_char = New Point3D
            If sender.text <> "" Then
                getProj.couple_front_char.X = toSingle(sender.Text)
            End If
        End If
    End Sub

    Private Sub Kuppl_TBDown_TextChanged(sender As Object, e As EventArgs) Handles Kuppl_TBDown.TextChanged
        If isKupplSelected("front") Then
            If getProj.couple_front_char Is Nothing Then getProj.couple_front_char = New Point3D
            If sender.text <> "" Then
                getProj.couple_front_char.Y = toSingle(sender.Text)
            End If
        End If
    End Sub

    Private Sub Kuppl_TBUp_TextChanged(sender As Object, e As EventArgs) Handles Kuppl_TBUp.TextChanged
        If isKupplSelected("front") Then
            If getProj.couple_front_char Is Nothing Then getProj.couple_front_char = New Point3D
            If sender.text <> "" Then
                getProj.couple_front_char.Z = toSingle(sender.Text)
            End If
        End If
    End Sub

    Private Sub Kuppl_DDNextVehicle_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Kuppl_DDNextVehicle.SelectedIndexChanged
        If isKupplSelected("heck") Then
            If Kuppl_DDNextVehicle.SelectedItem = "" Then
                getProj.couple_back_file = Nothing
            Else
                getProj.couple_back_file = New Filename(Kuppl_DDNextVehicle.Text, getProj.filename.path)
            End If
        End If
    End Sub

    Private Sub Kuppl_DDRichtung_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Kuppl_DDRichtung.SelectedIndexChanged
        If isKupplSelected("heck") Then
            getProj.couple_back_dir = intToBool(Kuppl_DDRichtung.SelectedIndex)
        End If
    End Sub

    Public Function getSelectedSpot() As OMSI_Spot
        If getProjTyp() = PROJ_TYPE_BUS Or getProjTyp() = PROJ_TYPE_OVH Then
            If TVHelper.SelectedNode.FullPath.Contains(TVHelper.Nodes(11).Text & "\") Then
                If TVHelper.SelectedNode.Index > getProj.model.spots.Count Then
                    If TVHelper.SelectedNode.Index > -1 Then
                        Return getProj.model.spots(TVHelper.SelectedNode.Index)
                    End If
                End If
            End If
        End If
        Return Nothing
    End Function




    ' #### TV Helper ####

    Private Sub TVHelper_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TVHelper.AfterSelect
        If TVHelper.SelectedNode.ToolTipText = "" Then
            TBName.Text = TVHelper.SelectedNode.Text
        End If
        If getProj() Is Projekt_Emt Then Exit Sub

        Dim index As Integer = TVHelper.SelectedNode.Index

        If TVHelper.SelectedNode.Text = TVHelper.Nodes(1).Text Then     'Boundingbox Then
            If Not getProj() Is Projekt_Emt Then
                showSettings({GBBbox})
                If Not getProj.bbox Is Nothing Then
                    PSPos.Point = getProj.bbox.pos
                    BBox_PSSize.Point = getProj.bbox.size
                End If
            End If
            Exit Sub
        End If

        If TVHelper.SelectedNode.FullPath.Contains("\") Then
            Select Case TVHelper.SelectedNode.FullPath.Split("\")(0)
                Case TVHelper.Nodes(0).Text     'Achsen
                    showSettings({GBAchse})
                    With getProj.achsen(index)
                        PSPos.Point = New Point3D(0, .achse_long, .achse_raddurchmesser / 2)
                        Achse_TBMaxwidt.Text = .achse_maxwidth
                        Achse_TBMinwidt.Text = .achse_minwidth
                        Achse_TBFeder.Text = .achse_feder
                        Achse_TBMaxforce.Text = .achse_maxforce
                        Achse_TBDaempfer.Text = .achse_daempfer
                        Achse_TBDurchmesser.Text = .achse_raddurchmesser
                        Achse_CBAntrieb.Checked = .achse_antrieb
                    End With

                Case TVHelper.Nodes(1).Text     'Attachpoint
                    'noch nix

                Case TVHelper.Nodes(2).Text     'Kameras
                    showSettings({GBKamera})
                    Dim selectedCamTmp As New Kamera
                    If TVHelper.SelectedNode.FullPath.Split("\")(1) = TVHelper.Nodes(2).Nodes(0).Text And getProj.driver_cam_list.Count > 0 Then
                        Kamera_RBFahrer.Checked = True
                        selectedCamTmp = getProj.driver_cam_list(index)
                        Kamera_BTStd.Enabled = True
                        Kamera_CBVerkauf.Enabled = True
                        Kamera_CBFahrplan.Enabled = True

                    ElseIf TVHelper.SelectedNode.FullPath.Split("\")(1) = TVHelper.Nodes(2).Nodes(1).Text And getProj.pax_cam_list.Count > 0 Then
                        Kamera_RBPassagier.Checked = True
                        selectedCamTmp = getProj.pax_cam_list(index)
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
                    With getProj()
                        If TVHelper.SelectedNode.Text = "Front" Then
                            Kuppl_LBFront.Visible = True
                            Kuppl_LBHeck.Visible = False
                            PSPos.Point = .couple_front_point
                            Kuppl_CBSound.Checked = .couple_front_sound
                            Kuppl_TBDrehwinkel.Text = .couple_front_char.X
                            Kuppl_TBDown.Text = .couple_front_char.Y
                            Kuppl_TBUp.Text = .couple_front_char.Z
                            Kuppl_DDKupplType.SelectedIndex = boolToInt(.couple_front_type)
                            VorherigerWagenToolStripMenuItem.Enabled = True

                        ElseIf TVHelper.SelectedNode.Text = "Heck" Then
                            Kuppl_LBFront.Visible = False
                            Kuppl_LBHeck.Visible = True
                            PSPos.Point = Projekt_Bus.couple_back_point
                            If Not getProj.couple_back_file Is Nothing Then Kuppl_DDNextVehicle.SelectedItem = getProj.couple_back_file.name
                            Kuppl_DDRichtung.SelectedIndex = boolToInt(getProj.couple_back_dir)
                            NächsterWagenToolStripMenuItem.Enabled = True
                        End If
                    End With

                Case TVHelper.Nodes(4).Text     'Innenlichter
                    showSettings({GBLicht})
                    PSPos.Point = getProj.model.intLichter(index).position

                Case TVHelper.Nodes(5).Text     'Rauch
                    showSettings({GBRauch})
                    PSPos.Point = getProj.model.rauch(index).position

                Case TVHelper.Nodes(6).Text     'Spiegel
                    showSettings({GBKamera})
                    PSPos.Point = getProj.spiegel(index).position

                Case TVHelper.Nodes(7).Text     'Sitz-/Stehplatz
                    showSettings({GBPlatz, GBBel})
                    With getProj()
                        PSPos.Point = .cabin.passPos(index).position
                    End With

                Case TVHelper.Nodes(10).Text     'Splinehelper
                    With getProj.splinehelpers(index)
                        PSPos.Point = .position
                        Splinehelper_TBDrehung.Text = .rotation.X
                        Splinehelper_TBSpline.Text = .spline.name
                    End With
                Case TVHelper.Nodes(11).Text    'Spots
                    showSettings({GBSpot})
                    With Projekt_Bus.model.spots(index) 'getProj.model.spots(index)
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
                    Projekt_Bus.achsen.RemoveAt(index)

                Case TVHelper.Nodes(2).Text     'Kameras
                    If TVHelper.SelectedNode.FullPath.Split("\")(1) = TVHelper.Nodes(2).Nodes(0).Text Then
                        getProj.driver_cam_list.RemoveAt(index)
                    ElseIf TVHelper.SelectedNode.FullPath.Split("\")(1) = TVHelper.Nodes(2).Nodes(1).Text Then
                        getProj.pax_cam_list.RemoveAt(index)
                    End If

                Case TVHelper.Nodes(3).Text     'Kupplungspunkte
                    If index = 0 Then
                        Projekt_Bus.couple_front = False
                        Projekt_Bus.couple_front_sound = False
                        VorherigerWagenToolStripMenuItem.Enabled = False
                    Else
                        Projekt_Bus.couple_back = False
                        Projekt_Bus.couple_back_file.name = ""
                        NächsterWagenToolStripMenuItem.Enabled = False
                    End If

                Case TVHelper.Nodes(4).Text     'Innenlichter
                    getProj.model.intLichter.RemoveAt(index)

                Case TVHelper.Nodes(5).Text     'Rauch
                    getProj.model.rauch.removeAt(index)

                Case TVHelper.Nodes(6).Text     'Spiegel
                    getProj.spiegel.RemoveAt(index)

                Case TVHelper.Nodes(7).Text     'Sitz-/Stehplatz
                    getProj.cabin.passPos.RemoveAt(index)

                                                'Tickets

                                                'Attachpoints

                Case TVHelper.Nodes(10).Text     'Splinehelper
                    getProj.splinehelpers.RemoveAt(index)

                Case TVHelper.Nodes(11).Text    'Spots
                    getProj.model.spots.RemoveAt(index)
            End Select

            TVHelper.Nodes.Remove(TVHelper.SelectedNode)
            GlMain.Invalidate()
        Else
            Select Case TVHelper.SelectedNode.FullPath
                Case TVHelper.Nodes(1).Text     'Boundingbox
                    BBox_PSSize.Point = New Point3D()
                    PSPos.Point = New Point3D
                    Projekt_Bus.bbox = Nothing
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
                If Not getProjTyp() = PROJ_TYPE_SLI Then
                    showSettings({GBMesh, GBMat, GBAnimation, GBBones, GBBel})
                Else
                    showSettings({GBSpline})
                End If
            Case 1
                showSettings(Nothing)
            Case 2
                showSettings({GBParent, GBLicht})
            Case 3
                If Not getProjTyp() = PROJ_TYPE_SLI Then
                    showSettings({GBPfade})
                Else
                    showSettings({GBPfad})
                End If

        End Select
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
            If LBLichter.SelectedIndex < getProj.model.lichter.Count Then
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
        With getProj.model.lichter(LBLichter.SelectedIndex)
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
            If .bitmap = "" Or My.Computer.FileSystem.FileExists(getProj.filename.path & "\Texture\" & .bitmap) Then
                Licht_TBTexture.BackColor = SystemColors.Control
            Else
                Licht_TBTexture.BackColor = Color.Red
            End If
            Parent_CBParent.Text = .parent
        End With
    End Sub

    Private Sub saveLightProps(index As Integer)
        If Not index < 0 And Not index > getProj.model.lichter.count - 1 Then
            With getProj.model.lichter(index)
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
        selectedMeshesChanged = True
        If Not getSelectedMesh() Is Nothing Then
            saveMeshProbs(lastSelectedMesh)
            showMeshProps(getSelectedMesh)
        End If
        GlMain.Invalidate()
        lastSelectedMesh = getSelectedMesh()
    End Sub

    Private Sub showMeshProps(mesh As OMSI_Mesh)
        If Not mesh Is Nothing Then
            With mesh
                'Allgemein
                TBName.Text = .filename.name
                PSPos.Point = .position

                'Mesh
                Mesh_DDViedpoint.SelectedIndex = .viewpoint
                Mesh_VSSichtbarkeit.Variable = .visibleVar
                Mesh_TBSichtbarkeitVal.Text = Convert.ToString(.visibleInt)
                Mesh_VSKlickevent.Variable = .mouseevent
                Mesh_PSCenter.Point = .center
                Mesh_NUMin.Value = Convert.ToDecimal(.lodMin)
                Mesh_NUMax.Value = Convert.ToDecimal(.lodMax)
                Mesh_TBMeshident.Text = .meshident

                'Parent
                Parent_CBParent.Text = .animparent

                'Materialien
                Mat_CBTex.Items.Clear()
                For Each id In getSelectedObjektId()
                    For Each texture In AlleObjekte(id).texturen
                        Mat_CBTex.Items.Add(texture.filename.name)
                    Next
                Next
                'Weitere Mat eig werden mit dem verändern der Texture geladen

                If Mat_CBTex.Items.Count > 0 Then
                    Mat_CBTex.SelectedIndex = 0
                    'Mat_CBTextTex.SelectedItem = Projekt_Bus.model.TextTexturen(Mat_CBTex.SelectedIndex).name
                Else
                    Mat_CBTextTex.SelectedIndex = 0
                End If

                'Animation
                Anim_TBAnimGrp.Text = .animparent
                Anim_DDList.Items.Clear()
                If .animations.Count > 0 Then
                    For i = 0 To .animations.Count - 1
                        Anim_DDList.Items.Add(i)
                    Next
                    Anim_DDList.SelectedIndex = 0
                    AnimDetails(mesh, 0)
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
                .mouseevent = Mesh_VSKlickevent.Variable
                .center = Mesh_PSCenter.Point
                .lodMin = Mesh_NUMin.Value
                .lodMax = Mesh_NUMax.Value
                .meshident = Mesh_TBMeshident.Text

                'Animation
                .animparent = Anim_TBAnimGrp.Text

            End With
        End If
    End Sub

    Private Sub Anim_CBList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Anim_DDList.SelectedIndexChanged
        AnimDetails(getSelectedMesh, Anim_DDList.SelectedIndex)
    End Sub

    Private Sub AnimDetails(mesh As OMSI_Mesh, id As Integer)
        With mesh
            If .animations(id).anim_type = OMSI_Anim.TYPE_ROTATION Then
                Anim_RBDrehen.Checked = True
                Anim_RBVerschieben.Checked = False
            Else
                Anim_RBDrehen.Checked = False
                Anim_RBVerschieben.Checked = True
            End If

            Anim_VSVar.Variable = .animations(id).anim_var
            Anim_TBValue.Text = .animations(id).anim_val
            If Not .animations(id).origin_trans = New Point3D Then
                Anim_RBCenter.Checked = False
                Anim_RBPoint.Checked = True
                Anim_PSRotPnt.Point = .animations(id).origin_trans
            Else
                Anim_RBCenter.Checked = True
                Anim_RBPoint.Checked = False
                Anim_PSRotPnt.Point = New Point3D
            End If
        End With
    End Sub

    Private Sub Anim_RBPoint_CheckedChanged(sender As Object, e As EventArgs) Handles Anim_RBPoint.CheckedChanged
        Anim_PSRotPnt.Enabled = Anim_RBPoint.Checked
    End Sub

    'Panel Texture ##########

    Private Sub PanelTextureFill_Click(sender As Object, e As EventArgs) Handles PanelTextureFill.Click
        With Frm_Texture
            If PBTexture.Tag <> "" Then
                .ImageTag = PBTexture.Tag
                .Text = "Texture - """ & PBTexture.Tag & """"

                Dim allSubObjekte As New List(Of Integer)
                Dim allTexCoords As Double() = {}
                For Each Objekt In AlleObjekte

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
            For Each Objekt In AlleObjekte
                For Each texture In Objekt.texturen
                    If texture.filename.name = file Then
                        If My.Computer.FileSystem.FileExists(texture.filename) Then
                            PBTexture.Tag = texture.filename
                            DisplayImage(PBTexture)

                            Exit Sub
                        End If
                    End If
                Next
            Next
            PBTexture.Image = My.Resources.pink
            If IO.File.Exists(Projekt_Bus.filename.path & "\Texture\" & file) Then
                PBTexture.Tag = Projekt_Bus.filename.path & "\Texture\" & file
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
        For Each localObject In AlleObjekte
            For Each texture In localObject.texturen
                TexturecheckLastChange(texture)
            Next
        Next
        For Each texture In overWriteTextures
            TexturecheckLastChange(texture)
        Next
        GlMain.Invalidate()
    End Sub

    Private Sub TexturecheckLastChange(texture As LocalTexture)
        If IO.File.Exists(texture.filename) Then
            If Not IO.File.GetLastWriteTime(texture.filename) = texture.lastChangeDate Then
                texture.lastChangeDate = IO.File.GetLastWriteTime(texture.filename)
                loadTexture(texture, True)
                If texture.filename.name = DDAlleTexturen.Text Then
                    SelectedTextureChanged(DDAlleTexturen.Text)
                End If
            End If
        End If
    End Sub


    Private Function getSelectedLight() As OMSI_Licht
        If LBLichter.SelectedIndex >= 0 Then
            If Not getProj().model Is Nothing Then
                For Each light In getProj.model.lichter
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
            If Not getProjTyp() = PROJ_TYPE_SLI Then
                If Not getProj().model Is Nothing Then
                    selectedMesh = getProj().model.meshes(LBMeshes.SelectedIndex)
                    Return selectedMesh
                End If
            Else
                Dim newMesh As New OMSI_Mesh
                With newMesh
                    .filename = New Filename(LBMeshes.SelectedItem, getProj.filename.path)
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
            If getProj() Is Projekt_Bus Or getProj() Is Projekt_Emt Or getProj() Is Projekt_Sco Then
                If Not getProj().model Is Nothing Then
                    For Each mesh In getProj.model.meshes
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

            If getProj() Is Projekt_Sli Then
                Dim newMesh As New OMSI_Mesh
                With newMesh
                    .filename = New Filename(LBMeshes.SelectedItem, getProj.filename.path)
                    .ObjIds.Add(LBMeshes.SelectedIndex)
                End With
                selectedMeshes.Add(newMesh)
            End If
        End If

        Return Nothing
    End Function

    Private Function getSelectedObjektId() As List(Of Int16)
        If LBMeshes.SelectedIndex >= 0 Then
            If Not getProjTyp() = PROJ_TYPE_SLI Then
                If Not getProj.model Is Nothing Then
                    For Each mesh In getProj.model.meshes
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
        GBMinMaxButton(sender, GBSplinehelper)
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
                                If sender.name = "TBY" Then getSelectedAchse.achse_long = PSPos.Y
                                If sender.name = "TBZ" Then
                                    getSelectedAchse.achse_raddurchmesser = PSPos.Z * 2
                                    Achse_TBDurchmesser.Text = PSPos.Z * 2
                                End If
                            End If

                        Case TVHelper.Nodes(1).Text     'Boundingbox
                            If Not getProj.bbox Is Nothing Then
                                getProj.bbox.pos = PSPos.Point
                            End If

                        Case TVHelper.Nodes(2).Text     'Kameras
                            If Not getSelectedKamera() Is Nothing Then
                                getSelectedKamera.position = New Point3D(PSPos.Point)
                            End If

                        Case TVHelper.Nodes(3).Text     'Kupplung
                                If TVHelper.SelectedNode.FullPath.Split("\")(1) = "Front" Then
                                    Projekt_Bus.couple_front_point = PSPos.Point
                                ElseIf TVHelper.SelectedNode.FullPath.Split("\")(1) = "Heck" Then
                                    Projekt_Bus.couple_back_point = PSPos.Point
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
                        getProj.paths.pathPoints(LBPfade.SelectedIndex) = PSPos.Point
                        getProj.paths.recalc
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
            If My.Settings.OrtoScale = 3 Then
                My.Settings.OrtoScale = 4
            Else
                My.Settings.OrtoScale = 3
            End If
            My.Settings.Save()
            My.Settings.Reload()
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
                    With LBMeshes
                        If .SelectedIndex > 0 Then
                            Dim tempMeshName As String = .SelectedItem
                            .Items(.SelectedIndex) = .Items(.SelectedIndex - 1)
                            .Items(.SelectedIndex - 1) = tempMeshName
                            .SelectedIndex -= 1
                        End If
                    End With
                    e.Handled = True
                End If
            Case Keys.Down
                If e.Control Then
                    With LBMeshes
                        If .SelectedIndex < .Items.Count - 1 Then
                            Dim tempMeshName As String = .SelectedItem
                            .Items(.SelectedIndex) = .Items(.SelectedIndex + 1)
                            .Items(.SelectedIndex + 1) = tempMeshName
                            .SelectedIndex += 1
                        End If
                    End With
                    e.Handled = True
                End If

            Case Keys.Right
                If viewPoint = 1 Then
                    selectedDriverCam += 1
                    If selectedDriverCam > Projekt_Bus.driver_cam_list.Count - 1 Then selectedDriverCam = 0
                ElseIf viewPoint = 2 Then
                    selectedPassCam += 1
                    If selectedPassCam > Projekt_Bus.pax_cam_list.Count - 1 Then selectedPassCam = 0
                End If
                GlMain.Invalidate()
            Case Keys.Left
                If viewPoint = 1 Then
                    selectedDriverCam -= 1
                    If selectedDriverCam < 0 Then selectedDriverCam = Projekt_Bus.driver_cam_list.Count - 1
                ElseIf viewPoint = 2 Then
                    selectedPassCam -= 1
                    If selectedPassCam < 0 Then selectedPassCam = Projekt_Bus.pax_cam_list.Count - 1
                End If
                GlMain.Invalidate()
            Case Else
                'für Mausbewegung
                mainShift = e.Shift
                mainStrg = e.Control
        End Select
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
        GL.ClearColor(My.Settings.BackColor3D)
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
        If DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() - last_draw < 1000 / My.Settings.fpsLimit Then Exit Sub
        last_draw = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()

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
        GL.ClearColor(My.Settings.BackColor3D)
        GL.LoadMatrix(lookat)
        GL.Viewport(0, 0, GlMain.Width, GlMain.Height) 'Size of window


        'Offset der Kamera zum Mittelpunkt der Szene
        If getProj() Is Projekt_Bus And viewPoint < 3 Then
            lookat = Matrix4.LookAt(Convert.ToSingle(0.0000001), Convert.ToSingle(0.000001), 0, 0, 0, 0, 0, 1, 0) 'Setup camera
            GL.LoadMatrix(lookat)
            If viewPoint = 1 Then
                With Projekt_Bus.driver_cam_list(selectedDriverCam)


                    'Spiegelberechnung nur in der Fahreransicht
                    If mirrorRender = True Then
                        With Projekt_Bus.spiegel(mirrorID)
                            GL.Translate(- .position.toVector3new)
                            'GL.Rotate(-(.rotX - 90), 0, 1, 0)
                            'GL.Rotate(-(.rotY + 90), 0, 0, 1)


                            'GL.Translate(New Vector3(0, -6, -2))
                            GL.Rotate(90 + .rotY, 0, 0, 1)
                            GL.Rotate(90, 0, 1, 0)

                        End With
                    Else
                        For i As Integer = 0 To Projekt_Bus.spiegel.Count - 1
                            GlMain_Paint(GlMain, Nothing, True, i)

                            With Projekt_Bus.spiegel(i)

                                GL.Rotate(-90, 0, 1, 0) '-90
                                GL.Rotate(-(.rotY + 90), 0, 0, 1) '45
                                'GL.Translate(New Vector3(0, 6, 2))

                                'GL.Rotate(.rotY + 90, 0, 0, 1)
                                'GL.Rotate(.rotX - 90, 0, 1, 0)
                                GL.Translate(.position.toVector3new)

                            End With
                        Next

                        GL.Rotate(.rotY + 90, 0, 0, 1)
                        GL.Rotate(.rotX - 90, 0, 1, 0)

                        GL.Translate(New Vector3(.position.toVector3))

                    End If




                End With
            ElseIf viewPoint = 2 Then
                With Projekt_Bus.pax_cam_list(selectedPassCam)
                    GL.Rotate(.rotY + 90, 0, 0, 1)
                    GL.Rotate(.rotX - 90, 0, 1, 0)
                    GL.Translate(New Vector3(.position.toVector3))
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
                    If getProj() Is Projekt_Bus Then
                        GL.Translate(New Vector3(Projekt_Bus.cam_outeside.toVector3))
                    End If
                Case 4
                    GL.Translate(New Vector3(CamLocation.X, CamLocation.Z, CamLocation.Y))
            End Select

        End If



        If My.Settings.GitterV Then
            GL.BindTexture(TextureTarget.Texture2D, 0)
            GL.Begin(PrimitiveType.Lines)
            GL.Color3(My.Settings.LineColor3D)

            For i As Integer = -10 To 10
                If i = 0 Then GL.Color3(Color.Green) Else GL.Color3(My.Settings.LineColor3D)
                GL.Vertex3(i, 0, -10)
                GL.Vertex3(i, 0, 10)
                If i = 0 Then GL.Color3(Color.Red) Else GL.Color3(My.Settings.LineColor3D)
                GL.Vertex3(-10, 0, i)
                GL.Vertex3(10, 0, i)
            Next i
            GL.End()
        End If






        If ModelLoaded Then
            GL.DepthFunc(DepthFunction.Less)        'Tiefenkorrektur einschalten (ist für Helfer abgeschaltet)
            For Each objekt In AlleObjekte
                drawL3D(objekt)
            Next
        End If

        If getProj() Is Projekt_Sco Then
            If Projekt_Sco.isloaded Then
                GL.LineWidth(3)
                GL.BindTexture(TextureTarget.Texture2D, 0)
                GL.DepthFunc(DepthFunction.Always)              'Alles wird in den Vordergrund gezeichnet
                GL.LineWidth(1)

                Select Case TCObjekte.SelectedIndex
                    Case 1

                        If Not Projekt_Sco.cabin Is Nothing Then
                            For Each seat In Projekt_Sco.cabin.passPos
                                GL.Color3(My.Settings.PassColor)

                                GL.VertexPointer(3, VertexPointerType.Double, 0, seat.vertices)
                                GL.DrawElements(PrimitiveType.Triangles, seat.edges.Count, DrawElementsType.UnsignedInt, seat.edges)
                                GL.Color3(Color.Black)
                                GL.DrawElements(PrimitiveType.Lines, seat.lines.Count, DrawElementsType.UnsignedInt, seat.lines)
                            Next
                        End If

                        If Not Projekt_Sco.ki_paths Is Nothing Then
                            GL.Color3(Color.Black)
                            For Each path In Projekt_Sco.ki_paths
                                With path
                                    GL.VertexPointer(3, VertexPointerType.Double, 0, .vertices)
                                    GL.DrawElements(PrimitiveType.Lines, .edges.Count, DrawElementsType.UnsignedInt, .edges)
                                End With
                            Next
                        End If
                End Select
            End If
        End If


        If getProj() Is Projekt_Sco Then
            If Not getProj.model Is Nothing Then
                GL.LineWidth(3)
                GL.BindTexture(TextureTarget.Texture2D, 0)
                GL.DepthFunc(DepthFunction.Always)              'Alles wird in den Vordergrund gezeichnet

                Select Case TCObjekte.SelectedIndex
                    Case 2
                        GL.BindTexture(TextureTarget.Texture2D, 0)
                        Dim i As Integer = 0
                        For Each licht In Projekt_Sco.model.lichter
                            With licht
                                GL.Color3(.color.R, .color.G, .color.B)
                                If i = LBLichter.SelectedIndex Then
                                    If timerBool Then
                                        GL.Color3(Color.Black)
                                    End If
                                End If

                                GL.VertexPointer(3, VertexPointerType.Double, 0, .vertices)
                                GL.DrawElements(PrimitiveType.Triangles, .edges.Count, DrawElementsType.UnsignedInt, .edges)
                            End With
                            i += 1
                        Next
                End Select
            End If
        End If


        If getProj() Is Projekt_Bus Then
            If Not getProj.model Is Nothing Then
                GL.LineWidth(3)
                GL.BindTexture(TextureTarget.Texture2D, 0)
                GL.DepthFunc(DepthFunction.Always)              'Alles wird in den Vordergrund gezeichnet

                Select Case TCObjekte.SelectedIndex
                    Case 0
                        GL.Color3(My.Settings.AchsenColor)

                        If Not getSelectedMesh() Is Nothing Then
                            For Each anim In getSelectedMesh.animations
                                With anim
                                    GL.VertexPointer(3, VertexPointerType.Double, 0, .vertices)
                                    GL.DrawElements(PrimitiveType.Lines, .edges.Count, DrawElementsType.UnsignedInt, .edges)
                                End With
                            Next
                        End If

                    Case 1
                        GL.VertexPointer(3, VertexPointerType.Double, 0, {0, 0, 0})
                        GL.TexCoordPointer(2, TexCoordPointerType.Double, 0, {0, 0})
                        For index As Integer = 0 To Projekt_Bus.driver_cam_list.Count - 1
                            With Projekt_Bus.driver_cam_list(index)
                                If TVHelper.SelectedNode.FullPath.Contains("Fahrerkameras\") And index = TVHelper.SelectedNode.Index Then
                                    GL.Color3(My.Settings.SelectionColor)
                                Else
                                    GL.Color3(My.Settings.CamDriverColor)
                                End If
                                GL.VertexPointer(3, VertexPointerType.Double, 0, .vertices)
                                GL.DrawElements(PrimitiveType.Lines, .edges.Count, DrawElementsType.UnsignedInt, .edges)
                            End With
                        Next

                        GL.Color3(My.Settings.CamPaxColor)
                        For index As Integer = 0 To Projekt_Bus.pax_cam_list.Count - 1
                            With Projekt_Bus.pax_cam_list(index)
                                If TVHelper.SelectedNode.FullPath.Contains("Fahrgastkameras\") And index = TVHelper.SelectedNode.Index Then
                                    GL.Color3(My.Settings.SelectionColor)
                                Else
                                    GL.Color3(My.Settings.CamDriverColor)
                                End If
                                GL.VertexPointer(3, VertexPointerType.Double, 0, .vertices)
                                GL.DrawElements(PrimitiveType.Lines, .edges.Count, DrawElementsType.UnsignedInt, .edges)
                            End With
                        Next

                        For i As Integer = 0 To Projekt_Bus.achsen.Count - 1
                            GL.Color3(My.Settings.AchsenColor)
                            If InStr(TVHelper.SelectedNode.FullPath, TVHelper.Nodes(0).Text & "\") And i = TVHelper.SelectedNode.Index Then GL.Color3(My.Settings.SelectionColor)
                            With Projekt_Bus.achsen(i)
                                GL.VertexPointer(3, VertexPointerType.Double, 0, .vertices)
                                GL.DrawElements(PrimitiveType.Lines, .edges.Count, DrawElementsType.UnsignedInt, .edges)
                            End With
                        Next

                        GL.Color3(My.Settings.CamReflexColor)
                        For Each kamera In Projekt_Bus.spiegel
                            With kamera
                                GL.VertexPointer(3, VertexPointerType.Double, 0, .vertices)
                                GL.DrawElements(PrimitiveType.Lines, .edges.Count, DrawElementsType.UnsignedInt, .edges)
                            End With
                        Next


                        If Not Projekt_Bus.bbox Is Nothing Then
                            With Projekt_Bus.bbox
                                GL.Color3(Color.Black)
                                GL.VertexPointer(3, VertexPointerType.Double, 0, .vertices)
                                GL.DrawElements(PrimitiveType.Lines, .edges.Count, DrawElementsType.UnsignedInt, .edges)
                            End With
                        End If


                        GL.DepthFunc(DepthFunction.Less)    'Im Vordergrund Zeichnen abschalten

                        If Not Projekt_Bus.cabin Is Nothing Then
                            GL.LineWidth(1)
                            For i As Integer = 0 To Projekt_Bus.cabin.passPos.Count - 1
                                With Projekt_Bus.cabin.passPos(i)
                                    GL.Color3(My.Settings.PassColor)
                                    If InStr(TVHelper.SelectedNode.FullPath, TVHelper.Nodes(7).Text & "\") Then
                                        If TVHelper.SelectedNode.Index = i Then
                                            GL.Color3(My.Settings.SelectionColor)
                                        End If
                                    End If
                                    GL.VertexPointer(3, VertexPointerType.Double, 0, .vertices)
                                    GL.DrawElements(PrimitiveType.Triangles, .edges.Count, DrawElementsType.UnsignedInt, .edges)
                                    GL.Color3(Color.Black)
                                    GL.DrawElements(PrimitiveType.Lines, .lines.Count, DrawElementsType.UnsignedInt, .lines)
                                End With
                            Next

                            If Not Projekt_Bus.cabin.driverPos Is Nothing Then
                                With Projekt_Bus.cabin.driverPos
                                    GL.Color3(My.Settings.DriverColor)
                                    GL.VertexPointer(3, VertexPointerType.Double, 0, .vertices)
                                    GL.DrawElements(PrimitiveType.Triangles, .edges.Count, DrawElementsType.UnsignedInt, .edges)
                                    GL.Color3(Color.Black)
                                    GL.DrawElements(PrimitiveType.Lines, .lines.Count, DrawElementsType.UnsignedInt, .lines)
                                End With
                            End If
                        End If

                        If Not Projekt_Bus.model.spots Is Nothing Then
                            If InStr(TVHelper.SelectedNode.FullPath, TVHelper.Nodes(11).Text & "\") Then
                                If TVHelper.SelectedNode.Index < Projekt_Bus.model.spots.Count Then
                                    With Projekt_Bus.model.spots(TVHelper.SelectedNode.Index)
                                        GL.Color3(.color.R, .color.G, .color.B)
                                        GL.VertexPointer(3, VertexPointerType.Double, 0, .vertices)
                                        GL.DrawElements(PrimitiveType.Triangles, .edges.Count, DrawElementsType.UnsignedInt, .edges)
                                        GL.Color3(Color.Black)
                                        GL.DrawElements(PrimitiveType.LineLoop, .lines.Count, DrawElementsType.UnsignedInt, .lines)
                                    End With
                                End If
                            End If
                        End If

                    Case 2
                        GL.BindTexture(TextureTarget.Texture2D, 0)
                        Dim i As Integer = 0
                        For Each licht In Projekt_Bus.model.lichter
                            With licht
                                GL.Color3(.color.R, .color.G, .color.B)
                                If i = LBLichter.SelectedIndex Then
                                    If timerBool Then
                                        GL.Color3(Color.Black)
                                    End If
                                End If

                                GL.VertexPointer(3, VertexPointerType.Double, 0, .vertices)
                                GL.DrawElements(PrimitiveType.TriangleFan, .edges.Count, DrawElementsType.UnsignedInt, .edges)
                            End With
                            i += 1
                        Next
                    Case 3
                        If Not Projekt_Bus.paths Is Nothing Then
                            With Projekt_Bus.paths
                                If .pathPoints.Count > 0 Then

                                    GL.Color3(Color.Pink)
                                    GL.VertexPointer(3, VertexPointerType.Double, 0, .vertices)
                                    GL.DrawElements(PrimitiveType.Lines, .edges.Count, DrawElementsType.UnsignedInt, .edges)

                                    GL.Color3(Color.Black)
                                    GL.PointSize(20)
                                    GL.BindTexture(TextureTarget.Texture2D, 0) 'dotTexture.id)

                                    For i = 0 To .dots.Count - 1
                                        If i = LBPfade.SelectedIndex Then
                                            GL.Color3(My.Settings.SelectionColor)
                                        ElseIf InStr(GBPfade.Tag, ";" & i & ";") Then
                                            GL.Color3(Color.Violet)
                                        Else
                                            GL.Color3(Color.Black)
                                        End If
                                        GL.VertexPointer(3, VertexPointerType.Double, 0, .dots(i).vertices)
                                        GL.DrawElements(PrimitiveType.TriangleFan, .dots(i).lines.Count, DrawElementsType.UnsignedInt, .dots(i).lines)
                                    Next
                                    GL.BindTexture(TextureTarget.Texture2D, 0)
                                    GL.LineWidth(3)

                                    For Each arrow In .arrows
                                        GL.Color3(Color.Pink)
                                        GL.VertexPointer(3, VertexPointerType.Double, 0, arrow.vertices)
                                        GL.DrawElements(PrimitiveType.Triangles, arrow.edges.Count, DrawElementsType.UnsignedInt, arrow.edges)
                                    Next
                                End If
                            End With
                        End If
                End Select
            End If
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



    Public origTexturen As New List(Of String)
    Public overWriteTextures As New List(Of LocalTexture)

    Private Sub drawL3D(objekt As Local3DObjekt)
        With objekt
            If .visible And Not .tempHidden Then
                For i = 0 To .subObjekte.Count - 1
                    'GL.Color3(Color.White)
                    If My.Settings.ShowAlpha Then
                        GL.Color4(1, 1, 1, .texturen(i).alpha)
                    Else
                        GL.Color3(Color.White)
                    End If

                    If Not origTexturen.Contains(.texturen(i).filename, StringComparer.OrdinalIgnoreCase) Then '-> Hier CaseInsensitiveComparer einfügen!
                        GL.BindTexture(TextureTarget.Texture2D, .texturen(i).id)
                    Else
                        'GL.BindTexture(TextureTarget.Texture2D, overWriteTextures(origTexturen.IndexOf(.texturen(i).filename)).id)
                        GL.BindTexture(TextureTarget.Texture2D, overWriteTextures(origTexturen.FindIndex(Function(s) s.Equals(.texturen(i).filename, StringComparison.CurrentCultureIgnoreCase))).id)
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
                            GL.Color3(My.Settings.SelectionColor)
                            GL.LineWidth(2)
                            GL.DrawElements(PrimitiveType.Lines, .lines.Count, DrawElementsType.UnsignedInt, .lines)
                            GL.LineWidth(1)
                        Else
                            If My.Settings.WireframeV Then
                                GL.Color3(My.Settings.LineColor3D)
                                GL.DrawElements(PrimitiveType.Lines, .lines.Count, DrawElementsType.UnsignedInt, .lines)
                            End If
                        End If
                    Next
                Else
                    If My.Settings.WireframeV Then
                        GL.Color3(My.Settings.LineColor3D)
                        GL.DrawElements(PrimitiveType.Lines, .lines.Count, DrawElementsType.UnsignedInt, .lines)
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
        If getProj() Is Projekt_Bus Or getProj() Is Projekt_Sco Or getProj() Is Projekt_Ovh Then
            Frm_TextTex.Show()
        Else
            If getProj() Is Projekt_Sli Then
                MsgBox("Splines könne keine Text-Texturen haben.")
            Else
                MsgNoProj()
            End If
        End If
    End Sub

    Private Sub HofDateienToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HofDateienToolStripMenuItem.Click
        If getProjTyp() = PROJ_TYPE_BUS Then
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
                        Mat_CBTextTex.Text = getProj.model.TextTexturen(.texTexVal).name
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
        If getProj.filename.path = "" Then Exit Sub
        If DDAlleTexturen.SelectedItem Is Nothing Then Exit Sub

        Dim selectedFile As String = DDAlleTexturen.SelectedItem.ToString
        Dim tmpList As New List(Of String)
        For Each file As String In IO.Directory.GetFiles(getProj.filename.path & "/Texture", "*.*", IO.SearchOption.TopDirectoryOnly)
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
        For Each folder In My.Computer.FileSystem.GetDirectories(My.Settings.OmsiPfad & "\Sceneryobjects")
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
        My.Computer.FileSystem.WriteAllText(My.Settings.OmsiPfad & "\alleBef.csv", Join(alleBef.ToArray, vbCrLf), False)
    End Sub

    Private Sub BBox_PSSize_Changed(sender As Object, e As EventArgs) Handles BBox_PSSize.Changed
        If getProj() Is Projekt_Bus Or getProj() Is Projekt_Sco Then
            If getProj.bbox Is Nothing Then
                getProj.bbox = New BoundingBox()
            End If
            getProj.bbox.size = BBox_PSSize.Point
        End If
    End Sub

    Private Sub BBoxBTBerechnen_Click(sender As Object, e As EventArgs) Handles BBoxBTBerechnen.Click
        If getProj() Is Projekt_Bus Or getProj() Is Projekt_Sco Then
            If getProj.bbox Is Nothing Then getProj.bbox = New BoundingBox
            With Projekt_Bus.bbox
                Dim min As New Point3D
                Dim max As New Point3D
                For Each objekt In AlleObjekte
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
        getSelectedMesh.animparent = Anim_TBAnimGrp.Text
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
        For i = 0 To getProj.model.lichter.count - 1
            If getProj.model.lichter(i).name = LBLichter.SelectedItem Then
                getProj.model.lichter.removeat(i)
                Exit For
            End If
        Next
        LBLichter.Items.Remove(LBLichter.SelectedItem)
    End Sub

    Private Sub Mesh_TBMeshident_Leave(sender As Object, e As EventArgs) Handles Mesh_TBMeshident.Leave
        If getSelectedMesh() Is Nothing Then Exit Sub
        If Mesh_TBMeshident.Text = "" Then
            getSelectedMesh.meshident = ""
        ElseIf Not Mesh_TBMeshident.Text.Contains(" ") Then
            getSelectedMesh.meshident = Mesh_TBMeshident.Text
        Else
            MsgBox("Der Meshident darf kein Leerzeichen enthalten!")
            Mesh_TBMeshident.Select()
            Mesh_TBMeshident.SelectAll()
        End If
    End Sub

    Private Sub TestToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TestToolStripMenuItem.Click
        checkForStdPos()
        'MsgBox(ToDouble("8180003F"))

        'MsgBox(AlleTexturen.Count)
    End Sub

    Dim selectedPathChanging As Boolean = True
    Private Sub LBPfade_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LBPfade.SelectedIndexChanged

        If Not getProj() Is Nothing Then
            selectedPathChanging = True
            TBName.Text = LBPfade.SelectedItem
            PSPos.Point = getProj.paths.pathPoints(LBPfade.SelectedIndex)

            Pfade_TBIndex.Text = LBPfade.SelectedIndex

            Pfade_CBAusstieg.Checked = False
            Pfade_CBEinstieg.Checked = False

            Pfade_CBVerkauf.Checked = False
            Pfade_CBTaster.Checked = False

            Pfade_CBVerkauf.Enabled = False
            Pfade_CBTaster.Enabled = False

            If Not getProj.cabin Is Nothing Then
                With getProj.cabin
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
            For i = getProj.paths.pathLinks.count - 1 To 0 Step -1

                If getProj.paths.pathLinks(i).X = LBPfade.SelectedIndex Then
                    counter += 1
                    GBPfade.Tag = GBPfade.Tag & getProj.paths.pathLinks(i).Y & ";"
                    If Not Pfade_DDNachste_0.Text = "" Then
                        With getProj()
                            addPathPntProperty(counter - 1, .paths.pathLinks(i).Y, .paths.roomheight(i), .paths.stemsounds(i), .paths.oneways.Contains(i))
                        End With

                    Else
                        Dim pntName As String = getProj.paths.pathPoints(getProj.paths.pathLinks(i).Y).Tag
                        If Not pntName Is Nothing Then
                            Pfade_DDNachste_0.Text = pntName
                        Else
                            Pfade_DDNachste_0.Text = "Punkt_" & getProj.paths.pathLinks(i).Y
                        End If
                        Pfade_TBStehh_0.Text = getProj.paths.roomheight(i)
                        Pfade_DDStepsound_0.Text = getProj.paths.stemsounds(i)
                        Pfade_PVerb0.Height = 60
                    End If
                End If

            Next

            Pfade_BTHinzu.Top = Pfade_PVerb0.Top + (Pfade_PVerb0.Height * counter)
            GBPfade.Height = Pfade_BTHinzu.Height + Pfade_PVerb0.Top + (Pfade_PVerb0.Height * counter)
            'Pfade_TBStehh.Text = getProj.paths.roomheight(LBPfade.SelectedIndex)
            'Pfade_DDStepsound.Text = getProj.paths.stemsounds(LBPfade.SelectedIndex)



            GlMain.Invalidate()
            selectedPathChanging = False
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
        If Not getProj.paths Is Nothing Then
            With getProj()

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
            With getProj.paths
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
        With getProj.paths
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
        If getProj() Is Projekt_Bus Then
            With getProj.cabin
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
        If getProj() Is Projekt_Bus Then
            With getProj.cabin
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
        If getProj() Is Projekt_Bus Then
            For i = 0 To getProj.cabin.doors.Count - 1
                If getProj.cabin.doors(i).pathindex = LBPfade.SelectedIndex Then
                    getProj.cabin.doors(i).noticketsale = Not Pfade_CBVerkauf.Checked
                    Exit Sub
                End If
            Next
        End If
    End Sub

    Private Sub Pfade_CBTaster_Click(sender As Object, e As EventArgs) Handles Pfade_CBTaster.Click
        If getProj() Is Projekt_Bus Then
            For i = 0 To getProj.cabin.doors.Count - 1
                If getProj.cabin.doors(i).pathindex = LBPfade.SelectedIndex Then
                    Projekt_Bus.cabin.doors(i).withButton = Pfade_CBTaster.Checked
                    Exit Sub
                End If
            Next
        End If
    End Sub


    Private Sub Pfade_CBNextWagen_Click(sender As Object, e As EventArgs) Handles Pfade_CBNextWagen.Click
        If getProj() Is Projekt_Bus Then
            If Pfade_CBNextWagen.Checked Then
                getProj.cabin.linkToNextVeh = LBPfade.SelectedIndex
                Pfade_CBVorWagen.Checked = False
                getProj.cabin.linkToPrevVeh = -1
            Else
                getProj.cabin.linkToNextVeh = -1
            End If
        End If
    End Sub

    Private Sub Pfade_CBVorWagen_Click(sender As Object, e As EventArgs) Handles Pfade_CBVorWagen.Click
        If getProj() Is Projekt_Bus Then
            If Pfade_CBVorWagen.Checked Then
                getProj.cabin.linkToPrevVeh = LBPfade.SelectedIndex
                Pfade_CBNextWagen.Checked = False
                getProj.cabin.linkToNextVeh = -1
            Else
                getProj.cabin.linkToPrevVeh = -1
            End If
        End If
    End Sub



    '#########################
    '   Lichter
    '#########################

    Private Sub DuplizierenToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles DuplizierenToolStripMenuItem1.Click
        If Not getProj.model Is Nothing Then
            Dim newLicht As New OMSI_Licht(getSelectedLight)
            newLicht.name = "Licht_" & getProj.model.lichter.Count
            getProj.model.lichter.add(newLicht)
            LBLichter.Items.Add(newLicht.name)
        End If
    End Sub

    Private Sub Licht_TBGroesse_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs) Handles Licht_TBGroesse.KeyPress
        e.Handled = helper.NumbersOnly(e, sender, True)
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
            If Not getProjTyp() = PROJ_TYPE_SLI Then
                If Not getProj.model.meshes Is Nothing Then
                    For Each objektIDs In getProj.model.meshes(e.Index).ObjIds
                        If e.NewValue Then
                            AlleObjekte(objektIDs).tempHidden = False
                        Else
                            AlleObjekte(objektIDs).tempHidden = True
                        End If
                    Next
                End If
            End If
        End If
    End Sub

    Private Sub PSPos_KeyPress(sender As Object, e As EventArgs) Handles PSPos.KeyPress

    End Sub

    Private Sub TReloadTextures_Tick(sender As Object, e As EventArgs) Handles TReloadTextures.Tick
        For Each localObject In AlleObjekte
            For Each texture In localObject.texturen
                TexturecheckLastChange(texture)
            Next
        Next
        For Each texture In overWriteTextures
            TexturecheckLastChange(texture)
        Next
        GlMain.Invalidate()
    End Sub
End Class

