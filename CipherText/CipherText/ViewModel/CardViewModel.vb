
Public Class CardViewModel
    Inherits ViewModelBase

#Region " Declarations "

    Private _cmdCopyToClipboardCommand As ICommand
    Private _cmdNavigateCommand As ICommand
    Private _objCard As Card

#End Region

#Region " Properties "

    Public Property Card() As Card
        Get
            Return _objCard
        End Get

        Private Set(ByVal Value As Card)
            _objCard = Value
            OnPropertyChanged("Card")
        End Set
    End Property

    Public ReadOnly Property HasPassword() As Boolean
        Get
            Return Not String.IsNullOrEmpty((From f In Me.Card.CardFields Where f.FieldType = FieldType.PasswordPrimary AndAlso f.FieldData.Trim.Length > 0 Select f.FieldData).FirstOrDefault)
        End Get
    End Property

    Public ReadOnly Property HasPrimaryURL() As Boolean
        Get
            Return Not String.IsNullOrEmpty((From f In Me.Card.CardFields Where f.FieldType = FieldType.URLPrimary AndAlso f.FieldData.Trim.Length > 0 Select f.FieldData).FirstOrDefault)
        End Get
    End Property

    Public ReadOnly Property HasUserName() As Boolean
        Get
            Return Not String.IsNullOrEmpty((From f In Me.Card.CardFields Where f.FieldType = FieldType.UserNamePrimary AndAlso f.FieldData.Trim.Length > 0 Select f.FieldData).FirstOrDefault)
        End Get
    End Property

    Public ReadOnly Property PrimaryPassword() As String
        Get

            Dim strPassword As String = (From f In Me.Card.CardFields Where f.FieldType = FieldType.PasswordPrimary AndAlso f.FieldData.Trim.Length > 0 Select f.FieldData).FirstOrDefault

            If Not String.IsNullOrEmpty(strPassword) Then
                Return strPassword

            Else
                Return String.Empty
            End If

        End Get
    End Property

    Public ReadOnly Property PrimaryURL() As String
        Get

            Dim strURL As String = (From f In Me.Card.CardFields Where f.FieldType = FieldType.URLPrimary AndAlso f.FieldData.Trim.Length > 0 Select f.FieldData).FirstOrDefault

            If strURL Is Nothing Then
                Return String.Empty

            Else
                Return strURL
            End If

        End Get
    End Property

    Public ReadOnly Property PrimaryUserName() As String
        Get

            Dim strUserName As String = (From f In Me.Card.CardFields Where f.FieldType = FieldType.UserNamePrimary AndAlso f.FieldData.Trim.Length > 0 Select f.FieldData).FirstOrDefault

            If Not String.IsNullOrEmpty(strUserName) Then
                Return strUserName

            Else
                Return String.Empty
            End If

        End Get
    End Property

#End Region

#Region " Command Properties "

    Public ReadOnly Property CopyToClipboardCommand() As ICommand
        Get

            If _cmdCopyToClipboardCommand Is Nothing Then
                _cmdCopyToClipboardCommand = New RelayCommand(Of String)(AddressOf CopyToClipboardExecute)
            End If

            Return _cmdCopyToClipboardCommand
        End Get
    End Property

    Public ReadOnly Property NavigateCommand() As ICommand
        Get

            If _cmdNavigateCommand Is Nothing Then
                _cmdNavigateCommand = New RelayCommand(Of String)(AddressOf NavigateExecute)
            End If

            Return _cmdNavigateCommand
        End Get
    End Property

#End Region

#Region " Constructors "

    Public Sub New(ByVal objCard As Card)
        _objCard = objCard
    End Sub

#End Region

#Region " Command Methods "

    Private Sub CopyToClipboardExecute(ByVal strText As String)
        My.Computer.Clipboard.Clear()
        My.Computer.Clipboard.SetText(strText)
    End Sub

    Private Sub NavigateExecute(ByVal strURL As String)

        If Not String.IsNullOrEmpty(strURL) Then
            Application.StartProcessWithFileName(strURL)
        End If

    End Sub

#End Region

#Region " Methods "

    Public Function IsValid() As Boolean
        Return Me.Card.IsValid
    End Function

#End Region

End Class
