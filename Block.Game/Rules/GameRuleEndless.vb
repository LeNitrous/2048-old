Imports Block.Game.Objects

Namespace Rules
    Public Class GameRuleEndless : Implements IGameRule
        Public Property ID As Integer Implements IGameRule.ID
        Public Property Name As String Implements IGameRule.Name
        Public Property ShowTimer As Boolean Implements IGameRule.ShowTimer
        Public Property ShowMoves As Boolean Implements IGameRule.ShowMoves
        Public Property ShowScore As Boolean Implements IGameRule.ShowScore

        Public Sub New()
            ID = 1
            Name = "Endless"
            ShowTimer = False
            ShowMoves = True
            ShowScore = True
        End Sub

        Public Function NewRecordCondition(Manager As Manager) As Boolean Implements IGameRule.NewRecordCondition
            Return False
        End Function
    End Class
End Namespace
