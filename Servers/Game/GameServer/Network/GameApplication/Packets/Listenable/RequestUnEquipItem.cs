using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestUnEquipItem
{
    public RequestUnEquipItem(Packet packet)
    {
        var _slot = packet.ReadInt();
    }
}