using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestSetPledgeCrest
{
    public byte[] Data;

    public RequestSetPledgeCrest(Packet packet)
    {
        var length = packet.ReadInt();
        if (length > 256)
        {
            return;
        }
        
        Data = packet.ReadBytesArray(length);
    }
}