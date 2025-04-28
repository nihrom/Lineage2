using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestPledgeWarList
{
    public int Unk1;
    public int Tab;

    public RequestPledgeWarList(Packet packet)
    {
        Unk1 = packet.ReadInt();
        Tab = packet.ReadInt();
    }
}