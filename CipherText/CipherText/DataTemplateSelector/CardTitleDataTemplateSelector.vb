
Public Class CardTitleDataTemplateSelector
    Inherits DataTemplateSelector

    Public Overrides Function SelectTemplate(ByVal item As Object, ByVal container As System.Windows.DependencyObject) As System.Windows.DataTemplate

        If TypeOf item Is CardViewModel Then

            If DirectCast(item, CardViewModel).HasPrimaryURL Then
                Return CType(DirectCast(container, System.Windows.Controls.ContentPresenter).FindResource("titleAsHyperlinkDataTemplate"), DataTemplate)

            Else
                Return CType(DirectCast(container, System.Windows.Controls.ContentPresenter).FindResource("titleNoHyperlinkDataTemplate"), DataTemplate)
            End If

        Else
            Return MyBase.SelectTemplate(item, container)
        End If

    End Function

End Class
