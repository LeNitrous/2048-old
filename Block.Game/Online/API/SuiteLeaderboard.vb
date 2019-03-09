Imports ProtoBuf

Namespace Online.API
    <ProtoContract>
    Public Class SuiteLeaderboard
        <ProtoMember(1)>
        Public Property GridSize As Integer
        <ProtoMember(2)>
        Public Property GameType As Integer
        <ProtoMember(3)>
        Public Property Listing As Dictionary(Of Integer, UserAttempt)
    End Class
End Namespace
