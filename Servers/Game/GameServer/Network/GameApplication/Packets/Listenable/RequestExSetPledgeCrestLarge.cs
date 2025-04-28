using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestExSetPledgeCrestLarge
{
    public byte[] Data;

    public RequestExSetPledgeCrestLarge(Packet packet)
    {
        var length = packet.ReadInt();
        
        if (length > 2176)
        {
            return;
        }
        
        Data = packet.ReadBytesArray(length);
    }
}