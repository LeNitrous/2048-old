Imports osu.Framework.Allocation
Imports osu.Framework.Audio
Imports osu.Framework.Graphics
Imports osu.Framework.Graphics.Containers
Imports osu.Framework.Graphics.Sprites
Imports osu.Framework.Graphics.Textures
Imports osu.Framework.Screens
Imports osuTK

Namespace Screens.Menu
    Public Class Splash : Inherits Screen
        Private MainMenu As MainMenu
        Private Background As Background
        Private IntroA As TextFlowContainer
        Private IntroB As TextFlowContainer
        Private IntroC As TextFlowContainer
        Private Logo As Sprite

        <Resolved>
        Private Property Audio As AudioManager

        <Resolved>
        Private Property Store As TextureStore

        <Resolved>
        Private Property BackgroundStack As ScreenStack

        <BackgroundDependencyLoader>
        Private Sub Load()
            IntroA = CreateTextFlowContainer()
            IntroA.AddText("original game by ", Sub(t) t.Font = t.Font.With("ClearSans", 30))
            IntroA.AddText("Gabriele Cirulli", Sub(t) t.Font = t.Font.With("ClearSans", 30, "Bold"))
            IntroB = CreateTextFlowContainer()
            IntroB.AddText("powered by the ", Sub(t) t.Font = t.Font.With("ClearSans", 30))
            IntroB.AddText("osu!framework", Sub(t) t.Font = t.Font.With("ClearSans", 30, "Bold"))
            IntroC = CreateTextFlowContainer()
            IntroC.AddText("Nitrous", Sub(t) t.Font = t.Font.With("ClearSans", 30, "Bold"))
            IntroC.AddText(" presents...", Sub(t) t.Font = t.Font.With("ClearSans", 30))
            Logo = New Sprite With {
                .Texture = Store.Get("logo"),
                .Scale = New Vector2(1.5),
                .Anchor = Anchor.Centre,
                .Origin = Anchor.Centre,
                .Alpha = 0
            }
            InternalChildren = New List(Of Drawable) From {
                IntroA,
                IntroB,
                IntroC,
                Logo
            }
        End Sub

        Protected Overrides Sub LoadComplete()
            MyBase.LoadComplete()
            LoadComponentAsync(New MainMenu, Sub(s) MainMenu = s)
            LoadComponentAsync(New Background, Sub(s) Background = s)
        End Sub

        Public Overrides Sub OnEntering(last As IScreen)
            MyBase.OnEntering(last)
            IntroA.Delay(1000) _
                .FadeIn(250, Easing.OutQuad) _
                .Schedule(Sub() Audio.Track.Get("mainmenu").Start()) _
                .Then(1750) _
                .FadeOut(250, Easing.OutQuad)
            IntroB.Delay(3000) _
                .FadeIn(250, Easing.OutQuad) _
                .Then(1750) _
                .FadeOut(250, Easing.OutQuad)
            IntroC.Delay(5000) _
                .FadeIn(250, Easing.OutQuad) _
                .Then(1750) _
                .FadeOut(250, Easing.OutQuad)
            Logo.Delay(7000) _
                .FadeIn(250, Easing.OutQuad) _
                .Then(1750) _
                .MoveToY(-200, Easing.OutQuad) _
                .Finally(Sub()
                             BackgroundStack.Push(Background)
                             Push(MainMenu)
                         End Sub)
        End Sub

        Private Function CreateTextFlowContainer() As TextFlowContainer
            Return New TextFlowContainer With {
                .AutoSizeAxes = Axes.Both,
                .Anchor = Anchor.Centre,
                .Origin = Anchor.Centre,
                .Alpha = 0
            }
        End Function
    End Class
End Namespace
