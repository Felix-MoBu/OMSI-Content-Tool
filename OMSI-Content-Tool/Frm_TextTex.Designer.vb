<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_TextTex
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_TextTex))
        Me.LBMain = New System.Windows.Forms.ListBox()
        Me.BTEntfernen = New System.Windows.Forms.Button()
        Me.BTNeu = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GBMain = New System.Windows.Forms.GroupBox()
        Me.CBEnh = New System.Windows.Forms.CheckBox()
        Me.GBEnh = New System.Windows.Forms.GroupBox()
        Me.CBAusr = New System.Windows.Forms.ComboBox()
        Me.CBGrid = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.RBColor = New System.Windows.Forms.RadioButton()
        Me.RBMono = New System.Windows.Forms.RadioButton()
        Me.TBHoehe = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TBBreite = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TBFont = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TBName = New System.Windows.Forms.TextBox()
        Me.BTSpeichern = New System.Windows.Forms.Button()
        Me.GBMain.SuspendLayout()
        Me.GBEnh.SuspendLayout()
        Me.SuspendLayout()
        '
        'LBMain
        '
        Me.LBMain.FormattingEnabled = True
        Me.LBMain.Location = New System.Drawing.Point(12, 12)
        Me.LBMain.Name = "LBMain"
        Me.LBMain.ScrollAlwaysVisible = True
        Me.LBMain.Size = New System.Drawing.Size(206, 225)
        Me.LBMain.TabIndex = 0
        '
        'BTEntfernen
        '
        Me.BTEntfernen.Location = New System.Drawing.Point(118, 243)
        Me.BTEntfernen.Name = "BTEntfernen"
        Me.BTEntfernen.Size = New System.Drawing.Size(100, 23)
        Me.BTEntfernen.TabIndex = 4
        Me.BTEntfernen.Text = "Entfernen"
        Me.BTEntfernen.UseVisualStyleBackColor = True
        '
        'BTNeu
        '
        Me.BTNeu.Location = New System.Drawing.Point(12, 243)
        Me.BTNeu.Name = "BTNeu"
        Me.BTNeu.Size = New System.Drawing.Size(100, 23)
        Me.BTNeu.TabIndex = 3
        Me.BTNeu.Text = "Neu"
        Me.BTNeu.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Name"
        '
        'GBMain
        '
        Me.GBMain.Controls.Add(Me.CBEnh)
        Me.GBMain.Controls.Add(Me.GBEnh)
        Me.GBMain.Controls.Add(Me.RBColor)
        Me.GBMain.Controls.Add(Me.RBMono)
        Me.GBMain.Controls.Add(Me.TBHoehe)
        Me.GBMain.Controls.Add(Me.Label4)
        Me.GBMain.Controls.Add(Me.TBBreite)
        Me.GBMain.Controls.Add(Me.Label3)
        Me.GBMain.Controls.Add(Me.TBFont)
        Me.GBMain.Controls.Add(Me.Label2)
        Me.GBMain.Controls.Add(Me.TBName)
        Me.GBMain.Controls.Add(Me.Label1)
        Me.GBMain.Location = New System.Drawing.Point(224, 7)
        Me.GBMain.Name = "GBMain"
        Me.GBMain.Size = New System.Drawing.Size(326, 230)
        Me.GBMain.TabIndex = 6
        Me.GBMain.TabStop = False
        '
        'CBEnh
        '
        Me.CBEnh.AutoSize = True
        Me.CBEnh.Location = New System.Drawing.Point(8, 147)
        Me.CBEnh.Name = "CBEnh"
        Me.CBEnh.Size = New System.Drawing.Size(104, 17)
        Me.CBEnh.TabIndex = 16
        Me.CBEnh.Text = "Verbessert (Enh)"
        Me.CBEnh.UseVisualStyleBackColor = True
        '
        'GBEnh
        '
        Me.GBEnh.Controls.Add(Me.CBAusr)
        Me.GBEnh.Controls.Add(Me.CBGrid)
        Me.GBEnh.Controls.Add(Me.Label5)
        Me.GBEnh.Location = New System.Drawing.Point(6, 149)
        Me.GBEnh.Name = "GBEnh"
        Me.GBEnh.Size = New System.Drawing.Size(314, 71)
        Me.GBEnh.TabIndex = 15
        Me.GBEnh.TabStop = False
        Me.GBEnh.Visible = False
        '
        'CBAusr
        '
        Me.CBAusr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBAusr.FormattingEnabled = True
        Me.CBAusr.Items.AddRange(New Object() {"Zentriert", "Linksbündig", "Rechtsbündig", "Zentriert (seitlicher Abstand)", "Linksbündig (seitlicher Abstand)", "Rechtbündig (seitlicher Abstand)"})
        Me.CBAusr.Location = New System.Drawing.Point(75, 19)
        Me.CBAusr.Name = "CBAusr"
        Me.CBAusr.Size = New System.Drawing.Size(199, 21)
        Me.CBAusr.TabIndex = 30
        '
        'CBGrid
        '
        Me.CBGrid.AutoSize = True
        Me.CBGrid.Location = New System.Drawing.Point(9, 46)
        Me.CBGrid.Name = "CBGrid"
        Me.CBGrid.Size = New System.Drawing.Size(146, 17)
        Me.CBGrid.TabIndex = 28
        Me.CBGrid.Text = "Pixel an Raster anpassen"
        Me.CBGrid.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 13)
        Me.Label5.TabIndex = 28
        Me.Label5.Text = "Ausrichtung"
        '
        'RBColor
        '
        Me.RBColor.AutoSize = True
        Me.RBColor.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RBColor.Location = New System.Drawing.Point(157, 91)
        Me.RBColor.Name = "RBColor"
        Me.RBColor.Size = New System.Drawing.Size(75, 17)
        Me.RBColor.TabIndex = 14
        Me.RBColor.Text = "Mehrfarbig"
        Me.RBColor.UseVisualStyleBackColor = True
        '
        'RBMono
        '
        Me.RBMono.AutoSize = True
        Me.RBMono.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RBMono.Checked = True
        Me.RBMono.Location = New System.Drawing.Point(8, 91)
        Me.RBMono.Name = "RBMono"
        Me.RBMono.Size = New System.Drawing.Size(87, 17)
        Me.RBMono.TabIndex = 13
        Me.RBMono.TabStop = True
        Me.RBMono.Text = "Monochrome"
        Me.RBMono.UseVisualStyleBackColor = True
        '
        'TBHoehe
        '
        Me.TBHoehe.Location = New System.Drawing.Point(193, 65)
        Me.TBHoehe.Name = "TBHoehe"
        Me.TBHoehe.Size = New System.Drawing.Size(87, 20)
        Me.TBHoehe.TabIndex = 12
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(154, 68)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(33, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Höhe"
        '
        'TBBreite
        '
        Me.TBBreite.Location = New System.Drawing.Point(52, 65)
        Me.TBBreite.Name = "TBBreite"
        Me.TBBreite.Size = New System.Drawing.Size(87, 20)
        Me.TBBreite.TabIndex = 10
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(34, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Breite"
        '
        'TBFont
        '
        Me.TBFont.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.TBFont.Cursor = System.Windows.Forms.Cursors.Hand
        Me.TBFont.Location = New System.Drawing.Point(52, 39)
        Me.TBFont.Name = "TBFont"
        Me.TBFont.ReadOnly = True
        Me.TBFont.Size = New System.Drawing.Size(228, 20)
        Me.TBFont.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(28, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Font"
        '
        'TBName
        '
        Me.TBName.Location = New System.Drawing.Point(52, 13)
        Me.TBName.Name = "TBName"
        Me.TBName.Size = New System.Drawing.Size(228, 20)
        Me.TBName.TabIndex = 6
        '
        'BTSpeichern
        '
        Me.BTSpeichern.Location = New System.Drawing.Point(450, 243)
        Me.BTSpeichern.Name = "BTSpeichern"
        Me.BTSpeichern.Size = New System.Drawing.Size(100, 23)
        Me.BTSpeichern.TabIndex = 7
        Me.BTSpeichern.Text = "Okay"
        Me.BTSpeichern.UseVisualStyleBackColor = True
        '
        'Frm_TextTex
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(556, 274)
        Me.Controls.Add(Me.BTSpeichern)
        Me.Controls.Add(Me.GBMain)
        Me.Controls.Add(Me.BTEntfernen)
        Me.Controls.Add(Me.BTNeu)
        Me.Controls.Add(Me.LBMain)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Frm_TextTex"
        Me.Text = "Text-Texturen"
        Me.GBMain.ResumeLayout(False)
        Me.GBMain.PerformLayout()
        Me.GBEnh.ResumeLayout(False)
        Me.GBEnh.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LBMain As ListBox
    Friend WithEvents BTEntfernen As Button
    Friend WithEvents BTNeu As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents GBMain As GroupBox
    Friend WithEvents TBName As TextBox
    Friend WithEvents BTSpeichern As Button
    Friend WithEvents TBFont As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TBHoehe As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TBBreite As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents RBColor As RadioButton
    Friend WithEvents RBMono As RadioButton
    Friend WithEvents CBEnh As CheckBox
    Friend WithEvents GBEnh As GroupBox
    Friend WithEvents CBGrid As CheckBox
    Friend WithEvents Label5 As Label
    Friend WithEvents CBAusr As ComboBox
End Class
