Public Class Funcs2
    Public Enum eProperty
        Text = 10
        Enabled = 20
        Visible = 30
        DataSource = 40
    End Enum

    Public Shared Sub UpdateCtrl(ctrl As Object, aProperty As eProperty, obj As Object)
        If ctrl.InvokeRequired Then
            ctrl.invoke(Sub() UpdateCtrl(ctrl, aProperty, obj))
        Else
            If TypeOf ctrl Is System.Windows.Forms.DataGridView Then
                Dim dgv As System.Windows.Forms.DataGridView = CType(ctrl, System.Windows.Forms.DataGridView)
                If aProperty = eProperty.DataSource Then
                    dgv.DataSource = CType(obj, DataTable)
                ElseIf aProperty = eProperty.Visible Then
                    dgv.Visible = CType(obj, Boolean)
                End If

            ElseIf TypeOf ctrl Is System.Windows.Forms.Panel Then
                Dim aPanel As System.Windows.Forms.Panel = CType(ctrl, System.Windows.Forms.Panel)
                If aProperty = eProperty.Visible Then
                    aPanel.Visible = CType(obj, Boolean)
                End If

            ElseIf TypeOf ctrl Is Windows.Forms.Label Then
                Dim lbl As Windows.Forms.Label = CType(ctrl, Windows.Forms.Label)
                If aProperty = eProperty.Text Then
                    lbl.Text = CType(obj, String)
                ElseIf aProperty = eProperty.Visible Then
                    lbl.Visible = CType(obj, Boolean)
                ElseIf aProperty = eProperty.Enabled Then
                    lbl.Enabled = CType(obj, Boolean)
                End If

            ElseIf TypeOf ctrl Is System.Windows.Forms.TextBox Then
                Dim tb As System.Windows.Forms.TextBox = CType(ctrl, System.Windows.Forms.TextBox)
                If aProperty = eProperty.Text Then
                    tb.Text = CType(obj, String)
                ElseIf aProperty = eProperty.Visible Then
                    tb.Visible = CType(obj, Boolean)
                ElseIf aProperty = eProperty.Enabled Then
                    tb.Enabled = CType(obj, Boolean)
                End If

            ElseIf TypeOf ctrl Is System.Windows.Forms.Button Then
                Dim btn As System.Windows.Forms.Button = CType(ctrl, System.Windows.Forms.Button)
                If aProperty = eProperty.Text Then
                    btn.Text = CType(obj, String)
                ElseIf aProperty = eProperty.Visible Then
                    btn.Visible = CType(obj, Boolean)
                ElseIf aProperty = eProperty.Enabled Then
                    btn.Enabled = CType(obj, Boolean)
                End If

            End If
        End If
    End Sub
End Class
