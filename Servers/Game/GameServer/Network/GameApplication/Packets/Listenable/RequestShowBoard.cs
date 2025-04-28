using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestShowBoard
{
    public RequestShowBoard(Packet packet)
    {
        packet.ReadInt(); // Unused.
    }
}