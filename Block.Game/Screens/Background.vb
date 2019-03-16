Imports osu.Framework.Allocation
Imports osu.Framework.Graphics
Imports osu.Framework.Graphics.Shapes
Imports osu.Framework.Graphics.Sprites
Imports osu.Framework.Graphics.Textures
Imports Block.Game.Graphics
Imports osuTK

Namespace Screens
    Public Class Background : Inherits osu.Framework.Screens.Screen
        <BackgroundDependencyLoader>
        Private Sub Load(Colours As Colours, Store As TextureStore)
            InternalChildren = New List(Of Drawable) From {
                New Box With {
                    .RelativeSizeAxes = Axes.Both,
                    .Colour = Colours.LightestBrown
                },
                New Sprite With {
                    .Texture = Store.Get("logo-notext"),
                    .Scale = New Vector2(2),
                    .Alpha = 0.1,
                    .Colour = Colours.DarkestBrown,
                    .Anchor = Anchor.Centre,
                    .Origin = Anchor.Centre
                }
            }
        End Sub
    End Class
End Namespace
