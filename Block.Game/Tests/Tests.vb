Imports osu.Framework.Allocation
Imports osu.Framework.Graphics
Imports osu.Framework.Graphics.Cursor
Imports osu.Framework.Graphics.Containers
Imports osu.Framework.Testing
Imports osu.Framework.Platform

Namespace Tests
    Public Class Tests : Inherits Game
        <BackgroundDependencyLoader>
        Private Sub Load()
            Child = New DrawSizePreservingFillContainer With {
                .Children = New List(Of Drawable)({
                    New TestBrowser("Block"),
                    New CursorContainer()
                })
            }
        End Sub

        Public Overrides Sub SetHost(host As GameHost)
            MyBase.SetHost(host)
            host.Window.CursorState = host.Window.CursorState Or CursorState.Hidden
        End Sub
    End Class
End Namespace
