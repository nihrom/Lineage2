using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class MultiSellChoose
{
    public MultiSellChoose(Packet packet)
    {
        var _listId = packet.ReadInt();
        var _entryId = packet.ReadInt();
        var _amount = packet.ReadInt();
    }
}