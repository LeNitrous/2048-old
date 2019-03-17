Imports Block.Game.Gameplay.Managers

Namespace Gameplay.Rules
    Public Interface IHasEndCondition
        Function GetWinCondition(manager As RuleManager) As Boolean
        Function GetLoseCondition(manager As RuleManager) As Boolean
    End Interface
End Namespace
