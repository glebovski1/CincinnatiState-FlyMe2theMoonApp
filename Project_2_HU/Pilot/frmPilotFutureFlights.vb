Public Class frmPilotFutureFlights

    Private Sub frmFutureFlights_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lstFutureFlights.Items.Clear()
        Try
            Dim intMileFlown As Integer = 0
            Dim strSelect As String = ""
            Dim cmdSelect As OleDb.OleDbCommand            ' this will be used for our Select statement
            Dim drSourceTable As OleDb.OleDbDataReader     ' this will be where our result set will 
            Dim dt As DataTable = New DataTable            ' this is the table we will load from our reader


            ' open the DB
            If OpenDatabaseConnectionSQLServer() = False Then

                ' No, warn the user ...
                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)

                ' and close the form/application
                Me.Close()

            End If

            ' Build the select statement
            strSelect = "SELECT 
                                F.intFlightID,
                                F.strFlightNumber,
                                F.dtmFlightDate,
                                A1.strAirportCity AS FromCity,
                                A2.strAirportCity AS ToCity,
                                P.strPlaneNumber,
                                PT.strPlaneType,
                                intMilesFlown
                            FROM TFlights F
                            JOIN TAirports A1 ON F.intFromAirportID = A1.intAirportID
                            JOIN TAirports A2 ON F.intToAirportID = A2.intAirportID
                            JOIN TPlanes P ON F.intPlaneID = P.intPlaneID
                            JOIN TPlaneTypes PT ON P.intPlaneTypeID = PT.intPlaneTypeID
                            JOIN TPilotFlights ON TPilotFlights.intFlightID = F.intFlightID
                            WHERE F.dtmFlightDate >= CAST(GETDATE() AS DATE)
                            AND TPilotFlights.intPilotID = " & modPilotLogic.intPilotId.ToString() &
                            "ORDER BY F.dtmFlightDate;"

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            While drSourceTable.Read()
                AddFlightRecord(drSourceTable("strFlightNumber"), drSourceTable("dtmFlightDate"), drSourceTable("FromCity"), drSourceTable("ToCity"), drSourceTable("strPlaneNumber"), drSourceTable("strPlaneType"), drSourceTable("intMilesFlown"))
                intMileFlown += CInt(drSourceTable("intMilesFlown"))
            End While

            lstFutureFlights.Items.Add("-------------------------")
            lstFutureFlights.Items.Add("Total miles to fly: " & vbTab & intMileFlown.ToString())
            ' Clean up
            drSourceTable.Close()

            ' close the database connection
            CloseDatabaseConnection()

        Catch ex As Exception

            ' Log and display error message
            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Private Sub AddFlightRecord(ByVal strFlightNumber As String, ByVal strFlightDate As String, ByVal strFromCity As String, ByVal strToCity As String, ByVal strPlaneNumber As String, ByVal strPlaneType As String, ByVal strMilesToFly As String)
        lstFutureFlights.Items.Add("-------------------")
        lstFutureFlights.Items.Add("Flight number:" & vbTab & strFlightNumber)
        lstFutureFlights.Items.Add("Flight Date:" & vbTab & strFlightDate)
        lstFutureFlights.Items.Add("From:" & vbTab & strFromCity)
        lstFutureFlights.Items.Add("To:" & vbTab & strToCity)
        lstFutureFlights.Items.Add("Plane number:" & vbTab & strPlaneNumber)
        lstFutureFlights.Items.Add("Plane type:" & vbTab & strPlaneType)
        lstFutureFlights.Items.Add("Miles to fly:" & vbTab & strMilesToFly)


    End Sub


    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Me.Close()
    End Sub


End Class