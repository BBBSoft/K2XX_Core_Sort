Imports System.Drawing.Printing

Public Class frmSelectPrinter
    Private LabelOffsetX As Integer = 0
    Private LabelOffsetY As Integer = 0
    Private PrinterName As String = ""

    Private Sub frmSelectPrinter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LabelOffsetX = My.Settings.OffsetX
        nudOffsetX.Value = LabelOffsetX

        LabelOffsetY = My.Settings.OffsetY
        nudOffsetY.Value = LabelOffsetY

        PrinterName = My.Settings.PrinterName
    End Sub

    Private Sub ComboBox1_Enter(sender As Object, e As EventArgs) Handles ComboBox1.Enter
        Dim pkInstalledPrinters As String
        ComboBox1.Items.Clear()
        ComboBox1.SelectedIndex = -1
        ComboBox1.Items.Add("No Printer Selected")

        ' Find all printers installed
        For Each pkInstalledPrinters In PrinterSettings.InstalledPrinters
            ComboBox1.Items.Add(pkInstalledPrinters)
        Next pkInstalledPrinters

        For i = 0 To ComboBox1.Items.Count - 1
            If ComboBox1.Items(i).ToString = PrinterName Then
                ComboBox1.SelectedIndex = i
            End If
        Next
        ' Set the combo to the first printer in the list

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If ComboBox1.SelectedIndex > -1 Then
            My.Settings.PrinterName = ComboBox1.Items(ComboBox1.SelectedIndex)
        End If
        My.Settings.OffsetX = LabelOffsetX
        My.Settings.OffsetY = LabelOffsetY
        My.Settings.Save()
        Me.Close()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        PrinterName = ComboBox1.Items(ComboBox1.SelectedIndex)
        OkToSave()
    End Sub

    Private Sub nudOffsetX_ValueChanged(sender As Object, e As EventArgs) Handles nudOffsetX.ValueChanged
        LabelOffsetX = nudOffsetX.Value
        OkToSave()
    End Sub

    Private Sub nudOffsetY_ValueChanged(sender As Object, e As EventArgs) Handles nudOffsetY.ValueChanged
        LabelOffsetY = nudOffsetY.Value
        OkToSave()
    End Sub
    Private Function OkToSave() As Boolean
        OkToSave = (LabelOffsetX <> My.Settings.OffsetX) Or
                   (LabelOffsetY <> My.Settings.OffsetY) Or
                   (PrinterName <> My.Settings.PrinterName)
        btnSave.Enabled = OkToSave
    End Function
End Class