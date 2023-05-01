'by Felix Modellbusse ;) (MoBu) 2019
Imports System.Text

Public Class DataBase
    Public loaded As Boolean = False
    Public filename As Filename
    Public version As Single
    Public proj_version As Single
    Public contentID As Integer
    Public creatorID As Integer

    Public selectedRepaint As OMSI_Repaint
    Public AlleVariablen As New List(Of String)
    Public AlleVarValues As New List(Of Double)
    Public lastVars As New List(Of String)
    Public todoList As New List(Of String)
    Public todoReadyList As New List(Of String)

    Public storedPoints As List(Of Point3D) = New List(Of Point3D)
    Public storedPointNames As List(Of String) = New List(Of String) 

    Public Const FILETYPE As String = "ocdb"
    Dim POINTDELIMITERS As Char() = {";"}

    Public Sub New(name As Filename)
        filename = New Filename(name.path & "\" & name.nameNoEnding & "." & FILETYPE)
        If Not IO.File.Exists(filename) Then
            Log.Add("Es wurde keine Projektdatenbank geladen!")
            Log.Add("Datei: " & filename, Log.TYPE_DEBUG)
            Exit Sub
        End If


        Log.Add("Projektdatenbank laden...")

        Dim allLines As String() = System.IO.File.ReadAllLines(filename, Encoding.GetEncoding(1252))

        For linect = 0 To allLines.Count - 1
            If Trim(allLines(linect)) <> "" Then
                Select Case allLines(linect)
                    Case "[version]"
                        version = toSingle(allLines(linect + 1))
                    Case "[proj_version]"
                        proj_version = toSingle(allLines(linect + 1))
                    Case "[creator_id]"
                        creatorID = allLines(linect + 1)
                    Case "[content_id]"
                        contentID = allLines(linect + 1)
                    Case "[repaint]"
                        selectedRepaint = New OMSI_Repaint
                        selectedRepaint.ctifile = allLines(linect + 1)
                        selectedRepaint.name = allLines(linect + 2)
                        linect += 2
                    Case "[setvar]"
                        AlleVariablen.Add(allLines(linect + 1))
                        AlleVarValues.Add(toSingle(allLines(linect + 2)))
                        linect += 2
                    Case "[lastvars]"
                        For i = linect + 2 To linect + 2 + CInt(allLines(linect + 1)) - 1
                            lastVars.Add(allLines(i))
                        Next
                        linect += 2 + CInt(allLines(linect + 1))
                    Case "[todo]"
                        For i = linect + 2 To linect + 2 + CInt(allLines(linect + 1)) - 1
                            todoList.Add(allLines(i))
                        Next
                        linect += 2 + CInt(allLines(linect + 1))
                    Case "[todo_ready]"
                        For i = linect + 2 To linect + 2 + CInt(allLines(linect + 1)) - 1
                            todoReadyList.Add(allLines(i))
                        Next
                        linect += 2 + CInt(allLines(linect + 1))
                    Case "[storedPoints]"
                        For i = linect + 2 To linect + 2 + CInt(allLines(linect + 1)) - 1
                            Dim values As String() = allLines(i).Split(POINTDELIMITERS, 4)
                            If values.Length > 3 Then
                                storedPoints.Add(New Point3D(values(0), values(1), values(2)))
                                storedPointNames.Add(values(3))
                            End If
                        Next
                End Select
            End If
        Next
        loaded = True
        Log.Add("Projektdatenbank """ & filename.name & """ fertig geladen.")
    End Sub

    Private Sub grabInfos()

        selectedRepaint = Frm_Main.selectedRepaint

        AlleVariablen = New List(Of String)
        AlleVarValues = New List(Of Double)
        For Each item In Frm_VarTest.getUsedVars
            AlleVariablen.Add(item.var)
            AlleVarValues.Add(item.val)
        Next


    End Sub


    Public Sub Save(Optional noInfoGrabbing As Boolean = False)
        If Not noInfoGrabbing Then grabInfos()

        If Not filename Is Nothing Then
            Dim newFile As New FileWriter(filename)
            With newFile
                If version <> 0 Then
                    .Add("[version]")
                    .Add(version, True)
                End If

                If proj_version <> 0 Then
                    .Add("[proj_version]")
                    .Add(proj_version, True)
                End If

                If creatorID <> 0 Then
                    .Add("[creator_id]")
                    .Add(creatorID, True)
                End If

                If contentID <> 0 Then
                    .Add("[content_id]")
                    .Add(contentID, True)
                End If

                If Not selectedRepaint Is Nothing Then
                    .Add("[repaint]")
                    .Add(selectedRepaint.ctifile)
                    .Add(selectedRepaint.name, True)
                End If

                For varct As Integer = 0 To AlleVariablen.Count - 1
                    .Add("[setvar]")
                    .Add(AlleVariablen(varct))
                    .Add(AlleVarValues(varct), True)
                Next

                If lastVars.Count > 0 Then
                    .Add("[lastvars]")
                    .Add(todoList.Count)
                    For lastVarsct As Integer = 0 To lastVars.Count - 1
                        .Add(lastVars(lastVarsct))
                    Next
                    .Add(vbCrLf)
                End If

                If todoList.Count > 0 Then
                    .Add("[todo]")
                    .Add(todoList.Count)
                    For todoct As Integer = 0 To todoList.Count - 1
                        .Add(todoList(todoct))
                    Next
                    .Add(vbCrLf)
                End If

                If todoReadyList.Count > 0 Then
                    .AddTag("todo_ready", todoReadyList.Count)
                    For todoct As Integer = 0 To todoReadyList.Count - 1
                        .Add(todoReadyList(todoct))
                    Next
                    .Add(vbCrLf)
                End If

                If storedPoints.Count > 0 Then
                    .AddTag("storedPoints", storedPoints.Count)
                    For i = 0 To storedPoints.Count - 1
                        Dim PointName As String = ""
                        If storedPointNames.Count > i Then
                            PointName = storedPointNames(i)
                        End If
                        .Add(storedPoints(i).asString(";") & ";" & PointName)
                    Next
                End If
            End With

            If newFile.Lenght > 2 Then
                Dim linesCount As Integer
                linesCount = newFile.Write()

                Log.Add("Projektdatenbank gespeichert! (Datei: " & filename.name & ", Zeilen: " & linesCount & ")")
            Else
                If IO.File.Exists(filename) Then
                    IO.File.Delete(filename)
                    Log.Add("Keine Projektdatenbank erstellt da keine Werte zum Speichern vorhanden sind. (Alte Datei gelöscht!)")
                Else
                    Log.Add("Keine Projektdatenbank erstellt da keine Werte zum Speichern vorhanden sind.")
                End If
            End If
        End If
    End Sub
End Class
