using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class SnoopQuit
{
    public SnoopQuit(Packet packet)
    {
        _snoopID = readInt();
    }
}