
Public Class CardTypeCommandViewModel
    Inherits ViewModelBase

#Region " Declarations "

    Private _bolIsSelected As Boolean = False
    Private _cmdFilterCommand As ICommand
    Private _cmdNewCommand As ICommand
    Private _objCardType As CardType

#End Region

#Region " Properties "

    Public ReadOnly Property CardType() As CardType
        Get
            Return _objCardType
        End Get
    End Property

    Public Property IsSelected() As Boolean
        Get
            Return _bolIsSelected
        End Get
        Set(ByVal Value As Boolean)
            _bolIsSelected = Value
            OnPropertyChanged("IsSelected")
        End Set
    End Property

#End Region

#Region " Command Properties "

    Public ReadOnly Property FilterCommand() As ICommand
        Get
            Return _cmdFilterCommand
        End Get
    End Property

    Public ReadOnly Property NewCommand() As ICommand
        Get
            Return _cmdNewCommand
        End Get
    End Property

#End Region

#Region " Constructors "

    Public Sub New(ByVal cmdNew As ICommand, ByVal cmdFilter As ICommand, ByVal objCardType As CardType)
        _objCardType = objCardType
        _cmdNewCommand = cmdNew
        _cmdFilterCommand = cmdFilter
    End Sub

#End Region

End Class
