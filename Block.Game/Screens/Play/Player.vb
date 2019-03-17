Imports osu.Framework.Allocation
Imports osu.Framework.Bindables
Imports osu.Framework.Graphics
Imports osu.Framework.Graphics.Containers
Imports Block.Game.Gameplay.Drawables
Imports Block.Game.Gameplay.Managers
Imports Block.Game.Gameplay.Rules
Imports osuTK

Namespace Screens.Play
    Public Class Player : Inherits Screen
        Private ReadOnly RuleManager As RuleManager
        Private ReadOnly GridManager As GridManager
        Private ReadOnly Rule As GameRule
        Private Counters As FillFlowContainer
        Private MovesDisplay As Display
        Private ScoreDisplay As Display
        Private TimerDisplay As Display

        Public Sub New(rule As GameRule, Optional size As Integer = 4)
            Me.Rule = rule
            GridManager = New GridManager(size)
            RuleManager = New RuleManager(rule, GridManager)
        End Sub

        <BackgroundDependencyLoader>
        Private Sub Load()
            Counters = New FillFlowContainer With {
                .Anchor = Anchor.Centre,
                .AutoSizeAxes = Axes.Both,
                .Position = New Vector2(-300, -340)
            }
            InternalChildren = New List(Of Drawable) From {
                Counters,
                New GridInputContainer With {
                    .RelativeSizeAxes = Axes.None,
                    .AutoSizeAxes = Axes.Both,
                    .Anchor = Anchor.Centre,
                    .Origin = Anchor.Centre,
                    .Y = 50,
                    .Child = New DrawableGrid(GridManager) With {.Area = 600}
                }
            }
            CreateHUD()
        End Sub

        Private Sub CreateHUD()
            If Rule.HasMoves Then
                MovesDisplay = New Display With {
                    .Title = "Moves",
                    .Value = "0"
                }
                Counters.Add(MovesDisplay)
                AddHandler RuleManager.Moves.ValueChanged, AddressOf UpdateMovesDisplay
            End If
            If Rule.HasScore Then
                ScoreDisplay = New Display With {
                    .Title = "Score",
                    .Value = "0"
                }
                Counters.Add(ScoreDisplay)
                AddHandler RuleManager.Score.ValueChanged, AddressOf UpdateScoreDisplay
            End If
            If Rule.HasTimer Then
                TimerDisplay = New Display With {
                    .Title = "Time",
                    .Value = "00:00",
                    .FixedWidth = True
                }
                Counters.Add(TimerDisplay)
            End If
            For Each Child In Counters
                With Child
                    .Margin = New MarginPadding With {.Right = 5}
                    .Anchor = Anchor.TopLeft
                    .Origin = Anchor.TopLeft
                End With
            Next
        End Sub

        Protected Overrides Sub Update()
            If TimerDisplay IsNot Nothing Then
                Dim formatted = TimeSpan.FromMilliseconds(RuleManager.Watch.ElapsedMilliseconds)
                TimerDisplay.Value = String.Format("{0}:{1}", formatted.Minutes.ToString().PadLeft(2, "0"), formatted.Seconds.ToString().PadLeft(2, "0"))
            End If
            MyBase.Update()
        End Sub

        Private Sub UpdateMovesDisplay(value As ValueChangedEvent(Of Integer))
            MovesDisplay.Value = value.NewValue
        End Sub

        Private Sub UpdateScoreDisplay(value As ValueChangedEvent(Of Integer))
            ScoreDisplay.Value = value.NewValue
        End Sub
    End Class
End Namespace
