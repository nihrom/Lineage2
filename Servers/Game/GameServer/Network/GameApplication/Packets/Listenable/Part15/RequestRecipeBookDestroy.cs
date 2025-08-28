using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestRecipeBookDestroy
{
    public int RecipeId;

    public RequestRecipeBookDestroy(Packet packet)
    {
        RecipeId = packet.ReadInt();
    }
}