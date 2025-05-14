Public Class frmStatistic
    Private Sub frmStatistic_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lisPilotsStatisitic.Items.Clear()
        lblTotalNumberOFCustomers.Text = GetTotalNumberOfCustomers()
        lblTotalFlights.Text = GetTotalFlightsOfCustomers()
        lblAverageMiles.Text = GetAverageMilesFlownByCustomers()
        lisAttendantStatistic.Items.Clear()
        lisPilotsStatisitic.Items.Clear()
        LoadPilotsStastistic()
        LoadAttendantStatistic()
    End Sub

    Private Function GetTotalNumberOfCustomers() As Integer
        Try
            Dim intTotalNumberOfCustomers As Integer = 0
            Dim dt As New DataTable    ' Table to load data from the reader
            Dim cmdSelect As OleDb.OleDbCommand
            Dim drSourceTable As OleDb.OleDbDataReader

            ' Open the DB connection
            If OpenDatabaseConnectionSQLServer() = False Then
                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                            "The application will now close.",
                            Me.Text + " Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()
                Exit Function
            End If

            ' Create an OleDbCommand that calls the stored procedure
            cmdSelect = New OleDb.OleDbCommand("usp_GetTotalNumberOfCustomers", modDatabaseUtilities.m_conAdministrator)
            cmdSelect.CommandType = CommandType.StoredProcedure

            ' Execute the stored procedure and get the data reader
            drSourceTable = cmdSelect.ExecuteReader()

            ' Read the returned result set
            If drSourceTable.Read() Then
                If drSourceTable.IsDBNull(0) Then
                    intTotalNumberOfCustomers = 0
                Else
                    intTotalNumberOfCustomers = CInt(drSourceTable("PassengersNumber"))
                End If
            End If

            ' Clean up: close the data reader and the DB connection
            drSourceTable.Close()
            CloseDatabaseConnection()

            Return intTotalNumberOfCustomers

        Catch ex As Exception
            ' Log and display error message
            MessageBox.Show(ex.Message)
            Return 0
        End Try
    End Function

    Private Function GetTotalFlightsOfCustomers()
        Try
            Dim intTotalFlightsOfCustomers As Integer = 0
            Dim dt As New DataTable    ' DataTable for the query results
            Dim cmdSelect As OleDb.OleDbCommand
            Dim drSourceTable As OleDb.OleDbDataReader

            ' Open the DB connection
            If OpenDatabaseConnectionSQLServer() = False Then
                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()
                Exit Function
            End If

            ' Create an OleDbCommand to call the stored procedure
            cmdSelect = New OleDb.OleDbCommand("usp_GetTotalFlightsOfCustomers", modDatabaseUtilities.m_conAdministrator)
            cmdSelect.CommandType = CommandType.StoredProcedure

            ' Execute the stored procedure and retrieve the data reader
            drSourceTable = cmdSelect.ExecuteReader()
            drSourceTable.Read()

            ' Check if the value is NULL; if not, convert to an integer
            If drSourceTable.IsDBNull(0) = True Then
                intTotalFlightsOfCustomers = 0
            Else
                intTotalFlightsOfCustomers = CInt(drSourceTable("TotalFlightsOFPassengers"))
            End If

            ' Clean up
            drSourceTable.Close()
            CloseDatabaseConnection()

            Return intTotalFlightsOfCustomers

        Catch ex As Exception
            ' Log and display error message
            MessageBox.Show(ex.Message)
            Return 0
        End Try

    End Function

    Private Function GetAverageMilesFlownByCustomers()
        Try
            Dim intAverageMilesForPassenger As Integer = 0
            Dim dt As New DataTable   ' DataTable to load results
            Dim cmdSelect As OleDb.OleDbCommand
            Dim drSourceTable As OleDb.OleDbDataReader

            ' Open the DB connection
            If OpenDatabaseConnectionSQLServer() = False Then
                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                "The application will now close.",
                                Me.Text + " Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()
                Exit Function
            End If

            ' Create an OleDbCommand that calls the stored procedure
            cmdSelect = New OleDb.OleDbCommand("usp_GetAverageMilesFlownForPassengers", modDatabaseUtilities.m_conAdministrator)
            cmdSelect.CommandType = CommandType.StoredProcedure

            ' Execute the stored procedure and retrieve the data reader
            drSourceTable = cmdSelect.ExecuteReader()
            drSourceTable.Read()

            ' Check for a NULL value; if not, convert to an integer
            If drSourceTable.IsDBNull(0) Then
                intAverageMilesForPassenger = 0
            Else
                intAverageMilesForPassenger = CInt(drSourceTable("AverageMilesFlownForPassengers"))
            End If

            ' Clean up the data reader and close the connection
            drSourceTable.Close()
            CloseDatabaseConnection()

            Return intAverageMilesForPassenger

        Catch ex As Exception
            ' Log and display error message
            MessageBox.Show(ex.Message)
            Return 0
        End Try

    End Function


    Private Sub LoadPilotsStastistic()
        Try

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
                            TPilots.intPilotID,
                            TPilots.strFirstName + ' ' + TPilots.strLastName AS FullName,
                            SUM(CASE 
                                            WHEN CAST(TFlights.dtmFlightDate AS DATE) < CAST(GETDATE() AS DATE) 
                                            THEN TFlights.intMilesFlown 
                                            ELSE 0 
                                        END) AS TotalMilesFlown
                        FROM 
                            TPilots
                            LEFT JOIN TPilotFlights ON TPilotFlights.intPilotID = TPilots.intPilotID
                            LEFT JOIN TFlights ON TFlights.intFlightID = TPilotFlights.intFlightID
                        GROUP BY
                            TPilots.intPilotID, TPilots.strFirstName, TPilots.strLastName;
"

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, modDatabaseUtilities.m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader()

            lisPilotsStatisitic.Items.Add("---------------------------------------------------------")
            lisPilotsStatisitic.Items.Add("                       Pilots                            ")
            lisPilotsStatisitic.Items.Add("---------------------------------------------------------")
            While drSourceTable.Read()
                lisPilotsStatisitic.Items.Add("Name:              " & vbTab & drSourceTable("FullName"))
                lisPilotsStatisitic.Items.Add("Total miles flown: " & vbTab & drSourceTable("TotalMilesFlown"))
                lisPilotsStatisitic.Items.Add("")
            End While







            'loop through result set and display in Listbox



            ' Clean up
            drSourceTable.Close()

            ' close the database connection
            CloseDatabaseConnection()



        Catch ex As Exception
            ' Log and display error message
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub LoadAttendantStatistic()
        Try

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
                            TAttendants.intAttendantID,
                            TAttendants.strFirstName + ' ' + TAttendants.strLastName AS FullName,
                            SUM(CASE 
                                            WHEN CAST(TFlights.dtmFlightDate AS DATE) < CAST(GETDATE() AS DATE) 
                                            THEN TFlights.intMilesFlown 
                                            ELSE 0 
                                        END) AS TotalMilesFlown
                        FROM 
                            TAttendants
                            LEFT JOIN TAttendantFlights ON TAttendantFlights.intAttendantID = TAttendants.intAttendantID
                            Left JOIN TFlights ON TFlights.intFlightID = TAttendantFlights.intFlightID
                        GROUP BY
                            TAttendants.intAttendantID, TAttendants.strFirstName, TAttendants.strLastName;"

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, modDatabaseUtilities.m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader()

            lisAttendantStatistic.Items.Add("-----------------------------------------------------------------")
            lisAttendantStatistic.Items.Add("                          Attendants                             ")
            lisAttendantStatistic.Items.Add("-----------------------------------------------------------------")
            While drSourceTable.Read()
                lisAttendantStatistic.Items.Add("Name:              " & vbTab & drSourceTable("FullName"))
                lisAttendantStatistic.Items.Add("Total miles flown: " & vbTab & drSourceTable("TotalMilesFlown"))
                lisAttendantStatistic.Items.Add("")
            End While


            'loop through result set and display in Listbox

            ' Clean up
            drSourceTable.Close()

            ' close the database connection
            CloseDatabaseConnection()



        Catch ex As Exception

            ' Log and display error message
            MessageBox.Show(ex.Message)


        End Try
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        Me.Close()
    End Sub
End Class