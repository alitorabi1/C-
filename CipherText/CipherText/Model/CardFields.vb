Imports System.Collections.ObjectModel
'
<Serializable()> Public Class CardFields
    Inherits ObservableCollection(Of CardField)

#Region " Constructors "

    Public Sub New()
    End Sub

#End Region

#Region " Methods "

    Public Function AddEmptyCardField() As CardField

        Dim intSortOrder As Integer = 10

        If Me.Count > 0 Then
            intSortOrder = Me(Me.Count - 1).FieldSortOrder + 10
        End If

        Dim obj As New CardField With {.FieldCase = FieldCase.None, .FieldSortOrder = intSortOrder, .FieldTag = "Change Me", .FieldType = FieldType.Plain, .MaximumLength = 50}
        Me.Add(obj)
        Return obj
    End Function

    Public Function AreCardFieldsValid() As Boolean

        For Each obj As CardField In Me

            If Not obj.IsMarkedForDelete AndAlso Not String.IsNullOrEmpty(obj.Error) Then
                Return False
            End If

        Next

        Return True
    End Function

    Public Sub Sort()

        'this was writen this way because, we always want the data sorted and stored, ordered by FieldSortOrder Ascending.
        'no reason to implement sorting by overriding methods in the base class for this one simple requirement
        If Me.Count > 0 Then

            Dim obj As List(Of CardField) = CType(Me.Items, List(Of CardField))
            'this uses the default comparer interface that was programmed in the CardField class.  i.e. sorts by FieldSortOrder
            obj.Sort()

            Dim intX As Integer = 10

            For Each objField As CardField In obj
                objField.FieldSortOrder = intX
                intX += 10
            Next

            obj = Nothing
            'this is the ObservableCollection method of telling the world the collection changed.
            MyBase.OnCollectionChanged(New System.Collections.Specialized.NotifyCollectionChangedEventArgs(Specialized.NotifyCollectionChangedAction.Reset))
        End If

    End Sub

#End Region

End Class
