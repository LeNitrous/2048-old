Imports osu.Framework.Allocation
Imports osu.Framework.Testing
Imports Block.Game.Screens.Play

Namespace Tests.Visuals.TestCaseComponents
    Public Class TestCaseDisplay : Inherits TestCase
        <BackgroundDependencyLoader>
        Private Sub Load()
            Dim display = New Display With {.Title = "Test Display"}
            display.Value = "Hello World"
            Add(display)
        End Sub
    End Class
End Namespace