Imports Block.Game.Screens.Play.Managers

Namespace Rules
    Public Interface IHasLeaderboard
        Function GetNewLeadCondition(manager As RuleManagerInfo) As Boolean
        Sub RecordNewLead(manager As RuleManagerInfo)
    End Interface
End Namespace
