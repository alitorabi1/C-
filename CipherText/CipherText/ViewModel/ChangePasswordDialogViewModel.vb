
Public Class ChangePasswordDialogViewModel
    Inherits ViewModelBase

#Region " Declarations "

    Private _cmdCancelCommand As ICommand
    Private _cmdSaveCommand As ICommand
    Private _strCurrentPassword As String = String.Empty
    Private _strNewPassword As String = String.Empty

#End Region

#Region " Properties "

    Public Property CurrentPassword() As String
        Get
            Return _strCurrentPassword
        End Get
        Set(ByVal Value As String)
            _strCurrentPassword = Value
        End Set
    End Property

    Public Property NewPassword() As String
        Get
            Return _strNewPassword
        End Get
        Set(ByVal Value As String)
            _strNewPassword = Value
            OnPropertyChanged("NewPassword")
        End Set
    End Property

#End Region

#Region " Events "

    Public Event PasswordChangedFailed As EventHandler
    Public Event RequestClose As EventHandler

#End Region

#Region " Command Properties "

    Public ReadOnly Property CancelCommand() As ICommand
        Get

            If _cmdCancelCommand Is Nothing Then
                _cmdCancelCommand = New RelayCommand(AddressOf CancelExecute)
            End If

            Return _cmdCancelCommand
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

#Region " Command Methods "

    Private Sub CancelExecute(ByVal parm As Object)
        OnRequestClose()
    End Sub

    Private Function CanSaveExecute(ByVal param As Object) As Boolean
        Return _strNewPassword.Trim.Length > 0
    End Function

    Private Sub SaveExecute(ByVal param As Object)

        If CanSaveExecute(param) Then

            If _strCurrentPassword = Application.Password Then
                Application.Password = _strNewPassword
                OnRequestClose()

            Else
                'TODO - developers, you can add much more security and logging here
                OnPasswordChangedFailed()
                Application.NotificationMessageBox("Incorrect Password", "Please re-enter your password.")
            End If

        End If

    End Sub

#End Region

#Region " Methods "

    Protected Sub OnPasswordChangedFailed()
        Me.NewPassword = String.Empty

        Dim handler As EventHandler = Me.PasswordChangedFailedEvent

        If handler IsNot Nothing Then
            handler.Invoke(Me, EventArgs.Empty)
        End If

    End Sub

    Protected Sub OnRequestClose()

        Dim handler As EventHandler = Me.RequestCloseEvent

        If handler IsNot Nothing Then
            handler.Invoke(Me, EventArgs.Empty)
        End If

    End Sub

#End Region

End Class
