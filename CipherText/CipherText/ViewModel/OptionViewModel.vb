Imports System.ComponentModel

Public Class OptionViewModel(Of TValue)
    Implements INotifyPropertyChanged
    Implements IComparable(Of OptionViewModel(Of TValue))

#Region " Declarations "

    Private Const UNSET_SORT_VALUE As Integer = Integer.MinValue
    Private _bolIsSelected As Boolean = False
    Private _intSortValue As Integer = Integer.MinValue
    Private _objValue As TValue
    Private _strDisplayName As String = String.Empty

#End Region

#Region " Properties "

    Public ReadOnly Property DisplayName() As String
        Get
            Return _strDisplayName
        End Get
    End Property

    Public Property IsSelected() As Boolean
        Get
            Return _bolIsSelected
        End Get
        Set(ByVal Value As Boolean)
            _bolIsSelected = Value
            OnPropertyChanged("IsSelected")
        End Set
    End Property

    Public ReadOnly Property SortValue() As Integer
        Get
            Return _intSortValue
        End Get
    End Property

    Public ReadOnly Property Value() As TValue
        Get
            Return _objValue
        End Get
    End Property

#End Region

#Region " Constructors "

    Public Sub New(ByVal strDisplayName As String, ByVal objValue As TValue)
        _strDisplayName = strDisplayName
        _objValue = objValue
    End Sub

    Public Sub New(ByVal strDisplayName As String, ByVal objValue As TValue, ByVal intSortValue As Integer)
        _strDisplayName = strDisplayName
        _objValue = objValue
        _intSortValue = intSortValue
    End Sub

#End Region

#Region " Events "

    Public Event PropertyChanged As PropertyChangedEventHandler Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged

#End Region

#Region " Methods "

    Public Function CompareTo(ByVal other As OptionViewModel(Of TValue)) As Integer Implements System.IComparable(Of OptionViewModel(Of TValue)).CompareTo

        If other Is Nothing Then
            Return -1

        ElseIf _intSortValue = UNSET_SORT_VALUE AndAlso other.SortValue = UNSET_SORT_VALUE Then
            Return _strDisplayName.CompareTo(other.DisplayName)

        ElseIf _intSortValue <> UNSET_SORT_VALUE AndAlso other.SortValue <> UNSET_SORT_VALUE Then
            Return _intSortValue.CompareTo(other.SortValue)

        ElseIf _intSortValue <> UNSET_SORT_VALUE AndAlso other.SortValue = UNSET_SORT_VALUE Then
            Return -1

        Else
            Return +1
        End If

    End Function

    Public Function GetValue() As TValue
        Return _objValue
    End Function

    Protected Sub OnPropertyChanged(ByVal strPropertyName As String)

        Dim handler As PropertyChangedEventHandler = Me.PropertyChangedEvent

        If handler IsNot Nothing Then
            handler.Invoke(Me, New PropertyChangedEventArgs(strPropertyName))
        End If

    End Sub

#End Region

End Class
