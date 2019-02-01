Imports osu.Framework.Graphics
Imports osu.Framework.Graphics.Containers
Imports osu.Framework.Graphics.Shapes
Imports osu.Framework.Graphics.Sprites
Imports osuTK
Imports osuTK.Graphics

Namespace Objects
    Public Class Piece
        Inherits CompositeDrawable

        Public TileX As Integer
        Public TileY As Integer

        Public Value As Integer = 0

        Private ReadOnly box As Box
        Private ReadOnly spriteText As SpriteText

        Public Sub New(ByVal b As Board, ByVal color As Color4)
            Size = New Vector2(b.Tile_Size)

            box = New Box With {
                .RelativeSizeAxes = Axes.Both,
                .Colour = color
            }
            spriteText = New SpriteText With {
                .Anchor = Anchor.Centre,
                .Origin = Anchor.Centre,
                .Text = Value,
                .TextSize = 24
            }

            InternalChildren = New List(Of Drawable)({
                box,
                spriteText
            })
        End Sub

        Private Sub Bounce()
            ScaleTo(1.5, 250, Easing.OutBounce)
            ScaleTo(1, 250, Easing.OutBounce)
        End Sub

        Public Sub Increment()
            Value *= 2
            spriteText.Text = Value

            Bounce()
        End Sub
    End Class
End Namespace
