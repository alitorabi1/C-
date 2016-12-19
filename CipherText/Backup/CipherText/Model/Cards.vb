Imports System.Collections.ObjectModel
'
<Serializable()> Public Class Cards
    Inherits ObservableCollection(Of Card)

#Region " Constructors "

    Public Sub New()
    End Sub

#End Region

#Region " Methods "

    Public Sub Sort()

        'this was writen this way because, we always want the data sorted and stored, ordered by FileAs Ascending.
        'no reason to implement sorting by overriding methods in the base class for this one simple requirement
        If Me.Count > 0 Then

            Dim obj As List(Of Card) = CType(Me.Items, List(Of Card))
            'this uses the default comparer interface that was programmed in the CardField class.  i.e. sorts by FieldSortOrder
            obj.Sort()
            MyBase.OnCollectionChanged(New System.Collections.Specialized.NotifyCollectionChangedEventArgs(Specialized.NotifyCollectionChangedAction.Reset))
        End If

    End Sub

#End Region

End Class
