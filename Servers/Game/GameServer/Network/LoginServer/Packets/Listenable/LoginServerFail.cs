using Common.Network;

namespace GameServer.Network.LoginServer.Packets.Listenable;

public class LoginServerFail
{
    public int Reason { get; }

    public LoginServerFail(Packet packet)
    {
        Reason = packet.ReadByte();
    }
}