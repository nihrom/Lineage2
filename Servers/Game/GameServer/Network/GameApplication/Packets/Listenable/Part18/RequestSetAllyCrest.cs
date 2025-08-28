using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestSetAllyCrest
{
    public int Length;
    public byte[] Data;

    public RequestSetAllyCrest(Packet packet)
    {
        Length = packet.ReadInt();
        
        if (Length > 192)
        {
            return;
        }
        
        Data = packet.ReadBytesArray(Length);
    }
}