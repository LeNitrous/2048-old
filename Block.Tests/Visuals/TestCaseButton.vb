Imports osu.Framework.Allocation
Imports osu.Framework.Testing
Imports osu.Framework.Graphics
Imports osu.Framework.Graphics.Containers
Imports Block.Core.Graphics
Imports Block.Core.Graphics.UserInterface

Namespace Visuals
    Public Class TestCaseButton
        Inherits TestCase

        <BackgroundDependencyLoader>
        Private Sub Load(color As BlockColor)
            Add(New FillFlowContainer With {
                .Anchor = Anchor.Centre,
                .Origin = Anchor.Centre,
                .Width = 300,
                .AutoSizeAxes = Axes.Y,
                .FillMode = Axes.Y,
                .Padding = New MarginPadding With {
                    .Horizontal = 5
                },
                .Children = New List(Of Drawable)({
                    New BlockButton("hello world"),
                    New BlockButton("accept") With {
                        .BackgroundColour = color.PoppinOrange
                    },
                    New BlockButton("deny") With {
                        .BackgroundColour = color.DriedBrown
                    }
                })
            })
        End Sub
    End Class
End Namespace
