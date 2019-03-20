Imports osu.Framework.Allocation
Imports osu.Framework.Graphics
Imports osu.Framework.Graphics.Sprites
Imports Block.Game.Overlays

Namespace Screens.Play
    Public Class PauseDialog : Inherits DialogPrompt
        Public OnExit As Action
        Public OnResume As Action
        Public OnRestart As Action

        Public Sub New()
            Title = "paused"
            Icon = "menu"
        End Sub

        <BackgroundDependencyLoader>
        Private Sub Load()
            BodyContent.Child = New SpriteText With {
                .Anchor = Anchor.Centre,
                .Origin = Anchor.Centre,
                .Text = "The game is currently paused.",
                .Font = New FontUsage("ClearSans", 28)
            }
            AddButton("exit", OnExit)
            AddButton("resume", OnResume)
            AddButton("restart", OnRestart)
        End Sub
    End Class
End Namespace
