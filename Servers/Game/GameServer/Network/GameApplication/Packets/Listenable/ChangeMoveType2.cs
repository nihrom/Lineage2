using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class ChangeMoveType2
{
    public ChangeMoveType2(Packet packet)
    {
        var _typeRun = packet.ReadInt() == 1;
    }
}