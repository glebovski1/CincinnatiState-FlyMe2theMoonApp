Public Class MainLoginForm
    Private Sub MainLoginForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnPassengerLogin_Click(sender As Object, e As EventArgs) Handles btnPassengerLogin.Click
        frmPassengerLogin.ShowDialog()
    End Sub

    Private Sub btnEmployeeLogin_Click(sender As Object, e As EventArgs) Handles btnEmployeeLogin.Click
        frmEmployeeLogin.ShowDialog()
    End Sub
End Class