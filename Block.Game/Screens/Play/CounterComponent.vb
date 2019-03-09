Imports osu.Framework.Allocation
Imports osu.Framework.Graphics
Imports osu.Framework.Graphics.Containers
Imports osu.Framework.Graphics.Sprites
Imports osuTK
Imports Block.Game.Graphics
Imports Block.Game.Graphics.Shapes

Namespace Screens.Play
    Public MustInherit Class CounterComponent
        Inherits CompositeDrawable

        Private Display As SpriteText

        Protected Title As String

        <BackgroundDependencyLoader>
        Private Sub Load(ByVal colour As BlockColour)
            Size = New Vector2(100, 60)
            Display = New SpriteText With {
                .Anchor = Anchor.Centre,
                .Origin = Anchor.Centre,
                .Text = "",
                .Font = New FontUsage("OpenSans", 36),
                .Y = -5
            }
            AddRangeInternal(New List(Of Drawable) From {
                New RoundedBox With {
                    .Anchor = Anchor.Centre,
                    .Origin = Anchor.Centre,
                    .RelativeSizeAxes = Axes.Both,
                    .BackgroundColour = colour.FromHex("bbada0")
                },
                New SpriteText With {
                    .Anchor = Anchor.BottomCentre,
                    .Origin = Anchor.BottomCentre,
                    .Y = -5,
                    .Text = Title,
                    .Font = New FontUsage("OpenSans", 14, "Bold"),
                    .Colour = colour.FromHex("eee4da")
                },
                Display
            })

            UpdateDisplayText()
        End Sub

        Protected Sub UpdateDisplayText()
            Display.Text = GetDisplayText()
        End Sub

        Protected MustOverride Function GetDisplayText() As String
    End Class
End Namespace
