Imports osu.Framework.Allocation
Imports osu.Framework.Graphics
Imports osu.Framework.Graphics.Containers
Imports osu.Framework.Graphics.Shapes
Imports osu.Framework.Graphics.Sprites
Imports osu.Framework.Graphics.Textures
Imports osu.Framework.Screens
Imports osuTK
Imports Block.Game.Graphics

Namespace Screens
    Public Class Screen : Inherits osu.Framework.Screens.Screen
        Public Content As Container

        <BackgroundDependencyLoader>
        Private Sub Load(ByVal colour As BlockColour, ByVal store As TextureStore)
            Content = New Container With {
                .RelativeSizeAxes = Axes.Both
            }
            InternalChildren = New List(Of Drawable)({
                New Box With {
                    .RelativeSizeAxes = Axes.Both,
                    .Colour = colour.LightestBrown
                },
                New Sprite With {
                    .Anchor = Anchor.Centre,
                    .Origin = Anchor.Centre,
                    .Colour = colour.DarkestBrown,
                    .Alpha = 0.1,
                    .Texture = store.Get("logo-notext"),
                    .Scale = New Vector2(2)
                },
                Content
            })
        End Sub

        Public Overrides Sub OnEntering(last As IScreen)
            FadeInFromZero(250)
            MyBase.OnEntering(last)
        End Sub

        Public Overrides Sub OnResuming(last As IScreen)
            FadeInFromZero(250)
            MyBase.OnResuming(last)
        End Sub

        Public Overrides Function OnExiting([next] As IScreen) As Boolean
            FadeOutFromOne(250)
            Return MyBase.OnExiting([next])
        End Function

        Public Overrides Sub OnSuspending([next] As IScreen)
            FadeOutFromOne(250)
            MyBase.OnSuspending([next])
        End Sub
    End Class
End Namespace
