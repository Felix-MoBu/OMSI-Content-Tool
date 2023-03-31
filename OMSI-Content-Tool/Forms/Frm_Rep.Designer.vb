<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Rep
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Rep))
        Me.LBRepaints = New System.Windows.Forms.ListBox()
        Me.BTNeu = New System.Windows.Forms.Button()
        Me.BTEntfernen = New System.Windows.Forms.Button()
        Me.PMain = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PRepVars = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LabelDateiname = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TBName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BTSpeichern = New System.Windows.Forms.Button()
        Me.BTÖffnen = New System.Windows.Forms.Button()
        Me.BTNeuLaden = New System.Windows.Forms.Button()
        Me.TBFilter = New System.Windows.Forms.TextBox()
        Me.BTRepTool = New System.Windows.Forms.Button()
        Me.PMain.SuspendLayout()
        Me.PRepVars.SuspendLayout()
        Me.SuspendLayout()
        '
        'LBRepaints
        '
        Me.LBRepaints.FormattingEnabled = True
        Me.LBRepaints.Location = New System.Drawing.Point(12, 38)
        Me.LBRepaints.Name = "LBRepaints"
        Me.LBRepaints.ScrollAlwaysVisible = True
        Me.LBRepaints.Size = New System.Drawing.Size(206, 368)
        Me.LBRepaints.TabIndex = 0
        '
        'BTNeu
        '
        Me.BTNeu.Location = New System.Drawing.Point(12, 415)
        Me.BTNeu.Name = "BTNeu"
        Me.BTNeu.Size = New System.Drawing.Size(100, 23)
        Me.BTNeu.TabIndex = 1
        Me.BTNeu.Text = "Neu"
        Me.BTNeu.UseVisualStyleBackColor = True
        '
        'BTEntfernen
        '
        Me.BTEntfernen.Location = New System.Drawing.Point(118, 415)
        Me.BTEntfernen.Name = "BTEntfernen"
        Me.BTEntfernen.Size = New System.Drawing.Size(100, 23)
        Me.BTEntfernen.TabIndex = 2
        Me.BTEntfernen.Text = "Entfernen"
        Me.BTEntfernen.UseVisualStyleBackColor = True
        '
        'PMain
        '
        Me.PMain.AutoScroll = True
        Me.PMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PMain.Controls.Add(Me.Label4)
        Me.PMain.Controls.Add(Me.PRepVars)
        Me.PMain.Controls.Add(Me.LabelDateiname)
        Me.PMain.Controls.Add(Me.Label2)
        Me.PMain.Controls.Add(Me.TBName)
        Me.PMain.Controls.Add(Me.Label1)
        Me.PMain.Location = New System.Drawing.Point(224, 12)
        Me.PMain.Name = "PMain"
        Me.PMain.Size = New System.Drawing.Size(565, 394)
        Me.PMain.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(5, 57)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Texturen"
        '
        'PRepVars
        '
        Me.PRepVars.BackColor = System.Drawing.SystemColors.Control
        Me.PRepVars.Controls.Add(Me.Label3)
        Me.PRepVars.Location = New System.Drawing.Point(6, 75)
        Me.PRepVars.Name = "PRepVars"
        Me.PRepVars.Size = New System.Drawing.Size(535, 100)
        Me.PRepVars.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(0, 5)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Variablen"
        '
        'LabelDateiname
        '
        Me.LabelDateiname.AutoSize = True
        Me.LabelDateiname.Location = New System.Drawing.Point(86, 6)
        Me.LabelDateiname.Name = "LabelDateiname"
        Me.LabelDateiname.Size = New System.Drawing.Size(33, 13)
        Me.LabelDateiname.TabIndex = 4
        Me.LabelDateiname.Text = "keine"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Datei-Name"
        '
        'TBName
        '
        Me.TBName.Location = New System.Drawing.Point(89, 29)
        Me.TBName.Name = "TBName"
        Me.TBName.Size = New System.Drawing.Size(381, 20)
        Me.TBName.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Repaint-Name"
        '
        'BTSpeichern
        '
        Me.BTSpeichern.Location = New System.Drawing.Point(706, 415)
        Me.BTSpeichern.Name = "BTSpeichern"
        Me.BTSpeichern.Size = New System.Drawing.Size(80, 23)
        Me.BTSpeichern.TabIndex = 4
        Me.BTSpeichern.Text = "Übernehmen"
        Me.BTSpeichern.UseVisualStyleBackColor = True
        '
        'BTÖffnen
        '
        Me.BTÖffnen.Location = New System.Drawing.Point(224, 415)
        Me.BTÖffnen.Name = "BTÖffnen"
        Me.BTÖffnen.Size = New System.Drawing.Size(80, 23)
        Me.BTÖffnen.TabIndex = 5
        Me.BTÖffnen.Text = "Ordner öffnen"
        Me.BTÖffnen.UseVisualStyleBackColor = True
        '
        'BTNeuLaden
        '
        Me.BTNeuLaden.Location = New System.Drawing.Point(310, 415)
        Me.BTNeuLaden.Name = "BTNeuLaden"
        Me.BTNeuLaden.Size = New System.Drawing.Size(80, 23)
        Me.BTNeuLaden.TabIndex = 6
        Me.BTNeuLaden.Text = "Neu laden"
        Me.BTNeuLaden.UseVisualStyleBackColor = True
        '
        'TBFilter
        '
        Me.TBFilter.Location = New System.Drawing.Point(12, 12)
        Me.TBFilter.Name = "TBFilter"
        Me.TBFilter.Size = New System.Drawing.Size(206, 20)
        Me.TBFilter.TabIndex = 7
        '
        'BTRepTool
        '
        Me.BTRepTool.Location = New System.Drawing.Point(499, 415)
        Me.BTRepTool.Name = "BTRepTool"
        Me.BTRepTool.Size = New System.Drawing.Size(115, 23)
        Me.BTRepTool.TabIndex = 8
        Me.BTRepTool.Text = "Repaint-Tool starten"
        Me.BTRepTool.UseVisualStyleBackColor = True
        '
        'Frm_Rep
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(798, 446)
        Me.Controls.Add(Me.BTRepTool)
        Me.Controls.Add(Me.TBFilter)
        Me.Controls.Add(Me.BTNeuLaden)
        Me.Controls.Add(Me.BTÖffnen)
        Me.Controls.Add(Me.BTSpeichern)
        Me.Controls.Add(Me.PMain)
        Me.Controls.Add(Me.BTEntfernen)
        Me.Controls.Add(Me.BTNeu)
        Me.Controls.Add(Me.LBRepaints)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(814, 485)
        Me.MinimumSize = New System.Drawing.Size(814, 485)
        Me.Name = "Frm_Rep"
        Me.Text = "Repaints"
        Me.PMain.ResumeLayout(False)
        Me.PMain.PerformLayout()
        Me.PRepVars.ResumeLayout(False)
        Me.PRepVars.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LBRepaints As ListBox
    Friend WithEvents BTNeu As Button
    Friend WithEvents BTEntfernen As Button
    Friend WithEvents PMain As Panel
    Friend WithEvents TBName As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents BTSpeichern As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents LabelDateiname As Label
    Friend WithEvents BTÖffnen As Button
    Friend WithEvents BTNeuLaden As Button
    Friend WithEvents PRepVars As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents TBFilter As TextBox
    Friend WithEvents BTRepTool As Button
End Class
