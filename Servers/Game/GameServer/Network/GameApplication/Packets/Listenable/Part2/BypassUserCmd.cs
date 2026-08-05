using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable.Part2;

public class BypassUserCmd
{
    public int Command;

    public BypassUserCmd(Packet packet)
    {
        Command = packet.ReadInt();
    }
}