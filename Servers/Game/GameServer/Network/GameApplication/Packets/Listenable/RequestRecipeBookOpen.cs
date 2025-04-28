using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestRecipeBookOpen
{
    public RequestRecipeBookOpen(Packet packet)
    {
        var _isDwarvenCraft = packet.ReadInt() == 0;
    }
}