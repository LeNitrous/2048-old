Imports osu.Framework.Allocation
Imports osu.Framework.Graphics
Imports osu.Framework.Graphics.Containers
Imports osu.Framework.Graphics.Shapes
Imports osu.Framework.Graphics.Sprites
Imports osuTK
Imports osuTK.Graphics

Namespace Screens.Play
    Public Class Countdown : Inherits Container
        Public Callback As Action
        Public Length As Single
        Private ReadOnly Watch As New Stopwatch
        Private Display As SpriteText

        Public Sub New(length As Single)
            Me.Length = length
        End Sub

        <BackgroundDependencyLoader>
        Private Sub Load()
            Anchor = Anchor.Centre
            Origin = Anchor.Centre
            RelativeSizeAxes = Axes.X
            Height = 80
            Display = New SpriteText With {
                .Font = New FontUsage("ClearSans", 64, "Bold"),
                .Anchor = Anchor.Centre,
                .Origin = Anchor.Centre,
                .Alpha = 0,
                .Y = -3
            }
            Children = New List(Of Drawable) From {
                New Box With {
                    .RelativeSizeAxes = Axes.Both,
                    .Colour = Color4.Black,
                    .Alpha = 0.8
                },
                Display
            }
        End Sub

        Public Sub Start()
            FadeOutFromOne(100) _
                .Then(100) _
                .FadeInFromZero(100) _
                .Loop(100, 3) _
                .Then() _
                .Schedule(Sub()
                              Display.FadeInFromZero(300)
                              Watch.Start()
                          End Sub) _
                .Then(Length + 1000) _
                .Schedule(Sub()
                              FadeOut(100) _
                                .Expire()
                              If Callback IsNot Nothing Then Callback.Invoke()
                          End Sub)
        End Sub

        Protected Overrides Sub Update()
            MyBase.Update()
            Dim timeLeft = Length - Watch.ElapsedMilliseconds
            Dim formatted = TimeSpan.FromMilliseconds(timeLeft)
            Display.Text = If(timeLeft < 1, "GO", CStr(formatted.Seconds + 1))
            If timeLeft < 1 Then Watch.Stop()
        End Sub
    End Class
End Namespace
