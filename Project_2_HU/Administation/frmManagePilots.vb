Public Class frmManagePilots
    Private Sub btnAddPilot_Click(sender As Object, e As EventArgs) Handles btnAddPilot.Click
        frmAddPilot.ShowDialog()
    End Sub

    Private Sub btnDeletePilot_Click(sender As Object, e As EventArgs) Handles btnDeletePilot.Click
        frmDeletePilot.ShowDialog()
    End Sub

    Private Sub btnAddToFlight_Click(sender As Object, e As EventArgs) Handles btnAddToFlight.Click
        frmAddPilotToFlight.ShowDialog()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnUpdatePilot_Click(sender As Object, e As EventArgs) Handles btnUpdatePilot.Click
        If frmPilotSelection.ShowDialog() = DialogResult.OK Then
            frmUpdatePilotFromAdmin.ShowDialog()
        End If
    End Sub

    Private Sub frmManagePilots_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class