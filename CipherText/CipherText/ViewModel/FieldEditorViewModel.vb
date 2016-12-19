Imports System.ComponentModel
Imports System.Collections.ObjectModel

Public Class FieldEditorViewModel
    Inherits ViewModelBase

#Region " Declarations "

    Private _bolDisposedValue As Boolean = False
    Private _bolInSchemaEditingMode As Boolean = False
    Private _bolIsFieledInEditMode As Boolean = False
    Private _bolIsMarkedForDelete As Boolean = False
    Private _cmdContractEditFieldCommand As ICommand
    Private _cmdEditFieldCommand As ICommand
    Private _cmdGeneratePasswordCommand As ICommand
    Private _cmdRemoveFieldCommand As ICommand
    Private _cmdRestoreFieldCommand As ICommand
    Private _objAvailableFieldCases As List(Of OptionViewModel(Of FieldCase))
    Private _objAvailableFieldTypes As List(Of OptionViewModel(Of FieldType))
    Private WithEvents _objCardField As CardField

#End Region

#Region " Properties "

    Public ReadOnly Property AvailableFieldCases() As List(Of OptionViewModel(Of FieldCase))
        Get

            If _objAvailableFieldCases Is Nothing Then
                CreateAvailableFieldCases()
            End If

            Return _objAvailableFieldCases
        End Get
    End Property

    Public ReadOnly Property AvailableFieldTypes() As List(Of OptionViewModel(Of FieldType))
        Get

            If _objAvailableFieldTypes Is Nothing Then
                CreateAvailableFieldTypes()
            End If

            Return _objAvailableFieldTypes
        End Get
    End Property

    Public Property CardField() As CardField
        Get
            Return _objCardField
        End Get

        Private Set(ByVal Value As CardField)
            _objCardField = Value
            OnPropertyChanged("CardField")
        End Set
    End Property

    Public Property InSchemaEditingMode() As Boolean
        Get
            Return _bolInSchemaEditingMode
        End Get
        Set(ByVal Value As Boolean)
            _bolInSchemaEditingMode = Value
            Me.IsFieledInEditMode = False
            OnPropertyChanged("InSchemaEditingMode")
        End Set
    End Property

    Public Property IsFieledInEditMode() As Boolean
        Get
            Return _bolIsFieledInEditMode
        End Get

        Private Set(ByVal Value As Boolean)
            _bolIsFieledInEditMode = Value
            OnPropertyChanged("IsFieledInEditMode")
        End Set
    End Property

    Public Property IsMarkedForDelete() As Boolean
        Get
            Return _bolIsMarkedForDelete
        End Get

        Private Set(ByVal Value As Boolean)
            _bolIsMarkedForDelete = Value
            OnPropertyChanged("IsMarkedForDelete")
        End Set
    End Property

#End Region

#Region " Command Properties "

    Public ReadOnly Property ContractEditFieldCommand() As ICommand
        Get

            If _cmdContractEditFieldCommand Is Nothing Then
                _cmdContractEditFieldCommand = New RelayCommand(AddressOf ContractEditFieldExecute, AddressOf CanContractEditFieldExecute)
            End If

            Return _cmdContractEditFieldCommand
        End Get
    End Property

    Public ReadOnly Property EditFieldCommand() As ICommand
        Get

            If _cmdEditFieldCommand Is Nothing Then
                _cmdEditFieldCommand = New RelayCommand(AddressOf EditFieldExecute, AddressOf CanEditFieldExecute)
            End If

            Return _cmdEditFieldCommand
        End Get
    End Property

    Public ReadOnly Property GeneratePasswordCommand() As ICommand
        Get

            If _cmdGeneratePasswordCommand Is Nothing Then
                _cmdGeneratePasswordCommand = New RelayCommand(AddressOf GeneratePasswordExecute, AddressOf CanGeneratePasswordExecute)
            End If

            Return _cmdGeneratePasswordCommand
        End Get
    End Property

    Public ReadOnly Property RemoveFieldCommand() As ICommand
        Get

            If _cmdRemoveFieldCommand Is Nothing Then
                _cmdRemoveFieldCommand = New RelayCommand(AddressOf RemoveFieldExecute)
            End If

            Return _cmdRemoveFieldCommand
        End Get
    End Property

    Public ReadOnly Property RestoreFieldCommand() As ICommand
        Get

            If _cmdRestoreFieldCommand Is Nothing Then
                _cmdRestoreFieldCommand = New RelayCommand(AddressOf RestoreFieldExecute, AddressOf CanRestoreFieldExecute)
            End If

            Return _cmdRestoreFieldCommand
        End Get
    End Property

#End Region

#Region " Constructors "

    Public Sub New(ByVal objCardField As CardField)
        _objCardField = objCardField
    End Sub

    Public Sub New(ByVal objCardField As CardField, ByVal bolEnableEeditMode As Boolean)
        _objCardField = objCardField

        If bolEnableEeditMode Then
            Me.InSchemaEditingMode = True
            Me.IsFieledInEditMode = True
        End If

    End Sub

#End Region

#Region " Command Methods "

    Private Function CanContractEditFieldExecute(ByVal parma As Object) As Boolean

        If _objCardField IsNot Nothing Then
            Return _bolInSchemaEditingMode AndAlso _bolIsFieledInEditMode AndAlso String.IsNullOrEmpty(_objCardField.Error)

        Else
            Return False

        End If
    End Function

    Private Function CanEditFieldExecute(ByVal param As Object) As Boolean
        Return Not _bolIsFieledInEditMode AndAlso _bolInSchemaEditingMode
    End Function

    Private Function CanGeneratePasswordExecute(ByVal param As Object) As Boolean

        If _objCardField IsNot Nothing Then
            Return _objCardField.FieldType = FieldType.PasswordPrimary OrElse _objCardField.FieldType = FieldType.PasswordSecondary

        Else
            Return False
        End If

    End Function

    Private Function CanRestoreFieldExecute(ByVal param As Object) As Boolean
        Return _bolIsMarkedForDelete
    End Function

    Private Sub ContractEditFieldExecute(ByVal param As Object)

        If CanContractEditFieldExecute(param) Then
            Me.IsFieledInEditMode = False
            OnPropertyChanged("CardField")
        End If

    End Sub

    Private Sub EditFieldExecute(ByVal param As Object)

        If CanEditFieldExecute(param) Then
            Me.IsFieledInEditMode = True
            OnPropertyChanged("CardField")
        End If

    End Sub

    Private Sub GeneratePasswordExecute(ByVal param As Object)

        If CanGeneratePasswordExecute(param) Then

            Dim strPassword As String = Application.GeneratePassword

            If Not String.IsNullOrEmpty(strPassword) Then
                Me.CardField.FieldData = strPassword
            End If

        End If

    End Sub

    Private Sub RemoveFieldExecute(ByVal param As Object)
        Me.IsMarkedForDelete = True 'this causes the border to overlay the field controls
        Me.CardField.IsMarkedForDelete = True 'this marks the field for removal after being saved
    End Sub

    Private Sub RestoreFieldExecute(ByVal param As Object)

        If CanRestoreFieldExecute(param) Then
            Me.IsMarkedForDelete = False
            Me.CardField.IsMarkedForDelete = False
            OnPropertyChanged("CardField")
        End If

    End Sub

#End Region

#Region " Methods "

    Private Sub CardField_PropertyChanged(ByVal sender As Object, ByVal e As System.ComponentModel.PropertyChangedEventArgs) Handles _objCardField.PropertyChanged

        If e.PropertyName = "FieldSortOrder" Then
            MyBase.OnPropertyChanged("FieldSortOrder")
        End If

        'When in edit mode, we need the form to refresh and check validation rules
        'as the form is being edited.  This accomplishes this.
        If _bolIsFieledInEditMode Then
            OnPropertyChanged("CardField")
        End If

    End Sub

    Public Sub CleanUp()
        'this seems strange that this type of extensive cleanup is necessary,
        '  but it is.  Not sure why, but these collections kept hanging around
        '  until I did this.  I think it has to do with the fact that the
        '  OptionViewModel implements INotifyPropertyChanged and WeakReference
        '  objects were holding on to these.
        _objAvailableFieldCases.Clear()
        _objAvailableFieldTypes.Clear()
        _objAvailableFieldCases = Nothing
        _objAvailableFieldTypes = Nothing
        _objCardField = Nothing
    End Sub

    Private Sub CreateAvailableFieldCases()
        _objAvailableFieldCases = New List(Of OptionViewModel(Of FieldCase))
        With _objAvailableFieldCases
            .Add(New OptionViewModel(Of FieldCase)("Lower", FieldCase.Lower))
            .Add(New OptionViewModel(Of FieldCase)("None", FieldCase.None))
            .Add(New OptionViewModel(Of FieldCase)("Outlook Phone", FieldCase.OutlookPhoneProper))
            .Add(New OptionViewModel(Of FieldCase)("Proper", FieldCase.Proper))
            .Add(New OptionViewModel(Of FieldCase)("Upper", FieldCase.Upper))
        End With
        _objAvailableFieldCases.Sort()
    End Sub

    Private Sub CreateAvailableFieldTypes()
        _objAvailableFieldTypes = New List(Of OptionViewModel(Of FieldType))
        With _objAvailableFieldTypes
            .Add(New OptionViewModel(Of FieldType)("Credit Card Number", FieldType.CreditCardNumber))
            .Add(New OptionViewModel(Of FieldType)("Email", FieldType.Email))
            .Add(New OptionViewModel(Of FieldType)("IP Address", FieldType.IP))
            .Add(New OptionViewModel(Of FieldType)("Password Primary", FieldType.PasswordPrimary))
            .Add(New OptionViewModel(Of FieldType)("Password Secondary", FieldType.PasswordSecondary))
            .Add(New OptionViewModel(Of FieldType)("Plain Text", FieldType.Plain))
            .Add(New OptionViewModel(Of FieldType)("Routing Number", FieldType.RoutingNumber))
            .Add(New OptionViewModel(Of FieldType)("URL Primary", FieldType.URLPrimary))
            .Add(New OptionViewModel(Of FieldType)("URL Secondary", FieldType.URLSecondary))
            .Add(New OptionViewModel(Of FieldType)("User Name Primary", FieldType.UserNamePrimary))
            .Add(New OptionViewModel(Of FieldType)("User Name Secondary", FieldType.UserNameSecondary))
        End With
        _objAvailableFieldTypes.Sort()
    End Sub

#End Region

End Class
