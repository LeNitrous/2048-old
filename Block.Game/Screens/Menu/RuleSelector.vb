Imports osu.Framework.Allocation
Imports osu.Framework.Bindables
Imports osu.Framework.Graphics
Imports osu.Framework.Graphics.Containers
Imports osu.Framework.Graphics.Sprites
Imports osu.Framework.Graphics.Textures
Imports osu.Framework.Input.Events
Imports Block.Game.Bindables
Imports Block.Game.Gameplay.Rules
Imports Block.Game.Graphics
Imports Block.Game.Graphics.UserInterface
Imports osuTK
Imports osuTK.Graphics

Namespace Screens.Menu
    Public Class RuleSelector : Inherits Container
        Public SelectRule As Action(Of GameRule)
        Private SelectedRuleId As WrappingBindableInt
        Private RuleSelected As SelectorSelectButton
        Private RuleNameSprite As SpriteText
        Private RuleDescSprite As SpriteText
        Private RuleIconSprite As Sprite

        <Resolved>
        Private Property Store As TextureStore

        <Resolved>
        Private Property Colours As Colours

        <Resolved>
        Private Property Rules As List(Of GameRule)

        <BackgroundDependencyLoader>
        Private Sub Load()
            Size = New Vector2(600, 200)
            RuleNameSprite = New SpriteText With {
                .Anchor = Anchor.BottomCentre,
                .Origin = Anchor.BottomCentre,
                .Colour = Colours.DarkestBrown,
                .Font = New FontUsage("ClearSans", 36, "Bold"),
                .Y = 40
            }
            RuleDescSprite = New SpriteText With {
                .Anchor = Anchor.BottomCentre,
                .Origin = Anchor.BottomCentre,
                .Colour = Colours.DarkestBrown,
                .Alpha = 0.8,
                .Font = New FontUsage("ClearSans", 20),
                .Y = 54
            }
            RuleIconSprite = New Sprite With {
                .Anchor = Anchor.Centre,
                .Origin = Anchor.Centre,
                .Size = New Vector2(120)
            }
            RuleSelected = New SelectorSelectButton With {
                .Anchor = Anchor.Centre,
                .Origin = Anchor.Centre,
                .ClickAction = AddressOf OnSelectRule
            }
            Children = New List(Of Drawable) From {
                New TextureButton With {
                    .Icon = "back",
                    .ClickAction = Sub() SelectedRuleId.Add(-1),
                    .BaseColour = Colours.DarkerBrown,
                    .Anchor = Anchor.CentreLeft,
                    .Origin = Anchor.CentreLeft,
                    .Size = New Vector2(140)
                },
                RuleSelected,
                New TextureButton With {
                    .Icon = "back",
                    .ClickAction = Sub() SelectedRuleId.Add(1),
                    .BaseColour = Colours.DarkerBrown,
                    .Anchor = Anchor.CentreRight,
                    .Origin = Anchor.CentreRight,
                    .Size = New Vector2(140),
                    .Flipped = True
                },
                RuleIconSprite,
                RuleNameSprite,
                RuleDescSprite
            }
            SelectedRuleId = New WrappingBindableInt With {
                .MinValue = 0,
                .MaxValue = Rules.Count - 1
            }
            AddHandler RuleSelected.CurrentRule.ValueChanged, AddressOf OnChangeRule
            AddHandler SelectedRuleId.ValueChanged, AddressOf OnChangeSelectedId
            RuleSelected.CurrentRule.Value = Rules.FirstOrDefault()
        End Sub

        Public Function GetSelectedRule() As GameRule
            Return If(Rules.ElementAtOrDefault(SelectedRuleId.Value), 0)
        End Function

        Private Sub OnChangeRule(ByVal rule As ValueChangedEvent(Of GameRule))
            RuleIconSprite.ClearTransforms()
            RuleIconSprite.Texture = Store.Get("Interface/mode-" & rule.NewValue.Name.ToLower().Replace(" ", String.Empty))
            RuleIconSprite.Scale = New Vector2(0.8)
            RuleIconSprite.ScaleTo(Vector2.One, 1000, Easing.OutElastic)
            RuleNameSprite.Text = rule.NewValue.Name.ToUpper()
            RuleDescSprite.Text = rule.NewValue.Description.ToLower()
        End Sub

        Private Sub OnChangeSelectedId(ByVal value As ValueChangedEvent(Of Integer))
            RuleSelected.CurrentRule.Value = If(Rules.ElementAtOrDefault(value.NewValue), 0)
        End Sub

        Private Sub OnSelectRule()
            If Not SelectRule Is Nothing Then
                SelectRule.Invoke(RuleSelected.CurrentRule.Value)
            End If
        End Sub

        Private Class SelectorSelectButton : Inherits MenuButton
            Public CurrentRule As Bindable(Of GameRule)

            <BackgroundDependencyLoader>
            Private Sub Load(ByVal colours As Colours)
                CurrentRule = New Bindable(Of GameRule)
                Size = New Vector2(140)
            End Sub
        End Class
    End Class
End Namespace
