'by Felix Modellbusse ;) (MoBu) 2019
Public Class Proj_Emt
    Public Const TYPE = Frm_Main.PROJ_TYPE_EMT

    Public filename As New Filename
    Public isloaded As Boolean
    Public changed As Boolean = True '#####  Wieder raus nehmen!  ######

    Public model As OMSI_Model
    Public paths As OMSI_Paths
    Public cabin As OMSI_Cabin

    Public Sub save()
        If Not changed Then Exit Sub
        MsgBox("Die Änderungen wurden nicht gespeichert! Bitte zunächst ein Projekt erstellen oder die Dateien einzeln exportieren.")
        Log.Add("Leeres Projekt darf nicht gespeichert werden!", Log.TYPE_DEBUG)
    End Sub
End Class
