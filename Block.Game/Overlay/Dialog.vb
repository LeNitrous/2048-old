Imports osu.Framework.Allocation
Imports osu.Framework.Graphics
Imports osu.Framework.Graphics.Containers
Imports osu.Framework.Graphics.Shapes
Imports osu.Framework.Graphics.Sprites
Imports osu.Framework.Graphics.Textures
Imports Block.Game.Graphics
Imports Block.Game.Graphics.Shapes
Imports Block.Game.Graphics.UserInterface
Imports osuTK
Imports osuTK.Graphics
Imports osu.Framework.Input.Events

Namespace Overlays
    Public Class Dialog : Inherits OverlayContainer
        Public Title As String
        Public Icon As String
        Public Body As Container
        Private TitleBar As FillFlowContainer
        Protected DialogBox As Container

        Protected Overrides ReadOnly Property BlockPositionalInput As Boolean = True

        Protected Overrides Function OnMouseUp(e As MouseUpEvent) As Boolean
            Return True
        End Function

        Protected Overrides Function OnMouseDown(e As MouseDownEvent) As Boolean
            Return True
        End Function

        Protected Overrides Function OnMouseMove(e As MouseMoveEvent) As Boolean
            Return True
        End Function

        <BackgroundDependencyLoader>
        Private Sub Load(colours As Colours, store As TextureStore)
            RelativeSizeAxes = Axes.Both
            TitleBar = New FillFlowContainer With {
                .RelativeSizeAxes = Axes.X,
                .Padding = New MarginPadding With {.Horizontal = 15},
                .Height = 40
            }
            Body = New Container With {
                .Anchor = Anchor.Centre,
                .Origin = Anchor.Centre,
                .RelativeSizeAxes = Axes.Both,
                .Size = New Vector2(0.9),
                .Padding = New MarginPadding With {.Top = 40}
            }
            DialogBox = New Container With {
                .Anchor = Anchor.Centre,
                .Origin = Anchor.Centre,
                .Size = New Vector2(600, 400),
                .Children = New List(Of Drawable) From {
                    New RoundedBox With {
                        .RelativeSizeAxes = Axes.Both,
                        .Colour = colours.LighterBrown
                    },
                    New Container With {
                        .RelativeSizeAxes = Axes.Both,
                        .Padding = New MarginPadding(10),
                        .Children = New List(Of Drawable) From {
                            New Box With {
                                .Anchor = Anchor.TopCentre,
                                .Origin = Anchor.TopCentre,
                                .RelativeSizeAxes = Axes.X,
                                .Height = 2,
                                .Position = New Vector2(0, 40),
                                .Width = 0.95,
                                .Colour = colours.LightestBrown
                            },
                            TitleBar,
                            Body
                        }
                    }
                }
            }
            Children = New List(Of Drawable) From {
                New Box With {
                    .RelativeSizeAxes = Axes.Both,
                    .Colour = Color4.Black,
                    .Alpha = 0.75
                },
                DialogBox
            }

            If Not String.IsNullOrEmpty(Icon) Then
                TitleBar.Add(New Sprite With {
                    .Anchor = Anchor.CentreLeft,
                    .Origin = Anchor.CentreLeft,
                    .Texture = store.Get("Interface/" & Icon),
                    .Size = New Vector2(20),
                    .Alpha = 0.5,
                    .Margin = New MarginPadding With {.Right = 5},
                    .Colour = colours.LightestBrown
                })
            End If

            TitleBar.Add(New SpriteText With {
                .Anchor = Anchor.CentreLeft,
                .Origin = Anchor.CentreLeft,
                .Text = Title,
                .Font = New FontUsage("ClearSans", 28, "Bold"),
                .Colour = colours.LightestBrown
            })
        End Sub

        Protected Overrides Sub PopIn()
            FadeIn(200, Easing.In)
            DialogBox.Scale = New Vector2(0.9)
            DialogBox.ScaleTo(1, 250, Easing.OutBack)
        End Sub

        Protected Overrides Sub PopOut()
            FadeOut(200, Easing.In)
            DialogBox.ScaleTo(0.9, 250, Easing.Out)
        End Sub
    End Class
End Namespace
