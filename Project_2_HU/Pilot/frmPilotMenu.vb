Public Class frmPilotMenu
    Private Sub frmPilotMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SayHiToPilot()
    End Sub

    Private Sub SayHiToPilot()
        lblHello.Text = "Hello " & modPilotLogic.strPilotFullName
    End Sub

    Private Sub btnUpdateProfile_Click(sender As Object, e As EventArgs) Handles btnUpdateProfile.Click
        frmUpdatePilot.ShowDialog()
        SayHiToPilot()
    End Sub

    Private Sub btnFutureFlights_Click(sender As Object, e As EventArgs) Handles btnFutureFlights.Click
        frmPilotFutureFlights.ShowDialog()
    End Sub

    Private Sub btnPastFlights_Click(sender As Object, e As EventArgs) Handles btnPastFlights.Click
        frmPilotPastFlight.ShowDialog()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class