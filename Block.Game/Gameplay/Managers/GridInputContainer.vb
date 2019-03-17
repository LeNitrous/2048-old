Imports osu.Framework.Input.Bindings

Namespace Gameplay.Managers
    Public Class GridInputContainer : Inherits KeyBindingContainer(Of MoveDirection)

        Public Overrides ReadOnly Property DefaultKeyBindings As IEnumerable(Of KeyBinding)
            Get
                Return New List(Of KeyBinding) From {
                    New KeyBinding(InputKey.Up, MoveDirection.Up),
                    New KeyBinding(InputKey.Down, MoveDirection.Down),
                    New KeyBinding(InputKey.Left, MoveDirection.Left),
                    New KeyBinding(InputKey.Right, MoveDirection.Right)
                }
            End Get
        End Property
    End Class

    Public Enum MoveDirection
        Up
        Right
        Down
        Left
    End Enum
End Namespace
