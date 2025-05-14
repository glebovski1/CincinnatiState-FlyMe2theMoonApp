Public Class frmDeletePilot
    Private Sub frmDeletePilot_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadPilots()
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

    Private Sub brnClose_Click(sender As Object, e As EventArgs) Handles brnClose.Click
        Me.Close()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If MessageBox.Show("Are you sure you want to delete this pilot?",
                 "Confirm Delete",
                 MessageBoxButtons.YesNo,
                 MessageBoxIcon.Warning) = DialogResult.Yes Then

            Dim intPilotID As Integer = CInt(cmbPilots.SelectedValue)
            DeletePilot(intPilotID)

        Else
            Me.Close()
        End If
    End Sub

    Private Sub DeletePilot(ByVal pilotID As Integer)
        Try
            Dim cmdDelete As OleDb.OleDbCommand
            Dim intRowsAffected As Integer

            ' open the DB
            If OpenDatabaseConnectionSQLServer() = False Then
                MessageBox.Show(Me,
                "Database connection error." & vbCrLf &
                "The application will now close.",
                Me.Text & " Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)
                Me.Close()
                Return
            End If

            ' prepare and execute the delete proc
            cmdDelete = New OleDb.OleDbCommand("usp_DeletePilot", m_conAdministrator)
            cmdDelete.CommandType = CommandType.StoredProcedure
            cmdDelete.Parameters.AddWithValue("@intPilotID", pilotID)

            intRowsAffected = cmdDelete.ExecuteNonQuery()

            If intRowsAffected > 0 Then
                MessageBox.Show("Pilot deleted successfully.")
            Else
                MessageBox.Show("No matching pilot found.")
            End If

            CloseDatabaseConnection()

        Catch ex As Exception
            MessageBox.Show("Delete failed: " & ex.Message)
        End Try
    End Sub


End Class