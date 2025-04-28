using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestAutoSoulShot
{
    public RequestAutoSoulShot(Packet packet)
    {
        var _itemId = packet.ReadInt();
        var _type = packet.ReadInt();
    }
}