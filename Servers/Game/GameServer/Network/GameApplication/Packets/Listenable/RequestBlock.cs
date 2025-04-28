using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestBlock
{
    public RequestBlock(Packet packet)
    {
        // _type = readInt(); // 0x00 - block, 0x01 - unblock, 0x03 - allblock, 0x04 - allunblock
        // if ((_type == BLOCK) || (_type == UNBLOCK))
        // {
        //     _name = readString();
        // }
    }
}