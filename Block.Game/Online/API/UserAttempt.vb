Imports ProtoBuf

Namespace Online.API
    <ProtoContract>
    Public Class UserAttempt
        <ProtoMember(1)>
        Public Property Name As String
        <ProtoMember(2)>
        Public Property Moves As Integer
        <ProtoMember(3)>
        Public Property Score As Integer
        <ProtoMember(4)>
        Public Property GridSize As Integer
        <ProtoMember(5)>
        Public Property GameType As Integer
        <ProtoMember(6)>
        Public Property TimeSpent As Integer
        <ProtoMember(7)>
        Public Property TimeAchieved As Integer
    End Class
End Namespace
