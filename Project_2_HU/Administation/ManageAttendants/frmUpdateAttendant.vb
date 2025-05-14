Public Class frmUpdateAttendant
    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim strLogin As String = ""
        Dim strPassword As String = ""
        Dim strFirstName As String = ""
        Dim strLastName As String = ""
        Dim strEmployeeID As String = ""
        Dim strLicenseDtate As String = ""
        Dim strHireDate As String = ""
        If ValidateInputs(strLogin, strPassword, strFirstName, strLastName, strEmployeeID, strLicenseDtate, strHireDate) Then
            UpdateAttendat(strLogin, strPassword, strFirstName, strLastName, strEmployeeID, strHireDate)
        End If
    End Sub

    Private Sub frmUpdateAttendant_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadAttendant(modAttendantLogic.intAttendantId)
    End Sub

    Private Sub UpdateAttendat(ByVal strLoginId As String, ByVal strPassword As String, ByVal strFirstName As String, ByVal strLastName As String, ByVal strEmployeeID As String, ByVal strHireDate As String)
        Try
            Dim strUpdate As String = ""
            Dim cmdUpdate As OleDb.OleDbCommand    ' update command object
            Dim intRowsAffected As Integer               ' how many rows were affected

            ' open the DB
            If OpenDatabaseConnectionSQLServer() = False Then
                MessageBox.Show(Me,
                    "Database connection error." & vbNewLine &
                    "The application will now close.",
                    Me.Text & " Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error)
                Me.Close()
                Return
            End If


            cmdUpdate = New OleDb.OleDbCommand(strUpdate, m_conAdministrator)
            cmdUpdate.CommandText = "usp_UpdateAttendantWithEmployee"
            cmdUpdate.CommandType = CommandType.StoredProcedure

            cmdUpdate.Parameters.AddWithValue("@intAttendantID", modAttendantLogic.intAttendantId)
            cmdUpdate.Parameters.AddWithValue("@strEmployeeLoginID", strLoginId)
            cmdUpdate.Parameters.AddWithValue("@strEmployeePassword", strPassword)
            cmdUpdate.Parameters.AddWithValue("@strEmployeeRole", "Attendant")
            cmdUpdate.Parameters.AddWithValue("@strEmployeeID", strEmployeeID)
            cmdUpdate.Parameters.AddWithValue("@strFirstName", strFirstName)
            cmdUpdate.Parameters.AddWithValue("@strLastName", strLastName)
            cmdUpdate.Parameters.AddWithValue("@dtmDateOfHire", DateTime.Parse(strHireDate))
            cmdUpdate.Parameters.AddWithValue("@dtmDateOfTermination", DateTime.Parse("2040-01-01"))

            ' execute proc
            intRowsAffected = cmdUpdate.ExecuteNonQuery()

            If intRowsAffected > 0 Then
                MessageBox.Show("Attendant has been updated")
            End If

            CloseDatabaseConnection()
            Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub LoadAttendant(ByVal intAttendantId As Integer)
        Try
            Dim strSelect As String = ""
            Dim cmdSelect As OleDb.OleDbCommand    ' command object
            Dim drSourceTable As OleDb.OleDbDataReader ' data reader

            ' open the DB
            If OpenDatabaseConnectionSQLServer() = False Then
                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text & " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()
                Return
            End If

            '— we’re using the stored proc instead of a raw SQL string
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            cmdSelect.CommandText = "usp_GetAttendantByID"
            cmdSelect.CommandType = CommandType.StoredProcedure
            cmdSelect.Parameters.AddWithValue("@intAttendantID", intAttendantId)

            drSourceTable = cmdSelect.ExecuteReader()

            If drSourceTable.Read() Then
                txtLoginID.Text = drSourceTable("strEmployeeLoginID").ToString()
                txtPassword.Text = drSourceTable("strEmployeePassword").ToString()
                txtFirstName.Text = drSourceTable("strFirstName").ToString()
                txtLastName.Text = drSourceTable("strLastName").ToString()
                dtmDateOfHire.Value = CDate(drSourceTable("dtmDateOfHire"))
                txtEmployeeID.Text = drSourceTable("strEmployeeID")

            End If

            CloseDatabaseConnection()

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