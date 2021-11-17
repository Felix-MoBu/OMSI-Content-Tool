<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm_VarTest
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_VarTest))
        Me.VS_0 = New O3D_Test.VarSelector()
        Me.BT_0 = New System.Windows.Forms.Button()
        Me.BTHinzu = New System.Windows.Forms.Button()
        Me.TB_0 = New System.Windows.Forms.TextBox()
        Me.RM_0 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'VS_0
        '
        Me.VS_0.Location = New System.Drawing.Point(12, 12)
        Me.VS_0.Name = "VS_0"
        Me.VS_0.Size = New System.Drawing.Size(178, 20)
        Me.VS_0.TabIndex = 0
        Me.VS_0.Variable = ""
        '
        'BT_0
        '
        Me.BT_0.Location = New System.Drawing.Point(196, 11)
        Me.BT_0.Name = "BT_0"
        Me.BT_0.Size = New System.Drawing.Size(75, 23)
        Me.BT_0.TabIndex = 1
        Me.BT_0.Text = "Trigger"
        Me.BT_0.UseVisualStyleBackColor = True
        '
        'BTHinzu
        '
        Me.BTHinzu.Location = New System.Drawing.Point(277, 39)
        Me.BTHinzu.Name = "BTHinzu"
        Me.BTHinzu.Size = New System.Drawing.Size(75, 23)
        Me.BTHinzu.TabIndex = 2
        Me.BTHinzu.Text = "Hinzufügen"
        Me.BTHinzu.UseVisualStyleBackColor = True
        '
        'TB_0
        '
        Me.TB_0.Location = New System.Drawing.Point(277, 13)
        Me.TB_0.Name = "TB_0"
        Me.TB_0.Size = New System.Drawing.Size(75, 20)
        Me.TB_0.TabIndex = 3
        Me.TB_0.Text = "0"
        '
        'RM_0
        '
        Me.RM_0.Location = New System.Drawing.Point(358, 11)
        Me.RM_0.Name = "RM_0"
        Me.RM_0.Size = New System.Drawing.Size(19, 23)
        Me.RM_0.TabIndex = 4
        Me.RM_0.Text = "-"
        Me.RM_0.UseVisualStyleBackColor = True
        Me.RM_0.Visible = False
        '
        'Frm_VarTest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(384, 673)
        Me.Controls.Add(Me.RM_0)
        Me.Controls.Add(Me.TB_0)
        Me.Controls.Add(Me.BTHinzu)
        Me.Controls.Add(Me.BT_0)
        Me.Controls.Add(Me.VS_0)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(400, 4096)
        Me.MinimumSize = New System.Drawing.Size(400, 200)
        Me.Name = "Frm_VarTest"
        Me.Text = "Variablen-Test"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents VS_0 As VarSelector
    Friend WithEvents BT_0 As Button
    Friend WithEvents BTHinzu As Button
    Friend WithEvents TB_0 As TextBox
    Friend WithEvents RM_0 As Button
End Class
