Imports osu.Framework.Allocation
Imports osu.Framework.Graphics
Imports osu.Framework.Graphics.Containers
Imports osu.Framework.Graphics.Shapes
Imports osu.Framework.Graphics.Sprites
Imports osu.Framework.Graphics.Textures
Imports osu.Framework.Screens
Imports Block.Game.Graphics
Imports Block.Game.Graphics.Shapes
Imports Block.Game.Graphics.UserInterface
Imports Block.Game.Online
Imports Block.Game.Screens
Imports osuTK
Imports LiteDB

Namespace Screens.Leaderboard
    Public Class Leaderboard : Inherits Screen
        <Resolved>
        Private Property Database As DatabaseContext

        <BackgroundDependencyLoader>
        Private Sub Load(colours As Colours)
            Dim scores = Database.Attempts.FindAll().OrderBy(Function(x) x.Elapsed).ToList()
            InternalChildren = New List(Of Drawable) From {
                New SpriteText With {
                    .Text = "Leaderboard",
                    .Anchor = Anchor.TopCentre,
                    .Origin = Anchor.TopCentre,
                    .Font = New FontUsage("ClearSans", 72, "Bold"),
                    .Position = New Vector2(0, 6),
                    .Colour = colours.DarkerBrown
                },
                New Button("Back", Sub() [Exit]()) With {
                    .Anchor = Anchor.BottomLeft,
                    .Origin = Anchor.BottomLeft
                },
                New Listing(scores) With {
                    .Anchor = Anchor.Centre,
                    .Origin = Anchor.Centre
                }
            }
        End Sub
    End Class
End Namespace
