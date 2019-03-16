Imports osu.Framework.Bindables
Imports Block.Game.Rules
Imports Block.Game.Screens.Play.Objects

Namespace Screens.Play.Managers
    Public Class RuleManager
        Public Score As New BindableInt
        Public Moves As New BindableInt
        Public Watch As New Stopwatch
        Public Event OnEnd(e As EndType)
        Private ReadOnly Rule As GameRule
        Private WithEvents GridManager As GridManager

        Public Sub New(gamerule As GameRule, manager As GridManager)
            GridManager = manager
            Rule = gamerule
        End Sub

        Public Sub Start()
            GridManager.AddStartTiles()
            Dim r = TryCast(Rule, IHasTimerAdjust)
            If r IsNot Nothing Then r.ApplyTimerAdjustment(Watch)
            Watch.Start()
        End Sub

        Private Sub GridOnEnd(e As EndType) Handles GridManager.OnEnd
            Dim r = TryCast(Rule, IHasLeaderboard)
            If r IsNot Nothing Then
                If r.GetNewLeadCondition(New RuleManagerInfo(Me)) Then
                    r.RecordNewLead(New RuleManagerInfo(Me))
                End If
            End If
            RaiseEvent OnEnd(e)
        End Sub

        Private Sub GridOnMove(e As MoveDirection) Handles GridManager.OnMove
            Moves.Add(1)
            Dim r = TryCast(Rule, IHasEndCondition)
            If r IsNot Nothing Then
                If r.GetWinCondition(Me) Then RaiseEvent OnEnd(EndType.Win)
                If r.GetLoseCondition(Me) Then RaiseEvent OnEnd(EndType.Lose)
            End If
        End Sub

        Private Sub GridOnTileMerge(merged As Tile) Handles GridManager.OnTileMerge
            Dim mergedScore = merged.Score.Value
            Dim r = TryCast(Rule, IHasScoreAdjust)
            If r IsNot Nothing Then r.ApplyScoreAdjustment(mergedScore)
            Score.Add(mergedScore)
        End Sub
    End Class

    Public Class RuleManagerInfo
        Public Score As Integer
        Public Moves As Integer
        Public Elapsed As Single

        Public Sub New(manager As RuleManager)
            Score = manager.Score.Value
            Moves = manager.Moves.Value
            Elapsed = manager.Watch.Elapsed.TotalMilliseconds
        End Sub
    End Class
End Namespace
