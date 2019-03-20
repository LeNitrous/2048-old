Imports osu.Framework.Graphics
Imports osu.Framework.Screens

Namespace Screens
    Public Class Screen : Inherits osu.Framework.Screens.Screen
        Public Overrides Sub OnEntering(last As IScreen)
            FadeInFromZero(250)
            MyBase.OnEntering(last)
        End Sub

        Public Overrides Sub OnResuming(last As IScreen)
            FadeInFromZero(250)
            MyBase.OnResuming(last)
        End Sub
    End Class
End Namespace
