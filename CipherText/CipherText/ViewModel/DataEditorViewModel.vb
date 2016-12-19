Imports System.Collections.ObjectModel
Imports System.ComponentModel

Public Class DataEditorViewModel
    Inherits ViewModelBase

#Region " Declarations "

    Private _bolInSchemaEditingMode As Boolean = False
    Private _bolSortingInProgress As Boolean = False
    Private _cmdAddFieldCommand As ICommand
    Private _cmdCancelCommand As ICommand
    Private _cmdDeleteCommand As ICommand
    Private _cmdModifyCharacterCasingRulesCommand As ICommand
    Private _cmdModifyFormCommand As ICommand
    Private _cmdSaveCommand As ICommand
    Private _enumDataEditorVisibility As Visibility = Visibility.Collapsed
    Private _objCardFieldCollection As New ObservableCollection(Of FieldEditorViewModel)
    Private _objCurrentCard As Card
    Private _objListCollectionView As ListCollectionView
    Private _objOriginalCard As Card
    Private _strModifyFormCommandText As String = String.Empty
    Private _strModifyFormCommandToolTip As String = String.Empty

#End Region

#Region " Events "

    Public Event RequestClose As EventHandler

#End Region

#Region " Properties "

    Public Property Card() As Card
        Get
            Return _objCurrentCard
        End Get

        Private Set(ByVal Value As Card)
            _objCurrentCard = Value
            OnPropertyChanged("Card")
        End Set
    End Property

    Public ReadOnly Property CardFieldCollection() As ObservableCollection(Of FieldEditorViewModel)
        Get
            Return _objCardFieldCollection
        End Get
    End Property

    Public Property DataEditorVisibility() As Visibility
        Get
            Return _enumDataEditorVisibility
        End Get

        Private Set(ByVal Value As Visibility)
            _enumDataEditorVisibility = Value
            OnPropertyChanged("DataEditorVisibility")
        End Set
    End Property

    Public Property InSchemaEditingMode() As Boolean
        Get
            Return _bolInSchemaEditingMode
        End Get

        Private Set(ByVal Value As Boolean)
            _bolInSchemaEditingMode = Value
            OnPropertyChanged("InSchemaEditingMode")
        End Set
    End Property

    Public Property ModifyFormCommandText() As String
        Get
            Return _strModifyFormCommandText
        End Get

        Private Set(ByVal Value As String)
            _strModifyFormCommandText = Value
            OnPropertyChanged("ModifyFormCommandText")
        End Set
    End Property

    Public Property ModifyFormCommandToolTip() As String
        Get
            Return _strModifyFormCommandToolTip
        End Get

        Private Set(ByVal Value As String)
            _strModifyFormCommandToolTip = Value
            OnPropertyChanged("ModifyFormCommandToolTip")
        End Set
    End Property

#End Region

#Region " Command Properties "

    Public ReadOnly Property AddFieldCommand() As ICommand
        Get

            If _cmdAddFieldCommand Is Nothing Then
                _cmdAddFieldCommand = New RelayCommand(AddressOf AddFieldExecute, AddressOf CanAddFieldExecute)
            End If

            Return _cmdAddFieldCommand
        End Get
    End Property

    Public ReadOnly Property CancelCommand() As ICommand
        Get

            If _cmdCancelCommand Is Nothing Then
                _cmdCancelCommand = New RelayCommand(AddressOf CancelExecute)
            End If

            Return _cmdCancelCommand
        End Get
    End Property

    Public ReadOnly Property DeleteCommand() As ICommand
        Get

            If _cmdDeleteCommand Is Nothing Then
                _cmdDeleteCommand = New RelayCommand(AddressOf DeleteExecute, AddressOf CanDeleteExecute)
            End If

            Return _cmdDeleteCommand
        End Get
    End Property

    Public ReadOnly Property ModifyCharacterCasingRulesCommand() As ICommand
        Get

            If _cmdModifyCharacterCasingRulesCommand Is Nothing Then
                _cmdModifyCharacterCasingRulesCommand = New RelayCommand(AddressOf ModifyCharacterCasingRulesExecute)
            End If

            Return _cmdModifyCharacterCasingRulesCommand
        End Get
    End Property

    Public ReadOnly Property ModifyFormCommand() As ICommand
        Get

            If _cmdModifyFormCommand Is Nothing Then
                _cmdModifyFormCommand = New RelayCommand(AddressOf ModifyFormExecute, AddressOf CanModifyFormExecute)
            End If

            Return _cmdModifyFormCommand
        End Get
    End Property

    Public ReadOnly Property SaveCommand() As ICommand
        Get

            If _cmdSaveCommand Is Nothing Then
                _cmdSaveCommand = New RelayCommand(AddressOf SaveExecute, AddressOf CanSaveExecute)
            End If

            Return _cmdSaveCommand
        End Get
    End Property

#End Region

#Region " Constructors "

    Public Sub New(ByVal objCard As Card)
        DataEditorVisibility = Visibility.Visible
        _objOriginalCard = objCard
        Me.Card = objCard.Clone
        LoadCardFields()
        EnableEditForm()
    End Sub

    Public Sub New(ByVal objCardType As CardType)
        DataEditorVisibility = Visibility.Visible
        Me.Card = New Card With {.CardTypeName = objCardType.CardTypeName, .DateCreated = Now.ToShortDateString, .CardFields = objCardType.CloneCardFields}
        LoadCardFields()
        EnableEditForm()
    End Sub

#End Region

#Region " Command Methods "

    Private Sub AddFieldExecute(ByVal param As Object)

        If CanAddFieldExecute(param) Then
            LoadCardField(Me.Card.CardFields.AddEmptyCardField(), True)
            SortFields()
        End If

    End Sub

    Private Function CanAddFieldExecute(ByVal param As Object) As Boolean
        Return _bolInSchemaEditingMode
    End Function

    Private Sub CancelExecute(ByVal parm As Object)
        CleanUp()
    End Sub

    Private Function CanDeleteExecute(ByVal param As Object) As Boolean
        Return Not _objOriginalCard Is Nothing
    End Function

    Private Function CanModifyFormExecute(ByVal param As Object) As Boolean

        If Not _bolInSchemaEditingMode Then
            Return True

        Else
            Return _objCurrentCard.IsValid
        End If

    End Function

    Private Function CanSaveExecute(ByVal parm As Object) As Boolean
        Return _objCurrentCard.IsValid
    End Function

    Private Sub DeleteExecute(ByVal param As Object)

        If CanDeleteExecute(param) Then

            If Application.ConfirmAction("Delete Card", "Are you sure you want to delete this card?") Then

                If _objOriginalCard IsNot Nothing Then
                    Application.DataBase.Cards.Remove(_objOriginalCard)
                End If

                CleanUp()
            End If

        End If

    End Sub

    Private Sub EnableEditForm()
        Me.ModifyFormCommandText = "Modify Form"
        Me.ModifyFormCommandToolTip = "Click to enable form field modifications."
    End Sub

    Private Sub EnableNormalForm()
        Me.ModifyFormCommandText = "Normal Form"
        Me.ModifyFormCommandToolTip = "Click to close modify form mode and return to normal form editing."
    End Sub

    Private Sub ModifyCharacterCasingRulesExecute(ByVal param As Object)

        Dim obj As New ModifyCaseCorrectionView
        obj.DataContext = New ModifyCaseCorrectionViewModel
        obj.ShowInTaskbar = True
        obj.WindowStartupLocation = WindowStartupLocation.CenterScreen
        obj.Topmost = Application.IsApplicationTopMost
        obj.ShowDialog()
    End Sub

    Private Sub ModifyFormExecute(ByVal param As Object)

        If CanModifyFormExecute(param) Then

            If _bolInSchemaEditingMode Then
                Me.InSchemaEditingMode = False
                EnableEditForm()

                For Each obj As FieldEditorViewModel In Me.CardFieldCollection
                    obj.InSchemaEditingMode = False
                Next

            Else
                Me.InSchemaEditingMode = True
                EnableNormalForm()

                For Each obj As FieldEditorViewModel In Me.CardFieldCollection
                    obj.InSchemaEditingMode = True
                Next

            End If

        End If

    End Sub

    Private Sub SaveExecute(ByVal param As Object)

        If CanSaveExecute(param) Then
            _bolSortingInProgress = True
            DataEditorVisibility = Visibility.Hidden
            RemovePropertyChangedEventHandlers()

            Dim objRemoveFieldList As New List(Of CardField)

            For intX As Integer = 0 To _objCurrentCard.CardFields.Count - 1

                If _objCurrentCard.CardFields(intX).IsMarkedForDelete Then
                    objRemoveFieldList.Add(_objCurrentCard.CardFields(intX))
                End If

            Next

            If objRemoveFieldList.Count > 0 Then

                For intX As Integer = 0 To objRemoveFieldList.Count - 1
                    _objCurrentCard.CardFields.Remove(objRemoveFieldList(intX))
                Next

                _objCurrentCard.CardFields.Sort()
            End If

            objRemoveFieldList.Clear()
            objRemoveFieldList = Nothing

            If _objOriginalCard Is Nothing Then
                Application.DataBase.Cards.Add(_objCurrentCard)

            Else
                Application.DataBase.Cards.Remove(_objOriginalCard)
                _objCurrentCard.DateModified = Now.ToShortDateString
                Application.DataBase.Cards.Add(_objCurrentCard.Clone)

                If Not Application.DataBase.Save() Then
                    Application.ShowEncryptionFailedMessage()
                    Application.Current.Shutdown()
                End If

            End If

            CleanUp()
        End If

    End Sub

#End Region

#Region " Methods "

    Private Sub AddPropertyChangedEventHandlers()

        For Each obj As FieldEditorViewModel In Me.CardFieldCollection
            AddHandler obj.PropertyChanged, AddressOf FieldEditorViewModel_PropertyChanged
        Next

    End Sub

    Private Sub CleanUp()
        'this seems strange that this type of extensive cleanup is necessary,
        '  but it is.
        RemovePropertyChangedEventHandlers()
        _objListCollectionView = Nothing

        For Each obj As FieldEditorViewModel In Me.CardFieldCollection
            obj.CleanUp()
        Next

        _objCardFieldCollection.Clear()
        Me.Card = Nothing
        _objOriginalCard = Nothing
        DataEditorVisibility = Visibility.Hidden
        OnRequestClose()
        '
        'This GC.Collect helps keep memory usage lower than if it was not here.
        GC.Collect(5)
    End Sub

    Private Sub FieldEditorViewModel_PropertyChanged(ByVal sender As Object, ByVal e As System.ComponentModel.PropertyChangedEventArgs)

        If Not _bolSortingInProgress AndAlso e.PropertyName = "FieldSortOrder" Then
            _bolSortingInProgress = True
            RemovePropertyChangedEventHandlers()
            _objCurrentCard.CardFields.Sort()
            SortFields()
            AddPropertyChangedEventHandlers()
            _bolSortingInProgress = False
        End If

    End Sub

    Private Sub LoadCardField(ByVal obj As CardField, Optional ByVal bolLoadInEditMode As Boolean = False)
        _objCardFieldCollection.Add(New FieldEditorViewModel(obj, bolLoadInEditMode))
        AddHandler obj.PropertyChanged, AddressOf FieldEditorViewModel_PropertyChanged
    End Sub

    Private Sub LoadCardFields()

        For Each obj As CardField In _objCurrentCard.CardFields
            LoadCardField(obj)
        Next

        SortFields()
    End Sub

    Protected Sub OnRequestClose()

        Dim handler As EventHandler = Me.RequestCloseEvent

        If handler IsNot Nothing Then
            handler.Invoke(Me, EventArgs.Empty)
        End If

    End Sub

    Private Sub RemovePropertyChangedEventHandlers()

        For Each obj As FieldEditorViewModel In _objCardFieldCollection
            RemoveHandler obj.PropertyChanged, AddressOf FieldEditorViewModel_PropertyChanged
        Next

    End Sub

    Private Sub SortFields()
        _objListCollectionView = TryCast(CollectionViewSource.GetDefaultView(_objCardFieldCollection), ListCollectionView)
        _objListCollectionView.SortDescriptions.Add(New SortDescription("CardField.FieldSortOrder", ListSortDirection.Ascending))
    End Sub

#End Region

End Class
