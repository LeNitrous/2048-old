Imports osu.Framework.Allocation
Imports osu.Framework.Graphics
Imports osu.Framework.Graphics.Sprites
Imports Block.Game.Overlays

Namespace Screens.Play
    Public Class LoseDialog : Inherits DialogPrompt
        Public OnExit As Action
        Public OnRestart As Action

        Public Sub New()
            Title = "you lose"
            Icon = "menu"
        End Sub

        <BackgroundDependencyLoader>
        Private Sub Load()
            BodyContent.Child = New SpriteText With {
                .Anchor = Anchor.Centre,
                .Origin = Anchor.Centre,
                .Text = "Better luck next time.",
                .Font = New FontUsage("ClearSans", 28)
            }
            AddButton("exit", OnExit)
            AddButton("restart", OnRestart)
        End Sub
    End Class
End Namespace
