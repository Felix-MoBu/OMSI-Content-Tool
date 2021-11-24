'by Felix Modellbusse ;) (MoBu) 2019
Public Class Frm_Eig_Mesh
    Public actMesh As OMSI_Mesh
    Private Sub Frm_Eig_Mesh_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not actMesh Is Nothing Then
            addProp("Name", actMesh.filename.name)
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
                        addProp("Flächen", subObjekteCount)
                        addProp("", "")
                        For i As Integer = 0 To .Texturen.Count - 1
                            addProp("Texture_" & i, .Texturen(i).filename.name)
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

    Private Sub LBLabels_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LBLabels.SelectedIndexChanged
        LBProps.SelectedIndex = LBLabels.SelectedIndex
    End Sub

    Private Sub LBProps_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LBProps.SelectedIndexChanged
        LBLabels.SelectedIndex = LBProps.SelectedIndex
    End Sub
End Class