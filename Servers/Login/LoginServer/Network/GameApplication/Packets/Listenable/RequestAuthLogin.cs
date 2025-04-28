using Common.Network;

namespace LoginServer.Network.GameApplication.Packets.Listenable;

public class RequestAuthLogin
{
    public byte[] Raw1 { get; } = new byte[128];
    
    public byte[] Raw2 { get; } = new byte[128];
    
    public bool NewAuthMethod { get; } = false;
    
    public RequestAuthLogin(Packet packet)
    {
        if (packet.GetBuffer().Length >= 256)
        {
            NewAuthMethod = true;
            Raw1 = packet.ReadBytesArray(128);
            Raw2 = packet.ReadBytesArray(128);
        }
        else if (packet.GetBuffer().Length >= 128)
        {
            NewAuthMethod = false;
            Raw1 = packet.ReadBytesArray(128);
        }
    }
}