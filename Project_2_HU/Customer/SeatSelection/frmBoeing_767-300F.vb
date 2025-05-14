Public Class frmBoeing_767_300F
    Private Sub frmBoeing_767_300F_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadTakenSeats(modFlightBooking.intSelectedFlightID)
    End Sub

    Private Sub LoadTakenSeats(ByVal intFlightID As Integer)
        Try
            Dim strCommand As String = ""
            Dim cmdSelect As OleDb.OleDbCommand ' select command object
            Dim drSourceTable As OleDb.OleDbDataReader ' data reader for pulling info

            ' open the DB
            If OpenDatabaseConnectionSQLServer() = False Then

                ' No, warn the user ...
                MessageBox.Show("Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)

                ' and close the form/application
            End If

            strCommand = "usp_GetTakenSeatsByFlight"


            cmdSelect = New OleDb.OleDbCommand(strCommand, modDatabaseUtilities.m_conAdministrator)
            cmdSelect.CommandType = CommandType.StoredProcedure
            cmdSelect.Parameters.AddWithValue("@intFlightID", intFlightID)
            drSourceTable = cmdSelect.ExecuteReader()

            While drSourceTable.Read()
                Dim strSeat As String = modFlightBooking.SwitchLetterAndDigitInSeatName(drSourceTable("strSeat"))
                Dim chk As CheckBox = TryCast(Me.Controls(strSeat), CheckBox)
                If chk IsNot Nothing Then
                    chk.Checked = True
                    chk.Enabled = False
                End If

            End While



        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub UncheckEnabledCheckBoxesExept(ByVal strCheckedLast As String)
        For Each cb As CheckBox In Controls.OfType(Of CheckBox)
            If cb.Enabled = True AndAlso cb.Name <> strCheckedLast Then
                cb.Checked = False
            End If

        Next
    End Sub

    Private Sub ProcessCheckedSeat(ByVal strSeatName As String)
        Dim decReservePrice As Decimal = 0
        Dim intRow As Integer = 0
        Dim strRow As String = ""
        Dim strLetter As String = ""
        For intIndex As Integer = 0 To strSeatName.Length - 1
            If Char.IsDigit(strSeatName(intIndex)) Then

                strRow += strSeatName(intIndex)

            ElseIf Char.IsLetter(strSeatName(intIndex)) Then

                strLetter += strSeatName(intIndex)

            End If
        Next
        intRow = CInt(strRow)

        If intRow > 8 Then
            decReservePrice += 20
        ElseIf intRow > 3 Then
            decReservePrice += 50
        ElseIf intRow > 0 Then
            decReservePrice += 150
        End If

        If intRow <= 8 And (strLetter = "D" Or strLetter = "E" Or strLetter = "F") Then
            decReservePrice -= 10
        End If



        modFlightBooking.strReservedSeat = strSeatName
        modFlightBooking.decPriceForReservation = decReservePrice
    End Sub

    Private Sub btnReserve_Click(sender As Object, e As EventArgs) Handles btnReserve.Click
        Dim boolCheckedExist As Boolean = False
        For Each cb As CheckBox In Controls.OfType(Of CheckBox)
            If cb.Checked AndAlso cb.Enabled() Then
                ProcessCheckedSeat(cb.Name)
                boolCheckedExist = True
                Me.Close()
            End If
        Next
        If boolCheckedExist = False Then
            MessageBox.Show("Seat not choosen")

        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

#Region "Check box events"

    Private Sub A1_CheckedChanged(sender As Object, e As EventArgs) Handles A1.CheckedChanged
        Dim chk As CheckBox = CType(sender, CheckBox)
        Dim strSeatName As String = chk.Name
        UncheckEnabledCheckBoxesExept(strSeatName)
    End Sub

    Private Sub B1_CheckedChanged(sender As Object, e As EventArgs) Handles B1.CheckedChanged
        Dim chk As CheckBox = CType(sender, CheckBox)
        Dim strSeatName As String = chk.Name
        UncheckEnabledCheckBoxesExept(strSeatName)
    End Sub

    Private Sub C1_CheckedChanged(sender As Object, e As EventArgs) Handles C1.CheckedChanged
        Dim chk As CheckBox = CType(sender, CheckBox)
        Dim strSeatName As String = chk.Name
        UncheckEnabledCheckBoxesExept(strSeatName)
    End Sub

    Private Sub D1_CheckedChanged(sender As Object, e As EventArgs) Handles D1.CheckedChanged
        Dim chk As CheckBox = CType(sender, CheckBox)
        Dim strSeatName As String = chk.Name
        UncheckEnabledCheckBoxesExept(strSeatName)
    End Sub

    Private Sub E1_CheckedChanged(sender As Object, e As EventArgs) Handles E1.CheckedChanged
        Dim chk As CheckBox = CType(sender, CheckBox)
        Dim strSeatName As String = chk.Name
        UncheckEnabledCheckBoxesExept(strSeatName)
    End Sub

    Private Sub F1_CheckedChanged(sender As Object, e As EventArgs) Handles F1.CheckedChanged
        Dim chk As CheckBox = CType(sender, CheckBox)
        Dim strSeatName As String = chk.Name
        UncheckEnabledCheckBoxesExept(strSeatName)
    End Sub

    Private Sub G1_CheckedChanged(sender As Object, e As EventArgs) Handles G1.CheckedChanged
        Dim chk As CheckBox = CType(sender, CheckBox)
        Dim strSeatName As String = chk.Name
        UncheckEnabledCheckBoxesExept(strSeatName)
    End Sub

    Private Sub H1_CheckedChanged(sender As Object, e As EventArgs) Handles H1.CheckedChanged
        Dim chk As CheckBox = CType(sender, CheckBox)
        Dim strSeatName As String = chk.Name
        UncheckEnabledCheckBoxesExept(strSeatName)
    End Sub

    Private Sub I1_CheckedChanged(sender As Object, e As EventArgs) Handles I1.CheckedChanged
        Dim chk As CheckBox = CType(sender, CheckBox)
        Dim strSeatName As String = chk.Name
        UncheckEnabledCheckBoxesExept(strSeatName)
    End Sub

    Private Sub A2_CheckedChanged(sender As Object, e As EventArgs) Handles A2.CheckedChanged
        Dim chk As CheckBox = CType(sender, CheckBox)
        Dim strSeatName As String = chk.Name
        UncheckEnabledCheckBoxesExept(strSeatName)
    End Sub

    Private Sub B2_CheckedChanged(sender As Object, e As EventArgs) Handles B2.CheckedChanged
        Dim chk As CheckBox = CType(sender, CheckBox)
        Dim strSeatName As String = chk.Name
        UncheckEnabledCheckBoxesExept(strSeatName)
    End Sub

    Private Sub C2_CheckedChanged(sender As Object, e As EventArgs) Handles C2.CheckedChanged
        Dim chk As CheckBox = CType(sender, CheckBox)
        Dim strSeatName As String = chk.Name
        UncheckEnabledCheckBoxesExept(strSeatName)
    End Sub

    Private Sub D2_CheckedChanged(sender As Object, e As EventArgs) Handles D2.CheckedChanged
        Dim chk As CheckBox = CType(sender, CheckBox)
        Dim strSeatName As String = chk.Name
        UncheckEnabledCheckBoxesExept(strSeatName)
    End Sub

    Private Sub E2_CheckedChanged(sender As Object, e As EventArgs) Handles E2.CheckedChanged
        Dim chk As CheckBox = CType(sender, CheckBox)
        Dim strSeatName As String = chk.Name
        UncheckEnabledCheckBoxesExept(strSeatName)
    End Sub

    Private Sub F2_CheckedChanged(sender As Object, e As EventArgs) Handles F2.CheckedChanged
        Dim chk As CheckBox = CType(sender, CheckBox)
        Dim strSeatName As String = chk.Name
        UncheckEnabledCheckBoxesExept(strSeatName)
    End Sub

    Private Sub G2_CheckedChanged(sender As Object, e As EventArgs) Handles G2.CheckedChanged
        Dim chk As CheckBox = CType(sender, CheckBox)
        Dim strSeatName As String = chk.Name
        UncheckEnabledCheckBoxesExept(strSeatName)
    End Sub

    Private Sub H2_CheckedChanged(sender As Object, e As EventArgs) Handles H2.CheckedChanged
        Dim chk As CheckBox = CType(sender, CheckBox)
        Dim strSeatName As String = chk.Name
        UncheckEnabledCheckBoxesExept(strSeatName)
    End Sub

    Private Sub I2_CheckedChanged(sender As Object, e As EventArgs) Handles I2.CheckedChanged
        Dim chk As CheckBox = CType(sender, CheckBox)
        Dim strSeatName As String = chk.Name
        UncheckEnabledCheckBoxesExept(strSeatName)
    End Sub

    Private Sub A3_CheckedChanged(sender As Object, e As EventArgs) Handles A3.CheckedChanged
        Dim chk As CheckBox = CType(sender, CheckBox)
        Dim strSeatName As String = chk.Name
        UncheckEnabledCheckBoxesExept(strSeatName)
    End Sub

    Private Sub B3_CheckedChanged(sender As Object, e As EventArgs) Handles B3.CheckedChanged
        Dim chk As CheckBox = CType(sender, CheckBox)
        Dim strSeatName As String = chk.Name
        UncheckEnabledCheckBoxesExept(strSeatName)
    End Sub

    Private Sub C3_CheckedChanged(sender As Object, e As EventArgs) Handles C3.CheckedChanged
        Dim chk As CheckBox = CType(sender, CheckBox)
        Dim strSeatName As String = chk.Name
        UncheckEnabledCheckBoxesExept(strSeatName)
    End Sub

    Private Sub D3_CheckedChanged(sender As Object, e As EventArgs) Handles D3.CheckedChanged
        Dim chk As CheckBox = CType(sender, CheckBox)
        Dim strSeatName As String = chk.Name
        UncheckEnabledCheckBoxesExept(strSeatName)
    End Sub

    Private Sub E3_CheckedChanged(sender As Object, e As EventArgs) Handles E3.CheckedChanged
        Dim chk As CheckBox = CType(sender, CheckBox)
        Dim strSeatName As String = chk.Name
        UncheckEnabledCheckBoxesExept(strSeatName)
    End Sub

    Private Sub F3_CheckedChanged(sender As Object, e As EventArgs) Handles F3.CheckedChanged
        Dim chk As CheckBox = CType(sender, CheckBox)
        Dim strSeatName As String = chk.Name
        UncheckEnabledCheckBoxesExept(strSeatName)
    End Sub

    Private Sub G3_CheckedChanged(sender As Object, e As EventArgs) Handles G3.CheckedChanged
        Dim chk As CheckBox = CType(sender, CheckBox)
        Dim strSeatName As String = chk.Name
        UncheckEnabledCheckBoxesExept(strSeatName)
    End Sub

    Private Sub H3_CheckedChanged(sender As Object, e As EventArgs) Handles H3.CheckedChanged
        Dim chk As CheckBox = CType(sender, CheckBox)
        Dim strSeatName As String = chk.Name
        UncheckEnabledCheckBoxesExept(strSeatName)
    End Sub

    Private Sub I3_CheckedChanged(sender As Object, e As EventArgs) Handles I3.CheckedChanged
        Dim chk As CheckBox = CType(sender, CheckBox)
        Dim strSeatName As String = chk.Name
        UncheckEnabledCheckBoxesExept(strSeatName)
    End Sub

    Private Sub A4_CheckedChanged(sender As Object, e As EventArgs) Handles A4.CheckedChanged
        Dim chk As CheckBox = CType(sender, CheckBox)
        Dim strSeatName As String = chk.Name
        UncheckEnabledCheckBoxesExept(strSeatName)
    End Sub

    Private Sub B4_CheckedChanged(sender As Object, e As EventArgs) Handles B4.CheckedChanged
        Dim chk As CheckBox = CType(sender, CheckBox)
        Dim strSeatName As String = chk.Name
        UncheckEnabledCheckBoxesExept(strSeatName)
    End Sub

    Private Sub C4_CheckedChanged(sender As Object, e As EventArgs) Handles C4.CheckedChanged
        Dim chk As CheckBox = CType(sender, CheckBox)
        Dim strSeatName As String = chk.Name
        UncheckEnabledCheckBoxesExept(strSeatName)
    End Sub

    Private Sub D4_CheckedChanged(sender As Object, e As EventArgs) Handles D4.CheckedChanged
        Dim chk As CheckBox = CType(sender, CheckBox)
        Dim strSeatName As String = chk.Name
        UncheckEnabledCheckBoxesExept(strSeatName)
    End Sub

    Private Sub E4_CheckedChanged(sender As Object, e As EventArgs) Handles E4.CheckedChanged
        Dim chk As CheckBox = CType(sender, CheckBox)
        Dim strSeatName As String = chk.Name
        UncheckEnabledCheckBoxesExept(strSeatName)
    End Sub

    Private Sub F4_CheckedChanged(sender As Object, e As EventArgs) Handles F4.CheckedChanged
        Dim chk As CheckBox = CType(sender, CheckBox)
        Dim strSeatName As String = chk.Name
        UncheckEnabledCheckBoxesExept(strSeatName)
    End Sub

    Private Sub G4_CheckedChanged(sender As Object, e As EventArgs) Handles G4.CheckedChanged
        Dim chk As CheckBox = CType(sender, CheckBox)
        Dim strSeatName As String = chk.Name
        UncheckEnabledCheckBoxesExept(strSeatName)
    End Sub

    Private Sub H4_CheckedChanged(sender As Object, e As EventArgs) Handles H4.CheckedChanged
        Dim chk As CheckBox = CType(sender, CheckBox)
        Dim strSeatName As String = chk.Name
        UncheckEnabledCheckBoxesExept(strSeatName)
    End Sub

    Private Sub I4_CheckedChanged(sender As Object, e As EventArgs) Handles I4.CheckedChanged
        Dim chk As CheckBox = CType(sender, CheckBox)
        Dim strSeatName As String = chk.Name
        UncheckEnabledCheckBoxesExept(strSeatName)
    End Sub

    Private Sub A5_CheckedChanged(sender As Object, e As EventArgs) Handles A5.CheckedChanged
        Dim chk As CheckBox = CType(sender, CheckBox)
        Dim strSeatName As String = chk.Name
        UncheckEnabledCheckBoxesExept(strSeatName)
    End Sub

    Private Sub B5_CheckedChanged(sender As Object, e As EventArgs) Handles B5.CheckedChanged
        Dim chk As CheckBox = CType(sender, CheckBox)
        Dim strSeatName As String = chk.Name
        UncheckEnabledCheckBoxesExept(strSeatName)
    End Sub

    Private Sub C5_CheckedChanged(sender As Object, e As EventArgs) Handles C5.CheckedChanged
        Dim chk As CheckBox = CType(sender, CheckBox)
        Dim strSeatName As String = chk.Name
        UncheckEnabledCheckBoxesExept(strSeatName)
    End Sub

    Private Sub D5_CheckedChanged(sender As Object, e As EventArgs) Handles D5.CheckedChanged
        Dim chk As CheckBox = CType(sender, CheckBox)
        Dim strSeatName As String = chk.Name
        UncheckEnabledCheckBoxesExept(strSeatName)
    End Sub

    Private Sub E5_CheckedChanged(sender As Object, e As EventArgs) Handles E5.CheckedChanged
        Dim chk As CheckBox = CType(sender, CheckBox)
        Dim strSeatName As String = chk.Name
        UncheckEnabledCheckBoxesExept(strSeatName)
    End Sub

    Private Sub F5_CheckedChanged(sender As Object, e As EventArgs) Handles F5.CheckedChanged
        Dim chk As CheckBox = CType(sender, CheckBox)
        Dim strSeatName As String = chk.Name
        UncheckEnabledCheckBoxesExept(strSeatName)
    End Sub

    Private Sub G5_CheckedChanged(sender As Object, e As EventArgs) Handles G5.CheckedChanged
        Dim chk As CheckBox = CType(sender, CheckBox)
        Dim strSeatName As String = chk.Name
        UncheckEnabledCheckBoxesExept(strSeatName)
    End Sub

    Private Sub H5_CheckedChanged(sender As Object, e As EventArgs) Handles H5.CheckedChanged
        Dim chk As CheckBox = CType(sender, CheckBox)
        Dim strSeatName As String = chk.Name
        UncheckEnabledCheckBoxesExept(strSeatName)
    End Sub

    Private Sub I5_CheckedChanged(sender As Object, e As EventArgs) Handles I5.CheckedChanged
        Dim chk As CheckBox = CType(sender, CheckBox)
        Dim strSeatName As String = chk.Name
        UncheckEnabledCheckBoxesExept(strSeatName)
    End Sub

    Private Sub A6_CheckedChanged(sender As Object, e As EventArgs) Handles A6.CheckedChanged
        Dim chk As CheckBox = CType(sender, CheckBox)
        Dim strSeatName As String = chk.Name
        UncheckEnabledCheckBoxesExept(strSeatName)
    End Sub

    Private Sub B6_CheckedChanged(sender As Object, e As EventArgs) Handles B6.CheckedChanged
        Dim chk As CheckBox = CType(sender, CheckBox)
        Dim strSeatName As String = chk.Name
        UncheckEnabledCheckBoxesExept(strSeatName)
    End Sub

    Private Sub C6_CheckedChanged(sender As Object, e As EventArgs) Handles C6.CheckedChanged
        Dim chk As CheckBox = CType(sender, CheckBox)
        Dim strSeatName As String = chk.Name
        UncheckEnabledCheckBoxesExept(strSeatName)
    End Sub

    Private Sub D6_CheckedChanged(sender As Object, e As EventArgs) Handles D6.CheckedChanged
        Dim chk As CheckBox = CType(sender, CheckBox)
        Dim strSeatName As String = chk.Name
        UncheckEnabledCheckBoxesExept(strSeatName)
    End Sub

    Private Sub E6_CheckedChanged(sender As Object, e As EventArgs) Handles E6.CheckedChanged
        Dim chk As CheckBox = CType(sender, CheckBox)
        Dim strSeatName As String = chk.Name
        UncheckEnabledCheckBoxesExept(strSeatName)
    End Sub

    Private Sub F6_CheckedChanged(sender As Object, e As EventArgs) Handles F6.CheckedChanged
        Dim chk As CheckBox = CType(sender, CheckBox)
        Dim strSeatName As String = chk.Name
        UncheckEnabledCheckBoxesExept(strSeatName)
    End Sub

    Private Sub G6_CheckedChanged(sender As Object, e As EventArgs) Handles G6.CheckedChanged
        Dim chk As CheckBox = CType(sender, CheckBox)
        Dim strSeatName As String = chk.Name
        UncheckEnabledCheckBoxesExept(strSeatName)
    End Sub

    Private Sub H6_CheckedChanged(sender As Object, e As EventArgs) Handles H6.CheckedChanged
        Dim chk As CheckBox = CType(sender, CheckBox)
        Dim strSeatName As String = chk.Name
        UncheckEnabledCheckBoxesExept(strSeatName)
    End Sub

    Private Sub I6_CheckedChanged(sender As Object, e As EventArgs) Handles I6.CheckedChanged
        Dim chk As CheckBox = CType(sender, CheckBox)
        Dim strSeatName As String = chk.Name
        UncheckEnabledCheckBoxesExept(strSeatName)
    End Sub

    Private Sub A7_CheckedChanged(sender As Object, e As EventArgs) Handles A7.CheckedChanged
        Dim chk As CheckBox = CType(sender, CheckBox)
        Dim strSeatName As String = chk.Name
        UncheckEnabledCheckBoxesExept(strSeatName)
    End Sub

    Private Sub B7_CheckedChanged(sender As Object, e As EventArgs) Handles B7.CheckedChanged
        Dim chk As CheckBox = CType(sender, CheckBox)
        Dim strSeatName As String = chk.Name
        UncheckEnabledCheckBoxesExept(strSeatName)
    End Sub

    Private Sub C7_CheckedChanged(sender As Object, e As EventArgs) Handles C7.CheckedChanged
        Dim chk As CheckBox = CType(sender, CheckBox)
        Dim strSeatName As String = chk.Name
        UncheckEnabledCheckBoxesExept(strSeatName)
    End Sub

    Private Sub D7_CheckedChanged(sender As Object, e As EventArgs) Handles D7.CheckedChanged
        Dim chk As CheckBox = CType(sender, CheckBox)
        Dim strSeatName As String = chk.Name
        UncheckEnabledCheckBoxesExept(strSeatName)
    End Sub

    Private Sub E7_CheckedChanged(sender As Object, e As EventArgs) Handles E7.CheckedChanged
        Dim chk As CheckBox = CType(sender, CheckBox)
        Dim strSeatName As String = chk.Name
        UncheckEnabledCheckBoxesExept(strSeatName)
    End Sub

    Private Sub F7_CheckedChanged(sender As Object, e As EventArgs) Handles F7.CheckedChanged
        Dim chk As CheckBox = CType(sender, CheckBox)
        Dim strSeatName As String = chk.Name
        UncheckEnabledCheckBoxesExept(strSeatName)
    End Sub

    Private Sub G7_CheckedChanged(sender As Object, e As EventArgs) Handles G7.CheckedChanged
        Dim chk As CheckBox = CType(sender, CheckBox)
        Dim strSeatName As String = chk.Name
        UncheckEnabledCheckBoxesExept(strSeatName)
    End Sub

    Private Sub H7_CheckedChanged(sender As Object, e As EventArgs) Handles H7.CheckedChanged
        Dim chk As CheckBox = CType(sender, CheckBox)
        Dim strSeatName As String = chk.Name
        UncheckEnabledCheckBoxesExept(strSeatName)
    End Sub

    Private Sub I7_CheckedChanged(sender As Object, e As EventArgs) Handles I7.CheckedChanged
        Dim chk As CheckBox = CType(sender, CheckBox)
        Dim strSeatName As String = chk.Name
        UncheckEnabledCheckBoxesExept(strSeatName)
    End Sub

    Private Sub A8_CheckedChanged(sender As Object, e As EventArgs) Handles A8.CheckedChanged
        Dim chk As CheckBox = CType(sender, CheckBox)
        Dim strSeatName As String = chk.Name
        UncheckEnabledCheckBoxesExept(strSeatName)
    End Sub

    Private Sub B8_CheckedChanged(sender As Object, e As EventArgs) Handles B8.CheckedChanged
        Dim chk As CheckBox = CType(sender, CheckBox)
        Dim strSeatName As String = chk.Name
        UncheckEnabledCheckBoxesExept(strSeatName)
    End Sub

    Private Sub C8_CheckedChanged(sender As Object, e As EventArgs) Handles C8.CheckedChanged
        Dim chk As CheckBox = CType(sender, CheckBox)
        Dim strSeatName As String = chk.Name
        UncheckEnabledCheckBoxesExept(strSeatName)
    End Sub

    Private Sub D8_CheckedChanged(sender As Object, e As EventArgs) Handles D8.CheckedChanged
        Dim chk As CheckBox = CType(sender, CheckBox)
        Dim strSeatName As String = chk.Name
        UncheckEnabledCheckBoxesExept(strSeatName)
    End Sub

    Private Sub E8_CheckedChanged(sender As Object, e As EventArgs) Handles E8.CheckedChanged
        Dim chk As CheckBox = CType(sender, CheckBox)
        Dim strSeatName As String = chk.Name
        UncheckEnabledCheckBoxesExept(strSeatName)
    End Sub

    Private Sub F8_CheckedChanged(sender As Object, e As EventArgs) Handles F8.CheckedChanged
        Dim chk As CheckBox = CType(sender, CheckBox)
        Dim strSeatName As String = chk.Name
        UncheckEnabledCheckBoxesExept(strSeatName)
    End Sub

    Private Sub G8_CheckedChanged(sender As Object, e As EventArgs) Handles G8.CheckedChanged
        Dim chk As CheckBox = CType(sender, CheckBox)
        Dim strSeatName As String = chk.Name
        UncheckEnabledCheckBoxesExept(strSeatName)
    End Sub

    Private Sub H8_CheckedChanged(sender As Object, e As EventArgs) Handles H8.CheckedChanged
        Dim chk As CheckBox = CType(sender, CheckBox)
        Dim strSeatName As String = chk.Name
        UncheckEnabledCheckBoxesExept(strSeatName)
    End Sub

    Private Sub I8_CheckedChanged(sender As Object, e As EventArgs) Handles I8.CheckedChanged
        Dim chk As CheckBox = CType(sender, CheckBox)
        Dim strSeatName As String = chk.Name
        UncheckEnabledCheckBoxesExept(strSeatName)
    End Sub

    Private Sub A9_CheckedChanged(sender As Object, e As EventArgs) Handles A9.CheckedChanged
        Dim chk As CheckBox = CType(sender, CheckBox)
        Dim strSeatName As String = chk.Name
        UncheckEnabledCheckBoxesExept(strSeatName)
    End Sub

    Private Sub B9_CheckedChanged(sender As Object, e As EventArgs) Handles B9.CheckedChanged
        Dim chk As CheckBox = CType(sender, CheckBox)
        Dim strSeatName As String = chk.Name
        UncheckEnabledCheckBoxesExept(strSeatName)
    End Sub

    Private Sub C9_CheckedChanged(sender As Object, e As EventArgs) Handles C9.CheckedChanged
        Dim chk As CheckBox = CType(sender, CheckBox)
        Dim strSeatName As String = chk.Name
        UncheckEnabledCheckBoxesExept(strSeatName)
    End Sub

    Private Sub D9_CheckedChanged(sender As Object, e As EventArgs) Handles D9.CheckedChanged
        Dim chk As CheckBox = CType(sender, CheckBox)
        Dim strSeatName As String = chk.Name
        UncheckEnabledCheckBoxesExept(strSeatName)
    End Sub

    Private Sub E9_CheckedChanged(sender As Object, e As EventArgs) Handles E9.CheckedChanged
        Dim chk As CheckBox = CType(sender, CheckBox)
        Dim strSeatName As String = chk.Name
        UncheckEnabledCheckBoxesExept(strSeatName)
    End Sub

    Private Sub F9_CheckedChanged(sender As Object, e As EventArgs) Handles F9.CheckedChanged
        Dim chk As CheckBox = CType(sender, CheckBox)
        Dim strSeatName As String = chk.Name
        UncheckEnabledCheckBoxesExept(strSeatName)
    End Sub

    Private Sub G9_CheckedChanged(sender As Object, e As EventArgs) Handles G9.CheckedChanged
        Dim chk As CheckBox = CType(sender, CheckBox)
        Dim strSeatName As String = chk.Name
        UncheckEnabledCheckBoxesExept(strSeatName)
    End Sub

    Private Sub H9_CheckedChanged(sender As Object, e As EventArgs) Handles H9.CheckedChanged
        Dim chk As CheckBox = CType(sender, CheckBox)
        Dim strSeatName As String = chk.Name
        UncheckEnabledCheckBoxesExept(strSeatName)
    End Sub

    Private Sub I9_CheckedChanged(sender As Object, e As EventArgs) Handles I9.CheckedChanged
        Dim chk As CheckBox = CType(sender, CheckBox)
        Dim strSeatName As String = chk.Name
        UncheckEnabledCheckBoxesExept(strSeatName)
    End Sub

    Private Sub A10_CheckedChanged(sender As Object, e As EventArgs) Handles A10.CheckedChanged
        Dim chk As CheckBox = CType(sender, CheckBox)
        Dim strSeatName As String = chk.Name
        UncheckEnabledCheckBoxesExept(strSeatName)
    End Sub

    Private Sub B10_CheckedChanged(sender As Object, e As EventArgs) Handles B10.CheckedChanged
        Dim chk As CheckBox = CType(sender, CheckBox)
        Dim strSeatName As String = chk.Name
        UncheckEnabledCheckBoxesExept(strSeatName)
    End Sub

    Private Sub C10_CheckedChanged(sender As Object, e As EventArgs) Handles C10.CheckedChanged
        Dim chk As CheckBox = CType(sender, CheckBox)
        Dim strSeatName As String = chk.Name
        UncheckEnabledCheckBoxesExept(strSeatName)
    End Sub

    Private Sub D10_CheckedChanged(sender As Object, e As EventArgs) Handles D10.CheckedChanged
        Dim chk As CheckBox = CType(sender, CheckBox)
        Dim strSeatName As String = chk.Name
        UncheckEnabledCheckBoxesExept(strSeatName)
    End Sub

    Private Sub E10_CheckedChanged(sender As Object, e As EventArgs) Handles E10.CheckedChanged
        Dim chk As CheckBox = CType(sender, CheckBox)
        Dim strSeatName As String = chk.Name
        UncheckEnabledCheckBoxesExept(strSeatName)
    End Sub

    Private Sub F10_CheckedChanged(sender As Object, e As EventArgs) Handles F10.CheckedChanged
        Dim chk As CheckBox = CType(sender, CheckBox)
        Dim strSeatName As String = chk.Name
        UncheckEnabledCheckBoxesExept(strSeatName)
    End Sub

    Private Sub G10_CheckedChanged(sender As Object, e As EventArgs) Handles G10.CheckedChanged
        Dim chk As CheckBox = CType(sender, CheckBox)
        Dim strSeatName As String = chk.Name
        UncheckEnabledCheckBoxesExept(strSeatName)
    End Sub

    Private Sub H10_CheckedChanged(sender As Object, e As EventArgs) Handles H10.CheckedChanged
        Dim chk As CheckBox = CType(sender, CheckBox)
        Dim strSeatName As String = chk.Name
        UncheckEnabledCheckBoxesExept(strSeatName)
    End Sub

    Private Sub I10_CheckedChanged(sender As Object, e As EventArgs) Handles I10.CheckedChanged
        Dim chk As CheckBox = CType(sender, CheckBox)
        Dim strSeatName As String = chk.Name
        UncheckEnabledCheckBoxesExept(strSeatName)
    End Sub


#End Region
End Class