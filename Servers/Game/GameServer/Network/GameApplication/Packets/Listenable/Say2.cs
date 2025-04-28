using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class Say2
{
    public Say2(Packet packet)
    {
        _text = readString();
        _type = readInt();
        _target = (_type == ChatType.WHISPER.getClientId()) ? readString() : null;
    }
}