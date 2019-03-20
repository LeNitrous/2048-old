Imports osu.Framework.Allocation
Imports osu.Framework.Bindables
Imports osu.Framework.Graphics
Imports osu.Framework.Graphics.Containers
Imports osu.Framework.Graphics.Sprites
Imports Block.Game.Gameplay.Objects
Imports Block.Game.Graphics
Imports Block.Game.Graphics.Shapes
Imports osuTK

Namespace Gameplay.Drawables
    Public Class DrawableTile : Inherits Container
        Public TileObject As Tile
        Private Background As RoundedBox
        Private TextSprite As SpriteText

        <Resolved>
        Private Property Colours As Colours

        Public Sub New(tile As Tile)
            TileObject = tile
        End Sub

        <BackgroundDependencyLoader>
        Private Sub Load()
            Size = New Vector2(128)
            Position = Vector2.Multiply(TileObject.Position.Value, 128)
            Background = New RoundedBox With {
                .RelativeSizeAxes = Axes.Both,
                .Anchor = Anchor.Centre,
                .Origin = Anchor.Centre
            }
            TextSprite = New SpriteText With {
                .Anchor = Anchor.Centre,
                .Origin = Anchor.Centre,
                .Text = TileObject.Score.Value
            }
            Child = New Container With {
                .Anchor = Anchor.Centre,
                .Origin = Anchor.Centre,
                .CornerRadius = 5,
                .Masking = True,
                .RelativeSizeAxes = Axes.Both,
                .Size = New Vector2(0.9),
                .Children = New List(Of Drawable) From {
                    Background,
                    TextSprite
                }
            }
            UpdateTile(TileObject.Score.Value)
            AddHandler TileObject.Score.ValueChanged, AddressOf OnChangeScore
            AddHandler TileObject.Position.ValueChanged, AddressOf OnChangePosition
        End Sub

        Public Sub Grow()
            Child.Scale = New Vector2(0)
            Child.ScaleTo(1, 100, Easing.OutSine)
        End Sub

        Public Sub Shrink()
            Child.ScaleTo(0, 300, Easing.OutQuad)
            Delay(300).Expire()
        End Sub

        Public Sub Glow()
            Dim glow As New EdgeEffectParameters With {
                .Colour = Background.Colour,
                .Hollow = True,
                .Radius = 25,
                .Type = EdgeEffectType.Glow
            }
            Dim c As Container = Child
            c.EdgeEffect = glow
            c.Delay(1000).FadeEdgeEffectTo(0, 500, Easing.Out)
        End Sub

        Public Sub Drop()
            Dim random = New Random()
            Dim speed = random.Next(1000, 2000)
            Child.MoveToOffset(New Vector2(0, 100), speed, Easing.Out) _
                .ScaleTo(0, speed * 4, Easing.Out) _
                .FadeOut(speed, Easing.Out)
            Delay(speed * 2).Expire()
        End Sub

        Private Sub OnChangeScore(score As ValueChangedEvent(Of Integer))
            UpdateTile(score.NewValue)
            ClearTransforms()
            Child.Scale = New Vector2(0.6)
            Child.ScaleTo(1, 750, Easing.OutElastic)
            If TileObject.Score.Value >= 2048 Then Glow()
        End Sub

        Private Sub OnChangePosition(position As ValueChangedEvent(Of Vector2))
            MoveTo(Vector2.Multiply(position.NewValue, 128), 150)
            If TileObject.IsMerged Then
                Expire()
            End If
        End Sub

        Private Sub UpdateTile(score As Integer)
            With TextSprite
                .Text = score
                .Font = New FontUsage("ClearSans", If(score.ToString().Length < 4, 64, 48), "Bold")
                .Colour = If(score < 8, Colours.FromHex("776e65"), Colours.FromHex("f9f6f2"))
            End With
            Dim progress = (Math.Log(score) / Math.Log(2)) - 1
            Background.Colour = If(progress < Colours.Tile.Count, Colours.Tile.ElementAt(progress), Colours.Tile.Last())
        End Sub

        Public Shared Narrowing Operator CType(drawable As DrawableTile) As Tile
            Return drawable.TileObject
        End Operator
    End Class
End Namespace
