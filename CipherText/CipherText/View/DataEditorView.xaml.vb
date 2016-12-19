Partial Public Class DataEditorView

#Region " Declarations "

    Private _objDataObject As DataObject

#End Region

#Region " Methods "

    Private Sub lblNotes_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Input.MouseButtonEventArgs) Handles lblNotes.MouseDown
        e.Handled = True

        If e.LeftButton = MouseButtonState.Pressed Then
            _objDataObject = Nothing
        End If

        If Not String.IsNullOrEmpty(Me.txtNotes.Text) Then
            My.Computer.Clipboard.Clear()
            My.Computer.Clipboard.SetText(Me.txtNotes.Text)
        End If

    End Sub

    Private Sub lblNotes_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Input.MouseEventArgs) Handles lblNotes.MouseMove
        e.Handled = True

        If e.LeftButton = MouseButtonState.Released OrElse _objDataObject IsNot Nothing OrElse String.IsNullOrEmpty(Me.txtNotes.Text) Then
            Exit Sub
        End If

        _objDataObject = New DataObject(DataFormats.UnicodeText, Me.txtNotes.Text)
        DragDrop.DoDragDrop(CType(sender, Label), _objDataObject, DragDropEffects.Copy)
    End Sub

    Private Sub lblTitle_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Input.MouseButtonEventArgs) Handles lblTitle.MouseDown
        e.Handled = True

        If e.LeftButton = MouseButtonState.Pressed Then
            _objDataObject = Nothing
        End If

        If Not String.IsNullOrEmpty(Me.txtTitle.Text) Then
            My.Computer.Clipboard.Clear()
            My.Computer.Clipboard.SetText(Me.txtTitle.Text)
        End If

    End Sub

    Private Sub lblTitle_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Input.MouseEventArgs) Handles lblTitle.MouseMove
        e.Handled = True

        If e.LeftButton = MouseButtonState.Released OrElse _objDataObject IsNot Nothing OrElse String.IsNullOrEmpty(Me.txtTitle.Text) Then
            Exit Sub
        End If

        _objDataObject = New DataObject(DataFormats.UnicodeText, Me.txtTitle.Text)
        DragDrop.DoDragDrop(CType(sender, Label), _objDataObject, DragDropEffects.Copy)
    End Sub

    'HACK - Setting Focus To a View field
    'When the View is brought into View, this event handler is called 
    ' by the DataEditorView.Visibility binding and the TargetUpdated attached event 
    Private Sub VisibilityChanged_EventHandler(ByVal sender As System.Object, ByVal e As System.Windows.Data.DataTransferEventArgs)

        e.Handled = True

        If Me.Visibility = Windows.Visibility.Visible Then

            Keyboard.Focus(Me.txtTitle)

        End If

    End Sub

#End Region

End Class
