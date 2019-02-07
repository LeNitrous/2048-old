Imports osu.Framework.Allocation
Imports osu.Framework.Graphics
Imports osu.Framework.Graphics.Containers
Imports osu.Framework.Graphics.Shapes
Imports osuTK
Imports osuTK.Graphics
Imports Block.Core.Graphics
Imports Block.Core.Graphics.Shapes

Namespace Objects.Drawables
    Public Class DrawableGrid
        Inherits CompositeDrawable

        Private ReadOnly GridObject As Grid
        Private ReadOnly TileContainer As Container = CreateTileContainer()
        Private GridSlots As FillFlowContainer

        Public Sub New(ByVal grid As Grid)
            GridObject = grid

            Size = New Vector2(GridObject.Size * 128 + 10)
            Anchor = Anchor.Centre
            Origin = Anchor.Centre

            AddHandler GridObject.TileAdded, AddressOf OnTileCreated
        End Sub

        <BackgroundDependencyLoader>
        Private Sub Load(ByVal color As BlockColor)
            GridSlots = CreateGridSlots(color.FromHex("eee4da"))
            InternalChildren = New List(Of Drawable)({
                New BeveledBox(color.FromHex("bbada0"), color.FromHex("93857a")) With {
                    .RelativeSizeAxes = Axes.Both
                },
                GridSlots,
                TileContainer
            })
        End Sub

        Private Sub OnTileCreated(ByRef tile As Tile)
            Dim newDrawableTile As New DrawableTile(tile) With {
                .Position = New Vector2(tile.Position.Value.X * 128 + (128 / 2), tile.Position.Value.Y * 128 + (128 / 2))
            }
            TileContainer.Add(newDrawableTile)
        End Sub

        Protected Function CreateGridSlots(ByVal slotColor As Color4) As FillFlowContainer
            Dim container = New FillFlowContainer With {
                .RelativeSizeAxes = Axes.Both,
                .Padding = New MarginPadding(5)
            }
            For i = 1 To GridObject.Size * GridObject.Size
                container.Add(New Container With {
                    .Size = New Vector2(128),
                    .Child = New Container With {
                        .RelativeSizeAxes = Axes.Both,
                        .Anchor = Anchor.Centre,
                        .Origin = Anchor.Centre,
                        .CornerRadius = 5,
                        .Masking = True,
                        .Scale = New Vector2(0.9),
                        .Child = New Box With {
                            .RelativeSizeAxes = Axes.Both,
                            .Colour = slotColor,
                            .Alpha = 0.35
                        }
                    }
                })
            Next
            Return container
        End Function

        Protected Function CreateTileContainer() As Container
            Return New Container With {
                .RelativeSizeAxes = Axes.Both,
                .Padding = New MarginPadding(5)
            }
        End Function

        Public Shared Narrowing Operator CType(ByVal drawable As DrawableGrid) As Grid
            Return drawable.GridObject
        End Operator
    End Class
End Namespace
