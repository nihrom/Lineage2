using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestPledgeMemberInfo
{
    public int Unk1;
    public string Player;

    public RequestPledgeMemberInfo(Packet packet)
    {
        Unk1 = packet.ReadInt();
        Player = packet.ReadString();
    }
}