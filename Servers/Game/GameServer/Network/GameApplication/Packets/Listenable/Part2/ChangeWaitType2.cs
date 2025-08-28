using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class ChangeWaitType2
{
    public bool TypeStand;

    public ChangeWaitType2(Packet packet)
    {
        TypeStand = packet.ReadInt() == 1;
    }
}