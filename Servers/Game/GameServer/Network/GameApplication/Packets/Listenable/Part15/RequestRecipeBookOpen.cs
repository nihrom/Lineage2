using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable.Part15;

public class RequestRecipeBookOpen
{
    public bool IsDwarvenCraft;

    public RequestRecipeBookOpen(Packet packet)
    {
        IsDwarvenCraft = packet.ReadInt() == 0;
    }
}