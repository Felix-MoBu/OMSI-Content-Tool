Public Class Frm_AnimGrp
    Dim automatic As Boolean

    Private Sub Frm_AnimGrp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Location = New Point(Frm_Main.Width / 2 - Me.Width / 2, Frm_Main.Height / 2 - Me.Height / 2)
        LBGruppennamen.Items.Clear()
        DDMaster.Items.Clear()
        DDMaster.Items.Add("")

        TBName.Text = ""
        DDMaster.Text = ""

        For Each mesh In Frm_Main.getProj.model.meshes
            If Not mesh.meshident Is Nothing Then
                If mesh.meshident <> "" And Not LBGruppennamen.Items.Contains(mesh.meshident) Then
                    LBGruppennamen.Items.Add(mesh.meshident)
                End If
            End If
        Next

        'Gruppen ohne Master
        For Each mesh In Frm_Main.getProj.model.meshes
            If Not mesh.animparent Is Nothing Then
                If mesh.animparent <> "" And Not LBGruppennamen.Items.Contains(mesh.animparent) Then
                    LBGruppennamen.Items.Add(mesh.animparent)
                    MsgBox("Die Gruppe """ & mesh.animparent & """ hat keinen Master!")
                End If
            End If
        Next

        For Each file In Frm_Main.LBMeshes.Items
            DDMaster.Items.Add(file)
        Next

        If LBGruppennamen.Items.Contains(Frm_Main.Anim_TBAnimGrp.Text) Then
            LBGruppennamen.SelectedItem = Frm_Main.Anim_TBAnimGrp
        End If
    End Sub

    Private Sub BTNeu_Click(sender As Object, e As EventArgs) Handles BTNeu.Click
        LBGruppennamen.Items.Add("Neue Gruppe")
        LBGruppennamen.SelectedIndex = LBGruppennamen.Items.Count - 1
    End Sub

    Private Sub BTEntfernen_MouseEnter(sender As Object, e As EventArgs) Handles BTEntfernen.MouseEnter
        If BTEntfernen.Enabled = False Then
            LBInfo.Visible = True
        End If
    End Sub

    Private Sub BTEntfernen_MouseLeave(sender As Object, e As EventArgs) Handles BTEntfernen.MouseLeave
        LBInfo.Visible = False
    End Sub

    Private Sub LBGruppennamen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LBGruppennamen.SelectedIndexChanged
        If Not automatic Then       'Sonst werden die Masters verändert!
            LBMeshes.Items.Clear()
            For Each mesh In Frm_Main.getProj.model.meshes
                If mesh.animparent = LBGruppennamen.SelectedItem Then
                    LBMeshes.Items.Add(mesh.filename.name)
                End If

                If mesh.meshident = LBGruppennamen.SelectedItem Then
                    DDMaster.Text = mesh.filename.name
                End If
            Next
            TBName.Text = LBGruppennamen.SelectedItem
        End If
    End Sub

    Private Sub BTÄndern_Click(sender As Object, e As EventArgs) Handles BTÄndern.Click
        If Not TBName.Text.Contains(" ") Then
            If Not LBGruppennamen.Items.Contains(TBName.Text) Then
                For Each mesh In Frm_Main.getProj.model.meshes
                    If mesh.animparent = LBGruppennamen.SelectedItem Then
                        mesh.animparent = TBName.Text
                    End If

                    If mesh.meshident = LBGruppennamen.SelectedItem Then
                        mesh.meshident = TBName.Text
                    End If
                Next
                automatic = True
                LBGruppennamen.Items(LBGruppennamen.SelectedIndex) = TBName.Text
                automatic = False
            End If
        Else
            MsgBox("Der Gruppenname darf kein Leerzeichen enthalten!")
        End If
    End Sub

    Private Sub BTÜbernehmen_Click(sender As Object, e As EventArgs) Handles BTÜbernehmen.Click
        Frm_Main.Anim_TBAnimGrp.Text = LBGruppennamen.SelectedItem
        Me.Close()
    End Sub

    Private Sub BTKeine_Click(sender As Object, e As EventArgs) Handles BTKeine.Click
        Frm_Main.Anim_TBAnimGrp.Text = ""
        Me.Close()
    End Sub

    Private Sub DDMaster_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DDMaster.SelectedIndexChanged
        For Each mesh In Frm_Main.getProj.model.meshes
            If mesh.meshident = LBGruppennamen.SelectedItem Then
                mesh.meshident = ""
            End If

            If mesh.filename.name = DDMaster.Text Then
                mesh.meshident = LBGruppennamen.SelectedItem
            End If
        Next
    End Sub
End Class