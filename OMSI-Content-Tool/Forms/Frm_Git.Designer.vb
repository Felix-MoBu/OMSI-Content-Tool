<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Git
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Git))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LBBranches = New System.Windows.Forms.ComboBox()
        Me.TBUrl = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.BTPull = New System.Windows.Forms.Button()
        Me.BTPush = New System.Windows.Forms.Button()
        Me.BTGitignore = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TBPfad = New System.Windows.Forms.TextBox()
        Me.BTNeu = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "URL"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 67)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Branch"
        '
        'LBBranches
        '
        Me.LBBranches.FormattingEnabled = True
        Me.LBBranches.Location = New System.Drawing.Point(78, 64)
        Me.LBBranches.Name = "LBBranches"
        Me.LBBranches.Size = New System.Drawing.Size(121, 21)
        Me.LBBranches.TabIndex = 2
        '
        'TBUrl
        '
        Me.TBUrl.Location = New System.Drawing.Point(78, 38)
        Me.TBUrl.Name = "TBUrl"
        Me.TBUrl.Size = New System.Drawing.Size(308, 20)
        Me.TBUrl.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 93)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Username"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(78, 90)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(308, 20)
        Me.TextBox2.TabIndex = 5
        '
        'BTPull
        '
        Me.BTPull.Location = New System.Drawing.Point(392, 36)
        Me.BTPull.Name = "BTPull"
        Me.BTPull.Size = New System.Drawing.Size(55, 23)
        Me.BTPull.TabIndex = 6
        Me.BTPull.Text = "Pull"
        Me.BTPull.UseVisualStyleBackColor = True
        '
        'BTPush
        '
        Me.BTPush.Location = New System.Drawing.Point(453, 36)
        Me.BTPush.Name = "BTPush"
        Me.BTPush.Size = New System.Drawing.Size(55, 23)
        Me.BTPush.TabIndex = 7
        Me.BTPush.Text = "Push"
        Me.BTPush.UseVisualStyleBackColor = True
        '
        'BTGitignore
        '
        Me.BTGitignore.Location = New System.Drawing.Point(78, 116)
        Me.BTGitignore.Name = "BTGitignore"
        Me.BTGitignore.Size = New System.Drawing.Size(75, 23)
        Me.BTGitignore.TabIndex = 8
        Me.BTGitignore.Text = ".gitignore"
        Me.BTGitignore.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Lokaler Pfad"
        '
        'TBPfad
        '
        Me.TBPfad.Location = New System.Drawing.Point(78, 12)
        Me.TBPfad.Name = "TBPfad"
        Me.TBPfad.ReadOnly = True
        Me.TBPfad.Size = New System.Drawing.Size(430, 20)
        Me.TBPfad.TabIndex = 10
        '
        'BTNeu
        '
        Me.BTNeu.Location = New System.Drawing.Point(205, 63)
        Me.BTNeu.Name = "BTNeu"
        Me.BTNeu.Size = New System.Drawing.Size(75, 23)
        Me.BTNeu.TabIndex = 11
        Me.BTNeu.Text = "Neu"
        Me.BTNeu.UseVisualStyleBackColor = True
        '
        'Frm_Git
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(513, 153)
        Me.Controls.Add(Me.BTNeu)
        Me.Controls.Add(Me.TBPfad)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.BTGitignore)
        Me.Controls.Add(Me.BTPush)
        Me.Controls.Add(Me.BTPull)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TBUrl)
        Me.Controls.Add(Me.LBBranches)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Git"
        Me.Text = "Git-Optionen"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents LBBranches As ComboBox
    Friend WithEvents TBUrl As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents BTPull As Button
    Friend WithEvents BTPush As Button
    Friend WithEvents BTGitignore As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents TBPfad As TextBox
    Friend WithEvents BTNeu As Button
End Class
