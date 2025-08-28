using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestSendFriendMsg
{
    public string Message;
    public string Reciever;

    public RequestSendFriendMsg(Packet packet)
    {
        Message = packet.ReadString();
        Reciever = packet.ReadString();
    }
}