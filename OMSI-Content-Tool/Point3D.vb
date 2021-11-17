Option Strict On

Imports OpenTK

Public Class Point3D
    Public X As Double
    Public Y As Double
    Public Z As Double

    Public Tag As Object

    Public Const ACHSE_X As Byte = 0
    Public Const ACHSE_Y As Byte = 1
    Public Const ACHSE_Z As Byte = 2

    Public Sub New()
        Me.X = 0
        Me.Y = 0
        Me.Z = 0
    End Sub

    Public Sub New(pnt As Point3D)
        Me.X = pnt.X
        Me.Y = pnt.Y
        Me.Z = pnt.Z
    End Sub

    Public Sub New(X As Double, Y As Double, Z As Double)
        Me.X = X
        Me.Y = Y
        Me.Z = Z
    End Sub

    Public Sub New(Pnt As Point3D, scale As Double)
        Me.X = Pnt.X * scale
        Me.Y = Pnt.Y * scale
        Me.Z = Pnt.Z * scale
    End Sub

    Public Shared Operator <>(ByVal obj1 As Point3D, ByVal obj2 As Point3D) As Boolean
        If obj1.X <> obj2.X Then Return True
        If obj1.Y <> obj2.Y Then Return True
        If obj1.Z <> obj2.Z Then Return True
        Return False
    End Operator

    Public Shared Operator =(ByVal obj1 As Point3D, ByVal obj2 As Point3D) As Boolean
        If obj1.X <> obj2.X Then Return False
        If obj1.Y <> obj2.Y Then Return False
        If obj1.Z <> obj2.Z Then Return False
        Return True
    End Operator

    Public Shared Operator <>(ByVal obj1 As Point3D, ByVal obj2 As Vector3) As Boolean
        If obj1.X <> obj2.X Then Return True
        If obj1.Y <> obj2.Y Then Return True
        If obj1.Z <> obj2.Z Then Return True
        Return False
    End Operator

    Public Shared Operator =(ByVal obj1 As Point3D, ByVal obj2 As Vector3) As Boolean
        If obj1.X <> obj2.X Then Return False
        If obj1.Y <> obj2.Y Then Return False
        If obj1.Z <> obj2.Z Then Return False
        Return True
    End Operator

    Public Function toVector3() As Vector3
        Return New Vector3(Convert.ToSingle(X), Convert.ToSingle(-Z), Convert.ToSingle(-Y))
    End Function

    Public Function toVector3new() As Vector3
        Return New Vector3(Convert.ToSingle(X), Convert.ToSingle(Y), Convert.ToSingle(Z))
    End Function


    Public Function fromList(index As Integer) As Double
        Select Case index
            Case 0
                Return Me.X
            Case 1
                Return Me.Y
            Case 2
                Return Me.Z
            Case Else
                Log.Add("Programmfehler Point3D.fromList", Log.TYPE_ERROR)
                MsgBox("Programmfehler Point3D.fromList")
                Return Double.NaN
        End Select
    End Function

    Public Function toList() As List(Of Double)
        toList = New List(Of Double)
        toList.Add(Me.X)
        toList.Add(Me.Y)
        toList.Add(Me.Z)
    End Function

    Public Sub rotate(rad As Double, achse As Byte)
        Dim origPos As New Point3D(Me)
        Select Case achse
            Case ACHSE_X
                Me.Y = Math.Cos(rad / 180 * Math.PI) * origPos.Y + Math.Sin(-rad / 180 * Math.PI) * origPos.Z
                Me.Z = Math.Sin(rad / 180 * Math.PI) * origPos.Y + Math.Cos(-rad / 180 * Math.PI) * origPos.Z
            Case ACHSE_Y
                Me.X = Math.Cos(rad / 180 * Math.PI) * origPos.Z + Math.Sin(-rad / 180 * Math.PI) * origPos.X
                Me.Z = Math.Sin(rad / 180 * Math.PI) * origPos.Z + Math.Cos(-rad / 180 * Math.PI) * origPos.X
            Case ACHSE_Z
                Me.X = Math.Cos(rad / 180 * Math.PI) * origPos.X + Math.Sin(-rad / 180 * Math.PI) * origPos.Y
                Me.Y = Math.Sin(rad / 180 * Math.PI) * origPos.X + Math.Cos(-rad / 180 * Math.PI) * origPos.Y
            Case Else
                Log.Add("Programmfehler: ungültige Achse bei Point3D.rotate ", Log.TYPE_DEBUG)
        End Select
    End Sub

    Public Sub rotate(rad As Double, achse As Byte, pnt As Point3D)
        Me.X -= pnt.X
        Me.Y -= pnt.Y
        Me.Z -= pnt.Z
        rotate(rad, achse)
        Me.X += pnt.X
        Me.Y += pnt.Y
        Me.Z += pnt.Z
    End Sub

    Public Sub move(dist As Double, achse As Byte)
        Select Case achse
            Case ACHSE_X
                Me.X += dist
            Case ACHSE_Y
                Me.Y += dist
            Case ACHSE_Z
                Me.Z += dist
            Case Else
                Log.Add("Programmfehler: ungültige Achse bei Point3D.move ", Log.TYPE_DEBUG)
        End Select
    End Sub

    Public Sub move(pnt As Point3D, Optional invert As Boolean = False)
        If Not invert Then
            Me.X += pnt.X
            Me.Y += pnt.Y
            Me.Z += pnt.Z
        Else
            Me.X -= pnt.X
            Me.Y -= pnt.Y
            Me.Z -= pnt.Z
        End If
    End Sub

    Public Function getWithInvertAchse(achse As Byte) As Point3D
        Select Case achse
            Case ACHSE_X
                Return New Point3D(-Me.X, Me.Y, Me.Z)
            Case ACHSE_Y
                Return New Point3D(Me.X, -Me.Y, Me.Z)
            Case ACHSE_Z
                Return New Point3D(Me.X, Me.Y, -Me.Z)
            Case Else
                Log.Add("Programmfehler: ungültige Achse bei Point3D.invertAchse ", Log.TYPE_DEBUG)
        End Select
        Return Me
    End Function

    Public Function dist(pnt As Point3D) As Double
        dist = Math.Abs(Math.Sqrt((Me.X - pnt.X) ^ 2 + (Me.Y - pnt.Y) ^ 2 + (Me.Z - pnt.Z) ^ 2))
    End Function

    Public Function dist(vector As Double) As Double
        dist = Math.Abs(Math.Sqrt((Me.X - vector) ^ 2 + (Me.Y - vector) ^ 2 + (Me.Z - vector) ^ 2))
    End Function

    Public Sub clear()
        X = 0
        Y = 0
        Z = 0
    End Sub
End Class
