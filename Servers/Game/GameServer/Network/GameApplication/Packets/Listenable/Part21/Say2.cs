using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class Say2
{
    public string Text;
    public int Type;

    public Say2(Packet packet)
    {
        // Text = packet.ReadString();
        // Type = packet.ReadInt();
        // var _target = (Type == ChatType.WHISPER.getClientId()) ? readString() : null;
    }
}