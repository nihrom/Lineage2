using Common.Network;

namespace LoginServer.Network.GameApplication.Packets.Listenable;

public class RequestServerList
{
    public int Skey1 { get; }
    
    public int Skey2 { get; }

    public RequestServerList(Packet packet)
    {
        Skey1 = packet.ReadInt(); // loginOk 1
        Skey2 = packet.ReadInt(); // loginOk 2
    }
}