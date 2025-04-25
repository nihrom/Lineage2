using Common.Network;

namespace LoginServer.Network.GameServer.Packets.Listenable;

public class RequestTempBan
{
    public RequestTempBan(Packet packet)
    {
        var accountName = packet.ReadString();
        var _ip = packet.ReadString();
        var _banTime = packet.ReadLong();
        bool haveReason = packet.ReadByte() != 0;
        
        if (haveReason)
        {
            packet.ReadString(); // _banReason
        }
    }
}