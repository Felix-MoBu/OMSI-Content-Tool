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
            System.IO.File.Delete(files(LBHofdateien.SelectedIndex))
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
            .Multiselect = True
            If .ShowDialog() Then
                For Each FileName In .FileNames
                    If .FileName <> "" Then
                        copyNewHof(.FileName)
                    End If
                Next
            End If
        End With
    End Sub

    Public Sub copyNewHof(oldFile As String)
        Dim newFile = New Filename(oldFile.Split("\").Last, Frm_Main.getProj.filename.path)
        If Not System.IO.File.Exists(newFile) Then
            System.IO.File.Copy(oldFile, newFile)
            Log.Add("Hofdatei importiert! (Datei: " & newFile.name & ")")

            einlesen()
        End If
    End Sub

    Private Sub Frm_Hof_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        BTEntfernen.Top = Height - 70
        BTImport.Top = BTEntfernen.Top
        LBHofdateien.Height = BTEntfernen.Top - 18
    End Sub
End Class