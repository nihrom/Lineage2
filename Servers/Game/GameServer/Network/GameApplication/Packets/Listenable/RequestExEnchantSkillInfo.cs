using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestExEnchantSkillInfo
{
    public RequestExEnchantSkillInfo(Packet packet)
    {
        _skillId = readInt();
        _skillLevel = readInt();
    }
}