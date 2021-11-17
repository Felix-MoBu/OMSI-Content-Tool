<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Help
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Help))
        Me.WBMain = New System.Windows.Forms.WebBrowser()
        Me.SuspendLayout()
        '
        'WBMain
        '
        Me.WBMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WBMain.Location = New System.Drawing.Point(0, 0)
        Me.WBMain.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WBMain.Name = "WBMain"
        Me.WBMain.Size = New System.Drawing.Size(784, 561)
        Me.WBMain.TabIndex = 0
        Me.WBMain.Url = New System.Uri("", System.UriKind.Relative)
        '
        'Frm_Help
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.Controls.Add(Me.WBMain)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Frm_Help"
        Me.Text = "Hilfe"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents WBMain As WebBrowser
End Class
