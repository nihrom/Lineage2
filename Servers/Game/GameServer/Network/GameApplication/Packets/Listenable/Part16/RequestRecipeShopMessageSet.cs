using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable.Part16;

public class RequestRecipeShopMessageSet
{
    public string Name;

    public RequestRecipeShopMessageSet(Packet packet)
    {
        Name = packet.ReadString();
    }
}