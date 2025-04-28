using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestPledgeReorganizeMember
{
    public RequestPledgeReorganizeMember(Packet packet)
    {
        _isMemberSelected = readInt();
        _memberName = readString();
        _newPledgeType = readInt();
        _selectedMember = readString();
    }
}