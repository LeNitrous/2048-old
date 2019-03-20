Imports Block.Game.Gameplay.Objects

Namespace Gameplay.Managers
    Public Class HistoryManager
        Public Scores As New Dictionary(Of Integer, Integer)
        Public Grids As New Dictionary(Of Integer, Grid)

        Public Sub Backward(ByVal ruleContainer As RuleContainer)
            Dim index = ruleContainer.Moves.Value - 1
            If index < 0 Then Exit Sub

            ruleContainer.Moves?.Add(-1)
            ruleContainer.Score?.Set(Scores(index))
            ruleContainer.GridManager.Grid.SetGrid(Grids(index))
            Scores.Remove(index + 1)
            Grids.Remove(index + 1)
        End Sub

        Public Sub Record(ByVal ruleContainer As RuleContainer)
            Scores.Add(ruleContainer.Moves.Value, ruleContainer.Score.Value)
            Grids.Add(ruleContainer.Moves.Value, ruleContainer.GridManager.Grid)
        End Sub
    End Class
End Namespace
