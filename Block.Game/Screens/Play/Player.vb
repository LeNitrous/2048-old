Imports osu.Framework.Allocation
Imports osu.Framework.Bindables
Imports osu.Framework.Graphics
Imports osu.Framework.Graphics.Containers
Imports osu.Framework.Screens
Imports Block.Game.Gameplay.Managers
Imports Block.Game.Gameplay.Rules
Imports Block.Game.Graphics.UserInterface
Imports osuTK

Namespace Screens.Play
    Public Class Player : Inherits Screen
        Private ReadOnly DisallowPause As New BindableBool
        Private ReadOnly GridManager As GridManager
        Private ReadOnly Rule As GameRule
        Private WithEvents RuleContainer As RuleContainer
        Private Counters As FillFlowContainer
        Private Buttons As FillFlowContainer
        Private MovesDisplay As Display
        Private ScoreDisplay As Display
        Private TimerDisplay As Display
        Private PauseDialog As PauseDialog
        Private LoseDialog As LoseDialog
        Private WinDialog As WinDialog
        Private PauseButton As IconButton
        Private UndoButton As IconButton

        Public Sub New(rule As GameRule, Optional size As Integer = 4)
            Me.Rule = rule
            GridManager = New GridManager(size)
        End Sub

        <BackgroundDependencyLoader>
        Private Sub Load()
            Counters = New FillFlowContainer With {.AutoSizeAxes = Axes.Both}
            RuleContainer = New RuleContainer(Rule, GridManager) With {
                .Anchor = Anchor.Centre,
                .Origin = Anchor.Centre,
                .Y = 50
            }
            Buttons = New FillFlowContainer With {
                .Anchor = Anchor.BottomRight,
                .Origin = Anchor.BottomRight,
                .AutoSizeAxes = Axes.Both
            }
            PauseDialog = New PauseDialog With {
                .OnExit = AddressOf Quit,
                .OnResume = AddressOf Unpause,
                .OnRestart = AddressOf Restart
            }
            WinDialog = New WinDialog With {
                .OnExit = AddressOf Quit,
                .OnRestart = AddressOf Restart
            }
            LoseDialog = New LoseDialog With {
                .OnExit = AddressOf Quit,
                .OnRestart = AddressOf Restart
            }
            InternalChildren = New List(Of Drawable) From {
                New Container With {
                    .Anchor = Anchor.Centre,
                    .Origin = Anchor.Centre,
                    .Position = New Vector2(0, -300),
                    .AutoSizeAxes = Axes.Y,
                    .Width = 600,
                    .Children = New List(Of Drawable) From {
                        Buttons,
                        Counters
                    }
                },
                RuleContainer,
                PauseDialog,
                WinDialog,
                LoseDialog
            }
            CreateHUD()
        End Sub

        Protected Overrides Sub LoadComplete()
            MyBase.LoadComplete()
            PreparePlayer()
        End Sub

        Private Sub PreparePlayer()
            DisallowPause.Value = True
            Dim r = TryCast(Rule, IHasCountdown)
            If r IsNot Nothing Then
                Dim countdownTimer = New Countdown(r?.CountdownLength) With {.Callback = AddressOf Start}
                AddInternal(countdownTimer)
                countdownTimer.Start()
            Else
                Start()
            End If
        End Sub

        Private Sub Start()
            RuleContainer.Start()
            DisallowPause.Value = False
        End Sub

        Private Sub Pause()
            PauseDialog.State = Visibility.Visible
            RuleContainer.Paused = True
        End Sub

        Private Sub Unpause()
            PauseDialog.State = Visibility.Hidden
            LoseDialog.State = Visibility.Hidden
            WinDialog.State = Visibility.Hidden
            RuleContainer.Paused = False
        End Sub

        Private Sub Quit()
            [Exit]()
        End Sub

        Private Sub Restart()
            RuleContainer.Reset()
            PreparePlayer()
            Unpause()
        End Sub

        Private Sub OnUndo()
            RuleContainer.Undo()
        End Sub

        Private Sub CreateHUD()
            If Rule.HasMoves Then
                MovesDisplay = New Display With {
                    .Title = "Moves",
                    .Value = "0"
                }
                Counters.Add(MovesDisplay)
                AddHandler RuleContainer.Moves.ValueChanged, AddressOf UpdateMovesDisplay
            End If
            If Rule.HasScore Then
                ScoreDisplay = New Display With {
                    .Title = "Score",
                    .Value = "0"
                }
                Counters.Add(ScoreDisplay)
                AddHandler RuleContainer.Score.ValueChanged, AddressOf UpdateScoreDisplay
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

            'If Rule.AllowUndo Then
            '    UndoButton = New IconButton("restart", AddressOf OnUndo) With {.Margin = New MarginPadding With {.Right = 10}}
            '    Buttons.Add(UndoButton)
            'End If

            PauseButton = New IconButton("menu", AddressOf Pause)
            PauseButton.Disabled.BindTo(DisallowPause)
            Buttons.Add(PauseButton)
        End Sub

        Protected Overrides Sub Update()
            If TimerDisplay IsNot Nothing Then
                Dim formatted = TimeSpan.FromMilliseconds(RuleContainer.Elapsed)
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

        Private Sub OnGameEnd(e As EndType) Handles RuleContainer.OnEnd
            RuleContainer.Paused = True
            Select Case e
                Case EndType.Win
                    Delay(2000).Schedule(Sub() WinDialog.State = Visibility.Visible)
                    Exit Select
                Case EndType.Lose
                    Delay(2000).Schedule(Sub() LoseDialog.State = Visibility.Visible)
                    Exit Select
            End Select
        End Sub
    End Class
End Namespace
