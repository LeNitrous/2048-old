Imports osu.Framework.Allocation
Imports osu.Framework.Bindables
Imports osu.Framework.Graphics
Imports osu.Framework.Graphics.Containers
Imports osu.Framework.Graphics.Sprites
Imports Block.Game.Graphics
Imports Block.Game.Graphics.Shapes
Imports osuTK

Namespace Screens.Play
    Public Class Display : Inherits Container
        Public Title As String
        Public Property Value As String
            Get
                Return Display.Text
            End Get
            Set(value As String)
                Display.Text = value
            End Set
        End Property
        Public Property FixedWidth As Boolean
            Get
                Return Display.Font.FixedWidth
            End Get
            Set(value As Boolean)
                Display.Font = Display.Font.With(fixedWidth:=value)
            End Set
        End Property
        Private Display As SpriteText

        Public Sub New()
            Size = New Vector2(120, 80)
            Display = New SpriteText With {
                .Anchor = Anchor.Centre,
                .Origin = Anchor.Centre,
                .Font = New FontUsage("ClearSans", 48),
                .Y = -3
            }
        End Sub

        <BackgroundDependencyLoader>
        Private Sub Load(colours As Colours)
            Children = New List(Of Drawable) From {
                New RoundedBox With {
                    .RelativeSizeAxes = Axes.Both,
                    .Colour = colours.LighterBrown
                },
                Display,
                New SpriteText With {
                    .Anchor = Anchor.BottomCentre,
                    .Origin = Anchor.BottomCentre,
                    .Colour = colours.LightestBrown,
                    .Alpha = 0.5,
                    .Font = New FontUsage("ClearSans", 14, "Bold"),
                    .Text = Title.ToUpper(),
                    .Y = -5
                }
            }
        End Sub
    End Class
End Namespace
