Imports osu.Framework.Testing
Imports osuTK.Graphics
Imports Block.Core.Objects

Namespace Tests
    <System.ComponentModel.Description("game piece")>
    Public Class TestCaseBlock
        Inherits TestCase

        Private gameBoard As New Board
        Private gamePiece As Piece

        Public Sub New()
            gamePiece = New Piece(gameBoard, Color4.Tomato) With {
                .Anchor = Anchor.Centre,
                .Origin = Origin.Centre
            }

            Add(gamePiece)

            AddRepeatStep("increment", Sub()
                                           gamePiece.Increment()
                                       End Sub, 5)
        End Sub
    End Class
End Namespace
