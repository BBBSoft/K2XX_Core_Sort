Public Class frmAlertWindow

    Private Unit As UnitWatch.sUnitWatch

    Public Sub New(unit As UnitWatch.sUnitWatch)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.Unit = unit
        Me.ShowDialog()

    End Sub

    Private Sub frmAlertWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblMessage1.Text = Unit.WatchMessage1
        lblMessage2.Text = Unit.Instructions1
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub frmAlertWindow_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.Refresh()
    End Sub
End Class