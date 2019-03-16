Imports osu.Framework.Allocation
Imports osu.Framework.Audio
Imports osu.Framework.Audio.Sample
Imports osu.Framework.Graphics
Imports osu.Framework.Graphics.Containers
Imports osu.Framework.Input.Events

Namespace Graphics.UserInterface
    Public Class ClickSound : Inherits CompositeDrawable
        Private ClickSample As SampleChannel

        Public Sub New()
            RelativeSizeAxes = Axes.Both
        End Sub

        <BackgroundDependencyLoader>
        Private Sub Load(Audio As AudioManager)
            ClickSample = Audio.Sample.Get("Interface/button-click")
        End Sub

        Protected Overrides Function OnClick(e As ClickEvent) As Boolean
            If ClickSample IsNot Nothing Then
                ClickSample.Play()
            End If
            Return MyBase.OnClick(e)
        End Function
    End Class
End Namespace
