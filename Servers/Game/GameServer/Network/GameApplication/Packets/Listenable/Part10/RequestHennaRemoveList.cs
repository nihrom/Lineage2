using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable.Part10;

public class RequestHennaRemoveList
{
    public RequestHennaRemoveList(Packet packet)
    {
        packet.ReadInt(); // Unknown.
    }
}