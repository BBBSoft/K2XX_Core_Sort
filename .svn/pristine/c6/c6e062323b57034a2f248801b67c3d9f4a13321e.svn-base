Public Class frmBrokenHousings

    Public BrokenAt As String = ""
    Private CenterPoint As Point
    Private Spanish As Boolean

    Public Sub New(CenterPoint As Point, Spanish As Boolean)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.CenterPoint = CenterPoint
        Me.Spanish = Spanish
    End Sub
    Private Sub frmBrokenHousings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim x As Integer = (CenterPoint.X) - (Me.Width / 2)
        Dim y As Integer = (CenterPoint.Y) - (Me.Height / 2)
        Me.Location = New Point(x, y)
        'If Spanish Then
        '    btnYoke.Text = "Housing Broken at Yoke"
        '    btnCenter.Text = "Housing Broken at Center"
        'Else
        '    btnYoke.Text = "Housing Broken at Yoke"
        '    btnCenter.Text = "Housing Broken at Center"
        'End If
    End Sub

    Private Sub btnYoke_Click(sender As Object, e As EventArgs) Handles btnYoke.Click
        BrokenAt = "Yoke"
        Me.Close()
    End Sub

    Private Sub btnCenter_Click(sender As Object, e As EventArgs) Handles btnCenter.Click
        BrokenAt = "Center"
        Me.Close()
    End Sub

    Private Sub btnBoth_Click(sender As Object, e As EventArgs) Handles btnBoth.Click
        BrokenAt = "Both"
        Me.Close()
    End Sub

    Private Sub frmBrokenHousings_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        If Me.WindowState <> FormWindowState.Normal Then
            Me.WindowState = FormWindowState.Normal
        End If
    End Sub


End Class