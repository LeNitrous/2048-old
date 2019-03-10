Imports osu.Framework.Bindables

Namespace Screens.Play
    Public Class MoveCounter
        Inherits CounterComponent

        Public Counter As BindableInt

        Public Sub New(ByVal counter As BindableInt)
            MyBase.New()
            Title = "moves"

            Me.Counter = counter
            AddHandler Me.Counter.ValueChanged, AddressOf Append
        End Sub

        Private Sub Append(ByVal value As ValueChangedEvent(Of Integer))
            UpdateDisplayText()
        End Sub

        Protected Overrides Function GetDisplayText() As String
            Return Counter.Value
        End Function
    End Class
End Namespace
