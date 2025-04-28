using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestRecipeShopMakeInfo
{
    public RequestRecipeShopMakeInfo(Packet packet)
    {
        var _playerObjectId = packet.ReadInt();
        var _recipeId = packet.ReadInt();
    }
}