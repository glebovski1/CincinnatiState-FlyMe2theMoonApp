Public Class frmUpdateAttendantProfile
    Private Sub frmUpdateAttendantProfile_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadAttendant(modAttendantLogic.intAttendantId)
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim strFirstName As String = ""
        Dim strLastName As String = ""
        Dim strLoginID As String = ""
        Dim strPassword As String = ""
        If ValidateInputs(strFirstName, strLastName, strLoginID, strPassword) Then
            UpdateAttendant(strFirstName, strLastName, strLoginID, strPassword)
        End If
    End Sub

    Private Function ValidateInputs(ByRef strFirstName As String, ByRef strLastName As String, ByRef strLoginID As String, ByRef strPassword As String) As Boolean
        Dim boolResult As Boolean = False

        boolResult = ValidateFirstName(strFirstName) AndAlso
             ValidateLastName(strLastName) AndAlso
             GetAndValidateLogin(strLoginID) AndAlso
             GetAndValidatePassword(strPassword)
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

    Private Sub LoadAttendantData()
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
            strSelect = "SELECT * FROM TAttendants WHERE intAttendantID = " & modAttendantLogic.intAttendantId

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            If drSourceTable.Read() Then
                txtFirstName.Text = drSourceTable("strFirstName")
                txtLastName.Text = drSourceTable("strLastName")

            End If




            ' Clean up
            drSourceTable.Close()

            ' close the database connection
            CloseDatabaseConnection()

        Catch ex As Exception

            ' Log and display error message
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


            End If

            CloseDatabaseConnection()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub UpdateAttendant(ByVal strFirstName As String, ByVal strLastName As String, ByVal strLoginID As String, ByVal strPassword As String)
        Try

            Dim strSelect As String = ""
            Dim strUpdate As String = ""
            Dim cmdUpdate As OleDb.OleDbCommand ' insert command object
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

            strUpdate =
                "UPDATE TAttendants SET " &
                "strFirstName = ?, strLastName = ? " &
                "WHERE intAttendantID = ?; " &
                "UPDATE TEmployees SET " &
                "strEmployeeLoginID = ?, strEmployeePassword = ? " &
                "WHERE intEmployeeID = ? AND strEmployeeRole = 'Attendant';"

            cmdUpdate = New OleDb.OleDbCommand(strUpdate, m_conAdministrator)

            ' Add parameters in the exact order they appear in the SQL string
            cmdUpdate.Parameters.AddWithValue("?", strFirstName)
            cmdUpdate.Parameters.AddWithValue("?", strLastName)
            cmdUpdate.Parameters.AddWithValue("?", modAttendantLogic.intAttendantId)

            cmdUpdate.Parameters.AddWithValue("?", strLoginID)
            cmdUpdate.Parameters.AddWithValue("?", strPassword)
            cmdUpdate.Parameters.AddWithValue("?", modAttendantLogic.intAttendantId)

            ' execute query to insert data
            intRowsAffected = cmdUpdate.ExecuteNonQuery()

            ' If not 0 insert successful
            If intRowsAffected > 0 Then
                MessageBox.Show("Attendant has been Updated")

                ' let user know success
                ' close new player form

                modAttendantLogic.strAttendantFullName = strFirstName & " " & strLastName
            Else
                MessageBox.Show("Attendant was not updated")
            End If


            CloseDatabaseConnection()       ' close connection if insert didn't work
            Close()


        Catch ex As Exception

            ' Log and display error message
            MessageBox.Show(ex.Message)

        End Try

    End Sub
End Class