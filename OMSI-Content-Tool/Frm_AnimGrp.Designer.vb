<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_AnimGrp
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_AnimGrp))
        Me.LBGruppennamen = New System.Windows.Forms.ListBox()
        Me.LBMeshes = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TBName = New System.Windows.Forms.TextBox()
        Me.BTNeu = New System.Windows.Forms.Button()
        Me.BTEntfernen = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LBInfo = New System.Windows.Forms.Label()
        Me.BTÄndern = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.BTÜbernehmen = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.BTKeine = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.DDMaster = New System.Windows.Forms.ComboBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'LBGruppennamen
        '
        Me.LBGruppennamen.FormattingEnabled = True
        Me.LBGruppennamen.Location = New System.Drawing.Point(12, 27)
        Me.LBGruppennamen.Name = "LBGruppennamen"
        Me.LBGruppennamen.Size = New System.Drawing.Size(190, 329)
        Me.LBGruppennamen.TabIndex = 0
        '
        'LBMeshes
        '
        Me.LBMeshes.Enabled = False
        Me.LBMeshes.FormattingEnabled = True
        Me.LBMeshes.Location = New System.Drawing.Point(227, 27)
        Me.LBMeshes.Name = "LBMeshes"
        Me.LBMeshes.Size = New System.Drawing.Size(190, 329)
        Me.LBMeshes.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Bezeichnung"
        '
        'TBName
        '
        Me.TBName.Location = New System.Drawing.Point(81, 47)
        Me.TBName.Name = "TBName"
        Me.TBName.Size = New System.Drawing.Size(223, 20)
        Me.TBName.TabIndex = 3
        '
        'BTNeu
        '
        Me.BTNeu.Location = New System.Drawing.Point(12, 362)
        Me.BTNeu.Name = "BTNeu"
        Me.BTNeu.Size = New System.Drawing.Size(92, 23)
        Me.BTNeu.TabIndex = 4
        Me.BTNeu.Text = "Neu"
        Me.BTNeu.UseVisualStyleBackColor = True
        '
        'BTEntfernen
        '
        Me.BTEntfernen.Enabled = False
        Me.BTEntfernen.Location = New System.Drawing.Point(110, 362)
        Me.BTEntfernen.Name = "BTEntfernen"
        Me.BTEntfernen.Size = New System.Drawing.Size(92, 23)
        Me.BTEntfernen.TabIndex = 5
        Me.BTEntfernen.Text = "Entfernen"
        Me.BTEntfernen.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(97, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Animationsgruppen"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(224, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(101, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Zugehörige Meshes"
        '
        'LBInfo
        '
        Me.LBInfo.AutoSize = True
        Me.LBInfo.Location = New System.Drawing.Point(229, 364)
        Me.LBInfo.Name = "LBInfo"
        Me.LBInfo.Size = New System.Drawing.Size(143, 26)
        Me.LBInfo.TabIndex = 8
        Me.LBInfo.Text = "Nur leere Animationsgruppen" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "können entfernt werden!"
        Me.LBInfo.Visible = False
        '
        'BTÄndern
        '
        Me.BTÄndern.Location = New System.Drawing.Point(310, 45)
        Me.BTÄndern.Name = "BTÄndern"
        Me.BTÄndern.Size = New System.Drawing.Size(80, 23)
        Me.BTÄndern.TabIndex = 9
        Me.BTÄndern.Text = "Ändern"
        Me.BTÄndern.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.DDMaster)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.BTÄndern)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.TBName)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 393)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(405, 77)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Details"
        '
        'BTÜbernehmen
        '
        Me.BTÜbernehmen.Location = New System.Drawing.Point(337, 476)
        Me.BTÜbernehmen.Name = "BTÜbernehmen"
        Me.BTÜbernehmen.Size = New System.Drawing.Size(80, 23)
        Me.BTÜbernehmen.TabIndex = 11
        Me.BTÜbernehmen.Text = "Übernehmen"
        Me.BTÜbernehmen.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 481)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(222, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Leere Gruppen werden automatisch gelöscht!"
        '
        'BTKeine
        '
        Me.BTKeine.Location = New System.Drawing.Point(251, 476)
        Me.BTKeine.Name = "BTKeine"
        Me.BTKeine.Size = New System.Drawing.Size(80, 23)
        Me.BTKeine.TabIndex = 13
        Me.BTKeine.Text = "Keine"
        Me.BTKeine.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Master"
        '
        'DDMaster
        '
        Me.DDMaster.FormattingEnabled = True
        Me.DDMaster.Location = New System.Drawing.Point(81, 19)
        Me.DDMaster.Name = "DDMaster"
        Me.DDMaster.Size = New System.Drawing.Size(223, 21)
        Me.DDMaster.TabIndex = 11
        '
        'Frm_AnimGrp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(429, 509)
        Me.Controls.Add(Me.BTKeine)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.BTÜbernehmen)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.LBInfo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.BTEntfernen)
        Me.Controls.Add(Me.BTNeu)
        Me.Controls.Add(Me.LBMeshes)
        Me.Controls.Add(Me.LBGruppennamen)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_AnimGrp"
        Me.Text = "Animationsgruppen"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LBGruppennamen As ListBox
    Friend WithEvents LBMeshes As ListBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TBName As TextBox
    Friend WithEvents BTNeu As Button
    Friend WithEvents BTEntfernen As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents LBInfo As Label
    Friend WithEvents BTÄndern As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents BTÜbernehmen As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents BTKeine As Button
    Friend WithEvents DDMaster As ComboBox
    Friend WithEvents Label5 As Label
End Class
