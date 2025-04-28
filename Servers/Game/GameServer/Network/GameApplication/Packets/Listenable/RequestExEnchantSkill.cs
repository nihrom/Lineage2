using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestExEnchantSkill
{
    public int SkillId;
    public int SkillLevel;

    public RequestExEnchantSkill(Packet packet)
    {
        SkillId = packet.ReadInt();
        SkillLevel = packet.ReadInt();
    }
}