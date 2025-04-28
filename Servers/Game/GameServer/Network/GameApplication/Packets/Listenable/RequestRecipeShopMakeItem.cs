using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestRecipeShopMakeItem
{
    public RequestRecipeShopMakeItem(Packet packet)
    {
        var _id = packet.ReadInt();
        var _recipeId = packet.ReadInt();
        var _unknown = packet.ReadInt();
    }
}