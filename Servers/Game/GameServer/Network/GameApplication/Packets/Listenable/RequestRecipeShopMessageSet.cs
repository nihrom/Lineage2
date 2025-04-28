using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestRecipeShopMessageSet
{
    public RequestRecipeShopMessageSet(Packet packet)
    {
        var _name = packet.ReadString();
    }
}