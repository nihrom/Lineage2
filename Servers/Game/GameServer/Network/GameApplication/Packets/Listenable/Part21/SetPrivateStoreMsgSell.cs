using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class SetPrivateStoreMsgSell
{
    public string StoreMsg;

    public SetPrivateStoreMsgSell(Packet packet)
    {
        StoreMsg = packet.ReadString();
    }
}