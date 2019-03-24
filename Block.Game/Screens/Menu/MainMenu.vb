Imports osu.Framework.Allocation
Imports osu.Framework.Graphics
Imports osu.Framework.Graphics.Containers
Imports osu.Framework.Graphics.Sprites
Imports osu.Framework.Graphics.Textures
Imports osu.Framework.Screens
Imports Block.Game.Gameplay.Rules
Imports Block.Game.Graphics
Imports Block.Game.Screens.Play
Imports osuTK

Namespace Screens.Menu
    Public Class MainMenu : Inherits Screen
        Private RuleSelect As RuleSelector
        Private DialogBox As GenericDialog

        <BackgroundDependencyLoader>
        Private Sub Load(colours As Colours, store As TextureStore)
            DialogBox = New GenericDialog
            RuleSelect = New RuleSelector With {
                .Anchor = Anchor.Centre,
                .Origin = Anchor.Centre,
                .SelectRule = AddressOf OnPlay,
                .Y = 100
            }
            InternalChildren = New List(Of Drawable) From {
                RuleSelect,
                New Sprite With {
                    .Anchor = Anchor.Centre,
                    .Origin = Anchor.Centre,
                    .Texture = store.Get("logo"),
                    .Colour = colours.FromHex("#776e65"),
                    .Scale = New Vector2(1.5),
                    .Y = -200
                },
                New MenuButton With {
                    .Anchor = Anchor.TopRight,
                    .Origin = Anchor.TopRight,
                    .Scale = New Vector2(0.5),
                    .Texture = "settings",
                    .Position = New Vector2(-10, 50),
                    .ClickAction = Sub() PromptDialog("Feature is not ready yet!")
                },
                New MenuButton With {
                    .Scale = New Vector2(0.5),
                    .Texture = "solo",
                    .Position = New Vector2(50, 10),
                    .ClickAction = Sub() PromptDialog("Feature is not ready yet!")
                },
                DialogBox
            }
        End Sub

        Private Sub PromptDialog(message As String)
            DialogBox.Message = message
            DialogBox.State = Visibility.Visible
        End Sub

        Private Sub OnPlay(rule As GameRule)
            LoadComponentAsync(New Player(rule), Sub(s) Push(s))
        End Sub
    End Class
End Namespace
