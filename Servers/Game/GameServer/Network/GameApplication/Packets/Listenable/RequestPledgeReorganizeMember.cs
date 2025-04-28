using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestPledgeReorganizeMember
{
    public RequestPledgeReorganizeMember(Packet packet)
    {
        var _isMemberSelected = packet.ReadInt();
        var _memberName = packet.ReadString();
        var _newPledgeType = packet.ReadInt();
        var _selectedMember = packet.ReadString();
    }
}