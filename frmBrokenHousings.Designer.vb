<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmBrokenHousings
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
        Me.btnYoke = New System.Windows.Forms.Button()
        Me.btnCenter = New System.Windows.Forms.Button()
        Me.btnBoth = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnYoke
        '
        Me.btnYoke.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnYoke.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnYoke.Location = New System.Drawing.Point(12, 10)
        Me.btnYoke.Name = "btnYoke"
        Me.btnYoke.Size = New System.Drawing.Size(310, 79)
        Me.btnYoke.TabIndex = 0
        Me.btnYoke.Text = "Housing Broken at Yoke" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Armazon quebrado del yugo"
        Me.btnYoke.UseVisualStyleBackColor = True
        '
        'btnCenter
        '
        Me.btnCenter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCenter.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCenter.Location = New System.Drawing.Point(12, 101)
        Me.btnCenter.Name = "btnCenter"
        Me.btnCenter.Size = New System.Drawing.Size(310, 79)
        Me.btnCenter.TabIndex = 1
        Me.btnCenter.Text = "Housing Broken at Center" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Armazon quebrado del centro"
        Me.btnCenter.UseVisualStyleBackColor = True
        '
        'btnBoth
        '
        Me.btnBoth.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBoth.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBoth.Location = New System.Drawing.Point(12, 192)
        Me.btnBoth.Name = "btnBoth"
        Me.btnBoth.Size = New System.Drawing.Size(310, 79)
        Me.btnBoth.TabIndex = 2
        Me.btnBoth.Text = "Housing Broken at Both Locations" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Armazon quebrado de ambos lados"
        Me.btnBoth.UseVisualStyleBackColor = True
        '
        'frmBrokenHousings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightCyan
        Me.ClientSize = New System.Drawing.Size(334, 284)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnBoth)
        Me.Controls.Add(Me.btnCenter)
        Me.Controls.Add(Me.btnYoke)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(350, 415)
        Me.MinimumSize = New System.Drawing.Size(350, 215)
        Me.Name = "frmBrokenHousings"
        Me.Text = "Broken Housing Questions"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnYoke As Button
    Friend WithEvents btnCenter As Button
    Friend WithEvents btnBoth As Button
End Class
