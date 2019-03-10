Imports Block.Game.Objects

Namespace Rules
    Public Interface IGameRule
        Property Name As String
        Property ShowTimer As Boolean
        Property ShowMoves As Boolean
        Property ShowScore As Boolean

        Function NewRecordCondition(ByVal Manager As Manager) As Boolean
    End Interface
End Namespace
