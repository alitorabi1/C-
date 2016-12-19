Imports System.Text.RegularExpressions

Public Class ValidationHelper

#Region " Methods "

    Public Shared Function IsBankRoutingNumberValid(ByVal strBankRoutingNumber As String) As Boolean

        If String.IsNullOrEmpty(strBankRoutingNumber) Then
            Return True
        End If

        Dim strErrorMessage As String = Nothing
        Dim intLengthBankRoutingNumber As Integer = Len(strBankRoutingNumber)
        Dim intValue As Integer

        If intLengthBankRoutingNumber <> 9 Then
            strErrorMessage = String.Format("The entered value {0} is not a valid bank routing number.  All bank routing numbers are 9 digits in length.", strBankRoutingNumber)
            Return False
        End If

        If Integer.Parse(strBankRoutingNumber.Substring(0, 1)) > 1 Then
            strErrorMessage = String.Format("The entered value {0} is not a valid bank routing number.  The first digit must be a 0 or a 1.", strBankRoutingNumber)
            Return False
        End If

        For Each c As Char In strBankRoutingNumber

            If Not Char.IsDigit(c) Then
                strErrorMessage = String.Format("The entered value {0} is not a valid bank routing number.  Only numeric input is allowed.", strBankRoutingNumber)
                Return False
            End If

        Next

        For intX As Integer = 0 To 8 Step 3
            intValue += Integer.Parse(strBankRoutingNumber.Substring(intX, 1)) * 3
            intValue += Integer.Parse(strBankRoutingNumber.Substring(intX + 1, 1)) * 7
            intValue += Integer.Parse(strBankRoutingNumber.Substring(intX + 2, 1))
        Next

        If intValue Mod 10 <> 0 Then
            strErrorMessage = String.Format("The entered value {0} is not a valid bank routing number.", strBankRoutingNumber)
            Return False

        Else
            Return True
        End If

    End Function

    Public Shared Function IsCreditCardNumberValid(ByVal strCardNumber As String) As Boolean

        If String.IsNullOrEmpty(strCardNumber) Then
            Return True
        End If

        Dim strErrorMessage As String = Nothing
        Dim intLengthCreditCardNumber As Integer = Len(strCardNumber)
        Dim intArr(intLengthCreditCardNumber) As Integer
        Dim intArrValue As Integer
        Dim intStart As Integer
        Dim intValue As Integer

        For Each c As Char In strCardNumber

            If Not Char.IsDigit(c) Then
                strErrorMessage = String.Format("The entered value {0} is not a valid credit card number.  Only numeric input is allowed.", strCardNumber)
                Return False
            End If

        Next

        For intCount = intLengthCreditCardNumber - 1 To 1 Step -2
            intValue = CType(Mid(strCardNumber, intCount, 1), Integer) * 2
            intArr(intCount) = intValue
        Next intCount

        intValue = 0

        If intLengthCreditCardNumber Mod 2 = 0 Then
            intStart = 2

        Else
            intStart = 1
        End If

        For intCount = intStart To intLengthCreditCardNumber Step 2
            intValue = intValue + CType(Mid(strCardNumber, intCount, 1), Integer)
            intArrValue = intArr(intCount - 1)

            If intArrValue < 10 Then
                intValue = intValue + intArrValue

            Else
                intValue = intValue + CType(Left(CType(intArrValue, String), 1), Integer) + CType(Right(CType(intArrValue, String), 1), Integer)
            End If

        Next intCount

        If intValue Mod 10 <> 0 Then
            strErrorMessage = String.Format("The entered value {0} is not a valid credit card number.", strCardNumber)
            Return False

        Else
            Return True
        End If

    End Function

    Public Shared Function IsInputValid(ByVal strTestMe As String, ByVal enumRegularExpressionPatternType As RegularExpressionPatternType) As Boolean

        If String.IsNullOrEmpty(strTestMe) Then
            Return True
        End If

        Dim strErrorMessage As String = Nothing
        Dim strPattern As String = String.Empty
        Dim strBrokenRuleDescription As String = String.Empty

        Select Case enumRegularExpressionPatternType

            Case RegularExpressionPatternType.Email
                strPattern = "^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$"
                strErrorMessage = "Field did not match the required email pattern."

            Case RegularExpressionPatternType.IPAddress
                strPattern = "^((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\.){3}(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])$"
                strErrorMessage = "Field did not match the required IP Address pattern."

            Case RegularExpressionPatternType.SSN
                strPattern = "^\d{3}-\d{2}-\d{4}$"
                strErrorMessage = "Field did not match the required SSN pattern."

            Case RegularExpressionPatternType.URL
                strPattern = "(?#WebOrIP)((?#protocol)((news|nntp|telnet|http|ftp|https|ftps|sftp):\/\/)?(?#subDomain)(([a-zA-Z0-9]+\.*(?#domain)[a-zA-Z0-9\-]+(?#TLD)(\.[a-zA-Z]+){1,2})|(?#IPAddress)((25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9])\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[0-9])))+(?#Port)(:[1-9][0-9]*)?)+(?#Path)((\/((?#dirOrFileName)[a-zA-Z0-9_\-\%\~\+]+)?)*)?(?#extension)(\.([a-zA-Z0-9_]+))?(?#parameters)(\?([a-zA-Z0-9_\-]+\=[a-z-A-Z0-9_\-\%\~\+]+)?(?#additionalParameters)(\&([a-zA-Z0-9_\-]+\=[a-z-A-Z0-9_\-\%\~\+]+)?)*)?"
                strErrorMessage = "Field did not match the required URL pattern."

            Case RegularExpressionPatternType.ZipCode
                strPattern = "^\d{5}(-\d{4})?$"
                strErrorMessage = "Field did not match the required Zip Code pattern."

            Case Else
                Throw New ArgumentOutOfRangeException("RegularExpressionPatternType", "Programmer did not program this pattern type")
        End Select

        If Regex.IsMatch(strTestMe, strPattern, RegexOptions.IgnoreCase) Then
            Return True

        Else
            Return False
        End If

    End Function

#End Region

End Class
