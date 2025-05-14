Public Class frmEmployeeLogin
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim strLoginID As String = ""
        Dim strPassword As String = ""
        If GetAndValidateInputs(strLoginID, strPassword) Then
            Login(strLoginID, strPassword)
        End If
    End Sub

    Private Function GetAndValidateInputs(ByRef strLoginID As String, ByRef strPassword As String) As Boolean

        Return GetAndValidateLogin(strLoginID) AndAlso GetAndValidatePassword(strPassword)

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

    Private Function Login(ByVal strLoginID, ByVal strPassword) As Boolean
        Dim boolResult As Boolean = False

        Try
            Dim strSelectCommand As String = ""
            Dim cmdSelect As OleDb.OleDbCommand ' select command object
            Dim drSourceTable As OleDb.OleDbDataReader ' data reader for pulling info
            Dim strEmployeeRole As String = ""
            Dim intEmployeeID As Integer

            ' open the DB
            If OpenDatabaseConnectionSQLServer() = False Then

                ' No, warn the user ...
                MessageBox.Show("Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)

                ' and close the form/application

            End If

            strSelectCommand = "SELECT TOP 1 strEmployeeRole, intEmployeeID " &
                                 "FROM TEmployees " &
                                 "WHERE strEmployeeLoginID = '" & strLoginID & "' AND strEmployeePassword = '" & strPassword & "'"
            cmdSelect = New OleDb.OleDbCommand(strSelectCommand, modDatabaseUtilities.m_conAdministrator)

            drSourceTable = cmdSelect.ExecuteReader()

            If drSourceTable.Read() Then
                strEmployeeRole = drSourceTable("strEmployeeRole")
                If strEmployeeRole <> "Admin" Then
                    intEmployeeID = drSourceTable("intEmployeeID")
                End If
                If strEmployeeRole = "Admin" Then
                    frmAdminMenu.ShowDialog()
                    boolResult = True
                ElseIf strEmployeeRole = "Pilot" Then
                    modPilotLogic.intPilotId = intEmployeeID
                    frmPilotMenu.ShowDialog()

                    boolResult = True
                ElseIf strEmployeeRole = "Attendant" Then
                    modAttendantLogic.intAttendantId = intEmployeeID
                    frmAttendantMenu.ShowDialog()
                    boolResult = True
                End If
            Else
                    MessageBox.Show("ID and/or Password are not Valid")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        Return boolResult
    End Function

    Private Sub frmEmployeeLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class