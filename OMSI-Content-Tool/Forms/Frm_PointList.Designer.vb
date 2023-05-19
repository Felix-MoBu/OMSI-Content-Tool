<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_PointList
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
        Dim Point3D1 As O3D_Test.Point3D = New O3D_Test.Point3D()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_PointList))
        Me.TB0 = New System.Windows.Forms.TextBox()
        Me.PS0 = New O3D_Test.PointSelector()
        Me.BTSpeichern = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'TB0
        '
        Me.TB0.Location = New System.Drawing.Point(12, 12)
        Me.TB0.Name = "TB0"
        Me.TB0.Size = New System.Drawing.Size(166, 20)
        Me.TB0.TabIndex = 0
        Me.TB0.Tag = "0"
        '
        'PS0
        '
        Me.PS0.BackColor = System.Drawing.Color.Transparent
        Me.PS0.Location = New System.Drawing.Point(184, 12)
        Me.PS0.Max = 1.7976931348623157E+308R
        Me.PS0.Min = -1.7976931348623157E+308R
        Me.PS0.Name = "PS0"
        Me.PS0.Point = Point3D1
        Me.PS0.Size = New System.Drawing.Size(161, 20)
        Me.PS0.TabIndex = 1
        Me.PS0.Tag = "0"
        Me.PS0.X = 0R
        Me.PS0.Y = 0R
        Me.PS0.Z = 0R
        '
        'BTSpeichern
        '
        Me.BTSpeichern.Location = New System.Drawing.Point(270, 502)
        Me.BTSpeichern.Name = "BTSpeichern"
        Me.BTSpeichern.Size = New System.Drawing.Size(75, 23)
        Me.BTSpeichern.TabIndex = 2
        Me.BTSpeichern.Text = "Speichern"
        Me.BTSpeichern.UseVisualStyleBackColor = True
        '
        'Frm_PointList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(352, 531)
        Me.Controls.Add(Me.BTSpeichern)
        Me.Controls.Add(Me.PS0)
        Me.Controls.Add(Me.TB0)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Frm_PointList"
        Me.Text = "Gespeicherte Punkte"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TB0 As TextBox
    Friend WithEvents PS0 As PointSelector
    Friend WithEvents BTSpeichern As Button
End Class
