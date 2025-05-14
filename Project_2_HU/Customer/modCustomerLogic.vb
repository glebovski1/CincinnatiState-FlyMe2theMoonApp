Imports System.Net.Mime.MediaTypeNames

Module modCustomerLogic
    Public intCustomerId As Integer
    Public strCustomerFullName As String

    Public Function AddPassenger(ByVal strLoginID As String, ByVal strPassword As String, ByVal strFirstName As String, ByVal strLastName As String,
                           ByVal strAddress As String, ByVal strCity As String, ByVal strZip As String, ByVal strPhoneNumber As String, ByVal strEmail As String, ByVal strDateOfBirth As String, ByVal intStateId As Integer) As Boolean
        Dim boolResult As Boolean = False
        Try

            Dim strSelect As String = ""
            Dim strInsert As String = ""
            Dim cmdInsert As OleDb.OleDbCommand ' insert command object

            Dim intRowsAffected As Integer  ' how many rows were affected when sql executed


            ' open the DB
            If OpenDatabaseConnectionSQLServer() = False Then

                ' No, warn the user ...
                MessageBox.Show("Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)

                ' and close the form/application


            End If


            strInsert = "EXECUTE usp_AddPassenger '" & strFirstName & "', '" & strLastName & "', '" & strAddress & "', '" &
            strCity & "', " & intStateId & ", '" & strZip & "', '" & strPhoneNumber & "', '" & strEmail & "', '" &
            strLoginID & "', '" & strPassword & "', '" & strDateOfBirth & "'"


            cmdInsert = New OleDb.OleDbCommand(strInsert, m_conAdministrator)
            cmdInsert.CommandType = CommandType.Text
            intRowsAffected = cmdInsert.ExecuteNonQuery()

            ' If not 0 insert successful
            If intRowsAffected > 0 Then
                MessageBox.Show("Passenger has been added")
                boolResult = True
                ' let user know success

            Else
                MessageBox.Show("LoginID and Password should be unique")
                boolResult = False
            End If


            CloseDatabaseConnection()       ' close connection if insert didn't work



        Catch ex As Exception

            ' Log and display error message
            MessageBox.Show(ex.Message)

        End Try
        Return boolResult
    End Function


    Public Function UpdatePassenger(ByVal strLoginID As String, ByVal strPassword As String, ByVal strFirstName As String, ByVal strLastName As String, ByVal strAddress As String,
                          ByVal strCity As String, ByVal strZip As String, ByVal strPhoneNumber As String, ByVal strEmail As String, ByVal strDateOfBirth As String, ByVal strStateId As String)
        Dim boolResult As Boolean = False
        Try

            Dim strSelect As String = ""
            Dim strUpdate As String = ""
            Dim cmdUpdate As OleDb.OleDbCommand ' insert command object
            Dim intRowsAffected As Integer  ' how many rows were affected when sql executed


            ' open the DB
            If OpenDatabaseConnectionSQLServer() = False Then

                ' No, warn the user ...
                MessageBox.Show("Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)

                ' and close the form/application


            End If



            strUpdate = "UPDATE TPassengers SET " &
             "strLoginID = '" & strLoginID & "', " &
             "strPassword = '" & strPassword & "', " &
             "strFirstName = '" & strFirstName & "', " &
             "strLastName = '" & strLastName & "', " &
             "strAddress = '" & strAddress & "', " &
             "strCity = '" & strCity & "', " &
             "intStateID = " & strStateId & ", " &
             "strZip = '" & strZip & "', " &
             "strPhoneNumber = '" & strPhoneNumber & "', " &
             "strEmail = '" & strEmail & "', " &
             "dtDateOfBirth = '" & strDateOfBirth & "' " &
             "WHERE intPassengerID = " & modCustomerLogic.intCustomerId


            MessageBox.Show(strUpdate)

            ' use insert command with sql string and connection object
            cmdUpdate = New OleDb.OleDbCommand(strUpdate, m_conAdministrator)

            ' execute query to insert data
            intRowsAffected = cmdUpdate.ExecuteNonQuery()

            ' If not 0 insert successful
            If intRowsAffected > 0 Then
                MessageBox.Show("Passenger has been Updated")

                ' let user know success
                ' close new player form

                modCustomerLogic.strCustomerFullName = strFirstName & " " & strLastName

                boolResult = True
            End If


            CloseDatabaseConnection()       ' close connection if insert didn't work


        Catch ex As Exception

            ' Log and display error message
            MessageBox.Show(ex.Message)

        End Try

        Return boolResult

    End Function

    Public Sub LoadPassengerData(ByRef strFirstName As String, ByRef strLastName As String, ByRef strAddress As String, ByRef strCity As String,
                                  ByRef strStateId As String, ByRef intZip As String, ByRef strPhoneNumber As String, ByRef strEmail As String
                                  )
        Try

            Dim strSelect As String = ""
            Dim cmdSelect As OleDb.OleDbCommand            ' this will be used for our Select statement
            Dim drSourceTable As OleDb.OleDbDataReader     ' this will be where our result set will 
            Dim dt As DataTable = New DataTable            ' this is the table we will load from our reader


            ' open the DB
            If OpenDatabaseConnectionSQLServer() = False Then

                ' No, warn the user ...
                MessageBox.Show("Database connection error." & vbNewLine &
                                    "The application will now close.",
                                      " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)

                ' and close the form/application


            End If

            ' Build the select statement
            strSelect = "SELECT * FROM TPassengers WHERE intPassengerID = " & modCustomerLogic.intCustomerId

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            If drSourceTable.Read() Then
                strFirstName = drSourceTable("strFirstName")
                strLastName = drSourceTable("strLastName")
                strAddress = drSourceTable("strAddress")
                strCity = drSourceTable("strCity")
                strStateId = drSourceTable("intStateID").ToString()
                intZip = drSourceTable("strZip")
                strPhoneNumber = drSourceTable("strPhoneNumber")
                strEmail = drSourceTable("strEmail")
            End If




            ' Clean up
            drSourceTable.Close()

            ' close the database connection
            CloseDatabaseConnection()

        Catch ex As Exception

            ' Log and display error message
            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Public Function Loggin(ByVal strLogginID As String, ByVal strPassword As String) As Boolean
        Dim boolResult As Boolean = False
        Try
            Dim strSelect As String = ""
            Dim cmdSelect As OleDb.OleDbCommand ' select command object
            Dim drSourceTable As OleDb.OleDbDataReader ' data reader for pulling info

            ' open the DB
            If OpenDatabaseConnectionSQLServer() = False Then

                ' No, warn the user ...
                MessageBox.Show("Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)

                ' and close the form/application


            End If

            strSelect = "SELECT TOP 1 intPassengerID, strFirstName + ' '  +strLastName As FullName
                FROM TPassengers
                WHERE strLoginID = '" & strLogginID & "' and strPassword = '" & strPassword & "'"
            cmdSelect = New OleDb.OleDbCommand(strSelect, modDatabaseUtilities.m_conAdministrator)

            drSourceTable = cmdSelect.ExecuteReader()

            If drSourceTable.Read() Then
                intCustomerId = drSourceTable("intPassengerID")
                strCustomerFullName = drSourceTable("FullName")
                boolResult = True
            Else
                MessageBox.Show("ID and/or Password are not Valid")
            End If


        Catch ex As Exception
            ' Log and display error message
            MessageBox.Show(ex.Message)
        End Try
        Return boolResult
    End Function

    Public Function GetNumberOfFlight(ByVal intCustomerID As Integer)
        Dim intNumberOfFlight As Integer = 0
        Try
            Dim strSelect As String = ""
            Dim cmdSelect As OleDb.OleDbCommand ' select command object
            Dim drSourceTable As OleDb.OleDbDataReader ' data reader for pulling info

            ' open the DB
            If OpenDatabaseConnectionSQLServer() = False Then

                ' No, warn the user ...
                MessageBox.Show("Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)

                ' and close the form/application
            End If

            strSelect =
                "SELECT COUNT(*) AS FlightCount " &
                "FROM TFlightPassengers fp " &
                "INNER JOIN TFlights f ON fp.intFlightID = f.intFlightID " &
                "WHERE fp.intPassengerID = " & intCustomerID & " " &
                "AND f.dtmFlightDate < GETDATE()"
            cmdSelect = New OleDb.OleDbCommand(strSelect, modDatabaseUtilities.m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader()

            If drSourceTable.Read() Then
                intNumberOfFlight = drSourceTable("FlightCount")
            Else
                MessageBox.Show("Somethin went wrong while retriving Flight count")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Return intNumberOfFlight
    End Function


    Public Function GetCustomerAge(ByVal intCustomerID As Integer) As Integer
        Dim intAge As Integer = -1
        Try
            Dim strSelect As String = ""
            Dim cmdSelect As OleDb.OleDbCommand ' select command object
            Dim drSourceTable As OleDb.OleDbDataReader ' data reader for pulling info
            Dim dtDateOfBirth As Date

            ' open the DB
            If OpenDatabaseConnectionSQLServer() = False Then

                ' No, warn the user ...
                MessageBox.Show("Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)

                ' and close the form/application
            End If

            strSelect = "SELECT
                            dtDateOfBirth
                        FROM
                        TPassengers
                        WHERE TPassengers.intPassengerID = " & intCustomerID

            cmdSelect = New OleDb.OleDbCommand(strSelect, modDatabaseUtilities.m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader()

            If drSourceTable.Read() Then
                dtDateOfBirth = Date.Parse(drSourceTable("dtDateOfBirth"))
                intAge = DateDiff(DateInterval.Year, dtDateOfBirth, Date.UtcNow())
            Else
                MessageBox.Show("Somethin went wrong while retriving age")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        Return intAge
    End Function

End Module
