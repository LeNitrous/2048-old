Imports osu.Framework.Allocation
Imports osu.Framework.Graphics
Imports osu.Framework.Graphics.Containers
Imports osu.Framework.Testing
Imports Block.Game.Objects
Imports Block.Game.Screens.Play

Namespace Tests.Visuals.TestCasePlayer
    Public Class TestCaseCounter
        Inherits TestCase

        Public GameManager As New Manager(4)

        <BackgroundDependencyLoader>
        Private Sub Load()
            Add(New FillFlowContainer With {
                .AutoSizeAxes = Axes.Both,
                .Children = New List(Of Drawable) From {
                    New MoveCounter(GameManager.Moves),
                    New ScoreCounter(GameManager.Score),
                    New TimerCounter(GameManager.Watch)
                }
            })

            AddRepeatStep("add moves", Sub()
                                           GameManager.Moves.Add(1)
                                       End Sub, 20)
            AddRepeatStep("add score", Sub()
                                           GameManager.Score.Add(4)
                                       End Sub, 10)
            AddStep("start timer", Sub()
                                       GameManager.Watch.Start()
                                   End Sub)
            AddWaitStep(20)
            AddStep("stop timer", Sub()
                                      GameManager.Watch.Stop()
                                  End Sub)
        End Sub
    End Class
End Namespace
