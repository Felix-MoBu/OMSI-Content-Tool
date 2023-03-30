<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_FindMesh
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_FindMesh))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TBSuchen = New System.Windows.Forms.TextBox()
        Me.BTSuchen = New System.Windows.Forms.Button()
        Me.BTAbbrechen = New System.Windows.Forms.Button()
        Me.CBMesh = New System.Windows.Forms.CheckBox()
        Me.CBTexture = New System.Windows.Forms.CheckBox()
        Me.CBVariable = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Suchen nach:"
        '
        'TBSuchen
        '
        Me.TBSuchen.Location = New System.Drawing.Point(92, 12)
        Me.TBSuchen.Name = "TBSuchen"
        Me.TBSuchen.Size = New System.Drawing.Size(209, 20)
        Me.TBSuchen.TabIndex = 1
        '
        'BTSuchen
        '
        Me.BTSuchen.Location = New System.Drawing.Point(304, 10)
        Me.BTSuchen.Name = "BTSuchen"
        Me.BTSuchen.Size = New System.Drawing.Size(81, 23)
        Me.BTSuchen.TabIndex = 2
        Me.BTSuchen.Text = "Weitersuchen"
        Me.BTSuchen.UseVisualStyleBackColor = True
        '
        'BTAbbrechen
        '
        Me.BTAbbrechen.Location = New System.Drawing.Point(304, 39)
        Me.BTAbbrechen.Name = "BTAbbrechen"
        Me.BTAbbrechen.Size = New System.Drawing.Size(81, 23)
        Me.BTAbbrechen.TabIndex = 3
        Me.BTAbbrechen.Text = "Abbrechen"
        Me.BTAbbrechen.UseVisualStyleBackColor = True
        '
        'CBMesh
        '
        Me.CBMesh.AutoSize = True
        Me.CBMesh.Checked = True
        Me.CBMesh.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CBMesh.Enabled = False
        Me.CBMesh.Location = New System.Drawing.Point(15, 45)
        Me.CBMesh.Name = "CBMesh"
        Me.CBMesh.Size = New System.Drawing.Size(52, 17)
        Me.CBMesh.TabIndex = 4
        Me.CBMesh.Text = "Mesh"
        Me.CBMesh.UseVisualStyleBackColor = True
        '
        'CBTexture
        '
        Me.CBTexture.AutoSize = True
        Me.CBTexture.Enabled = False
        Me.CBTexture.Location = New System.Drawing.Point(92, 45)
        Me.CBTexture.Name = "CBTexture"
        Me.CBTexture.Size = New System.Drawing.Size(62, 17)
        Me.CBTexture.TabIndex = 5
        Me.CBTexture.Text = "Texture"
        Me.CBTexture.UseVisualStyleBackColor = True
        '
        'CBVariable
        '
        Me.CBVariable.AutoSize = True
        Me.CBVariable.Enabled = False
        Me.CBVariable.Location = New System.Drawing.Point(177, 45)
        Me.CBVariable.Name = "CBVariable"
        Me.CBVariable.Size = New System.Drawing.Size(64, 17)
        Me.CBVariable.TabIndex = 6
        Me.CBVariable.Text = "Variable"
        Me.CBVariable.UseVisualStyleBackColor = True
        '
        'Frm_FindMesh
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(389, 69)
        Me.Controls.Add(Me.CBVariable)
        Me.Controls.Add(Me.CBTexture)
        Me.Controls.Add(Me.CBMesh)
        Me.Controls.Add(Me.BTAbbrechen)
        Me.Controls.Add(Me.BTSuchen)
        Me.Controls.Add(Me.TBSuchen)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(405, 108)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(405, 108)
        Me.Name = "Frm_FindMesh"
        Me.Text = "Suchen"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents TBSuchen As TextBox
    Friend WithEvents BTSuchen As Button
    Friend WithEvents BTAbbrechen As Button
    Friend WithEvents CBMesh As CheckBox
    Friend WithEvents CBTexture As CheckBox
    Friend WithEvents CBVariable As CheckBox
End Class
