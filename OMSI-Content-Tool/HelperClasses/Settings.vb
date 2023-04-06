Imports System.Configuration
Imports System.Text

Module Settings
    Public ReadOnly settingsFilename As String = "\Settings.cfg"

    Public ImportPfad As String = "C:\"
    Public ExportPfad As String = "C:\"
    Public LastExportFormat As Byte = 0
    Public LastImportFormat As Byte = 0
    Public LetzteProjekte As List(Of String) = New List(Of String)

    Public OpenPath As String = "C:\"
    Public OmsiPfad As String = "C:\Programme\Steam\steamapps\common\OMSI 2"
    Public RepToolPfad As String = "C:\Programme\Steam\steamapps\common\OMSI 2\SDK\RepaintTool.exe"
    Public BackupAnlegen As Boolean = False

    Public WireframeV As Boolean = True
    Public GitterV As Boolean = True
    Public OrtoScale As Integer = 3

    Public PObjekteV As Boolean = True
    Public PObjekteL As Point = New Point(10, 10)
    Public PObjekteS As Point = New Point(271, 328)

    Public PTextureV As Boolean = True
    Public PTextureL As Point = New Point(10, 338)
    Public PTextureS As Point = New Point(392, 337)

    Public PEigenschaftenV As Boolean = True
    Public PEigenschaftenL As Point = New Point(410, 10)
    Public PEigenschaftenS As Point = New Point(360, 630)

    Public PTimelineV As Boolean = True
    Public PTimelineL As Point = New Point(500, 500)
    Public PTimelineS As Point = New Point(814, 124)
    Public PTimelineSelTab As Integer = 0

    Public AchsenColor As Color = Color.Red
    Public BackColor3D As Color = Color.White
    Public CamDriverColor As Color = Color.Black
    Public CamPaxColor As Color = Color.Green
    Public CamReflexColor As Color = Color.Blue
    Public DriverColor As Color = Color.Blue
    Public EditorColor As Color = Frm_Main.PanelObjekte.BackColor
    Public LineColor3D As Color = Color.Black
    Public PaxColor As Color = Color.Pink
    Public SelectionColor As Color = Color.Orange



    Public fpsLimit As Integer = 120
    Public SaveInterval As Integer = 20
    Public SaveIntervalActive As Boolean = True
    Public SaveIntervalAuto As Boolean = False
    Public TexAutoReload As Boolean = False
    Public ShowAllParts As Boolean = False
    Public LogDebug As Boolean = False
    Public ShowAlpha As Boolean = True
    Public PfadeOrigBreite As Boolean = True

    Public o3dRemoveSpec As Boolean = False
    Public o3dAutoConvert As Boolean = False

    Public XUpAxis As Byte = 2
    Public XScale As Single = 1

    Public X3dUpAxis As Byte = 2
    Public X3dScale As Single = 1

    Public CreatorID As Integer = 0
    Public NickName As String = ""
    Public EMail As String = ""


    Public Sub Load(Optional filename As String = "Settings.cfg")

        If Not IO.File.Exists(filename) Then
            Save()
            Exit Sub
        Else

            Dim newfilename As Filename = New Filename(settingsFilename, Application.StartupPath)

            Dim allLines As String() = System.IO.File.ReadAllLines(filename, Encoding.GetEncoding(1252))

            For linect = 0 To allLines.Count - 1
                If Trim(allLines(linect)) <> "" Then
                    Select Case allLines(linect)
                        Case "[ImportPfad]"
                            ImportPfad = allLines(linect + 1)
                        Case "[ExportPfad]"
                            ExportPfad = allLines(linect + 1)
                        Case "[LastExportFormat]"
                            LastExportFormat = allLines(linect + 1)
                        Case "[LastImportFormat]"
                            LastImportFormat = allLines(linect + 1)
                        Case "[LetzteProjekte]"
                            LetzteProjekte.Clear()
                            For i = linect + 2 To linect + 2 + allLines(linect + 1)
                                LetzteProjekte.Add(allLines(i))
                            Next

                        Case "[OpenPath]"
                            OpenPath = allLines(linect + 1)
                        Case "[OmsiPfad]"
                            OmsiPfad = allLines(linect + 1)
                        Case "[RepToolPfad]"
                            RepToolPfad = allLines(linect + 1)
                        Case "[BackupAnlegen]"
                            BackupAnlegen = intToBool(allLines(linect + 1))

                        Case "[WireframeV]"
                            WireframeV = intToBool(allLines(linect + 1))
                        Case "[GitterV]"
                            GitterV = intToBool(allLines(linect + 1))
                        Case "[OrtoScale]"
                            OrtoScale = allLines(linect + 1)

                        Case "[PObjekte]"
                            PObjekteV = intToBool(allLines(linect + 1))
                            PObjekteL = New Point(allLines(linect + 2), allLines(linect + 3))
                            PObjekteS = New Point(allLines(linect + 4), allLines(linect + 5))

                        Case "[PTexture]"
                            PTextureV = intToBool(allLines(linect + 1))
                            PTextureL = New Point(allLines(linect + 2), allLines(linect + 3))
                            PTextureS = New Point(allLines(linect + 4), allLines(linect + 5))

                        Case "[PEigenschaften]"
                            PEigenschaftenV = intToBool(allLines(linect + 1))
                            PEigenschaftenL = New Point(allLines(linect + 2), allLines(linect + 3))
                            PEigenschaftenS = New Point(allLines(linect + 4), allLines(linect + 5))

                        Case "[PTimeline]"
                            PTimelineV = intToBool(allLines(linect + 1))
                            PTimelineL = New Point(allLines(linect + 2), allLines(linect + 3))
                            PTimelineS = New Point(allLines(linect + 4), allLines(linect + 5))
                            PTimelineSelTab = allLines(linect + 6)

                        Case "[AchsenColor]"
                            AchsenColor = Color.FromArgb(allLines(linect + 1), allLines(linect + 2), allLines(linect + 3))
                        Case "[BackColor3D]"
                            BackColor3D = Color.FromArgb(allLines(linect + 1), allLines(linect + 2), allLines(linect + 3))
                        Case "[CamDriverColor]"
                            CamDriverColor = Color.FromArgb(allLines(linect + 1), allLines(linect + 2), allLines(linect + 3))
                        Case "[CamPaxColor]"
                            CamPaxColor = Color.FromArgb(allLines(linect + 1), allLines(linect + 2), allLines(linect + 3))
                        Case "[CamReflexColor]"
                            CamReflexColor = Color.FromArgb(allLines(linect + 1), allLines(linect + 2), allLines(linect + 3))
                        Case "[DriverColor]"
                            DriverColor = Color.FromArgb(allLines(linect + 1), allLines(linect + 2), allLines(linect + 3))
                        Case "[EditorColor]"
                            EditorColor = Color.FromArgb(allLines(linect + 1), allLines(linect + 2), allLines(linect + 3))
                        Case "[LineColor3D]"
                            LineColor3D = Color.FromArgb(allLines(linect + 1), allLines(linect + 2), allLines(linect + 3))
                        Case "[PaxColor]"
                            PaxColor = Color.FromArgb(allLines(linect + 1), allLines(linect + 2), allLines(linect + 3))
                        Case "[SelectionColor]"
                            SelectionColor = Color.FromArgb(allLines(linect + 1), allLines(linect + 2), allLines(linect + 3))

                        Case "[fpsLimit]"
                            fpsLimit = allLines(linect + 1)
                        Case "[SaveInterval]"
                            SaveInterval = allLines(linect + 1)
                        Case "[SaveIntervalActive]"
                            SaveIntervalActive = intToBool(allLines(linect + 1))
                        Case "[SaveIntervalAuto]"
                            SaveIntervalAuto = intToBool(allLines(linect + 1))
                        Case "[TexAutoReload]"
                            TexAutoReload = intToBool(allLines(linect + 1))
                        Case "[ShowAllParts]"
                            ShowAllParts = intToBool(allLines(linect + 1))
                        Case "[LogDebug]"
                            LogDebug = intToBool(allLines(linect + 1))
                        Case "[ShowAlpha]"
                            ShowAlpha = intToBool(allLines(linect + 1))
                        Case "[PfadeOrigBreite]"
                            PfadeOrigBreite = intToBool(allLines(linect + 1))

                        Case "[o3dRemoveSpec]"
                            o3dRemoveSpec = intToBool(allLines(linect + 1))
                        Case "[o3dAutoConvert]"
                            o3dAutoConvert = intToBool(allLines(linect + 1))

                        Case "[XHandling]"
                            XUpAxis = allLines(linect + 1)
                            XScale = allLines(linect + 2)

                        Case "[X3dHandling]"
                            X3dUpAxis = allLines(linect + 1)
                            X3dScale = allLines(linect + 2)

                        Case "[UserData]"
                            CreatorID = allLines(linect + 1)
                            NickName = allLines(linect + 2)
                            EMail = allLines(linect + 3)
                    End Select
                End If

            Next
            Log.Add("Einstellungen aus Datei geladen...")
        End If
    End Sub

    Public Sub Save()
        Dim newFile As New FileWriter(New Filename(settingsFilename, Application.StartupPath))
        With newFile
            .AddTag("ImportPfad", ImportPfad, True)
            .AddTag("ExportPfad", ExportPfad, True)
            .AddTag("LastExportFormat", LastExportFormat, True)
            .AddTag("LastImportFormat", LastImportFormat, True)
            .AddTag("LetzteProjekte", LetzteProjekte.Count)
            .AddRange(LetzteProjekte, True)

            .AddTag("OpenPath", OpenPath, True)
            .AddTag("OmsiPfad", OmsiPfad, True)
            .AddTag("RepToolPfad", RepToolPfad, True)
            .AddTag("BackupAnlegen", boolToInt(BackupAnlegen), True)

            .AddTag("WireframeV", boolToInt(WireframeV), True)
            .AddTag("GitterV", boolToInt(GitterV), True)
            .AddTag("OrtoScale", OrtoScale, True)

            .AddTag("PObjekte", boolToInt(PObjekteV))
            .Add(PObjekteL.X)
            .Add(PObjekteL.Y)
            .Add(PObjekteS.X)
            .Add(PObjekteS.Y, True)

            .AddTag("PTexture", boolToInt(PTextureV))
            .Add(PTextureL.X)
            .Add(PTextureL.Y)
            .Add(PTextureS.X)
            .Add(PTextureS.Y, True)

            .AddTag("PEigenschaften", boolToInt(PEigenschaftenV))
            .Add(PEigenschaftenL.X)
            .Add(PEigenschaftenL.Y)
            .Add(PEigenschaftenS.X)
            .Add(PEigenschaftenS.Y, True)

            .AddTag("PTimeline", boolToInt(PTimelineV))
            .Add(PTimelineL.X)
            .Add(PTimelineL.Y)
            .Add(PTimelineS.X)
            .Add(PTimelineS.Y)
            .Add(PTimelineSelTab, True)

            .AddTag("AchsenColor", AchsenColor, True)
            .AddTag("BackColor3D", BackColor3D, True)
            .AddTag("CamDriverColor", CamDriverColor, True)
            .AddTag("CamPaxColor", CamPaxColor, True)
            .AddTag("CamReflexColor", CamReflexColor, True)
            .AddTag("DriverColor", DriverColor, True)
            .AddTag("EditorColor", EditorColor, True)
            .AddTag("LineColor3D", LineColor3D, True)
            .AddTag("PaxColor", PaxColor, True)
            .AddTag("SelectionColor", SelectionColor, True)

            .AddTag("fpsLimit", fpsLimit, True)
            .AddTag("SaveInterval", SaveInterval, True)
            .AddTag("SaveIntervalActive", boolToInt(SaveIntervalActive), True)
            .AddTag("SaveIntervalAuto", boolToInt(SaveIntervalAuto), True)
            .AddTag("TexAutoReload", boolToInt(TexAutoReload), True)
            .AddTag("ShowAllParts", boolToInt(ShowAllParts), True)
            .AddTag("LogDebug", boolToInt(LogDebug), True)
            .AddTag("ShowAlpha", boolToInt(ShowAlpha), True)
            .AddTag("PfadeOrigBreite", boolToInt(PfadeOrigBreite), True)


            .AddTag("o3dRemoveSpec", boolToInt(o3dRemoveSpec), True)
            .AddTag("o3dAutoConvert", boolToInt(o3dAutoConvert), True)

            .Add("[XHandling]")
            .Add(XUpAxis)
            .Add(XScale, True)

            .Add("[X3dHandling]")
            .Add(X3dUpAxis)
            .Add(X3dScale, True)

            .Add("[UserData]")
            .Add(CreatorID)
            .Add(NickName)
            .Add(EMail, True)

            Dim linesCount As Integer
            linesCount = newFile.Write()

        End With
    End Sub

    Public Sub Reset()

    End Sub

End Module
