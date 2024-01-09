Imports BBBLib

Public Class Reprint
    Private LabelTypes As String = ""
    Private GetLabelsPrinted As DataTable


    Private LT As String = ""
    Private TS As Date
    Private PN As String = ""
    Private SN As String = ""
    Private Line3 As String = ""
    Private BarCodeInfo As String = ""

    Public Sub New(LabelTypes As String())
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Try
            Me.LabelTypes = "'" + String.Join("','", LabelTypes) + "'"
        Catch ex As Exception
            Me.LabelTypes = ""
        End Try

    End Sub
    Private Sub Reprint_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Reprint_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        GetLabelsPrinted = Sql.GetLabelsPrinted(Me.LabelTypes)

        dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        dgvData.MultiSelect = False
        dgvData.DataSource = GetLabelsPrinted
        dgvData.ClearSelection()
        dgvData.Columns(0).DefaultCellStyle.Format = "MM/dd/yyyy HH:mm:ss"
        dgvData.AutoResizeColumns()

    End Sub

    Private Sub dgvData_CellContentClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvData.CellContentClick
        LT = dgvData.Rows(e.RowIndex).Cells("Label Type").Value.ToString
        TS = dgvData.Rows(e.RowIndex).Cells("TS").Value
        PN = dgvData.Rows(e.RowIndex).Cells("PN").Value.ToString
        SN = dgvData.Rows(e.RowIndex).Cells("SN").Value.ToString
        Line3 = dgvData.Rows(e.RowIndex).Cells("Line3").Value.ToString
        BarCodeInfo = dgvData.Rows(e.RowIndex).Cells("BarCode Info").Value.ToString
        btnRePrint.Enabled = True

        lblLabelType.Text = LT
        lblTimeStamp.Text = TS.ToString("MM/dd/yy HH:mm:ss")
        lblPN.Text = PN
        lblSN.Text = SN

    End Sub

    Private Sub btnRePrint_Click(sender As Object, e As EventArgs) Handles btnRePrint.Click
        btnRePrint.Enabled = False

        'Dim sArray As String() = {Labels.eLabelType.AMAM.ToString, Labels.eLabelType.Mopar.ToString}
        ''Dim sArray As New List(Of String)
        ''sArray.Add(Labels.eLabelType.AMAM.ToString)
        ''sArray.Add(Labels.eLabelType.Mopar.ToString)

        ''Dim str As String = String.Join(",", sArray.Select(x >= String.Format("'{0}'", x)))
        'Dim str As String = "'" + String.Join("','", sArray) + "'"

        Dim lblType As Labels.eLabelType = Labels.eLabelType.UnAssigned

        Try
            lblType = DirectCast([Enum].Parse(GetType(Labels.eLabelType), LT), Labels.eLabelType)
        Catch ex As Exception
            MsgBox("Error Setting Label Type!")
            ClearSelected()
            Exit Sub
        End Try

        Labels.setupPrtdoc(lblType, True)
        Dim LabelData As Object() = {PN,
                                     SN,
                                     Line3,
                                     BarCodeInfo}
        Labels.SetLabelData(LabelData)
        Labels.PrtDoc.Print()
        ClearSelected()
    End Sub


    Private Sub ClearSelected()
        lblLabelType.Text = ""
        lblTimeStamp.Text = ""
        lblPN.Text = ""
        lblSN.Text = ""
    End Sub
    '  Labels.setupPrtdoc(Labels.eLabelType.SNOnly, False)
    '  Dim BC As String = "XXYY17XX000"
    '  Labels.SetLabelData("", "XXYY17XX000", "", BC)
    '  Labels.PrtDoc.Print()
End Class