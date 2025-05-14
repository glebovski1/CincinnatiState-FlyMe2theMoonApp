Public Class frmAttendantMenu
    Private Sub frmAttendantMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SayHiToAttendant()
    End Sub


    Private Sub SayHiToAttendant()
        lblHello.Text = "Hello " & modAttendantLogic.strAttendantFullName
    End Sub

    Private Sub btnUpdateProfile_Click(sender As Object, e As EventArgs) Handles btnUpdateProfile.Click
        frmUpdateAttendantProfile.ShowDialog()
        SayHiToAttendant()
    End Sub

    Private Sub btnFutureFlights_Click(sender As Object, e As EventArgs) Handles btnFutureFlights.Click
        frmAttendantFutureFlights.ShowDialog()
    End Sub

    Private Sub btnPastFlights_Click(sender As Object, e As EventArgs) Handles btnPastFlights.Click
        frmAttendantPastFlights.ShowDialog()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class