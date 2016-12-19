Partial Public Class ApplicationMainWindowView

#Region " Declarations "

    Private _bolIsOnTop As Boolean = False

#End Region

#Region " Properties "

    Public ReadOnly Property IsOnTop() As Boolean
        Get
            Return _bolIsOnTop
        End Get
    End Property

#End Region

#Region " Constructors "

    Public Sub New(ByVal objApplicationMainWindowViewModel As ApplicationMainWindowViewModel)
        InitializeComponent()
        Me.DataContext = objApplicationMainWindowViewModel
    End Sub

#End Region

#Region " Methods "

    Private Sub ApplicationMainWindowView_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Closed
        Application.Current.Shutdown()
    End Sub

    Private Sub ApplicationMainWindowView_Loaded(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs) Handles Me.Loaded
        SetHyperlinkFloatText()
    End Sub

    Private Sub hlChangePassword_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
        e.Handled = True

        Dim obj As New ChangePasswordDialogView
        obj.DataContext = New ChangePasswordDialogViewModel
        obj.WindowStartupLocation = Windows.WindowStartupLocation.CenterScreen
        obj.ShowInTaskbar = True
        obj.Topmost = Application.IsApplicationTopMost
        obj.ShowDialog()
    End Sub

    Private Sub hlOnTop_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
        e.Handled = True
        _bolIsOnTop = Not _bolIsOnTop
        SetHyperlinkFloatText()
    End Sub

    Private Sub hlViewBlog_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
        e.Handled = True
        Application.StartProcessWithFileName("http://karlshifflett.wordpress.com")
    End Sub

    Private Sub hlViewCodeProjectArticle_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
        e.Handled = True
        Application.StartProcessWithFileName("http://www.codeproject.com/KB/WPF/ExploringWPFMVVM.aspx")
    End Sub

    Private Sub hlViewHowToVideo_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
        e.Handled = True
        Application.StartProcessWithFileName("http://silverlight.services.live.com/invoke/48184/CipherTextHowToVideo/iframe.html")
    End Sub

    Private Sub SetHyperlinkFloatText()

        If _bolIsOnTop Then
            Me.Topmost = True
            Me.tbOnTop.Text = "No Float"
            Me.hlOnTop.ToolTip = "Click to make application no longer float on top of other windows."

        Else
            Me.Topmost = False
            Me.tbOnTop.Text = "Float On Top"
            Me.hlOnTop.ToolTip = "Click to float application on top of other windows."
        End If

    End Sub

#End Region

End Class
