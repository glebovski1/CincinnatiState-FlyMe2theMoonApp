Public Class frmAddAttendantToFlight
    Private Sub frmAddAttendantToFlight_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadAttendants()
        LoadFlights()
    End Sub

    Private Sub LoadAttendants()
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
            strSelect = "SELECT intAttendantID, strFirstName + ' ' + strLastName AS FullName FROM TAttendants"

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader
            dt.Load(drSourceTable)

            cmbAttendant.ValueMember = "intAttendantID"
            cmbAttendant.DisplayMember = "FullName"
            cmbAttendant.DataSource = dt




            ' Clean up
            drSourceTable.Close()

            ' close the database connection
            CloseDatabaseConnection()

        Catch ex As Exception

            ' Log and display error message
            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Private Sub LoadFlights()
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



            strSelect = "SELECT intFlightID, strFlightNumber FROM TFlights WHERE dtmFlightDate > CAST(GETDATE() AS DATE)"

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader
            dt.Load(drSourceTable)

            cmbFlights.ValueMember = "intFlightID"
            cmbFlights.DisplayMember = "strFlightNumber"
            cmbFlights.DataSource = dt



            ' Clean up
            drSourceTable.Close()

            ' close the database connection
            CloseDatabaseConnection()

        Catch ex As Exception

            ' Log and display error message
            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Private Sub btnAssign_Click(sender As Object, e As EventArgs) Handles btnAssign.Click
        If MessageBox.Show("Are you sure you want to assing this attendant?",
                 "Confirm Assign",
                 MessageBoxButtons.YesNo,
                 MessageBoxIcon.Warning) = DialogResult.Yes Then

            AssignFlightToPilot()

        Else
            Me.Close()
        End If
    End Sub

    Private Sub AssignFlightToPilot()
        Try


            Dim strInsert As String = ""
            Dim strSelect As String = ""
            Dim cmdSelect As OleDb.OleDbCommand ' select command object
            Dim cmdInsert As OleDb.OleDbCommand
            Dim drSourceTable As OleDb.OleDbDataReader
            Dim intNextPrimaryKey As Integer ' holds next highest PK value
            Dim intRowsAffected As Integer  ' how many rows were affected when sql executed
            Dim dt As DataTable = New DataTable

            If OpenDatabaseConnectionSQLServer() = False Then

                ' No, warn the user ...
                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)

                ' and close the form/application
                Me.Close()

            End If




            strInsert = "INSERT INTO TAttendantFlights (intAttendantID, intFlightID) " &
            "VALUES (" & cmbAttendant.SelectedValue() & ", " & cmbFlights.SelectedValue() & ")"

            MessageBox.Show(strInsert)

            cmdInsert = New OleDb.OleDbCommand(strInsert, modDatabaseUtilities.m_conAdministrator)

            intRowsAffected = cmdInsert.ExecuteNonQuery()

            If intRowsAffected > 0 Then
                MessageBox.Show("Flight has been added")    ' let user know success
                ' close new player form
            End If

            CloseDatabaseConnection()       ' close connection if insert didn't work
            Close()



        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub cmbFlights_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFlights.SelectedIndexChanged

    End Sub
End Class