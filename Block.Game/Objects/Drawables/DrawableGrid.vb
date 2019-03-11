Imports osu.Framework.Allocation
Imports osu.Framework.Graphics
Imports osu.Framework.Graphics.Containers
Imports osuTK
Imports Block.Game.Graphics
Imports Block.Game.Graphics.Shapes

Namespace Objects.Drawables
    Public Class DrawableGrid : Inherits CompositeDrawable
        Private GridObject As Grid
        Private Tiles As Container
        Private Slots As FillFlowContainer

        Public Sub New(ByVal grid As Grid)
            GridObject = grid

            Size = New Vector2(GridObject.Size * 128 + 10)
        End Sub

        <BackgroundDependencyLoader>
        Private Sub Load(ByVal colour As BlockColour)
            Slots = New FillFlowContainer With {
                .RelativeSizeAxes = Axes.Both,
                .Padding = New MarginPadding(5)
            }

            For i = 1 To GridObject.Size ^ 2
                Slots.Add(New Container With {
                    .Size = New Vector2(128),
                    .Child = New RoundedBox With {
                        .BackgroundColour = colour.FromHex("eee4da"),
                        .RelativeSizeAxes = Axes.Both,
                        .Anchor = Anchor.Centre,
                        .Origin = Anchor.Centre,
                        .Scale = New Vector2(0.9),
                        .Alpha = 0.35
                    }
                })
            Next

            Tiles = New Container With {
                .RelativeSizeAxes = Axes.Both,
                .Padding = New MarginPadding(5)
            }
            InternalChildren = New List(Of Drawable) From {
                New RoundedBox With {
                    .BackgroundColour = colour.FromHex("bbada0"),
                    .RelativeSizeAxes = Axes.Both,
                    .Anchor = Anchor.Centre,
                    .Origin = Anchor.Centre
                },
                Slots,
                Tiles
            }

            AddHandler GridObject.TileAdded, AddressOf OnTileCreated
        End Sub

        Private Sub OnTileCreated(ByRef tile As Tile)
            Dim drawableTile As New DrawableTile(tile) With {
                .Position = New Vector2(tile.Position.Value.X * 128,
                                        tile.Position.Value.Y * 128)
            }

            Tiles.Add(drawableTile)

            If tile.From Is Nothing Then
                drawableTile.Content.Scale = New Vector2(0)
                drawableTile.Content.ScaleTo(1, 100, Easing.OutSine)
            End If
        End Sub
    End Class
End Namespace
