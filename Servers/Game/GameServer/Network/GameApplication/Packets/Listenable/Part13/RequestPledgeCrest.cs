using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable.Part13;

public class RequestPledgeCrest
{
    public int CrestId;

    public RequestPledgeCrest(Packet packet)
    {
        CrestId = packet.ReadInt();
    }
}