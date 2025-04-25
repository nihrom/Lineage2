using Common.Network;

namespace GameServer.Network.LoginServer.Packets.Sent;

public class _0x06_ServerStatus : Packet
{
    public _0x06_ServerStatus(List<(int attributeId, int attributeValue)> attributes) 
        : base(0x06)
    {
        WriteInt(attributes.Count);
        
        foreach ((int attributeId, int attributeValue) in attributes)
        {
            WriteInt(attributeId);
            WriteInt(attributeValue);
        }
    }
}