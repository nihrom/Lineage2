using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestPledgeReorganizeMember
{
    public int IsMemberSelected;
    public string MemberName;
    public int NewPledgeType;
    public string SelectedMember;

    public RequestPledgeReorganizeMember(Packet packet)
    {
        IsMemberSelected = packet.ReadInt();
        MemberName = packet.ReadString();
        NewPledgeType = packet.ReadInt();
        SelectedMember = packet.ReadString();
    }
}