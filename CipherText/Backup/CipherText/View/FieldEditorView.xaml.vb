Partial Public Class FieldEditorView


#Region " Declarations "

    Private _objDataObject As DataObject
    Private _objFieldEditorViewModel As FieldEditorViewModel

#End Region

#Region " Methods "

    Private Sub ClearAdorders(ByVal objAdornerLayer As AdornerLayer, ByVal objUIElement As UIElement)

        Dim objAdorder() As Adorner = objAdornerLayer.GetAdorners(objUIElement)

        If objAdorder IsNot Nothing Then

            For Each obj As Adorner In objAdorder
                objAdornerLayer.Remove(obj)
            Next

        End If

    End Sub

    Private Sub FieldEditorView_Loaded(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs) Handles Me.Loaded
        _objFieldEditorViewModel = TryCast(Me.DataContext, FieldEditorViewModel)
    End Sub

    Private Sub FieldEditorView_Unloaded(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs) Handles Me.Unloaded
        _objDataObject = Nothing
        _objFieldEditorViewModel = Nothing
    End Sub

    Private Sub FieldTag_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Input.MouseButtonEventArgs) Handles tbFieldTag.MouseDown
        e.Handled = True

        If e.LeftButton = MouseButtonState.Pressed Then
            _objDataObject = Nothing
        End If

        If _objFieldEditorViewModel Is Nothing Then
            Exit Sub
        End If

        If Not String.IsNullOrEmpty(_objFieldEditorViewModel.CardField.FieldData) Then
            My.Computer.Clipboard.Clear()
            My.Computer.Clipboard.SetText(_objFieldEditorViewModel.CardField.FieldData)
        End If

    End Sub

    Private Sub FieldTag_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Input.MouseEventArgs) Handles tbFieldTag.MouseMove
        e.Handled = True

        If e.LeftButton = MouseButtonState.Released OrElse _objDataObject IsNot Nothing OrElse _objFieldEditorViewModel Is Nothing OrElse String.IsNullOrEmpty(_objFieldEditorViewModel.CardField.FieldData) Then
            Exit Sub
        End If

        _objDataObject = New DataObject(DataFormats.UnicodeText, _objFieldEditorViewModel.CardField.FieldData)
        DragDrop.DoDragDrop(CType(sender, TextBlock), _objDataObject, DragDropEffects.Copy)
    End Sub

    Private Sub OnIsMarkedForDeletetUpdated(ByVal sender As System.Object, ByVal e As System.Windows.Data.DataTransferEventArgs)
        e.Handled = True

        If _objFieldEditorViewModel Is Nothing Then
            Exit Sub
        End If

        If _objFieldEditorViewModel.IsMarkedForDelete Then

            Dim objAdornerLayer As AdornerLayer = AdornerLayer.GetAdornerLayer(Me)

            If objAdornerLayer IsNot Nothing Then
                ClearAdorders(objAdornerLayer, Me.txtFieldData)
                ClearAdorders(objAdornerLayer, Me.txtFieldSortOrder)
                ClearAdorders(objAdornerLayer, Me.txtFieldTag)
                ClearAdorders(objAdornerLayer, Me.txtMaximumLength)
            End If

        End If

    End Sub

#End Region

End Class
