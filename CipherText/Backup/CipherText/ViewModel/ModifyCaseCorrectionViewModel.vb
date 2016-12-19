Imports System.Collections.ObjectModel

Public Class ModifyCaseCorrectionViewModel
    Inherits ViewModelBase

#Region " Declarations "

    Private _cmdAddCharacterCasingCheckCommand As ICommand
    Private _cmdCancelCommand As ICommand
    Private _cmdDeleteCharacterCasingCheckCommand As ICommand
    Private _cmdSaveCommand As ICommand
    Private _objCharacterCasingCheckViewModels As New ObservableCollection(Of CharacterCasingCheckViewModel)

#End Region

#Region " Events "

    Public Event RequestClose As EventHandler

#End Region

#Region " Properties "

    Public Property CharacterCasingCheckViewModels() As ObservableCollection(Of CharacterCasingCheckViewModel)
        Get
            Return _objCharacterCasingCheckViewModels
        End Get

        Private Set(ByVal Value As ObservableCollection(Of CharacterCasingCheckViewModel))
            _objCharacterCasingCheckViewModels = Value
            OnPropertyChanged("CharacterCasingCheckViewModels")
        End Set
    End Property

#End Region

#Region " Command Properties "

    Public ReadOnly Property AddCharacterCasingCheckCommand() As ICommand
        Get

            If _cmdAddCharacterCasingCheckCommand Is Nothing Then
                _cmdAddCharacterCasingCheckCommand = New RelayCommand(AddressOf AddCharacterCasingCheckExecute)
            End If

            Return _cmdAddCharacterCasingCheckCommand
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

    Public ReadOnly Property DeleteCharacterCasingCheckCommand() As ICommand
        Get
            Return _cmdDeleteCharacterCasingCheckCommand
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

    Public Sub New()
        Application.DataBase.CharacterCasingChecks.Sort()

        '
        'create a working deep copy of the rules
        For Each obj As CharacterCasingCheck In DeepCopy.Make(Of List(Of CharacterCasingCheck))(Application.DataBase.CharacterCasingChecks)
            _objCharacterCasingCheckViewModels.Add(New CharacterCasingCheckViewModel(New RelayCommand(Of CharacterCasingCheckViewModel)(AddressOf DeleteCharacterCasingCheckExecute), obj))
        Next

    End Sub

#End Region

#Region " Command Methods "

    Private Sub AddCharacterCasingCheckExecute(ByVal param As Object)
        _objCharacterCasingCheckViewModels.Add(New CharacterCasingCheckViewModel(New RelayCommand(Of CharacterCasingCheckViewModel)(AddressOf DeleteCharacterCasingCheckExecute), New CharacterCasingCheck))
    End Sub

    Private Sub CancelExecute(ByVal param As Object)
        OnRequestClose()
    End Sub

    Private Function CanSaveExecute(ByVal param As Object) As Boolean

        'a users entry error is far more likely at the bottom of the list than the top, 
        'since new records are added at the bottom.
        'CanSaveExecute runs many times so this needs to be fast as possible
        For intX As Integer = Me.CharacterCasingCheckViewModels.Count - 1 To 0 Step -1

            If CharacterCasingCheckViewModels(intX).CharacterCasingCheck.Error.Length > 0 Then
                Return False
            End If

        Next

        Return True
    End Function

    Private Sub DeleteCharacterCasingCheckExecute(ByVal param As CharacterCasingCheckViewModel)

        If Application.ConfirmAction("Delete", "Are you sure you want to delete this casing rule?") Then
            _objCharacterCasingCheckViewModels.Remove(param)
        End If

    End Sub

    Private Sub SaveExecute(ByVal param As Object)

        If CanSaveExecute(param) Then
            'clean up old rules
            Application.DataBase.CharacterCasingChecks.Clear()

            '
            'extract new rules from viewmodel
            Dim objCharacterCasingCheck As New List(Of CharacterCasingCheck)

            For Each obj As CharacterCasingCheckViewModel In _objCharacterCasingCheckViewModels
                objCharacterCasingCheck.Add(obj.CharacterCasingCheck)
            Next

            '
            'save a deep copy of the new rules to the database
            Application.DataBase.CharacterCasingChecks = DeepCopy.Make(Of List(Of CharacterCasingCheck))(objCharacterCasingCheck)

            '
            'save database
            If Not Application.DataBase.Save() Then
                Application.ShowEncryptionFailedMessage()
                Application.Current.Shutdown()
            End If

            '
            'close
            OnRequestClose()
        End If

    End Sub

#End Region

#Region " Methods "

    Protected Sub OnRequestClose()

        Dim handler As EventHandler = Me.RequestCloseEvent

        If handler IsNot Nothing Then
            handler.Invoke(Me, EventArgs.Empty)
        End If

    End Sub

#End Region

End Class
