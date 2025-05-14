Public Class frmAttendantSelection
    Private Sub frmAttendantSelection_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadAttendance()
    End Sub

    Private Sub LoadAttendance()
        Try
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
            cmdSelect = New OleDb.OleDbCommand("usp_GetAttendantFullNames", m_conAdministrator)
            cmdSelect.CommandType = CommandType.StoredProcedure

            ' Execute the stored procedure and load the results into a DataTable
            Dim drSourceTable As OleDb.OleDbDataReader = cmdSelect.ExecuteReader()
            dt.Load(drSourceTable)

            ' Bind the DataTable to your combo box
            cmbAttendants.ValueMember = "intAttendantID"
            cmbAttendants.DisplayMember = "FullName"
            cmbAttendants.DataSource = dt

            ' Clean up by closing the reader
            drSourceTable.Close()

            ' Close the database connection
            CloseDatabaseConnection()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub btnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click

        Dim intAttendantsId = cmbAttendants.SelectedValue
        If intAttendantsId > 0 Then
            modAttendantLogic.intAttendantId = cmbAttendants.SelectedValue
            modAttendantLogic.strAttendantFullName = cmbAttendants.Text
            Me.DialogResult = DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
End Class