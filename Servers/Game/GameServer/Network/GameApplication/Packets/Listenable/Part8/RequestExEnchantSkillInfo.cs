using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable.Part8;

public class RequestExEnchantSkillInfo
{
    public int SkillId;
    public int SkillLevel;

    public RequestExEnchantSkillInfo(Packet packet)
    {
        SkillId = packet.ReadInt();
        SkillLevel = packet.ReadInt();
    }
}