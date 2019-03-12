﻿Imports osu.Framework.Allocation
Imports osu.Framework.Graphics
Imports osu.Framework.Graphics.Containers
Imports osu.Framework.Input.Events
Imports osuTK
Imports Block.Game.Graphics
Imports Block.Game.Objects
Imports Block.Game.Objects.Drawables
Imports Block.Game.Rules

Namespace Screens.Play
    Public Class Player : Inherits Screen
        Private ReadOnly GameManager As Manager
        Private ReadOnly GameRule As IGameRule

        Public Sub New(ByVal rule As IGameRule, ByVal size As Integer)
            GameManager = New Manager(size)
            GameRule = rule
        End Sub

        <BackgroundDependencyLoader>
        Private Sub Load(ByVal colour As BlockColour)
            Dim Counter As New FillFlowContainer With {
                .AutoSizeAxes = Axes.Y,
                .Width = 600,
                .Direction = FillDirection.Horizontal,
                .Anchor = Anchor.Centre,
                .Origin = Anchor.Centre,
                .Y = -320
            }

            If GameRule.ShowMoves Then
                Counter.Add(New MoveCounter(GameManager.Moves) With {
                    .Margin = New MarginPadding() With {.Right = 5}
                })
            End If

            If GameRule.ShowScore Then
                Counter.Add(New ScoreCounter(GameManager.Score) With {
                    .Margin = New MarginPadding() With {.Right = 5}
                })
            End If

            If GameRule.ShowTimer Then
                Counter.Add(New TimerCounter(GameManager.Watch) With {
                    .Margin = New MarginPadding()
                 })
            End If

            Content.AddRange(New List(Of Drawable) From {
                New DrawableGrid(GameManager.Grid) With {
                    .Anchor = Anchor.Centre,
                    .Origin = Anchor.Centre,
                    .GridAreaSize = 600,
                    .Y = 30
                },
                Counter
            })

            GameManager.AddStartTiles()
            GameManager.Watch.Start()

            AddHandler GameManager.Win, AddressOf OnWin
            AddHandler GameManager.Lose, AddressOf OnLose
        End Sub

        Private Sub OnWin()

        End Sub

        Private Sub OnLose()
            GameManager.Watch.Stop()
        End Sub

        Protected Overrides Function OnKeyDown(e As KeyDownEvent) As Boolean
            GameManager.HandleInput(e)
            Return MyBase.OnKeyDown(e)
        End Function
    End Class
End Namespace
