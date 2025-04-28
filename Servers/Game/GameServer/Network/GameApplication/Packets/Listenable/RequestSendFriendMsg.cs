using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestSendFriendMsg
{
    public RequestSendFriendMsg(Packet packet)
    {
        var _message = packet.ReadString();
        var _reciever = packet.ReadString();
    }
}