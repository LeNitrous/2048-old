Namespace Rules
    Public Class GameRuleMoveTrial : Inherits GameRule
        Public Overrides ReadOnly Property ID As Integer = 1
        Public Overrides ReadOnly Property Name As String = "Move Trial"
        Public Overrides ReadOnly Property ShowTimer As Boolean = False
        Public Overrides ReadOnly Property ShowMoves As Boolean = True
        Public Overrides ReadOnly Property ShowScore As Boolean = False

        Public Overrides Function NewRecordCondition() As Boolean
            Return False
        End Function
    End Class
End Namespace
