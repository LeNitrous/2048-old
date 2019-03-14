Imports System.Reflection
Imports osu.Framework.Allocation
Imports osu.Framework.Graphics
Imports osu.Framework.Graphics.Containers
Imports osu.Framework.Graphics.Shapes
Imports osu.Framework.IO.Stores
Imports osu.Framework.Screens
Imports Block.Game.Graphics
Imports Block.Game.Rules
Imports Block.Game.Online.API
Imports Block.Game.Screens.Menu

Public Class BlockGame : Inherits osu.Framework.Game
    Private Shadows Dependencies As DependencyContainer

    Protected Overrides Function CreateChildDependencies(parent As IReadOnlyDependencyContainer) As IReadOnlyDependencyContainer
        Dependencies = New DependencyContainer(MyBase.CreateChildDependencies(parent))
        Return Dependencies
    End Function

    Public Sub New()
        Name = "lazer2048"
    End Sub

    <BackgroundDependencyLoader>
    Private Sub Load()
        Resources.AddStore(New DllResourceStore("Block.Game.Resources.dll"))
        Fonts.AddStore(New GlyphStore(Resources, "Fonts/ClearSans"))
        Fonts.AddStore(New GlyphStore(Resources, "Fonts/ClearSans-Bold"))
        Fonts.AddStore(New GlyphStore(Resources, "Fonts/ClearSans-Italic"))
        Fonts.AddStore(New GlyphStore(Resources, "Fonts/ClearSans-Medium"))
        Fonts.AddStore(New GlyphStore(Resources, "Fonts/ClearSans-MediumItalic"))
        Fonts.AddStore(New GlyphStore(Resources, "Fonts/ClearSans-Thin"))

        Dim stack = New ScreenStack With {
            .RelativeSizeAxes = Axes.Both
        }
        stack.Push(New MainMenu)

        Dim blockColour = New BlockColour()

        Child = New DrawSizePreservingFillContainer With {
            .RelativeSizeAxes = Axes.Both,
            .Children = New List(Of Drawable) From {
                New Box With {
                    .RelativeSizeAxes = Axes.Both,
                    .Colour = blockColour.FromHex("faf8ef")
                },
                Stack
            }
        }

        Dependencies.Cache(New API)
        Dependencies.Cache(stack)
        Dependencies.Cache(blockColour)
        Dependencies.Cache(GetAvailableRules())
    End Sub

    Private Function GetAvailableRules() As List(Of GameRule)
        Dim rules As New List(Of GameRule)
        Dim found = Assembly.GetExecutingAssembly().GetTypes().Where(Function(t) String.Equals(t.Namespace, "Block.Game.Rules", StringComparison.Ordinal))
        For Each instance In found
            If instance.IsSubclassOf(GetType(GameRule)) Then
                rules.Add(CType(Activator.CreateInstance(instance), GameRule))
            End If
        Next
        Return rules
    End Function
End Class
