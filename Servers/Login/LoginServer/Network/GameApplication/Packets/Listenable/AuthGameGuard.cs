using Common.Network;

namespace LoginServer.Network.GameApplication.Packets.Listenable;

public class AuthGameGuard
{
    public AuthGameGuard(Packet packet)
    {
        var _sessionId = packet.ReadInt();
        packet.ReadInt(); // data1
        packet.ReadInt(); // data2
        packet.ReadInt(); // data3
        packet.ReadInt(); // data4
    }
}