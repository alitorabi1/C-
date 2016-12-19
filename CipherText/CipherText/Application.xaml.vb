Imports System.IO

Class Application

#Region " Declarations "

    Public Const STR_ALLRECORDS As String = "All Records"

    Private Shared _objDataBase As DataBase
    Private Shared _strCipherText As String = Nothing
    Private Shared _strDataFileName As String
    Private Shared _strPassword As String = String.Empty

#End Region

#Region " Properties "

    Public Shared ReadOnly Property CipherText() As String
        Get
            Return _strCipherText
        End Get
    End Property

    Public Shared ReadOnly Property DataBase() As DataBase
        Get
            Return _objDataBase
        End Get
    End Property

    Public Shared ReadOnly Property DataFileName() As String
        Get
            Return _strDataFileName
        End Get
    End Property

    Public Shared ReadOnly Property IsApplicationTopMost() As Boolean
        Get
            Return CType(Application.Current.MainWindow, ApplicationMainWindowView).IsOnTop
        End Get
    End Property

    Public Shared Property Password() As String
        Get
            Return _strPassword
        End Get
        Set(ByVal Value As String)
            _strPassword = Value
        End Set
    End Property

#End Region

#Region " Methods "

    Private Sub App_Exit(ByVal sender As Object, ByVal e As System.Windows.ExitEventArgs) Handles Me.Exit

        If _objDataBase IsNot Nothing Then

            If Not _objDataBase.Save() Then
                ShowEncryptionFailedMessage()
            End If

        End If

        My.Computer.Clipboard.Clear()
    End Sub

    Private Sub Application_Startup(ByVal sender As Object, ByVal e As System.Windows.StartupEventArgs) Handles Me.Startup
        _strDataFileName = Path.Combine(My.Application.Info.DirectoryPath, "CipherTextData.enc")
        Application.Current.ShutdownMode = System.Windows.ShutdownMode.OnExplicitShutdown

        Dim objLogin As New LoginDialog

        If objLogin.ShowDialog = True Then
            _objDataBase = objLogin.DataBase
            objLogin.Close()
            objLogin = Nothing

            Dim objApplicationMainWindowView As New ApplicationMainWindowView(New ApplicationMainWindowViewModel)
            objApplicationMainWindowView.WindowStartupLocation = WindowStartupLocation.CenterScreen
            objApplicationMainWindowView.Show()

        Else
            Application.Current.Shutdown()
        End If

    End Sub

    Public Shared Function ConfirmAction(ByVal strCaption As String, ByVal strMessage As String) As Boolean

        If MessageBox.Show(strMessage, strCaption, MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) = MessageBoxResult.Yes Then
            Return True

        Else
            Return False
        End If

    End Function

    Public Shared Function GeneratePassword() As String

        Dim strResult As String = Nothing
        Dim obj As New GeneratePasswordDialog
        obj.WindowStartupLocation = WindowStartupLocation.CenterScreen
        obj.Topmost = Application.IsApplicationTopMost

        Dim result As System.Nullable(Of Boolean) = obj.ShowDialog

        If result.HasValue AndAlso result.Value = True Then
            strResult = obj.Password
        End If

        obj.Close()
        obj = Nothing
        Return strResult
    End Function

    Public Shared Sub NotificationMessageBox(ByVal strCaption As String, ByVal strMessage As String)
        MessageBox.Show(strMessage, strCaption, MessageBoxButton.OK, MessageBoxImage.Exclamation, MessageBoxResult.OK)
    End Sub

    Public Shared Sub ShowEncryptionFailedMessage()
        MessageBox.Show("Data File Encryption Write Failure", "An error occurred when writing Cipher Text Data to an encrypted file.  Your original data is untouched.  Any changes you have made since the last save are lost.  This application will not close.  You may restart the application.  Please report the error message by placing a comment on the Code Project article.", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK)
    End Sub

    Public Shared Sub StartProcessWithFileName(ByVal strFileName As String)

        Dim psi As New System.Diagnostics.ProcessStartInfo
        psi.FileName = strFileName
        psi.UseShellExecute = True
        System.Diagnostics.Process.Start(psi)
    End Sub

#End Region

End Class
