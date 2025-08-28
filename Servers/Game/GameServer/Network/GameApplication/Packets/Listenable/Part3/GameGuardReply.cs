using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class GameGuardReply
{
    public GameGuardReply(Packet packet)
    {
        _reply[0] = packet.ReadByte();
        _reply[1] = packet.ReadByte();
        _reply[2] = packet.ReadByte();
        _reply[3] = packet.ReadByte();
        packet.ReadInt();
        _reply[4] = packet.ReadByte();
        _reply[5] = packet.ReadByte();
        _reply[6] = packet.ReadByte();
        _reply[7] = packet.ReadByte();
    }
}