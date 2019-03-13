Imports osu.Framework
Imports osu.Framework.Graphics
Imports osu.Framework.Graphics.Containers

Namespace Screens.Menu
    Public Class ButtonGroup : Inherits FillFlowContainer(Of MenuButton) : Implements IStateful(Of ButtonGroupState)
        Public ReadOnly Id As String
        Public ReadOnly ParentId As String
        Private Visible As ButtonGroupState

        Public Event StateChanged As Action(Of ButtonGroupState) Implements IStateful(Of ButtonGroupState).StateChanged
        Public Property State As ButtonGroupState Implements IStateful(Of ButtonGroupState).State
            Get
                Return Visible
            End Get
            Set(value As ButtonGroupState)
                If Visible = value Then Exit Property

                Visible = value
                Select Case Visible
                    Case ButtonGroupState.Forward
                        MoveToX(-500, 300, Easing.OutQuart)
                        FadeOut(300, Easing.OutQuart)
                    Case ButtonGroupState.Visible
                        MoveToX(0, 300, Easing.OutQuart)
                        FadeIn(300, Easing.OutQuart)
                    Case ButtonGroupState.Backward
                        MoveToX(500, 300, Easing.OutQuart)
                        FadeOut(300, Easing.OutQuart)
                End Select

                RaiseEvent StateChanged(Visible)
            End Set
        End Property

        Public Sub New(ByVal name As String, ByVal buttons As List(Of MenuButton), Optional ByVal parent As String = "")
            Id = name
            ParentId = parent
            RelativeSizeAxes = Axes.X
            AutoSizeAxes = Axes.Y
            Direction = FillDirection.Horizontal

            For Each button In buttons
                Add(button)
            Next
        End Sub

        Public Overrides Sub Add(drawable As MenuButton)
            drawable.Margin = New MarginPadding With {.Right = 20.0F}
            drawable.Anchor = Anchor.Centre
            drawable.Origin = Anchor.Centre
            MyBase.Add(drawable)
        End Sub
    End Class

    Public Enum ButtonGroupState
        Forward
        Visible
        Backward
    End Enum
End Namespace
