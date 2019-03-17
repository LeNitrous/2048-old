Imports osu.Framework.Allocation
Imports osu.Framework.Graphics
Imports osu.Framework.Graphics.Containers
Imports osu.Framework.Screens
Imports Block.Game.Screens.Menu
Imports Block.Game.Overlays
Imports osuTK.Graphics

Public Class Game : Inherits GameBase
    Public Stack As ScreenStack
    Public BackgroundStack As ScreenStack
    Public OverlayContainer As Container

    <BackgroundDependencyLoader>
    Private Sub Load()
        OverlayContainer = New Container With {.RelativeSizeAxes = Axes.Both}
        BackgroundStack = New ScreenStack With {.RelativeSizeAxes = Axes.Both}
        Stack = New ScreenStack With {.RelativeSizeAxes = Axes.Both}
        Dependencies.CacheAs(Me)
        Dependencies.Cache(BackgroundStack)
        Child = New DrawSizePreservingFillContainer With {
            .RelativeSizeAxes = Axes.Both,
            .Children = New List(Of Drawable) From {
                BackgroundStack,
                Stack,
                OverlayContainer
            }
        }
        LoadComponentAsync(New Splash, Sub(s) Stack.Push(s))
    End Sub

    Private Sub UpdateOverlayFade()
        Stack.FadeColour(If(OverlayContainer.Any(), Color4.Black, Color4.White), 300, Easing.OutQuad)
    End Sub

    Public Sub AddOverlay(overlay As Overlay)
        If Not OverlayContainer.Contains(overlay) Then OverlayContainer.Add(overlay)
        UpdateOverlayFade()
    End Sub

    Public Sub RemoveOverlay(overlay As Overlay)
        If OverlayContainer.Contains(overlay) Then OverlayContainer.Remove(overlay)
        UpdateOverlayFade()
    End Sub
End Class
