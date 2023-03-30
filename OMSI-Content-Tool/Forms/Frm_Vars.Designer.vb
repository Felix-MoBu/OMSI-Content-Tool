<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Vars
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Vars))
        Me.TBFilter = New System.Windows.Forms.TextBox()
        Me.LBAlleVars = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LBLetzteVars = New System.Windows.Forms.ListBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BTKeine = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'TBFilter
        '
        Me.TBFilter.Location = New System.Drawing.Point(12, 23)
        Me.TBFilter.Name = "TBFilter"
        Me.TBFilter.Size = New System.Drawing.Size(200, 20)
        Me.TBFilter.TabIndex = 0
        '
        'LBAlleVars
        '
        Me.LBAlleVars.FormattingEnabled = True
        Me.LBAlleVars.Location = New System.Drawing.Point(12, 64)
        Me.LBAlleVars.Name = "LBAlleVars"
        Me.LBAlleVars.ScrollAlwaysVisible = True
        Me.LBAlleVars.Size = New System.Drawing.Size(200, 381)
        Me.LBAlleVars.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Filter"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Alle Variablen"
        '
        'LBLetzteVars
        '
        Me.LBLetzteVars.FormattingEnabled = True
        Me.LBLetzteVars.Location = New System.Drawing.Point(218, 64)
        Me.LBLetzteVars.Name = "LBLetzteVars"
        Me.LBLetzteVars.ScrollAlwaysVisible = True
        Me.LBLetzteVars.Size = New System.Drawing.Size(200, 381)
        Me.LBLetzteVars.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(215, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(145, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Zuletzt verwendete Variablen"
        '
        'BTKeine
        '
        Me.BTKeine.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTKeine.Location = New System.Drawing.Point(343, 23)
        Me.BTKeine.Name = "BTKeine"
        Me.BTKeine.Size = New System.Drawing.Size(75, 23)
        Me.BTKeine.TabIndex = 7
        Me.BTKeine.Text = "KEINE"
        Me.BTKeine.UseVisualStyleBackColor = True
        '
        'Frm_Vars
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(427, 454)
        Me.Controls.Add(Me.BTKeine)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.LBLetzteVars)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LBAlleVars)
        Me.Controls.Add(Me.TBFilter)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(443, 493)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(443, 493)
        Me.Name = "Frm_Vars"
        Me.Text = "Variable Auswählen"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TBFilter As TextBox
    Friend WithEvents LBAlleVars As ListBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents LBLetzteVars As ListBox
    Friend WithEvents Label3 As Label
    Friend WithEvents BTKeine As Button
End Class
