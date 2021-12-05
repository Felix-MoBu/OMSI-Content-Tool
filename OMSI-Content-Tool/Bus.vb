Public Class Bus
    Public filenname As String

    Public hersteller As String
    Public typ As String
    Public anstrich As String

    Public number_path As String
    Public reg_auto_pre As String
    Public reg_auto_post As String
    Public reg_file As String
    Public reg_free As Boolean

    Public baujahr As Integer
    Public laufleistung As String

    Public sound_file As String
    Public sound_ai_file As String
    Public model_file As String 'As modelFile
    Public path_file As String  'As pathFile
    Public cabin_file As String 'As cabinFile

    Public varlists As List(Of String)
    Public stringvarlists As List(Of String)
    Public scripts As List(Of String)
    Public constfiles As List(Of String)

    Public dirver_cam_list As List(Of Kamera)
    Public pax_cam_list As List(Of Kamera)
    Public cam_std As Byte
    Public outeside_cam As Point3D
    Public spiegel As List(Of Reflex_Kamera)
    Public spiegel_2 As List(Of Reflex_Kamera_2)

    'Ticketblock

    Public masse As Single
    Public trägheit As Point3D()
    Public bbox As List(Of Point3D)
    Public schwerpunkt As Single
    Public rollwiederstand As Integer
    Public drehpunkt As Integer
    Public lenkradius As Single
    Public aiheight As Single

    Public achsen As List(Of OMSI_Achse)
End Class
