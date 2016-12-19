Imports System.ComponentModel

Public MustInherit Class ViewModelBase
    Implements INotifyPropertyChanged

#Region " Events "

    Public Event PropertyChanged As PropertyChangedEventHandler Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged

#End Region

#Region " Constructor "

    Public Sub New()
    End Sub

#End Region

#Region " Methods "

    Protected Sub OnPropertyChanged(ByVal strPropertyName As String)

        Dim handler As PropertyChangedEventHandler = Me.PropertyChangedEvent

        If handler IsNot Nothing Then
            handler.Invoke(Me, New PropertyChangedEventArgs(strPropertyName))
        End If

    End Sub

#End Region

End Class
