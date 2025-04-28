using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestDeleteMacro
{
    public int Id;

    public RequestDeleteMacro(Packet packet)
    {
        Id = packet.ReadInt();
    }
}