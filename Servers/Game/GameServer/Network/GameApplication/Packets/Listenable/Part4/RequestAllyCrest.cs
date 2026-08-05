using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable.Part4;

public class RequestAllyCrest
{
    public int CrestId;

    public RequestAllyCrest(Packet packet)
    {
        CrestId = packet.ReadInt();
    }
}