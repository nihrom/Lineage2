using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestSendFriendMsg
{
    public RequestSendFriendMsg(Packet packet)
    {
        _message = readString();
        _reciever = readString();
    }
}