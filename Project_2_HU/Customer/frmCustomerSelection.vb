Public Class frmCustomerSelection
    Private Sub btnAddNewCustomer_Click(sender As Object, e As EventArgs) Handles btnAddNewCustomer.Click
        Dim form = frmAddPassenger
        form.ShowDialog()
        LoadPassengers()
    End Sub

    Private Sub frmCustomerSelection_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadPassengers()
    End Sub


    Private Sub LoadPassengers()
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
            strSelect = "SELECT intPassengerID, strFirstName + ' ' + strLastName AS FullName FROM TPassengers"

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader
            dt.Load(drSourceTable)

            cmbPassengers.ValueMember = "intPassengerID"
            cmbPassengers.DisplayMember = "FullName"
            cmbPassengers.DataSource = dt

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

    Private Sub btnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click
        Dim intCustomerId = cmbPassengers.SelectedValue
        If intCustomerId > 0 Then
            modCustomerLogic.intCustomerId = intCustomerId
            modCustomerLogic.strCustomerFullName = cmbPassengers.Text
            Me.Close()
            frmCustomerMenu.ShowDialog()


        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class