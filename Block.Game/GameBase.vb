Imports System.Reflection
Imports osu.Framework.Allocation
Imports osu.Framework.IO.Stores
Imports Block.Game.Gameplay.Rules
Imports Block.Game.Graphics

Public Class GameBase : Inherits osu.Framework.Game
    Protected Shadows Dependencies As DependencyContainer

    Protected Overrides Function CreateChildDependencies(parent As IReadOnlyDependencyContainer) As IReadOnlyDependencyContainer
        Dependencies = New DependencyContainer(MyBase.CreateChildDependencies(parent))
        Return Dependencies
    End Function

    <BackgroundDependencyLoader>
    Private Sub Load()
        Resources.AddStore(New DllResourceStore("Block.Game.Resources.dll"))
        Fonts = New FontStore(New GlyphStore(Resources, "Fonts/ClearSans"))
        Dependencies.Cache(Fonts)
        Fonts.AddStore(New GlyphStore(Resources, "Fonts/ClearSans"))
        Fonts.AddStore(New GlyphStore(Resources, "Fonts/ClearSans-Bold"))
        Fonts.AddStore(New GlyphStore(Resources, "Fonts/ClearSans-Italic"))
        Fonts.AddStore(New GlyphStore(Resources, "Fonts/ClearSans-Medium"))
        Fonts.AddStore(New GlyphStore(Resources, "Fonts/ClearSans-MediumItalic"))
        Fonts.AddStore(New GlyphStore(Resources, "Fonts/ClearSans-Thin"))
        Dependencies.Cache(New Colours())
        Dependencies.Cache(GetAvailableRules())
    End Sub

    Private Function GetAvailableRules() As List(Of GameRule)
        Dim Rules As New List(Of GameRule)
        Dim Found = Assembly.GetExecutingAssembly().GetTypes().Where(Function(t) String.Equals(t.Namespace, "Block.Game.Gameplay.Rules", StringComparison.Ordinal))
        For Each Instance In Found
            If Instance.IsSubclassOf(GetType(GameRule)) Then
                Rules.Add(CType(Activator.CreateInstance(Instance), GameRule))
            End If
        Next
        Return Rules
    End Function
End Class
