'by Felix Modellbusse ;) (MoBu) 2019
Public Class OMSI_Mesh
    Public index As Integer = 0
    Public isProtected As Boolean = True
    Public o3dVersion As Integer

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
    Public mouseEvent As String
    Public animations As New List(Of OMSI_Anim)
    Public bones As New List(Of OMSI_Bone)
    Public smoothSkin As Boolean

    Public meshIdent As String
    Public animParent As String

    Public texChanges As String
    Public isShadow As Boolean

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

            For Each bone In bones
                .Add("[setbone]")
                .Add(bone.var)
                .Add(bone.val & vbCrLf)
            Next


            If isshadow Then .Add("[isshadow]" & vbCrLf)


            For Each matl In materials
                .Add("++++++++++")
                If matl.matlChange Is Nothing Then
                    .Add("[matl]")
                    .Add(matl.name)
                    .Add(matl.index & vbCrLf)
                Else
                    .Add("[matl_change]")
                    .Add(matl.name)
                    .Add(matl.index)
                    .Add(matl.matlChange.var & vbCrLf)
                End If

                .AddRange(getMatlProps(matl))


                If matl.zWrite Then .Add("[matl_noZwrite]" & vbCrLf)

                If matl.zCheck Then .Add("[matl_noZcheck]" & vbCrLf)

                If matl.texTex Then
                    .Add("[useTextTexture]")
                    .Add(matl.texTexVal & vbCrLf)
                End If

                If Not matl.matlChange Is Nothing Then
                    For Each item In matl.matlChange.items
                        .Add("[matl_item]" & vbCrLf)
                        .AddRange(getMatlProps(item))
                    Next
                End If
            Next

            For Each anim In animations
                If anim.anim_var <> "" Then
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

                If Not anim.delay = 0 Then
                    .Add("delay")
                    .Add(fromSingle(anim.delay))
                End If

                If Not anim.maxspeed = 0 Then
                    .Add("maxspeed")
                    .Add(fromSingle(anim.maxspeed))
                End If
                .Add(vbCrLf)
            Next
        End With
    End Function

    Function getMatlProps(matl As OMSI_Matl) As List(Of String)
        getMatlProps = New List(Of String)
        With getMatlProps
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
                .Add("[texcoordtransY]")
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

            If matl.nightmap_name <> "" Then
                .Add("[matl_nightmap]")
                .Add(matl.nightmap_name & vbCrLf)
            End If

            For Each lightmap In matl.lightmap
                .Add("[matl_lightmap]")
                .Add(lightmap.name)
                .Add(lightmap.var & vbCrLf)
            Next

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
        End With

        Return getMatlProps
    End Function
End Class
