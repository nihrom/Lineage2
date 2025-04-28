using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestExPledgeCrestLarge
{
    public int CrestId;

    public RequestExPledgeCrestLarge(Packet packet)
    {
        CrestId = packet.ReadInt();
    }
}