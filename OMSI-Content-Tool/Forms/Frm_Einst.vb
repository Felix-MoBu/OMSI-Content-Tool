'by Felix Modellbusse ;) (MoBu) 2019
Option Strict On

Public Class Frm_Einst
    Public ReadOnly stdMail As String = "tjtb@go.ru"
    Public ReadOnly stdPasswd As String = "gerw46#"

    Private Sub OBUebernehmen_Click(sender As Object, e As EventArgs) Handles OBUebernehmen.Click
        'Page "Allgemein"
        Settings.SaveIntervalActive = CBTimerActive.Checked
        Settings.SaveIntervalAuto = CBTimerAuto.Checked
        Settings.SaveInterval = Convert.ToUInt16(TBSaveTimerInterval.Text)
        Settings.BackupAnlegen = CBBackup.Checked
        Settings.LogDebug = CBLogDebug.Checked
        Settings.o3dAutoConvert = CBautoO3d.Checked
        Settings.CreatorID = Convert.ToInt32(TBCreatorID.Text)
        Settings.NickName = TBNickname.Text
        Frm_Main.TimerReset()

        'Page "OMSI"
        Settings.OmsiPfad = TBOmsiPfad.Text
        Settings.RepToolPfad = TBRepTool.Text

        'Page "Darstellung"
        Settings.BackColor3D = TBColor3D.BackColor
        Dim x As Integer = TBColor3D.BackColor.R
        x += TBColor3D.BackColor.G
        x += TBColor3D.BackColor.B
        If x > 380 Then
            Settings.LineColor3D = Color.Black
        Else
            Settings.LineColor3D = Color.White
        End If

        Settings.TexAutoReload = CBTexAutoReload.Checked
        If CBTexAutoReload.Checked Then
            Frm_Main.TReloadTextures.Start()
        Else
            Frm_Main.TReloadTextures.Stop()
        End If
        Settings.ShowAllParts = CBShowAllParts.Checked

        Settings.CamDriverColor = TBColorDriverCam.BackColor
        Settings.CamPaxColor = TBColorPaxCam.BackColor
        Settings.CamReflexColor = TBColorReflexCam.BackColor
        Settings.PaxColor = TBColorPassengers.BackColor
        Settings.DriverColor = TBColorDriver.BackColor
        Settings.AchsenColor = TBColorAchsen.BackColor
        Settings.SelectionColor = TBColorSelectedObj.BackColor
        Settings.EditorColor = TBColorFenster.BackColor

        Settings.fpsLimit = Convert.ToInt32(TBMaxFPS.Text)

        '3D-Formate
        Settings.o3dRemoveSpec = CBO3dRemSpec.Checked

        Settings.XScale = Convert.ToSingle(TBXScale.Text)
        Settings.XUpAxis = Convert.ToByte(DDXUp.SelectedIndex)

        Settings.X3dScale = Convert.ToSingle(TBX3dScale.Text)
        Settings.X3dUpAxis = Convert.ToByte(DDX3dUp.SelectedIndex)


        Settings.Save()

        Frm_Main.GlMain.Invalidate()
        Me.Close()
    End Sub

    Private Sub Frm_Einst_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Settings.Load()
        Me.Location = New Point(Convert.ToInt16(Frm_Main.Width / 2 - Me.Width / 2), Convert.ToInt16(Frm_Main.Height / 2 - Me.Height / 2))
        'Page "Allgemein"
        CBTimerActive.Checked = Settings.SaveIntervalActive
        CBTimerAuto.Checked = Settings.SaveIntervalAuto
        TBSaveTimerInterval.Text = Convert.ToString(Settings.SaveInterval)
        CBBackup.Checked = Settings.BackupAnlegen
        CBLogDebug.Checked = Settings.LogDebug
        CBautoO3d.Checked = Settings.o3dAutoConvert
        TBCreatorID.Text = Convert.ToString(Settings.CreatorID)
        TBNickname.Text = Settings.NickName

        'Page "OMSI"
        TBOmsiPfad.Text = Settings.OmsiPfad
        TBRepTool.Text = Settings.RepToolPfad

        'Page "Darstellung"
        TBColor3D.BackColor = Settings.BackColor3D
        CBTexAutoReload.Checked = Settings.TexAutoReload
        CBShowAllParts.Checked = Settings.ShowAllParts
        TBColorDriverCam.BackColor = Settings.CamDriverColor
        TBColorPaxCam.BackColor = Settings.CamPaxColor
        TBColorReflexCam.BackColor = Settings.CamReflexColor
        TBColorDriver.BackColor = Settings.DriverColor
        TBColorPassengers.BackColor = Settings.PaxColor
        TBColorAchsen.BackColor = Settings.AchsenColor
        TBColorSelectedObj.BackColor = Settings.SelectionColor
        TBColorFenster.BackColor = Settings.EditorColor
        TBMaxFPS.Text = Convert.ToString(Settings.fpsLimit)

        'Page 3D-Formate
        CBO3dRemSpec.Checked = Settings.o3dRemoveSpec

        TBXScale.Text = Settings.XScale.ToString
        DDXUp.SelectedIndex = Settings.XUpAxis

        TBX3dScale.Text = Settings.X3dScale.ToString
        DDX3dUp.SelectedIndex = Settings.X3dUpAxis


        'Page Online
        TBMail.Text = Settings.EMail
        If Settings.EMail <> "" Then
            BTAbmelden.Enabled = True
        Else
            BTAnmelden.Enabled = True
        End If

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
            Settings.eMail = TBMail.Text
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
        Settings.eMail = ""
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
        Settings.PObjekteV = True
        Settings.PObjekteL = New Point(10, 10)
        Settings.PObjekteS = New Point(300, 350)
        Frm_Main.loadPositions()
    End Sub

    Private Sub BTResetTex_Click(sender As Object, e As EventArgs) Handles BTResetTex.Click
        Settings.PTextureV = True
        Settings.PTextureL = New Point(10, 10)
        Settings.PTextureS = New Point(392, 337)
        Frm_Main.loadPositions()
    End Sub

    Private Sub BTResetEig_Click(sender As Object, e As EventArgs) Handles BTResetEig.Click
        Settings.PEigenschaftenV = True
        Settings.PEigenschaftenL = New Point(10, 10)
        Settings.PEigenschaftenS = New Point(360, 630)
        Frm_Main.loadPositions()
    End Sub

    Private Sub BTResetTimeline_Click(sender As Object, e As EventArgs) Handles BTResetTimeline.Click
        Settings.PTimelineV = True
        Settings.PTimelineL = New Point(10, 10)
        Settings.PTimelineS = New Point(814, 124)
        Settings.PTimelineSelTab = 0
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

    Private Sub BTEinstReset_Click(sender As Object, e As EventArgs) Handles BTEinstReset.Click
        Settings.Reset()
    End Sub

    Private Sub TBContentID_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TBCreatorID.KeyPress
        If TBCreatorID.Text.Length >= 8 Then
            e.Handled = True
        End If
    End Sub

    Private Sub TBMaxFPS_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TBMaxFPS.KeyPress
        e.Handled = Helper.NumbersOnly(e, TBMaxFPS, , 0, 1000)
    End Sub

    Private Sub TBEditorFarbe_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TBColorFenster.KeyPress
        e.Handled = True
    End Sub

    Private Sub TBEditorFarbe_Click(sender As Object, e As EventArgs) Handles TBColorFenster.Click
        CDColorFenster.Color = TBColorFenster.BackColor
        If CDColorFenster.ShowDialog = DialogResult.OK Then
            TBColorFenster.BackColor = CDColorFenster.Color
            Frm_Main.loadPositions()
        End If
    End Sub
End Class