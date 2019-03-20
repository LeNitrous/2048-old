Imports osu.Framework.Allocation
Imports osu.Framework.Graphics
Imports osu.Framework.Graphics.Containers
Imports osu.Framework.Screens
Imports Block.Game.Screens.Menu

Public Class Game : Inherits GameBase
    Private Stack As ScreenStack
    Private BackgroundStack As ScreenStack

    <BackgroundDependencyLoader>
    Private Sub Load()
        Stack = New ScreenStack With {.RelativeSizeAxes = Axes.Both}
        BackgroundStack = New ScreenStack With {.RelativeSizeAxes = Axes.Both}

        Dependencies.CacheAs(Me)
        Dependencies.Cache(BackgroundStack)

        Child = New DrawSizePreservingFillContainer With {
            .RelativeSizeAxes = Axes.Both,
            .Children = New List(Of Drawable) From {
                BackgroundStack,
                Stack
            }
        }
        LoadComponentAsync(New Splash, Sub(s) Stack.Push(s))
    End Sub
End Class
