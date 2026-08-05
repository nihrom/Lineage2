using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable.Part9;

public class RequestGetBossRecord
{
    public int BossId;

    public RequestGetBossRecord(Packet packet)
    {
        BossId = packet.ReadInt();
    }
}