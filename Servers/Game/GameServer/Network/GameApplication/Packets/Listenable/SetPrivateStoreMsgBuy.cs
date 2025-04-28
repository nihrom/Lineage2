using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class SetPrivateStoreMsgBuy
{
    public SetPrivateStoreMsgBuy(Packet packet)
    {
        _storeMsg = readString();
    }
}