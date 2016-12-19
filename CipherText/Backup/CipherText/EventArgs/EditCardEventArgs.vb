
Public Class EditCardEventArgs
    Inherits EventArgs

    Private _objCard As Card

    Public Sub New(ByVal objCard As Card)
        _objCard = objCard
    End Sub

    Public ReadOnly Property Card() As Card
        Get
            Return _objCard
        End Get
    End Property

End Class
