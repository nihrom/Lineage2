using Common.Network;

namespace LoginServer.Network.GameApplication.Packets.Listenable;

public class RequestServerLogin
{
    public int Skey1 { get; }
    
    public int Skey2 { get; }

    public int ServerId { get; }

    public RequestServerLogin(Packet packet)
    {
        Skey1 = packet.ReadInt();
        Skey2 = packet.ReadInt();
        ServerId = packet.ReadByte();
    }
}