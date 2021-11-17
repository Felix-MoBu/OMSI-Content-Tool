Public Class Arrow
    Private position_int As Point3D
    Private vector_int As Point3D
    Private direction_int As Boolean
    Public vertices As Double()
    Public edges As Integer() = {0, 1, 2}

    Public Property position As Point3D
        Get
            Return position_int
        End Get
        Set(value As Point3D)
            position_int = value
            recalc()
        End Set
    End Property

    Public Property vector As Point3D
        Get
            Return vector_int
        End Get
        Set(value As Point3D)
            vector_int = value
            recalc()
        End Set
    End Property

    Public Property direction As Boolean
        Get
            Return direction_int
        End Get
        Set(value As Boolean)
            direction_int = value
            recalc()
        End Set
    End Property

    Public Sub New(pos As Point3D, vec As Point3D, Optional dir As Boolean = False)
        position_int = pos
        vector_int = vec
        direction_int = dir
        recalc()
    End Sub

    Private Sub recalc()
        If position_int Is Nothing Then Exit Sub
        If vector_int Is Nothing Then Exit Sub

        Dim tempVertices As New List(Of Double)
        With tempVertices
            .Add(-position.X)
            .Add(position.Z)
            .Add(position.Y)



            Dim eVector As New Point3D()
            Dim laenge As Double = Math.Sqrt(((vector_int.X - position_int.X) ^ 2) + ((vector_int.Y - position_int.Y) ^ 2) + ((vector_int.Z - position_int.Z) ^ 2))
            eVector.X = (vector_int.X - position_int.X) / laenge / 10
            eVector.Y = (vector_int.Y - position_int.Y) / laenge / 10
            eVector.Z = (vector_int.Z - position_int.Z) / laenge / 10

            Dim temPnt As New Point3D(position_int)
            'temPnt.X = (eVector.X / Math.Sqrt((eVector.X ^ 2) + (eVector.Y ^ 2) + (eVector.Z ^ 2))) / 10
            'temPnt.Y = (eVector.Y / Math.Sqrt((eVector.X ^ 2) + (eVector.Y ^ 2) + (eVector.Z ^ 2))) / 10
            'temPnt.Z = (eVector.Z / Math.Sqrt((eVector.X ^ 2) + (eVector.Y ^ 2) + (eVector.Z ^ 2))) / 10

            temPnt.move(eVector, Not direction_int)
            Dim x As Double = (eVector.X * eVector.Y)
            'If (eVector.X * eVector.Y) < 0 Then
            If (temPnt.X - eVector.Y + temPnt.Y - eVector.X) > (temPnt.X + eVector.Y + temPnt.Y + eVector.X) And direction Then
                .Add(-(temPnt.X + eVector.Y))
                .Add(temPnt.Z)
                .Add(temPnt.Y + eVector.X)

                .Add(-(temPnt.X - eVector.Y))
                .Add(temPnt.Z)
                .Add(temPnt.Y - eVector.X)
            Else
                .Add(-(temPnt.X - eVector.Y))
                .Add(temPnt.Z)
                .Add(temPnt.Y - eVector.X)

                .Add(-(temPnt.X + eVector.Y))
                .Add(temPnt.Z)
                .Add(temPnt.Y + eVector.X)

            End If




        End With
        vertices = tempVertices.ToArray
    End Sub
End Class
