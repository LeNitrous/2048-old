Imports Block.Game.Screens.Play.Managers

Namespace Rules
    Public Interface IHasEndCondition
        Function GetWinCondition(manager As RuleManager) As Boolean
        Function GetLoseCondition(manager As RuleManager) As Boolean
    End Interface
End Namespace
