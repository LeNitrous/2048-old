Imports osu.Framework.Allocation
Imports osu.Framework.Graphics
Imports osu.Framework.Graphics.Containers
Imports Block.Core.Graphics
Imports Block.Core.Graphics.UserInterface

Namespace Screens.Menu
    Public Class MainMenu
        Inherits BlockScreen

        <BackgroundDependencyLoader>
        Private Sub Load(color As BlockColor)
            BackgroundColor = color.FromHex("#faf8ef")
            Content.Children = New List(Of Drawable)({
                New FillFlowContainer With {
                    .FillMode = Axes.Y,
                    .AutoSizeAxes = Axes.Y,
                    .Width = 300,
                    .Anchor = Anchor.Centre,
                    .Origin = Anchor.Centre,
                    .Y = 200,
                    .Children = New List(Of BlockButton)({
                        New BlockButton("Play"),
                        New BlockButton("Exit")
                    })
                }
            })
        End Sub
    End Class
End Namespace
