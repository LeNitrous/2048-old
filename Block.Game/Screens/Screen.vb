Imports osu.Framework.Allocation
Imports osu.Framework.Audio
Imports osu.Framework.Audio.Track
Imports osu.Framework.Graphics
Imports osu.Framework.Screens

Namespace Screens
    Public Class Screen : Inherits osu.Framework.Screens.Screen
        Public BGM As Track
        Protected TrackPath As String

        Public Sub New(Optional TrackPath As String = "")
            Me.TrackPath = TrackPath
        End Sub

        <BackgroundDependencyLoader>
        Private Sub Load(Audio As AudioManager)
            BGM = Audio.Track.Get(TrackPath)
        End Sub

        Public Overrides Sub OnEntering(last As IScreen)
            FadeInFromZero(250)
            If BGM IsNot Nothing Then
                BGM.Start()
            End If
            MyBase.OnEntering(last)
        End Sub

        Public Overrides Sub OnResuming(last As IScreen)
            FadeInFromZero(250)
            MyBase.OnResuming(last)
        End Sub

        Public Overrides Function OnExiting([next] As IScreen) As Boolean
            FadeOutFromOne(250)
            If BGM IsNot Nothing Then
                BGM.Stop()
            End If
            Return MyBase.OnExiting([next])
        End Function

        Public Overrides Sub OnSuspending([next] As IScreen)
            FadeOutFromOne(250)
            MyBase.OnSuspending([next])
        End Sub
    End Class
End Namespace
