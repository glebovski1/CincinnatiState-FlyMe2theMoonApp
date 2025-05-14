Public Class frmPilotSelection
    Private Sub frmPilotSelection_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadPilots()
    End Sub

    Private Sub LoadPilots()
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
            cmdSelect = New OleDb.OleDbCommand("usp_GetPilotFullNames", m_conAdministrator)
            cmdSelect.CommandType = CommandType.StoredProcedure

            ' Execute the stored procedure and load the results into a DataTable
            Dim drSourceTable As OleDb.OleDbDataReader = cmdSelect.ExecuteReader()
            dt.Load(drSourceTable)

            ' Bind the DataTable to your combo box
            cmbPilots.ValueMember = "intPilotID"
            cmbPilots.DisplayMember = "FullName"
            cmbPilots.DataSource = dt

            ' Clean up the DataReader
            drSourceTable.Close()

            ' Close the database connection
            CloseDatabaseConnection()

        Catch ex As Exception
            ' Log and display error message
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub btnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click

        Dim intPilotId = cmbPilots.SelectedValue
        If intPilotId > 0 Then
            modPilotLogic.intPilotId = cmbPilots.SelectedValue
            modPilotLogic.strPilotFullName = cmbPilots.Text
            Me.DialogResult = DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub


End Class