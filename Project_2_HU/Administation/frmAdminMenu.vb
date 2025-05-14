Public Class frmAdminMenu
    Private Sub btnPilots_Click(sender As Object, e As EventArgs) Handles btnPilots.Click
        frmManagePilots.ShowDialog()
    End Sub

    Private Sub btnAttendance_Click(sender As Object, e As EventArgs) Handles btnAttendance.Click
        frmManageAttendants.ShowDialog()
    End Sub

    Private Sub btnStatistic_Click(sender As Object, e As EventArgs) Handles btnStatistic.Click
        frmStatistic.ShowDialog()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnAddFlight_Click(sender As Object, e As EventArgs) Handles btnAddFlight.Click
        frmAddFlight.ShowDialog()
    End Sub

    Private Sub frmAdminMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class