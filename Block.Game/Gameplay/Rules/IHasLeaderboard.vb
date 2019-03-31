Imports Block.Game.Online.Models
Imports LiteDB

Namespace Gameplay.Rules
    Public Interface IHasLeaderboard
        Function GetNewLeadCondition(attempts As LiteCollection(Of UserAttempt), thisAttempt As UserAttempt) As Boolean
    End Interface
End Namespace
