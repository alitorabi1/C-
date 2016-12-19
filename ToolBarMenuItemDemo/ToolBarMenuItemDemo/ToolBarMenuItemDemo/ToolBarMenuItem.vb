Imports System.Windows.Controls.Primitives

Public Class ToolBarMenuItem
    Inherits System.Windows.Controls.MenuItem

    Shared Sub New()
        'This OverrideMetadata call tells the system that this element wants to provide a style that is different than its base class.
        'This style is defined in themes\generic.xaml
        DefaultStyleKeyProperty.OverrideMetadata(GetType(ToolBarMenuItem), New FrameworkPropertyMetadata(GetType(ToolBarMenuItem)))
    End Sub

    Public Enum PlacementMode
        Bottom = 0
        Top = 1
        Right = 2
        Left = 3
    End Enum

    Public Shared ReadOnly SubMenuPlacementModeProperty As DependencyProperty = DependencyProperty.Register("SubMenuPlacementMode", GetType(PlacementMode), GetType(ToolBarMenuItem), New FrameworkPropertyMetadata(PlacementMode.Bottom))
    Public Property SubMenuPlacementMode As PlacementMode
        Get
            Return GetValue(SubMenuPlacementModeProperty)
        End Get
        Set(ByVal value As PlacementMode)
            SetValue(SubMenuPlacementModeProperty, value)
        End Set
    End Property

    Private Sub ToolBarMenuItem_Click(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs) Handles Me.Click
        Me.IsSubmenuOpen = False
    End Sub

    Private Sub ToolBarMenuItem_MouseLeave(ByVal sender As Object, ByVal e As System.Windows.Input.MouseEventArgs) Handles Me.MouseLeave
        Me.IsSubmenuOpen = False
    End Sub

    Private Sub ToolBarMenuItem_PreviewMouseLeftButtonDown(ByVal sender As Object, ByVal e As System.Windows.Input.MouseButtonEventArgs) Handles Me.PreviewMouseLeftButtonDown
        If Me.IsSubmenuOpen = False Then
            Me.IsSubmenuOpen = True
            Me.StaysOpenOnClick = False
        End If
    End Sub
End Class
