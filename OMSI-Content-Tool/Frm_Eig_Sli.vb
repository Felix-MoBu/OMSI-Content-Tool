'by Felix Modellbusse ;) (MoBu) 2019
Imports System.ComponentModel

Public Class Frm_Eig_Sli
    Public Projekt_Sli As Proj_Sli

    Private Sub Frm_Eig_Sli_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Location = New Point(Frm_Main.Width / 2 - Me.Width / 2, Frm_Main.Height / 2 - Me.Height / 2)

        With Projekt_Sli
            TBName.Text = .filename.name
            TBPath.Text = .filename.path
            TBLaenge.Text = .length
            TBHalbbreite.Text = .halfcantwidth
            CBEditor.Checked = .onlyeditor
        End With
    End Sub

    Private Sub BTSchließen_Click(sender As Object, e As EventArgs) Handles BTSchließen.Click
        Me.Close()
    End Sub

    Private Sub Frm_Eig_Sli_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        With Projekt_Sli
            .filename.name = TBName.Text
            .filename.path = TBPath.Text
            .length = TBLaenge.Text
            .halfcantwidth = TBHalbbreite.Text
            .onlyeditor = CBEditor.Checked
        End With
    End Sub
End Class