Namespace Screens.Play
    Public Class TimerCounter : Inherits CounterComponent

        Private ReadOnly Watch As Stopwatch

        Public Sub New(ByVal watch As Stopwatch)
            Title = "elapsed"
            Me.Watch = watch
        End Sub

        Protected Overrides Sub Update()
            If Watch.IsRunning Then
                UpdateDisplayText()
            End If
            MyBase.Update()
        End Sub

        Protected Overrides Function GetDisplayText() As String
            Dim formatted = TimeSpan.FromMilliseconds(Watch.ElapsedMilliseconds)
            Return String.Format("{0}:{1}", formatted.Minutes.ToString().PadLeft(2, "0"), formatted.Seconds.ToString().PadLeft(2, "0"))
        End Function
    End Class
End Namespace
