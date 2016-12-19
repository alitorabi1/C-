Imports System.Threading
Imports System.ComponentModel
Imports System.Collections.ObjectModel

Public Class DataBaseViewModel
    Inherits ViewModelBase

#Region " Declarations "

    Private _cmdEditCardCommand As ICommand
    Private _cmdResetFilterTextCommand As ICommand
    Private _enumFilterButtonVisibility As Visibility = Visibility.Collapsed
    Private _objCardViewModels As New ObservableCollection(Of CardViewModel)
    Private _objCardViewModelSearchResults As ListCollectionView
    Private _strCardTypeFilter As String = Application.STR_ALLRECORDS
    Private _strFilterText As String = String.Empty
    Private _strViewingMessage As String = String.Empty
    Private Delegate Sub FilterDelegate()

#End Region

#Region " Events "

    'Public Event EditCard As EditCardEventHandler
#End Region

#Region " Properties "

    Public Property CardViewModelSearchResults() As ListCollectionView
        Get
            Return _objCardViewModelSearchResults
        End Get

        Private Set(ByVal Value As ListCollectionView)
            _objCardViewModelSearchResults = Value
            OnPropertyChanged("CardViewModelSearchResults")
        End Set
    End Property

    Public ReadOnly Property CipherText() As String
        Get
            Return Application.CipherText
        End Get
    End Property

    Public Property FilterButtonVisibility() As Visibility
        Get
            Return _enumFilterButtonVisibility
        End Get
        Set(ByVal Value As Visibility)
            _enumFilterButtonVisibility = Value
            OnPropertyChanged("FilterButtonVisibility")
        End Set
    End Property

    Public Property FilterText() As String
        Get
            Return _strFilterText
        End Get
        Set(ByVal Value As String)
            _strFilterText = Value
            OnPropertyChanged("FilterText")
            Search()
        End Set
    End Property

    Public Property ViewingMessage() As String
        Get
            Return _strViewingMessage
        End Get

        Private Set(ByVal Value As String)
            _strViewingMessage = Value
            OnPropertyChanged("ViewingMessage")
        End Set
    End Property

#End Region

#Region " Command Properties "

    Public ReadOnly Property EditCardCommand() As ICommand
        Get
            Return _cmdEditCardCommand
        End Get
    End Property

    Public ReadOnly Property ResetFilterTextCommand() As ICommand
        Get

            If _cmdResetFilterTextCommand Is Nothing Then
                _cmdResetFilterTextCommand = New RelayCommand(AddressOf ResetFilterTextExecute)
            End If

            Return _cmdResetFilterTextCommand
        End Get
    End Property

#End Region

#Region " Constructors "

    Public Sub New(ByVal cmdEditCardCommand As ICommand)
        _cmdEditCardCommand = cmdEditCardCommand
        AddHandler Application.DataBase.Cards.CollectionChanged, AddressOf CardsCollectionChanged_Handler

        For Each obj As Card In Application.DataBase.Cards
            _objCardViewModels.Add(New CardViewModel(obj))
        Next

        _objCardViewModelSearchResults = New ListCollectionView(_objCardViewModels)
        _objCardViewModelSearchResults.SortDescriptions.Add(New SortDescription("Card.Title", ListSortDirection.Ascending))
        SetViewingMessage()
    End Sub

#End Region

#Region " Command Methods "

    Private Sub CardsCollectionChanged_Handler(ByVal sender As Object, ByVal e As System.Collections.Specialized.NotifyCollectionChangedEventArgs)

        If e.Action = Specialized.NotifyCollectionChangedAction.Remove Then

            For Each obj As Card In e.OldItems

                Dim objRemoveCard As Card = obj
                Dim objRemoveCardViewModel As CardViewModel = (From x As CardViewModel In _objCardViewModels Where System.Object.ReferenceEquals(x.Card, objRemoveCard) Select x).FirstOrDefault

                If objRemoveCardViewModel IsNot Nothing Then
                    _objCardViewModels.Remove(objRemoveCardViewModel)
                End If

            Next

        ElseIf e.Action = Specialized.NotifyCollectionChangedAction.Add Then

            For Each obj As Card In e.NewItems
                _objCardViewModels.Add(New CardViewModel(obj))
            Next

        End If

    End Sub

#End Region

#Region " Search & Filter Methods "

    Private Function Contains(ByVal obj As Object) As Boolean
        Return DirectCast(obj, CardViewModel).Card.Filter(_strCardTypeFilter, _strFilterText.Trim)
    End Function

    Private Sub ResetFilterTextExecute(ByVal param As Object)
        Me.FilterText = String.Empty
    End Sub

    Private Sub Search()
        SetResetButton()
        _objCardViewModelSearchResults.Dispatcher.BeginInvoke(Windows.Threading.DispatcherPriority.ApplicationIdle, New FilterDelegate(AddressOf SearchWorker))
        SetViewingMessage()
    End Sub

    Private Sub SearchWorker()

        If Me.FilterText.Trim.Length > 0 OrElse _strCardTypeFilter <> Application.STR_ALLRECORDS Then
            _objCardViewModelSearchResults.Filter = New Predicate(Of Object)(AddressOf Me.Contains)

        Else
            _objCardViewModelSearchResults.Filter = Nothing
        End If

    End Sub

    Public Sub SetCardTypeFilter(ByVal strCardTypeFilter As String)
        _strCardTypeFilter = strCardTypeFilter
        Search()
        SetViewingMessage()
    End Sub

    Private Sub SetResetButton()

        If Me.FilterText.Trim.Length = 0 Then
            Me.FilterButtonVisibility = Windows.Visibility.Hidden

        Else
            Me.FilterButtonVisibility = Windows.Visibility.Visible
        End If

    End Sub

    Private Sub SetViewingMessage()

        Dim strCardTypeFilter As String = _strCardTypeFilter

        If Not _strCardTypeFilter.EndsWith("s") Then
            strCardTypeFilter = String.Concat(_strCardTypeFilter, "s")
        End If

        If String.IsNullOrEmpty(Me.FilterText) Then

            If strCardTypeFilter.StartsWith("All") Then
                Me.ViewingMessage = String.Format("Viewing {0}", strCardTypeFilter)

            Else
                Me.ViewingMessage = String.Format("Viewing all {0}", strCardTypeFilter)
            End If

        Else
            Me.ViewingMessage = String.Format("Viewing filtered list of {0}", strCardTypeFilter)
        End If

    End Sub

#End Region

End Class
