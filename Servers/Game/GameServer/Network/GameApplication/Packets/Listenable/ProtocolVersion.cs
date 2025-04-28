using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

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
            _version = 0;
        }
    }
}