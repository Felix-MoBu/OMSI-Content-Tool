'by Felix Modellbusse ;) (MoBu) 2019
Imports System.Drawing.Imaging
Imports System.Drawing.Imaging.PixelFormat


Module DDS_Tool
    Public Function readDDS(DDSfile As String) As Bitmap
        If DDSfile = "" Then
            Log.Add("DDS-Datei ohne Namen kann nicht geladen werden", Log.TYPE_WARNUNG)
            Return Nothing
        End If

        If Not System.IO.File.Exists(DDSfile) Then
            Log.Add("DDS-Datei existiert nicht (Datei: " & DDSfile & ")", Log.TYPE_WARNUNG)
            Return Nothing
        Else

        End If

        Return Nothing
    End Function
End Module
