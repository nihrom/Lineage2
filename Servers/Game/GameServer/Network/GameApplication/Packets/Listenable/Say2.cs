using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class Say2
{
    public Say2(Packet packet)
    {
        var _text = packet.ReadString();
        var _type = packet.ReadInt();
        var _target = (_type == ChatType.WHISPER.getClientId()) ? readString() : null;
    }
}