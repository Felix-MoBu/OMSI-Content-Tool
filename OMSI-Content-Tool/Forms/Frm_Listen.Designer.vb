<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Listen
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Listen))
        Me.LBOrdner = New System.Windows.Forms.ListBox()
        Me.BTHinzu = New System.Windows.Forms.Button()
        Me.BTEntf = New System.Windows.Forms.Button()
        Me.LBAusgewählt = New System.Windows.Forms.ListBox()
        Me.TBOrdnerFiltern = New System.Windows.Forms.TextBox()
        Me.TBAusgFiltern = New System.Windows.Forms.TextBox()
        Me.BTÜbernehmen = New System.Windows.Forms.Button()
        Me.BTAbbrechen = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LBInfo = New System.Windows.Forms.Label()
        Me.BTNeu = New System.Windows.Forms.Button()
        Me.BTOrdner = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'LBOrdner
        '
        Me.LBOrdner.FormattingEnabled = True
        Me.LBOrdner.Location = New System.Drawing.Point(12, 36)
        Me.LBOrdner.Name = "LBOrdner"
        Me.LBOrdner.Size = New System.Drawing.Size(250, 485)
        Me.LBOrdner.TabIndex = 0
        '
        'BTHinzu
        '
        Me.BTHinzu.Location = New System.Drawing.Point(272, 36)
        Me.BTHinzu.Name = "BTHinzu"
        Me.BTHinzu.Size = New System.Drawing.Size(75, 23)
        Me.BTHinzu.TabIndex = 1
        Me.BTHinzu.Text = ">"
        Me.BTHinzu.UseVisualStyleBackColor = True
        '
        'BTEntf
        '
        Me.BTEntf.Location = New System.Drawing.Point(272, 62)
        Me.BTEntf.Name = "BTEntf"
        Me.BTEntf.Size = New System.Drawing.Size(75, 23)
        Me.BTEntf.TabIndex = 2
        Me.BTEntf.Text = "<"
        Me.BTEntf.UseVisualStyleBackColor = True
        '
        'LBAusgewählt
        '
        Me.LBAusgewählt.FormattingEnabled = True
        Me.LBAusgewählt.Location = New System.Drawing.Point(358, 36)
        Me.LBAusgewählt.Name = "LBAusgewählt"
        Me.LBAusgewählt.Size = New System.Drawing.Size(250, 485)
        Me.LBAusgewählt.TabIndex = 3
        '
        'TBOrdnerFiltern
        '
        Me.TBOrdnerFiltern.Location = New System.Drawing.Point(50, 10)
        Me.TBOrdnerFiltern.Name = "TBOrdnerFiltern"
        Me.TBOrdnerFiltern.Size = New System.Drawing.Size(212, 20)
        Me.TBOrdnerFiltern.TabIndex = 4
        '
        'TBAusgFiltern
        '
        Me.TBAusgFiltern.Location = New System.Drawing.Point(393, 10)
        Me.TBAusgFiltern.Name = "TBAusgFiltern"
        Me.TBAusgFiltern.Size = New System.Drawing.Size(215, 20)
        Me.TBAusgFiltern.TabIndex = 6
        '
        'BTÜbernehmen
        '
        Me.BTÜbernehmen.Location = New System.Drawing.Point(523, 527)
        Me.BTÜbernehmen.Name = "BTÜbernehmen"
        Me.BTÜbernehmen.Size = New System.Drawing.Size(85, 23)
        Me.BTÜbernehmen.TabIndex = 8
        Me.BTÜbernehmen.Text = "Übernehmen"
        Me.BTÜbernehmen.UseVisualStyleBackColor = True
        '
        'BTAbbrechen
        '
        Me.BTAbbrechen.Location = New System.Drawing.Point(432, 527)
        Me.BTAbbrechen.Name = "BTAbbrechen"
        Me.BTAbbrechen.Size = New System.Drawing.Size(85, 23)
        Me.BTAbbrechen.TabIndex = 9
        Me.BTAbbrechen.Text = "Abbrechen"
        Me.BTAbbrechen.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Filter:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(355, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Filter:"
        '
        'LBInfo
        '
        Me.LBInfo.AutoSize = True
        Me.LBInfo.Location = New System.Drawing.Point(12, 532)
        Me.LBInfo.Name = "LBInfo"
        Me.LBInfo.Size = New System.Drawing.Size(221, 13)
        Me.LBInfo.TabIndex = 12
        Me.LBInfo.Text = "Bei Filterung wird der Ordner neu ausgelesen!"
        '
        'BTNeu
        '
        Me.BTNeu.Location = New System.Drawing.Point(272, 120)
        Me.BTNeu.Name = "BTNeu"
        Me.BTNeu.Size = New System.Drawing.Size(75, 23)
        Me.BTNeu.TabIndex = 14
        Me.BTNeu.Text = "Neu"
        Me.BTNeu.UseVisualStyleBackColor = True
        '
        'BTOrdner
        '
        Me.BTOrdner.Location = New System.Drawing.Point(272, 149)
        Me.BTOrdner.Name = "BTOrdner"
        Me.BTOrdner.Size = New System.Drawing.Size(75, 40)
        Me.BTOrdner.TabIndex = 15
        Me.BTOrdner.Text = "Ordner öffnen"
        Me.BTOrdner.UseVisualStyleBackColor = True
        '
        'Frm_Listen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(620, 558)
        Me.Controls.Add(Me.BTOrdner)
        Me.Controls.Add(Me.BTNeu)
        Me.Controls.Add(Me.LBInfo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BTAbbrechen)
        Me.Controls.Add(Me.BTÜbernehmen)
        Me.Controls.Add(Me.TBAusgFiltern)
        Me.Controls.Add(Me.TBOrdnerFiltern)
        Me.Controls.Add(Me.LBAusgewählt)
        Me.Controls.Add(Me.BTEntf)
        Me.Controls.Add(Me.BTHinzu)
        Me.Controls.Add(Me.LBOrdner)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Frm_Listen"
        Me.Text = "Listen"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LBOrdner As ListBox
    Friend WithEvents BTHinzu As Button
    Friend WithEvents BTEntf As Button
    Friend WithEvents LBAusgewählt As ListBox
    Friend WithEvents TBOrdnerFiltern As TextBox
    Friend WithEvents TBAusgFiltern As TextBox
    Friend WithEvents BTÜbernehmen As Button
    Friend WithEvents BTAbbrechen As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents LBInfo As Label
    Friend WithEvents BTNeu As Button
    Friend WithEvents BTOrdner As Button
End Class
