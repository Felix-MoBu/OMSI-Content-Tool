'by Felix Modellbusse ;) (MoBu) 2019
Public Class OMSI_Anim
    Public var As String

    Private origin_trans_int As New Point3D
    Private origin_from_mesh_int As Boolean
    Private mesh_center_int As New Point3D

    Private origin_rot_x_int As Single
    Private origin_rot_y_int As Single
    Private origin_rot_z_int As Single

    Public anim_type As Boolean '0 = Rot, 1 = Trans
    Public anim_var As String
    Public anim_val As Double

    Public origin As String
    Public delay As Integer
    Public maxspeed As Integer


    Public vertices As Double()
    Public edges As Integer() = {0, 1}

    Public Const TYPE_ROTATION As Boolean = 0
    Public Const TYPE_TRANSFORM As Boolean = 1
    '...

    Public Property origin_trans() As Point3D
        Get
            Return origin_trans_int
        End Get
        Set(value As Point3D)
            origin_trans_int = value
            recalc()
        End Set
    End Property

    Public Property origin_rot_x As Single
        Get
            Return origin_rot_x_int
        End Get
        Set(value As Single)
            origin_rot_x_int = value
            recalc()
        End Set
    End Property

    Public Property origin_rot_y As Single
        Get
            Return origin_rot_y_int
        End Get
        Set(value As Single)
            origin_rot_y_int = value
            recalc()
        End Set
    End Property

    Public Property origin_rot_z As Single
        Get
            Return origin_rot_z_int
        End Get
        Set(value As Single)
            origin_rot_z_int = value
            recalc()
        End Set
    End Property

    Public Property origin_from_mesh As Boolean
        Get
            Return origin_from_mesh_int
        End Get
        Set(value As Boolean)
            origin_from_mesh_int = value
            recalc()
        End Set
    End Property

    Public Property mesh_center As Point3D
        Get
            Return mesh_center_int
        End Get
        Set(value As Point3D)
            mesh_center_int = value
            recalc()
        End Set
    End Property

    Public Sub New()
        recalc()
    End Sub

    Private Sub recalc()
        Dim verts As New List(Of Double)

        If origin_from_mesh_int Then
            verts.AddRange(PointToList(New Point3D(-mesh_center_int.X, mesh_center_int.Y, mesh_center_int.Z + 5), mesh_center_int.getWithInvertAchse(Point3D.ACHSE_X)))
            verts.AddRange(PointToList(New Point3D(-mesh_center_int.X, mesh_center_int.Y, mesh_center_int.Z - 5), mesh_center_int.getWithInvertAchse(Point3D.ACHSE_X)))
        Else
            verts.AddRange(PointToList(New Point3D(-origin_trans.X, origin_trans.Y, origin_trans.Z + 5), origin_trans.getWithInvertAchse(Point3D.ACHSE_X)))
            verts.AddRange(PointToList(New Point3D(-origin_trans.X, origin_trans.Y, origin_trans.Z - 5), origin_trans.getWithInvertAchse(Point3D.ACHSE_X)))
        End If

        'MsgBox(verts(0) & "; " & verts(1) & "; " & verts(2) & vbCrLf & verts(3) & "; " & verts(4) & "; " & verts(5))

        vertices = verts.ToArray
        edges = {0, 1}
    End Sub

    Private Function PointToList(tmpPnt As Point3D, origin As Point3D) As List(Of Double)
        PointToList = New List(Of Double)
        tmpPnt.rotate(origin_rot_x_int, Point3D.ACHSE_X, origin)
        tmpPnt.rotate(origin_rot_y_int, Point3D.ACHSE_Y, origin)
        tmpPnt.rotate(origin_rot_z_int, Point3D.ACHSE_Z, origin)

        PointToList.Add(tmpPnt.X)
        PointToList.Add(tmpPnt.Z)
        PointToList.Add(tmpPnt.Y)
    End Function
End Class
