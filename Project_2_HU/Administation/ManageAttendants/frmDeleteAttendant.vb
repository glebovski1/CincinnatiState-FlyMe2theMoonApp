Public Class frmDeleteAttendant
    Private Sub frmDeleteAttendant_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadAttendants()
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

            cmbAttendants.ValueMember = "intAttendantID"
            cmbAttendants.DisplayMember = "FullName"
            cmbAttendants.DataSource = dt




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
        If MessageBox.Show("Are you sure you want to delete this attendant?",
                 "Confirm Delete",
                 MessageBoxButtons.YesNo,
                 MessageBoxIcon.Warning) = DialogResult.Yes Then

            Dim intAttendantID As Integer = CInt(cmbAttendants.SelectedValue)
            DeleteAttendant(intAttendantID)

        Else
            Me.Close()
        End If
    End Sub



    Private Sub DeleteAttendant(ByVal attendantID As Integer)
        Try
            Dim cmdDelete As OleDb.OleDbCommand
            Dim intRowsAffecter As Integer

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


            cmdDelete = New OleDb.OleDbCommand("usp_DeleteAttendant", m_conAdministrator)
            cmdDelete.CommandType = CommandType.StoredProcedure
            cmdDelete.Parameters.AddWithValue("@intAttendantID", attendantID)

            intRowsAffecter = cmdDelete.ExecuteNonQuery()

            If intRowsAffecter > 0 Then
                MessageBox.Show("Attendant deleted successfully.")
            Else
                MessageBox.Show("No matching attendant found.")
            End If


            CloseDatabaseConnection()
        Catch ex As Exception
            MessageBox.Show("Delete failed: " & ex.Message)
        End Try
    End Sub

End Class