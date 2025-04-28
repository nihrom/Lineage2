using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestRecipeItemMakeInfo
{
    public int Id;

    public RequestRecipeItemMakeInfo(Packet packet)
    {
        Id = packet.ReadInt();
    }
}