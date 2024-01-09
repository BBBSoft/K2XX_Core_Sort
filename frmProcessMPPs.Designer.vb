<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProcessMPPs
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.dgv = New System.Windows.Forms.DataGridView()
        Me.lblRFIDTag = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.lblDisposition = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnGood = New System.Windows.Forms.Button()
        Me.btnBad = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.panelCC1 = New System.Windows.Forms.Panel()
        Me.btnCC1No = New System.Windows.Forms.Button()
        Me.btnCC1Yes = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.panelVI = New System.Windows.Forms.Panel()
        Me.panelCC2 = New System.Windows.Forms.Panel()
        Me.btnCC2No = New System.Windows.Forms.Button()
        Me.btnCC2Yes = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.tmrBtnFlash = New System.Windows.Forms.Timer(Me.components)
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.CheckedListBox2 = New System.Windows.Forms.CheckedListBox()
        Me.CheckedListBox1 = New System.Windows.Forms.CheckedListBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.CheckedListBox3 = New System.Windows.Forms.CheckedListBox()
        Me.lblCurrentBIN = New System.Windows.Forms.Label()
        Me.btnPrintTest = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnStartInhale = New System.Windows.Forms.Button()
        Me.tmrInhale = New System.Windows.Forms.Timer(Me.components)
        Me.bgw = New System.ComponentModel.BackgroundWorker()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MenuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DiscardDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.lblBOLNumber = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tt = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.panelCC1.SuspendLayout()
        Me.panelVI.SuspendLayout()
        Me.panelCC2.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgv
        '
        Me.dgv.AllowUserToAddRows = False
        Me.dgv.AllowUserToDeleteRows = False
        Me.dgv.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Location = New System.Drawing.Point(12, 375)
        Me.dgv.Name = "dgv"
        Me.dgv.ReadOnly = True
        Me.dgv.Size = New System.Drawing.Size(1061, 83)
        Me.dgv.TabIndex = 0
        '
        'lblRFIDTag
        '
        Me.lblRFIDTag.BackColor = System.Drawing.Color.White
        Me.lblRFIDTag.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRFIDTag.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRFIDTag.Location = New System.Drawing.Point(111, 39)
        Me.lblRFIDTag.Name = "lblRFIDTag"
        Me.lblRFIDTag.Size = New System.Drawing.Size(154, 31)
        Me.lblRFIDTag.TabIndex = 1
        Me.lblRFIDTag.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(22, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 20)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "RFID Tag:"
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.BackColor = System.Drawing.Color.PaleTurquoise
        Me.btnSave.Enabled = False
        Me.btnSave.Location = New System.Drawing.Point(949, 327)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(124, 39)
        Me.btnSave.TabIndex = 3
        Me.btnSave.Text = "Save Data"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'lblDisposition
        '
        Me.lblDisposition.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDisposition.BackColor = System.Drawing.Color.White
        Me.lblDisposition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDisposition.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDisposition.Location = New System.Drawing.Point(10, 8)
        Me.lblDisposition.Name = "lblDisposition"
        Me.lblDisposition.Size = New System.Drawing.Size(260, 138)
        Me.lblDisposition.TabIndex = 4
        Me.lblDisposition.Text = "Label2"
        Me.lblDisposition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(130, 20)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Visual Inspection"
        '
        'btnGood
        '
        Me.btnGood.BackColor = System.Drawing.Color.LightGreen
        Me.btnGood.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGood.Location = New System.Drawing.Point(326, 7)
        Me.btnGood.Name = "btnGood"
        Me.btnGood.Size = New System.Drawing.Size(98, 34)
        Me.btnGood.TabIndex = 6
        Me.btnGood.Text = "Good"
        Me.btnGood.UseVisualStyleBackColor = False
        '
        'btnBad
        '
        Me.btnBad.BackColor = System.Drawing.Color.LightSalmon
        Me.btnBad.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBad.Location = New System.Drawing.Point(446, 7)
        Me.btnBad.Name = "btnBad"
        Me.btnBad.Size = New System.Drawing.Size(98, 34)
        Me.btnBad.TabIndex = 7
        Me.btnBad.Text = "Bad"
        Me.btnBad.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.panelCC1)
        Me.Panel1.Controls.Add(Me.panelVI)
        Me.Panel1.Controls.Add(Me.panelCC2)
        Me.Panel1.Location = New System.Drawing.Point(12, 84)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(760, 148)
        Me.Panel1.TabIndex = 8
        Me.Panel1.Visible = False
        '
        'panelCC1
        '
        Me.panelCC1.Controls.Add(Me.btnCC1No)
        Me.panelCC1.Controls.Add(Me.btnCC1Yes)
        Me.panelCC1.Controls.Add(Me.Label4)
        Me.panelCC1.Location = New System.Drawing.Point(6, 0)
        Me.panelCC1.Name = "panelCC1"
        Me.panelCC1.Size = New System.Drawing.Size(557, 47)
        Me.panelCC1.TabIndex = 16
        '
        'btnCC1No
        '
        Me.btnCC1No.BackColor = System.Drawing.Color.Gainsboro
        Me.btnCC1No.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCC1No.Location = New System.Drawing.Point(447, 6)
        Me.btnCC1No.Name = "btnCC1No"
        Me.btnCC1No.Size = New System.Drawing.Size(98, 34)
        Me.btnCC1No.TabIndex = 10
        Me.btnCC1No.Text = "No"
        Me.btnCC1No.UseVisualStyleBackColor = False
        '
        'btnCC1Yes
        '
        Me.btnCC1Yes.BackColor = System.Drawing.Color.Gainsboro
        Me.btnCC1Yes.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCC1Yes.Location = New System.Drawing.Point(327, 6)
        Me.btnCC1Yes.Name = "btnCC1Yes"
        Me.btnCC1Yes.Size = New System.Drawing.Size(98, 34)
        Me.btnCC1Yes.TabIndex = 9
        Me.btnCC1Yes.Text = "Yes"
        Me.btnCC1Yes.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(4, 13)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(310, 20)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Does this unit have any Crevice Corrosion?"
        '
        'panelVI
        '
        Me.panelVI.Controls.Add(Me.btnBad)
        Me.panelVI.Controls.Add(Me.btnGood)
        Me.panelVI.Controls.Add(Me.Label2)
        Me.panelVI.Location = New System.Drawing.Point(6, 93)
        Me.panelVI.Name = "panelVI"
        Me.panelVI.Size = New System.Drawing.Size(557, 47)
        Me.panelVI.TabIndex = 15
        Me.panelVI.Visible = False
        '
        'panelCC2
        '
        Me.panelCC2.Controls.Add(Me.btnCC2No)
        Me.panelCC2.Controls.Add(Me.btnCC2Yes)
        Me.panelCC2.Controls.Add(Me.Label6)
        Me.panelCC2.Location = New System.Drawing.Point(6, 47)
        Me.panelCC2.Name = "panelCC2"
        Me.panelCC2.Size = New System.Drawing.Size(557, 47)
        Me.panelCC2.TabIndex = 14
        Me.panelCC2.Visible = False
        '
        'btnCC2No
        '
        Me.btnCC2No.BackColor = System.Drawing.Color.Gainsboro
        Me.btnCC2No.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCC2No.Location = New System.Drawing.Point(447, 6)
        Me.btnCC2No.Name = "btnCC2No"
        Me.btnCC2No.Size = New System.Drawing.Size(98, 34)
        Me.btnCC2No.TabIndex = 13
        Me.btnCC2No.Text = "No"
        Me.btnCC2No.UseVisualStyleBackColor = False
        '
        'btnCC2Yes
        '
        Me.btnCC2Yes.BackColor = System.Drawing.Color.Gainsboro
        Me.btnCC2Yes.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCC2Yes.Location = New System.Drawing.Point(327, 6)
        Me.btnCC2Yes.Name = "btnCC2Yes"
        Me.btnCC2Yes.Size = New System.Drawing.Size(98, 34)
        Me.btnCC2Yes.TabIndex = 12
        Me.btnCC2Yes.Text = "Yes"
        Me.btnCC2Yes.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(4, 13)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(268, 20)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Is the Crevice Corrosion acceptable?"
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.lblDisposition)
        Me.Panel2.Location = New System.Drawing.Point(793, 123)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(280, 156)
        Me.Panel2.TabIndex = 9
        Me.Panel2.Visible = False
        '
        'tmrBtnFlash
        '
        Me.tmrBtnFlash.Interval = 1500
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.CheckedListBox2)
        Me.Panel3.Controls.Add(Me.CheckedListBox1)
        Me.Panel3.Location = New System.Drawing.Point(12, 238)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(575, 117)
        Me.Panel3.TabIndex = 10
        Me.Panel3.Visible = False
        '
        'CheckedListBox2
        '
        Me.CheckedListBox2.CheckOnClick = True
        Me.CheckedListBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckedListBox2.FormattingEnabled = True
        Me.CheckedListBox2.Items.AddRange(New Object() {"Acceptable Crevice Corrosion"})
        Me.CheckedListBox2.Location = New System.Drawing.Point(65, 14)
        Me.CheckedListBox2.Name = "CheckedListBox2"
        Me.CheckedListBox2.Size = New System.Drawing.Size(333, 88)
        Me.CheckedListBox2.TabIndex = 1
        '
        'CheckedListBox1
        '
        Me.CheckedListBox1.CheckOnClick = True
        Me.CheckedListBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckedListBox1.FormattingEnabled = True
        Me.CheckedListBox1.Items.AddRange(New Object() {"Damaged Housing", "Damaged Connector", "Water Ingresion"})
        Me.CheckedListBox1.Location = New System.Drawing.Point(16, 14)
        Me.CheckedListBox1.Name = "CheckedListBox1"
        Me.CheckedListBox1.Size = New System.Drawing.Size(333, 88)
        Me.CheckedListBox1.TabIndex = 0
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.CheckedListBox3)
        Me.Panel4.Location = New System.Drawing.Point(593, 285)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(234, 117)
        Me.Panel4.TabIndex = 13
        Me.Panel4.Visible = False
        '
        'CheckedListBox3
        '
        Me.CheckedListBox3.CheckOnClick = True
        Me.CheckedListBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckedListBox3.FormattingEnabled = True
        Me.CheckedListBox3.Items.AddRange(New Object() {"Damaged Housing", "Damaged Connector", "Water Ingresion"})
        Me.CheckedListBox3.Location = New System.Drawing.Point(3, 3)
        Me.CheckedListBox3.Name = "CheckedListBox3"
        Me.CheckedListBox3.Size = New System.Drawing.Size(200, 88)
        Me.CheckedListBox3.TabIndex = 0
        '
        'lblCurrentBIN
        '
        Me.lblCurrentBIN.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurrentBIN.Location = New System.Drawing.Point(290, 44)
        Me.lblCurrentBIN.Name = "lblCurrentBIN"
        Me.lblCurrentBIN.Size = New System.Drawing.Size(333, 23)
        Me.lblCurrentBIN.TabIndex = 11
        Me.lblCurrentBIN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnPrintTest
        '
        Me.btnPrintTest.BackColor = System.Drawing.SystemColors.Control
        Me.btnPrintTest.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrintTest.Location = New System.Drawing.Point(793, 83)
        Me.btnPrintTest.Name = "btnPrintTest"
        Me.btnPrintTest.Size = New System.Drawing.Size(280, 34)
        Me.btnPrintTest.TabIndex = 12
        Me.btnPrintTest.Text = "Re-Print"
        Me.btnPrintTest.UseVisualStyleBackColor = False
        Me.btnPrintTest.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(290, 42)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(428, 24)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Scan existing RFID or Click                           button."
        '
        'btnStartInhale
        '
        Me.btnStartInhale.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStartInhale.Location = New System.Drawing.Point(527, 36)
        Me.btnStartInhale.Name = "btnStartInhale"
        Me.btnStartInhale.Size = New System.Drawing.Size(122, 34)
        Me.btnStartInhale.TabIndex = 15
        Me.btnStartInhale.Text = "Start Inhale"
        Me.btnStartInhale.UseVisualStyleBackColor = True
        '
        'tmrInhale
        '
        Me.tmrInhale.Interval = 1000
        '
        'bgw
        '
        Me.bgw.WorkerReportsProgress = True
        Me.bgw.WorkerSupportsCancellation = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1085, 24)
        Me.MenuStrip1.TabIndex = 16
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'MenuToolStripMenuItem
        '
        Me.MenuToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DiscardDataToolStripMenuItem})
        Me.MenuToolStripMenuItem.Name = "MenuToolStripMenuItem"
        Me.MenuToolStripMenuItem.Size = New System.Drawing.Size(50, 20)
        Me.MenuToolStripMenuItem.Text = "Menu"
        '
        'DiscardDataToolStripMenuItem
        '
        Me.DiscardDataToolStripMenuItem.Enabled = False
        Me.DiscardDataToolStripMenuItem.Name = "DiscardDataToolStripMenuItem"
        Me.DiscardDataToolStripMenuItem.Size = New System.Drawing.Size(140, 22)
        Me.DiscardDataToolStripMenuItem.Text = "Discard Data"
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(915, 27)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(158, 23)
        Me.Button1.TabIndex = 17
        Me.Button1.Text = "Change Bill of Lading #"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'lblBOLNumber
        '
        Me.lblBOLNumber.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblBOLNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBOLNumber.Location = New System.Drawing.Point(916, 53)
        Me.lblBOLNumber.Name = "lblBOLNumber"
        Me.lblBOLNumber.Size = New System.Drawing.Size(157, 19)
        Me.lblBOLNumber.TabIndex = 18
        Me.lblBOLNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(759, 56)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(151, 13)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "Numero de BOL de embarque:"
        '
        'frmProcessMPPs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1085, 470)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblBOLNumber)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnStartInhale)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnPrintTest)
        Me.Controls.Add(Me.lblCurrentBIN)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblRFIDTag)
        Me.Controls.Add(Me.dgv)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.Panel3)
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmProcessMPPs"
        Me.Text = "Process K2XX MPP Reman."
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.panelCC1.ResumeLayout(False)
        Me.panelCC1.PerformLayout()
        Me.panelVI.ResumeLayout(False)
        Me.panelVI.PerformLayout()
        Me.panelCC2.ResumeLayout(False)
        Me.panelCC2.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgv As DataGridView
    Friend WithEvents lblRFIDTag As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents btnSave As Button
    Friend WithEvents lblDisposition As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents btnGood As Button
    Friend WithEvents btnBad As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents tmrBtnFlash As Timer
    Friend WithEvents Panel3 As Panel
    Friend WithEvents CheckedListBox1 As CheckedListBox
    Friend WithEvents lblCurrentBIN As Label
    Friend WithEvents CheckedListBox2 As CheckedListBox
    Friend WithEvents btnPrintTest As Button
    Friend WithEvents CheckedListBox3 As CheckedListBox
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents btnStartInhale As Button
    Friend WithEvents tmrInhale As Timer
    Friend WithEvents bgw As System.ComponentModel.BackgroundWorker
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents MenuToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DiscardDataToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Button1 As Button
    Friend WithEvents lblBOLNumber As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents btnCC2No As Button
    Friend WithEvents btnCC2Yes As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents btnCC1No As Button
    Friend WithEvents btnCC1Yes As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents panelCC1 As Panel
    Friend WithEvents panelVI As Panel
    Friend WithEvents panelCC2 As Panel
    Friend WithEvents tt As ToolTip
End Class
