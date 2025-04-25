using Common.Network;

namespace GameServer.Network.LoginServer.Packets.Sent;

public class _0x01_AuthRequest : Packet
{
    public _0x01_AuthRequest(
        byte id,
        bool acceptAlternate,
        bool reserveHost,
        short port,
        int maxPlayer,
        byte[] hexId,
        List<(string subnet, string host)> subnetHosts) : base(0x01)
    {
        WriteByte(id);
        WriteByte((byte)(acceptAlternate ? 0x01 : 0x00));
        WriteByte((byte)(reserveHost ? 0x01 : 0x00));
        WriteShort(port);
        WriteInt(maxPlayer);
        WriteInt(hexId.Length);
        WriteByteArray(hexId);
        WriteInt(subnetHosts.Count);
        
        foreach (var (subnet, host) in subnetHosts)
        {
            WriteString(subnet);
            WriteString(host);
        }
    }
}