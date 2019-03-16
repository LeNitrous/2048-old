Imports osu.Framework.Allocation
Imports osu.Framework.Testing
Imports osu.Framework.Graphics
Imports osu.Framework.Graphics.Containers
Imports Block.Game.Screens.Play.Drawables
Imports Block.Game.Screens.Play.Objects

Namespace Tests.Visuals.TestCasePlayer
    Public Class TestCaseTile : Inherits TestCase
        Public FlowContainer As FillFlowContainer

        <BackgroundDependencyLoader>
        Private Sub Load()
            FlowContainer = New FillFlowContainer With {
                .RelativeSizeAxes = Axes.Both
            }
            Add(FlowContainer)

            Dim i As Integer = 2
            While i <= 16384
                FlowContainer.Add(New DrawableTile(New Tile(i)))
                i *= 2
            End While
        End Sub
    End Class
End Namespace
