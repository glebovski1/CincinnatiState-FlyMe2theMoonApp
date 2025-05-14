Imports System.Data.OleDb

Public Class frmFutureFlights
    Private Sub frmFutureFlights_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lstFutureFlights.Items.Clear()
        Try
            Dim intMileFlown As Integer = 0
            Dim dt As New DataTable    ' Table to load data from the reader
            Dim cmdSelect As OleDb.OleDbCommand

            ' Open the DB connection
            If OpenDatabaseConnectionSQLServer() = False Then
                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                            "The application will now close.",
                            Me.Text + " Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()
                Exit Sub
            End If

            ' Create an OleDbCommand that calls the stored procedure
            cmdSelect = New OleDb.OleDbCommand("usp_GetFuturePassengerFlights", m_conAdministrator)
            cmdSelect.CommandType = CommandType.StoredProcedure

            ' Add the passenger ID parameter to the command
            cmdSelect.Parameters.Add(New OleDb.OleDbParameter("@PassengerID", OleDbType.Integer)).Value = modCustomerLogic.intCustomerId

            ' Execute the stored procedure and retrieve the DataReader
            Dim drSourceTable As OleDb.OleDbDataReader = cmdSelect.ExecuteReader()

            ' Process the result set: add flight records and accumulate miles flown
            While drSourceTable.Read()
                AddFlightRecord(
            drSourceTable("strFlightNumber"),
            drSourceTable("dtmFlightDate"),
            drSourceTable("FromCity"),
            drSourceTable("ToCity"),
            drSourceTable("strPlaneNumber"),
            drSourceTable("strPlaneType"),
            drSourceTable("intMilesFlown"),
            drSourceTable("strSeat")
)
                intMileFlown += CInt(drSourceTable("intMilesFlown"))
            End While

            lstFutureFlights.Items.Add("-------------------------")
            lstFutureFlights.Items.Add("Total miles to fly: " & vbTab & intMileFlown.ToString())

            ' Clean up the DataReader
            drSourceTable.Close()

            ' Close the database connection
            CloseDatabaseConnection()

        Catch ex As Exception
            ' Log and display error message
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub AddFlightRecord(ByVal strFlightNumber As String, ByVal strFlightDate As String, ByVal strFromCity As String, ByVal strToCity As String, ByVal strPlaneNumber As String, ByVal strPlaneType As String, ByVal strMilesToFly As String, ByVal strSeat As String)
        lstFutureFlights.Items.Add("-------------------")
        lstFutureFlights.Items.Add("Flight number:" & vbTab & strFlightNumber)
        lstFutureFlights.Items.Add("Flight Date:" & vbTab & strFlightDate)
        lstFutureFlights.Items.Add("From:" & vbTab & strFromCity)
        lstFutureFlights.Items.Add("To:" & vbTab & strToCity)
        lstFutureFlights.Items.Add("Plane number:" & vbTab & strPlaneNumber)
        lstFutureFlights.Items.Add("Plane type:" & vbTab & strPlaneType)
        lstFutureFlights.Items.Add("Miles to fly:" & vbTab & strMilesToFly)
        lstFutureFlights.Items.Add("Seat: " & vbTab & strSeat)

    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Me.Close()
    End Sub


End Class