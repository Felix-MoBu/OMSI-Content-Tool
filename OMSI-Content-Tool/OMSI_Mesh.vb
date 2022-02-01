'by Felix Modellbusse ;) (MoBu) 2019
Public Class OMSI_Mesh
    Public index As Integer = 0
    Public isProtected As Boolean = True

    Public filename As Filename
    Public ObjIds As New List(Of Int16)
    Public position As New Point3D
    Private center_int As New Point3D   '-> Hat property
    Private origin_int As New Point3D   '-> Hat property

    Public viewpoint As Byte
    Public illumination As OMSI_Illumination
    Public lodMin As Single = 0
    Public lodMax As Single = 1

    Public materials As New List(Of OMSI_Matl)
    Public visibleVar As String
    Public visibleInt As Integer
    Public mouseevent As String
    Public animations As New List(Of OMSI_Anim)
    Public bones As New List(Of OMSI_Bone)
    Public smoothskin As Boolean

    Public meshident As String
    Public animparent As String

    Public texchanges As String
    Public isshadow As Boolean

    Public matl_change_file As String
    Public matl_change_index As Integer
    Public matl_change_var As String

    Public Property center As Point3D
        Get
            Return center_int
        End Get
        Set(value As Point3D)
            center_int = value
            For Each anim In animations
                anim.mesh_center = value
            Next
        End Set
    End Property

    Public Property origin As Point3D
        Get
            Return origin_int
        End Get
        Set(value As Point3D)
            origin_int = value
            For Each anim In animations
                anim.mesh_origin = origin_int
            Next
        End Set
    End Property

    Public Function getpropertys() As List(Of String)
        getpropertys = New List(Of String)
        With getpropertys
            .Add("---------------------------------" & vbCrLf)
            .Add("[mesh]")
            .Add(filename.name & vbCrLf)

            If Not viewpoint = 0 Then
                .Add("[viewpoint]")
                .Add(viewpoint & vbCrLf)
            End If

            If Not illumination Is Nothing Then
                .Add("[illumination_interior]")
                For Each value In illumination.values
                    .Add(value)
                Next
                .Add(vbCrLf)
            End If

            If mouseevent <> "" Then
                .Add("[mouseevent]")
                .Add(mouseevent & vbCrLf)
            End If

            If visibleVar <> "" Then
                .Add("[visible]")
                .Add(visibleVar)
                .Add(visibleInt & vbCrLf)
            End If

            If meshident <> "" Then
                .Add("[mesh_ident]")
                .Add(meshident & vbCrLf)
            End If

            If animparent <> "" Then
                .Add("[animparent]")
                .Add(animparent & vbCrLf)
            End If

            If smoothskin Then .Add("[smoothskin]" & vbCrLf)

            If bones.Count > 0 Then
                For Each bone In bones
                    .Add("[setbone]")
                    .Add(bone.var)
                    .Add(bone.val & vbCrLf)
                Next
            End If

            If matl_change_file <> "" Then
                .Add("[matl_change]")
                .Add(matl_change_file)
                .Add(matl_change_index)
                .Add(matl_change_var & vbCrLf)
            End If

            If isshadow Then .Add("[isshadow]" & vbCrLf)

            For Each matl In materials
                .Add("++++++++++")
                .Add("[matl]")
                .Add(matl.name)
                .Add(matl.index & vbCrLf)

                If matl.freetexFile <> "" Then
                    .Add("[matl_freetex]")
                    .Add(matl.freetexFile)
                    .Add(matl.freetexVar & vbCrLf)
                End If

                If matl.transX <> "" Then
                    .Add("[texcoordtransX]")
                    .Add(matl.transX & vbCrLf)
                End If

                If matl.transY <> "" Then
                    .Add("[texcoordtransX]")
                    .Add(matl.transY & vbCrLf)
                End If

                If matl.alpha > 0 Then
                    .Add("[matl_alpha]")
                    .Add(Convert.ToInt16(matl.alpha) & vbCrLf)
                End If

                If matl.alphascale <> "" Then
                    .Add("[alphascale]")
                    .Add(matl.alphascale & vbCrLf)
                End If

                If matl.env_map <> "" Then
                    .Add("[matl_envmap]")
                    .Add(matl.env_map)
                    .Add(fromSingle(matl.env_scalce) & vbCrLf)
                End If

                If matl.envmask <> "" Then
                    .Add("[matl_envmap_mask]")
                    .Add(matl.envmask & vbCrLf)
                End If

                If matl.lightmap_name <> "" Then
                    .Add("[matl_lightmap]")
                    .Add(matl.lightmap_name)
                    .Add(matl.lightmap_var & vbCrLf)
                End If

                If matl.bumpmap_file <> "" Then
                    .Add("[matl_bumpmap]")
                    .Add(matl.bumpmap_file)
                    .Add(fromSingle(matl.bumpmap_val) & vbCrLf)
                End If

                If Not matl.adressBorder Is Nothing Then
                    .Add("[matl_texadress_border]")
                    For Each value In matl.adressBorder
                        .Add(value)
                    Next
                    .Add(vbCrLf)
                End If

                If matl.transmap Then
                    .Add("[matl_transmap]")
                    .Add(matl.transmapVar & vbCrLf)
                End If

                If matl.zWrite Then .Add("[matl_noZwrite]" & vbCrLf)

                If matl.zCheck Then .Add("[matl_noZcheck]" & vbCrLf)

                If matl.texTex Then
                    .Add("[useTextTexture]")
                    .Add(matl.texTexVal & vbCrLf)
                End If
            Next

            For Each anim In animations
                .Add("[newanim]")
                If anim.origin_from_mesh Then
                    .Add("origin_from_mesh")
                Else
                    If anim.origin_trans.dist(New Point3D) <> 0 Then
                        .Add("origin_trans")
                        .Add(fromSingle(anim.origin_trans.X))
                        .Add(fromSingle(anim.origin_trans.Y))
                        .Add(fromSingle(anim.origin_trans.Z))
                    End If
                End If

                If Not anim.origin_rot.X = 0 Then
                    .Add("origin_rot_x")
                    .Add(fromSingle(anim.origin_rot.X))
                End If

                If Not anim.origin_rot.Y = 0 Then
                    .Add("origin_rot_y")
                    .Add(fromSingle(anim.origin_rot.Y))
                End If

                If Not anim.origin_rot.Z = 0 Then
                    .Add("origin_rot_z")
                    .Add(fromSingle(anim.origin_rot.Z))
                End If

                If anim.anim_type = OMSI_Anim.TYPE_ROTATION Then
                    .Add("anim_rot")
                    .Add(anim.anim_var)
                    .Add(fromSingle(anim.anim_val))
                Else
                    .Add("anim_trans")
                    .Add(anim.anim_var)
                    .Add(fromSingle(anim.anim_val))
                End If
                .Add(vbCrLf)
            Next
        End With
    End Function
End Class
