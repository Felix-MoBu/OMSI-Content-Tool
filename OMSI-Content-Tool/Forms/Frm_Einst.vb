'by Felix Modellbusse ;) (MoBu) 2019
Option Strict On

Public Class Frm_Einst
    Public ReadOnly stdMail As String = "tjtb@go.ru"
    Public ReadOnly stdPasswd As String = "gerw46#"

    Private Sub OBUebernehmen_Click(sender As Object, e As EventArgs) Handles OBUebernehmen.Click
        With My.Settings
            'Page "Allgemein"
            .SaveIntervalActive = CBTimerActive.Checked
            .SaveIntervalAuto = CBTimerAuto.Checked
            .SaveInterval = Convert.ToUInt16(TBSaveTimerInterval.Text)
            .BackupAnlegen = CBBackup.Checked
            .LogDebug = CBLogDebug.Checked
            .AutoConvertO3D = CBautoO3d.Checked
            .CreatorID = Convert.ToInt32(TBCreatorID.Text)
            .NickName = TBNickname.Text
            Frm_Main.TimerReset()

            'Page "OMSI"
            .OmsiPfad = TBOmsiPfad.Text
            .RepToolPfad = TBRepTool.Text

            'Page "Darstellung"
            .BackColor3D = TBColor3D.BackColor
            Dim x As Integer = TBColor3D.BackColor.R
            x += TBColor3D.BackColor.G
            x += TBColor3D.BackColor.B
            If x > 380 Then
                .LineColor3D = Color.Black
            Else
                .LineColor3D = Color.White
            End If

            .TexAutoReload = CBTexAutoReload.Checked
            If CBTexAutoReload.Checked Then
                Frm_Main.TReloadTextures.Start()
            Else
                Frm_Main.TReloadTextures.Stop()
            End If
            .ShowAllParts = CBShowAllParts.Checked

            .CamDriverColor = TBColorDriverCam.BackColor
            .CamPaxColor = TBColorPaxCam.BackColor
            .CamReflexColor = TBColorReflexCam.BackColor
            .PaxColor = TBColorPassengers.BackColor
            .DriverColor = TBColorDriver.BackColor
            .AchsenColor = TBColorAchsen.BackColor
            .SelectionColor = TBColorSelectedObj.BackColor

            .fpsLimit = Convert.ToInt32(TBMaxFPS.Text)

            '3D-Formate
            .o3dRemoveSpec = CBO3dRemSpec.Checked

            .XScale = TBXScale.Text
            .XUpAxis = Convert.ToByte(DDXUp.SelectedIndex)

            .X3dScale = TBX3dScale.Text
            .X3dUpAxis = Convert.ToByte(DDX3dUp.SelectedIndex)


            .Save()
            .Reload()
        End With

        Frm_Main.GlMain.Invalidate()
        Me.Close()
    End Sub

    Private Sub Frm_Einst_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Location = New Point(Convert.ToInt16(Frm_Main.Width / 2 - Me.Width / 2), Convert.ToInt16(Frm_Main.Height / 2 - Me.Height / 2))
        With My.Settings
            'Page "Allgemein"
            CBTimerActive.Checked = .SaveIntervalActive
            CBTimerAuto.Checked = .SaveIntervalAuto
            TBSaveTimerInterval.Text = Convert.ToString(.SaveInterval)
            CBBackup.Checked = .BackupAnlegen
            CBLogDebug.Checked = .LogDebug
            CBautoO3d.Checked = .AutoConvertO3D
            TBCreatorID.Text = Convert.ToString(.CreatorID)
            TBNickname.Text = .NickName

            'Page "OMSI"
            TBOmsiPfad.Text = .OmsiPfad
            TBRepTool.Text = .RepToolPfad

            'Page "Darstellung"
            TBColor3D.BackColor = .BackColor3D
            CBTexAutoReload.Checked = .TexAutoReload
            CBShowAllParts.Checked = .ShowAllParts
            TBColorDriverCam.BackColor = .CamDriverColor
            TBColorPaxCam.BackColor = .CamPaxColor
            TBColorReflexCam.BackColor = .CamReflexColor
            TBColorDriver.BackColor = .DriverColor
            TBColorPassengers.BackColor = .PaxColor
            TBColorAchsen.BackColor = .AchsenColor
            TBColorSelectedObj.BackColor = .SelectionColor
            TBMaxFPS.Text = Convert.ToString(.fpsLimit)

            'Page 3D-Formate
            CBO3dRemSpec.Checked = .o3dRemoveSpec

            TBXScale.Text = .XScale
            DDXUp.SelectedIndex = .XUpAxis

            TBX3dScale.Text = .X3dScale
            DDX3dUp.SelectedIndex = .X3dUpAxis


            'Page Online
            TBMail.Text = .eMail
            If .eMail <> "" Then
                BTAbmelden.Enabled = True
            Else
                BTAnmelden.Enabled = True
            End If
        End With
    End Sub

    Private Sub BTPfadSuchen_Click(sender As Object, e As EventArgs) Handles BTPfadSuchen.Click
        Dim fd As New FolderBrowserDialog
        fd.SelectedPath = TBOmsiPfad.Text
        If fd.ShowDialog() = DialogResult.OK Then
            TBOmsiPfad.Text = fd.SelectedPath
        End If
    End Sub

    Private Sub BTRepToolSuchen_Click(sender As Object, e As EventArgs) Handles BTRepToolSuchen.Click
        Dim fd As New OpenFileDialog
        If TBRepTool.Text <> "" Then
            fd.InitialDirectory = New Filename(TBRepTool.Text).path
        Else
            fd.InitialDirectory = TBOmsiPfad.Text
        End If

        fd.Multiselect = False
        If fd.ShowDialog() = DialogResult.OK Then
            TBRepTool.Text = fd.FileName
        End If
    End Sub

    Private Sub BTAbbrechen_Click(sender As Object, e As EventArgs) Handles BTAbbrechen.Click
        Me.Close()
    End Sub

    Private Sub TBColorDriverCam_Click(sender As Object, e As EventArgs) Handles TBColorDriverCam.Click
        colorSelect(TBColorDriverCam)
    End Sub

    Private Sub TBColorDriverCam_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TBColorDriverCam.KeyPress
        e.Handled = True
    End Sub

    Private Sub TBColorPaxCam_Click(sender As Object, e As EventArgs) Handles TBColorPaxCam.Click
        colorSelect(TBColorPaxCam)
    End Sub

    Private Sub TBColorPaxCam_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TBColorPaxCam.KeyPress
        e.Handled = True
    End Sub

    Private Sub TBColorReflexCam_Click(sender As Object, e As EventArgs) Handles TBColorReflexCam.Click
        colorSelect(TBColorReflexCam)
    End Sub

    Private Sub TBColorReflexCam_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TBColorReflexCam.KeyPress
        e.Handled = True
    End Sub

    Private Sub TBColor3D_Click(sender As Object, e As EventArgs) Handles TBColor3D.Click
        colorSelect(TBColor3D)
    End Sub

    Private Sub TBColor3D_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TBColor3D.KeyPress
        e.Handled = True
    End Sub

    Private Sub TBColorPassengers_Click(sender As Object, e As EventArgs) Handles TBColorPassengers.Click
        colorSelect(TBColorPassengers)
    End Sub

    Private Sub TBColorPassengers_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TBColorPassengers.KeyPress
        e.Handled = True
    End Sub

    Private Sub TBColorDriver_Click(sender As Object, e As EventArgs) Handles TBColorDriver.Click
        colorSelect(TBColorDriver)
    End Sub

    Private Sub TBColorDriver_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TBColorDriver.KeyPress
        e.Handled = True
    End Sub

    Private Sub TBColorSelectedObj_Click(sender As Object, e As EventArgs) Handles TBColorSelectedObj.Click
        colorSelect(TBColorSelectedObj)
    End Sub

    Private Sub TBColorSelectedObj_Keypress(sender As Object, e As KeyPressEventArgs) Handles TBColorSelectedObj.KeyPress
        e.Handled = True
    End Sub

    Private Sub colorSelect(ByRef sender As TextBox)
        Dim cd As New ColorDialog
        cd.Color = sender.BackColor
        If cd.ShowDialog = DialogResult.OK Then
            sender.BackColor = cd.Color
        End If
    End Sub


    Private Function checkLogin(mail As String, password As String) As Boolean
        If mail = stdMail Then
            If password = stdPasswd Then
                Return True
            End If
        End If
        Return False
    End Function

    Private Sub BTAnmelden_Click(sender As Object, e As EventArgs) Handles BTAnmelden.Click
        If checkLogin(TBMail.Text, TBPassword.Text) Then
            My.Settings.eMail = TBMail.Text
            Log.Add("Im Online-Bereich angemeldet.")
            MsgBox("Anmeldung erfolgreich! Anwendung bitte neu starten.")
            BTAnmelden.Enabled = False
            BTAbmelden.Enabled = True
        Else
            TBPassword.Text = ""
            Log.Add("Online-Bereich: Login fehlgeschlagen!")
            MsgBox("Anmeldung fehlgeschlagen!")
        End If
    End Sub

    Private Sub BTAbmelden_Click(sender As Object, e As EventArgs) Handles BTAbmelden.Click
        My.Settings.eMail = ""
        Log.Add("Im Online-Bereich abgemeldet.")
        BTAnmelden.Enabled = True
        BTAbmelden.Enabled = False
    End Sub

    Private Sub TBSaveTimerInterval_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TBSaveTimerInterval.KeyPress
        e.Handled = NumbersOnly(e)
    End Sub

    Private Function NumbersOnly(e As KeyPressEventArgs) As Boolean
        If (Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) Or Asc(e.KeyChar) = 8 Then
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub BTResetObj_Click(sender As Object, e As EventArgs) Handles BTResetObj.Click
        With My.Settings
            .PObjekteV = True
            .PObjekteH = 350
            .PObjekteW = 300
            .PObjekteX = 10
            .PObjekteY = 10
        End With
        Frm_Main.loadPositions()
    End Sub

    Private Sub BTResetTex_Click(sender As Object, e As EventArgs) Handles BTResetTex.Click
        With My.Settings
            .PTextureV = True
            .PTextureH = 337
            .PTextureW = 392
            .PTextureX = 10
            .PTextureY = 10
        End With
        Frm_Main.loadPositions()
    End Sub

    Private Sub BTResetEig_Click(sender As Object, e As EventArgs) Handles BTResetEig.Click
        With My.Settings
            .PEigenschaftenV = True
            .PEigenschaftenH = 600
            .PEigenschaftenX = 10
            .PEigenschaftenY = 10
        End With
        Frm_Main.loadPositions()
    End Sub

    Private Sub TBColorAchsen_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TBColorAchsen.KeyPress
        e.Handled = True
    End Sub

    Private Sub TBColorAchsen_Click(sender As Object, e As EventArgs) Handles TBColorAchsen.Click
        CDColorAchsen.Color = TBColorAchsen.BackColor
        If CDColorAchsen.ShowDialog = DialogResult.OK Then
            TBColorAchsen.BackColor = CDColorAchsen.Color
        End If
    End Sub

    Private Sub BTEinstExp_Click(sender As Object, e As EventArgs) Handles BTEinstExp.Click
        Dim fd As New SaveFileDialog
        With fd
            .Filter = "Textdatei (*.txt)|*.txt"
            .FileName = "MyOCT-Settings.txt"
        End With

        If fd.ShowDialog = DialogResult.OK Then
            Dim fw As New FileWriter(New Filename(fd.FileName))
            With My.Settings
                For Each item As Configuration.SettingsProperty In My.Settings.Properties
                    If Not .PropertyValues(item.Name).PropertyValue.ToString = "" Then
                        fw.Add(item.Name & "=" & .PropertyValues(item.Name).PropertyValue.ToString)
                    End If
                Next
            End With
            fw.Write()
        End If
    End Sub

    Private Sub BTEinstImport_Click(sender As Object, e As EventArgs) Handles BTEinstImport.Click
        'Dim fd As New OpenFileDialog
        'With fd
        '    .Filter = "Textdatei (*.txt)|*.txt"
        'End With

        'If fd.ShowDialog = DialogResult.OK And fd.FileName <> "" Then
        '    Dim allLines As String() = Split(My.Computer.FileSystem.ReadAllText(fd.FileName), vbCrLf)
        '    For linect As Integer = 1 To allLines.Count - 1
        '        If InStr(allLines(linect), "=") > 0 Then
        '            My.Settings(Split(allLines(linect), "=")(0)) = allLines(linect).Substring(InStr(allLines(linect), "="))
        '            'MsgBox(allLines(linect).Substring(InStr(allLines(linect), "=")))
        '        End If
        '    Next
        'End If
        MsgBox("Import derzeit nicht möglich!")
    End Sub

    Private Sub BTEinstReset_Click(sender As Object, e As EventArgs) Handles BTEinstReset.Click
        My.Settings.Reset()
    End Sub

    Private Sub TBContentID_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TBCreatorID.KeyPress
        If TBCreatorID.Text.Length >= 8 Then
            e.Handled = True
        End If
    End Sub

    Private Sub TBMaxFPS_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TBMaxFPS.KeyPress
        e.Handled = Helper.NumbersOnly(e, TBMaxFPS, , 0, 1000)
    End Sub
End Class