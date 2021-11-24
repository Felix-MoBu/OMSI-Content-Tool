'by Felix Modellbusse ;) (MoBu) 2019
Public Class Frm_Hof
    Dim files() As String

    Private Sub Frm_Hof_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Location = New Point(Frm_Main.Width / 2 - Me.Width / 2, Frm_Main.Height / 2 - Me.Height / 2)

        If Not Frm_Main.getProj.filename Is Nothing Then
            If Not Frm_Main.getProj.filename.path = "" Then
                einlesen()
            End If
        End If
    End Sub

    Private Sub einlesen()
        files = IO.Directory.GetFiles(Frm_Main.getProj.filename.path, "*.hof", IO.SearchOption.TopDirectoryOnly)

        LBHofdateien.Items.Clear()
        For Each file In files
            LBHofdateien.Items.Add(file.Split("\").Last)
        Next
    End Sub

    Private Sub BTEntfernen_Click(sender As Object, e As EventArgs) Handles BTEntfernen.Click
        Dim x = MsgBox("Sicher, dass die Datei unwiderruflich gelöscht werden soll?", vbYesNo)
        If x = vbYes Then
            My.Computer.FileSystem.DeleteFile(files(LBHofdateien.SelectedIndex))
            einlesen()
        End If
    End Sub

    Private Sub LBHofdateien_DoubleClick(sender As Object, e As EventArgs) Handles LBHofdateien.DoubleClick
        Try
            Process.Start(files(LBHofdateien.SelectedIndex))
        Catch ex As Exception
            Shell("notepad.exe " + files(LBHofdateien.SelectedIndex))
        End Try
    End Sub

    Private Sub BTImport_Click(sender As Object, e As EventArgs) Handles BTImport.Click
        Dim fd As New OpenFileDialog
        With fd
            .Title = "Hof-Datei Auswählen..."
            .Filter = "Hof-Datei (*.hof)|*.hof"
            .InitialDirectory = My.Settings.OpenPath
            If .ShowDialog() Then
                If .FileName <> "" Then
                    Dim newFile = New Filename(.FileName.Split("\").Last, Frm_Main.getProj.filename.path)
                    My.Computer.FileSystem.CopyFile(.FileName, newFile)
                    Log.Add("Hofdatei importiert! (Datei: " & newFile.name & ")")

                    einlesen()
                End If
            End If
        End With
    End Sub
End Class