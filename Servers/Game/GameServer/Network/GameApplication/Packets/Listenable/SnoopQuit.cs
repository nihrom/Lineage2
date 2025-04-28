using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class SnoopQuit
{
    public SnoopQuit(Packet packet)
    {
        var _snoopID = packet.ReadInt();
    }
}