<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSelectBushing
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
        Me.PanelRack = New System.Windows.Forms.Panel()
        Me.btnRack64 = New System.Windows.Forms.Button()
        Me.btnRack59 = New System.Windows.Forms.Button()
        Me.btn700Nm = New System.Windows.Forms.Button()
        Me.btn550Nm = New System.Windows.Forms.Button()
        Me.btn300Nm = New System.Windows.Forms.Button()
        Me.PanelRack.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelRack
        '
        Me.PanelRack.Controls.Add(Me.btnRack59)
        Me.PanelRack.Controls.Add(Me.btnRack64)
        Me.PanelRack.Location = New System.Drawing.Point(46, 12)
        Me.PanelRack.Name = "PanelRack"
        Me.PanelRack.Size = New System.Drawing.Size(738, 503)
        Me.PanelRack.TabIndex = 3
        '
        'btnRack64
        '
        Me.btnRack64.BackgroundImage = Global.K2XX_Core_Sort.My.Resources.Resources.Rack_64_C_Factor
        Me.btnRack64.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnRack64.Location = New System.Drawing.Point(15, 7)
        Me.btnRack64.Name = "btnRack64"
        Me.btnRack64.Size = New System.Drawing.Size(345, 485)
        Me.btnRack64.TabIndex = 2
        Me.btnRack64.UseVisualStyleBackColor = True
        '
        'btnRack59
        '
        Me.btnRack59.BackgroundImage = Global.K2XX_Core_Sort.My.Resources.Resources.Rack_59_C_Factor
        Me.btnRack59.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnRack59.Location = New System.Drawing.Point(379, 7)
        Me.btnRack59.Name = "btnRack59"
        Me.btnRack59.Size = New System.Drawing.Size(345, 485)
        Me.btnRack59.TabIndex = 3
        Me.btnRack59.UseVisualStyleBackColor = True
        '
        'btn700Nm
        '
        Me.btn700Nm.AutoSize = True
        Me.btn700Nm.BackgroundImage = Global.K2XX_Core_Sort.My.Resources.Resources._700Nm
        Me.btn700Nm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btn700Nm.Location = New System.Drawing.Point(554, 2)
        Me.btn700Nm.Name = "btn700Nm"
        Me.btn700Nm.Size = New System.Drawing.Size(270, 520)
        Me.btn700Nm.TabIndex = 8
        Me.btn700Nm.UseVisualStyleBackColor = True
        '
        'btn550Nm
        '
        Me.btn550Nm.AutoSize = True
        Me.btn550Nm.BackgroundImage = Global.K2XX_Core_Sort.My.Resources.Resources._550Nm
        Me.btn550Nm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btn550Nm.Location = New System.Drawing.Point(278, 2)
        Me.btn550Nm.Name = "btn550Nm"
        Me.btn550Nm.Size = New System.Drawing.Size(270, 520)
        Me.btn550Nm.TabIndex = 7
        Me.btn550Nm.UseVisualStyleBackColor = True
        '
        'btn300Nm
        '
        Me.btn300Nm.AutoSize = True
        Me.btn300Nm.BackgroundImage = Global.K2XX_Core_Sort.My.Resources.Resources._300Nm
        Me.btn300Nm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btn300Nm.Location = New System.Drawing.Point(2, 2)
        Me.btn300Nm.Name = "btn300Nm"
        Me.btn300Nm.Size = New System.Drawing.Size(270, 520)
        Me.btn300Nm.TabIndex = 6
        Me.btn300Nm.UseVisualStyleBackColor = True
        '
        'frmSelectBushing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(833, 525)
        Me.Controls.Add(Me.PanelRack)
        Me.Controls.Add(Me.btn700Nm)
        Me.Controls.Add(Me.btn550Nm)
        Me.Controls.Add(Me.btn300Nm)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmSelectBushing"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmSelectBushing"
        Me.PanelRack.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PanelRack As Panel
    Friend WithEvents btnRack59 As Button
    Friend WithEvents btnRack64 As Button
    Friend WithEvents btn700Nm As Button
    Friend WithEvents btn550Nm As Button
    Friend WithEvents btn300Nm As Button
End Class
