'by Felix Modellbusse ;) (MoBu) 2019

Public Class OMSI_Attachment
    Public name As String
    Private attach_rot_int As New Point3D
    Private attach_pnt_int As New Point3D

    Public vertices As Double()
    Private vertices_int As Double() = {0, 0, 0.1,
                                        -0.0866, 0, 0.05,
                                        -0.0866, 0, -0.05,
                                        0, 0, -0.1,
                                        0.0866, 0, -0.05,
                                        0.0866, 0, 0.05}
    Public edges As Integer() = {1, 2, 0,
                                 1, 0, 2,
                                 3, 4, 2,
                                 3, 2, 4,
                                 5, 0, 4,
                                 5, 4, 0, 0}

    Public Sub New()
        recalcPosition()
    End Sub

    Public Property attach_rot As Point3D
        Get
            Return attach_rot_int
        End Get
        Set(value As Point3D)
            attach_rot_int = value
            recalcPosition()
        End Set
    End Property

    Public Property attach_pnt As Point3D
        Get
            Return attach_pnt_int
        End Get
        Set(value As Point3D)
            attach_pnt_int = value
            recalcPosition()
        End Set
    End Property

    Private Sub recalcPosition()
        Dim newVerts As New List(Of Point3D)
        For i As Integer = 0 To vertices_int.Count - 1 Step 3
            newVerts.Add(New Point3D(vertices_int(i), vertices_int(i + 1), vertices_int(i + 2)))
        Next

        If Not attach_rot.X = 0 Then
            For Each point In newVerts
                point.rotate(attach_rot.X, Point3D.ACHSE_X)
            Next
        End If
        If Not attach_rot.Y = 0 Then
            For Each point In newVerts
                point.rotate(attach_rot.Y, Point3D.ACHSE_Y)
            Next
        End If
        If Not attach_rot.Z = 0 Then
            For Each point In newVerts
                point.rotate(attach_rot.Z, Point3D.ACHSE_Z)
            Next
        End If


        Dim newVerts2 As New List(Of Double)
        For i As Integer = 0 To newVerts.Count - 1
            newVerts(i).move(New Point3D(attach_pnt.X, attach_pnt.Y, attach_pnt.Z))
            newVerts2.AddRange(newVerts(i).toList)
        Next
        vertices = newVerts2.ToArray
    End Sub
End Class
