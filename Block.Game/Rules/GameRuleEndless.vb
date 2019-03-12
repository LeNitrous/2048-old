Imports Block.Game.Objects

Namespace Rules
    Public Class GameRuleEndless
        Implements IGameRule

        Public Property Name As String Implements IGameRule.Name
            Get
                Return "Endless"
            End Get
            Set(value As String)
            End Set
        End Property

        Public Property ShowTimer As Boolean Implements IGameRule.ShowTimer
            Get
                Return False
            End Get
            Set(value As Boolean)
            End Set
        End Property

        Public Property ShowMoves As Boolean Implements IGameRule.ShowMoves
            Get
                Return True
            End Get
            Set(value As Boolean)
            End Set
        End Property

        Public Property ShowScore As Boolean Implements IGameRule.ShowScore
            Get
                Return True
            End Get
            Set(value As Boolean)
            End Set
        End Property

        Public Function NewRecordCondition(Manager As Manager) As Boolean Implements IGameRule.NewRecordCondition
            Return False
        End Function
    End Class
End Namespace
