Namespace Rules
    Public Class GameRuleEndless : Inherits GameRule
        Public Overrides ReadOnly Property ID As Integer = 1
        Public Overrides ReadOnly Property Name As String = "Endless"
        Public Overrides ReadOnly Property Description As String = "there is no end"
        Public Overrides ReadOnly Property HasTimer As Boolean = False
        Public Overrides ReadOnly Property HasMoves As Boolean = True
        Public Overrides ReadOnly Property HasScore As Boolean = True
        Public Overrides ReadOnly Property IsMultiplayer As Boolean = False
    End Class
End Namespace
