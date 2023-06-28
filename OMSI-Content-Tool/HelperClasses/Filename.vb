'by Felix Modellbusse ;) (MoBu) 2019
Public Class Filename
    ''' <summary>
    ''' Only path, beginning with the drive letter, without filename or extension
    ''' </summary>
    Public path As String
    ''' <summary>
    ''' Only name with extension but without path
    ''' </summary>
    Public name As String

    ''' <summary>
    ''' Only name without path or extension
    ''' </summary>
    Property nameNoEnding As String
        Get
            Dim tempname = Split(name, ".")
            Dim purename As String = ""
            For i = 0 To tempname.Count - 2
                purename &= tempname(i)
            Next
            Return purename
        End Get
        Set(value As String)
            If name.Contains(".") Then
                Dim tempname = Split(name, ".")
                tempname(tempname.Count - 2) = value
                name = Join(tempname, ".")
            Else
                name = value
            End If
        End Set
    End Property

    ''' <summary>
    ''' Only extension without seperating dot
    ''' </summary>
    Public Property extension As String
        Get
            Return Split(name, ".").Last
        End Get
        Set(value As String)
            name = nameNoEnding & "." & value
        End Set
    End Property


    Public Sub New(Optional logging As Boolean = True)
        If logging Then
            Log.Add("Leeren Dateinamen hinzugefügt!", Log.TYPE_DEBUG)
        End If
        Me.name = ""
        Me.path = ""
    End Sub

    Public Sub New(filename As Filename)
        Me.name = filename.name
        Me.path = filename.path
    End Sub

    Public Sub New(filename As Object)
        Try
            Me.name = filename.name
            Me.path = filename.path
        Catch ex As Exception
            Me.name = ""
            Me.path = ""
        End Try
    End Sub

    Public Sub New(filename As String, Optional projectpath As String = "")
        If projectpath <> "" Then
            If Not projectpath.Substring(projectpath.Length - 1) = "\" Then projectpath &= "\"
            If filename.Length > projectpath.Length Then
                If filename.Contains(projectpath) Then
                    Me.name = filename.Substring(projectpath.Length)
                Else
                    Me.name = filename
                End If
            Else
                Me.name = filename
            End If
            If projectpath.Substring(projectpath.Length - 1) = "\" Then projectpath = projectpath.Substring(0, projectpath.Length - 1)
            Me.path = projectpath
            If filename.Length + 1 > projectpath.Length Then
                Me.name = filename.Substring(projectpath.Length + 1)
            End If
        Else
                Dim tempPath = Split(filename, "\")
            Me.name = tempPath(tempPath.Count - 1)

            Dim tempPath2 As String() = Split(filename, "\")
            For i As Integer = 0 To tempPath.Count - 2
                If i > 0 Then path &= "\"
                Me.path = Me.path & tempPath2(i)
            Next i
        End If
    End Sub

    Public Shared Operator <>(ByVal obj1 As Filename, ByVal obj2 As Filename) As Boolean
        If obj1 Is Nothing Then Return True
        If obj2 Is Nothing Then Return True
        If obj1.ToString <> obj2.ToString Then Return True
        Return False
    End Operator

    Public Shared Operator =(ByVal obj1 As Filename, ByVal obj2 As Filename) As Boolean
        If obj1 Is Nothing Then Return False
        If obj2 Is Nothing Then Return False
        If obj1.ToString = obj2.ToString Then Return True
        Return False
    End Operator

    Public Shared Operator <>(ByVal obj1 As String, ByVal obj2 As Filename) As Boolean
        If obj1 Is Nothing Then Return True
        If obj2 Is Nothing Then Return True
        If obj1 <> obj2.ToString Then Return True
        Return False
    End Operator

    Public Shared Operator =(ByVal obj1 As String, ByVal obj2 As Filename) As Boolean
        If obj1 Is Nothing Then Return False
        If obj2 Is Nothing Then Return False
        If obj1 = obj2.ToString Then Return True
        Return False
    End Operator

    Public Shared Operator <>(ByVal obj1 As Filename, ByVal obj2 As String) As Boolean
        If obj1 Is Nothing Then Return True
        If obj2 Is Nothing Then Return True
        If obj1.ToString <> obj2 Then Return True
        Return False
    End Operator

    Public Shared Operator =(ByVal obj1 As Filename, ByVal obj2 As String) As Boolean
        If obj1 Is Nothing Then Return False
        If obj2 Is Nothing Then Return False
        If obj1.ToString = obj2 Then Return True
        Return False
    End Operator

    Public Shared Widening Operator CType(v As Filename) As String
        If v.path <> "" Then
            Return v.path & "\" & v.name
        Else
            Return v.name
        End If
    End Operator

    Public Shared Widening Operator CType(v As String) As Filename
        Dim newFilename As New Filename(v)
        Return newFilename
    End Operator

    Public Shared Operator &(ByVal obj1 As String, ByVal obj2 As Filename) As String
        Return obj1 & obj2.ToString()
    End Operator


    Public Overrides Function ToString() As String
        If Me.path <> "" Then
            Return Me.path & "\" & Me.name
        Else
            Return Me.name
        End If
    End Function
End Class
