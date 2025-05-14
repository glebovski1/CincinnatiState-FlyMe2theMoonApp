Public Class frmAddPassenger

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim strLoginID As String = ""
        Dim strPassword As String = ""
        Dim strFirstName As String = ""
        Dim strLastName As String = ""
        Dim strAddress As String = ""
        Dim strCity As String = ""
        Dim strZip As String = ""
        Dim strPhoneNumber As String = ""
        Dim strEmail As String = ""
        Dim strDateOfBirth As String = ""
        Dim intStateId As Integer = CInt(cmbState.SelectedValue)
        If ValidateInputs(strLoginID, strPassword, strFirstName, strLastName, strAddress, strCity, strZip, strPhoneNumber, strEmail, strDateOfBirth) Then
            modCustomerLogic.AddPassenger(strLoginID, strPassword, strFirstName, strLastName, strAddress, strCity, strZip, strPhoneNumber, strEmail, strDateOfBirth, intStateId)
            Me.Close()
        End If

    End Sub

    Private Function ValidateInputs(ByRef strLoginID As String, ByRef strPassword As String, ByRef strFirstName As String, ByRef strLastName As String, ByRef strAddress As String, ByRef strCity As String, ByRef strZip As String, ByRef strPhoneNumber As String, ByRef strEmail As String, ByRef strDateOfBirth As String) As Boolean
        Dim boolResult As Boolean = False

        boolResult = ValidateFirstName(strFirstName) AndAlso
             ValidateLogin(strLoginID) AndAlso
             ValidatePassword(strPassword) AndAlso
             ValidateLastName(strLastName) AndAlso
             ValidateAddress(strAddress) AndAlso
             ValidateCity(strCity) AndAlso
             ValidateZip(strZip) AndAlso
             ValidatePhoneNumber(strPhoneNumber) AndAlso
             ValidateEmail(strEmail) AndAlso
             ValidateDateBirth(strDateOfBirth)
        Return boolResult
    End Function

    Public Function ValidateLogin(ByRef strLogin As String) As Boolean
        Dim boolResult As Boolean = False
        Dim strTextFromInput As String = txtLoginID.Text
        If strTextFromInput.Length > 0 Then
            boolResult = True
            strLogin = strTextFromInput
        Else
            MessageBox.Show("Login ID required")
            txtLoginID.Focus()
        End If
        Return boolResult

    End Function

    Public Function ValidatePassword(ByRef strPassword As String) As Boolean
        Dim boolResult As Boolean = False
        Dim strTextFromInput As String = txtPassword.Text
        If strTextFromInput.Length > 0 Then
            boolResult = True
            strPassword = strTextFromInput
        Else
            MessageBox.Show("Password required")
            txtPassword.Focus()
        End If
        Return boolResult
    End Function

    Public Function ValidateDateBirth(ByRef strDateOfBirth As String) As Boolean
        Dim boolResult As Boolean = False
        Dim dtDate As Date = dtpDateOfBirth.Value
        If dtDate < Date.UtcNow() Then
            boolResult = True
            strDateOfBirth = dtDate.ToString()
        Else
            MessageBox.Show("Date of birth should be real")

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

    Private Function ValidateAddress(ByRef strAddress As String) As Boolean
        Dim boolResult As Boolean = False
        Dim strTextFromInput As String = txtAddress.Text
        If strTextFromInput.Length > 0 Then
            boolResult = True
            strAddress = strTextFromInput
        Else
            MessageBox.Show("Address required")
            txtAddress.Focus()
        End If
        Return boolResult
    End Function

    Private Function ValidateCity(ByRef strCity As String) As Boolean
        Dim boolResult As Boolean = False
        Dim strTextFromInput As String = txtCity.Text
        If strTextFromInput.Length > 0 Then
            boolResult = True
            strCity = strTextFromInput
        Else
            MessageBox.Show("City required")
            txtCity.Focus()
        End If
        Return boolResult
    End Function

    Private Function ValidateZip(ByRef strZip As String) As Boolean
        Dim boolResult As Boolean = False
        Dim strTextFromInput As String = txtZip.Text
        If strTextFromInput.Length > 0 Then
            boolResult = True
            strZip = strTextFromInput
        Else
            MessageBox.Show("ZIP code required")
            txtZip.Focus()
        End If
        Return boolResult
    End Function

    Private Function ValidatePhoneNumber(ByRef strPhoneNumber As String) As Boolean
        Dim boolResult As Boolean = False
        Dim strTextFromInput As String = txtPhoneNumber.Text
        If strTextFromInput.Length > 0 Then
            boolResult = True
            strPhoneNumber = strTextFromInput
        Else
            MessageBox.Show("Phone number required")
            txtPhoneNumber.Clear()
        End If
        Return boolResult
    End Function


    Private Function ValidateEmail(ByRef strEmail As String) As Boolean
        Dim boolResult As Boolean = False
        Dim strTextFromInput As String = txtEmail.Text

        If strTextFromInput.Length = 0 Then
            MessageBox.Show("Email address required")
            txtEmail.Clear()
            txtEmail.Focus()
        ElseIf Not strTextFromInput.Contains("@") Then
            MessageBox.Show("Email must contain '@'")
            txtEmail.Clear()
            txtEmail.Focus()
        Else
            boolResult = True
            strEmail = strTextFromInput
        End If

        Return boolResult
    End Function

    Private Sub frmAddPassenger_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
            strSelect = "SELECT * FROM TStates"

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader
            dt.Load(drSourceTable)

            'loop through result set and display in Listbox

            cmbState.ValueMember = "intStateID"
            cmbState.DisplayMember = "strState"
            cmbState.DataSource = dt


            ' Clean up
            drSourceTable.Close()

            ' close the database connection
            CloseDatabaseConnection()

        Catch ex As Exception

            ' Log and display error message
            MessageBox.Show(ex.Message)

        End Try
    End Sub


    Private Sub AddPassenger(ByVal strLoginID As String, ByVal strPassword As String, ByVal strFirstName As String, ByVal strLastName As String,
                            ByVal strAddress As String, ByVal strCity As String, ByVal strZip As String, ByVal strPhoneNumber As String, ByVal strEmail As String, ByVal strDateOfBirth As String, ByVal strStateId As String)
        Try

            Dim strSelect As String = ""
            Dim strInsert As String = ""
            Dim cmdInsert As OleDb.OleDbCommand ' insert command object
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


            MessageBox.Show(strInsert)

            ' use insert command with sql string and connection object
            strInsert = "EXECUTE dbo.usp_AddPassenger '" & strLoginID & "', '" & strPassword & "', '" & strFirstName & "', '" &
                strAddress & "', '" & strCity & "', '" & strStateId & "', '" & strZip & "', '" & strPhoneNumber & "', '" & strEmail & "', '" & strDateOfBirth & "'"
            cmdInsert = New OleDb.OleDbCommand(strInsert, m_conAdministrator)






            ' execute query to insert data
            intRowsAffected = cmdInsert.ExecuteNonQuery()

            ' If not 0 insert successful
            If intRowsAffected > 0 Then
                MessageBox.Show("Passenger has been added")    ' let user know success
                ' close new player form
            End If


            CloseDatabaseConnection()       ' close connection if insert didn't work
            Close()


        Catch ex As Exception

            ' Log and display error message
            MessageBox.Show(ex.Message)

        End Try

    End Sub


End Class