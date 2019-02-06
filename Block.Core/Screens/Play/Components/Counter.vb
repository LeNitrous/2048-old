Imports osu.Framework.Allocation
Imports osu.Framework.Configuration
Imports osu.Framework.Graphics
Imports osu.Framework.Graphics.Containers
Imports osu.Framework.Graphics.Shapes
Imports osu.Framework.Graphics.Sprites
Imports osuTK
Imports Block.Core.Graphics

Namespace Screens.Play.Components
    Public Class Counter
        Inherits CompositeDrawable

        Private ReadOnly Background As Box
        Private ReadOnly Description As SpriteText
        Protected ReadOnly CounterText As SpriteText
        Protected ReadOnly CounterBindable As New BindableInt

        Public Sub New(ByVal desc As String, ByVal bindable As BindableInt)
            Size = New Vector2(100, 50)
            Background = CreateBackground()
            CounterText = CreateCounterText(bindable)
            Description = CreateDescription(desc)

            InternalChild = New Container With {
                .RelativeSizeAxes = Axes.Both,
                .CornerRadius = 5,
                .Masking = True,
                .Children = New List(Of Drawable)({
                    Background,
                    CounterText,
                    Description
                })
            }

            AddHandler CounterBindable.ValueChanged, AddressOf UpdateText
        End Sub

        <BackgroundDependencyLoader>
        Private Sub Load(color As BlockColor)
            Background.Colour = color.FreshBrown
        End Sub

        Protected Function CreateBackground() As Box
            Return New Box With {
                .RelativeSizeAxes = Axes.Both
            }
        End Function

        Protected Overridable Function CreateCounterText(ByVal bindable As BindableInt) As SpriteText
            CounterBindable.BindTo(bindable)
            Return New SpriteText With {
                .Anchor = Anchor.Centre,
                .Origin = Anchor.Centre,
                .Y = -5,
                .Text = "0",
                .TextSize = 32
            }
        End Function

        Protected Function CreateDescription(ByVal desc As String) As SpriteText
            Return New SpriteText With {
                .Anchor = Anchor.BottomCentre,
                .Origin = Anchor.Centre,
                .Y = -10,
                .Text = desc,
                .TextSize = 14,
                .Font = "OpenSans-Bold"
            }
        End Function

        Protected Overridable Sub UpdateText(ByVal newValue As Integer)
            CounterText.Text = CStr(newValue)
        End Sub
    End Class
End Namespace
