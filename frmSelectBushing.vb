Public Class frmSelectBushing
    Private Sub frmSelectBushing_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        PanelRack.Visible = False

    End Sub
    Private Sub btn300Nm_Click_1(sender As Object, e As EventArgs) Handles btn300Nm.Click

        Close()
        Form1.lblMessage.Text = "300 Nm Bushing, 56 C-Factor"
        Form1.lblMessage.BackColor = Color.Green
        Form1.lblMessage.ForeColor = Color.White
        Form1.btnRunInhale.Enabled = True
        Form1.lblBushingInfo.Text = "300"
        Form1.lblCFactorInfo.Text = "56"

    End Sub
    Private Sub btn550Nm_Click(sender As Object, e As EventArgs) Handles btn550Nm.Click

        Close()
        Form1.lblMessage.Text = "550 Nm Bushing, 64 C-Factor"
        Form1.lblMessage.BackColor = Color.Green
        Form1.lblMessage.ForeColor = Color.White
        Form1.lblBushingInfo.Text = "550"
        Form1.lblCFactorInfo.Text = "64"

    End Sub

    Private Sub btn700Nm_Click_2(sender As Object, e As EventArgs) Handles btn700Nm.Click

        PanelRack.Visible = True
        btn300Nm.Enabled = False
        btn550Nm.Enabled = False
        btn700Nm.Enabled = False

    End Sub

    Private Sub btnRack64_Click(sender As Object, e As EventArgs) Handles btnRack64.Click

        Close()
        Form1.lblMessage.Text = "700 Nm Bushing, 64 C-Factor"
        Form1.lblMessage.BackColor = Color.Green
        Form1.lblMessage.ForeColor = Color.White
        Form1.lblBushingInfo.Text = "700"
        Form1.lblCFactorInfo.Text = "64"

    End Sub

    Private Sub btnRack59_Click(sender As Object, e As EventArgs) Handles btnRack59.Click

        Close()
        Form1.lblMessage.Text = "700 Nm Bushing, 59 C-Factor"
        Form1.lblMessage.BackColor = Color.Green
        Form1.lblMessage.ForeColor = Color.White
        Form1.lblBushingInfo.Text = "700"
        Form1.lblCFactorInfo.Text = "59"

    End Sub
End Class