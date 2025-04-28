using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class SetPrivateStoreMsgSell
{
    public SetPrivateStoreMsgSell(Packet packet)
    {
        var _storeMsg = packet.ReadString();
    }
}