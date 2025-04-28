using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class SnoopQuit
{
    public int SnoopId;

    public SnoopQuit(Packet packet)
    {
        SnoopId = packet.ReadInt();
    }
}