using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestRecipeShopMakeItem
{
    public RequestRecipeShopMakeItem(Packet packet)
    {
        _id = readInt();
        _recipeId = readInt();
        _unknown = readInt();
    }
}