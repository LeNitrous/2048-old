Imports osu.Framework.Allocation
Imports osu.Framework.Graphics
Imports osu.Framework.Graphics.Sprites
Imports Block.Game.Overlays

Namespace Screens.Play
    Public Class WinDialog : Inherits DialogPrompt
        Public OnExit As Action
        Public OnRestart As Action

        Public Sub New()
            Title = "you win!"
            Icon = "menu"
        End Sub

        <BackgroundDependencyLoader>
        Private Sub Load()
            BodyContent.Child = New SpriteText With {
                .Anchor = Anchor.Centre,
                .Origin = Anchor.Centre,
                .Text = "Congratulations!",
                .Font = New FontUsage("ClearSans", 28)
            }
            AddButton("exit", OnExit)
            AddButton("restart", OnRestart)
        End Sub
    End Class
End Namespace
