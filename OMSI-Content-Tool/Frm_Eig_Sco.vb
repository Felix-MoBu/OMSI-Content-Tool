'by Felix Modellbusse ;) (MoBu) 2019
Imports System.ComponentModel

Public Class Frm_Eig_Sco
    Public Projekt_Sco As Proj_Sco

    Private Sub Frm_Eig_Sco_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Location = New Point(Frm_Main.Width / 2 - Me.Width / 2, Frm_Main.Height / 2 - Me.Height / 2)

        With Projekt_Sco
            TBDateiname.Text = .filename.name
            TBPath.Text = .filename.path
            If Not .cabin Is Nothing Then
                TBCabin.Text = .cabin.filename.path
            End If
            If Not .sound_file Is Nothing Then
                TBSound.Text = .sound_file.name
            End If
            If Not Projekt_Sco.model.filename = Projekt_Sco.filename Then
                CBModel.Checked = True
                TBModel.Text = Projekt_Sco.model.filename
            End If

            TBName.Text = .name
            TBGruppen.Text = Join(.gruppen.ToArray, vbCrLf)

            CBonlyEditor.Checked = .onlyeditor
            TBDetailfaktor.Text = .detail_factor
            CBComplexcity.SelectedIndex = .complexity
            CBRendertype.Text = .rendertype

            If .petrolstation Or .busstop Or .carpark_p Or .entrypoint Or .helparrow Then
                RBHilfsobj.Checked = True
            End If

            CBTankstelle.Checked = .petrolstation
            CBBusstop.Checked = .busstop
            CBCarpark.Checked = .carpark_p
            CBEntrypoint.Checked = .entrypoint
            CBHilfspfeil.Checked = .helparrow

            CBFixed.Checked = .fixed
            CBSurface.Checked = .surface
            CBJoinable.Checked = .joinable
            CBNocollision.Checked = .nocollision
            CBAbsHeight.Checked = .absheight
            TBCrashmodeKraft.Text = .crashmode_pole.X
            TBCrashmodeWinkel.Text = .crashmode_pole.Y

            CBLightmapMapping.Checked = .LightMapMapping
            CBShadow.Checked = .shadow
            CBNormalBel.Checked = .nomaplighting
            CBNightMapMode.SelectedIndex = .nightmapmode
        End With
    End Sub

    Private Sub TBName_TextChanged(sender As Object, e As EventArgs) Handles TBName.TextChanged
        Projekt_Sco.name = TBName.Text
    End Sub

    Private Sub Frm_Eig_Sco_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If Trim(TBGruppen.Text) = "" Then
            MsgBox("Gruppen dürfen nicht leer bleiben!")
            e.Cancel = True
        End If

        With Projekt_Sco
            .filename.name = TBDateiname.Text
            .filename.path = TBPath.Text
            If TBCabin.Text <> "" Then
                .cabin.filename.path = TBCabin.Text
            End If
            If TBSound.Text <> "" Then
                .sound_file.name = TBSound.Text
            End If

            .name = TBName.Text
            .gruppen.Clear()
            For Each gruppe In Split(TBGruppen.Text, vbCrLf)
                If Trim(gruppe) <> "" Then
                    .gruppen.Add(Trim(gruppe))
                End If
            Next

            .onlyeditor = CBonlyEditor.Checked
            .detail_factor = TBDetailfaktor.Text
            .complexity = CBComplexcity.SelectedIndex
            .rendertype = CBRendertype.Text

            .petrolstation = CBTankstelle.Checked
            .busstop = CBBusstop.Checked
            .carpark_p = CBCarpark.Checked
            .entrypoint = CBEntrypoint.Checked
            .helparrow = CBHilfspfeil.Checked

            .fixed = CBFixed.Checked
            .surface = CBSurface.Checked
            .joinable = CBJoinable.Checked
            .nocollision = CBNocollision.Checked
            .absheight = CBAbsHeight.Checked
            .crashmode_pole.X = TBCrashmodeKraft.Text
            .crashmode_pole.Y = TBCrashmodeWinkel.Text

            .LightMapMapping = CBLightmapMapping.Checked
            .shadow = CBShadow.Checked
            .nomaplighting = CBNormalBel.Checked
            .nightmapmode = CBNightMapMode.SelectedIndex
        End With
    End Sub

    Private Sub RBHilfsobj_CheckedChanged(sender As Object, e As EventArgs) Handles RBHilfsobj.CheckedChanged
        GBGeneric.Enabled = RBHilfsobj.Checked
    End Sub

    Private Sub BTOrdner_Click(sender As Object, e As EventArgs) Handles BTOrdner.Click
        If TBPath.Text <> "" Then
            Process.Start(TBPath.Text)
        Else
            MsgBox("Bitte erst ein Projekt öffnen oder erstellen!")
        End If
    End Sub

    Private Sub BTSchließen_Click(sender As Object, e As EventArgs) Handles BTSchließen.Click
        Me.Close()
    End Sub

    Private Sub CBModel_CheckedChanged(sender As Object, e As EventArgs) Handles CBModel.CheckedChanged
        TBModel.Enabled = CBModel.Checked
    End Sub
End Class