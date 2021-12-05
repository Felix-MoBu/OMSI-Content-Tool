<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Loading
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
        Me.PBMain = New System.Windows.Forms.ProgressBar()
        Me.LBInfo = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'PBMain
        '
        Me.PBMain.Location = New System.Drawing.Point(12, 12)
        Me.PBMain.Name = "PBMain"
        Me.PBMain.Size = New System.Drawing.Size(360, 23)
        Me.PBMain.TabIndex = 0
        '
        'LBInfo
        '
        Me.LBInfo.AutoSize = True
        Me.LBInfo.Location = New System.Drawing.Point(12, 53)
        Me.LBInfo.Name = "LBInfo"
        Me.LBInfo.Size = New System.Drawing.Size(39, 13)
        Me.LBInfo.TabIndex = 1
        Me.LBInfo.Text = "Label1"
        '
        'Frm_Loading
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(384, 89)
        Me.Controls.Add(Me.LBInfo)
        Me.Controls.Add(Me.PBMain)
        Me.Name = "Frm_Loading"
        Me.Text = "Frm_Loading"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PBMain As ProgressBar
    Friend WithEvents LBInfo As Label
End Class
