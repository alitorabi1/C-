Imports System.ComponentModel
'
Partial Public Class GeneratePasswordDialog

#Region " Declarations "

    Private _cmdGeneratePasswordCommand As ICommand
    Private _intPasswordLength As Integer = 8
    Private _strPassword As String = String.Empty

#End Region

#Region " Properties "

    Public ReadOnly Property GeneratePasswordCommand() As ICommand
        Get

            If _cmdGeneratePasswordCommand Is Nothing Then
                _cmdGeneratePasswordCommand = New RelayCommand(AddressOf GeneratePasswordExecute, AddressOf CanGeneratePasswordExecute)
            End If

            Return _cmdGeneratePasswordCommand
        End Get
    End Property

    Public ReadOnly Property Password() As String
        Get
            Return _strPassword
        End Get
    End Property

    Public Property PasswordLength() As Integer
        Get
            Return _intPasswordLength
        End Get
        Set(ByVal Value As Integer)
            _intPasswordLength = Value
        End Set
    End Property

#End Region

#Region " Methods "

    Private Function CanGeneratePasswordExecute(ByVal param As Object) As Boolean
        Return Not (Me.chkIncludeLowerCaseLetters.IsChecked.Value = False AndAlso Me.chkIncludeNumbers.IsChecked.Value = False AndAlso Me.chkIncludeSpecialCharacters.IsChecked.Value = False AndAlso Me.chkIncludeUpperCaseLetters.IsChecked.Value = False)
    End Function

    Private Sub GeneratePassword_Loaded(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs) Handles Me.Loaded
        Me.DataContext = Me
    End Sub

    Private Sub GeneratePasswordExecute(ByVal param As Object)

        If CanGeneratePasswordExecute(param) Then
            _strPassword = RandomPassword.Generate(Me.PasswordLength, chkIncludeSpecialCharacters.IsChecked.Value, chkIncludeNumbers.IsChecked.Value, chkIncludeUpperCaseLetters.IsChecked.Value, chkIncludeLowerCaseLetters.IsChecked.Value)
            Me.DialogResult = True
        End If

    End Sub

#End Region

End Class
