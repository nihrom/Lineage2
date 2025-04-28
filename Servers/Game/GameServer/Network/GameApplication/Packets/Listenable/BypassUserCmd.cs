using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class BypassUserCmd
{
    public int Command;

    public BypassUserCmd(Packet packet)
    {
        Command = packet.ReadInt();
    }
}