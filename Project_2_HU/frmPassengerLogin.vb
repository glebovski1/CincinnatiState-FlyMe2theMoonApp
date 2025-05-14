Imports System.Net.Mime.MediaTypeNames

Public Class frmPassengerLogin
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnNewPassenger_Click(sender As Object, e As EventArgs) Handles btnNewPassenger.Click
        frmAddPassenger.ShowDialog()
    End Sub

    Private Sub txtLogin_Click(sender As Object, e As EventArgs) Handles txtLogin.Click
        Dim strLoginID As String = txtLoginID.Text
        Dim strPassword As String = txtPassword.Text
        If modCustomerLogic.Loggin(strLoginID, strPassword) Then
            frmCustomerMenu.ShowDialog()
        End If
    End Sub

    Private Sub frmPassengerLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class