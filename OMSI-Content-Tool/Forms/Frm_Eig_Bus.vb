'by Felix Modellbusse ;) (MoBu) 2019
Imports System.ComponentModel
Imports System.Text

Public Class Frm_Eig_Bus

    Public Projekt_Bus As Proj_Bus

    Private Sub Frm_Eig_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Location = New Point(Frm_Main.Width / 2 - Me.Width / 2, Frm_Main.Height / 2 - Me.Height / 2)
        DDLaufleistung.SelectedIndex = 0

        DDSprache.Items.Clear()
        DDSprache.Items.Add("Andere")
        DDSprache.SelectedIndex = 0

        Dim languagePfad As String = Settings.OmsiPfad & "\Languages"
        If IO.Directory.Exists(languagePfad) Then
            Dim files() As String = IO.Directory.GetFiles(languagePfad)
            For Each file As String In files
                Dim s1 As String() = Split(file, "\")
                Dim s2 As String = Split(s1(s1.Count - 1), "_")(0)
                If Not DDSprache.Items.Contains(s2) Then
                    DDSprache.Items.Add(s2)
                End If
            Next
        Else
            Log.Add("Der Ordner 'Languages' im OMSI-Verzeichnis wurde nicht gefunden. Einige Optionen sind dadurch nicht vollstädnig!", , True)
        End If

        With Projekt_Bus

            TBName.Text = .filename.name
            TBPath.Text = .filename.path

            TBHersteller.Text = .hersteller
            TBTyp.Text = .typ
            TBAnstrich.Text = .anstrich
            TBBeschreibung.Text = Join(.beschreibung.ToArray, vbCrLf)

            TBBaujahr.Text = .baujahr
            TBLaufleistung.Text = .laufleistung

            TBMasse.Text = .masse
            TBTrägheitX.Text = .trägheit.X
            TBTrägheitY.Text = .trägheit.Y
            TBTrägheitZ.Text = .trägheit.Z
            TBRollwiderstand.Text = .rollwiederstand
            TBSchwerpunkt.Text = .schwerpunkt
            TBLenkradius.Text = .lenkradius
            TBAiDelta.Text = .aiheight
            TBDetailfaktor.Text = .model.detailfaktor

            TBDrehpunkt.Text = .drehpunkt

            CBAchsen.Items.Clear()
            CBAchsen.Items.Add("Benutzerdef.")
            CBAchsen.Text = "Benutzerdef."
            For i = 0 To .achsen.Count - 1
                CBAchsen.Items.Add("Achse " & i)
                If .achsen(i).Y = .drehpunkt Then CBAchsen.Text = "Achse " & i
            Next i

            If Not .sound_file Is Nothing Then TBSound.Text = .sound_file.name
            If Not .sound_ai_file Is Nothing Then TBSoundAI.Text = .sound_ai_file.name
            If Not .model Is Nothing Then TBModel.Text = .model.filename.name
            If Not .paths Is Nothing Then TBPfade.Text = .paths.filename.name
            If Not .cabin Is Nothing Then TBCabin.Text = .cabin.filename.name
            CBScriptshare.Checked = .scriptshare

            TBPräfix.Text = .reg_auto_pre
            CBPostfix.Text = .reg_auto_post
            CBKennz.Checked = Not .reg_free

            TBTcName.Text = .model.TexChangeName
            TBTcFolder.Text = .model.TexChangeFolder

            TBWagennrFile.Text = .number_path
            LoadWagenNr()

            DDAIType.SelectedIndex = 4
            If Not .aiVehicleType = Proj_Bus.AI_TYPE.NOT_SELECTED Then
                DDAIType.SelectedIndex = .aiVehicleType
            End If
        End With

    End Sub

    Private Sub LoadWagenNr()
        With TBWagennrFile
            If System.IO.File.Exists(TBPath.Text & "\" & .Text) Then
                TBWagennummern.Text = My.Computer.FileSystem.ReadAllText(TBPath.Text & "\" & .Text, Encoding.GetEncoding(1252))
                .ForeColor = Color.Black
            Else
                .ForeColor = Color.Red
            End If
        End With
    End Sub

    Private Sub SaveWagenNr()
        If System.IO.File.Exists(TBPath.Text & "\" & TBWagennrFile.Text) Then
            My.Computer.FileSystem.WriteAllText(TBPath.Text & "\" & TBWagennrFile.Text, TBWagennummern.Text, False)
        End If
    End Sub

    Private Sub BTSchließen_Click(sender As Object, e As EventArgs) Handles BTSchließen.Click
        Me.Close()
    End Sub

    Private Sub DDLaufleistung_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DDLaufleistung.SelectedIndexChanged
        Select Case sender.Selectedindex
            Case 1
                TBLaufleistung.Text = 40000
            Case 2
                TBLaufleistung.Text = 60000
            Case 3
                TBLaufleistung.Text = 80000
        End Select
    End Sub

    Private Sub BTWagenNrLaden_Click(sender As Object, e As EventArgs) Handles BTWagenNrLaden.Click
        Dim fd As New OpenFileDialog
        Dim tmp As String()

        fd.Filter = "(*.org) - OMSI-Registration|*.org"
        fd.InitialDirectory = TBPath.Text
        fd.FileName = TBWagennrFile.Text
        If fd.ShowDialog Then
            tmp = Split(fd.FileName, "\")

            TBWagennrFile.Text = tmp(tmp.Count - 1)
            LoadWagenNr()
        End If
    End Sub

    Private Sub TBWagennummern_TextChanged(sender As Object, e As EventArgs) Handles TBWagennummern.TextChanged
        If TBWagennrFile.Text <> "" And TBPath.Text <> "" Then
            My.Computer.FileSystem.WriteAllText(TBPath.Text & "\" & TBWagennrFile.Text, TBWagennummern.Text, False)
        End If
    End Sub

    Private Sub CBWagennummern_CheckedChanged(sender As Object, e As EventArgs)
        BTWagenNrLaden.Enabled = sender.checked
        TBWagennummern.Enabled = sender.checked
        LBWagennummern.Enabled = sender.checked
    End Sub

    Private Sub CBKennz_CheckedChanged(sender As Object, e As EventArgs) Handles CBKennz.CheckedChanged
        CBPostfix.Enabled = sender.checked
        LBPostfix.Enabled = sender.checked
        TBPräfix.Enabled = sender.checked
        LBPräfix.Enabled = sender.checked
    End Sub

    Private Sub Frm_Eig_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        With Projekt_Bus

            .filename.name = TBName.Text
            .filename.path = TBPath.Text

            If Not TBModel.Text = .model.filename.name Then
                If Not TBModel.Text = "" Then
                    Dim x As MsgBoxResult = MsgBox("Durch das verändern der Modell-Datei können Änderungen am vorherigen Modell verloren gehen." & vbCrLf & "Trotzdem fortsetzen?", MsgBoxStyle.YesNo)
                    If x = vbYes Then
                        .model = New OMSI_Model(New Filename(TBModel.Text, .filename.path))
                        .model.TexChangeName = TBTcName.Text
                        .model.TexChangeFolder = TBTcFolder.Text
                        Frm_Main.loadNewModel(.model)
                        Log.Add("Modell-Datei gewechselt (Datei: " & TBModel.Text & ")")
                    End If
                Else
                    .model = New OMSI_Model
                    .model.TexChangeName = TBTcName.Text
                    .model.TexChangeFolder = TBTcFolder.Text
                    Frm_Main.loadNewModel(.model)
                    Log.Add("Modell-Datei hinzugefügt (Datei: " & TBModel.Text & ")")
                End If
            End If

            If Not .cabin Is Nothing Then
                If Not TBCabin.Text = .cabin.filename.name Then
                    If Not TBCabin.Text = "" Then
                        Dim x As MsgBoxResult = MsgBox("Durch das verändern der Cabin-Datei können Änderungen am vorherigen Modell verloren gehen." & vbCrLf & "Trotzdem fortsetzen?", MsgBoxStyle.YesNo)
                        If x = vbYes Then
                            .cabin = New OMSI_Cabin(New Filename(TBCabin.Text, .filename.path))
                            Frm_Main.loadCabinPrefs(.cabin)
                            Log.Add("Cabin-Datei gewechselt (Datei: " & TBCabin.Text & ")")
                        End If
                    Else
                        .cabin = Nothing
                        Frm_Main.loadCabinPrefs(.cabin)
                        Log.Add("Cabin-Datei entfernt!")
                    End If
                End If
            Else
                If Not TBCabin.Text = "" Then
                    .cabin = New OMSI_Cabin(New Filename(TBCabin.Text, .filename.path))
                    Frm_Main.loadCabinPrefs(.cabin)
                    Log.Add("Cabin-Datei hinzugefügt (Datei: " & TBCabin.Text & ")")
                End If
            End If

                If Not .paths Is Nothing Then
                If Not TBPfade.Text = .paths.filename.name Then
                    If Not TBPfade.Text = "" Then
                        Dim x As MsgBoxResult = MsgBox("Durch das verändern der Pfade-Datei können Änderungen am vorherigen Modell verloren gehen." & vbCrLf & "Trotzdem fortsetzen?", MsgBoxStyle.YesNo)
                        If x = vbYes Then
                            .paths = New OMSI_Paths(New Filename(TBPfade.Text, .filename.path))
                            Frm_Main.loadPathsPrefs(.paths)
                            Log.Add("Pfade-Datei gewechselt (Datei: " & TBPfade.Text & ")")
                        End If
                    Else
                        .paths = Nothing
                        Frm_Main.loadPathsPrefs(.paths)
                        Log.Add("Pfade-Datei entfernt!")
                    End If
                End If
            Else
                If Not TBPfade.Text = "" Then
                    .paths = New OMSI_Paths(New Filename(TBPfade.Text, .filename.path))
                    Frm_Main.loadPathsPrefs(.paths)
                    Log.Add("Pfade-Datei hinzugefügt (Datei: " & TBPfade.Text & ")")
                End If
            End If


                .hersteller = TBHersteller.Text
            .typ = TBTyp.Text
            .anstrich = TBAnstrich.Text

            .baujahr = TBBaujahr.Text
            .laufleistung = TBLaufleistung.Text

            .masse = TBMasse.Text
            .trägheit.X = TBTrägheitX.Text
            .trägheit.Y = TBTrägheitY.Text
            .trägheit.Z = TBTrägheitZ.Text
            .rollwiederstand = TBRollwiderstand.Text
            .schwerpunkt = TBSchwerpunkt.Text
            .lenkradius = TBLenkradius.Text
            .aiheight = TBAiDelta.Text
            .model.detailfaktor = TBDetailfaktor.Text

            .beschreibung = Split(TBBeschreibung.Text, vbCrLf).ToList
            .drehpunkt = TBDrehpunkt.Text


            .reg_auto_pre = TBPräfix.Text
            .reg_auto_post = CBPostfix.Text
            .reg_free = CBKennz.Checked

            .number_path = TBWagennrFile.Text

            SaveWagenNr()
            If DDAIType.SelectedIndex = 4 Then
                .aiVehicleType = Proj_Bus.AI_TYPE.NOT_SELECTED
            Else
                .aiVehicleType = DDAIType.SelectedIndex
            End If
        End With
    End Sub

    Private Sub BTPfad_Click(sender As Object, e As EventArgs) Handles BTPfad.Click
        Dim fd As New FolderBrowserDialog
        fd.SelectedPath = TBPath.Text
        If fd.ShowDialog Then
            TBPath.Text = fd.SelectedPath
        End If
    End Sub

    Private Sub CBAchsen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBAchsen.SelectedIndexChanged
        If CBAchsen.SelectedIndex = 0 Then Exit Sub
        TBDrehpunkt.Text = Projekt_Bus.achsen(CBAchsen.SelectedIndex - 1).Y
    End Sub

    Private Function filepicker(tb As TextBox, folder As String, filetype As String)
        Dim fd As OpenFileDialog = New OpenFileDialog
        With fd
            .InitialDirectory = Projekt_Bus.filename.path & folder
            .Filter = filetype & "-Datei (*.cfg)|*.cfg"
            .Title = filetype & " öffnen"

            If .ShowDialog() = DialogResult.OK Then
                Dim tmpName As String = .FileName.Substring(Projekt_Bus.filename.path.Length + 1)
                tb.Text = tmpName
                Return tmpName
            Else
                Return tb.Text
            End If
        End With
    End Function

    Private Sub BTSound_Click(sender As Object, e As EventArgs) Handles BTSound.Click
        Dim filepath As String = filepicker(TBSound, "\Sound", "Sound")
        'Projekt_Bus.sound_file = New Filename(filepath, Projekt_Bus.filename.path)
    End Sub


    Private Sub BTSoundAI_Click(sender As Object, e As EventArgs) Handles BTSoundAI.Click
        Dim filepath As String = filepicker(TBSoundAI, "\Sound", "AI-Sound")
        'Projekt_Bus.sound_ai_file = New Filename(filepath, Projekt_Bus.filename.path)
    End Sub

    Private Sub Modell_Click(sender As Object, e As EventArgs) Handles Modell.Click
        Dim filepath As String = filepicker(TBModel, "\Model", "Modell")
        'Projekt_Bus.model.filename = New Filename(filepath, Projekt_Bus.filename.path)
    End Sub

    Private Sub BTPath_Click(sender As Object, e As EventArgs) Handles BTPath.Click
        Dim filepath As String = filepicker(TBPfade, "\Model", "Pfade")
        'If filepath = "" Then
        '    Projekt_Bus.paths = Nothing
        'Else
        '    Projekt_Bus.paths = New OMSI_Paths(New Filename(filepath, Projekt_Bus.filename.path))
        'End If
    End Sub

    Private Sub BTSitze_Click(sender As Object, e As EventArgs) Handles BTSitze.Click
        Dim filepath As String = filepicker(TBCabin, "\Model", "Cabin")
        'If filepath = "" Then
        '    Projekt_Bus.cabin = Nothing
        'Else
        '    Projekt_Bus.cabin = New OMSI_Cabin(New Filename(filepath, Projekt_Bus.filename.path))
        'End If
    End Sub

    Private Sub TBHersteller_KeyUp(sender As Object, e As KeyEventArgs) Handles TBHersteller.KeyUp
        Projekt_Bus.hersteller = TBHersteller.Text
    End Sub

    Private Sub TBTyp_KeyUp(sender As Object, e As KeyEventArgs) Handles TBTyp.KeyUp
        Projekt_Bus.typ = TBTyp.Text
    End Sub

    Private Sub TBAnstrich_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles TBAnstrich.MouseDoubleClick
        Projekt_Bus.anstrich = TBAnstrich.Text
    End Sub

    Private Sub BTOrdner_Click(sender As Object, e As EventArgs) Handles BTOrdner.Click
        If TBPath.Text <> "" Then
            If IO.Directory.Exists(TBPath.Text) Then
                Process.Start(TBPath.Text)
            Else
                MsgBox("Dieser Ordner existiert nicht!")
            End If
        Else
                MsgBox("Bitte erst ein Projekt öffnen oder erstellen!")
        End If
    End Sub

    Private Sub BTModellDel_Click(sender As Object, e As EventArgs) Handles BTModellDel.Click
        TBModel.Clear()
    End Sub

    Private Sub BTSoudDel_Click(sender As Object, e As EventArgs) Handles BTSoudDel.Click
        TBSound.Clear()
    End Sub

    Private Sub BTAISoundDel_Click(sender As Object, e As EventArgs) Handles BTAISoundDel.Click
        TBSoundAI.Clear()
    End Sub

    Private Sub BTPfadeDel_Click(sender As Object, e As EventArgs) Handles BTPfadeDel.Click
        TBPfade.Clear()
    End Sub

    Private Sub BTCabinDel_Click(sender As Object, e As EventArgs) Handles BTCabinDel.Click
        TBCabin.Clear()
    End Sub

    Private Sub CBScriptshare_CheckedChanged(sender As Object, e As EventArgs) Handles CBScriptshare.CheckedChanged
        Projekt_Bus.scriptshare = CBScriptshare.Checked
    End Sub
End Class