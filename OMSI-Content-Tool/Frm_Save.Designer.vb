<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Save
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Save))
        Me.LBProjDatei = New System.Windows.Forms.Label()
        Me.BTProj = New System.Windows.Forms.Button()
        Me.TBProj = New System.Windows.Forms.TextBox()
        Me.TBModel = New System.Windows.Forms.TextBox()
        Me.BTModel = New System.Windows.Forms.Button()
        Me.LBModelDatei = New System.Windows.Forms.Label()
        Me.BTSpeichern = New System.Windows.Forms.Button()
        Me.BTAbbr = New System.Windows.Forms.Button()
        Me.CBExtraModel = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'LBProjDatei
        '
        Me.LBProjDatei.AutoSize = True
        Me.LBProjDatei.Location = New System.Drawing.Point(12, 15)
        Me.LBProjDatei.Name = "LBProjDatei"
        Me.LBProjDatei.Size = New System.Drawing.Size(53, 13)
        Me.LBProjDatei.TabIndex = 0
        Me.LBProjDatei.Text = "Bus-Datei"
        '
        'BTProj
        '
        Me.BTProj.Location = New System.Drawing.Point(688, 11)
        Me.BTProj.Name = "BTProj"
        Me.BTProj.Size = New System.Drawing.Size(80, 23)
        Me.BTProj.TabIndex = 1
        Me.BTProj.Text = "Durchsuchen"
        Me.BTProj.UseVisualStyleBackColor = True
        '
        'TBProj
        '
        Me.TBProj.Location = New System.Drawing.Point(82, 12)
        Me.TBProj.Name = "TBProj"
        Me.TBProj.Size = New System.Drawing.Size(600, 20)
        Me.TBProj.TabIndex = 2
        '
        'TBModel
        '
        Me.TBModel.Location = New System.Drawing.Point(82, 41)
        Me.TBModel.Name = "TBModel"
        Me.TBModel.Size = New System.Drawing.Size(600, 20)
        Me.TBModel.TabIndex = 5
        '
        'BTModel
        '
        Me.BTModel.Location = New System.Drawing.Point(688, 40)
        Me.BTModel.Name = "BTModel"
        Me.BTModel.Size = New System.Drawing.Size(80, 23)
        Me.BTModel.TabIndex = 4
        Me.BTModel.Text = "Durchsuchen"
        Me.BTModel.UseVisualStyleBackColor = True
        '
        'LBModelDatei
        '
        Me.LBModelDatei.AutoSize = True
        Me.LBModelDatei.Location = New System.Drawing.Point(12, 44)
        Me.LBModelDatei.Name = "LBModelDatei"
        Me.LBModelDatei.Size = New System.Drawing.Size(64, 13)
        Me.LBModelDatei.TabIndex = 3
        Me.LBModelDatei.Text = "Model-Datei"
        '
        'BTSpeichern
        '
        Me.BTSpeichern.Location = New System.Drawing.Point(688, 69)
        Me.BTSpeichern.Name = "BTSpeichern"
        Me.BTSpeichern.Size = New System.Drawing.Size(80, 23)
        Me.BTSpeichern.TabIndex = 6
        Me.BTSpeichern.Text = "Speichern"
        Me.BTSpeichern.UseVisualStyleBackColor = True
        '
        'BTAbbr
        '
        Me.BTAbbr.Location = New System.Drawing.Point(602, 69)
        Me.BTAbbr.Name = "BTAbbr"
        Me.BTAbbr.Size = New System.Drawing.Size(80, 23)
        Me.BTAbbr.TabIndex = 7
        Me.BTAbbr.Text = "Abbrechen"
        Me.BTAbbr.UseVisualStyleBackColor = True
        '
        'CBExtraModel
        '
        Me.CBExtraModel.AutoSize = True
        Me.CBExtraModel.Location = New System.Drawing.Point(82, 72)
        Me.CBExtraModel.Name = "CBExtraModel"
        Me.CBExtraModel.Size = New System.Drawing.Size(131, 17)
        Me.CBExtraModel.TabIndex = 8
        Me.CBExtraModel.Text = "Separate Modell-Datei"
        Me.CBExtraModel.UseVisualStyleBackColor = True
        Me.CBExtraModel.Visible = False
        '
        'Frm_Save
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 101)
        Me.Controls.Add(Me.CBExtraModel)
        Me.Controls.Add(Me.BTAbbr)
        Me.Controls.Add(Me.BTSpeichern)
        Me.Controls.Add(Me.TBModel)
        Me.Controls.Add(Me.BTModel)
        Me.Controls.Add(Me.LBModelDatei)
        Me.Controls.Add(Me.TBProj)
        Me.Controls.Add(Me.BTProj)
        Me.Controls.Add(Me.LBProjDatei)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(800, 140)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(800, 140)
        Me.Name = "Frm_Save"
        Me.Text = "Speichern unter..."
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LBProjDatei As Label
    Friend WithEvents BTProj As Button
    Friend WithEvents TBProj As TextBox
    Friend WithEvents TBModel As TextBox
    Friend WithEvents BTModel As Button
    Friend WithEvents LBModelDatei As Label
    Friend WithEvents BTSpeichern As Button
    Friend WithEvents BTAbbr As Button
    Friend WithEvents CBExtraModel As CheckBox
End Class
