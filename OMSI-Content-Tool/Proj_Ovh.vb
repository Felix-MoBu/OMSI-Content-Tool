'by Felix Modellbusse ;) (MoBu) 2019
Public Class Proj_Ovh
    Public Const TYPE = Frm_Main.PROJ_TYPE_OVH
    Public Const EXTENSION As String = "ovh"

    Public isloaded As Boolean
    Public filename As Filename
    Public changed As Boolean = True '#####  Wieder raus nehmen!  ######

    Public varlists As New List(Of String)
    Public stringvarlists As New List(Of String)
    Public scripts As New List(Of String)
    Public constfiles As New List(Of String)

    'Public controlCables As New List(Of OMSI_ControlCabels)

    'hier weiter!





    '"[control_cable_front]" / "[control_cable_back]"
    'L / C / R -> links, center, rechts
    '0 -> Index von 0 an
    'Lesevariable (String)
    'Schreibvariable (String)
    'Kupplungsvar damit es läuft (String)




    Public Sub save()
        If Not changed Then Exit Sub

        MsgBox("Fahrzeuge können derzeit noch nicht gespeichert werden")
    End Sub
End Class
