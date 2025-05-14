Public Class frmBookFlight
    'This veriable suppose to block loading flight first flight in combobox on form loading
    Private intMinIndexForFlightSelection As Integer = 1
    Private Sub frmBookFlight_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        rbNotReserve.Enabled = False
        rbReserve.Enabled = False
        rbNotReserve.Checked = False
        rbReserve.Checked = False
        lblSeat.Text = ""
        lblPriceWithoutReservation.Text = ""
        lblPriceWithReservation.Text = ""

        modFlightBooking.ClearBookingData()
        LoadFlights()
        cmbFlights.SelectedIndex = -1
        intMinIndexForFlightSelection = 0
    End Sub

    Private Sub LoadFlights()
        Try
            Dim strSelect As String = ""
            Dim cmdSelect As OleDb.OleDbCommand
            Dim drSourceTable As OleDb.OleDbDataReader
            Dim dt As DataTable = New DataTable

            If OpenDatabaseConnectionSQLServer() = False Then

                ' No, warn the user ...
                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)

                ' and close the form/application
                Me.Close()

            End If



            strSelect = "SELECT
                            F.intFlightID,
                            F.strFlightNumber,
                            F.dtmFlightDate,
                            F.dtmTimeOfDeparture,
                            F.dtmTimeOfLanding,
                            PT.strPlaneType,
                            Fr.strAirportCode   AS FromAirport,
                            Dest.strAirportCode AS ToAirport,
                            COUNT(P.intFlightPassengerID) AS SeatsTaken,
	                        F.strFlightNumber + ' (' + FORMAT(F.dtmFlightDate, 'yyyy-MM-dd') + ' From ' + Fr.strAirportCode + ' to ' + Dest.strAirportCode + ')' As FullFlightName
                        FROM dbo.TFlights            AS F
                        LEFT JOIN dbo.TFlightPassengers AS P 
                            ON F.intFlightID = P.intFlightID
                        LEFT JOIN dbo.TPlanes       AS PL
                            ON PL.intPlaneID = F.intPlaneID
                        LEFT JOIN dbo.TPlaneTypes   AS PT
                            ON PT.intPlaneTypeID = PL.intPlaneTypeID
                        LEFT JOIN dbo.TAirports     AS Fr
                            ON Fr.intAirportID = F.intFromAirportID    
                        LEFT JOIN dbo.TAirports     AS Dest
                            ON Dest.intAirportID = F.intToAirportID
                        WHERE
                            F.dtmFlightDate >= CAST(GETDATE() AS DATE)
                        GROUP BY
                            F.intFlightID,
                            F.strFlightNumber,
                            F.dtmFlightDate,
                            F.dtmTimeOfDeparture,
                            F.dtmTimeOfLanding,
                            PT.strPlaneType,
                            Fr.strAirportCode,
                            Dest.strAirportCode
                        ORDER BY
                            F.dtmFlightDate,
                            F.dtmTimeOfDeparture;"


            cmdSelect = New OleDb.OleDbCommand(strSelect, modDatabaseUtilities.m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader()
            dt.Load(drSourceTable)

            FilterFullFlight(dt)

            cmbFlights.ValueMember = "intFlightID"
            cmbFlights.DisplayMember = "FullFlightName"
            cmbFlights.DataSource = dt

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Public Sub FilterFullFlight(ByRef dt As DataTable)
        ' FILTER rows here
        For i As Integer = dt.Rows.Count - 1 To 0 Step -1
            Dim row As DataRow = dt.Rows(i)

            If row.IsNull("SeatsTaken") OrElse row.IsNull("strPlaneType") Then
                Continue For
            End If

            Dim intSeatsTaken As Integer = row("SeatsTaken")
            Dim strPlaneType As String = row("strPlaneType")

            If strPlaneType = "Airbus A350" And intSeatsTaken >= modFlightBooking.intA350Capacity Then
                dt.Rows.RemoveAt(i)
            ElseIf strPlaneType = "Boeing 747-8" And intSeatsTaken >= modFlightBooking.int747Capacity Then
                dt.Rows.RemoveAt(i)
            ElseIf strPlaneType = "Boeing 767-300F" And intSeatsTaken >= modFlightBooking.int767Capacity Then
                dt.Rows.RemoveAt(i)
            End If
        Next
    End Sub




    Private Sub cmbFlights_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFlights.SelectedIndexChanged
        If cmbFlights.SelectedIndex >= intMinIndexForFlightSelection Then
            modFlightBooking.intSelectedFlightID = cmbFlights.SelectedValue
            LoadPrice()
        End If
    End Sub

    Private Function LoadPrice() As Decimal

        Dim intflightID As Integer = CInt(cmbFlights.SelectedValue)
        Dim decFlightCost As Decimal = 0
        Dim decFlightCostWithReservation As Decimal = 0

        'Flight info'
        Dim intFlightDistance As Integer
        Dim intSeatsReserved As Integer
        Dim strDestination As String = String.Empty
        Dim strPlaneType As String = String.Empty

        'Passenger info

        Dim intAge As Integer
        Dim intFlightTaken As Integer


        modFlightBooking.GetFLightInfo(intflightID, intFlightDistance, intSeatsReserved, strDestination, strPlaneType)

        intAge = modCustomerLogic.GetCustomerAge(modCustomerLogic.intCustomerId)

        intFlightTaken = modCustomerLogic.GetNumberOfFlight(modCustomerLogic.intCustomerId)


        decFlightCost = modFlightBooking.GetFlightCost(intSeatsReserved, intFlightDistance, intAge, intFlightTaken, strDestination)

        If decFlightCost > 0 Then
            rbNotReserve.Enabled = True
        End If

        If modFlightBooking.decPriceForReservation > 0 Then
            decFlightCostWithReservation = modFlightBooking.GetFlightCost(intSeatsReserved, intFlightDistance, intAge, intFlightTaken, strDestination, modFlightBooking.decPriceForReservation)
            lblPriceWithReservation.Text = decFlightCostWithReservation.ToString("c")
            rbReserve.Enabled = True
        End If

        lblPriceWithoutReservation.Text = decFlightCost.ToString("c")

        modFlightBooking.strSelectedPlaneType = strPlaneType
        modFlightBooking.decFlightCostWithReservation = decFlightCostWithReservation
        modFlightBooking.decFlightCost = decFlightCost

        Return decFlightCost


    End Function

    Private Sub btnBookFlight_Click(sender As Object, e As EventArgs) Handles btnBookFlight.Click
        If cmbFlights.SelectedIndex < 0 Then
            MessageBox.Show("Flight not selected")
        Else

            If (Not rbNotReserve.Checked) And (Not rbReserve.Checked) Then
                MessageBox.Show("Option not selected")
            Else
                BookFlight()
            End If
        End If

    End Sub


    Public Sub BookFlight()
        Dim boolResult As Boolean = False
        If modFlightBooking.intSelectedFlightID > 0 Then
            If rbNotReserve.Checked Then

                If MessageBox.Show("Price (Not reserved): " & modFlightBooking.decFlightCost.ToString("c"),
                "Confirm Book",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) = DialogResult.Yes Then
                    boolResult = modFlightBooking.AddPassengerToFLight(modCustomerLogic.intCustomerId, modFlightBooking.intSelectedFlightID, "Seat to be assigned at Check In", modFlightBooking.decFlightCost)
                Else
                    Me.Close()
                End If
            ElseIf rbReserve.Checked Then
                If MessageBox.Show("Price (Reserved " & modFlightBooking.strReservedSeat & " ): " & modFlightBooking.decFlightCostWithReservation.ToString("c"),
                "Confirm Book",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) = DialogResult.Yes Then
                    boolResult = modFlightBooking.AddPassengerToFLight(modCustomerLogic.intCustomerId, modFlightBooking.intSelectedFlightID, modFlightBooking.strReservedSeat, modFlightBooking.decFlightCostWithReservation)

                Else
                    Me.Close()
                End If
            End If
        End If

        If boolResult Then
            Me.Close()
        Else
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnSelectSeat_Click(sender As Object, e As EventArgs) Handles btnSelectSeat.Click
        If cmbFlights.SelectedIndex >= 0 Then

            If modFlightBooking.strSelectedPlaneType = "Airbus A350" Then
                Dim frmSelectSeat As frmAirbus350 = New frmAirbus350()
                frmSelectSeat.ShowDialog()

            ElseIf modFlightBooking.strSelectedPlaneType = "Boeing 747-8" Then

                Dim frmSelectSeat As frmBoeing747_8 = New frmBoeing747_8()
                frmSelectSeat.ShowDialog()

            ElseIf modFlightBooking.strSelectedPlaneType = "Boeing 767-300F" Then

                Dim frmSelectSeat As frmBoeing_767_300F = New frmBoeing_767_300F()
                frmSelectSeat.ShowDialog()
            End If

            LoadPrice()

            If modFlightBooking.strReservedSeat.Length > 0 Then
                lblSeat.Text = modFlightBooking.strReservedSeat
            End If
        Else
            MessageBox.Show("Flight not select")
        End If

    End Sub
End Class

