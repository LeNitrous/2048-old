Imports osu.Framework.Allocation
Imports osu.Framework.Graphics
Imports osu.Framework.Graphics.Containers
Imports osu.Framework.Graphics.Shapes
Imports osu.Framework.Input.Bindings
Imports osuTK
Imports Block.Game.Graphics
Imports Block.Game.Objects.Managers

Namespace Objects.Drawables
    Public Class DrawableGrid : Inherits Container : Implements IKeyBindingHandler(Of MoveDirection)
        Private Manager As GridManager
        Private Tiles As Container

        <Resolved>
        Private Property Colours As BlockColour

        Public Property GridAreaSize As Single
            Set(value As Single)
                Scale = New Vector2(value / Size.X)
            End Set
            Get
                Return Width
            End Get
        End Property

        Public Sub New(ByVal manager As GridManager)
            Me.Manager = manager
            Size = New Vector2(manager.Grid.Size * 128 + 10)
            Scale = New Vector2(528 / Size.X)
        End Sub

        <BackgroundDependencyLoader>
        Private Sub Load()
            Masking = True
            CornerRadius = 5
            Tiles = New Container With {
                .RelativeSizeAxes = Axes.Both,
                .Padding = New MarginPadding(5)
            }
            Child = New GridInputContainer With {
                .RelativeSizeAxes = Axes.Both,
                .Children = New List(Of Drawable) From {
                    New Box With {
                        .Colour = Colours.FromHex("bbada0"),
                        .RelativeSizeAxes = Axes.Both,
                        .Anchor = Anchor.Centre,
                        .Origin = Anchor.Centre
                    },
                    CreateTileSlots(),
                    Tiles
                }
            }

            AddHandler Manager.Grid.TileAdded, AddressOf OnTileCreated
        End Sub

        Private Function CreateTileSlots() As FillFlowContainer
            Dim slots = New FillFlowContainer With {
                .RelativeSizeAxes = Axes.Both,
                .Padding = New MarginPadding(5)
            }
            For i = 1 To Manager.Grid.Size ^ 2
                slots.Add(New Container With {
                    .Size = New Vector2(128),
                    .Child = New Container With {
                        .RelativeSizeAxes = Axes.Both,
                        .CornerRadius = 5,
                        .Masking = True,
                        .Scale = New Vector2(0.9),
                        .Anchor = Anchor.Centre,
                        .Origin = Anchor.Centre,
                        .Child = New Box With {
                            .Colour = Colours.FromHex("eee4da"),
                            .Alpha = 0.35,
                            .RelativeSizeAxes = Axes.Both
                        }
                    }
                })
            Next
            Return slots
        End Function

        Private Sub OnTileCreated(ByRef tile As Tile)
            Dim drawableTile As New DrawableTile(tile)
            Tiles.Add(drawableTile)
            If tile.From Is Nothing Then
                drawableTile.Grow()
            End If
        End Sub

        Public Function OnPressed(action As MoveDirection) As Boolean Implements IKeyBindingHandler(Of MoveDirection).OnPressed
            Manager.Move(action)
            Return True
        End Function

        Public Function OnReleased(action As MoveDirection) As Boolean Implements IKeyBindingHandler(Of MoveDirection).OnReleased
            Return False
        End Function
    End Class
End Namespace
