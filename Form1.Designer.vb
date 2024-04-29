<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.cboxProducts = New System.Windows.Forms.ComboBox()
        Me.lblSelectProduct = New System.Windows.Forms.Label()
        Me.btnRunInhale = New System.Windows.Forms.Button()
        Me.lblQ2 = New System.Windows.Forms.Label()
        Me.lblQ1 = New System.Windows.Forms.Label()
        Me.btnYes1 = New System.Windows.Forms.Button()
        Me.btnNo1 = New System.Windows.Forms.Button()
        Me.btnNo2 = New System.Windows.Forms.Button()
        Me.btnYes2 = New System.Windows.Forms.Button()
        Me.PanelQ2 = New System.Windows.Forms.Panel()
        Me.PanelQ1 = New System.Windows.Forms.Panel()
        Me.lblBorkenLocation = New System.Windows.Forms.Label()
        Me.PanelQ3 = New System.Windows.Forms.Panel()
        Me.lblQ3 = New System.Windows.Forms.Label()
        Me.btnYes3 = New System.Windows.Forms.Button()
        Me.btnNo3 = New System.Windows.Forms.Button()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.lblDisposition = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MenuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UnMarryRFIDsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LanguageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AllowEscKeyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToggleDebugModeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ReProcessMPPsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.SetupLabelPrinterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReprintLabelFromRFIDTagToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintScrapLabelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintLabelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.msMsg = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnClearProduct = New System.Windows.Forms.Button()
        Me.PanelK2XX = New System.Windows.Forms.Panel()
        Me.PanelQ6 = New System.Windows.Forms.Panel()
        Me.lblQ6 = New System.Windows.Forms.Label()
        Me.btnYes6 = New System.Windows.Forms.Button()
        Me.btnNo6 = New System.Windows.Forms.Button()
        Me.PanelQ5 = New System.Windows.Forms.Panel()
        Me.lblQ5 = New System.Windows.Forms.Label()
        Me.btnYes5 = New System.Windows.Forms.Button()
        Me.btnNo5 = New System.Windows.Forms.Button()
        Me.PanelQ4 = New System.Windows.Forms.Panel()
        Me.lblQ4 = New System.Windows.Forms.Label()
        Me.btnYes4 = New System.Windows.Forms.Button()
        Me.btnNo4 = New System.Windows.Forms.Button()
        Me.PanelBushingInfo = New System.Windows.Forms.Panel()
        Me.lblCFactorInfo = New System.Windows.Forms.Label()
        Me.lblBushingInfo = New System.Windows.Forms.Label()
        Me.lblCFactor = New System.Windows.Forms.Label()
        Me.lblBushingType = New System.Windows.Forms.Label()
        Me.lblBushing = New System.Windows.Forms.Label()
        Me.btnNoTag = New System.Windows.Forms.Button()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.ckboxSetBlacklist = New System.Windows.Forms.CheckBox()
        Me.PanelInhale = New System.Windows.Forms.Panel()
        Me.lblNoCommTryNumber = New System.Windows.Forms.Label()
        Me.PanelRFID = New System.Windows.Forms.Panel()
        Me.btnClickWhenDone = New System.Windows.Forms.Button()
        Me.UcIndicator1 = New SerialPort.ucIndicator()
        Me.lblRFIDTag = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.dgv = New System.Windows.Forms.DataGridView()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblRackBarcodeLen = New System.Windows.Forms.Label()
        Me.btnClearData = New System.Windows.Forms.Button()
        Me.btnDebug = New System.Windows.Forms.Button()
        Me.PanelDebug = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ckboxSaveDataEnabled = New System.Windows.Forms.CheckBox()
        Me.ckboxOnBlacklist = New System.Windows.Forms.CheckBox()
        Me.lblBBBPN = New System.Windows.Forms.Label()
        Me.lblACDPN = New System.Windows.Forms.Label()
        Me.lblGMPN = New System.Windows.Forms.Label()
        Me.ckboxConnectorBroken = New System.Windows.Forms.CheckBox()
        Me.ckboxHousingBroken = New System.Windows.Forms.CheckBox()
        Me.ckboxWaterIngression = New System.Windows.Forms.CheckBox()
        Me.ckboxNoComm = New System.Windows.Forms.CheckBox()
        Me.ckboxBadDTCs = New System.Windows.Forms.CheckBox()
        Me.ckboxGoodMtr = New System.Windows.Forms.CheckBox()
        Me.ckboxBadMtr = New System.Windows.Forms.CheckBox()
        Me.PanelRB1 = New System.Windows.Forms.Panel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblCoreSNLen = New System.Windows.Forms.Label()
        Me.lblCorePNLen = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblRackBuildDate = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblCoreSN = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblCorePN = New System.Windows.Forms.Label()
        Me.tbRackBarcode = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.UcRFID1 = New RFIDReader.ucRFID()
        Me.tmrMain = New System.Windows.Forms.Timer(Me.components)
        Me.tt = New System.Windows.Forms.ToolTip(Me.components)
        Me.BGW = New System.ComponentModel.BackgroundWorker()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.tmrFlash = New System.Windows.Forms.Timer(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnChangeBoL = New System.Windows.Forms.Button()
        Me.lblBillOfLading = New System.Windows.Forms.Label()
        Me.btnReclassify = New System.Windows.Forms.Button()
        Me.PanelQ2.SuspendLayout()
        Me.PanelQ1.SuspendLayout()
        Me.PanelQ3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.PanelK2XX.SuspendLayout()
        Me.PanelQ6.SuspendLayout()
        Me.PanelQ5.SuspendLayout()
        Me.PanelQ4.SuspendLayout()
        Me.PanelBushingInfo.SuspendLayout()
        Me.PanelInhale.SuspendLayout()
        Me.PanelRFID.SuspendLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelDebug.SuspendLayout()
        Me.PanelRB1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cboxProducts
        '
        Me.cboxProducts.FormattingEnabled = True
        Me.cboxProducts.Location = New System.Drawing.Point(227, 26)
        Me.cboxProducts.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cboxProducts.Name = "cboxProducts"
        Me.cboxProducts.Size = New System.Drawing.Size(238, 28)
        Me.cboxProducts.TabIndex = 0
        '
        'lblSelectProduct
        '
        Me.lblSelectProduct.Location = New System.Drawing.Point(13, 29)
        Me.lblSelectProduct.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSelectProduct.Name = "lblSelectProduct"
        Me.lblSelectProduct.Size = New System.Drawing.Size(206, 20)
        Me.lblSelectProduct.TabIndex = 1
        Me.lblSelectProduct.Text = "Select Product:"
        Me.lblSelectProduct.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnRunInhale
        '
        Me.btnRunInhale.Location = New System.Drawing.Point(6, 10)
        Me.btnRunInhale.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnRunInhale.Name = "btnRunInhale"
        Me.btnRunInhale.Size = New System.Drawing.Size(167, 35)
        Me.btnRunInhale.TabIndex = 8
        Me.btnRunInhale.Text = "Run Inhale"
        Me.btnRunInhale.UseVisualStyleBackColor = True
        '
        'lblQ2
        '
        Me.lblQ2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblQ2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQ2.Location = New System.Drawing.Point(0, 2)
        Me.lblQ2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblQ2.Name = "lblQ2"
        Me.lblQ2.Size = New System.Drawing.Size(235, 25)
        Me.lblQ2.TabIndex = 10
        Me.lblQ2.Text = "Are connectors broken?"
        Me.lblQ2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblQ1
        '
        Me.lblQ1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblQ1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQ1.Location = New System.Drawing.Point(0, 2)
        Me.lblQ1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblQ1.Name = "lblQ1"
        Me.lblQ1.Size = New System.Drawing.Size(210, 23)
        Me.lblQ1.TabIndex = 11
        Me.lblQ1.Text = "Is the housing broken?"
        Me.lblQ1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnYes1
        '
        Me.btnYes1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnYes1.BackColor = System.Drawing.Color.Gainsboro
        Me.btnYes1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnYes1.Location = New System.Drawing.Point(310, 1)
        Me.btnYes1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnYes1.Name = "btnYes1"
        Me.btnYes1.Size = New System.Drawing.Size(65, 27)
        Me.btnYes1.TabIndex = 12
        Me.btnYes1.Text = "Yes"
        Me.btnYes1.UseVisualStyleBackColor = False
        '
        'btnNo1
        '
        Me.btnNo1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNo1.BackColor = System.Drawing.Color.Gainsboro
        Me.btnNo1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNo1.Location = New System.Drawing.Point(384, 1)
        Me.btnNo1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnNo1.Name = "btnNo1"
        Me.btnNo1.Size = New System.Drawing.Size(65, 27)
        Me.btnNo1.TabIndex = 13
        Me.btnNo1.Text = "No"
        Me.btnNo1.UseVisualStyleBackColor = False
        '
        'btnNo2
        '
        Me.btnNo2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNo2.BackColor = System.Drawing.Color.Gainsboro
        Me.btnNo2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNo2.Location = New System.Drawing.Point(384, 1)
        Me.btnNo2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnNo2.Name = "btnNo2"
        Me.btnNo2.Size = New System.Drawing.Size(65, 27)
        Me.btnNo2.TabIndex = 15
        Me.btnNo2.Text = "No"
        Me.btnNo2.UseVisualStyleBackColor = False
        '
        'btnYes2
        '
        Me.btnYes2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnYes2.BackColor = System.Drawing.Color.Gainsboro
        Me.btnYes2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnYes2.Location = New System.Drawing.Point(310, 1)
        Me.btnYes2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnYes2.Name = "btnYes2"
        Me.btnYes2.Size = New System.Drawing.Size(65, 27)
        Me.btnYes2.TabIndex = 14
        Me.btnYes2.Text = "Yes"
        Me.btnYes2.UseVisualStyleBackColor = False
        '
        'PanelQ2
        '
        Me.PanelQ2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PanelQ2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.PanelQ2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelQ2.Controls.Add(Me.lblQ2)
        Me.PanelQ2.Controls.Add(Me.btnYes2)
        Me.PanelQ2.Controls.Add(Me.btnNo2)
        Me.PanelQ2.Location = New System.Drawing.Point(1, 351)
        Me.PanelQ2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PanelQ2.Name = "PanelQ2"
        Me.PanelQ2.Size = New System.Drawing.Size(457, 32)
        Me.PanelQ2.TabIndex = 17
        '
        'PanelQ1
        '
        Me.PanelQ1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PanelQ1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.PanelQ1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelQ1.Controls.Add(Me.lblBorkenLocation)
        Me.PanelQ1.Controls.Add(Me.lblQ1)
        Me.PanelQ1.Controls.Add(Me.btnYes1)
        Me.PanelQ1.Controls.Add(Me.btnNo1)
        Me.PanelQ1.Location = New System.Drawing.Point(1, 315)
        Me.PanelQ1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PanelQ1.Name = "PanelQ1"
        Me.PanelQ1.Size = New System.Drawing.Size(457, 32)
        Me.PanelQ1.TabIndex = 18
        '
        'lblBorkenLocation
        '
        Me.lblBorkenLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBorkenLocation.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBorkenLocation.Location = New System.Drawing.Point(217, 5)
        Me.lblBorkenLocation.Name = "lblBorkenLocation"
        Me.lblBorkenLocation.Size = New System.Drawing.Size(87, 20)
        Me.lblBorkenLocation.TabIndex = 14
        Me.lblBorkenLocation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PanelQ3
        '
        Me.PanelQ3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PanelQ3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.PanelQ3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelQ3.Controls.Add(Me.lblQ3)
        Me.PanelQ3.Controls.Add(Me.btnYes3)
        Me.PanelQ3.Controls.Add(Me.btnNo3)
        Me.PanelQ3.Enabled = False
        Me.PanelQ3.Location = New System.Drawing.Point(1, 492)
        Me.PanelQ3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PanelQ3.Name = "PanelQ3"
        Me.PanelQ3.Size = New System.Drawing.Size(457, 32)
        Me.PanelQ3.TabIndex = 19
        '
        'lblQ3
        '
        Me.lblQ3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblQ3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQ3.Location = New System.Drawing.Point(-1, 0)
        Me.lblQ3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblQ3.Name = "lblQ3"
        Me.lblQ3.Size = New System.Drawing.Size(235, 25)
        Me.lblQ3.TabIndex = 11
        Me.lblQ3.Text = "Is there water ingression?"
        Me.lblQ3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnYes3
        '
        Me.btnYes3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnYes3.BackColor = System.Drawing.Color.Gainsboro
        Me.btnYes3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnYes3.Location = New System.Drawing.Point(310, 1)
        Me.btnYes3.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnYes3.Name = "btnYes3"
        Me.btnYes3.Size = New System.Drawing.Size(65, 27)
        Me.btnYes3.TabIndex = 12
        Me.btnYes3.Text = "Yes"
        Me.btnYes3.UseVisualStyleBackColor = False
        '
        'btnNo3
        '
        Me.btnNo3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNo3.BackColor = System.Drawing.Color.Gainsboro
        Me.btnNo3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNo3.Location = New System.Drawing.Point(384, 1)
        Me.btnNo3.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnNo3.Name = "btnNo3"
        Me.btnNo3.Size = New System.Drawing.Size(65, 27)
        Me.btnNo3.TabIndex = 13
        Me.btnNo3.Text = "No"
        Me.btnNo3.UseVisualStyleBackColor = False
        '
        'Panel4
        '
        Me.Panel4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel4.Controls.Add(Me.lblDisposition)
        Me.Panel4.Location = New System.Drawing.Point(463, 373)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(477, 136)
        Me.Panel4.TabIndex = 20
        '
        'lblDisposition
        '
        Me.lblDisposition.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblDisposition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDisposition.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDisposition.Location = New System.Drawing.Point(0, 0)
        Me.lblDisposition.Name = "lblDisposition"
        Me.lblDisposition.Size = New System.Drawing.Size(477, 136)
        Me.lblDisposition.TabIndex = 0
        Me.lblDisposition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuToolStripMenuItem, Me.msMsg})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(964, 24)
        Me.MenuStrip1.TabIndex = 21
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'MenuToolStripMenuItem
        '
        Me.MenuToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UnMarryRFIDsToolStripMenuItem, Me.LanguageToolStripMenuItem, Me.AllowEscKeyToolStripMenuItem, Me.ToggleDebugModeToolStripMenuItem, Me.ToolStripSeparator1, Me.ReProcessMPPsToolStripMenuItem, Me.ToolStripSeparator2, Me.SetupLabelPrinterToolStripMenuItem, Me.ReprintLabelFromRFIDTagToolStripMenuItem, Me.PrintScrapLabelToolStripMenuItem, Me.PrintLabelToolStripMenuItem})
        Me.MenuToolStripMenuItem.Name = "MenuToolStripMenuItem"
        Me.MenuToolStripMenuItem.Size = New System.Drawing.Size(50, 20)
        Me.MenuToolStripMenuItem.Text = "Menu"
        '
        'UnMarryRFIDsToolStripMenuItem
        '
        Me.UnMarryRFIDsToolStripMenuItem.Name = "UnMarryRFIDsToolStripMenuItem"
        Me.UnMarryRFIDsToolStripMenuItem.Size = New System.Drawing.Size(219, 22)
        Me.UnMarryRFIDsToolStripMenuItem.Text = "UnMarry RFIDs"
        Me.UnMarryRFIDsToolStripMenuItem.Visible = False
        '
        'LanguageToolStripMenuItem
        '
        Me.LanguageToolStripMenuItem.Name = "LanguageToolStripMenuItem"
        Me.LanguageToolStripMenuItem.Size = New System.Drawing.Size(219, 22)
        Me.LanguageToolStripMenuItem.Text = "Language"
        '
        'AllowEscKeyToolStripMenuItem
        '
        Me.AllowEscKeyToolStripMenuItem.Name = "AllowEscKeyToolStripMenuItem"
        Me.AllowEscKeyToolStripMenuItem.Size = New System.Drawing.Size(219, 22)
        Me.AllowEscKeyToolStripMenuItem.Text = "Allow Esc Key"
        '
        'ToggleDebugModeToolStripMenuItem
        '
        Me.ToggleDebugModeToolStripMenuItem.Name = "ToggleDebugModeToolStripMenuItem"
        Me.ToggleDebugModeToolStripMenuItem.Size = New System.Drawing.Size(219, 22)
        Me.ToggleDebugModeToolStripMenuItem.Text = "Toggle Debug Mode"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(216, 6)
        '
        'ReProcessMPPsToolStripMenuItem
        '
        Me.ReProcessMPPsToolStripMenuItem.Name = "ReProcessMPPsToolStripMenuItem"
        Me.ReProcessMPPsToolStripMenuItem.Size = New System.Drawing.Size(219, 22)
        Me.ReProcessMPPsToolStripMenuItem.Text = "Process MPP Reman"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(216, 6)
        '
        'SetupLabelPrinterToolStripMenuItem
        '
        Me.SetupLabelPrinterToolStripMenuItem.Name = "SetupLabelPrinterToolStripMenuItem"
        Me.SetupLabelPrinterToolStripMenuItem.Size = New System.Drawing.Size(219, 22)
        Me.SetupLabelPrinterToolStripMenuItem.Text = "Setup Label Printer"
        '
        'ReprintLabelFromRFIDTagToolStripMenuItem
        '
        Me.ReprintLabelFromRFIDTagToolStripMenuItem.Name = "ReprintLabelFromRFIDTagToolStripMenuItem"
        Me.ReprintLabelFromRFIDTagToolStripMenuItem.Size = New System.Drawing.Size(219, 22)
        Me.ReprintLabelFromRFIDTagToolStripMenuItem.Text = "Reprint Label from RFID tag"
        '
        'PrintScrapLabelToolStripMenuItem
        '
        Me.PrintScrapLabelToolStripMenuItem.Name = "PrintScrapLabelToolStripMenuItem"
        Me.PrintScrapLabelToolStripMenuItem.Size = New System.Drawing.Size(219, 22)
        Me.PrintScrapLabelToolStripMenuItem.Text = "Reprint Scrap Label"
        '
        'PrintLabelToolStripMenuItem
        '
        Me.PrintLabelToolStripMenuItem.Name = "PrintLabelToolStripMenuItem"
        Me.PrintLabelToolStripMenuItem.Size = New System.Drawing.Size(219, 22)
        Me.PrintLabelToolStripMenuItem.Text = "Reprint Last Label"
        Me.PrintLabelToolStripMenuItem.Visible = False
        '
        'msMsg
        '
        Me.msMsg.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.msMsg.Name = "msMsg"
        Me.msMsg.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.msMsg.Size = New System.Drawing.Size(22, 20)
        Me.msMsg.Text = ":"
        '
        'btnClearProduct
        '
        Me.btnClearProduct.Location = New System.Drawing.Point(483, 27)
        Me.btnClearProduct.Name = "btnClearProduct"
        Me.btnClearProduct.Size = New System.Drawing.Size(192, 27)
        Me.btnClearProduct.TabIndex = 23
        Me.btnClearProduct.Text = "Clear Product"
        Me.btnClearProduct.UseVisualStyleBackColor = True
        '
        'PanelK2XX
        '
        Me.PanelK2XX.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelK2XX.Controls.Add(Me.PanelQ6)
        Me.PanelK2XX.Controls.Add(Me.PanelQ3)
        Me.PanelK2XX.Controls.Add(Me.PanelQ5)
        Me.PanelK2XX.Controls.Add(Me.PanelQ4)
        Me.PanelK2XX.Controls.Add(Me.PanelBushingInfo)
        Me.PanelK2XX.Controls.Add(Me.lblBushing)
        Me.PanelK2XX.Controls.Add(Me.btnNoTag)
        Me.PanelK2XX.Controls.Add(Me.ComboBox1)
        Me.PanelK2XX.Controls.Add(Me.ckboxSetBlacklist)
        Me.PanelK2XX.Controls.Add(Me.PanelInhale)
        Me.PanelK2XX.Controls.Add(Me.PanelRFID)
        Me.PanelK2XX.Controls.Add(Me.dgv)
        Me.PanelK2XX.Controls.Add(Me.Label4)
        Me.PanelK2XX.Controls.Add(Me.lblRackBarcodeLen)
        Me.PanelK2XX.Controls.Add(Me.PanelQ1)
        Me.PanelK2XX.Controls.Add(Me.btnClearData)
        Me.PanelK2XX.Controls.Add(Me.btnDebug)
        Me.PanelK2XX.Controls.Add(Me.Panel4)
        Me.PanelK2XX.Controls.Add(Me.PanelQ2)
        Me.PanelK2XX.Controls.Add(Me.PanelDebug)
        Me.PanelK2XX.Controls.Add(Me.PanelRB1)
        Me.PanelK2XX.Enabled = False
        Me.PanelK2XX.Location = New System.Drawing.Point(8, 213)
        Me.PanelK2XX.Name = "PanelK2XX"
        Me.PanelK2XX.Size = New System.Drawing.Size(944, 534)
        Me.PanelK2XX.TabIndex = 24
        '
        'PanelQ6
        '
        Me.PanelQ6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PanelQ6.BackColor = System.Drawing.Color.WhiteSmoke
        Me.PanelQ6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelQ6.Controls.Add(Me.lblQ6)
        Me.PanelQ6.Controls.Add(Me.btnYes6)
        Me.PanelQ6.Controls.Add(Me.btnNo6)
        Me.PanelQ6.Enabled = False
        Me.PanelQ6.Location = New System.Drawing.Point(1, 457)
        Me.PanelQ6.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PanelQ6.Name = "PanelQ6"
        Me.PanelQ6.Size = New System.Drawing.Size(457, 32)
        Me.PanelQ6.TabIndex = 44
        '
        'lblQ6
        '
        Me.lblQ6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblQ6.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQ6.Location = New System.Drawing.Point(1, 0)
        Me.lblQ6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblQ6.Name = "lblQ6"
        Me.lblQ6.Size = New System.Drawing.Size(235, 25)
        Me.lblQ6.TabIndex = 11
        Me.lblQ6.Text = "Pinion Sensor Conn Broken?"
        Me.lblQ6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnYes6
        '
        Me.btnYes6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnYes6.BackColor = System.Drawing.Color.Gainsboro
        Me.btnYes6.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnYes6.Location = New System.Drawing.Point(310, 1)
        Me.btnYes6.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnYes6.Name = "btnYes6"
        Me.btnYes6.Size = New System.Drawing.Size(65, 27)
        Me.btnYes6.TabIndex = 12
        Me.btnYes6.Text = "Yes"
        Me.btnYes6.UseVisualStyleBackColor = False
        '
        'btnNo6
        '
        Me.btnNo6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNo6.BackColor = System.Drawing.Color.Gainsboro
        Me.btnNo6.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNo6.Location = New System.Drawing.Point(384, 1)
        Me.btnNo6.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnNo6.Name = "btnNo6"
        Me.btnNo6.Size = New System.Drawing.Size(65, 27)
        Me.btnNo6.TabIndex = 13
        Me.btnNo6.Text = "No"
        Me.btnNo6.UseVisualStyleBackColor = False
        '
        'PanelQ5
        '
        Me.PanelQ5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PanelQ5.BackColor = System.Drawing.Color.WhiteSmoke
        Me.PanelQ5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelQ5.Controls.Add(Me.lblQ5)
        Me.PanelQ5.Controls.Add(Me.btnYes5)
        Me.PanelQ5.Controls.Add(Me.btnNo5)
        Me.PanelQ5.Enabled = False
        Me.PanelQ5.Location = New System.Drawing.Point(1, 421)
        Me.PanelQ5.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PanelQ5.Name = "PanelQ5"
        Me.PanelQ5.Size = New System.Drawing.Size(457, 32)
        Me.PanelQ5.TabIndex = 43
        '
        'lblQ5
        '
        Me.lblQ5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblQ5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQ5.Location = New System.Drawing.Point(1, 0)
        Me.lblQ5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblQ5.Name = "lblQ5"
        Me.lblQ5.Size = New System.Drawing.Size(235, 25)
        Me.lblQ5.TabIndex = 11
        Me.lblQ5.Text = "Bent Pinion?"
        Me.lblQ5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnYes5
        '
        Me.btnYes5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnYes5.BackColor = System.Drawing.Color.Gainsboro
        Me.btnYes5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnYes5.Location = New System.Drawing.Point(310, 1)
        Me.btnYes5.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnYes5.Name = "btnYes5"
        Me.btnYes5.Size = New System.Drawing.Size(65, 27)
        Me.btnYes5.TabIndex = 12
        Me.btnYes5.Text = "Yes"
        Me.btnYes5.UseVisualStyleBackColor = False
        '
        'btnNo5
        '
        Me.btnNo5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNo5.BackColor = System.Drawing.Color.Gainsboro
        Me.btnNo5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNo5.Location = New System.Drawing.Point(384, 1)
        Me.btnNo5.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnNo5.Name = "btnNo5"
        Me.btnNo5.Size = New System.Drawing.Size(65, 27)
        Me.btnNo5.TabIndex = 13
        Me.btnNo5.Text = "No"
        Me.btnNo5.UseVisualStyleBackColor = False
        '
        'PanelQ4
        '
        Me.PanelQ4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PanelQ4.BackColor = System.Drawing.Color.WhiteSmoke
        Me.PanelQ4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelQ4.Controls.Add(Me.lblQ4)
        Me.PanelQ4.Controls.Add(Me.btnYes4)
        Me.PanelQ4.Controls.Add(Me.btnNo4)
        Me.PanelQ4.Enabled = False
        Me.PanelQ4.Location = New System.Drawing.Point(1, 386)
        Me.PanelQ4.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PanelQ4.Name = "PanelQ4"
        Me.PanelQ4.Size = New System.Drawing.Size(457, 32)
        Me.PanelQ4.TabIndex = 42
        '
        'lblQ4
        '
        Me.lblQ4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblQ4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQ4.Location = New System.Drawing.Point(1, 0)
        Me.lblQ4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblQ4.Name = "lblQ4"
        Me.lblQ4.Size = New System.Drawing.Size(235, 25)
        Me.lblQ4.TabIndex = 11
        Me.lblQ4.Text = "Pinion with Corrosion?"
        Me.lblQ4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnYes4
        '
        Me.btnYes4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnYes4.BackColor = System.Drawing.Color.Gainsboro
        Me.btnYes4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnYes4.Location = New System.Drawing.Point(310, 1)
        Me.btnYes4.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnYes4.Name = "btnYes4"
        Me.btnYes4.Size = New System.Drawing.Size(65, 27)
        Me.btnYes4.TabIndex = 12
        Me.btnYes4.Text = "Yes"
        Me.btnYes4.UseVisualStyleBackColor = False
        '
        'btnNo4
        '
        Me.btnNo4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNo4.BackColor = System.Drawing.Color.Gainsboro
        Me.btnNo4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNo4.Location = New System.Drawing.Point(384, 1)
        Me.btnNo4.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnNo4.Name = "btnNo4"
        Me.btnNo4.Size = New System.Drawing.Size(65, 27)
        Me.btnNo4.TabIndex = 13
        Me.btnNo4.Text = "No"
        Me.btnNo4.UseVisualStyleBackColor = False
        '
        'PanelBushingInfo
        '
        Me.PanelBushingInfo.Controls.Add(Me.lblCFactorInfo)
        Me.PanelBushingInfo.Controls.Add(Me.lblBushingInfo)
        Me.PanelBushingInfo.Controls.Add(Me.lblCFactor)
        Me.PanelBushingInfo.Controls.Add(Me.lblBushingType)
        Me.PanelBushingInfo.Location = New System.Drawing.Point(455, 85)
        Me.PanelBushingInfo.Name = "PanelBushingInfo"
        Me.PanelBushingInfo.Size = New System.Drawing.Size(294, 123)
        Me.PanelBushingInfo.TabIndex = 30
        Me.PanelBushingInfo.Visible = False
        '
        'lblCFactorInfo
        '
        Me.lblCFactorInfo.BackColor = System.Drawing.Color.White
        Me.lblCFactorInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCFactorInfo.Location = New System.Drawing.Point(120, 45)
        Me.lblCFactorInfo.Name = "lblCFactorInfo"
        Me.lblCFactorInfo.Size = New System.Drawing.Size(80, 25)
        Me.lblCFactorInfo.TabIndex = 3
        Me.lblCFactorInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblBushingInfo
        '
        Me.lblBushingInfo.BackColor = System.Drawing.Color.White
        Me.lblBushingInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBushingInfo.Location = New System.Drawing.Point(120, 15)
        Me.lblBushingInfo.Name = "lblBushingInfo"
        Me.lblBushingInfo.Size = New System.Drawing.Size(80, 25)
        Me.lblBushingInfo.TabIndex = 2
        Me.lblBushingInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCFactor
        '
        Me.lblCFactor.Location = New System.Drawing.Point(5, 45)
        Me.lblCFactor.Name = "lblCFactor"
        Me.lblCFactor.Size = New System.Drawing.Size(115, 25)
        Me.lblCFactor.TabIndex = 1
        Me.lblCFactor.Text = "C-Factor:"
        Me.lblCFactor.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblBushingType
        '
        Me.lblBushingType.Location = New System.Drawing.Point(5, 15)
        Me.lblBushingType.Name = "lblBushingType"
        Me.lblBushingType.Size = New System.Drawing.Size(115, 25)
        Me.lblBushingType.TabIndex = 0
        Me.lblBushingType.Text = "Bushing Type:"
        Me.lblBushingType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblBushing
        '
        Me.lblBushing.AutoSize = True
        Me.lblBushing.Location = New System.Drawing.Point(436, 177)
        Me.lblBushing.Name = "lblBushing"
        Me.lblBushing.Size = New System.Drawing.Size(13, 20)
        Me.lblBushing.TabIndex = 41
        Me.lblBushing.Text = "."
        Me.lblBushing.Visible = False
        '
        'btnNoTag
        '
        Me.btnNoTag.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNoTag.Location = New System.Drawing.Point(700, 5)
        Me.btnNoTag.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnNoTag.Name = "btnNoTag"
        Me.btnNoTag.Size = New System.Drawing.Size(150, 29)
        Me.btnNoTag.TabIndex = 40
        Me.btnNoTag.Text = "No Tag"
        Me.btnNoTag.UseVisualStyleBackColor = True
        Me.btnNoTag.Visible = False
        '
        'ComboBox1
        '
        Me.ComboBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(791, 70)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(149, 28)
        Me.ComboBox1.TabIndex = 39
        '
        'ckboxSetBlacklist
        '
        Me.ckboxSetBlacklist.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ckboxSetBlacklist.AutoSize = True
        Me.ckboxSetBlacklist.Location = New System.Drawing.Point(770, 77)
        Me.ckboxSetBlacklist.Name = "ckboxSetBlacklist"
        Me.ckboxSetBlacklist.Size = New System.Drawing.Size(15, 14)
        Me.ckboxSetBlacklist.TabIndex = 38
        Me.ckboxSetBlacklist.UseVisualStyleBackColor = True
        '
        'PanelInhale
        '
        Me.PanelInhale.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelInhale.Controls.Add(Me.lblNoCommTryNumber)
        Me.PanelInhale.Controls.Add(Me.btnRunInhale)
        Me.PanelInhale.Location = New System.Drawing.Point(7, 177)
        Me.PanelInhale.Name = "PanelInhale"
        Me.PanelInhale.Size = New System.Drawing.Size(198, 54)
        Me.PanelInhale.TabIndex = 37
        '
        'lblNoCommTryNumber
        '
        Me.lblNoCommTryNumber.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNoCommTryNumber.AutoSize = True
        Me.lblNoCommTryNumber.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoCommTryNumber.Location = New System.Drawing.Point(180, 0)
        Me.lblNoCommTryNumber.Name = "lblNoCommTryNumber"
        Me.lblNoCommTryNumber.Size = New System.Drawing.Size(13, 14)
        Me.lblNoCommTryNumber.TabIndex = 9
        Me.lblNoCommTryNumber.Text = "#"
        Me.lblNoCommTryNumber.Visible = False
        '
        'PanelRFID
        '
        Me.PanelRFID.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelRFID.BackColor = System.Drawing.Color.WhiteSmoke
        Me.PanelRFID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelRFID.Controls.Add(Me.btnClickWhenDone)
        Me.PanelRFID.Controls.Add(Me.UcIndicator1)
        Me.PanelRFID.Controls.Add(Me.lblRFIDTag)
        Me.PanelRFID.Controls.Add(Me.Label10)
        Me.PanelRFID.Location = New System.Drawing.Point(463, 315)
        Me.PanelRFID.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PanelRFID.Name = "PanelRFID"
        Me.PanelRFID.Size = New System.Drawing.Size(478, 50)
        Me.PanelRFID.TabIndex = 36
        '
        'btnClickWhenDone
        '
        Me.btnClickWhenDone.BackColor = System.Drawing.Color.LightSalmon
        Me.btnClickWhenDone.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnClickWhenDone.Location = New System.Drawing.Point(0, 0)
        Me.btnClickWhenDone.Name = "btnClickWhenDone"
        Me.btnClickWhenDone.Size = New System.Drawing.Size(476, 48)
        Me.btnClickWhenDone.TabIndex = 35
        Me.btnClickWhenDone.Text = "Click here when done."
        Me.btnClickWhenDone.UseVisualStyleBackColor = False
        Me.btnClickWhenDone.Visible = False
        '
        'UcIndicator1
        '
        Me.UcIndicator1.Location = New System.Drawing.Point(11, 19)
        Me.UcIndicator1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.UcIndicator1.Name = "UcIndicator1"
        Me.UcIndicator1.Size = New System.Drawing.Size(15, 15)
        Me.UcIndicator1.TabIndex = 36
        '
        'lblRFIDTag
        '
        Me.lblRFIDTag.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblRFIDTag.BackColor = System.Drawing.Color.White
        Me.lblRFIDTag.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRFIDTag.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRFIDTag.Location = New System.Drawing.Point(105, 13)
        Me.lblRFIDTag.Name = "lblRFIDTag"
        Me.lblRFIDTag.Size = New System.Drawing.Size(183, 25)
        Me.lblRFIDTag.TabIndex = 33
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(24, 13)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(75, 25)
        Me.Label10.TabIndex = 32
        Me.Label10.Text = "RFID:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dgv
        '
        Me.dgv.AllowUserToAddRows = False
        Me.dgv.AllowUserToDeleteRows = False
        Me.dgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Location = New System.Drawing.Point(0, 238)
        Me.dgv.Name = "dgv"
        Me.dgv.ReadOnly = True
        Me.dgv.Size = New System.Drawing.Size(941, 70)
        Me.dgv.TabIndex = 27
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(223, 211)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(92, 20)
        Me.Label4.TabIndex = 28
        Me.Label4.Text = "Inhale Data"
        '
        'lblRackBarcodeLen
        '
        Me.lblRackBarcodeLen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblRackBarcodeLen.AutoSize = True
        Me.lblRackBarcodeLen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRackBarcodeLen.Location = New System.Drawing.Point(667, 70)
        Me.lblRackBarcodeLen.Name = "lblRackBarcodeLen"
        Me.lblRackBarcodeLen.Size = New System.Drawing.Size(21, 13)
        Me.lblRackBarcodeLen.TabIndex = 26
        Me.lblRackBarcodeLen.Text = "##"
        '
        'btnClearData
        '
        Me.btnClearData.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClearData.Location = New System.Drawing.Point(700, 40)
        Me.btnClearData.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnClearData.Name = "btnClearData"
        Me.btnClearData.Size = New System.Drawing.Size(150, 29)
        Me.btnClearData.TabIndex = 14
        Me.btnClearData.Text = "Clear Data"
        Me.btnClearData.UseVisualStyleBackColor = True
        Me.btnClearData.Visible = False
        '
        'btnDebug
        '
        Me.btnDebug.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDebug.Location = New System.Drawing.Point(865, 40)
        Me.btnDebug.Name = "btnDebug"
        Me.btnDebug.Size = New System.Drawing.Size(75, 29)
        Me.btnDebug.TabIndex = 21
        Me.btnDebug.Text = "Debug"
        Me.btnDebug.UseVisualStyleBackColor = True
        '
        'PanelDebug
        '
        Me.PanelDebug.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelDebug.Controls.Add(Me.Label7)
        Me.PanelDebug.Controls.Add(Me.ckboxSaveDataEnabled)
        Me.PanelDebug.Controls.Add(Me.ckboxOnBlacklist)
        Me.PanelDebug.Controls.Add(Me.lblBBBPN)
        Me.PanelDebug.Controls.Add(Me.lblACDPN)
        Me.PanelDebug.Controls.Add(Me.lblGMPN)
        Me.PanelDebug.Controls.Add(Me.ckboxConnectorBroken)
        Me.PanelDebug.Controls.Add(Me.ckboxHousingBroken)
        Me.PanelDebug.Controls.Add(Me.ckboxWaterIngression)
        Me.PanelDebug.Controls.Add(Me.ckboxNoComm)
        Me.PanelDebug.Controls.Add(Me.ckboxBadDTCs)
        Me.PanelDebug.Controls.Add(Me.ckboxGoodMtr)
        Me.PanelDebug.Controls.Add(Me.ckboxBadMtr)
        Me.PanelDebug.Location = New System.Drawing.Point(401, 98)
        Me.PanelDebug.Name = "PanelDebug"
        Me.PanelDebug.Size = New System.Drawing.Size(539, 114)
        Me.PanelDebug.TabIndex = 29
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(9, 87)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(359, 18)
        Me.Label7.TabIndex = 29
        Me.Label7.Text = "##"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ckboxSaveDataEnabled
        '
        Me.ckboxSaveDataEnabled.AutoSize = True
        Me.ckboxSaveDataEnabled.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckboxSaveDataEnabled.Location = New System.Drawing.Point(419, 87)
        Me.ckboxSaveDataEnabled.Name = "ckboxSaveDataEnabled"
        Me.ckboxSaveDataEnabled.Size = New System.Drawing.Size(117, 18)
        Me.ckboxSaveDataEnabled.TabIndex = 41
        Me.ckboxSaveDataEnabled.Text = "Save Data Enabled"
        Me.ckboxSaveDataEnabled.UseVisualStyleBackColor = True
        '
        'ckboxOnBlacklist
        '
        Me.ckboxOnBlacklist.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckboxOnBlacklist.Location = New System.Drawing.Point(226, 63)
        Me.ckboxOnBlacklist.Name = "ckboxOnBlacklist"
        Me.ckboxOnBlacklist.Size = New System.Drawing.Size(132, 20)
        Me.ckboxOnBlacklist.TabIndex = 40
        Me.ckboxOnBlacklist.Text = "On Blacklist"
        Me.ckboxOnBlacklist.UseVisualStyleBackColor = True
        '
        'lblBBBPN
        '
        Me.lblBBBPN.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblBBBPN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBBBPN.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBBBPN.Location = New System.Drawing.Point(361, 57)
        Me.lblBBBPN.Name = "lblBBBPN"
        Me.lblBBBPN.Size = New System.Drawing.Size(167, 20)
        Me.lblBBBPN.TabIndex = 39
        Me.lblBBBPN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblACDPN
        '
        Me.lblACDPN.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblACDPN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblACDPN.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblACDPN.Location = New System.Drawing.Point(361, 37)
        Me.lblACDPN.Name = "lblACDPN"
        Me.lblACDPN.Size = New System.Drawing.Size(167, 20)
        Me.lblACDPN.TabIndex = 38
        Me.lblACDPN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblGMPN
        '
        Me.lblGMPN.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblGMPN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblGMPN.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGMPN.Location = New System.Drawing.Point(361, 17)
        Me.lblGMPN.Name = "lblGMPN"
        Me.lblGMPN.Size = New System.Drawing.Size(167, 20)
        Me.lblGMPN.TabIndex = 37
        Me.lblGMPN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ckboxConnectorBroken
        '
        Me.ckboxConnectorBroken.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckboxConnectorBroken.Location = New System.Drawing.Point(226, 23)
        Me.ckboxConnectorBroken.Name = "ckboxConnectorBroken"
        Me.ckboxConnectorBroken.Size = New System.Drawing.Size(132, 20)
        Me.ckboxConnectorBroken.TabIndex = 36
        Me.ckboxConnectorBroken.Text = "Connectors Broken"
        Me.ckboxConnectorBroken.UseVisualStyleBackColor = True
        '
        'ckboxHousingBroken
        '
        Me.ckboxHousingBroken.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckboxHousingBroken.Location = New System.Drawing.Point(226, 3)
        Me.ckboxHousingBroken.Name = "ckboxHousingBroken"
        Me.ckboxHousingBroken.Size = New System.Drawing.Size(132, 20)
        Me.ckboxHousingBroken.TabIndex = 35
        Me.ckboxHousingBroken.Text = "Housing Broken"
        Me.ckboxHousingBroken.UseVisualStyleBackColor = True
        '
        'ckboxWaterIngression
        '
        Me.ckboxWaterIngression.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckboxWaterIngression.Location = New System.Drawing.Point(226, 43)
        Me.ckboxWaterIngression.Name = "ckboxWaterIngression"
        Me.ckboxWaterIngression.Size = New System.Drawing.Size(132, 20)
        Me.ckboxWaterIngression.TabIndex = 34
        Me.ckboxWaterIngression.Text = "Water Ingression"
        Me.ckboxWaterIngression.UseVisualStyleBackColor = True
        '
        'ckboxNoComm
        '
        Me.ckboxNoComm.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckboxNoComm.Location = New System.Drawing.Point(12, 43)
        Me.ckboxNoComm.Name = "ckboxNoComm"
        Me.ckboxNoComm.Size = New System.Drawing.Size(196, 20)
        Me.ckboxNoComm.TabIndex = 33
        Me.ckboxNoComm.Text = "No Comm"
        Me.ckboxNoComm.UseVisualStyleBackColor = True
        '
        'ckboxBadDTCs
        '
        Me.ckboxBadDTCs.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckboxBadDTCs.Location = New System.Drawing.Point(12, 23)
        Me.ckboxBadDTCs.Name = "ckboxBadDTCs"
        Me.ckboxBadDTCs.Size = New System.Drawing.Size(196, 20)
        Me.ckboxBadDTCs.TabIndex = 32
        Me.ckboxBadDTCs.Text = "Bad DTC (Torque Sensor DTCs)"
        Me.ckboxBadDTCs.UseVisualStyleBackColor = True
        '
        'ckboxGoodMtr
        '
        Me.ckboxGoodMtr.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckboxGoodMtr.Location = New System.Drawing.Point(12, 63)
        Me.ckboxGoodMtr.Name = "ckboxGoodMtr"
        Me.ckboxGoodMtr.Size = New System.Drawing.Size(196, 20)
        Me.ckboxGoodMtr.TabIndex = 31
        Me.ckboxGoodMtr.Text = "Good Motor"
        Me.ckboxGoodMtr.UseVisualStyleBackColor = True
        '
        'ckboxBadMtr
        '
        Me.ckboxBadMtr.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckboxBadMtr.Location = New System.Drawing.Point(12, 3)
        Me.ckboxBadMtr.Name = "ckboxBadMtr"
        Me.ckboxBadMtr.Size = New System.Drawing.Size(196, 20)
        Me.ckboxBadMtr.TabIndex = 30
        Me.ckboxBadMtr.Text = "Bad Motor (Bad DTC)"
        Me.ckboxBadMtr.UseVisualStyleBackColor = True
        '
        'PanelRB1
        '
        Me.PanelRB1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelRB1.Controls.Add(Me.Label9)
        Me.PanelRB1.Controls.Add(Me.lblCoreSNLen)
        Me.PanelRB1.Controls.Add(Me.lblCorePNLen)
        Me.PanelRB1.Controls.Add(Me.Label8)
        Me.PanelRB1.Controls.Add(Me.lblRackBuildDate)
        Me.PanelRB1.Controls.Add(Me.Label5)
        Me.PanelRB1.Controls.Add(Me.lblCoreSN)
        Me.PanelRB1.Controls.Add(Me.Label6)
        Me.PanelRB1.Controls.Add(Me.lblCorePN)
        Me.PanelRB1.Controls.Add(Me.tbRackBarcode)
        Me.PanelRB1.Controls.Add(Me.Label2)
        Me.PanelRB1.Controls.Add(Me.Label3)
        Me.PanelRB1.Controls.Add(Me.Panel1)
        Me.PanelRB1.Location = New System.Drawing.Point(6, 41)
        Me.PanelRB1.Name = "PanelRB1"
        Me.PanelRB1.Size = New System.Drawing.Size(687, 134)
        Me.PanelRB1.TabIndex = 30
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(379, 112)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(13, 14)
        Me.Label9.TabIndex = 9
        Me.Label9.Text = "#"
        Me.Label9.Visible = False
        '
        'lblCoreSNLen
        '
        Me.lblCoreSNLen.AutoSize = True
        Me.lblCoreSNLen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCoreSNLen.Location = New System.Drawing.Point(376, 67)
        Me.lblCoreSNLen.Name = "lblCoreSNLen"
        Me.lblCoreSNLen.Size = New System.Drawing.Size(21, 13)
        Me.lblCoreSNLen.TabIndex = 25
        Me.lblCoreSNLen.Text = "##"
        '
        'lblCorePNLen
        '
        Me.lblCorePNLen.AutoSize = True
        Me.lblCorePNLen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCorePNLen.Location = New System.Drawing.Point(376, 33)
        Me.lblCorePNLen.Name = "lblCorePNLen"
        Me.lblCorePNLen.Size = New System.Drawing.Size(21, 13)
        Me.lblCorePNLen.TabIndex = 24
        Me.lblCorePNLen.Text = "##"
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(379, 94)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(13, 14)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "#"
        Me.Label8.Visible = False
        '
        'lblRackBuildDate
        '
        Me.lblRackBuildDate.BackColor = System.Drawing.Color.White
        Me.lblRackBuildDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRackBuildDate.Location = New System.Drawing.Point(126, 96)
        Me.lblRackBuildDate.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblRackBuildDate.Name = "lblRackBuildDate"
        Me.lblRackBuildDate.Size = New System.Drawing.Size(246, 30)
        Me.lblRackBuildDate.TabIndex = 23
        Me.lblRackBuildDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(26, 100)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(87, 20)
        Me.Label5.TabIndex = 22
        Me.Label5.Text = "Build Date:"
        '
        'lblCoreSN
        '
        Me.lblCoreSN.BackColor = System.Drawing.Color.White
        Me.lblCoreSN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCoreSN.Location = New System.Drawing.Point(126, 64)
        Me.lblCoreSN.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCoreSN.Name = "lblCoreSN"
        Me.lblCoreSN.Size = New System.Drawing.Size(246, 30)
        Me.lblCoreSN.TabIndex = 7
        Me.lblCoreSN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(56, 69)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(58, 20)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "SN (T):"
        '
        'lblCorePN
        '
        Me.lblCorePN.BackColor = System.Drawing.Color.White
        Me.lblCorePN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCorePN.Location = New System.Drawing.Point(126, 31)
        Me.lblCorePN.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCorePN.Name = "lblCorePN"
        Me.lblCorePN.Size = New System.Drawing.Size(246, 30)
        Me.lblCorePN.TabIndex = 5
        Me.lblCorePN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tbRackBarcode
        '
        Me.tbRackBarcode.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbRackBarcode.Location = New System.Drawing.Point(126, 2)
        Me.tbRackBarcode.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tbRackBarcode.Name = "tbRackBarcode"
        Me.tbRackBarcode.Size = New System.Drawing.Size(553, 26)
        Me.tbRackBarcode.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(4, 5)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(114, 20)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Rack Barcode:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(18, 36)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(96, 20)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Core PN (P):"
        '
        'Panel1
        '
        Me.Panel1.Location = New System.Drawing.Point(395, 36)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(539, 138)
        Me.Panel1.TabIndex = 42
        '
        'UcRFID1
        '
        Me.UcRFID1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.UcRFID1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UcRFID1.Location = New System.Drawing.Point(11, 20)
        Me.UcRFID1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.UcRFID1.Name = "UcRFID1"
        Me.UcRFID1.Size = New System.Drawing.Size(12, 12)
        Me.UcRFID1.TabIndex = 34
        '
        'tmrMain
        '
        Me.tmrMain.Interval = 250
        '
        'BGW
        '
        Me.BGW.WorkerReportsProgress = True
        Me.BGW.WorkerSupportsCancellation = True
        '
        'lblMessage
        '
        Me.lblMessage.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMessage.BackColor = System.Drawing.Color.LightCyan
        Me.lblMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMessage.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessage.Location = New System.Drawing.Point(8, 88)
        Me.lblMessage.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(944, 125)
        Me.lblMessage.TabIndex = 16
        Me.lblMessage.Text = "Message"
        Me.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tmrFlash
        '
        Me.tmrFlash.Interval = 125
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(14, 222)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(236, 20)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "Numero de BOL de embarque:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnChangeBoL
        '
        Me.btnChangeBoL.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnChangeBoL.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnChangeBoL.Location = New System.Drawing.Point(678, 56)
        Me.btnChangeBoL.Name = "btnChangeBoL"
        Me.btnChangeBoL.Size = New System.Drawing.Size(274, 27)
        Me.btnChangeBoL.TabIndex = 27
        Me.btnChangeBoL.Text = "Change Bill of Lading #"
        Me.btnChangeBoL.UseVisualStyleBackColor = True
        '
        'lblBillOfLading
        '
        Me.lblBillOfLading.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblBillOfLading.BackColor = System.Drawing.Color.White
        Me.lblBillOfLading.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBillOfLading.Location = New System.Drawing.Point(257, 219)
        Me.lblBillOfLading.Name = "lblBillOfLading"
        Me.lblBillOfLading.Size = New System.Drawing.Size(436, 26)
        Me.lblBillOfLading.TabIndex = 28
        Me.lblBillOfLading.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnReclassify
        '
        Me.btnReclassify.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnReclassify.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReclassify.Location = New System.Drawing.Point(678, 27)
        Me.btnReclassify.Name = "btnReclassify"
        Me.btnReclassify.Size = New System.Drawing.Size(274, 27)
        Me.btnReclassify.TabIndex = 29
        Me.btnReclassify.Text = "Reclassify parts"
        Me.btnReclassify.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(964, 759)
        Me.Controls.Add(Me.btnReclassify)
        Me.Controls.Add(Me.lblBillOfLading)
        Me.Controls.Add(Me.btnChangeBoL)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnClearProduct)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.lblSelectProduct)
        Me.Controls.Add(Me.cboxProducts)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.PanelK2XX)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MinimumSize = New System.Drawing.Size(980, 670)
        Me.Name = "Form1"
        Me.Text = "K2XX Core Sort"
        Me.PanelQ2.ResumeLayout(False)
        Me.PanelQ1.ResumeLayout(False)
        Me.PanelQ3.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.PanelK2XX.ResumeLayout(False)
        Me.PanelK2XX.PerformLayout()
        Me.PanelQ6.ResumeLayout(False)
        Me.PanelQ5.ResumeLayout(False)
        Me.PanelQ4.ResumeLayout(False)
        Me.PanelBushingInfo.ResumeLayout(False)
        Me.PanelInhale.ResumeLayout(False)
        Me.PanelInhale.PerformLayout()
        Me.PanelRFID.ResumeLayout(False)
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelDebug.ResumeLayout(False)
        Me.PanelDebug.PerformLayout()
        Me.PanelRB1.ResumeLayout(False)
        Me.PanelRB1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cboxProducts As ComboBox
    Friend WithEvents lblSelectProduct As Label
    Friend WithEvents btnRunInhale As Button
    Friend WithEvents lblQ2 As Label
    Friend WithEvents lblQ1 As Label
    Friend WithEvents btnYes1 As Button
    Friend WithEvents btnNo1 As Button
    Friend WithEvents btnNo2 As Button
    Friend WithEvents btnYes2 As Button
    Friend WithEvents PanelQ2 As Panel
    Friend WithEvents PanelQ1 As Panel
    Friend WithEvents PanelQ3 As Panel
    Friend WithEvents lblQ3 As Label
    Friend WithEvents btnYes3 As Button
    Friend WithEvents btnNo3 As Button
    Friend WithEvents Panel4 As Panel
    Friend WithEvents lblDisposition As Label
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents MenuToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UnMarryRFIDsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnClearProduct As Button
    Friend WithEvents PanelK2XX As Panel
    Friend WithEvents btnDebug As Button
    Friend WithEvents btnClearData As Button
    Friend WithEvents tmrMain As Timer
    Friend WithEvents lblRackBarcodeLen As Label
    Friend WithEvents tt As ToolTip
    Friend WithEvents BGW As System.ComponentModel.BackgroundWorker
    Friend WithEvents dgv As DataGridView
    Friend WithEvents Label4 As Label
    Friend WithEvents msMsg As ToolStripMenuItem
    Friend WithEvents lblRFIDTag As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents lblMessage As Label
    Friend WithEvents UcRFID1 As RFIDReader.ucRFID
    Friend WithEvents btnClickWhenDone As Button
    Friend WithEvents PanelRFID As Panel
    Friend WithEvents PanelInhale As Panel
    Friend WithEvents ToggleDebugModeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ckboxSetBlacklist As CheckBox
    Friend WithEvents tmrFlash As Timer
    Friend WithEvents LanguageToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents lblNoCommTryNumber As Label
    Friend WithEvents AllowEscKeyToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label1 As Label
    Friend WithEvents btnChangeBoL As Button
    Friend WithEvents lblBillOfLading As Label
    Friend WithEvents PrintLabelToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SetupLabelPrinterToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents lblBorkenLocation As Label
    Friend WithEvents btnReclassify As Button
    Friend WithEvents ReprintLabelFromRFIDTagToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents PrintScrapLabelToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents ReProcessMPPsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents UcIndicator1 As SerialPort.ucIndicator
    Friend WithEvents btnNoTag As Button
    Friend WithEvents PanelRB1 As Panel
    Friend WithEvents lblCoreSNLen As Label
    Friend WithEvents lblCorePNLen As Label
    Friend WithEvents lblRackBuildDate As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents lblCoreSN As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents lblCorePN As Label
    Friend WithEvents tbRackBarcode As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents PanelDebug As Panel
    Friend WithEvents Label7 As Label
    Friend WithEvents ckboxSaveDataEnabled As CheckBox
    Friend WithEvents ckboxOnBlacklist As CheckBox
    Friend WithEvents lblBBBPN As Label
    Friend WithEvents lblACDPN As Label
    Friend WithEvents lblGMPN As Label
    Friend WithEvents ckboxConnectorBroken As CheckBox
    Friend WithEvents ckboxHousingBroken As CheckBox
    Friend WithEvents ckboxWaterIngression As CheckBox
    Friend WithEvents ckboxNoComm As CheckBox
    Friend WithEvents ckboxBadDTCs As CheckBox
    Friend WithEvents ckboxGoodMtr As CheckBox
    Friend WithEvents ckboxBadMtr As CheckBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label8 As Label
    Friend WithEvents lblBushing As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents PanelBushingInfo As Panel
    Friend WithEvents lblBushingType As Label
    Friend WithEvents lblBushingInfo As Label
    Friend WithEvents lblCFactor As Label
    Friend WithEvents lblCFactorInfo As Label
    Friend WithEvents PanelQ6 As Panel
    Friend WithEvents lblQ6 As Label
    Friend WithEvents btnYes6 As Button
    Friend WithEvents btnNo6 As Button
    Friend WithEvents PanelQ5 As Panel
    Friend WithEvents lblQ5 As Label
    Friend WithEvents btnYes5 As Button
    Friend WithEvents btnNo5 As Button
    Friend WithEvents PanelQ4 As Panel
    Friend WithEvents lblQ4 As Label
    Friend WithEvents btnYes4 As Button
    Friend WithEvents btnNo4 As Button
End Class
