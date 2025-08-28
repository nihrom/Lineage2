using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class GameGuardReply
{
    public byte[] Reply = new byte[8];
    
    public GameGuardReply(Packet packet)
    {
        Reply[0] = packet.ReadByte();
        Reply[1] = packet.ReadByte();
        Reply[2] = packet.ReadByte();
        Reply[3] = packet.ReadByte();
        packet.ReadInt();
        Reply[4] = packet.ReadByte();
        Reply[5] = packet.ReadByte();
        Reply[6] = packet.ReadByte();
        Reply[7] = packet.ReadByte();
    }
}