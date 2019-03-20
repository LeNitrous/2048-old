Imports osu.Framework.Allocation
Imports osu.Framework.Testing
Imports Block.Game.Screens.Play

Namespace Tests.Visuals.TestCaseComponents
    Public Class TestCaseCountdown : Inherits TestCase
        <BackgroundDependencyLoader>
        Private Sub Load()
            Dim display = New Countdown(3000)
            Add(display)
            AddStep("start", Sub() display.Start())
        End Sub
    End Class
End Namespace