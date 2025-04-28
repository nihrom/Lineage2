using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class AllyDismiss
{
    public string ClanName;

    public AllyDismiss(Packet packet)
    {
        ClanName = packet.ReadString();
    }
}