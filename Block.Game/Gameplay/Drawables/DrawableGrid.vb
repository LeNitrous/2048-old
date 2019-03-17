Imports osu.Framework.Allocation
Imports osu.Framework.Graphics
Imports osu.Framework.Graphics.Containers
Imports osu.Framework.Input.Bindings
Imports osuTK
Imports Block.Game.Gameplay.Managers
Imports Block.Game.Gameplay.Objects
Imports Block.Game.Graphics
Imports Block.Game.Graphics.Shapes

Namespace Gameplay.Drawables
    Public Class DrawableGrid : Inherits Container : Implements IKeyBindingHandler(Of MoveDirection)
        Private Manager As GridManager
        Private Tiles As Container

        <Resolved>
        Private Property Colours As Colours

        Public Property Area As Single
            Set(value As Single)
                Scale = New Vector2(value / Width)
            End Set
            Get
                Return Width
            End Get
        End Property

        Public Sub New(manager As GridManager)
            Me.Manager = manager
            Size = New Vector2(manager.Grid.Size * 128 + 10)
            Scale = New Vector2(528 / Size.X)
        End Sub

        <BackgroundDependencyLoader>
        Private Sub Load()
            Dim Slots = CreateTileSlots()
            Tiles = New Container With {
                .RelativeSizeAxes = Axes.Both,
                .Padding = New MarginPadding(5)
            }
            Children = New List(Of Drawable) From {
                New RoundedBox With {
                    .Colour = Colours.LighterBrown,
                    .RelativeSizeAxes = Axes.Both,
                    .Anchor = Anchor.Centre,
                    .Origin = Anchor.Centre
                },
                Slots,
                Tiles
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
                    .Child = New RoundedBox With {
                        .RelativeSizeAxes = Axes.Both,
                        .Scale = New Vector2(0.9),
                        .Anchor = Anchor.Centre,
                        .Origin = Anchor.Centre,
                        .Colour = Colours.FromHex("eee4da"),
                        .Alpha = 0.35
                    }
                })
            Next
            Return slots
        End Function

        Private Sub OnTileCreated(tile As Tile)
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
            Return True
        End Function
    End Class
End Namespace
