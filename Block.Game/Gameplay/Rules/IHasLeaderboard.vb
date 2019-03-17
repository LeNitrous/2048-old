Imports Block.Game.Gameplay.Managers

Namespace Gameplay.Rules
    Public Interface IHasLeaderboard
        Function GetNewLeadCondition(manager As RuleManagerInfo) As Boolean
    End Interface
End Namespace
