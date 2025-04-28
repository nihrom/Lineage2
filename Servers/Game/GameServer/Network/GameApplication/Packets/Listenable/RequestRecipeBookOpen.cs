using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestRecipeBookOpen
{
    public RequestRecipeBookOpen(Packet packet)
    {
        _isDwarvenCraft = readInt() == 0;
    }
}