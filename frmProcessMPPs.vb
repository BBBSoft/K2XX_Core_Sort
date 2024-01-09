'
' Added by Enrique Juarez 2020-08-11
'
Imports System.ComponentModel
Imports BBB_Printing.K2xxCoreSortLabel

Public Class frmProcessMPPs
    Private ProcessUnTagedMPP As Boolean = False
    Private frmClrDTCs As BBBLib.frmClearDTCs

    Public RFIDidx As Integer = -1
    Public Constring As String = ""
    Public Disposition As String = ""
    Public BIN As String = ""
    Public MPP_BIN As String = ""
    Public ConnectorsBroken As String = ""
    Public AllGoodDTCs As String = ""
    Public VisualInspection As String = ""
    Public Scrap As Boolean = False
    ' Added by Enrique Juarez 2020-08-11
    Public DTCs As String = ""
    'Private ItemsList1 As String(,) = {
    '    {"Damaged Housing", "Dmgd Hsng"},
    '    {"Damaged Connector", "Dmgd Conn"},
    '    {"Crevice Corrosion", "Crev Corr"},
    '    {"Water Ingresion", "Wtr Ingr"}
    '}
    Private ItemsList1 As String(,) = {
        {"Damaged Housing", "Dmgd Hsng"},
        {"Damaged Connector", "Dmgd Conn"},
        {"Water Ingresion", "Wtr Ingr"}
    }
    'Remove MPP :  BIN # 1 - 38029554CH (MPP BIN 3)
    'Remove MPP :  BIN # 2 - 38239062CH (MPP BIN 4)
    'Remove MPP: BIN # 2 - 38239062C (MPP BIN 2)
    'Remove MPP: BIN # 1 - 38029554C (MPP BIN 1)

    'Added by Enrique Juarez 2020-08-11
    Private Sub LoadListItems()
        CheckedListBox1.Items.Clear()
        For Idx = 0 To (ItemsList1.Length / 2) - 1
            CheckedListBox1.Items.Add(ItemsList1(Idx, 0))
        Next
    End Sub

    Private Sub frmProcessMPPs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Process K2XX MPP Reman. v" + BBBLib.Func.theAppVersion

        Gvars.ProductType = Gvars.eProductType.K2XX_GM__AC_Delco

        ' Added by Enrique Juarez 2020-08-11
        LoadListItems()
        ClearData()
        tmrBtnFlash.Enabled = True
        Gvars.GetDTCsForK2XXMPPReman()
        tt.SetToolTip(btnStartInhale, Gvars.InhalePrg.AppPath)

    End Sub

    Public Sub RFIDScanned(Data As String)
        If lblRFIDTag.Text.Trim.Length = 0 Then
            SetTextBoxWithInvoke(Me.lblRFIDTag, Data)
        End If
    End Sub

    Private Sub lblRFIDTag_Click(sender As Object, e As EventArgs) Handles lblRFIDTag.Click
        If lblRFIDTag.Text.Trim.Length = 0 And AltKey Then
            Dim ans As String = InputBox("Enter RFID tag #")
            If ans.Trim.Length = 10 Then
                SetTextBoxWithInvoke(Me.lblRFIDTag, ans)
            End If
            AltKey = False
        End If
    End Sub

    Private Delegate Sub SetLabelTextDelegate(ByVal LB As Label, ByVal txt As String)

    Private Sub SetTextBoxWithInvoke(ByVal LB As Label, ByVal txt As String)
        If LB.InvokeRequired Then
            LB.Invoke(New SetLabelTextDelegate(AddressOf SetTextBoxWithInvoke), New Object() {LB, txt})
        Else
            LB.Text = txt
        End If
    End Sub

    Private Sub lblRFIDTag_TextChanged(sender As Object, e As EventArgs) Handles lblRFIDTag.TextChanged

        If lblRFIDTag.Text = "" Then
            Me.ControlBox = True
            Exit Sub
        Else
            Me.ControlBox = False
        End If


        If ProcessUnTagedMPP = False Then
            ProcessExistingRFIDtag(lblRFIDTag.Text)
        Else
            CheckMPPOnlyRFIDtag(lblRFIDTag.Text)
        End If


    End Sub


    Private Sub ProcessExistingRFIDtag(RFIDTag As String)

        Dim ds As New BBBLib.SQL.dsDataSet(Constring, "SELECT * FROM [EPSData].[dbo].[K2XX_CoreSort] WHERE [RFIDtag]=@RFIDtag AND [Status]=1 ORDER BY TS DESC;", {{"@RFIDTag", RFIDTag}})
        BBBLib.SQL.RunSQLQuery(ds)

        Dim dt As DataTable = ds.rtDataSet.Tables(0)

        dgv.DataSource = dt

        ' Added by Enrique Juarez 2020-08-11
        DTCs = ""
        If (dt.Rows.Count > 0) Then
            If (dt.Rows(0)("NoComm").ToString().Equals("False")) Then
                If (dt.Rows(0)("BadDTCs").ToString().Equals("True")) Then
                    DTCs = "DTCs:" & dt.Rows(0)("UnacceptableDTCs").ToString() & ";"
                End If
            Else
                DTCs = "NoComm;"
            End If
        Else
            MessageBox.Show("RFID no existe. Verifica por favor!", "Aviso...", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ClearData()
            Return
        End If
        ' End Adding

        BIN = GetData(dt, "BIN")
        lblCurrentBIN.Text = ""
        RFIDidx = CInt(GetData(dt, "idx"))
        'MPP_BIN = GetData(dt, "MPP_BIN")
        'ConnectorsBroken = GetData(dt, "ConnectorsBroken")
        'AllGoodDTCs = GetData(dt, "AllGoodDTCs")
        Gvars.MyData.BadUnit = False

        If BIN.Contains("Remove MPP") Then
            If BIN.Contains("1 - 38029554CH") Then
                lblCurrentBIN.Text = "P/N: 38029554CH"
                MPP_BIN = "MPP BIN # 3"
                'Added by Enrique Juarez 2020-08-11
                lblDisposition.ForeColor = Color.Black
                lblDisposition.BackColor = Color.SkyBlue
                'Panel4.Visible = True
                Gvars.MyData.BadUnit = True

            ElseIf BIN.Contains("2 - 38239062CH") Then
                lblCurrentBIN.Text = "P/N: 38239062CH"
                MPP_BIN = "MPP BIN # 4"
                'Added by Enrique Juarez 2020-08-11
                lblDisposition.ForeColor = Color.Black
                lblDisposition.BackColor = Color.SkyBlue
                'Panel4.Visible = True
                Gvars.MyData.BadUnit = True

            ElseIf BIN.Contains("1 - 38029554C") Then
                lblCurrentBIN.Text = "P/N: 38029554C"
                MPP_BIN = "MPP BIN # 1"
                'Added by Enrique Juarez 2020-08-11
                lblDisposition.ForeColor = Color.Black
                lblDisposition.BackColor = Color.FromArgb(241, 213, 146)
                lblDisposition.BackColor = Color.Orange

            ElseIf BIN.Contains("2 - 38239062C") Then
                lblCurrentBIN.Text = "P/N: 38239062C"
                MPP_BIN = "MPP BIN # 2"
                'Added by Enrique Juarez 2020-08-11
                lblDisposition.ForeColor = Color.Black
                lblDisposition.BackColor = Color.FromArgb(241, 213, 146)
                lblDisposition.BackColor = Color.Orange

            Else
                lblCurrentBIN.Text = ""
                MPP_BIN = "Invalid"
                'Added by Enrique Juarez 2020-08-11
                lblDisposition.ForeColor = Color.Black
                lblDisposition.BackColor = Color.Yellow
                Gvars.MyData.BadUnit = True

            End If
        Else
            'Invalid BIN
            MPP_BIN = "Invalid"
            'Added by Enrique Juarez 2020-08-11
            lblDisposition.ForeColor = Color.Black
            lblDisposition.BackColor = Color.FromArgb(241, 213, 146)
        End If

        lblDisposition.Text = MPP_BIN

        'If MPP_BIN = "Invalid" Then
        '    Panel2.Visible = True
        'ElseIf MPP_BIN.Contains("MPP BIN # 1") Then
        '    Panel1.Visible = True
        'ElseIf MPP_BIN.Contains("MPP BIN # 2") Then
        '    Panel1.Visible = True
        'Else
        '    Panel2.Visible = True
        'End If

        'Remove MPP :  BIN # 1 - 38029554CH (MPP BIN 3)
        'Remove MPP :  BIN # 2 - 38239062CH (MPP BIN 4)
        'Remove MPP: BIN # 1 - 38029554C (MPP BIN 1)
        'Remove MPP: BIN # 2 - 38239062C (MPP BIN 2)
        Panel1.Visible = True
        'panelCC1.Visible = True

    End Sub

    Private Sub ProcessMPPwithoutRFIDTag()

        Dim dt As DataTable = dgv.DataSource

        ' Added by Enrique Juarez 2020-08-11
        DTCs = ""

        If Gvars.MyData.UnacceptableDTCs <> "" Then
            DTCs = "DTCs:" & Gvars.MyData.UnacceptableDTCs & ";"
        ElseIf Gvars.MyData.NoComm Then
            DTCs = "NoComm;"
        End If

        'If (dt.Rows.Count > 0) Then
        '    If (dt.Rows(0)("NoComm").ToString().Equals("False")) Then
        '        If (dt.Rows(0)("BadDTCs").ToString().Equals("True")) Then
        '            DTCs = "DTCs:" & dt.Rows(0)("UnacceptableDTCs").ToString() & ";"
        '        End If
        '    Else
        '        DTCs = "NoComm;"
        '    End If
        'Else
        '    MessageBox.Show("RFID no existe. Verifica por favor!", "Aviso...", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    ClearData()
        '    Return
        'End If
        ' End Adding

        'BIN = GetData(dt, "BIN")
        BIN = ""
        lblCurrentBIN.Text = ""
        'RFIDidx = CInt(GetData(dt, "idx"))
        ''MPP_BIN = GetData(dt, "MPP_BIN")
        ''ConnectorsBroken = GetData(dt, "ConnectorsBroken")
        ''AllGoodDTCs = GetData(dt, "AllGoodDTCs")

        If (Gvars.MyData.SoftwareVersion1 Like "*K2xx_12*") Then
            BIN = "Remove MPP: BIN # 2 - 38239062C"
        Else
            BIN = "Remove MPP: BIN # 1 - 38029554C"
        End If


        If Gvars.MyData.AllGoodDTCs = True And Gvars.MyData.OnBlackList_MPP = False Then
            If Gvars.MyData.SoftwareVersion1.Trim = "" Then

                lblCurrentBIN.Text = ""
                MPP_BIN = "Invalid"
                'Added by Enrique Juarez 2020-08-11
                lblDisposition.ForeColor = Color.Black
                lblDisposition.BackColor = Color.Yellow

            ElseIf Not (Gvars.MyData.SoftwareVersion1 Like "*K2xx_12*") Then
                lblCurrentBIN.Text = "P/N: 38029554C"
                MPP_BIN = "MPP BIN # 1"
                'Added by Enrique Juarez 2020-08-11
                lblDisposition.ForeColor = Color.Black
                lblDisposition.BackColor = Color.SkyBlue
                Panel1.Visible = True

            ElseIf (Gvars.MyData.SoftwareVersion1 Like "*K2xx_12*") Then
                lblCurrentBIN.Text = "P/N: 38239062C"
                MPP_BIN = "MPP BIN # 2"
                'Added by Enrique Juarez 2020-08-11
                lblDisposition.ForeColor = Color.Black
                lblDisposition.BackColor = Color.SkyBlue
                Panel1.Visible = True

            End If
        ElseIf (Gvars.MyData.BadDTCFound = True) Or (Gvars.MyData.OnBlackList_MPP = True) Then
            If Gvars.MyData.SoftwareVersion1.Trim = "" Then
                lblCurrentBIN.Text = ""
                MPP_BIN = "Invalid"
                'Added by Enrique Juarez 2020-08-11
                lblDisposition.ForeColor = Color.Black
                lblDisposition.BackColor = Color.Yellow

            ElseIf Not (Gvars.MyData.SoftwareVersion1 Like "*K2xx_12*") Then
                lblCurrentBIN.Text = "P/N: 38029554CH"
                MPP_BIN = "MPP BIN # 3"
                'Added by Enrique Juarez 2020-08-11
                lblDisposition.ForeColor = Color.Black
                lblDisposition.BackColor = Color.SkyBlue
                Panel1.Visible = True
                btnGood.Enabled = False
                ' btnBad_Click(Me, New EventArgs)
                Gvars.MyData.BadUnit = True

            ElseIf (Gvars.MyData.SoftwareVersion1 Like "*K2xx_12*") Then
                lblCurrentBIN.Text = "P/N: 38239062CH"
                MPP_BIN = "MPP BIN # 4"
                'Added by Enrique Juarez 2020-08-11
                lblDisposition.ForeColor = Color.Black
                lblDisposition.BackColor = Color.SkyBlue
                Panel1.Visible = True
                btnGood.Enabled = False
                ' btnBad_Click(Me, New EventArgs)
                Gvars.MyData.BadUnit = True

            End If

        Else
            'Invalid BIN
            MPP_BIN = "Invalid"
            'Added by Enrique Juarez 2020-08-11
            lblDisposition.ForeColor = Color.Black
            lblDisposition.BackColor = Color.FromArgb(241, 213, 146)
        End If

        lblDisposition.Text = MPP_BIN

        If MPP_BIN = "Invalid" Then
            Panel2.Visible = True
        ElseIf MPP_BIN.Contains("MPP BIN # 1") Then
            Panel1.Visible = True
        ElseIf MPP_BIN.Contains("MPP BIN # 2") Then
            Panel1.Visible = True
        Else
            Panel2.Visible = True
        End If
        'Remove MPP :  BIN # 1 - 38029554CH (MPP BIN 3)
        'Remove MPP :  BIN # 2 - 38239062CH (MPP BIN 4)
        'Remove MPP: BIN # 1 - 38029554C (MPP BIN 1)
        'Remove MPP: BIN # 2 - 38239062C (MPP BIN 2)


    End Sub
    Private Function GetData(dt As DataTable, Field As String) As String
        If IsDBNull(dt.Rows(0)(Field)) Then
            GetData = ""
        Else
            GetData = dt.Rows(0)(Field)
        End If
    End Function

    Private Sub btnBad_Click(sender As Object, e As EventArgs) Handles btnBad.Click
        If Gvars.MyData.BadUnit = True Then
            btnGood.Enabled = False
        End If

        btnGood.BackColor = Color.FromKnownColor(KnownColor.Control)
        btnBad.BackColor = Color.FromKnownColor(KnownColor.LightSalmon)
        VisualInspection = "Bad"
        Gvars.MyData.TagColor = Gvars.eTagColor.Blue

        If BIN.Contains("1 - 38029554C") Then
            MPP_BIN = "MPP BIN # 3"
        ElseIf BIN.Contains("2 - 38239062C") Then
            MPP_BIN = "MPP BIN # 4"
        End If
        lblDisposition.Text = MPP_BIN
        lblDisposition.ForeColor = Color.Black
        lblDisposition.BackColor = Color.SkyBlue

        'btnSave.Enabled = True
        'Panel2.Visible = True
        Panel3.Visible = True
        ReasonList = ""
        CheckedListBox2.Visible = False
        CheckedListBox1.Visible = True

        If Gvars.MyData.CreviceCorrosionPresent = 1 And Gvars.MyData.CreviceCorrosionAcceptable = 0 Then
            ReasonList = "Crev Corr"
            Gvars.MyData.TagColor = Gvars.eTagColor.Red
            Panel2.Visible = True
        End If

        SetBinAndColor()

        ProcessReasonlist1()
    End Sub

    Private Sub btnGood_Click(sender As Object, e As EventArgs) Handles btnGood.Click
        btnBad.BackColor = Color.FromKnownColor(KnownColor.Control)
        btnGood.BackColor = Color.FromKnownColor(KnownColor.LightGreen)
        VisualInspection = "Good"

        Gvars.MyData.TagColor = Gvars.eTagColor.Manila


        If BIN.Contains("1 - 38029554C") Then
            MPP_BIN = "MPP BIN # 1"
        ElseIf BIN.Contains("2 - 38239062C") Then
            MPP_BIN = "MPP BIN # 2"
        End If

        lblDisposition.Text = MPP_BIN
        'Added by Enrique Juarez 2020-08-11
        lblDisposition.ForeColor = Color.Black
        lblDisposition.BackColor = Color.FromArgb(241, 213, 146)
        'lblDisposition.BackColor = Color.Orange

        'btnSave.Enabled = True
        ReasonList = ""
        Panel2.Visible = True
        Panel3.Visible = True
        CheckedListBox2.Visible = True
        CheckedListBox1.Visible = False

        CheckedListBox2.Visible = False
        If Gvars.MyData.CreviceCorrosionPresent = 1 And Gvars.MyData.CreviceCorrosionAcceptable = 1 Then
            Gvars.MyData.TagColor = Gvars.eTagColor.Orange
            ReasonList = "Acceptable Crevice Corrosion"
        End If

        If Gvars.MyData.CreviceCorrosionPresent = 1 And Gvars.MyData.CreviceCorrosionAcceptable = 0 Then
            Gvars.MyData.TagColor = Gvars.eTagColor.Red
            ReasonList = "Crev Corr"
        End If

        SetBinAndColor()

    End Sub
    Private Sub SetBinAndColor()
        Scrap = False

        If (MPP_BIN = "Invalid") And (Gvars.MyData.CreviceCorrosionPresent = 1 And Gvars.MyData.CreviceCorrosionAcceptable = 0) Then
            Gvars.MyData.TagColor = Gvars.eTagColor.Red
            MPP_BIN = "Scrap"
            lblDisposition.Text = MPP_BIN
            lblDisposition.ForeColor = Color.Yellow
            lblDisposition.BackColor = Color.Maroon
            Scrap = True

        ElseIf (MPP_BIN = "Invalid") Then
            lblDisposition.Text = MPP_BIN
            lblDisposition.ForeColor = Color.Black
            lblDisposition.BackColor = Color.Yellow

        ElseIf Gvars.MyData.TagColor = Gvars.eTagColor.Red Then
            lblDisposition.Text = "Scrap"
            lblDisposition.ForeColor = Color.Yellow
            lblDisposition.BackColor = Color.Maroon
            Scrap = True

        ElseIf Gvars.MyData.TagColor = Gvars.eTagColor.Manila Then
            lblDisposition.Text = MPP_BIN + " Manila"
            lblDisposition.ForeColor = Color.Black
            lblDisposition.BackColor = Color.FromArgb(241, 213, 146)

        ElseIf Gvars.MyData.TagColor = Gvars.eTagColor.Blue Then
            lblDisposition.Text = MPP_BIN + " Blue"
            lblDisposition.ForeColor = Color.Black
            lblDisposition.BackColor = Color.SkyBlue

        ElseIf Gvars.MyData.TagColor = Gvars.eTagColor.Orange And (MPP_BIN.Contains("MPP BIN # 3") Or MPP_BIN.Contains("MPP BIN # 4")) Then
            lblDisposition.Text = MPP_BIN + " Blue"
            lblDisposition.ForeColor = Color.Black
            lblDisposition.BackColor = Color.SkyBlue

        ElseIf Gvars.MyData.TagColor = Gvars.eTagColor.Orange Then
            lblDisposition.Text = MPP_BIN + " Orange"
            lblDisposition.ForeColor = Color.Black
            lblDisposition.BackColor = Color.Orange

        Else

        End If


    End Sub
    Private Sub ClearData()
        ProcessUnTagedMPP = False
        RFIDidx = -1
        lblRFIDTag.Text = ""
        lblCurrentBIN.Text = ""
        Disposition = ""
        BIN = ""
        MPP_BIN = ""
        ReasonList = ""
        VisualInspection = ""
        Panel1.Visible = False
        Panel2.Visible = False
        Panel3.Visible = False
        Panel4.Visible = False
        btnGood.BackColor = Color.FromKnownColor(KnownColor.LightGreen)
        btnBad.BackColor = Color.FromKnownColor(KnownColor.LightSalmon)
        btnSave.BackColor = Color.FromKnownColor(KnownColor.Control)
        btnGood.Enabled = True
        btnBad.Enabled = True
        dgv.DataSource = Nothing
        UnCheckAll(CheckedListBox1)
        UnCheckAll(CheckedListBox2)
        UnCheckAll(CheckedListBox3)
        Scrap = False

        Gvars.ClearMyData()

        DiscardDataToolStripMenuItem.Enabled = True
        btnCC1Yes.BackColor = Color.Gainsboro
        btnCC1No.BackColor = Color.Gainsboro
        btnCC2Yes.BackColor = Color.Gainsboro
        btnCC2No.BackColor = Color.Gainsboro

        panelCC1.Visible = True
        panelCC2.Visible = False
        panelVI.Visible = False

        btnGood.Enabled = True
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If ProcessUnTagedMPP = True Then

            Gvars.MyData.BoL = lblBOLNumber.Text
            If Gvars.MyData.RFID_Idx = 0 Or Gvars.MyData.RFID_Tag = "" Then
                MsgBox("You must scan an RFID tag first.", vbOKOnly + vbCritical)
                Exit Sub
            End If

            Gvars.MyData.ConnectorBroken = False
            If ReasonList.Contains("Dmgd Conn") Then Gvars.MyData.ConnectorBroken = True

            Gvars.MyData.WaterIngressionValid = True
            Gvars.MyData.WaterIngression = False
            If ReasonList.Contains("Wtr Ingr") Then Gvars.MyData.WaterIngression = True

            Gvars.MyData.Bin = BIN.Trim
            If ReasonList.Trim.Length > 0 Or Gvars.MyData.BadDTCFound Then
                Gvars.MyData.Bin += "H"
            End If

            SaveData_MPPOnly()

                RFIDidx = Gvars.MyData.RFID_Idx

            End If



            SaveData()
        ' Added by Enrique Juarez 2020-08-11
        PrintLabel()
        ' End adding
        ClearData()
    End Sub

    Private Sub SaveData()

        If Scrap = True Then MPP_BIN = "Scrap"
        Dim ds As New BBBLib.SQL.dsDataSet(Constring, "UPDATE [EPSData].[dbo].[K2XX_CoreSort] SET [MPP_BIN]=@MPPBIN, [MPP_ReasonList]=@MPPReasonList, [MPP_TS] = GETDATE(),[MPP_TAG_Color]=@MPPTagColor WHERE [idx]=@RFIDidx;", {{"@RFIDidx", RFIDidx}, {"@MPPBIN", MPP_BIN}, {"@MPPReasonList", ReasonList}, {"@MPPTagColor", Gvars.MyData.TagColor.ToString}})
        BBBLib.SQL.RunSQLQuery(ds)

    End Sub

    Private Sub Panel2_VisibleChanged(sender As Object, e As EventArgs) Handles Panel2.VisibleChanged
        btnSave.Enabled = Panel2.Visible
    End Sub

    Private Sub tmrBtnFlash_Tick(sender As Object, e As EventArgs) Handles tmrBtnFlash.Tick
        If btnSave.Enabled Then
            If btnSave.BackColor = Color.PaleTurquoise Then
                btnSave.BackColor = Color.Yellow
            Else
                btnSave.BackColor = Color.PaleTurquoise
            End If
        Else
            If btnSave.BackColor <> Color.FromKnownColor(KnownColor.Control) Then btnSave.BackColor = Color.FromKnownColor(KnownColor.Control)
        End If

    End Sub

    Private ReasonList As String = ""


    Private Sub CheckedListBox1_SelectedValueChanged(sender As Object, e As EventArgs) Handles CheckedListBox1.SelectedValueChanged
        'Dim Found As Boolean = False
        'ReasonList = ""
        'Scrap = False
        'lblDisposition.Text = MPP_BIN
        '' Added by Enrique Juarez 2020-08-11
        'lblDisposition.ForeColor = Color.Black
        'lblDisposition.BackColor = Color.SkyBlue

        'Gvars.MyData.TagColor = Gvars.eTagColor.Blue

        'For i = 0 To CheckedListBox1.Items.Count - 1
        '    If CheckedListBox1.GetItemChecked(i) Then
        '        If ReasonList.Length > 0 Then ReasonList += "; "
        '        ' Commented by Enrique Juarez 2020-08-11
        '        'ReasonList += CheckedListBox1.Items(i).ToString
        '        ' Added by Enrique Juarez 2020-08-11
        '        ReasonList += ItemsList1(i, 1)
        '        If i = 2 Then
        '            lblDisposition.Text = "Scrap"
        '            ' Added by Enrique Juarez 2020-08-11
        '            lblDisposition.ForeColor = Color.Yellow
        '            lblDisposition.BackColor = Color.Maroon

        '            Gvars.MyData.TagColor = Gvars.eTagColor.Red
        '            Scrap = True
        '        End If
        '        Found = True
        '    End If
        'Next

        'If Gvars.MyData.CreviceCorrosionPresent = 1 And Gvars.MyData.CreviceCorrosionAcceptable = 0 Then
        '    Gvars.MyData.TagColor = Gvars.eTagColor.Red
        '    Found = True
        'End If

        'SetBinAndColor()

        'Panel2.Visible = Found

        ProcessReasonlist1()
    End Sub

    Private Sub ProcessReasonlist1()
        Dim Found As Boolean = False
        ReasonList = ""
        Scrap = False
        lblDisposition.Text = MPP_BIN
        ' Added by Enrique Juarez 2020-08-11
        lblDisposition.ForeColor = Color.Black
        lblDisposition.BackColor = Color.SkyBlue

        Gvars.MyData.TagColor = Gvars.eTagColor.Blue

        For i = 0 To CheckedListBox1.Items.Count - 1
            If CheckedListBox1.GetItemChecked(i) Then
                If ReasonList.Length > 0 Then ReasonList += "; "
                ' Commented by Enrique Juarez 2020-08-11
                'ReasonList += CheckedListBox1.Items(i).ToString
                ' Added by Enrique Juarez 2020-08-11
                ReasonList += ItemsList1(i, 1)
                If i = 2 Then
                    lblDisposition.Text = "Scrap"
                    ' Added by Enrique Juarez 2020-08-11
                    lblDisposition.ForeColor = Color.Yellow
                    lblDisposition.BackColor = Color.Maroon

                    Gvars.MyData.TagColor = Gvars.eTagColor.Red
                    Scrap = True
                End If
                Found = True
            End If
        Next

        If Gvars.MyData.BadUnit = True Then
            Found = True
        End If

        If Gvars.MyData.CreviceCorrosionPresent = 1 And Gvars.MyData.CreviceCorrosionAcceptable = 0 Then
            Gvars.MyData.TagColor = Gvars.eTagColor.Red
            Found = True

            If ReasonList.Contains("Scrap") = False Then
                If ReasonList.Length > 0 Then ReasonList += "; "
                ReasonList += "Scrap"
            End If
        End If

        If Gvars.MyData.CreviceCorrosionPresent = 1 And Gvars.MyData.CreviceCorrosionAcceptable = 1 And (MPP_BIN.Contains("MPP BIN # 1") Or MPP_BIN.Contains("MPP BIN # 2")) Then
            Gvars.MyData.TagColor = Gvars.eTagColor.Orange
            If ReasonList.Length > 0 Then ReasonList += "; "
            ReasonList += "Acceptable Crevice Corrosion"
            Found = True
        End If

        SetBinAndColor()

        Panel2.Visible = Found

    End Sub
    Private Sub CheckedListBox2_SelectedValueChanged(sender As Object, e As EventArgs) Handles CheckedListBox2.SelectedValueChanged
        'Dim Found As Boolean = False
        ReasonList = ""
        For i = 0 To CheckedListBox2.Items.Count - 1
            If CheckedListBox2.GetItemChecked(i) Then
                If ReasonList.Length > 0 Then ReasonList += "; "
                ReasonList += CheckedListBox2.Items(i).ToString
                'Found = True
            End If
        Next
    End Sub

    ' Added by Enrique Juarez
    Private Sub CheckedListBox3_SelectedValueChanged(sender As Object, e As EventArgs) Handles CheckedListBox3.SelectedValueChanged
        ReasonList = ""
        Scrap = False
        lblDisposition.Text = MPP_BIN
        lblDisposition.ForeColor = Color.Black
        lblDisposition.BackColor = Color.SkyBlue

        If Gvars.MyData.CreviceCorrosionPresent = 1 And Gvars.MyData.CreviceCorrosionAcceptable = 0 Then
            ReasonList = "Crev Corr"
        End If

        For i = 0 To CheckedListBox3.Items.Count - 1
            If CheckedListBox3.GetItemChecked(i) Then
                If ReasonList.Length > 0 Then ReasonList += "; "
                ReasonList += CheckedListBox3.Items(i).ToString
                'lblDisposition.Text = "Scrap"
                'lblDisposition.ForeColor = Color.Yellow
                'lblDisposition.BackColor = Color.Maroon
                Scrap = True
            End If
        Next
        If ReasonList.Contains("Water Ingresion") Then
            lblDisposition.Text = "Scrap"
            lblDisposition.ForeColor = Color.Yellow
            lblDisposition.BackColor = Color.Maroon
        End If
    End Sub
    ' End Add

    Private Sub UnCheckAll(CLB As CheckedListBox)
        For i = 0 To CLB.Items.Count - 1
            CLB.SetItemChecked(i, False)
        Next
    End Sub

    Private AltKey As Boolean = False

    Private Sub frmProcessMPPs_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        AltKey = (e.Modifiers = Keys.Alt)
    End Sub

    Private Sub frmProcessMPPs_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        AltKey = (e.Modifiers = Keys.Alt)
    End Sub

    '
    ' Added by Enrique Juarez 2020-08-11
    '
    Private Sub PrintLabel()
        ' Added by Enrique Juarez
        Dim DateFormat As String = Now.ToString("yyMMdd")

        PrinterInfo = New sK2xxLabelInfo(True)

        PrinterInfo.Variables = {{"%Bin%", "XXXXXXX"},
                                {"%BBBCorePN%", "XXXXXXXXXXXXX"},
                                {"%GMCorePN%", "XXXXXXXXXX"},
                                {"%RFID%", "XXXXXXXXXX"},
                                {"%RFIDidx%", "XXXXX"}}

        PrinterInfo.Text.Add(New sPrinterText("%Bin%", New Point(10, 5), "Arial", 13, FontStyle.Bold))
        PrinterInfo.Text.Add(New sPrinterText("%BBBCorePN%", New Point(10, 25), "Arial", 11, FontStyle.Bold))
        PrinterInfo.Text.Add(New sPrinterText("%GMCorePN%", New Point(10, 40), "Arial", 11, FontStyle.Bold))
        PrinterInfo.Text.Add(New sPrinterText("%PartInfo%", New Point(10, 65), "Arial", 6, FontStyle.Bold))
        PrinterInfo.Text.Add(New sPrinterText("%RFID%-%RFIDidx%-" + DateFormat, New Point(10, 80), "Arial", 9, FontStyle.Bold))

        PrinterInfo.GMCorePN = ""

        'PrinterInfo.Bin = MPP_BIN 
        PrinterInfo.Bin = MPP_BIN + " " + Gvars.MyData.TagColor.ToString

        If (Scrap) Then PrinterInfo.Bin = "SCRAP"
        PrinterInfo.BBBCorePN = "PN - " & BIN.Substring(BIN.IndexOf("-") + 2)
        If (MPP_BIN.Equals("MPP BIN # 3") Or MPP_BIN.Equals("MPP BIN # 4")) Then
            If (PrinterInfo.BBBCorePN.EndsWith("C")) Then
                PrinterInfo.BBBCorePN += "H"
                PrinterInfo.GMCorePN = "HOLD"
            End If
        End If
        PrinterInfo.PartInfo = DTCs & ReasonList
        PrinterInfo.RFID = lblRFIDTag.Text
        PrinterInfo.RFIDidx = RFIDidx
        PrinterInfo.setVars()
        PrinterInfo.Border = True

        If BBB_Printing.K2xxCoreSortLabel.isPrinterSelected() Then
            setupPrtdoc()
            PrtDoc.Print()
        End If
    End Sub

    Private Sub btnPrintTest_Click(sender As Object, e As EventArgs) Handles btnPrintTest.Click
        PrintLabel()
    End Sub



    ' Added by Marc LaClair 2020-08-25
    Public Enum eInhaleState
        idle = 0
        InhaleStarted = 1
        InhaleComplete_Success = 2
        InhaleTimeout = 3
    End Enum
    Private InhaleState As eInhaleState

    Private InhaleCounter As Integer
    Private dtInhaleData As DataTable

    Private Sub btnStartInhale_Click(sender As Object, e As EventArgs) Handles btnStartInhale.Click
        If lblBOLNumber.Text.Trim = "" Then
            MsgBox("Please enter a BOL number first.", vbOK + vbCritical)
            Exit Sub
        End If

        'See if bgw is busy if so then exit sub
        If bgw.IsBusy Then Exit Sub

        'disable button
        btnStartInhale.Enabled = False

        'Delete output.csv file
        If Not Gvars.DeleteOutputFile(Gvars.InhalePrg.OutputFileLocation) Then
            Exit Sub
        End If

        'Reset Counter
        InhaleCounter = 0

        'Start Timer
        InhaleState = eInhaleState.InhaleStarted

        'Start batch file
        bgw.RunWorkerAsync()

    End Sub

    Private Sub tmrInhale_Tick(sender As Object, e As EventArgs) Handles tmrInhale.Tick
        '
    End Sub

    Private Sub bgw_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgw.DoWork
        ProcessUnTagedMPP = True

        Dim objProcess As System.Diagnostics.Process
        Gvars.InhalePrg.ReturnValue = 0
        Gvars.InhalePrg.ErrorMsg = ""
        Gvars.InhalePrg.AnError = False

        Try
            objProcess = New System.Diagnostics.Process()
            objProcess.StartInfo.FileName = Gvars.InhalePrg.AppPath
            objProcess.StartInfo.Arguments = Gvars.InhalePrg.Arguments
            objProcess.StartInfo.WindowStyle = ProcessWindowStyle.Normal
            objProcess.Start()
            If Not objProcess.WaitForExit(Gvars.InhalePrg.Timeout_mSec) Then
                objProcess.Kill()
                Gvars.InhalePrg.ReturnValue = -999
            Else
                Gvars.InhalePrg.ReturnValue = objProcess.ExitCode.ToString
            End If
            objProcess.Close()
            objProcess.Dispose()
            objProcess = Nothing


        Catch ex As Exception
            Gvars.InhalePrg.ErrorMsg = ex.ToString
            Gvars.InhalePrg.AnError = True
        End Try

    End Sub

    Private Sub bgw_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bgw.RunWorkerCompleted
        dtInhaleData = New DataTable

        If Not IO.File.Exists(Gvars.InhalePrg.OutputFileLocation) Then
            MsgBox("Missing " + Gvars.InhalePrg.OutputFileLocation + " file.")
        Else
            Gvars.ClearMyData()

            dtInhaleData = Gvars.ReadCSV(Gvars.InhalePrg.OutputFileLocation)

            frmClrDTCs = New BBBLib.frmClearDTCs("K2XXMPPRE", "OP30A", "[ClearDTCsBatchFile=C:\EPS\Batch Files\ReadData-K2XX.bat],[ClearableDTCsPrefix=ClearableDTCs],[AcceptableDTCsPrefix=OP30A],[OutputFile=C:\eps\data\output.csv]")
            frmClrDTCs.AppType = BBBLib.frmClearDTCs.eAppType.CoreSort

            If frmClrDTCs.OkToClearDTCs(dtInhaleData) Then
                frmClrDTCs.ShowDialog()
                dtInhaleData = Gvars.ReadCSV(Gvars.InhalePrg.OutputFileLocation)
            Else
                frmClrDTCs.Dispose()
                frmClrDTCs = Nothing
            End If

            DiscardDataToolStripMenuItem.Enabled = True

                Gvars.GetCSVFile(dtInhaleData, dgv)

                ProcessMPPwithoutRFIDTag()
            End If

            If Gvars.InhalePrg.ReturnValue <> -999 Then
            tmrInhale.Enabled = True
        End If

        btnStartInhale.Enabled = True

    End Sub

    Private Sub DiscardDataToolStripMenuItem_Click(sender As Object, e As EventArgs) 
        Dim ans As MsgBoxResult = MsgBox("Are you sure you want to discard this data?", vbYesNo + vbCritical)
        If ans = vbYes Then
            ClearData()
        End If

    End Sub


    Private Sub SaveData_MPPOnly()
        'If Gvars.MyData.HoldUnit Then
        '    Gvars.MyData.Bin = "Hold Unit " + Gvars.MyData.Contact + " @x" + Gvars.MyData.EXT
        'End If

        Try

            Dim aQuery As String = ""
            aQuery = "UPDATE [K2XX_CoreSort] "
            aQuery += "SET [PCName]=@PCName, "
            aQuery += "[RackBarCode]='MPP Only', "
            aQuery += "[CorePN]='MPP Only', "
            aQuery += "[CoreSN]='MPP Only', "
            aQuery += "[BuildDate]='MPP Only', "
            aQuery += "[SoftwareVersion1]=@5, "
            aQuery += "[SoftwareVersion2]=@6, "
            aQuery += "[SoftwareVersion3]=@7, "
            aQuery += "[EPS_SN]=@8, "
            aQuery += "[ECU_SN]=@9, "
            aQuery += "[VIN]=@10, "
            aQuery += "[Mfg Traceability]=@11, "
            aQuery += "[SpecVersion]=@12, "
            aQuery += "[Gear SN]=@13, "
            aQuery += "[ECUHardwarePN]=@14, "
            aQuery += "[GM_PN]=@15, "
            aQuery += "[DTC_1]=@16, "
            aQuery += "[DTC_2]=@17, "
            aQuery += "[DTC_3]=@18, "
            aQuery += "[DTC_4]=@19, "
            aQuery += "[DTC_5]=@20, "
            aQuery += "[DTC_6]=@21, "
            aQuery += "[DTC_7]=@22, "
            aQuery += "[DTC_8]=@23, "
            aQuery += "[DTC_9]=@24, "
            aQuery += "[DTC_10]=@25, "
            aQuery += "[DTC_11]=@26, "
            aQuery += "[DTC_12]=@27, "
            aQuery += "[DTC_13]=@28, "
            aQuery += "[DTC_14]=@29, "
            aQuery += "[DTC_15]=@30, "
            aQuery += "[DTC_16]=@31, "
            aQuery += "[DTC_17]=@32, "
            aQuery += "[DTC_18]=@33, "
            aQuery += "[DTC_19]=@34, "
            aQuery += "[DTC_20]=@35, "
            aQuery += "[Prog Ver]=@36, "
            aQuery += "[BadDTCs]=@37, "
            aQuery += "[Torque_Sensor_DTCs]=@38, "
            aQuery += "[NoComm]=@39, "
            aQuery += "[AllGoodDTCs]=@40, "
            aQuery += "[AcceptableDTCs]=@41, "
            aQuery += "[UnacceptableDTCs]=@42, "
            aQuery += "[BrokenHousing]=@43, "
            aQuery += "[ConnectorsBroken]=@44, "
            aQuery += "[WaterIngressionValid]=@45, "
            aQuery += "[WaterIngression]=@46, "
            aQuery += "[GMPN]='MPP Only', "
            aQuery += "[ACDPN]='MPP Only', "
            aQuery += "[BBBPN]='MPP Only', "
            aQuery += "[BIN]=@50, "
            aQuery += "[ScrapHousing]='MPP Only', "
            aQuery += "[ScrapMotor]=@52,"
            aQuery += "[OnBlacklist_Rack]='MPP Only',"
            aQuery += "[OnBlacklist_MPP]=@54,"
            aQuery += "[TestData]=@55,"
            aQuery += "[BillOfLading]=@56,"
            aQuery += "[BrokenHousingLoc]=@57 "
            aQuery += "WHERE idx=@idx AND [Status]=1"

            '([RackBarCode],[CorePN],[CoreSN],[BuildDate],[SoftwareVersion1],[SoftwareVersion2],[SoftwareVersion3]"
            'aQuery += ",[EPS_SN],[ECU_SN],[VIN],[Mfg Traceability],[SpecVersion],[Gear SN],[ECUHardwarePN],[GM_PN],[DTC_1],[DTC_2],[DTC_3],[DTC_4],[DTC_5],[DTC_6],[DTC_7],[DTC_8]"
            'aQuery += ",[DTC_9],[DTC_10],[DTC_11],[DTC_12],[DTC_13],[DTC_14],[DTC_15],[DTC_16],[DTC_17],[DTC_18],[DTC_19],[DTC_20],[Prog Ver],[BadDTCs],[Torque_Sensor_DTCs],[NoComm]"
            'aQuery += ",[AllGoodDTCs],[AcceptableDTCs],[UnacceptableDTCs],[BrokenHousing],[ConnectorsBroken],[WaterIngressionValid],[WaterIngression ],[GMPN],[ACDPN],[BBBPN],[BIN])"
            'aQuery += " VALUES (@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12,@13,@14,@15,@16,@17,@18,@19,@20,@21,@22,@23,@24,@25,@26,@27,@28,@29,@30,@31,@32,@33,@34,@35,@36,@37,@38,@39,@40,"
            'aQuery += "@41,@42,@43,@44,@45,@46,@47,@48,@49,@50,@51,@52)"

            Dim Params As Object(,) = {{"@PCName", BBBLib.Func.theComputerName},
                                       {"@1", "MPP Only"},
                                       {"@2", "MPP Only"},
                                       {"@3", "MPP Only"},
                                       {"@4", "MPP Only"},
                                       {"@5", Gvars.MyData.SoftwareVersion1},
                                       {"@6", Gvars.MyData.SoftwareVersion2},
                                       {"@7", Gvars.MyData.SoftwareVersion3},
                                       {"@8", Gvars.MyData.EPS_SN},
                                       {"@9", Gvars.MyData.ECU_SN},
                                       {"@10", Gvars.MyData.VIN},
                                       {"@11", Gvars.MyData.ManufacturingTraceability},
                                       {"@12", Gvars.MyData.SpecVersion},
                                       {"@13", Gvars.MyData.GearSerialNumber},
                                       {"@14", Gvars.MyData.ECUHardwarePN},
                                       {"@15", Gvars.MyData.GM_PN},
                                       {"@16", Gvars.MyData.DTC1},
                                       {"@17", Gvars.MyData.DTC2},
                                       {"@18", Gvars.MyData.DTC3},
                                       {"@19", Gvars.MyData.DTC4},
                                       {"@20", Gvars.MyData.DTC5},
                                       {"@21", Gvars.MyData.DTC6},
                                       {"@22", Gvars.MyData.DTC7},
                                       {"@23", Gvars.MyData.DTC8},
                                       {"@24", Gvars.MyData.DTC9},
                                       {"@25", Gvars.MyData.DTC10},
                                       {"@26", Gvars.MyData.DTC11},
                                       {"@27", Gvars.MyData.DTC12},
                                       {"@28", Gvars.MyData.DTC13},
                                       {"@29", Gvars.MyData.DTC14},
                                       {"@30", Gvars.MyData.DTC15},
                                       {"@31", Gvars.MyData.DTC16},
                                       {"@32", Gvars.MyData.DTC17},
                                       {"@33", Gvars.MyData.DTC18},
                                       {"@34", Gvars.MyData.DTC19},
                                       {"@35", Gvars.MyData.DTC20},
                                       {"@36", Gvars.MyData.ProgVer},
                                       {"@37", Gvars.MyData.BadDTCFound.ToString},
                                       {"@38", Gvars.MyData.SpecialCaseDTCs.ToString},
                                       {"@39", Gvars.MyData.NoComm.ToString},
                                       {"@40", Gvars.MyData.AllGoodDTCs.ToString},
                                       {"@41", Gvars.MyData.AcceptableDTCs},
                                       {"@42", Gvars.MyData.UnacceptableDTCs},
                                       {"@43", Gvars.MyData.HousingBroken.ToString},
                                       {"@44", Gvars.MyData.ConnectorBroken.ToString},
                                       {"@45", Gvars.MyData.WaterIngressionValid.ToString},
                                       {"@46", Gvars.MyData.WaterIngression.ToString},
                                       {"@47", "MPP Only"},
                                       {"@48", "MPP Only"},
                                       {"@49", "MPP Only"},
                                       {"@50", Gvars.MyData.Bin},
                                       {"@51", "MPP Only"},
                                       {"@52", Gvars.MyData.ScrapMotor.ToString},
                                       {"@53", "MPP Only"},
                                       {"@54", Gvars.MyData.OnBlackList_MPP.ToString},
                                       {"@55", False},
                                       {"@56", Gvars.MyData.BoL},
                                       {"@57", Gvars.MyData.HousingBrokenLocation},
                                       {"@idx", Gvars.MyData.RFID_Idx}}

            Dim ds As New BBBLib.SQL.dsDataSet(Constring, aQuery, Params)
            BBBLib.SQL.RunSQLQuery(ds)
            BBBLib.Log.LogMsg("Data Saved: RFID Tag (idx): BIN: " + Gvars.MyData.RFID_Tag + " (" + Gvars.MyData.RFID_Idx.ToString + ") - " + Gvars.MyData.Bin)

            If ds.Failed Then
                BBBLib.Log.LogMsg("Error Saving Data: (Exception) " + ds.ExceptionMsg)
                BBBLib.Log.LogMsg("Error Saving Data: (Barcode) " + Gvars.MyData.RackBarcode)
                BBBLib.Log.LogMsg("Error Saving Data: (Core SN) " + Gvars.MyData.CoreSN)
                BBBLib.Log.LogMsg("Error Saving Data: (MPP SN) " + Gvars.MyData.ManufacturingTraceability)
                BBBLib.Log.LogMsg("Error Saving Data: (Acceptable DTCs) " + Gvars.MyData.AcceptableDTCs)
                BBBLib.Log.LogMsg("Error Saving Data: (Uncceptable DTCs) " + Gvars.MyData.UnacceptableDTCs)
                BBBLib.Log.LogMsg("Error Saving Data: (RFID) " + Gvars.MyData.RFID_Tag)
                BBBLib.Log.LogMsg("Error Saving Data: (RFID Idx) " + Gvars.MyData.RFID_Idx.ToString)
                BBBLib.Log.LogMsg("Error Saving Data: (BIN) " + Gvars.MyData.Bin)
                MsgBox("Error during save data." + vbCrLf + ds.ExceptionMsg)

            End If
        Catch ex As Exception
            BBBLib.Log.LogMsg("Error Saving Data: (Exception) " + ex.ToString)
            BBBLib.Log.LogMsg("Error Saving Data: (Barcode) " + Gvars.MyData.RackBarcode)
            BBBLib.Log.LogMsg("Error Saving Data: (Core SN) " + Gvars.MyData.CoreSN)
            BBBLib.Log.LogMsg("Error Saving Data: (MPP SN) " + Gvars.MyData.ManufacturingTraceability)
            BBBLib.Log.LogMsg("Error Saving Data: (Acceptable DTCs) " + Gvars.MyData.AcceptableDTCs)
            BBBLib.Log.LogMsg("Error Saving Data: (Uncceptable DTCs) " + Gvars.MyData.UnacceptableDTCs)
            BBBLib.Log.LogMsg("Error Saving Data: (RFID) " + Gvars.MyData.RFID_Tag)
            BBBLib.Log.LogMsg("Error Saving Data: (RFID Idx) " + Gvars.MyData.RFID_Idx.ToString)
            BBBLib.Log.LogMsg("Error Saving Data: (BIN) " + Gvars.MyData.Bin)
            MsgBox("Error Saving data Please contact Supervisor.  " + ex.ToString)
        End Try
    End Sub

    Private Sub CheckMPPOnlyRFIDtag(RFIDtag As String)

        'If LastRFIDScanned = Data Then
        If Gvars.IsRFIDTagMarried(RFIDtag) Then
            'Dim msg As String = "This RFID tag (" + Data + ") should have been attached to the previously processed unit." + vbCrLf + vbCrLf + "Do you want to continue using this RFID tag on this unit?"
            'Dim msg As String = "This RFID tag (" + Data + ") is already married to a unit." + vbCrLf + vbCrLf + "Do you want to continue using this RFID tag on this unit?"
            Dim msg As String = Gvars.Phrases(12, Gvars.Language).Replace("<RFIDTag>", RFIDtag)

            If MessageBox.Show(msg, "Duplicate RFID", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification) = vbNo Then
                ' MessageBox.Show("Please scan a different RFID tag", "Duplicate RFID", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification)
                msg = Gvars.Phrases(13, Gvars.Language)
                MessageBox.Show(msg, "Duplicate RFID", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification)
                lblRFIDTag.Text = ""
                Exit Sub
            Else
                msg = Gvars.Phrases(28, Gvars.Language)
                If MessageBox.Show(msg, "Duplicate RFID", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification) = vbNo Then
                    lblRFIDTag.Text = ""
                    Exit Sub
                End If
            End If
            'If MsgBox(msg, vbYesNo) = vbNo Then
            '    Exit Sub
            'End If
        End If

        Dim idx As Integer = marryRFIDTag(RFIDtag)
        If idx = 0 Then Exit Sub
        Gvars.MyData.RFID_Idx = idx
        Gvars.MyData.RFID_Tag = RFIDtag
        'Funcs2.UpdateCtrl(lblRFIDTag, Funcs2.eProperty.Text, Data)

        Gvars.MyData.RFID_Acquired = True



    End Sub

    Private Function marryRFIDTag(RFIDTag As String) As Integer
        marryRFIDTag = 0
        Gvars.MyData.ProductType = "K2XX GM MPP Only"

        Dim ds As New BBBLib.SQL.dsDataSet(Constring, "sp_K2XX_CoreSort_AssignRFID_w_AutoUnMarry @RFIDTag, @Product", {{"@RFIDTag", RFIDTag}, {"@Product", Gvars.MyData.ProductType}})
        'Dim ds As New BBBLib.SQL.dsDataSet(ConString_EPSData, "sp_K2XX_CoreSort_AssignRFID @RFIDTag, @Product", {{"@RFIDTag", RFIDTag}, {"@Product", Gvars.MyData.ProductType}})
        BBBLib.SQL.RunSQLQuery(ds)
        If ds.Failed Then
            MsgBox("Error during RFID Tag Marry: " + vbCrLf + ds.ExceptionMsg)
        Else
            Dim dt As DataTable = ds.rtDataSet.Tables(0)
            If dt.Rows.Count = 1 Then
                marryRFIDTag = dt.Rows(0)("idx")
            End If
        End If

        If marryRFIDTag = 0 Then
            MsgBox("This tag is already married to a Unit.  Please pick a different tag.", vbOKOnly)
        End If
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ans As String = InputBox("Enter BOL Number", "BOL", lblBOLNumber.Text)
        lblBOLNumber.Text = ans.Trim
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub



    Private Sub btnCC1Yes_Click(sender As Object, e As EventArgs) Handles btnCC1Yes.Click
        Panel2.Visible = False
        panelCC2.Visible = True
        btnCC1Yes.BackColor = Color.Bisque
        btnCC1No.BackColor = Color.Gainsboro
        Gvars.MyData.CreviceCorrosionPresent = 1
    End Sub

    Private Sub btnCC1No_Click(sender As Object, e As EventArgs) Handles btnCC1No.Click
        Panel2.Visible = False
        panelCC2.Visible = False
        panelVI.Visible = True
        btnCC1No.BackColor = Color.Bisque
        btnCC1Yes.BackColor = Color.Gainsboro
        Gvars.MyData.CreviceCorrosionPresent = 0

        If Gvars.MyData.BadUnit = True Then
            btnBad_Click(Me, New EventArgs)
        End If
    End Sub




    Private Sub btnCC2Yes_Click(sender As Object, e As EventArgs) Handles btnCC2Yes.Click
        Panel2.Visible = False
        panelVI.Visible = True
        btnCC2Yes.BackColor = Color.LightGreen
        btnCC2No.BackColor = Color.Gainsboro
        Gvars.MyData.CreviceCorrosionAcceptable = 1
        If Gvars.MyData.BadUnit = True Then
            btnBad_Click(Me, New EventArgs)
        End If
    End Sub

    Private Sub btnCC2No_Click(sender As Object, e As EventArgs) Handles btnCC2No.Click
        Panel2.Visible = False
        panelVI.Visible = True
        btnCC2No.BackColor = Color.LightSalmon
        btnCC2Yes.BackColor = Color.Gainsboro
        Gvars.MyData.CreviceCorrosionAcceptable = 0
        If Gvars.MyData.BadUnit = True Then
            btnBad_Click(Me, New EventArgs)
        End If
    End Sub

    Private Sub DiscardDataToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles DiscardDataToolStripMenuItem.Click
        If MsgBox("Are you sure you want to discard this data?", vbYesNo) = vbYes Then
            ClearData()
        End If
    End Sub


End Class