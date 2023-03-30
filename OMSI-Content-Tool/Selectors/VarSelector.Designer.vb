<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VarSelector
    Inherits System.Windows.Forms.UserControl

    'UserControl überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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
        Me.TBVar = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'TBVar
        '
        Me.TBVar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.TBVar.Location = New System.Drawing.Point(0, 0)
        Me.TBVar.Name = "TBVar"
        Me.TBVar.ReadOnly = True
        Me.TBVar.Size = New System.Drawing.Size(100, 20)
        Me.TBVar.TabIndex = 0
        '
        'VarSelector
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TBVar)
        Me.Name = "VarSelector"
        Me.Size = New System.Drawing.Size(100, 20)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Public WithEvents TBVar As TextBox
End Class
