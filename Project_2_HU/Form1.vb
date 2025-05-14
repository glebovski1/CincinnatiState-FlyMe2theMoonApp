Public Class Form1
    Private Sub btnAdministration_Click(sender As Object, e As EventArgs) Handles btnAdministration.Click
        frmAdminMenu.ShowDialog()
    End Sub

    Private Sub btnCustomer_Click(sender As Object, e As EventArgs)
        Dim form = frmCustomerSelection
        form.ShowDialog()
    End Sub

    Private Sub btnPilot_Click(sender As Object, e As EventArgs) Handles btnPilot.Click
        frmPilotSelection.ShowDialog()
    End Sub

    Private Sub btnAttendant_Click(sender As Object, e As EventArgs) Handles btnAttendant.Click
        frmAttendantSelection.ShowDialog()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
