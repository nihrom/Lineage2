using Common.Network;

namespace LoginServer.Network.GameApplication.Packets.Listenable;

public class AuthGameGuard
{
    public int SessionId { get; }

    public AuthGameGuard(Packet packet)
    {
        SessionId = packet.ReadInt();
        packet.ReadInt(); // data1
        packet.ReadInt(); // data2
        packet.ReadInt(); // data3
        packet.ReadInt(); // data4
    }
}