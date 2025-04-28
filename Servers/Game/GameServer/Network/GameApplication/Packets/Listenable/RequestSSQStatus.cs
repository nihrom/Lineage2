using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestSSQStatus
{
    public byte Page;

    public RequestSSQStatus(Packet packet)
    {
        Page = packet.ReadByte();
    }
}