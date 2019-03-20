Imports osu.Framework.Allocation
Imports osu.Framework.Bindables
Imports osu.Framework.Graphics
Imports osu.Framework.Graphics.Containers
Imports Block.Game.Gameplay.Drawables
Imports Block.Game.Gameplay.Rules
Imports Block.Game.Gameplay.Objects

Namespace Gameplay.Managers
    Public Class RuleContainer : Inherits CompositeDrawable
        Public Score As BindableInt
        Public Moves As BindableInt
        Public Watch As Stopwatch
        Public Elapsed As Single
        Public Event OnEnd(e As EndType)
        Public WithEvents GridManager As GridManager
        'Private History As New HistoryManager
        Private DrawableGrid As DrawableGrid
        Private ReadOnly Rule As GameRule
        Private IsPaused As Boolean

        Public Property Paused As Boolean
            Get
                Return IsPaused
            End Get
            Set(value As Boolean)
                If value Then
                    If Watch IsNot Nothing Then Watch.Stop()
                Else
                    If Watch IsNot Nothing Then Watch.Start()
                End If
                IsPaused = value
                GridManager.ShouldMoveTiles = Not value
            End Set
        End Property

        Public Sub New(gamerule As GameRule, manager As GridManager)
            GridManager = manager
            Rule = gamerule
            If Rule.HasMoves Then Moves = New BindableInt
            If Rule.HasScore Then Score = New BindableInt
            If Rule.HasTimer Then Watch = New Stopwatch
        End Sub

        <BackgroundDependencyLoader>
        Private Sub Load()
            DrawableGrid = New DrawableGrid(GridManager) With {.Area = 600}
            AutoSizeAxes = Axes.Both
            AddInternal(New GridInputContainer With {
                .RelativeSizeAxes = Axes.None,
                .AutoSizeAxes = Axes.Both,
                .Child = DrawableGrid
            })
        End Sub

        Public Sub Start()
            For i = 0 To 1
                AddRandomTile()
            Next
            Watch?.Start()
            'History.Record(Me)
        End Sub

        Public Sub Reset()
            Score?.Set(0)
            Moves?.Set(0)
            Watch?.Reset()
            Watch?.Stop()
            GridManager.Grid.Empty()
        End Sub

        Public Sub Undo()
            'History.Backward(Me)
        End Sub

        Private Sub GridOnEnd(e As EndType)
            Watch?.Stop()

            If e = EndType.Lose Then DrawableGrid.Collapse()

            Dim r = TryCast(Rule, IHasLeaderboard)
            If r?.GetNewLeadCondition(New RuleManagerInfo(Me)) Then
                ' Streamlined database inserting logic here
            End If

            RaiseEvent OnEnd(e)
        End Sub

        Private Sub GridOnMove(e As MoveDirection) Handles GridManager.OnMove
            Moves?.Add(1)
            'History.Record(Me)

            If GridManager.ShouldAddRandomTile Then
                AddRandomTile()
            End If

            Dim endCondition = TryCast(Rule, IHasEndCondition)
            If endCondition Is Nothing Then
                If Not GridManager.MovesAvailable() Then GridOnEnd(EndType.Lose)
            End If

            Dim onMoveEvent = TryCast(Rule, IHasMoveEvent)
            onMoveEvent?.OnMove(Me)
        End Sub

        Private Sub GridOnTileMerge(merged As Tile) Handles GridManager.OnTileMerge
            Dim mergedScore = merged.Score.Value

            Dim endCondition = TryCast(Rule, IHasEndCondition)
            If endCondition Is Nothing Then
                If mergedScore = 2048 Then GridOnEnd(EndType.Win)
            End If

            If Score IsNot Nothing Then
                Dim r = TryCast(Rule, IHasScoreAdjust)
                r?.ApplyScoreAdjustment(mergedScore)
                Score.Add(mergedScore)
            End If
        End Sub

        Protected Overrides Sub Update()
            If Watch IsNot Nothing Then Elapsed = Watch.ElapsedMilliseconds
            Dim updatable = TryCast(Rule, IHasUpdate)
            updatable?.Update(Me)
        End Sub

        Private Sub AddRandomTile()
            If GridManager.Grid.GetAvailableCells().Count Then
                Dim r = TryCast(Rule, IHasSpawnAdjust)
                Dim value As Integer
                Dim position = GridManager.GetRandomAvailableCell()

                value = If(GridManager.RNG.NextDouble() < 0.9, 2, 4)
                If r IsNot Nothing Then value = r.SpawnAdjustment()

                Dim tile = New Tile(value, position)
                GridManager.Grid.InsertTile(tile)
            End If
        End Sub
    End Class

    Public Class RuleManagerInfo
        Public Score As Integer
        Public Moves As Integer
        Public Elapsed As Single

        Public Sub New(manager As RuleContainer)
            Score = If(manager.Score IsNot Nothing, manager.Score.Value, 0)
            Moves = If(manager.Moves IsNot Nothing, manager.Moves.Value, 0)
            Elapsed = If(manager.Watch IsNot Nothing, manager.Watch.Elapsed.TotalMilliseconds, 0)
        End Sub
    End Class
End Namespace
