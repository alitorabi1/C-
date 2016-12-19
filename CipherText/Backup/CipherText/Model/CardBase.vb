Imports System.ComponentModel
'
<Serializable()> Public MustInherit Class CardBase
    Implements INotifyPropertyChanged
    Implements IDisposable

#Region " Declarations "

    Private _bolDisposedValue As Boolean = False        ' To detect redundant calls

#End Region

#Region " INotifyPropertyChanged Serializable "

    Private Const STR_PROPERTYCHANGEDEVENT As String = "PropertyChangedEvent"
    '
    <NonSerialized()> Private _objNonSerializablePropertyChangedHandlers As New System.ComponentModel.EventHandlerList

    '''' <summary> 
    '''' Raised when a public property of this object is set. 
    '''' </summary> 
    Public Custom Event PropertyChanged As PropertyChangedEventHandler Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged
        AddHandler(ByVal value As PropertyChangedEventHandler)
            Me.NonSerializablePropertyChangedHandlers.AddHandler(STR_PROPERTYCHANGEDEVENT, value)
        End AddHandler
        RemoveHandler(ByVal value As PropertyChangedEventHandler)
            Me.NonSerializablePropertyChangedHandlers.RemoveHandler(STR_PROPERTYCHANGEDEVENT, value)
        End RemoveHandler
        RaiseEvent(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)

            Dim obj As PropertyChangedEventHandler = TryCast(Me.NonSerializablePropertyChangedHandlers(STR_PROPERTYCHANGEDEVENT), PropertyChangedEventHandler)

            If obj IsNot Nothing Then
                obj.Invoke(sender, e)
            End If

        End RaiseEvent
    End Event

    ''' <summary> 
    ''' Raises the PropertyChanged event, and invokes the AfterPropertyChanged method
    ''' </summary> 
    ''' <param name="strPropertyName"> 
    ''' The property which was changed. 
    ''' </param> 
    Protected Sub OnPropertyChanged(ByVal strPropertyName As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(strPropertyName))
    End Sub

    '
    Private ReadOnly Property NonSerializablePropertyChangedHandlers() As System.ComponentModel.EventHandlerList
        Get

            If _objNonSerializablePropertyChangedHandlers Is Nothing Then
                _objNonSerializablePropertyChangedHandlers = New System.ComponentModel.EventHandlerList
            End If

            Return _objNonSerializablePropertyChangedHandlers
        End Get
    End Property

#End Region

#Region " IDisposable Support "

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal bolDisposing As Boolean)

        If Not _bolDisposedValue Then

            If bolDisposing Then
                'This is required when using the EventHandlerList!!
                'This is required when using the EventHandlerList!!
                'This is required when using the EventHandlerList!!
                _objNonSerializablePropertyChangedHandlers.Dispose()
                _objNonSerializablePropertyChangedHandlers = Nothing
                'This is required when using the EventHandlerList!!
                'This is required when using the EventHandlerList!!
                'This is required when using the EventHandlerList!!
            End If

        End If

        _bolDisposedValue = True
    End Sub

#End Region

End Class
