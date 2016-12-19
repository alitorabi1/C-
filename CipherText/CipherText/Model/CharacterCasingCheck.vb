Imports System.ComponentModel
'
''' <summary>
''' Provides a container for a single character casing check.
''' </summary>
<Serializable()> Public Class CharacterCasingCheck
    Inherits CardBase
    Implements IDataErrorInfo
    Implements IComparable(Of CharacterCasingCheck)

#Region " Declarations "

    Private _strLookFor As String = String.Empty
    Private _strReplaceWith As String = String.Empty

#End Region

#Region " Properties "

    Public ReadOnly Property [Error]() As String Implements System.ComponentModel.IDataErrorInfo.Error
        Get

            Dim strError As String = Nothing

            If String.IsNullOrEmpty(_strLookFor) Then
                strError = "Look For is a required field."
            End If

            If String.IsNullOrEmpty(_strLookFor) Then

                If strError IsNot Nothing Then
                    strError += vbCrLf
                End If

                strError += "Replace With is a required field."
            End If

            If _strLookFor.Length <> _strReplaceWith.Length Then

                If strError IsNot Nothing Then
                    strError += vbCrLf
                End If

                strError += "Look For and Replace With must be the same length."
            End If

            If strError Is Nothing Then
                Return String.Empty

            Else
                Return strError
            End If

        End Get
    End Property

    Default Public ReadOnly Property Item(ByVal columnName As String) As String Implements System.ComponentModel.IDataErrorInfo.Item
        Get

            If columnName = "LookFor" AndAlso String.IsNullOrEmpty(_strLookFor) Then
                Return "Look For is a required field."

            ElseIf columnName = "ReplaceWith" AndAlso String.IsNullOrEmpty(_strLookFor) Then
                Return "Replace With is a required field."
            End If

            If _strLookFor.Length <> _strReplaceWith.Length Then
                Return "Look For and Replace With must be the same length."
            End If

            Return String.Empty
        End Get
    End Property

    ''' <summary>
    ''' Gets the string value to look for when the character casing check is being performed.
    ''' </summary>
    Public Property LookFor() As String
        Get
            Return _strLookFor
        End Get
        Set(ByVal Value As String)
            _strLookFor = Value
            '
            'this cool trick forces both fields to be validated when user is making changes
            '
            OnPropertyChanged("LookFor")
            OnPropertyChanged("ReplaceWith")
        End Set
    End Property

    ''' <summary>
    ''' Gets the string value that will replace the LookFor value when the character casing check is being performed.
    ''' </summary>
    Public Property ReplaceWith() As String
        Get
            Return _strReplaceWith
        End Get
        Set(ByVal Value As String)
            _strReplaceWith = Value
            '
            'this cool trick forces both fields to be validated when user is making changes
            '
            OnPropertyChanged("ReplaceWith")
            OnPropertyChanged("LookFor")
        End Set
    End Property

#End Region

#Region " Constructors "

    Public Sub New()
    End Sub

    ''' <summary>
    ''' Provides a container for a custom character casing correction.  The LookFor and ReplaceWith strings must be the same length.
    ''' </summary>
    ''' <param name="strLookFor">String value to replace.</param>
    ''' <param name="strReplaceWith">String value that will replace the LookFor value.</param>
    Public Sub New(ByVal strLookFor As String, ByVal strReplaceWith As String)

        If strLookFor.Length <> strReplaceWith.Length Then
            Throw New ArgumentException("The LookFor and ReplaceWith strings must be the same length.")
        End If

        _strLookFor = strLookFor
        _strReplaceWith = strReplaceWith
    End Sub

#End Region

#Region " Methods "

    Public Function CompareTo(ByVal other As CharacterCasingCheck) As Integer Implements System.IComparable(Of CharacterCasingCheck).CompareTo
        Return _strLookFor.CompareTo(other.LookFor)
    End Function

#End Region

End Class
