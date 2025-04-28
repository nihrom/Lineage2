using Common.Network;

namespace LoginServer.Network.GameApplication.Packets.Listenable;

public class RequestServerList
{
    private int Skey1 { get; }
    
    private int Skey2 { get; }

    public RequestServerList(Packet packet)
    {
        Skey1 = packet.ReadInt(); // loginOk 1
        Skey2 = packet.ReadInt(); // loginOk 2
    }
}