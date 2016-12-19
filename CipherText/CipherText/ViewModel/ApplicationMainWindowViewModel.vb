Imports System.Collections.ObjectModel

Public Class ApplicationMainWindowViewModel
    Inherits ViewModelBase

#Region " Declarations "

    Private _bolEditingRecord As Boolean = False
    Private _objCardTypeCommands As ReadOnlyCollection(Of CardTypeCommandViewModel)
    Private WithEvents _objDataBaseViewModel As DataBaseViewModel
    Private _objDataEditorViewModel As DataEditorViewModel

#End Region

#Region " Properties "

    Public ReadOnly Property CardTypeCommands() As ReadOnlyCollection(Of CardTypeCommandViewModel)
        Get

            If _objCardTypeCommands Is Nothing Then
                _objCardTypeCommands = LoadCardTypeCommands()
            End If

            Return _objCardTypeCommands
        End Get
    End Property

    Public ReadOnly Property DataBaseViewModel() As DataBaseViewModel
        Get
            Return _objDataBaseViewModel
        End Get
    End Property

    Public Property DataEditorViewModel() As DataEditorViewModel
        Get
            Return _objDataEditorViewModel
        End Get

        Private Set(ByVal Value As DataEditorViewModel)
            _objDataEditorViewModel = Value
            OnPropertyChanged("DataEditorViewModel")
        End Set
    End Property

    Public Property EditingRecord() As Boolean
        Get
            Return _bolEditingRecord
        End Get

        Private Set(ByVal Value As Boolean)
            _bolEditingRecord = Value
            OnPropertyChanged("EditingRecord")
        End Set
    End Property

#End Region

#Region " Constructors "

    Public Sub New()
        _objDataBaseViewModel = New DataBaseViewModel(New RelayCommand(Of Card)(AddressOf EditCardExecute))
    End Sub

#End Region

#Region " Command Methods "

    Private Sub EditCardExecute(ByVal param As Card)
        Me.EditingRecord = True
        Me.DataEditorViewModel = New DataEditorViewModel(param)
        AddHandler DataEditorViewModel.RequestClose, AddressOf RequestCloseEventHandler
    End Sub

    Private Sub FilterExecute(ByVal objCardType As CardType)
        Me.DataBaseViewModel.SetCardTypeFilter(objCardType.CardTypeName)
    End Sub

    Private Sub NewExecute(ByVal objCardType As CardType)
        Me.EditingRecord = True
        Me.DataEditorViewModel = New DataEditorViewModel(objCardType)
        AddHandler DataEditorViewModel.RequestClose, AddressOf RequestCloseEventHandler
    End Sub

#End Region

#Region " Methods "

    Private Function LoadCardTypeCommands() As ReadOnlyCollection(Of CardTypeCommandViewModel)

        Dim obj As New List(Of CardTypeCommandViewModel)

        For Each objCardType As CardType In Application.DataBase.CardTypes
            obj.Add(New CardTypeCommandViewModel(New RelayCommand(Of CardType)(AddressOf NewExecute), New RelayCommand(Of CardType)(AddressOf FilterExecute), objCardType))
        Next

        Dim objAllRecordsViewModel As CardTypeCommandViewModel = (From c In obj Where c.CardType.CardTypeName = Application.STR_ALLRECORDS).FirstOrDefault

        If objAllRecordsViewModel IsNot Nothing Then
            objAllRecordsViewModel.IsSelected = True
        End If

        Return New ReadOnlyCollection(Of CardTypeCommandViewModel)(obj)
    End Function

    Private Sub RequestCloseEventHandler(ByVal sender As Object, ByVal e As EventArgs)
        Me.EditingRecord = False
        RemoveHandler DataEditorViewModel.RequestClose, AddressOf RequestCloseEventHandler
        Me.DataEditorViewModel = Nothing
    End Sub

#End Region

End Class
