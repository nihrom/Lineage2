using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class ChangeMoveType2
{
    public bool TypeRun;

    public ChangeMoveType2(Packet packet)
    {
        TypeRun = packet.ReadInt() == 1;
    }
}