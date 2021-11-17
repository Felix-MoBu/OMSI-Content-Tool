Option Strict On

Imports System.IO
Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices

Module TGA_Tool
    ' Flag zum erkennen, ob es sich bei den TGA-Typen 9, 10 und 11
    ' in den Bilddaten um RAW- oder RLE-kodierte Daten handelt 
    Private Const RleFlag As Byte = &H80

    ' Vertikal- und Horizontalflag zum spiegeln des Bildes
    Private Const VFlag As Byte = &H10
    Private Const HFlag As Byte = &H20

    ' TGA-Header
    Private Structure TgaHeader
        ' Größe des Identblocks in Byte, der nach dem Header (18 Byte) folgt. 
        ' Normalerweise 0
        Dim IdentSize As Byte
        ' Palettentyp: 0 = Keine Palette vorhanden, 1 = Palette vorhanden
        Dim ColorMapType As Byte
        ' Bildtyp: 0 = none, 1 = Indexed, 2 = RGB, 3 = Grauskale, 
        ' 9 = Indexed (RLE), 10 = RGB (RLE), 11 = Grauskale (RLE)
        Dim ImageType As Byte
        ' erster Eintrag in der Farbtabelle
        Dim ColorMapStart As Short
        ' Anzahl der Farben in der Farbpalette
        Dim ColorMapLength As Short
        ' Bits Per Pixel der Farbtabelle 15, 16, 24, 32
        Dim ColorMapBits As Byte
        ' X-Position des Bildes in Pixel. Normalerweise 0
        Dim xStart As Short
        ' Y-Position des Bildes in Pixel. Normalerweise 0
        Dim yStart As Short
        Dim Width As Short          ' Breite des Bildes in Pixel
        Dim Height As Short         ' Höhe des Bildes in Pixel
        Dim Bits As Byte            ' Bits Per Pixel des Bildes 8, 16, 24, 32
        Dim Descriptor As Byte      ' Descriptor bits des Bildes
    End Structure

    ''' <summary>
    ''' Konvertiert eine Targadatei (TGA) in ein Bitmapobjekt
    ''' </summary>
    ''' <param name="TgaFile">Pfad zur Targadatei</param>
    ''' <returns>Bitmap-Objekt</returns>
    Public Function readTGA(ByVal TgaFile As String) As Bitmap

        ' !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        ' zur Zeit unterstützt diese Funktion folgende Targa-Formate:
        ' Imagetyp: 1, 2, 3, 9, 10, 11
        ' Bits: 8, 16, 24, 32
        ' ColorMapBits: 24, 32
        ' !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

        ' ist die Datei nicht vorhanden
        If Not File.Exists(TgaFile) Then
            Log.Add("TGA-Import Fehler! (Fehler: TGA001, Datei: """ & TgaFile & """) nicht gefunden!", Log.TYPE_WARNUNG)
            ' dann Nothing zurück geben
            Return Nothing
        Else

            ' ist die Dateierweiterung <> .TGA
            If Path.GetExtension(TgaFile).ToUpper <> ".TGA" Then
                Log.Add("TGA-Import Fehler! (Fehler: TGA002, Datei: """ & TgaFile & """) falscher Dateityp!", Log.TYPE_WARNUNG)
                ' dann Nothing zurück geben
                Return Nothing
            End If
        End If

        ' TGA-Header
        Dim tTgaHeader As New TgaHeader

        ' div. Variablen
        Dim X As Integer = 0
        Dim Y As Integer = 0
        Dim RleID As Integer = 0
        Dim PalIndex As Integer = 0
        Dim BmpWidth As Integer = 0
        Dim BmpHeight As Integer = 0
        Dim BmpStride As Integer = 0
        Dim TgaPixPos As Integer = 0
        Dim BmpPixPos As Integer = 0
        Dim BytePerPixel As Integer = 0
        Dim NoPadBytes As Boolean = False
        Dim TgaData As Byte() = Nothing
        Dim BmpData As Byte() = Nothing
        Dim TgaPal As Byte() = Nothing
        Dim BmpPal As ColorPalette = Nothing
        Dim BmpPixelFormat As New PixelFormat

        ' Variable für die zuerstellende Bitmap -> OutBmp
        Dim OutBmp As Bitmap = Nothing

        ' FileStream öffnen -> FS
        Using FS As New FileStream(TgaFile, FileMode.Open, FileAccess.Read)

            ' einen BinaryReader vom FileStream erstellen -> BR
            Dim BR As New BinaryReader(FS)

            ' Header aus der TGA auslesen
            tTgaHeader.IdentSize = BR.ReadByte
            tTgaHeader.ColorMapType = BR.ReadByte
            tTgaHeader.ImageType = BR.ReadByte
            tTgaHeader.ColorMapStart = BR.ReadInt16
            tTgaHeader.ColorMapLength = BR.ReadInt16
            tTgaHeader.ColorMapBits = BR.ReadByte
            tTgaHeader.xStart = BR.ReadInt16
            tTgaHeader.yStart = BR.ReadInt16
            tTgaHeader.Width = BR.ReadInt16
            tTgaHeader.Height = BR.ReadInt16
            tTgaHeader.Bits = BR.ReadByte
            tTgaHeader.Descriptor = BR.ReadByte

            ' Breite und Höhe des Bildes speichern
            BmpWidth = tTgaHeader.Width
            BmpHeight = tTgaHeader.Height

            ' ist die Breite des Bildes ohne Rest durch 4 teilbar
            ' oder ist es eine 32bpp-TGA
            If BmpWidth Mod 4 = 0 Or tTgaHeader.Bits = 32 Then

                ' dann gibt es keine PadBytes in der zu erstellenden Bitmap
                NoPadBytes = True
            End If

            ' nach TGA-ImageTyp selektieren
            Select Case tTgaHeader.ImageType
                Case 1, 2, 3, 9, 10, 11
                    '  1 = Unkomprimiert, Indexed
                    '  2 = Unkomprimiert, RGB
                    '  3 = Unkomprimiert, Grauskale
                    '  9 = RLE enkodiert, Indexed
                    ' 10 = RLE enkodiert, RGB
                    ' 11 = RLE enkodiert, Grauskale

                    ' nach Anzahl der Bits per Pixel selektieren
                    Select Case tTgaHeader.Bits
                        Case 8

                            ' Byte pro Pixel
                            BytePerPixel = 1

                            ' Breite einer Bildzeile inkl. PadBytes berechnen
                            ' für die zu erstellende Bitmap (OutBmp)
                            BmpStride = (BmpWidth + 3) And Not 3

                            ' Pixelformat für die zu erstellende Bitmap
                            ' (OutBmp) festlegen
                            BmpPixelFormat = PixelFormat.Format8bppIndexed
                        Case 16
                            BytePerPixel = 2
                            BmpStride = ((BmpWidth * 2) + 2) And Not 2
                            BmpPixelFormat = PixelFormat.Format16bppRgb555
                        Case 24
                            BytePerPixel = 3
                            BmpStride = ((BmpWidth * 3) + 3) And Not 3
                            BmpPixelFormat = PixelFormat.Format24bppRgb
                        Case 32
                            BytePerPixel = 4
                            BmpStride = BmpWidth * 4
                            BmpPixelFormat = PixelFormat.Format32bppArgb
                        Case Else

                            ' andere
                            BmpPixelFormat = PixelFormat.Undefined
                    End Select

                    ' wenn die zu erstellende Bitmap PadBytes hat, dann brauchen
                    ' wir BmpData zum späteren umkopieren von TgaData
                    If Not NoPadBytes Then

                        ' Größe des Arrays BmpData zur Aufnahme der Bilddaten
                        ' für die zu erstellende Bitmap (OutBmp) berechnen
                        ' und dimensionieren wenn PadBytes vorhanden sind
                        BmpData = New Byte((BmpHeight * BmpStride) - 1) {}

                    End If

                    ' Größe des Arrays TgaData zur Aufnahme der Bilddaten
                    ' aus der TGA berechnen und dimensionieren
                    TgaData = New Byte((BmpHeight *
                        (BmpWidth * BytePerPixel)) - 1) {}
                Case Else

                    ' andere
            End Select

            ' Ist tTgaHeader.IdentSize > 0 dann folgt direkt nach dem Header
            ' ein Identblock in der Größe von tTgaHeader.IdentSize. Da wir
            ' diesen nicht benötigen, überspringen wir diesen Block.
            FS.Seek(tTgaHeader.IdentSize, SeekOrigin.Current)

            ' Direkt nach dem Header und/oder nach dem IdentBlock wenn 
            ' vorhanden, kommen die Palettendaten wenn vorhanden.

            ' enthält die TGA Palettendaten
            If tTgaHeader.ColorMapType = 1 Then

                ' nach Anzahl der Bits per Pixel selektieren
                Select Case tTgaHeader.ColorMapBits
                    Case 8

                        ' Größe des Arrays TgaPal zur Aufnahme der Palettendaten
                        ' berechnen und dimensionieren
                        TgaPal =
                            New Byte((tTgaHeader.ColorMapLength * 1) - 1) {}
                    Case 16
                        TgaPal =
                            New Byte((tTgaHeader.ColorMapLength * 2) - 1) {}
                    Case 24
                        TgaPal =
                            New Byte((tTgaHeader.ColorMapLength * 3) - 1) {}
                    Case 32
                        TgaPal =
                            New Byte((tTgaHeader.ColorMapLength * 4) - 1) {}
                    Case Else

                        'andere
                End Select

                'Palettendaten aus der TGA auslesen
                TgaPal = BR.ReadBytes(TgaPal.Length)

            End If

            ' Direkt nach dem Header und/oder nach dem IdentBlock wenn vorhanden
            ' und/oder nach den Palettendaten wenn vorhanden, kommen die die
            ' eigentlichen Bilddaten der TGA

            ' nach TGA-ImageTyp selektieren
            Select Case tTgaHeader.ImageType

                Case 1, 2, 3 ' nur die unkomprimierten TGA-Typen

                    ' komplette Bilddaten aus der TGA auslesen
                    TgaData = BR.ReadBytes(TgaData.Length)

                Case 9, 10, 11 ' nur die komprimierten TGA-Typen (RAW/RLE)

                    ' Da wir durch die RLE-Komprimierung nicht wissen wieviel
                    ' Bytes an Bitmapdaten wir einlesen müssen, lesen wir 
                    ' solange die Daten ein bis TgaData.Length
                    ' (unkomprimierte Größe) erreicht ist.
                    For X = 0 To TgaData.Length - 1

                        'PacketHeader-Byte aus der TGA lesen
                        RleID = BR.ReadByte

                        ' ist das Bit 8 von RleID = 1 dann liegt das folgende
                        ' Datenpaket RLE-Komprimiert vor
                        If CBool(RleID And RleFlag) Then

                            ' In (RleID - RleFlag) steht die Anzahl der 
                            ' Wiederholungen - 1
                            RleID = (RleID - RleFlag) + 1

                            ' nach Anzahl der Bits per Pixel selektieren
                            Select Case tTgaHeader.Bits
                                Case 8, 16, 24, 32

                                    ' entsprechende Anzahl von Bytes aus der 
                                    ' TGA auslesen und direkt nach TgaData an 
                                    ' Offset X kopieren
                                    BR.ReadBytes(BytePerPixel).CopyTo(TgaData,
                                        X)

                                    ' nun kopieren wir die ausgelesenen Bytes 
                                    ' entsprechend der Wiederholungen 
                                    ' hintereinander
                                    For Y = 1 To RleID - 1
                                        Array.Copy(TgaData, X, TgaData,
                                            X + (Y * BytePerPixel),
                                            BytePerPixel)
                                    Next

                                    ' X = X + Offset
                                    X += (RleID * BytePerPixel) - 1

                                Case Else

                                    ' andere
                            End Select
                        Else
                            ' ist das Bit 8 von RleID = 0 dann liegt das 
                            ' folgende Datenpaket unkomprimiert vor (RAW).

                            ' RleID enthält die Anzahl der Pixel - 1.
                            RleID += 1

                            ' nach Anzahl der Bits per Pixel selektieren
                            Select Case tTgaHeader.Bits
                                Case 8, 16, 24, 32

                                    ' entsprechende Anzahl von Bytes aus der 
                                    ' TGA auslesen und direkt nach TgaData an 
                                    ' Offset X kopieren
                                    BR.ReadBytes(RleID * BytePerPixel).CopyTo(
                                        TgaData, X)

                                    ' X = X + Offset
                                    X += (RleID * BytePerPixel) - 1

                                Case Else

                                    'andere
                            End Select
                        End If
                    Next
                Case Else

                    'andere
            End Select

            BR.Close() 'BinaryReader schließen
            FS.Close() 'FileStream Schließen
        End Using

        ' Wurde kein entsprechendes Pixelformat festgelegt, dann haben wir es 
        ' hier mit einem nicht implementierten TGA-Format zu tun. Also können 
        ' wir auch aus dem Rest des Codes aussteigen.
        If BmpPixelFormat = PixelFormat.Undefined Then
            Log.Add("TGA Pixelformat Fehler (Fehler: TGA010, Datei: " & TgaFile & ")")
            ' dann Nothing zurück geben
            Return Nothing
        End If

        ' nun haben wir alle relevanten Daten zusammen um daraus eine Bitmap
        ' zu erstellen

        ' nach TGA-ImageTyp selektieren
        Select Case tTgaHeader.ImageType
            Case 1, 2, 3, 9, 10, 11

                ' wenn die zu erstellende Bitmap PadBytes hat, dann müssen
                ' wir die Bilddaten pixelweise umkopieren.
                If Not NoPadBytes Then

                    ' Da TGAs keine PadBytes haben aber Bitmaps schon, müssen
                    ' wir die Bilddaten aus dem Array TgaData (TGA-Bilddaten)
                    ' nach BmpData (BMP-Bilddaten) pixelweise umkopieren.
                    For Y = 0 To BmpHeight - 1
                        For X = 0 To BmpWidth - 1

                            ' nach Anzahl der Bits per Pixel selektieren
                            Select Case tTgaHeader.Bits
                                Case 8, 16, 24, 32

                                    ' Pixelposition für BmpData berechnen
                                    BmpPixPos = (Y * BmpStride) +
                                        (X * BytePerPixel)

                                    ' Pixelposition für TgaData berechnen
                                    TgaPixPos = (Y *
                                        (BmpWidth * BytePerPixel)) _
                                        + (X * BytePerPixel)

                                    ' Pixeldaten von TgaData nach BmpData 
                                    ' umkopieren
                                    Array.Copy(TgaData, TgaPixPos, BmpData,
                                        BmpPixPos, BytePerPixel)

                                Case Else

                                    'andere
                            End Select
                        Next
                    Next
                End If

                Dim hBmpData As New GCHandle

                ' wenn keine PadBytes in der zu erstellenden Bitmap vorhanden 
                ' sind
                If NoPadBytes Then

                    ' dann verwenden wir das TgaData ByteArray

                    ' Handle auf das gepinnte ByteArray TgaData holen
                    hBmpData = GCHandle.Alloc(TgaData, GCHandleType.Pinned)
                Else

                    ' PadBytes vorhanden
                    ' dann verwenden wir das BmpData ByteArray

                    ' Handle auf das gepinnte ByteArray BmpData holen
                    hBmpData = GCHandle.Alloc(BmpData, GCHandleType.Pinned)
                End If

                ' neues BitmapData-Objekt erstellen
                Dim NewData As New BitmapData
                NewData.Width = BmpWidth
                NewData.Height = BmpHeight
                NewData.Stride = BmpStride
                NewData.PixelFormat = BmpPixelFormat
                NewData.Scan0 = hBmpData.AddrOfPinnedObject()

                ' neue Bitmap in entsprechender Breite, Höhe und Pixelformat 
                ' erstellen
                OutBmp = New Bitmap(BmpWidth, BmpHeight, BmpPixelFormat)

                ' Bitmapdaten der Bitmap zum beschreiben im Speicher sperren 
                ' und die Daten aus dem gepinnten Array übertragen
                Dim Data As BitmapData = OutBmp.LockBits(
                    New Rectangle(0, 0, BmpWidth, BmpHeight),
                    ImageLockMode.WriteOnly Or ImageLockMode.UserInputBuffer,
                    BmpPixelFormat, NewData)

                ' Sperrung der Bitmapdaten wieder aufheben
                OutBmp.UnlockBits(Data)

                ' Handle auf das gepinnte ByteArray freigeben
                hBmpData.Free()

                ' hatte die TGA Palettendaten
                If tTgaHeader.ColorMapType = 1 Then

                    ' Originalpalette der Bitmap auslesen
                    BmpPal = OutBmp.Palette

                    ' alle Paletteneinträge aus der TGA, die wir zuvor in TgaPal
                    '  eingelesen haben, in die Palette der Bitmap umkopieren
                    For PalIndex = tTgaHeader.ColorMapStart To _
                        tTgaHeader.ColorMapLength - 1

                        ' nach Anzahl der Bits per Pixel in der 
                        ' Palette selektieren
                        Select Case tTgaHeader.ColorMapBits
                            Case 16

                                ' hier hatte ich keine TGA zum testen
                            Case 24

                                ' Palettendaten umkopieren
                                BmpPal.Entries(PalIndex) = Color.FromArgb(255,
                                    TgaPal((PalIndex * 3) + 2),
                                    TgaPal((PalIndex * 3) + 1),
                                    TgaPal((PalIndex * 3) + 0))
                            Case 32
                                BmpPal.Entries(PalIndex) = Color.FromArgb(
                                    TgaPal((PalIndex * 4) + 3),
                                    TgaPal((PalIndex * 4) + 2),
                                    TgaPal((PalIndex * 4) + 1),
                                    TgaPal((PalIndex * 4) + 0))
                            Case Else

                                'andere
                        End Select
                    Next

                    ' veränderte Palette wieder in die Bitmap zurück schreiben
                    OutBmp.Palette = BmpPal

                Else
                    ' die TGA hatte keine Palettendaten

                    ' nach TGA-ImageTyp selektieren
                    Select Case tTgaHeader.ImageType
                        Case 3, 11 'nur Typ 3 und 11

                            ' Originalpalette der Bitmap auslesen
                            BmpPal = OutBmp.Palette

                            ' eine eigene Palette erstellen (Grauskale)
                            For PalIndex = 0 To BmpPal.Entries.Length - 1

                                BmpPal.Entries(PalIndex) =
                                    Color.FromArgb(255,
                                    PalIndex,
                                    PalIndex,
                                    PalIndex)
                            Next

                            ' veränderte Palette wieder in die Bitmap 
                            ' zurück schreiben
                            OutBmp.Palette = BmpPal

                        Case Else

                            'andere
                    End Select
                End If

                ' Screen(destination)|Image(Origin)
                '  of first pixel    | bit 5 | bit 4
                ' -------------------|-------------
                ' Bottom(Left)       |   0   |   0
                ' Bottom(Right)      |   0   |   1
                ' Top(Left)          |   1   |   0
                ' Top(Right)         |   1   |   1

                ' ist das Bit 4 vom tTgaHeader.descriptor = 1
                If CBool(tTgaHeader.Descriptor And VFlag) Then

                    ' dann vertikal spiegeln
                    OutBmp.RotateFlip(RotateFlipType.RotateNoneFlipX)
                End If

                ' ist das Bit 5 vom tTgaHeader.descriptor = 1
                If CBool(tTgaHeader.Descriptor And HFlag) Then

                    ' Normalerweise liegen die Bytes des ersten Pixels im 
                    ' Speicher unten links. GDI+ spiegelt das Bild automatisch 
                    ' so, das das erste Pixel dann oben links ist. Daher 
                    ' brauchen wir das Bild nicht drehen wenn das Bit 5 vom
                    ' tTgaHeader.Descriptor = 1 ist. Wir drehen aber das Bild 
                    ' wenn das Bit 5 vom tTgaHeader.descriptor = 0 ist. Somit 
                    ' hat alles wieder seine Richtigkeit.

                Else
                    ' dann horizontal spiegeln
                    OutBmp.RotateFlip(RotateFlipType.RotateNoneFlipY)
                End If

            Case Else

                'andere
        End Select

        ' fertige Bitmap zurück geben
        Return OutBmp

    End Function
End Module
