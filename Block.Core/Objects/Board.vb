Imports osu.Framework.Graphics.Containers

Namespace Objects
    Public Class Board
        Inherits CompositeDrawable

        Private Dimensions As Integer
        Private Map As Block(,)

        Public Sub New(Optional ByVal size As Integer = 3)
            Dimensions = size
            ReDim Map(Dimensions, Dimensions)
        End Sub

        Public Sub Move(ByVal direction As MoveDirection)
            Select Case direction
                Case MoveDirection.Up

                Case MoveDirection.Down

                Case MoveDirection.Left

                Case MoveDirection.Right

                Case Else
                    Throw New NotSupportedException("Performed an invalid move.")
            End Select
        End Sub

        Public Enum MoveDirection
            Up
            Down
            Left
            Right
        End Enum
    End Class
End Namespace
