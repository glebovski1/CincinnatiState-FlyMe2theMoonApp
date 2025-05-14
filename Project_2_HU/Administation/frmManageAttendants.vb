Public Class frmManageAttendants
    Private Sub btnAddAttendant_Click(sender As Object, e As EventArgs) Handles btnAddAttendant.Click
        frmAddAttendant.ShowDialog()
    End Sub

    Private Sub btnDeleteAttendant_Click(sender As Object, e As EventArgs) Handles btnDeleteAttendant.Click
        frmDeleteAttendant.ShowDialog()
    End Sub

    Private Sub btnAddToFlight_Click(sender As Object, e As EventArgs) Handles btnAddToFlight.Click
        frmAddAttendantToFlight.ShowDialog()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnUpdateAttendant_Click(sender As Object, e As EventArgs) Handles btnUpdateAttendant.Click
        If frmAttendantSelection.ShowDialog() = DialogResult.OK Then
            frmUpdateAttendant.ShowDialog()
        End If

    End Sub

    Private Sub frmManageAttendants_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class