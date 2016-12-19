Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.ComponentModel
'
<Serializable()> Public Class Card
    Inherits CardBase
    Implements IDataErrorInfo
    Implements IComparable(Of Card)

#Region " Declarations "

    Private _objCardFields As New CardFields
    Private _strCardTypeName As String = String.Empty
    Private _strDateCreated As String = String.Empty
    Private _strDateModified As String = String.Empty
    Private _strNotes As String = String.Empty
    Private _strTitle As String = String.Empty

#End Region

#Region " Properties "

    Public Property CardFields() As CardFields
        Get
            Return _objCardFields
        End Get
        Set(ByVal Value As CardFields)
            _objCardFields = Value
            OnPropertyChanged("CardFields")
        End Set
    End Property

    Public Property CardTypeName() As String
        Get
            Return _strCardTypeName
        End Get
        Set(ByVal Value As String)
            _strCardTypeName = FormatText.ApplyCharacterCasing(Value, CharacterCasing.ProperName)
            OnPropertyChanged("CardTypeName")
        End Set
    End Property

    Public Property DateCreated() As String
        Get
            Return _strDateCreated
        End Get
        Set(ByVal Value As String)
            _strDateCreated = Value
            OnPropertyChanged("DateCreated")
        End Set
    End Property

    Public Property DateModified() As String
        Get
            Return _strDateModified
        End Get
        Set(ByVal Value As String)
            _strDateModified = Value
            OnPropertyChanged("DateModified")
        End Set
    End Property

    Public ReadOnly Property [Error]() As String Implements System.ComponentModel.IDataErrorInfo.Error
        Get

            If String.IsNullOrEmpty(Me.Title) Then
                Return "Title is a required field"

            Else
                Return String.Empty
            End If

        End Get
    End Property

    Default Public ReadOnly Property Item(ByVal columnName As String) As String Implements System.ComponentModel.IDataErrorInfo.Item
        Get

            If columnName = "Title" AndAlso String.IsNullOrEmpty(Me.Title) Then
                Return "Title is a required field"

            Else
                Return String.Empty
            End If

        End Get
    End Property

    Public Property Notes() As String
        Get
            Return _strNotes
        End Get
        Set(ByVal Value As String)
            _strNotes = Value
            OnPropertyChanged("Notes")
        End Set
    End Property

    Public Property Title() As String
        Get
            Return _strTitle
        End Get
        Set(ByVal Value As String)
            _strTitle = FormatText.ApplyCharacterCasing(Value, CharacterCasing.ProperName)
            OnPropertyChanged("Title")
        End Set
    End Property

#End Region

#Region " Constructors "

    Public Sub New()
    End Sub

#End Region

#Region " Methods "

    Public Function Clone() As Card
        Return DeepCopy.Make(Of Card)(Me)
    End Function

    Public Function CompareTo(ByVal other As Card) As Integer Implements System.IComparable(Of Card).CompareTo
        Return _strTitle.CompareTo(other.Title)
    End Function

    Public Function Filter(ByVal strCardTypeFilter As String, ByVal strFilterText As String) As Boolean

        If Not String.IsNullOrEmpty(strCardTypeFilter) AndAlso strCardTypeFilter <> Application.STR_ALLRECORDS AndAlso _strCardTypeName <> strCardTypeFilter Then
            Return False
        End If

        If strFilterText.Length = 0 Then
            Return True
        End If

        If _strTitle.IndexOf(strFilterText, StringComparison.OrdinalIgnoreCase) > -1 Then
            Return True
        End If

        For Each objField As CardField In _objCardFields

            If objField.FieldData.IndexOf(strFilterText, StringComparison.OrdinalIgnoreCase) > -1 Then
                Return True
            End If

        Next

        Return False
    End Function

    Public Function IsValid() As Boolean

        If Not String.IsNullOrEmpty(Me.Error) Then
            Return False
        End If

        Return Me.CardFields.AreCardFieldsValid
    End Function

#End Region

End Class
