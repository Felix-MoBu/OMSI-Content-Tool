'by Felix Modellbusse ;) (MoBu) 2019
Imports System.Text

Public Class Frm_Rep
    Dim repaints As New List(Of OMSI_Repaint)
    Dim rep_vars As New List(Of OMSI_Rep_Var)
    Dim nameTemp As String
    Dim noLoad As Boolean
    Dim allFiles As New List(Of String)
    Dim TexChangeFolder As String
    Dim renameRepaint As Boolean = False
    Dim anstrichAlt As String

    Public Projekt_Bus As Proj_Bus

    Private Sub Frm_Rep_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TexChangeFolder = Projekt_Bus.filename.path & "\" & Projekt_Bus.model.TexChangeFolder

        Me.Location = New Point(Frm_Main.Width / 2 - Me.Width / 2, Frm_Main.Height / 2 - Me.Height / 2)

        einlesen()
        TBFilter.Text = ""
    End Sub

    Private Sub einlesen()
        'Standardlack
        anstrichAlt = Projekt_Bus.anstrich
        For Each TCTex In Projekt_Bus.model.TexChangeTexs
            Dim newRP As New OMSI_Repaint
            With newRP
                .ctifile = "Standardlack"
                .name = Projekt_Bus.anstrich & " 🔒"
                .file = TCTex.file
                .var = TCTex.Var
                .changed = False
                .anstrich = True
            End With
            repaints.Add(newRP)
        Next

        'CTI-Dateien einlesen
        Dim files() As String = IO.Directory.GetFiles(TexChangeFolder, "*.cti", IO.SearchOption.TopDirectoryOnly)
        For Each file In files
            Dim lines() As String = Split(My.Computer.FileSystem.ReadAllText(file, Encoding.GetEncoding(1252)), vbCrLf)
            Dim lastName As String = ""

            For i = 0 To lines.Count - 1
                If lines(i) = "[item]" Then
                    Dim rp As New OMSI_Repaint
                    With rp
                        lastName = lines(i + 1)
                        .name = lines(i + 1)
                        .var = lines(i + 2)
                        .ctifile = file.Substring(TexChangeFolder.Count + 1)
                        .file = Replace(lines(i + 3), "/", "\")
                        If InStr(lines(i + 3), "/") Then
                            Log.Add("Formatfehler in Repaint automatisch behoben! (Fehler: R001, Zeile: " & i + 3 & " Datei: " & file & ")", Log.TYPE_WARNUNG)
                            .changed = True
                        Else
                            .changed = False
                        End If
                    End With
                    repaints.Add(rp)
                End If
                If lines(i) = "[setvar]" Then
                    Dim rv As New OMSI_Rep_Var
                    With rv
                        .name = lastName
                        .file = file
                        .var = lines(i + 1)
                        .val = lines(i + 2)
                    End With
                    rep_vars.Add(rv)
                End If
            Next
        Next

        'Alle Bild-Dateien einlesen
        Dim allFilesTmp() As String = IO.Directory.GetFiles(TexChangeFolder, "*.*", IO.SearchOption.AllDirectories)

        'Nur die Unterstützten formate raus filtern
        allFiles.Add("")
        For Each file In allFilesTmp
            If Frm_Main.OMSI_ImageFormats.Contains(file.Split(".").Last) Then
                allFiles.Add(file.Substring(TexChangeFolder.Count + 1))
            End If
        Next

        Dim lastSelectedRepaint As String = Frm_Main.repName

        'Listbox füllen
        For Each repaint In repaints
            For Each ctc In Projekt_Bus.model.TexChangeTexs
                If ctc.Var = repaint.var Then
                    If Not LBRepaints.Items.Contains(repaint.name) Then
                        LBRepaints.Items.Add(repaint.name)
                        Exit For
                    End If
                End If
            Next
        Next

        'Texturechange Elemente anzeigen
        For i = 0 To Projekt_Bus.model.TexChangeTexs.Count - 1

            'Label für jede Tauschtexture hinzufügen
            Dim lb As New Label
            With Projekt_Bus.model.TexChangeTexs(i)
                lb.Name = "LB" & i
                lb.Top = i * 25 + 80
                lb.Left = 5
                lb.Width = 200
                lb.Height = 20
                lb.BackColor = Color.White
                lb.Text = .Var & " (" & .file & ")"
            End With
            PMain.Controls.Add(lb)

            'Combobox für jede Tauschtexture hinzufügen
            Dim cb As New ComboBox
            With cb
                .Name = "CB" & i
                .Top = i * 25 + 80
                .Left = 210
                .Width = 250
                .Items.AddRange(allFiles.ToArray)
                AddHandler .SelectedIndexChanged, AddressOf texture_changed
            End With
            PMain.Controls.Add(cb)

            'Bearbeiten-Button für jede Tauschtexture hinzufügen
            Dim bt As New Button
            With bt
                .Name = "BT" & i
                .Text = "Bearbeiten"
                .Top = i * 25 + 80
                .Left = 465
                .Enabled = False
                AddHandler .Click, AddressOf bearbeiten_click
            End With
            PMain.Controls.Add(bt)
        Next

        PRepVars.Top = Projekt_Bus.model.TexChangeTexs.Count * 25 + 80
        PRepVars.Controls.Clear()

        If LBRepaints.Items.Count > 1 Then
            LBRepaints.SelectedIndex = 1
            If lastSelectedRepaint <> "" Then
                If LBRepaints.Items.Contains(lastSelectedRepaint) Then
                    LBRepaints.SelectedIndex = LBRepaints.Items.IndexOf(lastSelectedRepaint)
                Else
                    LBRepaints.SelectedIndex = 0
                End If
            Else
                LBRepaints.SelectedIndex = 0
            End If
        End If

        noLoad = False

        Log.Add(LBRepaints.Items.Count & " Repaints geladen!")
    End Sub

    Private Sub bearbeiten_click(ByVal sender As Object, ByVal e As EventArgs)
        Dim id As Integer = sender.name.substring(2)
        For Each control In PMain.Controls
            If control.Name = "CB" & id Then
                Dim RepFolder As String = TexChangeFolder
                If LBRepaints.SelectedIndex = 0 Then
                    RepFolder = Projekt_Bus.filename.path & "\Texture"
                End If

                If My.Computer.FileSystem.FileExists(RepFolder & "\" & control.text) Then
                    Process.Start(RepFolder & "\" & control.text)
                    Exit For
                Else
                    MsgBox("Die angegebene Datei existiert nicht!")
                    Log.Add("Die Texture existiert nicht! (Fehler: R011, Datei: " & TexChangeFolder & "/" & control.text & ")", Log.TYPE_ERROR)
                    Exit For
                End If
            End If
        Next

    End Sub

    Private Sub texture_changed(sender As Object, e As EventArgs)
        For i = 0 To PMain.Controls.Count - 1
            If sender.name = "CB" & i Then
                For Each control In PMain.Controls
                    If control.Name = "BT" & i Then
                        If sender.Text <> "" Then
                            control.Enabled = True
                        Else
                            control.Enabled = False
                        End If
                        Exit Sub    'Hier nach passiert nix mehr
                    End If
                Next
            End If
        Next

    End Sub

    'Listbox
    Private Sub LBRepaints_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LBRepaints.SelectedIndexChanged
        Frm_Main.origTexturen.Clear()
        Frm_Main.overWriteTextures.Clear()

        Dim noSelected As Boolean = True
        If Not renameRepaint Then
            For Each control In PMain.Controls
                If InStr(control.name, "CB") Then
                    If control.Text <> "" Then noSelected = False
                    control.Text = ""
                    control.backcolor = Color.White
                End If
                If InStr(control.Name, "BT") Then
                    control.Enabled = False
                End If
            Next
        End If


        If noSelected And noLoad And Not renameRepaint Then
            Dim result As Integer = MsgBox("Für dieses Repaint sind keine Texturen ausgewählt. Soll das Repaint gelöscht werden?", vbYesNo)
            Select Case result
                Case vbYes
                    LBRepaints.Items.Remove(TBName.Text)
                Case vbNo
                    noLoad = False
                    LBRepaints.SelectedItem = TBName.Text
                    Exit Sub
            End Select
        End If
        noLoad = True

        For Each control In PMain.Controls
            If control.Name.contains("CB") Then
                control.Enabled = True
            End If
        Next


        For Each repaint In repaints
            If repaint.name = LBRepaints.SelectedItem Then
                TBName.Text = repaint.name.Replace(" 🔒", "")
                LabelDateiname.Text = repaint.ctifile
                For i = 0 To Projekt_Bus.model.TexChangeTexs.Count - 1
                    If repaint.var = Projekt_Bus.model.TexChangeTexs(i).Var Then

                        Dim RepFolder As String = TexChangeFolder
                        Dim ChangeEnable As Boolean = True
                        If LBRepaints.SelectedIndex = 0 Then
                            RepFolder = Projekt_Bus.filename.path & "\Texture"
                            ChangeEnable = False
                            BTEntfernen.Enabled = False
                        End If

                        For Each control In PMain.Controls
                            If control.Name = "CB" & i Then
                                If My.Computer.FileSystem.FileExists(RepFolder & "\" & repaint.file) Then
                                    control.selecteditem = repaint.file
                                Else
                                    control.backcolor = Color.Red
                                End If
                                control.Text = repaint.file
                                control.Enabled = ChangeEnable
                            End If
                            If control.Name = "BT" & i Then
                                control.Enabled = True
                            End If
                        Next

                        If LBRepaints.SelectedIndex > 0 Then
                            Dim newLT As New LocalTexture
                            newLT.filename = New Filename(repaint.file, RepFolder)
                            Frm_Main.loadTexture(newLT)         '<- Hier vlt mit True die vorher geladene Texture überschreiben!
                            Frm_Main.origTexturen.Add(New Filename(Projekt_Bus.model.TexChangeTexs(i).file, Projekt_Bus.filename.path & "\Texture"))
                            Frm_Main.overWriteTextures.Add(newLT)
                            Frm_Main.repName = LBRepaints.SelectedItem
                            Exit For
                        End If
                    End If
                Next
            End If
        Next

        loadPVars()
        Frm_Main.GlMain.Invalidate()
    End Sub

    Private Sub loadPVars()

        For Each Control In PRepVars.Controls
            If InStr(Control.Name, "VS;") Then
                If Control.Variable <> "" Then
                    Frm_Main.RecalcVis(Control.Variable, 0)
                End If
            End If
        Next

        PRepVars.Visible = False
        PRepVars.Controls.Clear()

        If Not LBRepaints.SelectedIndex = 0 Then
            Dim LB As New Label
            With LB
                .Text = "Variablen"
                .Font = New Font(.Font, FontStyle.Bold)
                .Top = 0
                .Left = 0
                .Width = 100
                .Height = 19
            End With
            PRepVars.Controls.Add(LB)

            Dim PVars_line As Integer = 0
            Dim leftOffset As Integer = 0
            Dim ctVar As Integer = 0
            For Each rep_var In rep_vars
                If rep_var.name = LBRepaints.SelectedItem Then
                    Dim VS As New VarSelector
                    With VS
                        .Variable = rep_var.var
                        .Top = 20 + 25 * PVars_line
                        .Left = leftOffset
                        .Width = 100
                        .Height = 20
                        .Name = "VS;" & ctVar
                        .TBVar.Name = "VSTB;" & ctVar
                        AddHandler .TBVar.TextChanged, AddressOf var_changed
                    End With
                    PRepVars.Controls.Add(VS)

                    Dim TB As New TextBox
                    With TB
                        .Text = rep_var.val
                        .Top = 20 + 25 * PVars_line
                        .Left = 105 + leftOffset
                        .Width = 50
                        .Height = 20
                        .Name = "TB;" & ctVar
                        AddHandler .TextChanged, AddressOf var_changed
                    End With
                    PRepVars.Controls.Add(TB)

                    Dim BT As New Button
                    With BT
                        .Text = "✕"
                        .Top = 20 + 25 * PVars_line
                        .Left = 160 + leftOffset
                        .Height = 20
                        .Width = 20
                        .Name = leftOffset & ";" & 20 + 25 * PVars_line & ";" & ctVar
                        AddHandler .Click, AddressOf varLoeschen_click
                    End With
                    PRepVars.Controls.Add(BT)

                    If leftOffset = 0 Then
                        leftOffset = 200
                    Else
                        PVars_line += 1
                        leftOffset = 0
                    End If

                    'Frm_Main.resetVis()
                    'If Not rep_var.val = 0 Then
                    Frm_Main.RecalcVis(rep_var.var, rep_var.val)
                    ' End If

                    For varind = 0 To Frm_Main.AlleVariablen.Count - 1
                        If Frm_Main.AlleVariablen(varind) = rep_var.name Then
                            Frm_Main.AlleVarValues(varind) = rep_var.val
                            Exit For
                        End If
                    Next
                    ctVar += 1
                End If
            Next

            Dim BTn As New Button
            With BTn
                .Text = "Neu"
                .Name = "BTVarNeu"
                .Top = 20 + 25 * PVars_line
                .Left = leftOffset
                .Width = 50
                .Height = 20
                AddHandler .Click, AddressOf varNeu_click
            End With
            PRepVars.Controls.Add(BTn)

            PVars_line += 1

            PRepVars.Height = 20 + 25 * PVars_line
            PRepVars.Visible = True
        End If
    End Sub

    Private Sub var_changed(ByVal sender As Object, ByVal e As EventArgs)
        Dim ctVar As Integer = 0
        For Each rep_var In rep_vars
            If rep_var.name = TBName.Text Then
                If sender.name.split(";")(1) = ctVar Then
                    If TypeOf sender Is VarSelector Then
                        rep_var.var = sender.variable
                    End If
                    If TypeOf sender Is TextBox Then
                        If IsNumeric(sender.Text) Then
                            If sender.Text <> "" Then rep_var.val = sender.Text
                        Else
                            rep_var.var = sender.text
                        End If
                    End If

                        Frm_Main.resetVis()
                    If Not rep_var.val = 0 Then
                        Frm_Main.RecalcVis(rep_var.var, rep_var.val)
                    End If

                    Frm_Main.GlMain.Invalidate()
                    Exit For
                End If
                ctVar += 1
            End If
        Next
    End Sub

    Private Sub varLoeschen_click(ByVal sender As Object, ByVal e As EventArgs)
        MsgBox(sender.name)

        For Each control In PRepVars.Controls
            If control.location = New Point(Split(sender.name, ";")(0), Split(sender.name, ";")(1)) Then
                For Each rep_var In rep_vars
                    If rep_var.name = TBName.Text Then
                        If rep_var.var = control.variable Then
                            rep_vars.Remove(rep_var)
                            loadPVars()
                        End If
                        Exit For
                    End If
                Next
                Exit For
            End If
        Next
    End Sub

    Private Sub varNeu_click(ByVal sender As Object, ByVal e As EventArgs)
        Dim rep_var As New OMSI_Rep_Var
        rep_var.name = TBName.Text
        rep_vars.Add(rep_var)
        loadPVars()
    End Sub


    Private Sub BTNeu_Click(sender As Object, e As EventArgs) Handles BTNeu.Click
        Dim index As Integer = 1

        Do While LBRepaints.Items.Contains("Neu" & index)
            index += 1
        Loop

        LBRepaints.Items.Add("Neu" & index)
        LBRepaints.SelectedIndex = LBRepaints.Items.Count - 1
        TBName.Text = "Neu" & index
    End Sub

    'Name ändern
    Private Sub TBName_Enter(sender As Object, e As EventArgs) Handles TBName.Enter
        nameTemp = TBName.Text
    End Sub

    Private Sub TBName_Leave(sender As Object, e As EventArgs) Handles TBName.Leave
        checkAndRename()
    End Sub

    Private Sub TBName_KeyDown(sender As Object, e As KeyEventArgs) Handles TBName.KeyDown
        If e.KeyCode = Keys.Enter Then
            checkAndRename()
        End If
    End Sub

    Private Sub checkAndRename()
        Dim doppelt As Boolean = False

        If Not TBName.Text = nameTemp Then
            For Each item In LBRepaints.Items
                If item = TBName.Text Then
                    MsgBox("Dieser Name wird bereits verwendet!")
                    TBName.Select()
                    doppelt = True
                End If
            Next

            For Each rep_var In rep_vars
                If rep_var.name = nameTemp Then
                    rep_var.name = TBName.Text
                End If
            Next
        End If

        If Not doppelt Then
            For Each repaint In repaints
                If repaint.name = nameTemp Then
                    repaint.name = TBName.Text
                    repaint.changed = True
                End If

            Next
            renameRepaint = True
            LBRepaints.Items(LBRepaints.SelectedIndex) = TBName.Text
            renameRepaint = False
        End If
        nameTemp = TBName.Text
    End Sub

    'Speichern
    Private Sub BTSpeichern_Click(sender As Object, e As EventArgs) Handles BTSpeichern.Click
        Dim newCtifile As String = ""
        Dim oldname As String = ""
        Dim anstrichChanged As Boolean = False

        For Each repaint In repaints
            If repaint.changed = True Then
                If repaint.anstrich = False Then
                    Dim tempStr As String = "Diese Datei wurde mit dem OMSI-Content-Tool erstellt/bearbeitet" & vbCrLf & vbCrLf
                    For Each repaint2 In repaints
                        With repaint2
                            If .ctifile = repaint.ctifile Then
                                If oldname <> .name Then
                                    tempStr &= "---------------------------------" & vbCrLf & .name & vbCrLf & "---------------------------------" & vbCrLf & vbCrLf
                                    oldname = .name
                                End If
                                newCtifile = TexChangeFolder & "\" & .ctifile
                                tempStr &= "[item]" & vbCrLf
                                tempStr &= .name & vbCrLf
                                tempStr &= .var & vbCrLf
                                tempStr &= .file & vbCrLf & vbCrLf
                                repaint2.changed = False
                            End If
                        End With
                    Next
                    For Each rep_var In rep_vars
                        If rep_var.name = repaint.name Then
                            With rep_var
                                If .var <> "" Then
                                    tempStr &= vbCrLf & "[setvar]" & vbCrLf
                                    tempStr &= .var & vbCrLf
                                    tempStr &= .val & vbCrLf
                                End If
                            End With
                        End If
                    Next
                    If newCtifile <> "" Then
                        My.Computer.FileSystem.WriteAllText(newCtifile, tempStr, False)
                        Log.Add("Repaint-Datei neu geschrieben: " & newCtifile)
                    End If

                Else
                    If Not anstrichChanged Then
                        Projekt_Bus.anstrich = repaint.name
                        anstrichChanged = True
                        Log.Add("Standardanstrich umbenannt (Alt: " & anstrichAlt & ", Neu: " & repaint.name & ")")
                    End If
                End If
            End If
        Next
        Me.Close()
    End Sub

    Private Sub BTÖffnen_Click(sender As Object, e As EventArgs) Handles BTÖffnen.Click
        Process.Start(TexChangeFolder)
    End Sub

    Private Sub BTNeuLaden_Click(sender As Object, e As EventArgs) Handles BTNeuLaden.Click
        einlesen()
    End Sub

    Private Sub TBFilter_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TBFilter.KeyPress
        LBRepaints.Items.Clear()
        For Each repaint In repaints
            If LCase(repaint.name).Contains(LCase(TBFilter.Text)) Then
                LBRepaints.Items.Add(repaint.name)
            End If
        Next
        If LBRepaints.Items.Count > 1 Then
            LBRepaints.SelectedIndex = 0
        End If
    End Sub

    Private Sub BTRepTool_Click(sender As Object, e As EventArgs) Handles BTRepTool.Click
        If My.Computer.FileSystem.FileExists(My.Settings.RepToolPfad) Then
            Process.Start(My.Settings.RepToolPfad)
        Else
            MsgBox("Bitte wähle zunächst in den Einstellungen den Pfad zum Repaint-Tool aus!")
        End If
    End Sub
End Class