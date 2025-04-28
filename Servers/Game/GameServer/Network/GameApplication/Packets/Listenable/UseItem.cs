using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class UseItem
{
    public UseItem(Packet packet)
    {
        var _objectId = packet.ReadInt();
        var _ctrlPressed = packet.ReadInt() != 0;
    }
}