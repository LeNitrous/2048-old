Imports osu.Framework.Testing
Imports Block.Core.Objects

Namespace Tests
    <System.ComponentModel.Description("game board")>
    Public Class TestCaseBoard
        Inherits TestCase

        Private gameBoard As New Board

        Public Sub New()
            Add(gameBoard)

            AddStep("2x2 board", Sub()
                                     gameBoard.Resize(2)
                                 End Sub)

            AddStep("3x3 board", Sub()
                                     gameBoard.Resize(3)
                                 End Sub)

            AddStep("4x4 board", Sub()
                                     gameBoard.Resize(4)
                                 End Sub)

            AddStep("5x5 board", Sub()
                                     gameBoard.Resize(5)
                                 End Sub)
        End Sub
    End Class
End Namespace
