﻿Imports osu.Framework.Allocation
Imports osu.Framework.Bindables
Imports osu.Framework.Graphics
Imports osu.Framework.Graphics.Containers
Imports osu.Framework.Graphics.Sprites
Imports osuTK
Imports osuTK.Graphics
Imports Block.Game.Graphics
Imports Block.Game.Graphics.Shapes

Namespace Objects.Drawables
    Public Class DrawableTile : Inherits Container
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
            Position = Vector2.Multiply(TileObject.Position.Value, 128)
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
            Child = New Container With {
                .Anchor = Anchor.Centre,
                .Origin = Anchor.Centre,
                .RelativeSizeAxes = Axes.Both,
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

        Private Sub OnChangeScore(ByVal score As ValueChangedEvent(Of Integer))
            UpdateTile(score.NewValue)
            ClearTransforms()

            Child.Scale = New Vector2(0.6)
            Child.ScaleTo(1, 750, Easing.OutElastic)
        End Sub

        Private Sub OnChangePosition(ByVal position As ValueChangedEvent(Of Vector2))
            MoveTo(Vector2.Multiply(position.NewValue, 64), 150)

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
