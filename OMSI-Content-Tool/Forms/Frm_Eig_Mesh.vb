'by Felix Modellbusse ;) (MoBu) 2019
Public Class Frm_Eig_Mesh
    Public actMesh As OMSI_Mesh
    Private Sub Frm_Eig_Mesh_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not actMesh Is Nothing Then
            addProp("Name", actMesh.filename.name)
            addProp("Erstellt", IO.File.GetCreationTime(actMesh.filename))
            addProp("Geändert", IO.File.GetLastWriteTime(actMesh.filename))
            addProp("O3D-Version", actMesh.o3dVersion)
            addProp("Protected", actMesh.isProtected.ToString)
            For Each objekt In Frm_Main.AlleObjekte
                If actMesh.ObjIds.Contains(objekt.id) Then
                    With objekt
                        addProp("Eckpunkte", .vertices.Count / 3)
                        addProp("Subobjekte", .subObjekte.Count)
                        Dim subObjekteCount As Integer = 0
                        For Each subObjekt In .subObjekte
                            subObjekteCount += subObjekt.Count
                        Next
                        addProp("Flächen", subObjekteCount / 3)

                        addEmptProp()
                        For i As Integer = 0 To .texturen.Count - 1
                            Dim additional As String = ""
                            If .texturen(i).matName <> "" Then additional = " (" & .texturen(i).matName & ")"
                            addProp("Texture_" & i, .texturen(i).filename.name & additional)
                        Next
                    End With
                End If
            Next
        End If
    End Sub

    Private Sub addProp(prop As String, val As String)
        LBLabels.Items.Add(prop)
        LBProps.Items.Add(val)
    End Sub

    Private Sub addEmptProp()
        LBLabels.Items.Add("")
        LBProps.Items.Add("")
    End Sub

    Private Sub KopierenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KopierenToolStripMenuItem.Click
        Clipboard.SetText(LBProps.SelectedItem)
    End Sub

    Private Sub LBProps_MouseDown(sender As Object, e As MouseEventArgs) Handles LBProps.MouseDown
        LBLabels.SelectedIndex = LBProps.SelectedIndex
    End Sub

    Private Sub LBProps_MouseUp(sender As Object, e As MouseEventArgs) Handles LBProps.MouseUp
        LBLabels.SelectedIndex = LBProps.SelectedIndex
    End Sub

    Private Sub LBLabels_MouseDown(sender As Object, e As MouseEventArgs) Handles LBLabels.MouseDown
        LBProps.SelectedIndex = LBLabels.SelectedIndex
    End Sub

    Private Sub LBLabels_MouseUp(sender As Object, e As MouseEventArgs) Handles LBLabels.MouseUp
        LBProps.SelectedIndex = LBLabels.SelectedIndex
    End Sub
End Class