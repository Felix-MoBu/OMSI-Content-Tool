<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Eig_Sli
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Eig_Sli))
        Me.Label58 = New System.Windows.Forms.Label()
        Me.TBHalbbreite = New System.Windows.Forms.TextBox()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.TBLaenge = New System.Windows.Forms.TextBox()
        Me.CBEditor = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.BTPfad = New System.Windows.Forms.Button()
        Me.TBPath = New System.Windows.Forms.TextBox()
        Me.TBName = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.BTOrdner = New System.Windows.Forms.Button()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.BTSchließen = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label58
        '
        Me.Label58.AutoSize = True
        Me.Label58.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label58.Location = New System.Drawing.Point(211, 22)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(55, 13)
        Me.Label58.TabIndex = 30
        Me.Label58.Text = "Halbbreite"
        '
        'TBHalbbreite
        '
        Me.TBHalbbreite.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBHalbbreite.Location = New System.Drawing.Point(275, 19)
        Me.TBHalbbreite.Name = "TBHalbbreite"
        Me.TBHalbbreite.Size = New System.Drawing.Size(72, 20)
        Me.TBHalbbreite.TabIndex = 29
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label45.Location = New System.Drawing.Point(10, 22)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(37, 13)
        Me.Label45.TabIndex = 28
        Me.Label45.Text = "Länge"
        '
        'TBLaenge
        '
        Me.TBLaenge.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBLaenge.Location = New System.Drawing.Point(94, 19)
        Me.TBLaenge.Name = "TBLaenge"
        Me.TBLaenge.Size = New System.Drawing.Size(72, 20)
        Me.TBLaenge.TabIndex = 27
        '
        'CBEditor
        '
        Me.CBEditor.AutoSize = True
        Me.CBEditor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBEditor.Location = New System.Drawing.Point(13, 55)
        Me.CBEditor.Name = "CBEditor"
        Me.CBEditor.Size = New System.Drawing.Size(150, 17)
        Me.CBEditor.TabIndex = 31
        Me.CBEditor.Text = "Nur im Map-Editor sichtbar"
        Me.CBEditor.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label27)
        Me.GroupBox1.Controls.Add(Me.Label26)
        Me.GroupBox1.Controls.Add(Me.BTPfad)
        Me.GroupBox1.Controls.Add(Me.TBPath)
        Me.GroupBox1.Controls.Add(Me.TBName)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(439, 78)
        Me.GroupBox1.TabIndex = 32
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Organisatorisches"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(6, 48)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(29, 13)
        Me.Label27.TabIndex = 22
        Me.Label27.Text = "Pfad"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(6, 22)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(58, 13)
        Me.Label26.TabIndex = 21
        Me.Label26.Text = "Dateiname"
        '
        'BTPfad
        '
        Me.BTPfad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTPfad.Location = New System.Drawing.Point(353, 43)
        Me.BTPfad.Name = "BTPfad"
        Me.BTPfad.Size = New System.Drawing.Size(75, 23)
        Me.BTPfad.TabIndex = 20
        Me.BTPfad.Text = "Auswählen"
        Me.BTPfad.UseVisualStyleBackColor = True
        '
        'TBPath
        '
        Me.TBPath.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBPath.Location = New System.Drawing.Point(94, 45)
        Me.TBPath.Name = "TBPath"
        Me.TBPath.Size = New System.Drawing.Size(253, 20)
        Me.TBPath.TabIndex = 19
        '
        'TBName
        '
        Me.TBName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBName.Location = New System.Drawing.Point(94, 19)
        Me.TBName.Name = "TBName"
        Me.TBName.Size = New System.Drawing.Size(334, 20)
        Me.TBName.TabIndex = 18
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.CBEditor)
        Me.GroupBox2.Controls.Add(Me.TBLaenge)
        Me.GroupBox2.Controls.Add(Me.Label58)
        Me.GroupBox2.Controls.Add(Me.Label45)
        Me.GroupBox2.Controls.Add(Me.TBHalbbreite)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(12, 96)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(437, 85)
        Me.GroupBox2.TabIndex = 33
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Spline"
        '
        'BTOrdner
        '
        Me.BTOrdner.Location = New System.Drawing.Point(12, 415)
        Me.BTOrdner.Name = "BTOrdner"
        Me.BTOrdner.Size = New System.Drawing.Size(80, 23)
        Me.BTOrdner.TabIndex = 40
        Me.BTOrdner.Text = "Ordner öffnen"
        Me.BTOrdner.UseVisualStyleBackColor = True
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(171, 420)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(199, 13)
        Me.Label30.TabIndex = 43
        Me.Label30.Text = "Änderungen werden direkt übernommen!"
        '
        'BTSchließen
        '
        Me.BTSchließen.Location = New System.Drawing.Point(376, 415)
        Me.BTSchließen.Name = "BTSchließen"
        Me.BTSchließen.Size = New System.Drawing.Size(75, 23)
        Me.BTSchließen.TabIndex = 42
        Me.BTSchließen.Text = "Schließen"
        Me.BTSchließen.UseVisualStyleBackColor = True
        '
        'Frm_Eig_Sli
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(461, 450)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.BTSchließen)
        Me.Controls.Add(Me.BTOrdner)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Eig_Sli"
        Me.Text = "Eigenschaften"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label58 As Label
    Friend WithEvents TBHalbbreite As TextBox
    Friend WithEvents Label45 As Label
    Friend WithEvents TBLaenge As TextBox
    Friend WithEvents CBEditor As CheckBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label27 As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents BTPfad As Button
    Friend WithEvents TBPath As TextBox
    Friend WithEvents TBName As TextBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents BTOrdner As Button
    Friend WithEvents Label30 As Label
    Friend WithEvents BTSchließen As Button
End Class
