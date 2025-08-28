using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestExOustFromMPCC
{
    public string Name;

    public RequestExOustFromMPCC(Packet packet)
    {
        Name = packet.ReadString();
    }
}