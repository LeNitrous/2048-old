Imports ProtoBuf

Namespace Gameplay.Rules
    <ProtoContract>
    Public MustInherit Class GameRule
        <ProtoMember(1)>
        MustOverride ReadOnly Property ID As Integer
        <ProtoMember(2)>
        MustOverride ReadOnly Property Name As String
        <ProtoMember(3)>
        MustOverride ReadOnly Property Description As String

        MustOverride ReadOnly Property HasTimer As Boolean

        MustOverride ReadOnly Property HasMoves As Boolean

        MustOverride ReadOnly Property HasScore As Boolean

        MustOverride ReadOnly Property AllowUndo As Boolean
    End Class
End Namespace
