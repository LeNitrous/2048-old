Namespace Rules
    Public Class GameRuleClassic : Inherits GameRule
        Public Overrides ReadOnly Property ID As Integer = 0
        Public Overrides ReadOnly Property Name As String = "Classic"
        Public Overrides ReadOnly Property ShowTimer As Boolean = True
        Public Overrides ReadOnly Property ShowMoves As Boolean = True
        Public Overrides ReadOnly Property ShowScore As Boolean = True

        Public Overrides Function NewRecordCondition() As Boolean
            Return False
        End Function
    End Class
End Namespace
