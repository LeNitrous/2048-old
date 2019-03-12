Imports osu.Framework.Allocation
Imports osu.Framework.Graphics
Imports osu.Framework.Graphics.Containers
Imports osu.Framework.Graphics.Sprites
Imports osuTK
Imports Block.Game.Graphics
Imports Block.Game.Graphics.Shapes

Namespace Screens.Play
    Public MustInherit Class CounterComponent : Inherits CompositeDrawable
        Protected Display As SpriteText
        Protected Title As String

        Public Sub New()
            Size = New Vector2(120, 80)
            Display = New SpriteText With {
                .Anchor = Anchor.Centre,
                .Origin = Anchor.Centre,
                .Text = "",
                .Font = New FontUsage("ClearSans", 48),
                .Y = -5
            }
        End Sub

        <BackgroundDependencyLoader>
        Private Sub Load(ByVal colour As BlockColour)
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
                    .Text = Title.ToUpper(),
                    .Font = New FontUsage("ClearSans", 20, "Bold"),
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
