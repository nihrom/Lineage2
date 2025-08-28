using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class AuthLogin
{
    public string LoginName;
    public int PlayKey2;
    public int PlayKey1;
    public int LoginKey1;
    public int LoginKey2;

    public AuthLogin(Packet packet)
    {
        LoginName = packet.ReadString().ToLower();
        PlayKey2 = packet.ReadInt();
        PlayKey1 = packet.ReadInt();
        LoginKey1 = packet.ReadInt();
        LoginKey2 = packet.ReadInt();
    }
}