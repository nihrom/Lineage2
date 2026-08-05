using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable.Part18;

public class RequestShowBoard
{
    public RequestShowBoard(Packet packet)
    {
        packet.ReadInt(); // Unused.
    }
}