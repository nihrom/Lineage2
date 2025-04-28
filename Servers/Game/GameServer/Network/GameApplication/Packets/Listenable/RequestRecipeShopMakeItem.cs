using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestRecipeShopMakeItem
{
    public int Id;
    public int RecipeId;
    public int Unknown;

    public RequestRecipeShopMakeItem(Packet packet)
    {
        Id = packet.ReadInt();
        RecipeId = packet.ReadInt();
        Unknown = packet.ReadInt();
    }
}