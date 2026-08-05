using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable.Part8;

public class RequestExOustFromMPCC
{
    public string Name;

    public RequestExOustFromMPCC(Packet packet)
    {
        Name = packet.ReadString();
    }
}