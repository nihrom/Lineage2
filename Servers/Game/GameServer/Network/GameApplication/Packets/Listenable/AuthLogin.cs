using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class AuthLogin
{
    public AuthLogin(Packet packet)
    {
        var _loginName = packet.ReadString().toLowerCase();
        var _playKey2 = packet.ReadInt();
        var _playKey1 = packet.ReadInt();
        var _loginKey1 = packet.ReadInt();
        var _loginKey2 = packet.ReadInt();
    }
}