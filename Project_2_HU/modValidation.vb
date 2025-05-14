Module modValidation


    Public Function ValidateString(ByVal strInput As String, Optional ByVal strRequiredStr As String = "", Optional ByVal intMinLen As Integer = 1) As Boolean
        Dim bIsValid As Boolean = False

        If strInput.Length < intMinLen Or strInput.Contains(strRequiredStr) Then
            bIsValid = False
        Else
            bIsValid = True
        End If

        Return bIsValid
    End Function

    Public Function ValidateNumeric(ByVal strInput As String, Optional ByVal intMin As Integer = 0, Optional ByVal intMax As Integer = 1000) As Boolean
        Dim bIsValid As Boolean = False
        Dim intResult As Integer

        If Integer.TryParse(strInput, intResult) Then
            If intResult <= intMax AndAlso intResult >= intMin Then
                bIsValid = True
            End If
        End If
        Return bIsValid
    End Function

    Public Function GetAndValidateIntInputFromTextControl(ByRef txtControl As TextBox, ByRef intOutput As Integer, Optional ByVal intMin As Integer = 0, Optional ByVal intMax As Integer = 1000) As Boolean
        Dim strTextFromControl As String = txtControl.Text
        Dim bIsValid As Boolean = False
        Dim intResult As Integer

        If Integer.TryParse(strTextFromControl, intResult) Then
            If intResult <= intMax AndAlso intResult >= intMin Then
                intOutput = intResult
                bIsValid = True
            Else
                MessageBox.Show("Input value should be in a ragne ( " & intMin.ToString() & " - " & intMax.ToString() & " )")
                txtControl.Clear()
                txtControl.Focus()
            End If
        Else
            MessageBox.Show("Input should be integer")
            txtControl.Clear()
            txtControl.Focus()
        End If
        Return bIsValid


    End Function

End Module
