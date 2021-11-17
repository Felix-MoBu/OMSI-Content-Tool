Imports System.Drawing.Imaging
Imports System.Drawing.Imaging.PixelFormat


Module DDS_Tool
    Public Function readDDS(DDSfile As String) As Bitmap
        If DDSfile = "" Then
            Log.Add("DDS-Datei ohne Namen kann nicht geladen werden", Log.TYPE_WARNUNG)
            Return Nothing
        End If

        If Not My.Computer.FileSystem.FileExists(DDSfile) Then
            Log.Add("DDS-Datei existiert nicht (Datei: " & DDSfile & ")", Log.TYPE_WARNUNG)
            Return Nothing
        End If

        Return Nothing
    End Function
End Module
