using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestRecipeShopMakeInfo
{
    public int PlayerObjectId;
    public int RecipeId;

    public RequestRecipeShopMakeInfo(Packet packet)
    {
        PlayerObjectId = packet.ReadInt();
        RecipeId = packet.ReadInt();
    }
}