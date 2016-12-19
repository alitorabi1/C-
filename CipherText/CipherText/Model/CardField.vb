Imports System.ComponentModel
Imports CipherText.ValidationHelper
Imports System.Text
'
<Serializable()> Public Class CardField
    Inherits CardBase
    Implements IDataErrorInfo
    Implements IComparable(Of CardField)

#Region " Declarations "

    Private _bolIsMarkedForDelete As Boolean = False
    Private _bolIsRequired As Boolean = False
    Private _enumFieldCase As FieldCase = FieldCase.None
    Private _enumFieldType As FieldType = CipherText.FieldType.Plain
    Private _intFieldSortOrder As Integer
    Private _intMaximumLength As Integer = 50
    Private _strFieldData As String = String.Empty
    Private _strFieldTag As String = String.Empty

#End Region

#Region " Properties "

    Public ReadOnly Property [Error]() As String Implements System.ComponentModel.IDataErrorInfo.Error
        Get
            Return CheckRules()
        End Get
    End Property

    Public Property FieldCase() As FieldCase
        Get
            Return _enumFieldCase
        End Get
        Set(ByVal Value As FieldCase)
            _enumFieldCase = Value
            OnPropertyChanged("FieldCase")
        End Set
    End Property

    Public Property FieldData() As String
        Get
            Return _strFieldData
        End Get
        Set(ByVal Value As String)

            If Value Is Nothing Then
                _strFieldData = String.Empty

            Else

                Select Case Me.FieldCase

                    Case FieldCase.Lower
                        _strFieldData = Value.ToLower

                    Case FieldCase.None
                        _strFieldData = Value

                    Case FieldCase.OutlookPhoneProper
                        _strFieldData = FormatText.ApplyCharacterCasing(Value, CharacterCasing.OutlookPhoneProperName)

                    Case FieldCase.Proper
                        _strFieldData = FormatText.ApplyCharacterCasing(Value, CharacterCasing.ProperName)

                    Case FieldCase.Upper
                        _strFieldData = Value.ToUpper
                End Select

            End If

            OnPropertyChanged("FieldData")
        End Set
    End Property

    Public Property FieldSortOrder() As Integer
        Get
            Return _intFieldSortOrder
        End Get
        Set(ByVal Value As Integer)
            _intFieldSortOrder = Value
            OnPropertyChanged("FieldSortOrder")
        End Set
    End Property

    Public Property FieldTag() As String
        Get
            Return _strFieldTag
        End Get
        Set(ByVal Value As String)
            _strFieldTag = FormatText.ApplyCharacterCasing(Value, CharacterCasing.ProperName)
            OnPropertyChanged("FieldTag")
        End Set
    End Property

    Public Property FieldType() As FieldType
        Get
            Return _enumFieldType
        End Get
        Set(ByVal Value As FieldType)
            _enumFieldType = Value
            OnPropertyChanged("FieldType")
        End Set
    End Property

    Public Property IsMarkedForDelete() As Boolean
        Get
            Return _bolIsMarkedForDelete
        End Get
        Set(ByVal Value As Boolean)
            _bolIsMarkedForDelete = Value
        End Set
    End Property

    Public Property IsRequired() As Boolean
        Get
            Return _bolIsRequired
        End Get
        Set(ByVal Value As Boolean)
            _bolIsRequired = Value
            OnPropertyChanged("IsRequired")
        End Set
    End Property

    Default Public ReadOnly Property Item(ByVal columnName As String) As String Implements System.ComponentModel.IDataErrorInfo.Item
        Get
            Return CheckRule(columnName)
        End Get
    End Property

    Public Property MaximumLength() As Integer
        Get
            Return _intMaximumLength
        End Get
        Set(ByVal Value As Integer)
            _intMaximumLength = Value
            OnPropertyChanged("MaximumLength")
        End Set
    End Property

#End Region

#Region " Constructors "

    Public Sub New()
        _intFieldSortOrder = 999
    End Sub

#End Region

#Region " Methods "

    Private Function CheckFieldData() As String

        If _bolIsRequired AndAlso String.IsNullOrEmpty(_strFieldData.Trim) Then
            Return String.Format("{0} is a required field.", _strFieldTag)
        End If

        If _strFieldData.Length > _intMaximumLength Then
            Return String.Format("{0} length is too long.  Please reedit this field.", _strFieldTag)
        End If

        Select Case _enumFieldType

            Case CipherText.FieldType.Plain, CipherText.FieldType.PasswordPrimary, CipherText.FieldType.PasswordSecondary, CipherText.FieldType.UserNamePrimary, CipherText.FieldType.UserNameSecondary

                '
            Case CipherText.FieldType.CreditCardNumber

                If Not IsCreditCardNumberValid(_strFieldData) Then
                    Return String.Format("{0} is not valid.  Please reedit this field.", _strFieldTag)
                End If

            Case CipherText.FieldType.Email

                If Not IsInputValid(_strFieldData, RegularExpressionPatternType.Email) Then
                    Return String.Format("{0} is not valid.  Please reedit this field.", _strFieldTag)
                End If

            Case CipherText.FieldType.IP

                If Not IsInputValid(_strFieldData, RegularExpressionPatternType.IPAddress) Then
                    Return String.Format("{0} is not valid.  Please reedit this field.", _strFieldTag)
                End If

            Case CipherText.FieldType.RoutingNumber

                If Not IsBankRoutingNumberValid(_strFieldData) Then
                    Return String.Format("{0} is not valid.  Please reedit this field.", _strFieldTag)
                End If

            Case CipherText.FieldType.URLPrimary, CipherText.FieldType.URLSecondary

                If Not IsInputValid(_strFieldData, RegularExpressionPatternType.URL) Then
                    Return String.Format("{0} is not valid.  Please reedit this field.", _strFieldTag)
                End If

            Case Else
                Throw New ArgumentOutOfRangeException("FieldType", Me.FieldType, "Programmer did not program this value.")
        End Select

        Return String.Empty
    End Function

    Private Function CheckFieldTag() As String

        If String.IsNullOrEmpty(_strFieldTag) Then
            Return "Field tag is a required field"

        Else
            Return String.Empty
        End If

    End Function

    Private Function CheckMaximumLength() As String

        If _intMaximumLength < 0 Then
            Return String.Format("{0} maximum length must be greater than zero.", _strFieldTag)

        Else
            Return String.Empty
        End If

    End Function

    Private Function CheckRule(ByVal strPropertyName As String) As String

        If strPropertyName = "FieldData" Then
            Return CheckFieldData()
        End If

        If strPropertyName = "FieldTag" Then
            Return CheckFieldTag()
        End If

        If strPropertyName = "MaximumLength" Then
            CheckMaximumLength()
        End If

        Return String.Empty
    End Function

    Private Function CheckRules() As String

        Dim sb As New StringBuilder(1024)
        Dim strTest As String = Nothing
        strTest = CheckFieldData()

        If Not String.IsNullOrEmpty(strTest) Then
            sb.AppendLine(strTest)
        End If

        strTest = CheckFieldTag()

        If Not String.IsNullOrEmpty(strTest) Then
            sb.AppendLine(strTest)
        End If

        strTest = CheckMaximumLength()

        If Not String.IsNullOrEmpty(strTest) Then
            sb.AppendLine(strTest)
        End If

        Return sb.ToString
    End Function

    Public Function CompareTo(ByVal other As CardField) As Integer Implements System.IComparable(Of CardField).CompareTo
        Return _intFieldSortOrder.CompareTo(other.FieldSortOrder)
    End Function

#End Region

End Class
