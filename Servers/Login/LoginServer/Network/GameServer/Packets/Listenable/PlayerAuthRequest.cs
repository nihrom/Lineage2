using Common.Network;

namespace LoginServer.Network.GameServer.Packets.Listenable;

public class PlayerAuthRequest
{
    public PlayerAuthRequest(Packet packet)
    {
        string account = packet.ReadString();
        int playKey1 = packet.ReadInt();
        int playKey2 = packet.ReadInt();
        int loginKey1 = packet.ReadInt();
        int loginKey2 = packet.ReadInt();
    }
}