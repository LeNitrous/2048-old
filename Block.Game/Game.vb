Imports System.Reflection
Imports osu.Framework.Allocation
Imports osu.Framework.Graphics
Imports osu.Framework.Graphics.Containers
Imports osu.Framework.IO.Stores
Imports osu.Framework.Screens
Imports Block.Game.Graphics
Imports Block.Game.Rules
Imports Block.Game.Screens
Imports Block.Game.Screens.Menu

Public Class Game : Inherits osu.Framework.Game
    Private Shadows Dependencies As DependencyContainer

    Protected Overrides Function CreateChildDependencies(parent As IReadOnlyDependencyContainer) As IReadOnlyDependencyContainer
        Dependencies = New DependencyContainer(MyBase.CreateChildDependencies(parent))
        Return Dependencies
    End Function

    <BackgroundDependencyLoader>
    Private Sub Load()
        Resources.AddStore(New DllResourceStore("Block.Game.Resources.dll"))
        Fonts.AddStore(New GlyphStore(Resources, "Fonts/ClearSans"))
        Fonts.AddStore(New GlyphStore(Resources, "Fonts/ClearSans-Bold"))
        Fonts.AddStore(New GlyphStore(Resources, "Fonts/ClearSans-Italic"))
        Fonts.AddStore(New GlyphStore(Resources, "Fonts/ClearSans-Medium"))
        Fonts.AddStore(New GlyphStore(Resources, "Fonts/ClearSans-MediumItalic"))
        Fonts.AddStore(New GlyphStore(Resources, "Fonts/ClearSans-Thin"))

        Dim backgroundStack = New ScreenStack With {.RelativeSizeAxes = Axes.Both}
        Dim stack = New ScreenStack With {.RelativeSizeAxes = Axes.Both}

        Dependencies.Cache(New Colours())
        Dependencies.Cache(backgroundStack)
        Dependencies.Cache(GetAvailableRules())

        Child = New DrawSizePreservingFillContainer With {
            .RelativeSizeAxes = Axes.Both,
            .Children = New List(Of Drawable) From {
                backgroundStack,
                stack
            }
        }

        LoadComponentAsync(New Splash, Sub(s) stack.Push(s))
    End Sub

    Private Function GetAvailableRules() As List(Of GameRule)
        Dim Rules As New List(Of GameRule)
        Dim Found = Assembly.GetExecutingAssembly().GetTypes().Where(Function(t) String.Equals(t.Namespace, "Block.Game.Rules", StringComparison.Ordinal))
        For Each Instance In Found
            If Instance.IsSubclassOf(GetType(GameRule)) Then
                Rules.Add(CType(Activator.CreateInstance(Instance), GameRule))
            End If
        Next
        Return Rules
    End Function
End Class
