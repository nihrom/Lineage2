using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestRecipeItemMakeSelf
{
    public RequestRecipeItemMakeSelf(Packet packet)
    {
        var _id = packet.ReadInt();
    }
}