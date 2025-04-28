using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestRecipeShopMakeInfo
{
    public RequestRecipeShopMakeInfo(Packet packet)
    {
        _playerObjectId = readInt();
        _recipeId = readInt();
    }
}