Imports osu.Framework.Graphics
Imports osu.Framework.Graphics.Containers
Imports osu.Framework.Graphics.Shapes
Imports osuTK
Imports osuTK.Graphics

Namespace Objects
    Public Class Board
        Inherits CompositeDrawable

        Public ReadOnly Tile_Size As Integer = 128
        Public ReadOnly Tile_Margin As Integer = 5
        Public ReadOnly Board_Padding As Integer = 5

        Private Dimensions As Integer
        Private Map As Piece(,)

        Private tileContainer As FillFlowContainer

        Public Sub New(Optional ByVal tiles As Integer = 3)
            Resize(tiles)
        End Sub

        Public Sub Move(ByVal direction As MoveDirection)
            Select Case direction
                Case MoveDirection.Up

                Case MoveDirection.Down

                Case MoveDirection.Left

                Case MoveDirection.Right

                Case Else
                    Throw New NotSupportedException("Performed an invalid move.")
            End Select
        End Sub

        Public Sub Resize(ByVal tiles As Integer)
            Dimensions = tiles
            Size = New Vector2((Board_Padding * 2) + ((Tile_Size + (Tile_Margin * 2)) * Dimensions))

            ReDim Map(Dimensions, Dimensions)

            tileContainer = New FillFlowContainer With {
                .RelativeSizeAxes = Axes.Both,
                .Padding = New MarginPadding(Board_Padding),
                .Direction = FillDirection.Full
            }

            InternalChildren = New List(Of Drawable)({
                New Box With {
                    .RelativeSizeAxes = Axes.Both,
                    .Colour = Color4.DarkGray
                },
                tileContainer
            })

            For index = 1 To Dimensions * Dimensions
                tileContainer.Add(New Box With {
                    .Colour = Color4.LightGray,
                    .Size = New Vector2(Tile_Size),
                    .Margin = New MarginPadding(Tile_Margin)
                })
            Next
        End Sub

        Private Sub AddTile(ByVal position As Vector2)

        End Sub

        Private Sub RemoveTile(ByVal position As Vector2)

        End Sub

        Private Sub MoveTile(ByVal fromPos As Vector2, ByVal toPos As Vector2)

        End Sub
    End Class
End Namespace
