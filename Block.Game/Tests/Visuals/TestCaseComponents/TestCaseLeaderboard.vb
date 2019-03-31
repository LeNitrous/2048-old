Imports osu.Framework.Allocation
Imports osu.Framework.Testing
Imports Block.Game.Online.Models
Imports Block.Game.Screens.Leaderboard

Namespace Tests.Visuals.TestCaseComponents
    Public Class TestCaseLeaderboard : Inherits TestCase
        <BackgroundDependencyLoader>
        Private Sub Load()
            Dim fakeAttempts As New List(Of UserAttempt) From {
                New UserAttempt,
                New UserAttempt,
                New UserAttempt,
                New UserAttempt,
                New UserAttempt,
                New UserAttempt,
                New UserAttempt,
                New UserAttempt,
                New UserAttempt,
                New UserAttempt,
                New UserAttempt,
                New UserAttempt
            }
            Add(New Listing(fakeAttempts))
        End Sub
    End Class
End Namespace
