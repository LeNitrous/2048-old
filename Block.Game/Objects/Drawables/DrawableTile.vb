Imports osu.Framework.Allocation
Imports osu.Framework.Bindables
Imports osu.Framework.Graphics
Imports osu.Framework.Graphics.Containers
Imports osu.Framework.Graphics.Sprites
Imports osuTK
Imports osuTK.Graphics
Imports Block.Game.Graphics
Imports Block.Game.Graphics.Shapes

Namespace Objects.Drawables
    Public Class DrawableTile : Inherits CompositeDrawable
        Public Content As Container

        Private TileObject As Tile
        Private Background As RoundedBox
        Private TextSprite As SpriteText

        <Resolved>
        Private Property BlockColour As BlockColour

        Public Sub New(ByVal tile As Tile)
            TileObject = tile
        End Sub

        <BackgroundDependencyLoader>
        Private Sub Load()
            Size = New Vector2(128)
            Background = New RoundedBox With {
                .RelativeSizeAxes = Axes.Both,
                .Size = New Vector2(0.9),
                .Anchor = Anchor.Centre,
                .Origin = Anchor.Centre
            }
            TextSprite = New SpriteText With {
                .Anchor = Anchor.Centre,
                .Origin = Anchor.Centre,
                .Text = TileObject.Score.Value
            }
            Content = New Container With {
                .RelativeSizeAxes = Axes.Both,
                .Anchor = Anchor.Centre,
                .Origin = Anchor.Centre,
                .Children = New List(Of Drawable) From {
                    Background,
                    TextSprite
                }
            }
            InternalChild = Content

            UpdateTile(TileObject.Score.Value)

            AddHandler TileObject.Score.ValueChanged, AddressOf OnChangeScore
            AddHandler TileObject.Position.ValueChanged, AddressOf OnChangePosition
        End Sub

        Public Sub OnChangeScore(ByVal score As ValueChangedEvent(Of Integer))
            UpdateTile(score.NewValue)
            ClearTransforms()

            Content.Scale = New Vector2(0.6)
            Content.ScaleTo(1, 750, Easing.OutElastic)

            If score.NewValue >= 2048 Then
                Dim ghost As New DrawableTile(TileObject) With {
                    .Alpha = 1,
                    .Scale = New Vector2(0.75)
                }
                ghost.ScaleTo(1.25, 800, Easing.OutCirc)
                ghost.FadeTo(0, 1000, Easing.OutCirc)
                ghost.Expire()
            End If
        End Sub

        Private Sub OnChangePosition(ByVal position As ValueChangedEvent(Of Vector2))
            MoveTo(New Vector2(position.NewValue.X * 128, position.NewValue.Y * 128), 150)

            If TileObject.IsMerged Then
                Expire()
            End If
        End Sub

        Private Sub UpdateTile(ByVal score As Integer)
            With TextSprite
                .Text = score
                .Font = New FontUsage("ClearSans", If(score.ToString().Length < 4, 64, 48), "Bold")
                .Colour = If(score < 8, BlockColour.FromHex("776e65"), BlockColour.FromHex("f9f6f2"))
            End With
            Dim progress = Math.Log(score) / Math.Log(2)
            Background.BackgroundColour = If(progress - 1 >= BlockColour.TileColours.Count,
                BlockColour.TileColours.ElementAt(BlockColour.TileColours.Count - 1), BlockColour.TileColours.ElementAt(progress - 1))
        End Sub

        Public Shared Narrowing Operator CType(ByVal drawable As DrawableTile) As Tile
            Return drawable.TileObject
        End Operator
    End Class
End Namespace
