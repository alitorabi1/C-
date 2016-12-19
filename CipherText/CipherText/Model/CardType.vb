Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.ComponentModel
'
<Serializable()> Public Class CardType
    Implements IDataErrorInfo

#Region " Declarations "

    Private _objCardFields As New CardFields
    Private _strCardTypeName As String = String.Empty
    Private _strIcon As String = String.Empty

#End Region

#Region " Properties "

    Public ReadOnly Property CardFields() As CardFields
        Get
            Return _objCardFields
        End Get
    End Property

    Public Property CardTypeName() As String
        Get
            Return _strCardTypeName
        End Get
        Set(ByVal Value As String)
            _strCardTypeName = Value
        End Set
    End Property

    Public ReadOnly Property [Error]() As String Implements System.ComponentModel.IDataErrorInfo.Error
        Get

            If String.IsNullOrEmpty(_strCardTypeName) Then
                Return "Card Type is a required field"

            Else
                Return String.Empty
            End If

        End Get
    End Property

    Public Property Icon() As String
        Get
            Return _strIcon
        End Get
        Set(ByVal Value As String)
            _strIcon = Value
        End Set
    End Property

    Default Public ReadOnly Property Item(ByVal columnName As String) As String Implements System.ComponentModel.IDataErrorInfo.Item
        Get

            If columnName = "CardTypeName" AndAlso String.IsNullOrEmpty(_strCardTypeName) Then
                Return "Card Type Name is a required field"

            Else
                Return String.Empty
            End If

        End Get
    End Property

#End Region

#Region " Constructors "

    Public Sub New()
    End Sub

    Public Sub New(ByVal strCardTypeName As String, ByVal strIcon As String)
        _strCardTypeName = strCardTypeName
        _strIcon = strIcon
    End Sub

#End Region

#Region " Methods "

    Public Function CloneCardFields() As CardFields
        Return DeepCopy.Make(Of CardFields)(_objCardFields)
    End Function

#End Region

End Class
