Imports osu.Framework.Allocation
Imports osu.Framework.Bindables
Imports osu.Framework.Graphics
Imports osu.Framework.Graphics.Containers
Imports osu.Framework.Graphics.Sprites
Imports Block.Game.Graphics.Shapes
Imports osuTK
Imports osuTK.Graphics
Imports osu.Framework.Input.Events

Namespace Graphics.UserInterface
    Public Class Button : Inherits ClickableContainer
        Public Text As String
        Public ClickAction As Action
        Public BodyColour As Color4
        Public Disabled As New BindableBool
        Protected Body As RoundedBox
        Protected Flash As RoundedBox

        Public Sub New(text As String, Optional clickAction As Action = Nothing)
            Me.Text = text
            Me.ClickAction = clickAction
            Size = New Vector2(140, 40)
        End Sub

        <BackgroundDependencyLoader>
        Private Sub Load(colours As Colours)
            Masking = True
            CornerRadius = 5
            Body = CreateRoundedBox()
            Body.Colour = BodyColour
            Flash = CreateRoundedBox()
            Flash.Colour = Color4.WhiteSmoke
            Flash.Alpha = 0
            Children = New List(Of Drawable) From {
                New ClickSound,
                Body,
                New SpriteText With {
                    .Text = Text,
                    .Font = New FontUsage("ClearSans", 24),
                    .Anchor = Anchor.Centre,
                    .Origin = Anchor.Centre
                },
                Flash
            }
            AddHandler Disabled.ValueChanged, AddressOf UpdateDisableState
        End Sub

        Private Function CreateRoundedBox() As RoundedBox
            Return New RoundedBox With {
                .RelativeSizeAxes = Axes.Both
            }
        End Function

        Private Sub UpdateDisableState(state As ValueChangedEvent(Of Boolean))
            If state.NewValue Then
                Body.Colour = Color4.Gray
            Else
                Body.Colour = BodyColour
            End If
        End Sub

        Protected Overrides Function OnClick(e As ClickEvent) As Boolean
            If Disabled.Value Then Return MyBase.OnClick(e)
            Flash.ClearTransforms()
            Flash.Alpha = 0.9
            Flash.FadeOut(300, Easing.OutQuad)
            If ClickAction IsNot Nothing Then ClickAction.Invoke()
            Return MyBase.OnClick(e)
        End Function
    End Class
End Namespace
