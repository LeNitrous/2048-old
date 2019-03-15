Imports osu.Framework.Allocation
Imports osu.Framework.Audio
Imports osu.Framework.Graphics
Imports osu.Framework.Input.Bindings
Imports osu.Framework.Screens
Imports Block.Game.Graphics
Imports Block.Game.Objects
Imports Block.Game.Objects.Managers
Imports Block.Game.Objects.Drawables
Imports Block.Game.Rules
Imports Block.Game.Screens.Menu

Namespace Screens.Play
    Public Class Player : Inherits Screen
        Private ReadOnly GameManager As GridManager
        Private ReadOnly GameRule As GameRule

        <Resolved>
        Private Property Stack As ScreenStack

        Public Sub New(ByVal rule As GameRule, ByVal size As Integer)
            GameManager = New GridManager(size)
            GameRule = rule
        End Sub

        <BackgroundDependencyLoader>
        Private Sub Load(ByVal audio As AudioManager, ByVal colour As BlockColour)
            BackgroundTrack = audio.Track.Get("gameplay-solo")

            Content.Add(New DrawableGrid(GameManager) With {
                .Y = 30,
                .GridAreaSize = 600,
                .Anchor = Anchor.Centre,
                .Origin = Anchor.Centre
            })

            GameManager.AddStartTiles()
            GameManager.Watch.Start()

            AddHandler GameManager.Win, AddressOf OnWin
            AddHandler GameManager.Lose, AddressOf OnLose
        End Sub

        Private Sub OnWin()
            GameManager.Watch.Stop()
            Stack.Exit()
            Stack.Push(New MainMenu)
        End Sub

        Private Sub OnLose()
            GameManager.Watch.Stop()
            Stack.Exit()
            Stack.Push(New MainMenu)
        End Sub

        Private Sub OnExit()
            Stack.Exit()
            Stack.Push(New MainMenu)
        End Sub

        Private Sub OnRestart()
            GameManager.Watch.Restart()
            GameManager.Score.Value = 0
            GameManager.Moves.Value = 0
        End Sub

        Private Sub OnRewind()
            Dim last As Tile(,) = GameManager.History.LastOrDefault()
            GameManager.Grid.Cells = last
        End Sub
    End Class
End Namespace
