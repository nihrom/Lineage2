using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class ProtocolVersion
{
    public ProtocolVersion(Packet packet)
    {
        try
        {
            var _version = packet.ReadInt();
        }
        catch (Exception e)
        {
            _version = 0;
        }
    }
}