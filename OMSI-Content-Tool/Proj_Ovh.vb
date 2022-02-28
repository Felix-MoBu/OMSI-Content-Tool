'by Felix Modellbusse ;) (MoBu) 2019
Imports System.Text

Public Class Proj_Ovh
    Public Const TYPE = Frm_Main.PROJ_TYPE_OVH
    Public Const EXTENSION As String = "ovh"

    Public isloaded As Boolean
    Public filename As Filename
    Public changed As Boolean = True '#####  Wieder raus nehmen!  ######

    Public model As OMSI_Model

    Public varlists As New List(Of String)
    Public stringvarlists As New List(Of String)
    Public scripts As New List(Of String)
    Public constfiles As New List(Of String)

    Public ProjDataBase As DataBase

    'Public controlCables As New List(Of OMSI_ControlCabels)

    'hier weiter!

    '"[control_cable_front]" / "[control_cable_back]"
    'L / C / R -> links, center, rechts
    '0 -> Index von 0 an
    'Lesevariable (String)
    'Schreibvariable (String)
    'Kupplungsvar damit es läuft (String)

    Public Sub New(filepath As String)
        filename = New Filename(filepath)
        If My.Computer.FileSystem.FileExists(filename.path & "\" & filename.name) Then
            Dim allLines As String() = Split(Replace(My.Computer.FileSystem.ReadAllText(filename, Encoding.GetEncoding(1252)), vbCr, ""), vbLf)

        End If
    End Sub


    Public Sub save()
        If Not changed Then Exit Sub

        MsgBox("Fahrzeuge können derzeit noch nicht gespeichert werden")
    End Sub

    Public Function usedFiles() As List(Of Filename)
        usedFiles = New List(Of Filename)
        With usedFiles
            .Add(filename)
            .AddRange(model.usedFiles)

        End With
        Return usedFiles
    End Function
End Class
