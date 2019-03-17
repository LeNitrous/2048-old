Imports osu.Framework.Bindables
Imports Block.Game.Gameplay.Rules
Imports Block.Game.Gameplay.Objects

Namespace Gameplay.Managers
    Public Class RuleManager
        Public Score As BindableInt
        Public Moves As BindableInt
        Public Watch As Stopwatch
        Public Event OnEnd(e As EndType)
        Private IsPaused As Boolean
        Private ReadOnly Rule As GameRule
        Private WithEvents GridManager As GridManager

        Public Property Paused As Boolean
            Get
                Return IsPaused
            End Get
            Set(value As Boolean)
                If value Then
                    Watch.Stop()
                Else
                    Watch.Start()
                End If
                IsPaused = value
            End Set
        End Property

        Public Sub New(gamerule As GameRule, manager As GridManager)
            GridManager = manager
            Rule = gamerule
            If Rule.HasMoves Then Moves = New BindableInt
            If Rule.HasScore Then Score = New BindableInt
            If Rule.HasTimer Then Watch = New Stopwatch
        End Sub

        Public Sub Start()
            GridManager.AddStartTiles()
            Dim r = TryCast(Rule, IHasTimerAdjust)
            If r IsNot Nothing Then r.ApplyTimerAdjustment(Watch)
            If Watch IsNot Nothing Then Watch.Start()
        End Sub

        Private Sub GridOnEnd(e As EndType) Handles GridManager.OnEnd
            Dim r = TryCast(Rule, IHasLeaderboard)
            If r IsNot Nothing Then
                If r.GetNewLeadCondition(New RuleManagerInfo(Me)) Then
                    ' Streamlined database saving logic here
                End If
            End If
            RaiseEvent OnEnd(e)
        End Sub

        Private Sub GridOnMove(e As MoveDirection) Handles GridManager.OnMove
            If Moves IsNot Nothing Then Moves.Add(1)
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
            If Score IsNot Nothing Then Score.Add(mergedScore)
        End Sub
    End Class

    Public Class RuleManagerInfo
        Public Score As Integer
        Public Moves As Integer
        Public Elapsed As Single

        Public Sub New(manager As RuleManager)
            Score = If(manager.Score IsNot Nothing, manager.Score.Value, 0)
            Moves = If(manager.Moves IsNot Nothing, manager.Moves.Value, 0)
            Elapsed = If(manager.Watch IsNot Nothing, manager.Watch.Elapsed.TotalMilliseconds, 0)
        End Sub
    End Class
End Namespace
