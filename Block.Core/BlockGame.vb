Imports osu.Framework
Imports osu.Framework.Allocation
Imports osu.Framework.Graphics
Imports osu.Framework.Screens
Imports Block.Core.Graphics
Imports Block.Core.Screens.Menu

Public Class BlockGame
    Inherits Game

    Private Dependencies As DependencyContainer

    Protected Overrides Function CreateChildDependencies(parent As IReadOnlyDependencyContainer) As IReadOnlyDependencyContainer
        Dependencies = New DependencyContainer(MyBase.CreateChildDependencies(parent))
        Return Dependencies
    End Function

    <BackgroundDependencyLoader>
    Private Sub Load()
        Dependencies.Cache(New BlockColor())

        Add(New ScreenStack(New MainMenu) With {
            .RelativeSizeAxes = Axes.Both
        })
    End Sub
End Class
