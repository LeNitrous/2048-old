Imports osu.Framework.Allocation
Imports osu.Framework.Graphics
Imports osu.Framework.Graphics.Containers
Imports Block.Game.Graphics
Imports Block.Game.Graphics.UserInterface
Imports osuTK

Namespace Overlays
    Public Class DialogPrompt : Inherits Dialog
        Public BodyContent As Container
        Private Footer As FillFlowContainer

        <Resolved>
        Private Property Colours As Colours

        <BackgroundDependencyLoader>
        Private Sub Load()
            DialogBox.Size = New Vector2(350, 250)
            BodyContent = New Container With {
                .RelativeSizeAxes = Axes.Both,
                .Padding = New MarginPadding With {.Bottom = 40}
            }
            Footer = New FillFlowContainer With {
                .Anchor = Anchor.BottomCentre,
                .Origin = Anchor.BottomCentre,
                .RelativeSizeAxes = Axes.X,
                .AutoSizeAxes = Axes.Y,
                .Direction = FillDirection.Horizontal
            }
            Body.Children = New List(Of Drawable) From {
                BodyContent,
                Footer
            }
        End Sub

        Protected Overrides Sub LoadComplete()
            MyBase.LoadComplete()
            For i = 0 To Footer.Children.Count - 2
                Dim button As Button = Footer.Children.ElementAt(i)
                button.Padding = New MarginPadding With {.Right = 10}
            Next
        End Sub

        Public Sub AddButton(text As String, Optional clickAction As Action = Nothing)
            Footer.Add(New Button(text, clickAction) With {
                .Anchor = Anchor.Centre,
                .Origin = Anchor.Centre,
                .BodyColour = Colours.LighterBrown.Darken(0.1),
                .Width = 100
            })
        End Sub
    End Class
End Namespace
