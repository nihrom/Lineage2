using Common.Network;

namespace LoginServer.Network.GameApplication.Packets.Listenable;

public class RequestAuthLogin
{
    public byte[] Raw { get; }
    
    public RequestAuthLogin(Packet packet)
    {
        Raw = packet.ReadByteArrayAlt(256);
    }
}