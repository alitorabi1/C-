Partial Public Class ChangePasswordDialogView

#Region " Events "

    Private WithEvents _objChangePasswordDialogViewModel As ChangePasswordDialogViewModel

#End Region

#Region " Methods "

    'this code is required here because the WPF Password TextBox does not expose Password as a 
    '   dependency property so we can't bind directly to it.
    Private Sub ChangePasswordDialogView_Loaded(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs) Handles Me.Loaded
        _objChangePasswordDialogViewModel = TryCast(Me.DataContext, ChangePasswordDialogViewModel)
        Me.txtCurrentPassword.Focus()
    End Sub

    Private Sub ChangePasswordDialogViewModel_PasswordChangedFailed(ByVal sender As Object, ByVal e As System.EventArgs) Handles _objChangePasswordDialogViewModel.PasswordChangedFailed
        Me.txtCurrentPassword.Clear()
    End Sub

    Private Sub ChangePasswordDialogViewModel_RequestClose(ByVal sender As Object, ByVal e As System.EventArgs) Handles _objChangePasswordDialogViewModel.RequestClose
        Me.Close()
    End Sub

    Private Sub txtCurrentPassword_PasswordChanged(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs) Handles txtCurrentPassword.PasswordChanged
        e.Handled = True

        If _objChangePasswordDialogViewModel IsNot Nothing Then
            _objChangePasswordDialogViewModel.CurrentPassword = Me.txtCurrentPassword.Password
        End If

    End Sub

#End Region

End Class
