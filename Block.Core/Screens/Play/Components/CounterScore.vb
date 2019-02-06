Imports osu.Framework.Configuration
Imports osu.Framework.Graphics
Imports osu.Framework.Graphics.Sprites
Imports osuTK

Namespace Screens.Play.Components
    Public Class CounterScore
        Inherits Counter

        Private PreviousValue As Integer = 0

        Public Sub New(ByVal bindable As BindableInt)
            MyBase.New("Score", bindable)

            AddHandler CounterBindable.ValueChanged, AddressOf CreateNumberSprite
        End Sub

        Private Sub CreateNumberSprite(ByVal newValue As Integer)
            Dim numberSprite As New SpriteText With {
                .Anchor = Anchor.Centre,
                .Origin = Anchor.Centre,
                .Position = New Vector2(-20, -20),
                .Text = "+" & (newValue - PreviousValue),
                .TextSize = 24,
                .Font = "OpenSans-Bold"
            }
            AddInternal(numberSprite)
            numberSprite.FadeOutFromOne(1000).MoveToOffset(New Vector2(0, -20), 1000).Expire()
            PreviousValue = newValue
        End Sub
    End Class
End Namespace
