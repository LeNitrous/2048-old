Imports osu.Framework.Allocation
Imports osu.Framework.Graphics
Imports osu.Framework.Testing
Imports Block.Game.Screens.Menu

Namespace Tests.Visuals.TestCaseComponents
    Public Class TestCaseMenuButton : Inherits TestCase
        <BackgroundDependencyLoader>
        Private Sub Load()
            Add(New MenuButton With {
                .Anchor = Anchor.Centre,
                .Origin = Anchor.Centre,
                .Texture = "exit"
            })
        End Sub
    End Class
End Namespace
