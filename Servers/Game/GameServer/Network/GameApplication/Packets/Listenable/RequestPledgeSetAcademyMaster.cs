using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestPledgeSetAcademyMaster
{
    public int Set;
    public string CurrPlayerName;
    public string TargetPlayerName;

    public RequestPledgeSetAcademyMaster(Packet packet)
    {
        Set = packet.ReadInt();
        CurrPlayerName = packet.ReadString();
        TargetPlayerName = packet.ReadString();
    }
}