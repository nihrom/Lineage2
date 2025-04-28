using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestDeleteMacro
{
    public RequestDeleteMacro(Packet packet)
    {
        var _id = packet.ReadInt();
    }
}