using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestExEnchantSkill
{
    public RequestExEnchantSkill(Packet packet)
    {
        _skillId = readInt();
        _skillLevel = readInt();
    }
}