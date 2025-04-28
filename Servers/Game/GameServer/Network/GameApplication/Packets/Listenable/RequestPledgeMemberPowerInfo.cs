using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestPledgeMemberPowerInfo
{
    public int Unk1;
    public string Player;

    public RequestPledgeMemberPowerInfo(Packet packet)
    {
        Unk1 = packet.ReadInt();
        Player = packet.ReadString();
    }
}