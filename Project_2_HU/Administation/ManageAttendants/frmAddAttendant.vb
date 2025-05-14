Public Class frmAddAttendant
    Private Sub frmAddAttendant_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim strLogin As String = ""
        Dim strPassword As String = ""
        Dim strFirstName As String = ""
        Dim strLastName As String = ""
        Dim strEmployeeID As String = ""
        Dim strLicenseDtate As String = ""
        Dim strHireDate As String = ""


        If ValidateInputs(strLogin, strPassword, strFirstName, strLastName, strEmployeeID, strLicenseDtate, strHireDate) Then
            InsertAttendant(strLogin, strPassword, strFirstName, strLastName, strEmployeeID, strHireDate)
        End If
    End Sub

    Private Sub InsertAttendant(ByVal strLoginId As String, ByVal strPassword As String, ByVal strFirstName As String, ByVal strLastName As String, ByVal strEmployeeID As String, ByVal strHireDate As String)

        Try

            Dim strSelect As String = ""
            Dim strInsert As String = ""
            Dim cmdInsert As OleDb.OleDbCommand ' insert command object
            Dim intRowsAffected As Integer  ' how many rows were affected when sql executed

            ' open the DB
            If OpenDatabaseConnectionSQLServer() = False Then
                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text & " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()
                Return
            End If

            ' use insert command with sql string and connection object
            cmdInsert = New OleDb.OleDbCommand(strInsert, m_conAdministrator)
            cmdInsert.CommandText = "usp_InsertAttendantWithEmployee"
            cmdInsert.CommandType = CommandType.StoredProcedure

            ' map proc parameters
            cmdInsert.Parameters.AddWithValue("@strEmployeeLoginID", strLoginId)
            cmdInsert.Parameters.AddWithValue("@strEmployeePassword", strPassword)
            cmdInsert.Parameters.AddWithValue("@strEmployeeRole", "Attendant")
            cmdInsert.Parameters.AddWithValue("@strEmployeeID", strEmployeeID)
            cmdInsert.Parameters.AddWithValue("@strFirstName", strFirstName)
            cmdInsert.Parameters.AddWithValue("@strLastName", strLastName)
            cmdInsert.Parameters.AddWithValue("@dtmDateOfHire", DateTime.Parse(strHireDate))
            cmdInsert.Parameters.AddWithValue("@dtmDateOfTermination", DateTime.Parse("2040-01-01"))

            ' execute proc
            intRowsAffected = cmdInsert.ExecuteNonQuery()

            If intRowsAffected > 0 Then
                MessageBox.Show("Attendant has been added")    ' let user know success
            End If

            CloseDatabaseConnection()
            Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub


    'Validation
    Private Function ValidateInputs(ByRef strLoginID As String, ByRef strPassword As String, ByRef strFirstName As String, ByRef strLastName As String, ByRef strEmployeeId As String, ByRef strDateTime As String, ByRef strHireDate As String) As Boolean
        Dim boolResult As Boolean = False

        boolResult =
             GetAndValidateLogin(strLoginID) AndAlso
             GetAndValidatePassword(strPassword) AndAlso
             ValidateFirstName(strFirstName) AndAlso
             ValidateLastName(strLastName) AndAlso
             ValidateEmployeeID(strEmployeeId) AndAlso
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