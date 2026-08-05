using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable.Part3;

public class ProtocolVersion
{
    public int Version;

    public ProtocolVersion(Packet packet)
    {
        try
        {
            Version = packet.ReadInt();
        }
        catch (Exception e)
        {
            Version = 0;
        }
    }
}