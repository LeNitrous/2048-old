Imports osu.Framework.Allocation
Imports osu.Framework.Graphics
Imports osu.Framework.Graphics.Containers
Imports osu.Framework.Graphics.Shapes
Imports osu.Framework.Graphics.Sprites
Imports osuTK
Imports osuTK.Graphics
Imports Block.Core.Graphics

Namespace Objects.Drawables
    Public Class DrawableTile
        Inherits CompositeDrawable

        Private ReadOnly TileObject As Tile
        Private TileBox As Box
        Private TileText As SpriteText
        Private Ghost As New Container
        Private GhostBox As Box
        Private GhostText As SpriteText
        Private Colors As New List(Of Color4)

        Public Sub New(ByVal tile As Tile)
            Size = New Vector2(128)
            Origin = Anchor.Centre
            TileObject = tile
            TileBox = CreateBox()
            TileText = CreateSpriteText()
            GhostBox = CreateBox()
            GhostText = CreateSpriteText()
            Ghost = CreateTile(GhostBox, GhostText)
            Ghost.Alpha = 0
            InternalChildren = New List(Of Drawable)({
                CreateTile(TileBox, TileText),
                Ghost
            })

            TileObject.Score.BindValueChanged(AddressOf OnChangeScore)
            TileObject.Position.BindValueChanged(AddressOf OnChangePosition)
        End Sub

        <BackgroundDependencyLoader>
        Private Sub Load(ByVal color As BlockColor)
            Colors = New List(Of Color4) From {
                color.FromHex("f3d774"),
                color.FromHex("f3d774"),
                color.FromHex("f2b179"),
                color.FromHex("f59563"),
                color.FromHex("f67c5f"),
                color.FromHex("f65e3b"),
                color.FromHex("edcf72"),
                color.FromHex("edcc61"),
                color.FromHex("edc850"),
                color.FromHex("edc53f"),
                color.FromHex("edc22e"),
                color.FromHex("3c3a32")
            }
            TileBox.Colour = GetColor()
            GhostBox.Colour = GetColor()

            If TileObject.From Is Nothing Then
                Grow()
            End If
        End Sub

        Public Sub Grow()
            Scale = New Vector2(0)
            ScaleTo(1, 100, Easing.InSine)
        End Sub

        Protected Function GetColor() As Color4
            If TileObject.GetProgress() - 1 > Colors.Count Then
                Return Colors.ElementAt(Colors.Count - 1)
            Else
                Return Colors.ElementAt(TileObject.GetProgress() - 1)
            End If
        End Function

        Protected Function CreateBox() As Box
            Return New Box With {
                .RelativeSizeAxes = Axes.Both
            }
        End Function

        Protected Function CreateSpriteText() As SpriteText
            Return New SpriteText With {
                .Anchor = Anchor.Centre,
                .Origin = Anchor.Centre,
                .Text = TileObject.Score.Value,
                .TextSize = 64 * 0.9
            }
        End Function

        Protected Function CreateTile(ByVal box As Box, ByVal text As SpriteText) As Container
            Return New Container With {
                .RelativeSizeAxes = Axes.Both,
                .Anchor = Anchor.Centre,
                .Origin = Anchor.Centre,
                .CornerRadius = 5,
                .Masking = True,
                .Size = New Vector2(0.9),
                .Children = New List(Of Drawable)({
                    box,
                    text
                })
            }
        End Function

        Private Sub OnChangeScore(newScore As Integer)
            TileText.Text = newScore
            TileBox.Colour = GetColor()
            ClearTransforms()
            Scale = New Vector2(0.6)
            ScaleTo(1, 750, Easing.OutElastic)
            If newScore >= 2048 Then
                Ghost.ClearTransforms()
                GhostText.Text = newScore
                GhostBox.Colour = GetColor()
                Ghost.Alpha = 1
                Ghost.Scale = New Vector2(0.75)
                Ghost.ScaleTo(1.25, 800, Easing.OutCirc)
                Ghost.FadeTo(0, 1000, Easing.OutCirc)
            End If
        End Sub

        Private Sub OnChangePosition(newVector As Vector2)
            Dim row = newVector.X
            Dim col = newVector.Y
            MoveTo(New Vector2(row * Size.X + (Size.X / 2), col * Size.X + (Size.X / 2)), 150)
            If TileObject.IsMerged Then
                Expire()
            End If
        End Sub

        Public Shared Narrowing Operator CType(ByVal drawable As DrawableTile) As Tile
            Return drawable.TileObject
        End Operator
    End Class
End Namespace
