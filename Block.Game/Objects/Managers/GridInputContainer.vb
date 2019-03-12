Imports osu.Framework.Input.Bindings

Namespace Objects.Managers
    Public Class GridInputContainer : Inherits KeyBindingContainer(Of MoveDirection)

        Public Overrides ReadOnly Property DefaultKeyBindings As IEnumerable(Of KeyBinding)
            Get
                Return New List(Of KeyBinding) From {
                    New KeyBinding(New InputKey() {InputKey.Up}, MoveDirection.Up),
                    New KeyBinding(New InputKey() {InputKey.Down}, MoveDirection.Down),
                    New KeyBinding(New InputKey() {InputKey.Left}, MoveDirection.Left),
                    New KeyBinding(New InputKey() {InputKey.Right}, MoveDirection.Right)
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
