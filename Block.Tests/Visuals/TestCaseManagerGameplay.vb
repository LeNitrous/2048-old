Imports osu.Framework.Allocation
Imports osu.Framework.Graphics
Imports osu.Framework.Graphics.Containers
Imports osu.Framework.Graphics.Sprites
Imports osu.Framework.Input.Events
Imports osuTK

Namespace Visuals
    <ComponentModel.Description("full gameplay")>
    Public Class TestCaseManagerGameplay
        Inherits TestCaseManager

        Private scoreCount As SpriteText
        Private movesCount As SpriteText

        Public Sub New()
            scoreCount = New SpriteText With {
                .TextSize = 16,
                .Text = "Score: 0"
            }
            movesCount = New SpriteText With {
                .TextSize = 16,
                .Text = "Moves: 0"
            }
            AddRange(New List(Of Drawable)({
                New FillFlowContainer With {
                    .Width = 50,
                    .AutoSizeAxes = Axes.Y,
                    .FillMode = Axes.Y,
                    .Position = New Vector2(10, 10),
                    .Children = New List(Of Drawable)({
                        scoreCount, movesCount
                    })
                }
            }))
        End Sub

        <BackgroundDependencyLoader>
        Private Sub Load()
            Manager.AddStartTiles()

            AddHandler Manager.GameWin, AddressOf OnWin
            AddHandler Manager.GameOver, AddressOf OnLose
            AddHandler Manager.Score.ValueChanged, AddressOf OnScoreChanged
            AddHandler Manager.Moves.ValueChanged, AddressOf OnMovesChanged
        End Sub

        Protected Overrides Function OnKeyDown(e As KeyDownEvent) As Boolean
            Manager.HandleInput(e)
            Return MyBase.OnKeyDown(e)
        End Function

        Private Sub OnWin()
            Console.WriteLine("YOU WIN")
        End Sub

        Private Sub OnLose()
            Console.WriteLine("YOU LOSE")
        End Sub

        Private Sub OnScoreChanged()
            scoreCount.Text = String.Format("Score: {0}", Manager.Score.Value)
        End Sub

        Private Sub OnMovesChanged()
            movesCount.Text = String.Format("Moves: {0}", Manager.Moves.Value)
        End Sub
    End Class
End Namespace
