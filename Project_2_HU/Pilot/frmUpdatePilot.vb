Public Class frmUpdatePilot

    Private Sub frmUpdatePilot_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadPilot(modPilotLogic.intPilotId)
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
            UpdatePilot(strFirstName, strLastName, strLoginID, strPassword)
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


    Private Sub LoadPilot(ByVal intPilotID As Integer)
        Try
            Dim strCommandText As String = ""
            Dim cmdSelect As OleDb.OleDbCommand
            Dim drSourceTable As OleDb.OleDbDataReader

            If OpenDatabaseConnectionSQLServer() = False Then
                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text & " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()
                Return
            End If

            strCommandText = "usp_GetPilotByID"
            cmdSelect = New OleDb.OleDbCommand(strCommandText, modDatabaseUtilities.m_conAdministrator)
            cmdSelect.CommandText = "usp_GetPilotByID"
            cmdSelect.CommandType = CommandType.StoredProcedure
            cmdSelect.Parameters.AddWithValue("@intPilotID", intPilotID)

            drSourceTable = cmdSelect.ExecuteReader()

            If drSourceTable.Read() Then
                txtLoginID.Text = drSourceTable("strEmployeeLoginID").ToString()
                txtPassword.Text = drSourceTable("strEmployeePassword").ToString()
                txtFirstName.Text = drSourceTable("strFirstName").ToString()
                txtLastName.Text = drSourceTable("strLastName").ToString()

            End If




        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub UpdatePilot(ByVal strFirstName As String, ByVal strLastName As String, ByVal strLoginId As String, ByVal strPassword As String)
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


            strUpdate = "UPDATE TPilots SET " &
                        "strFirstName = ?, strLastName = ? " &
                        "WHERE intPilotID = ?; " &
                        "UPDATE TEmployees SET " &
                        "strEmployeeLoginID = ?, strEmployeePassword = ? " &
                        "WHERE intEmployeeID = ? AND strEmployeeRole = 'Pilot';"

            cmdUpdate = New OleDb.OleDbCommand(strUpdate, modDatabaseUtilities.m_conAdministrator)

            ' Add parameters in the same exact order as question marks in the SQL string
            cmdUpdate.Parameters.AddWithValue("?", strFirstName)
            cmdUpdate.Parameters.AddWithValue("?", strLastName)
            cmdUpdate.Parameters.AddWithValue("?", modPilotLogic.intPilotId)

            cmdUpdate.Parameters.AddWithValue("?", strLoginId)
            cmdUpdate.Parameters.AddWithValue("?", strPassword)
            cmdUpdate.Parameters.AddWithValue("?", modPilotLogic.intPilotId)

            ' execute query to insert data
            intRowsAffected = cmdUpdate.ExecuteNonQuery()

            ' If not 0 insert successful
            If intRowsAffected > 0 Then
                MessageBox.Show("Pilot has been Updated")

                ' let user know success
                ' close new player form

                modPilotLogic.strPilotFullName = strFirstName & " " & strLastName
            Else
                MessageBox.Show("Password and LoginID should be unique")
            End If


            CloseDatabaseConnection()       ' close connection if insert didn't work
            Close()


        Catch ex As Exception

            ' Log and display error message
            MessageBox.Show(ex.Message)

        End Try

    End Sub


End Class