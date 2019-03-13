Imports System.Reflection
Imports osu.Framework.Screens
Imports osu.Framework.Allocation
Imports osu.Framework.Graphics
Imports osu.Framework.Graphics.Sprites
Imports Block.Game.Graphics
Imports Block.Game.Rules
Imports Block.Game.Screens.Play

Namespace Screens.Menu
    Public Class MainMenu : Inherits Screen
        Public MainSystem As MenuButtonGroup
        Public PlaySystem As MenuButtonGroup
        Public ModeSystem As MenuButtonGroup
        Public LeadSystem As MenuButtonGroup

        <Resolved>
        Private Property Stack As ScreenStack

        <BackgroundDependencyLoader>
        Private Sub Load(ByVal colour As BlockColour)
            MainSystem = New MenuButtonGroup
            MainSystem.AddButtonRange(New List(Of MenuButton) From {
                New MenuButton("exit", "leaving so soon?"),
                New MenuButton("play", "some classic 2048", Sub() MainSystem.SwitchTo(PlaySystem))
            })

            PlaySystem = New MenuButtonGroup(1)
            PlaySystem.AddButtonRange(New List(Of MenuButton) From {
                New MenuButton("back", "", Sub() MainSystem.Back()),
                New MenuButton("solo", "you alone", Sub() PlaySystem.SwitchTo(ModeSystem))
            })

            ModeSystem = New MenuButtonGroup(1)
            ModeSystem.AddButton(New MenuButton("back", "", Sub() PlaySystem.Back()))
            For Each Rule As Type In GetGameRules()
                If Rule.IsSubclassOf(GetType(GameRule)) Then
                    Dim gamerule = CType(Activator.CreateInstance(Rule), GameRule)
                    ModeSystem.AddButton(New MenuButton(gamerule.Name.ToLower(), gamerule.Description, Sub() OnPlay(gamerule),
                                                        String.Format("mode-{0}", gamerule.Name.ToLower().Replace(" ", String.Empty))))
                End If
            Next

            LeadSystem = New MenuButtonGroup(1)
            LeadSystem.AddButtonRange(New List(Of MenuButton) From {
                New MenuButton("back", "", Sub() MainSystem.Back()),
                New MenuButton("local", "local ranking"),
                New MenuButton("global", "world ranking")
            })

            Content.AddRange(New List(Of Drawable) From {
                New SpriteText With {
                    .Anchor = Anchor.Centre,
                    .Origin = Anchor.Centre,
                    .Text = "2048",
                    .Font = New FontUsage("ClearSans", 192, "Bold"),
                    .Colour = colour.FromHex("#776e65"),
                    .Y = -150
                },
                MainSystem,
                LeadSystem,
                PlaySystem,
                ModeSystem
            })
        End Sub

        Private Sub OnPlay(ByVal rule As IGameRule, Optional ByVal size As Integer = 4)
            Stack.Exit()
            Stack.Push(New Player(rule, 4))
        End Sub

        Private Function GetGameRules() As IEnumerable(Of Type)
            Return Assembly.GetExecutingAssembly().GetTypes().Where(Function(t) String.Equals(t.Namespace, "Block.Game.Rules", StringComparison.Ordinal))
        End Function
    End Class
End Namespace
