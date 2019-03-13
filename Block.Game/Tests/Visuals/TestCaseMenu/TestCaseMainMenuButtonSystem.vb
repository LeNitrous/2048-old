Imports osu.Framework.Allocation
Imports osu.Framework.Bindables
Imports osu.Framework.Graphics
Imports osu.Framework.Graphics.Sprites
Imports osu.Framework.Testing
Imports osuTK
Imports Block.Game.Screens.Menu

Namespace Tests.Visuals.TestCaseMenu
    Public Class TestCaseMainMenuButtonSystem : Inherits TestCase
        <BackgroundDependencyLoader>
        Private Sub Load()
            Add(New ButtonSystem)
        End Sub
    End Class
End Namespace
