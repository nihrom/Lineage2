using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestHennaItemList
{
    public RequestHennaItemList(Packet packet)
    {
        packet.ReadInt(); // Unknown.
    }
}