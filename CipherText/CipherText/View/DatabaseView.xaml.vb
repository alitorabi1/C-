Partial Public Class DatabaseView

    Private Sub FilterText_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Input.KeyEventArgs)

        If e.Key = Key.Escape Then
            e.Handled = True

            Dim obj As DataBaseViewModel = TryCast(Me.DataContext, DataBaseViewModel)

            If obj IsNot Nothing Then
                obj.FilterText = String.Empty
            End If

        End If

    End Sub

    Private Sub ItemsControl_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Input.MouseButtonEventArgs)

        Dim objFrameworkElement As FrameworkElement = TryCast(e.OriginalSource, FrameworkElement)

        If objFrameworkElement IsNot Nothing AndAlso TypeOf objFrameworkElement.DataContext Is CardViewModel Then

            Dim obj As DataBaseViewModel = TryCast(Me.DataContext, DataBaseViewModel)

            If obj IsNot Nothing Then

                Dim objCardViewModel As CardViewModel = TryCast(objFrameworkElement.DataContext, CardViewModel)

                If objCardViewModel IsNot Nothing Then
                    e.Handled = True
                    obj.EditCardCommand.Execute(objCardViewModel.Card)
                End If

            End If

        End If

    End Sub

    Private Sub SearchResult_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Input.KeyEventArgs)

        If e.Key = Key.Enter Then

            Dim obj As DataBaseViewModel = TryCast(Me.DataContext, DataBaseViewModel)

            If obj IsNot Nothing Then

                Dim objCardViewModel As CardViewModel = TryCast(TryCast(sender, Border).DataContext, CardViewModel)

                If objCardViewModel IsNot Nothing Then
                    e.Handled = True
                    obj.EditCardCommand.Execute(objCardViewModel.Card)
                End If

            End If

        End If

    End Sub

End Class
