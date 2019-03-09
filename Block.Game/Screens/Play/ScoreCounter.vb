Imports osu.Framework.Bindables
Imports osu.Framework.Graphics
Imports osu.Framework.Graphics.Sprites
Imports osuTK

Namespace Screens.Play
    Public Class ScoreCounter
        Inherits MoveCounter

        Public Sub New(ByVal counter As BindableInt)
            MyBase.New(counter)
            Title = "score"
            AddHandler Me.Counter.ValueChanged, AddressOf CreateGhostNumber
        End Sub

        Private Sub CreateGhostNumber(ByVal score As ValueChangedEvent(Of Integer))
            Dim ghost As New SpriteText With {
                .Anchor = Anchor.Centre,
                .Origin = Anchor.Centre,
                .Position = New Vector2(-20, 0),
                .Text = String.Format("{0}+", score.NewValue - score.OldValue),
                .Font = New FontUsage("OpenSans", 24, "Bold")
            }
            AddInternal(ghost)
            ghost.MoveToY(-30, 500, Easing.OutQuart)
            ghost.FadeOut(500, Easing.OutQuart)
            ghost.Expire()
        End Sub
    End Class
End Namespace
