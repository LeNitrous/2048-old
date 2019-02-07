Imports System.Timers
Imports osu.Framework.Configuration
Imports osu.Framework.Graphics.Sprites

Namespace Screens.Play.Components
    Public Class CounterClock
        Inherits Counter

        Private Time As Timer

        Public Sub New()
            MyBase.New("Elapsed", Nothing)

            Time = New Timer With {
                .Interval = 1000
            }

            AddHandler Time.Elapsed, AddressOf OnTick
        End Sub

        Public Sub Start()
            Time.Enabled = True
        End Sub

        Public Sub Pause()
            Time.Enabled = False
        End Sub

        Private Sub OnTick()
            CounterBindable.Add(1)
        End Sub

        Protected Overrides Function CreateCounterText(bindable As BindableInt) As SpriteText
            Return New SpriteText With {
                .Anchor = Anchor.Centre,
                .Origin = Anchor.Centre,
                .Y = -5,
                .Text = "00:00",
                .TextSize = 32
            }
        End Function

        Protected Overrides Sub UpdateText(newValue As Integer)
            Dim formatted As TimeSpan = TimeSpan.FromSeconds(CounterBindable)
            CounterText.Text = String.Format("{0}:{1}", formatted.Minutes.ToString().PadLeft(2, "0"),
                                             formatted.Seconds.ToString().PadLeft(2, "0"))
        End Sub
    End Class
End Namespace
