Imports Block.Game.Objects

Namespace Rules
    Public Class GameRuleClassic : Implements IGameRule
        Public Property Name As String Implements IGameRule.Name
            Get
                Return "Classic"
            End Get
            Private Set(value As String)
            End Set
        End Property

        Public Property ShowTimer As Boolean Implements IGameRule.ShowTimer
            Get
                Return True
            End Get
            Private Set(value As Boolean)
            End Set
        End Property

        Public Property ShowMoves As Boolean Implements IGameRule.ShowMoves
            Get
                Return True
            End Get
            Private Set(value As Boolean)
            End Set
        End Property

        Public Property ShowScore As Boolean Implements IGameRule.ShowScore
            Get
                Return True
            End Get
            Private Set(value As Boolean)
            End Set
        End Property

        Public Function NewRecordCondition(ByVal manager As Manager) As Boolean Implements IGameRule.NewRecordCondition
            Return False
        End Function
    End Class
End Namespace
