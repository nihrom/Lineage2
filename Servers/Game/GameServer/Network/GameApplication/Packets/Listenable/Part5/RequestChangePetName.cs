using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestChangePetName
{
    public string Name;

    public RequestChangePetName(Packet packet)
    {
        Name = packet.ReadString();
    }
}