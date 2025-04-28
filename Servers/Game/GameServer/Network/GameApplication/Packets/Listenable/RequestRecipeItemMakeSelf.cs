using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestRecipeItemMakeSelf
{
    public int Id;

    public RequestRecipeItemMakeSelf(Packet packet)
    {
        Id = packet.ReadInt();
    }
}