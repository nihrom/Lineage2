using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestPledgePower
{
    public int Rank;
    public int Action;
    public int Privs;

    public RequestPledgePower(Packet packet)
    {
        Rank = packet.ReadInt();
        Action = packet.ReadInt();
        if (Action == 2)
        {
            Privs = packet.ReadInt();
        }
        else
        {
            Privs = 0;
        }
    }
}