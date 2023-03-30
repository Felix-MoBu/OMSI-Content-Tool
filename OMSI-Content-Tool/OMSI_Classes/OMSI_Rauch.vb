'by Felix Modellbusse ;) (MoBu) 2019
Public Class OMSI_Rauch
    Public name As String
    Public position As New Point3D
    Public richtung As New Point3D
    Public speed As String
    Public speedvar As String
    Public frequenz As String
    Public lebensdauer As String
    Public bremsfaktor As String
    Public fallkurve As String
    Public größe As String
    Public vergrößerung As String
    Public alphaInit As String
    Public alphavVar As String
    Public color As New RGBColor
    Public parent As String
End Class

'Erzeugt Partikelsystem Rauch, welches an vorherigem Mesh angeheftet ist

'	* x, y, z Position
'	* x, y, z Ausströmrichtung

'Ab hier können wahlweise Variablennamen (nur lokal!) oder Werte eingegeben werden:
'	* Geschwindigkeit beim Ausstoß
'	* Geschwindigkeitsvariation
'	* Frequenz
'	* Lebensdauer
'	* Bremsfaktor
'	* Fallkoeffizient
'	* Startgröße
'	* Vergrößerungsrate
'	* Initialalpha
'	* Alphavariation
'	* R,G,B