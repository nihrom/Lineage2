using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable.Part10;

public class RequestHennaItemList
{
    public RequestHennaItemList(Packet packet)
    {
        packet.ReadInt(); // Unknown.
    }
}