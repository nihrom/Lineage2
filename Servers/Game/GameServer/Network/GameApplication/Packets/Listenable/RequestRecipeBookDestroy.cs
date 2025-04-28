using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestRecipeBookDestroy
{
    public RequestRecipeBookDestroy(Packet packet)
    {
        var _recipeID = packet.ReadInt();
    }
}