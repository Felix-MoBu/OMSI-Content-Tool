﻿'by Felix Modellbusse ;) (MoBu) 2019
Public Class Proj_Emt
    Public Const TYPE = 0

    Public filename As New Filename(False)
    Public isloaded As Boolean
    Public changed As Boolean = True '#####  Wieder raus nehmen!  ######

    Public model As New OMSI_Model
    Public paths As OMSI_Paths
    Public cabin As OMSI_Cabin

    Public ProjDataBase As DataBase

    Public Sub save()
        If Not changed Then Exit Sub
        MsgBox("Die Änderungen wurden nicht gespeichert! Bitte zunächst ein Projekt erstellen oder die Dateien einzeln exportieren.")
        Log.Add("Leeres Projekt darf nicht gespeichert werden!", Log.TYPE_DEBUG)
    End Sub

    Public Function usedFiles() As List(Of Filename)
        usedFiles = New List(Of Filename)
        With usedFiles

        End With
        Return usedFiles
    End Function
End Class
