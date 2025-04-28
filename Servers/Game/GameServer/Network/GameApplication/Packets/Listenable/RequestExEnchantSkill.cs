using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestExEnchantSkill
{
    public RequestExEnchantSkill(Packet packet)
    {
        var _skillId = packet.ReadInt();
        var _skillLevel = packet.ReadInt();
    }
}