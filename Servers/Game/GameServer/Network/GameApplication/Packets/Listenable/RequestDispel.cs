using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestDispel
{
    public int SkillId;
    public int SkillLevel;

    public RequestDispel(Packet packet)
    {
        SkillId = packet.ReadInt();
        SkillLevel = packet.ReadInt();
    }
}