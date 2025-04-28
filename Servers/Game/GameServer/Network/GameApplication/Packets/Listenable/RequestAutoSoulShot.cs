using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestAutoSoulShot
{
    public int ItemId;
    public int Type;

    public RequestAutoSoulShot(Packet packet)
    {
        ItemId = packet.ReadInt();
        Type = packet.ReadInt();
    }
}