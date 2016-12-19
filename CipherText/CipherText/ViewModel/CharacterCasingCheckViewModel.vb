
Public Class CharacterCasingCheckViewModel
    Inherits ViewModelBase

#Region " Declarations "

    Private _cmdDeleteCharacterCasingCheckCommand As ICommand
    Private _objCharacterCasingCheck As CharacterCasingCheck

#End Region

#Region " Properties "

    Public Property CharacterCasingCheck() As CharacterCasingCheck
        Get
            Return _objCharacterCasingCheck
        End Get

        Private Set(ByVal Value As CharacterCasingCheck)
            _objCharacterCasingCheck = Value
            OnPropertyChanged("CharacterCasingCheck")
        End Set
    End Property

#End Region

#Region " Command Properties "

    Public ReadOnly Property DeleteCharacterCasingCheckCommand() As ICommand
        Get
            Return _cmdDeleteCharacterCasingCheckCommand
        End Get
    End Property

#End Region

#Region " Constructors "

    Public Sub New(ByVal cmdDeleteCharacterCasingCheckCommand As ICommand, ByVal objCharacterCasingCheck As CharacterCasingCheck)
        _cmdDeleteCharacterCasingCheckCommand = cmdDeleteCharacterCasingCheckCommand
        _objCharacterCasingCheck = objCharacterCasingCheck
    End Sub

#End Region

End Class
