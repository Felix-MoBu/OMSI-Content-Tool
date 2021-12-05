'by Felix Modellbusse ;) (MoBu) 2019
Namespace My
    ' Für MyApplication sind folgende Ereignisse verfügbar:
    ' Startup: Wird beim Starten der Anwendung noch vor dem Erstellen des Startformulars ausgelöst.
    ' Shutdown: Wird nach dem Schließen aller Anwendungsformulare ausgelöst.  Dieses Ereignis wird nicht ausgelöst, wenn die Anwendung mit einem Fehler beendet wird.
    ' UnhandledException: Wird bei einem Ausnahmefehler ausgelöst.
    ' StartupNextInstance: Wird beim Starten einer Einzelinstanzanwendung ausgelöst, wenn die Anwendung bereits aktiv ist. 
    ' NetworkAvailabilityChanged: Wird beim Herstellen oder Trennen der Netzwerkverbindung ausgelöst.
    Partial Friend Class MyApplication
        Private Sub Application_Startup(ByVal sender As Object, ByVal e As ApplicationServices.StartupEventArgs) Handles Me.Startup
            For i = 0 To e.CommandLine.ToArray.Count - 1
                MsgBox(e.CommandLine.ToArray(i) & "  " & i)
            Next


            Frm_Main.Show()
            If e.CommandLine.ToArray.Count > 1 Then
                MsgBox("A")
                Frm_Main.fileimport2(New Filename(e.CommandLine.ToArray(1)))
                Exit Sub
            End If
            If e.CommandLine.ToArray.Count = 1 Then
                MsgBox(e.CommandLine.ToArray(0))
                If My.Computer.FileSystem.FileExists(e.CommandLine.ToArray(0)) Then
                    Frm_Main.fileimport2(New Filename(e.CommandLine.ToArray(0)))
                Else
                    O3D_Test.Log.Add("Die angegebene Datei konnte nicht gefunden werden! (Datei: " & e.CommandLine.ToArray(0) & ")", O3D_Test.Log.TYPE_ERROR)
                    MsgBox("Die angegebene Datei wurde nicht gefunden!")
                End If
            Else
                'Frm_Main.fileimport2("C:\Users\model\Desktop\O3D_DX\Export_test.x3d")
            End If
        End Sub
    End Class
End Namespace
