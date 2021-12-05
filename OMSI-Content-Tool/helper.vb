'by Felix Modellbusse ;) (MoBu) 2019
Imports System.Text.RegularExpressions 'Für ColorFromData

Module helper
    Dim allowedKeys As Integer() = {3, 8, 22, 24}

    Public Function NumbersOnly(e As KeyPressEventArgs, Optional TB As TextBox = Nothing, Optional asDouble As Boolean = False, Optional maxValue As Double = Double.MaxValue, Optional minValue As Double = Double.MinValue) As Boolean
        If asDouble Then '44 = Komma | 45 = Minus | 46 = Punkt
            If TB Is Nothing Then Return True
            If Asc(e.KeyChar) = 45 Then
                Dim startindex As Integer = TB.SelectionStart + 1
                If TB.SelectionLength > 0 Then
                    TB.SelectedText = ""
                End If
                If TB.Text <> "" Then
                    If TB.Text(0) = "-" Then
                        TB.Text = TB.Text.Substring(1, TB.Text.Length - 1)
                        startindex -= 2
                    Else
                        TB.Text = "-" & TB.Text
                    End If
                Else
                    TB.Text = "-" & TB.Text
                End If

                If TB.Text.Length < startindex Or startindex < 0 Then
                    TB.SelectionStart = TB.Text.Length
                Else
                    TB.SelectionStart = startindex
                End If
                Return True
            End If

            If Asc(e.KeyChar) = 44 Or Asc(e.KeyChar) = 46 Then
                Dim startindex As Integer = TB.SelectionStart + 1
                If TB.SelectionLength > 0 Then
                    TB.SelectedText = ""
                End If
                TB.Text = TB.Text.Substring(0, TB.SelectionStart) & "," & TB.Text.Substring(TB.SelectionStart)

                If TB.Text.Length < startindex Then
                    TB.SelectionStart = TB.Text.Length
                Else
                    TB.SelectionStart = startindex
                End If

                Return True
            End If
        End If

        If (Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) Or allowedKeys.Contains(Asc(e.KeyChar)) Then
            Return False
        Else
            Return True
        End If
    End Function

    Public Function toSingle(text As String) As Single
        Try
            Return Convert.ToSingle(Replace(text, ".", ","))
        Catch ex As Exception
            Log.Add("Ungültige convertierung von """ & text & """ in eine Kommazahl!", Log.TYPE_WARNUNG)
            Return 0
        End Try
    End Function

    Public Function toByte(val As String) As Byte
        If CInt(val) > 255 Then Return 255
        If CInt(val) < 0 Then Return 0
        Return Convert.ToByte(CInt(val))
    End Function

    Public Function toByte(val As Integer) As Byte
        If val > 255 Then Return 255
        If val < 0 Then Return 0
        Return Convert.ToByte(val)
    End Function

    Public Function toByte(val As Single) As Byte
        If val > 255 Then Return 255
        If val < 0 Then Return 0
        Return Convert.ToByte(val)
    End Function

    Public Function toBool(val As String) As Boolean
        If val = "1" Then Return True
        Return False
    End Function

    Public Function fromSingle(value As Single, Optional length As Byte = 3) As String
        Return Replace(FormatNumber(value, length,,, TriState.False), ",", ".")
    End Function

    Public Function fromDouble(value As Double, Optional length As Byte = 3) As String
        Return Replace(FormatNumber(value, length,,, TriState.False), ",", ".")
    End Function

    Public Function fromBool(value As Boolean) As String
        If value Then Return "1"
        Return "0"
    End Function

    Public Function stringToBool(val As String) As Boolean
        If LCase(val) = "true" Then Return True
        Return False
    End Function
    Public Function boolToInt(val As Boolean) As Integer
        If val Then Return 1
        Return 0
    End Function

    Public Function intToBool(val As Integer) As Boolean
        If val = 0 Then Return False
        Return True
    End Function

    Public Function roundToIndex(val As Double) As Integer
        If Int(val) > val Then
            Return CInt(val) - 1
        Else
            Return CInt(val)
        End If
    End Function

    Public Function ColourFromData(s As String) As Color
        Dim fallbackColour = Color.Black

        If Not s.StartsWith("color", StringComparison.OrdinalIgnoreCase) Then
            Return fallbackColour
        End If

        ' Extract whatever is between the brackets.
        Dim re = New Regex("\[(.+?)]")
        Dim colorNameMatch = re.Match(s)
        If Not colorNameMatch.Success Then
            Return fallbackColour
        End If

        Dim colourName = colorNameMatch.Groups(1).Value

        ' Get the names of the known colours.
        'TODO: If this function is called frequently, consider creating allColours as a variable with a larger scope.
        Dim allColours = [Enum].GetNames(GetType(System.Drawing.KnownColor))

        ' Attempt a case-insensitive match to the known colours.
        Dim nameOfColour = allColours.FirstOrDefault(Function(c) String.Compare(c, colourName, StringComparison.OrdinalIgnoreCase) = 0)

        If Not String.IsNullOrEmpty(nameOfColour) Then
            Return Color.FromName(nameOfColour)
        End If

        ' Was not a named colour. Parse for ARGB values.
        re = New Regex("A=(\d+).*?R=(\d+).*?G=(\d+).*?B=(\d+)", RegexOptions.IgnoreCase)
        Dim componentMatches = re.Match(colourName)

        If componentMatches.Success Then

            Dim a = Integer.Parse(componentMatches.Groups(1).Value)
            Dim r = Integer.Parse(componentMatches.Groups(2).Value)
            Dim g = Integer.Parse(componentMatches.Groups(3).Value)
            Dim b = Integer.Parse(componentMatches.Groups(4).Value)

            Dim maxValue = 255

            If a > maxValue OrElse r > maxValue OrElse g > maxValue OrElse b > maxValue Then
                Return fallbackColour
            End If

            Return System.Drawing.Color.FromArgb(a, r, g, b)

        End If

        Return fallbackColour

    End Function

    Public Sub DisplayImage(PB As PictureBox)
        Dim textureFilename As New Filename(PB.Tag)
        If textureFilename.extension = "dds" Then Exit Sub             'DDS-Annomalie wieder entfernen
        If textureFilename.extension.ToLower = "tga" Then
            PB.Image = readTGA(textureFilename)
        Else
            PB.Load(textureFilename)
        End If
    End Sub


    Public Sub MsgNoProj()
        MsgBox("Bitte erst ein Projekt öffnen oder erstellen!")
    End Sub
End Module
