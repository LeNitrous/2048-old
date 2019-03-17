Imports osu.Framework.Allocation
Imports osu.Framework.Graphics
Imports osu.Framework.Graphics.Containers
Imports osu.Framework.Graphics.Sprites
Imports osu.Framework.Graphics.Textures
Imports Block.Game.Graphics.Shapes
Imports osuTK

Namespace Graphics.UserInterface
    Public Class Header : Inherits Container
        Public Property Text As String
            Get
                Return TextSprite.Text
            End Get
            Set(value As String)
                TextSprite.Text = value
            End Set
        End Property
        Public Icon As String
        Private TextSprite As SpriteText

        Public Sub New()
            AutoSizeAxes = Axes.Both
            TextSprite = New SpriteText With {
                .Anchor = Anchor.Centre,
                .Origin = Anchor.Centre,
                .Font = New FontUsage("ClearSans", 64, "Bold"),
                .Position = New Vector2(20, -3)
            }
        End Sub

        <BackgroundDependencyLoader>
        Private Sub Load(colours As Colours, store As TextureStore)
            Children = New List(Of Drawable) From {
                New RoundedBox With {
                    .Size = New Vector2(75),
                    .Colour = colours.LighterBrown,
                    .Rotation = 45,
                    .Position = New Vector2(50, -3)
                },
                New RoundedBox With {
                    .Size = New Vector2(300, 105),
                    .Colour = colours.LighterBrown,
                    .Position = New Vector2(47, -3)
                },
                New Sprite With {
                    .Size = New Vector2(60),
                    .Anchor = Anchor.CentreLeft,
                    .Origin = Anchor.CentreLeft,
                    .X = 25,
                    .Texture = store.Get("Interface/" & Icon)
                },
                TextSprite
            }
        End Sub
    End Class
End Namespace
