using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestReplySurrenderPledgeWar
{
    public string ReqName;
    public int Answer;

    public RequestReplySurrenderPledgeWar(Packet packet)
    {
        ReqName = packet.ReadString();
        Answer = packet.ReadInt();
    }
}