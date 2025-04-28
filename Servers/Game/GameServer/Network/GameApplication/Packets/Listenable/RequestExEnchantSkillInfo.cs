using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestExEnchantSkillInfo
{
    public RequestExEnchantSkillInfo(Packet packet)
    {
        var _skillId = packet.ReadInt();
        var _skillLevel = packet.ReadInt();
    }
}