Public Class frmAddPilotToFlight
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub frmAddPilotToFlight_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadPilots()
        LoadFlights()
    End Sub

    Private Sub LoadPilots()
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
            strSelect = "SELECT intPilotID, strFirstName + ' ' + strLastName AS FullName FROM TPilots"

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader
            dt.Load(drSourceTable)

            cmbPilots.ValueMember = "intPilotID"
            cmbPilots.DisplayMember = "FullName"
            cmbPilots.DataSource = dt



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

    Private Sub btnAssign_Click(sender As Object, e As EventArgs) Handles btnAssign.Click
        If MessageBox.Show("Are you sure you want to assing this pilot?",
                "Confirm assing",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) = DialogResult.Yes Then

            AssignPilotToFlight()

        Else
            Me.Close()
        End If
    End Sub

    Private Sub AssignPilotToFlight()
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


            strInsert = "INSERT INTO TPilotFlights (intPilotID, intFlightID) " &
            "VALUES (" & cmbPilots.SelectedValue() & ", " & cmbFlights.SelectedValue() & ")"

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
End Class