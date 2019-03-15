Namespace Rules
    Public Class GameRuleTimeTrial : Inherits GameRule
        Public Overrides ReadOnly Property ID As Integer = 2
        Public Overrides ReadOnly Property Name As String = "Time Trial"
        Public Overrides ReadOnly Property Description As String = "play as fast as you can"
        Public Overrides ReadOnly Property HasTimer As Boolean = True
        Public Overrides ReadOnly Property HasMoves As Boolean = False
        Public Overrides ReadOnly Property HasScore As Boolean = False
        Public Overrides ReadOnly Property IsMultiplayer As Boolean = False
    End Class
End Namespace
