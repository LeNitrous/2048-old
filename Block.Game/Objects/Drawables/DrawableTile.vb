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
    Public Class DrawableTile
        Inherits CompositeDrawable

        Public Content As Container

        Private TileObject As Tile
        Private Background As RoundedBox
        Private TextSprite As SpriteText
        Private Colours As New List(Of Color4)

        Public Sub New(ByVal tile As Tile)
            TileObject = tile
        End Sub

        <BackgroundDependencyLoader>
        Private Sub Load(ByVal colour As BlockColour)
            Colours = colour.TileColours

            Size = New Vector2(128)
            Background = New RoundedBox With {
                .BackgroundColour = GetColour(),
                .RelativeSizeAxes = Axes.Both,
                .Size = New Vector2(0.9),
                .Anchor = Anchor.Centre,
                .Origin = Anchor.Centre
            }
            TextSprite = New SpriteText With {
                .Anchor = Anchor.Centre,
                .Origin = Anchor.Centre,
                .Text = TileObject.Score.Value,
                .Font = New FontUsage("OpenSans", GetFontSize(TileObject.Score.Value))
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

            AddHandler TileObject.Score.ValueChanged, AddressOf OnChangeScore
            AddHandler TileObject.Position.ValueChanged, AddressOf OnChangePosition
        End Sub

        Public Sub OnChangeScore(ByVal score As ValueChangedEvent(Of Integer))
            TextSprite.Text = score.NewValue
            Background.BackgroundColour = GetColour()
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

        Protected Function GetColour() As Color4
            If TileObject.GetProgress() - 1 >= Colours.Count Then
                Return Colours.ElementAt(Colours.Count - 1)
            Else
                Return Colours.ElementAt(TileObject.GetProgress() - 1)
            End If
        End Function

        Protected Function GetFontSize(ByVal score As Integer) As Single
            Select Case score.ToString().Length
                Case 1 To 3
                    Return 64
                Case Else
                    Return 48
            End Select
        End Function

        Public Shared Narrowing Operator CType(ByVal drawable As DrawableTile) As Tile
            Return drawable.TileObject
        End Operator
    End Class
End Namespace
