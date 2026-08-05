using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable.Part21;

public class SnoopQuit
{
    public int SnoopId;

    public SnoopQuit(Packet packet)
    {
        SnoopId = packet.ReadInt();
    }
}