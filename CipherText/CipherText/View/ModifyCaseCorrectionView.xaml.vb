Imports System.Collections.Specialized
Imports System.Collections.ObjectModel
Partial Public Class ModifyCaseCorrectionView

#Region " Declarations "

    Private WithEvents _objCharacterCasingCheckViewModels As ObservableCollection(Of CharacterCasingCheckViewModel)
    Private WithEvents _objModifyCaseCorrectionViewModel As ModifyCaseCorrectionViewModel

#End Region

#Region " Methods "

    Private Sub _objCharacterCasingCheckViewModels_CollectionChanged(ByVal sender As Object, ByVal e As System.Collections.Specialized.NotifyCollectionChangedEventArgs) Handles _objCharacterCasingCheckViewModels.CollectionChanged

        If e.Action = NotifyCollectionChangedAction.Add Then
            Me.svCharacterCasingCheckViewModels.ScrollToEnd()
        End If

    End Sub

    Private Sub _objModifyCaseCorrectionViewModel_RequestClose(ByVal sender As Object, ByVal e As System.EventArgs) Handles _objModifyCaseCorrectionViewModel.RequestClose
        Me.Close()
    End Sub

    Private Sub ModifyCaseCorrectionView_Loaded(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs) Handles Me.Loaded
        _objModifyCaseCorrectionViewModel = TryCast(Me.DataContext, ModifyCaseCorrectionViewModel)

        If _objModifyCaseCorrectionViewModel IsNot Nothing Then
            _objCharacterCasingCheckViewModels = _objModifyCaseCorrectionViewModel.CharacterCasingCheckViewModels
        End If

    End Sub

#End Region

End Class
