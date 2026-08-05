using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable.Part8;

public class RequestExPledgeCrestLarge
{
    public int CrestId;

    public RequestExPledgeCrestLarge(Packet packet)
    {
        CrestId = packet.ReadInt();
    }
}