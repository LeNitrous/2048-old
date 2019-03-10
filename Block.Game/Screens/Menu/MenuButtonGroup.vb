Imports osu.Framework.Graphics
Imports osu.Framework.Graphics.Containers
Imports osuTK

Namespace Screens.Menu
    Public Class MenuButtonGroup : Inherits FillFlowContainer
        Private ReadOnly Level As Integer
        Private FromGroup As MenuButtonGroup

        Public Sub New(Optional ByVal level As Integer = 0)
            Anchor = Anchor.Centre
            Origin = Anchor.Centre
            AutoSizeAxes = Axes.Y
            RelativeSizeAxes = Axes.X

            Me.Level = level
            Position = New Vector2(level * 500, 100)
            Alpha = If(Me.Level > 0, 0F, 1.0F)
        End Sub

        Public Sub AddButton(ByRef button As MenuButton)
            button.Anchor = Anchor.Centre
            button.Origin = Anchor.Centre
            button.Margin = New MarginPadding With {.Horizontal = 10.0F}
            Add(button)
        End Sub

        Public Sub AddButtonRange(ByRef buttons As List(Of MenuButton))
            For Each button As MenuButton In buttons
                AddButton(button)
            Next
        End Sub

        Public Sub SwitchTo(ByVal toGroup As MenuButtonGroup)
            MoveToX(-500, 500, Easing.OutQuint)
            FadeOut(500, Easing.OutQuint)

            FromGroup = toGroup
            FromGroup.MoveToX(0, 500, Easing.OutQuint)
            FromGroup.FadeIn(500, Easing.OutQuint)
        End Sub

        Public Sub Back()
            MoveToX(0, 500, Easing.OutQuint)
            FadeIn(500, Easing.OutQuint)

            FromGroup.MoveToX(FromGroup.Level * 500, 500, Easing.OutQuint)
            FromGroup.FadeOut(500, Easing.OutQuint)
        End Sub
    End Class
End Namespace
