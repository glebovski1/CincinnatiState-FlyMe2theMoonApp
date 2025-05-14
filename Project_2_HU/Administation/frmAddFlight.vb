Public Class frmAddFlight
    Private Sub frmAddFlight_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadAirports()
        LoadPlaneTypes()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub AddFlight(ByVal strFlightNumber As String, ByVal dtFlightDate As DateTime, ByVal dtDepartureTime As DateTime, ByVal dtLandingTime As DateTime, ByVal intMilesFlown As Integer)
        Try
            Dim strCommnadText As String = ""
            Dim cmdInsert As OleDb.OleDbCommand
            Dim intRowsAffected As Integer

            If OpenDatabaseConnectionSQLServer() = False Then

                ' No, warn the user ...
                MessageBox.Show("Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)

                ' and close the form/application

            End If

            ' prepare proc call
            cmdInsert = New OleDb.OleDbCommand(strCommnadText, m_conAdministrator)
            cmdInsert.CommandText = "usp_InsertFlight"
            cmdInsert.CommandType = CommandType.StoredProcedure

            ' map parameters in exact procedure order
            cmdInsert.Parameters.AddWithValue("@strFlightNumber", strFlightNumber)
            cmdInsert.Parameters.Add(
                    "@dtmFlightDate",
                    OleDb.OleDbType.DBDate
                ).Value = dtFlightDate.Date

            ' Time only (SQL TIME(7))
            cmdInsert.Parameters.Add(
                    "@dtmTimeofDeparture",
                    OleDb.OleDbType.DBTime
                ).Value = dtDepartureTime.TimeOfDay

            cmdInsert.Parameters.Add(
                    "@dtmTimeOfLanding",
                    OleDb.OleDbType.DBTime
                ).Value = dtLandingTime.TimeOfDay
            cmdInsert.Parameters.AddWithValue("@intFromAirportID", CInt(cmbAirportFrom.SelectedValue))
            cmdInsert.Parameters.AddWithValue("@intToAirportID", CInt(cmbAirportTo.SelectedValue))
            cmdInsert.Parameters.AddWithValue("@intMilesFlown", intMilesFlown)
            cmdInsert.Parameters.AddWithValue("@intPlaneID", CInt(cmbPlaneType.SelectedValue))

            ' execute proc
            intRowsAffected = cmdInsert.ExecuteNonQuery()

            If intRowsAffected > 0 Then
                MessageBox.Show("Flight has been added")    ' let user know success
                Me.Close()
            Else
                MessageBox.Show("Failed to add Flight")
            End If

            CloseDatabaseConnection()
            Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub


    Private Sub LoadPlaneTypes()
        Try
            Dim strCommnadText As String = ""
            Dim cmdSelect As OleDb.OleDbCommand
            Dim drSourceTable As OleDb.OleDbDataReader
            Dim dt As DataTable = New DataTable

            If OpenDatabaseConnectionSQLServer() = False Then

                ' No, warn the user ...
                MessageBox.Show("Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)

                ' and close the form/application

            End If

            strCommnadText = "SELECT 
	                                intPlaneID,
	                                strPlaneNumber + ' (' + strPlaneType + ')' As PlaneName
                                FROM TPlanes 
                                JOIN TPlaneTypes On TPlaneTypes.intPlaneTypeID = TPlanes.intPlaneID"
            cmdSelect = New OleDb.OleDbCommand(strCommnadText, modDatabaseUtilities.m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader()
            dt.Load(drSourceTable)

            cmbPlaneType.DataSource = dt
            cmbPlaneType.DisplayMember = "PlaneName"
            cmbPlaneType.ValueMember = "intPlaneID"

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub LoadAirports()
        Try
            Dim strCommnadText As String = ""
            Dim cmdSelect As OleDb.OleDbCommand
            Dim drSourceTable As OleDb.OleDbDataReader
            Dim dtAirports As DataTable = New DataTable


            If OpenDatabaseConnectionSQLServer() = False Then

                ' No, warn the user ...
                MessageBox.Show("Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)

                ' and close the form/application

            End If

            strCommnadText = "SELECT intAirportID, strAirportCity + ' ' + strAirportCode As AirportName FROM TAirports"
            cmdSelect = New OleDb.OleDbCommand(strCommnadText, modDatabaseUtilities.m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader()
            dtAirports.Load(drSourceTable)


            cmbAirportFrom.DataSource = dtAirports
            cmbAirportFrom.DisplayMember = "AirportName"
            cmbAirportFrom.ValueMember = "intAirportID"

            cmbAirportTo.DataSource = dtAirports.Copy()
            cmbAirportTo.DisplayMember = "AirportName"
            cmbAirportTo.ValueMember = "intAirportID"

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Function GetAndValidateInputs(ByRef strFlightNumber As String, ByRef dtFlightDate As DateTime, ByRef dtDepartureTime As DateTime, ByRef dtLandingTime As DateTime, ByRef intMilesFlown As Integer) As Boolean
        Dim boolResult As Boolean = False

        boolResult = GetAndValidateFlightNumber(strFlightNumber) AndAlso
            GetAndValidateFlightDate(dtFlightDate) AndAlso
            GetAndValidateDepartureAndLandingTime(dtDepartureTime, dtLandingTime) AndAlso
            CheckNotSameAirports() AndAlso
            GetAndValidateDistance(intMilesFlown)

        Return boolResult

    End Function

    Private Function GetAndValidateFlightNumber(ByRef strFlightNumber As String) As Boolean
        Dim boolResult As Boolean = False

        If txtFlightNumber.Text.Length > 0 Then

            strFlightNumber = txtFlightNumber.Text
            boolResult = True
        Else
            MessageBox.Show("Flight number required")
            txtFlightNumber.Focus()
        End If


        Return boolResult
    End Function

    Private Function GetAndValidateFlightDate(ByRef dtFlightDate As DateTime) As Boolean
        Dim boolResult As Boolean = False

        If dtpFlightDate.Value > Date.UtcNow() Then

            dtFlightDate = dtpFlightDate.Value
            boolResult = True
        Else
            MessageBox.Show("It should ne future flight")
            txtFlightNumber.Focus()
        End If


        Return boolResult

    End Function

    Private Function GetAndValidateDepartureAndLandingTime(ByRef dtDepartureTime As DateTime, ByRef dtLandingTime As DateTime) As Boolean
        Dim boolResult As Boolean = False
        Dim timeDepartureTime = dtpDepartureTime.Value.TimeOfDay
        Dim timeLandingTime = dtpLandingTime.Value.TimeOfDay
        dtDepartureTime = dtpFlightDate.Value.Date + timeDepartureTime
        dtLandingTime = dtpFlightDate.Value.Date + timeLandingTime
        boolResult = True


        Return boolResult
    End Function

    Private Function GetAndValidateDistance(ByRef intMilesFlown As Integer) As Boolean
        Dim boolResult As Boolean = False
        If nupMilesFlown.Value > 100 Then
            intMilesFlown = nupMilesFlown.Value
            boolResult = True
        Else
            MessageBox.Show("Flight cant be so short")
            boolResult = False
        End If
        Return boolResult
    End Function


    Private Function CheckNotSameAirports() As Boolean
        Dim boolResult As Boolean
        If cmbAirportFrom.SelectedValue = cmbAirportTo.SelectedValue Then
            MessageBox.Show("Choose two different airports")
            boolResult = False
        Else
            boolResult = True

        End If
        Return boolResult
    End Function



    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim strFlightNumber As String = ""
        Dim dtFlightDate As DateTime
        Dim dtDepartureTime As DateTime
        Dim dtLandingTime As DateTime
        Dim intMilesFlown As Integer = 0

        If GetAndValidateInputs(strFlightNumber, dtFlightDate, dtDepartureTime, dtLandingTime, intMilesFlown) Then
            AddFlight(strFlightNumber, dtFlightDate, dtDepartureTime, dtLandingTime, intMilesFlown)
        End If
    End Sub
End Class