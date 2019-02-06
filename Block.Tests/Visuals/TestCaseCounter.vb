Imports osu.Framework.Allocation
Imports osu.Framework.Configuration
Imports osu.Framework.Graphics
Imports osu.Framework.Graphics.Containers
Imports osu.Framework.Testing
Imports Block.Core.Screens.Play.Components

Namespace Visuals
    Public Class TestCaseCounter
        Inherits TestCase

        <BackgroundDependencyLoader>
        Private Sub Load()
            Dim bindable As New BindableInt
            Dim clock As New CounterClock

            Add(New FillFlowContainer With {
                .Anchor = Anchor.Centre,
                .Origin = Anchor.Centre,
                .FillMode = Axes.X,
                .AutoSizeAxes = Axes.Both,
                .Children = New List(Of Drawable)({
                    New Counter("Test", bindable),
                    New CounterScore(bindable),
                    clock
                })
            })

            clock.Start()

            AddStep("add", Sub()
                               bindable.Add(1)
                           End Sub)
        End Sub
    End Class
End Namespace
