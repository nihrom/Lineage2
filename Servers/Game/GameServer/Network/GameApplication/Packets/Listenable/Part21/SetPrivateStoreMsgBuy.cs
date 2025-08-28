using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class SetPrivateStoreMsgBuy
{
    public string StoreMsg;

    public SetPrivateStoreMsgBuy(Packet packet)
    {
        StoreMsg = packet.ReadString();
    }
}