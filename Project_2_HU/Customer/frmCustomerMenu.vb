Public Class frmCustomerMenu
    Private Sub frmCustomerMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SayHiToPassenger()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        frmUpdatePassenger.ShowDialog()
        SayHiToPassenger()
    End Sub

    Private Sub SayHiToPassenger()
        lblHello.Text = "Hello " & modCustomerLogic.strCustomerFullName
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim frmBook As frmBookFlight = New frmBookFlight
        frmBookFlight.ShowDialog()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        frmFutureFlights.ShowDialog()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        frmPastFlights.ShowDialog()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class