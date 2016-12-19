
Public NotInheritable Class FormatText

#Region " Constructors "

    Private Sub New()
    End Sub

#End Region

#Region " Methods "

    ''' <summary>
    ''' Corrects the text character casing and optionally format phone fields simliar to Microsoft Outlook.
    ''' </summary>
    ''' <param name="strIn">String to be case corrected and optionally formatted.</param>
    ''' <param name="enumCharacterCase">Character case and format.</param>
    ''' <returns>String case corrected and optionally formatted.</returns>
    Public Shared Function ApplyCharacterCasing(ByVal strIn As String, ByVal enumCharacterCase As CharacterCasing) As String

        If Application.DataBase Is Nothing Then
            Return strIn.Trim
            Exit Function
        End If

        strIn = strIn.Trim

        If strIn.Length = 0 Then
            Return strIn.Trim
            Exit Function
        End If

        Dim intX As Integer

        Select Case enumCharacterCase

            Case CharacterCasing.None
                Return strIn

            Case CharacterCasing.LowerCase
                Return strIn.ToLower

            Case CharacterCasing.UpperCase
                Return strIn.ToUpper

            Case CharacterCasing.OutlookPhoneNoProperName
                Return FormatOutLookPhone(strIn)

            Case CharacterCasing.OutlookPhoneUpper
                Return FormatOutLookPhone(strIn).ToUpper
        End Select

        strIn = strIn.ToLower

        Dim strPrevious As String = " "
        Dim strPreviousTwo As String = "  "
        Dim strPreviousThree As String = "   "
        Dim strChar As String

        For intX = 0 To strIn.Length - 1
            strChar = strIn.Substring(intX, 1)

            If Char.IsLetter(CType(strChar, Char)) AndAlso strChar <> strChar.ToUpper Then

                If strPrevious = " " OrElse strPrevious = "." OrElse strPrevious = "-" OrElse strPrevious = "/" OrElse strPreviousThree = " O'" OrElse strPreviousTwo = "Mc" Then
                    strIn = strIn.Remove(intX, 1)
                    strIn = strIn.Insert(intX, strChar.ToUpper)
                    strPrevious = strChar.ToUpper

                Else
                    strPrevious = strChar
                End If

            Else
                strPrevious = strChar
            End If

            strPreviousTwo = strPreviousTwo.Substring(1, 1) & strPrevious
            strPreviousThree = strPreviousThree.Substring(1, 1) & strPreviousThree.Substring(2, 1) & strPrevious
        Next

        intX = strIn.IndexOf("'")

        If intX = 1 Then

            Dim strInsert As String = strIn.Substring(2, 1).ToUpper
            strIn = strIn.Remove(2, 1)
            strIn = strIn.Insert(2, strInsert)
        End If

        Try
            intX = strIn.IndexOf("'", 3)

            If intX > 3 AndAlso strIn.Substring(intX - 2, 1) = " " Then

                Dim strInsert As String = strIn.Substring(intX + 1, 1).ToUpper
                strIn = strIn.Remove(intX + 1, 1)
                strIn = strIn.Insert(intX + 1, strInsert)
            End If

        Catch
        End Try

        'never remove this code
        strIn += " "

        For Each objCheck As CharacterCasingCheck In Application.DataBase.CharacterCasingChecks

            If strIn.Contains(objCheck.LookFor) Then

                Dim intPosition As Integer = strIn.IndexOf(objCheck.LookFor)

                If intPosition > -1 Then
                    strIn = strIn.Remove(intPosition, objCheck.LookFor.Length)
                    strIn = strIn.Insert(intPosition, objCheck.ReplaceWith)
                End If

            End If

        Next

        If enumCharacterCase = CharacterCasing.OutlookPhoneProperName Then
            strIn = FormatOutLookPhone(strIn)
        End If

        Return strIn.Trim
    End Function

    Private Shared Function FormatOutLookPhone(ByVal strIn As String) As String

        If strIn.Trim.Length = 0 Then
            Return strIn
        End If

        Dim strTempCasted As String = strIn & " "

        Try

            Dim strTemp As String = strTempCasted
            Dim intX As Integer = strTemp.IndexOf(" ", 8)

            If intX > 0 Then
                strTemp = strIn.Substring(0, intX)
                strTemp = strTemp.Replace("(", "")
                strTemp = strTemp.Replace(")", "")
                strTemp = strTemp.Replace(" ", "")
                strTemp = strTemp.Replace("-", "")

                Dim lngTemp As Long

                If Long.TryParse(strTemp, lngTemp) AndAlso strTemp.Length = 10 Then
                    strTempCasted = lngTemp.ToString("(###) ###-####") & "  " & strTempCasted.Substring(intX).Trim
                End If

            Else
            End If

        Catch
        End Try

        Return strTempCasted
    End Function

#End Region

End Class
