Public Class frmAddPilot
    Private Sub frmAddPilot_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadRoles()
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim strLoginID As String = ""
        Dim strPassword As String = ""
        Dim strFirstName As String = ""
        Dim strLastName As String = ""
        Dim strEmployeeID As String = ""
        Dim strLicenseDtate As String = ""
        Dim strHireDate As String = ""


        If ValidateInputs(strLoginID, strPassword, strFirstName, strLastName, strEmployeeID, strLicenseDtate, strHireDate) Then
            InsertPilot(strLoginID, strPassword, strFirstName, strLastName, strEmployeeID, strLicenseDtate, strHireDate)
        End If

    End Sub

    Private Sub InsertPilot(ByVal strLoginID As String, ByVal strPassword As String, ByVal strFirstName As String, ByVal strLastName As String, ByVal strEmployeeID As String, ByVal strLicenseDtate As String, ByVal strHireDate As String)
        Try

            Dim strSelect As String = ""
            Dim strInsert As String = ""
            'Dim cmdSelect As OleDb.OleDbCommand ' select command object
            Dim cmdInsert As OleDb.OleDbCommand ' insert command object
            Dim drSourceTable As OleDb.OleDbDataReader ' data reader for pulling info
            Dim intNextPrimaryKey As Integer ' holds next highest PK value
            Dim intRowsAffected As Integer  ' how many rows were affected when sql executed


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



            ' use insert command with sql string and connection object
            cmdInsert = New OleDb.OleDbCommand(strInsert, m_conAdministrator)
            cmdInsert.CommandText = "usp_InsertPilotWithEmployee"
            cmdInsert.CommandType = CommandType.StoredProcedure
            cmdInsert.Parameters.AddWithValue("@strEmployeeLoginID", strLoginID)
            cmdInsert.Parameters.AddWithValue("@strEmployeePassword", strPassword)
            cmdInsert.Parameters.AddWithValue("@strEmployeeRole", "Pilot")
            cmdInsert.Parameters.AddWithValue("@strEmployeeID", strEmployeeID)
            cmdInsert.Parameters.AddWithValue("@strFirstName", strFirstName)
            cmdInsert.Parameters.AddWithValue("@strLastName", strLastName)

            ' Parse your dates
            cmdInsert.Parameters.AddWithValue("@dtmDateOfHire", DateTime.Parse(strHireDate))
            cmdInsert.Parameters.AddWithValue("@dtmDateOfTermination", DateTime.Parse("2040-01-01"))
            cmdInsert.Parameters.AddWithValue("@dtmDateOfLicense", DateTime.Parse(strLicenseDtate))

            cmdInsert.Parameters.AddWithValue("@intPilotRoleID", CInt(cmbRole.SelectedValue))


            intRowsAffected = cmdInsert.ExecuteNonQuery()

            ' If not 0 insert successful
            If intRowsAffected > 0 Then
                MessageBox.Show("Pilot has been added")    ' let user know success
                ' close new player form
            End If


            CloseDatabaseConnection()       ' close connection if insert didn't work
            Close()


        Catch ex As Exception

            ' Log and display error message
            MessageBox.Show(ex.Message)

        End Try

    End Sub

    Private Sub LoadRoles()
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
            strSelect = "SELECT * FROM TPilotRoles"

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader
            dt.Load(drSourceTable)

            'loop through result set and display in Listbox

            cmbRole.ValueMember = "intPilotRoleID"
            cmbRole.DisplayMember = "strPilotRole"
            cmbRole.DataSource = dt


            ' Clean up
            drSourceTable.Close()

            ' close the database connection
            CloseDatabaseConnection()

        Catch ex As Exception

            ' Log and display error message
            MessageBox.Show(ex.Message)

        End Try
    End Sub



    'Validation

    Private Function ValidateInputs(ByRef strLoginId As String, ByRef strPassword As String, ByRef strFirstName As String, ByRef strLastName As String, ByRef strEmployeeId As String, ByRef strDateTime As String, ByRef strHireDate As String) As Boolean
        Dim boolResult As Boolean = False

        boolResult =
             GetAndValidateLogin(strLoginId) AndAlso
             GetAndValidatePassword(strPassword) AndAlso
             ValidateFirstName(strFirstName) AndAlso
             ValidateLastName(strLastName) AndAlso
             ValidateEmployeeID(strEmployeeId) AndAlso
             ValidateLicenseDate(strDateTime) AndAlso
             ValidateHireDate(strHireDate)

        Return boolResult
    End Function

    Private Function GetAndValidatePassword(ByRef strPassword As String) As Boolean
        Dim boolResult As Boolean = False
        If txtPassword.Text.Length > 0 Then
            boolResult = True

            strPassword = txtPassword.Text
        Else
            MessageBox.Show("Password required")
        End If
        Return boolResult
    End Function

    Private Function GetAndValidateLogin(ByRef strLoginID As String) As Boolean
        Dim boolResult As Boolean = False
        If txtLoginID.Text.Length > 0 Then
            boolResult = True

            strLoginID = txtLoginID.Text
        Else
            MessageBox.Show("Login required")
        End If
        Return boolResult
    End Function

    Private Function ValidateFirstName(ByRef strFirstName As String) As Boolean
        Dim boolResult As Boolean = False
        Dim strTextFromInput As String = txtFirstName.Text
        If strTextFromInput.Length > 0 Then
            boolResult = True
            strFirstName = strTextFromInput
        Else
            MessageBox.Show("First name required")
            txtFirstName.Focus()
        End If
        Return boolResult
    End Function

    Private Function ValidateLastName(ByRef strLastName As String) As Boolean
        Dim boolResult As Boolean = False
        Dim strTextFromInput As String = txtLastName.Text
        If strTextFromInput.Length > 0 Then
            boolResult = True
            strLastName = strTextFromInput
        Else
            MessageBox.Show("Last name required")
            txtLastName.Focus()
        End If
        Return boolResult
    End Function

    Private Function ValidateEmployeeID(ByRef strEmployeeId As String) As Boolean
        Dim boolResult As Boolean = False
        Dim strTextFromInput As String = txtEmployeeID.Text
        If strTextFromInput.Length > 0 Then
            boolResult = True
            strEmployeeId = strTextFromInput
        Else
            MessageBox.Show("Employee ID required")
            txtEmployeeID.Focus()
        End If
        Return boolResult
    End Function

    Private Function ValidateLicenseDate(ByRef strLicenseDate As String) As Boolean
        Dim strDateTime As String = dtmLicenseDate.Value.ToString("yyyy-MM-dd")
        Dim boolResult As Boolean = False
        If strDateTime.Length > 0 Then
            strLicenseDate = strDateTime
            boolResult = True
        Else
            MessageBox.Show("License Date required")
        End If
        Return boolResult
    End Function


    Private Function ValidateHireDate(ByRef strHireDate As String) As Boolean
        Dim strDateTime As String = dtmDateOfHire.Value.ToString("yyyy-MM-dd")
        Dim boolResult As Boolean = False
        If strDateTime.Length > 0 Then
            strHireDate = strDateTime
            boolResult = True
        Else
            MessageBox.Show("Hire Date required")
        End If
        Return boolResult
    End Function

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub


End Class