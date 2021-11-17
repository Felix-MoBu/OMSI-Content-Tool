Imports System.ComponentModel

Public Class Frm_Eig

    Private Sub Frm_Eig_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Location = New Point(Frm_Main.Width / 2 - Me.Width / 2, Frm_Main.Height / 2 - Me.Height / 2)
        DDLaufleistung.SelectedIndex = 0

        DDSprache.Items.Clear()
        DDSprache.Items.Add("Andere")
        DDSprache.SelectedIndex = 0
        Dim files() As String = IO.Directory.GetFiles(My.Settings.OmsiPfad & "\Languages")
        For Each file As String In files
            Dim s1 As String() = Split(file, "\")
            Dim s2 As String = Split(s1(s1.Count - 1), "_")(0)
            If Not DDSprache.Items.Contains(s2) Then
                DDSprache.Items.Add(s2)
            End If
        Next

        With Frm_Main.Projekt

            TBName.Text = .filename
            TBPath.Text = .path

            TBHersteller.Text = .hersteller
            TBTyp.Text = .typ
            TBAnstrich.Text = .anstrich
            TBBeschreibung.Text = .beschreibung

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
                If .achsen(i).achse_long = .drehpunkt Then CBAchsen.Text = "Achse " & i
            Next i

            TBSound.Text = .sound_file
            TBSoundAI.Text = .sound_ai_file
            TBModel.Text = .model.filename
            TBPfade.Text = .path_file
            TBCabin.Text = .cabin_file


            TBPräfix.Text = .reg_auto_pre
            CBPostfix.Text = .reg_auto_post
            CBKennz.Checked = .reg_free

            TBTcName.Text = .model.TexChangeName
            TBTcFolder.Text = .model.TexChangeFolder

            TBWagennrFile.Text = .number_path
            LoadWagenNr()
        End With

    End Sub

    Private Sub LoadWagenNr()
        With TBWagennrFile
            If My.Computer.FileSystem.FileExists(TBPath.Text & "\" & .Text) Then
                TBWagennummern.Text = My.Computer.FileSystem.ReadAllText(TBPath.Text & "\" & .Text)
                .ForeColor = Color.Black
            Else
                .ForeColor = Color.Red
            End If
        End With
    End Sub

    Private Sub SaveWagenNr()
        If My.Computer.FileSystem.FileExists(TBPath.Text & "\" & TBWagennrFile.Text) Then
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
        With Frm_Main.Projekt

            .filename = TBName.Text
            .path = TBPath.Text

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

            .beschreibung = TBBeschreibung.Text
            .drehpunkt = TBDrehpunkt.Text


            .reg_auto_pre = TBPräfix.Text
            .reg_auto_post = CBPostfix.Text
            .reg_free = CBKennz.Checked

            .number_path = TBWagennrFile.Text

            .model.TexChangeName = TBTcName.Text
            .model.TexChangeFolder = TBTcFolder.Text

            SaveWagenNr()
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
        TBDrehpunkt.Text = Frm_Main.Projekt.achsen(CBAchsen.SelectedIndex - 1).achse_long
    End Sub
End Class