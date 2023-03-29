'by Felix Modellbusse ;) (MoBu) 2019
Imports System.Text

Public Class Proj_Ovh
    Public Const TYPE = Frm_Main.PROJ_TYPE_OVH
    Public Const EXTENSION As String = "ovh"

    Public isloaded As Boolean
    Public filename As Filename
    Public changed As Boolean = True '#####  Wieder raus nehmen!  ######

    Public hersteller As String
    Public typ As String
    Public anstrich As String

    Public beschreibung As New List(Of String)
    Public number_path As String
    Public reg_list As String
    Public reg_auto_pre As String
    Public reg_auto_post As String
    Public reg_free As Boolean
    Public aiVehicleType As Byte = AI_TYPE.NOT_SELECTED

    Public baujahr As Integer
    Public laufleistung As String

    Public sound_file As Filename
    Public sound_ai_file As Filename
    Public model As OMSI_Model
    Public paths As OMSI_Paths
    Public cabin As OMSI_Cabin

    Public varlists As New List(Of String)
    Public stringvarlists As New List(Of String)
    Public scripts As New List(Of String)
    Public constfiles As New List(Of String)

    Public driver_cam_list As New List(Of Kamera)
    Public pax_cam_list As New List(Of Kamera)
    Public cam_std As Byte
    Public cam_outeside As New Point3D
    Public spiegel As New List(Of Reflex_Kamera)
    Public ticketblöcke As New List(Of OMSI_Attachment)

    Public fixed As Boolean
    Public masse As Single
    Public trägheit As New Point3D
    Public bbox As BoundingBox
    Public cog As New Point3D
    Public schwerpunkt As Single
    Public rollwiederstand As Integer
    Public drehpunkt As Single
    Public lenkradius As Single
    Public aiheight As Single

    Public controlCables As New List(Of OMSI_ControlCabels)

    Public achsen As New List(Of OMSI_Achse)
    Public boogie As New List(Of OMSI_Boogie)
    Public contactShoes As New List(Of OMSI_ContactShoe)
    Public sinus As OMSI_Sinus
    Public body_osc As OMSI_Body_osc

    Public couple_back As Boolean
    Public couple_back_point As Point3D
    Public couple_back_file As Filename
    Public couple_back_dir As Boolean

    Public couple_front As Boolean
    Public couple_front_point As Point3D
    Public couple_front_sound As Boolean
    Public couple_front_char As Point3D
    Public couple_front_type As Boolean



    Public ProjDataBase As DataBase

    Public Structure AI_TYPE
        Const CAR As Byte = 0
        Const TAXI As Byte = 1
        Const BUS As Byte = 2
        Const TRUCK As Byte = 3
        Const NOT_SELECTED As Byte = 255
    End Structure

    Public Structure COUPLE_TYPE
        Const LKW As Boolean = False
        Const BUS As Boolean = True
    End Structure

    Public Sub New(filepath As String)
        filename = New Filename(filepath)
        If My.Computer.FileSystem.FileExists(filename.path & "\" & filename.name) Then
            Dim allLines As String() = System.IO.File.ReadAllLines(filename, Encoding.GetEncoding(1252))

            '#### Hier weiter! ####

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
