Module modFlightBooking
    Public Const intA350Capacity As Integer = 48
    Public Const int747Capacity As Integer = 60
    Public Const int767Capacity As Integer = 90

    Public intSelectedFlightID As Integer = 0
    Public strSelectedPlaneType As String = ""

    Public strReservedSeat As String = ""
    Public decPriceForReservation As Decimal = 0


    Public decFlightCost As Decimal = 0
    Public decFlightCostWithReservation As Decimal = 0

    Public Sub ClearBookingData()
        intSelectedFlightID = 0
        strSelectedPlaneType = ""
        strReservedSeat = ""
        decPriceForReservation = 0
        decFlightCost = 0
        decFlightCostWithReservation = 0
    End Sub

    Public Function GetFlightCost(ByVal intSeatsTaken As Integer, ByVal intTotalMiles As Integer, ByVal intPassengerAge As Integer, ByVal intFlightsTakenBeffore As Integer, ByVal strDestination As String, Optional ByVal decSeatReservationCost As Decimal = 0) As Decimal
        Dim decPercentDeduction As Decimal = 0

        Dim decFlightCost As Decimal = 250
        If intTotalMiles > 750 Then
            decFlightCost += 50
        End If

        If intSeatsTaken > 8 Then
            decFlightCost += 100
        End If

        If intSeatsTaken < 4 Then
            decFlightCost -= 50
        End If

        If strDestination.Contains("MIA") Then
            decFlightCost += 15
        End If

        decFlightCost += decSeatReservationCost

        If intPassengerAge >= 65 Then
            decPercentDeduction += 0.2
        ElseIf intPassengerAge <= 5 Then
            decPercentDeduction += 0.65
        End If

        If intFlightsTakenBeffore >= 10 Then
            decPercentDeduction += 0.2
        ElseIf intFlightsTakenBeffore >= 5 Then
            decPercentDeduction += 0.1
        End If

        Return decFlightCost * (1 - decPercentDeduction)

    End Function

    Public Function SwitchLetterAndDigitInSeatName(ByVal strSeatName As String) As String
        If strSeatName.Length > 5 Then
            Return strSeatName
        End If
        Dim digits = New String(strSeatName.Where(AddressOf Char.IsDigit).ToArray())
        Dim letters = New String(strSeatName.Where(AddressOf Char.IsLetter).ToArray())
        If Char.IsDigit(strSeatName(0)) Then
            Return letters & digits   ' "12A" → "A12"
        Else
            Return digits & letters   ' "A12" → "12A"
        End If
    End Function


    Public Sub GetFLightInfo(ByVal intFlightID As Integer, ByRef intFLightDistance As Integer, ByRef intSeatsReserved As Integer, ByRef strDestination As String, ByRef strPlaneType As String)
        Try
            Dim strSelect As String
            Dim cmdSelect As OleDb.OleDbCommand
            Dim drSourceTable As OleDb.OleDbDataReader

            If OpenDatabaseConnectionSQLServer() = False Then

                ' No, warn the user ...
                MessageBox.Show("Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)

                ' and close the form/application
            End If


            strSelect =
                        "SELECT " &
                            "f.intMilesFlown        AS Distance, " &
                            "A.strAirportCity + ' ' + A.strAirportCode AS Destination, " &
                            "PT.strPlaneType    AS PlaneType, " &
                            "COUNT(fp.intFlightPassengerID) AS SeatsReserved " &
                        "FROM TFlights f " &
                        "JOIN TAirports A ON f.intToAirportID = A.intAirportID " &
                        "JOIN TPlanes p   ON f.intPlaneID     = p.intPlaneID " &
                        "JOIN TPlaneTypes PT ON p.intPlaneTypeID = PT.intPlaneTypeID " &
                        "LEFT JOIN TFlightPassengers fp ON f.intFlightID = fp.intFlightID " &
                        "WHERE f.intFlightID = " & intFlightID & " " &
                        "GROUP BY " &
                            "f.intMilesFlown, " &
                            "A.strAirportCity + ' ' + A.strAirportCode, " &
                            "PT.strPlaneType"
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader()
            If drSourceTable.Read() Then
                intFLightDistance = CInt(drSourceTable("Distance"))
                intSeatsReserved = CInt(drSourceTable("SeatsReserved"))
                strDestination = drSourceTable("Destination").ToString()
                strPlaneType = drSourceTable("PlaneType").ToString()
            End If

            drSourceTable.Close()
            CloseDatabaseConnection()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Public Function AddPassengerToFLight(ByVal intPassengerID As Integer, ByVal intFlightID As Integer, ByVal strSeatName As String, ByVal decFlightPrice As String) As Boolean
        Dim boolResult As Boolean = False
        Try
            Dim strInsert As String
            Dim cmdInsert As OleDb.OleDbCommand
            Dim intRowsAffected As Integer = 0

            If OpenDatabaseConnectionSQLServer() = False Then

                ' No, warn the user ...
                MessageBox.Show("Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)

                ' and close the form/application
            End If

            strInsert = "INSERT INTO TFlightPassengers " &
                        "(intFlightID, intPassengerID, strSeat, decFlightCost) " &
                        "VALUES (" & intFlightID & ", " & intPassengerID & ", '" & modFlightBooking.SwitchLetterAndDigitInSeatName(strSeatName) & "', " & decFlightPrice & ")"
            cmdInsert = New OleDb.OleDbCommand(strInsert, modDatabaseUtilities.m_conAdministrator)
            intRowsAffected = cmdInsert.ExecuteNonQuery()
            If intRowsAffected > 0 Then
                MessageBox.Show("Flight booked")
                boolResult = True
            Else
                MessageBox.Show("Flight not booked (Something went wrong)")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        Return boolResult
    End Function




End Module
