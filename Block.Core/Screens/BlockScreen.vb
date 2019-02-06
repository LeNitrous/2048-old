Imports osu.Framework.Allocation
Imports osu.Framework.Graphics
Imports osu.Framework.Graphics.Containers
Imports osu.Framework.Graphics.Shapes
Imports osu.Framework.Screens
Imports osuTK.Graphics

Namespace Screens
    Public Class BlockScreen
        Inherits Screen

        Public Content As DrawSizePreservingFillContainer
        Private Background As Box
        Public Property BackgroundColor As Color4
            Get
                Return Background.Colour
            End Get
            Set(value As Color4)
                Background.FadeColour(value)
            End Set
        End Property

        <BackgroundDependencyLoader>
        Private Sub Load()
            Background = New Box With {
                .RelativeSizeAxes = Axes.Both
            }
            Content = New DrawSizePreservingFillContainer With {
                .RelativeSizeAxes = Axes.Both
            }
            InternalChildren = New List(Of Drawable)({
                Background,
                Content
            })
        End Sub

        Public Overrides Sub OnEntering(last As IScreen)
            FadeInFromZero(250)
            MyBase.OnEntering(last)
        End Sub

        Public Overrides Sub OnResuming(last As IScreen)
            FadeInFromZero(250)
            MyBase.OnResuming(last)
        End Sub

        Public Overrides Function OnExiting([next] As IScreen) As Boolean
            FadeOutFromOne(250)
            Return MyBase.OnExiting([next])
        End Function

        Public Overrides Sub OnSuspending([next] As IScreen)
            FadeOutFromOne(250)
            MyBase.OnSuspending([next])
        End Sub
    End Class
End Namespace
