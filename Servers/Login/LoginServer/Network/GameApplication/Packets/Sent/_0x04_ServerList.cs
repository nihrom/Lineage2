using Common.Network;

namespace LoginServer.Network.GameApplication.Packets.Sent;

public class _0x04_ServerList : Packet
{
    public record ServerData(
        byte ServerId,
        byte[] Ip,
        int Port,
        byte AgeLimit,
        bool IsPvp,
        short CurrentPlayers,
        short MaxPlayers,
        bool Connected,
        bool IsBrackets,
        bool TestMode);
    
    public _0x04_ServerList(
        byte serversCount,
        byte accountLastServer,
        IReadOnlyCollection<ServerData> servers) : base(0x04)
    {
        WriteByte(serversCount, accountLastServer); //(byte)client.ActiveAccount.LastServer);
        
        foreach (var server in servers)
        {
            int bits = 0x40;
            if (server.TestMode)
                bits |= 0x04;

            WriteByte(server.ServerId);
            WriteByteArray(server.Ip);
            WriteInt(server.Port);
            WriteByte(server.AgeLimit);
            WriteByte(server.IsPvp ? (byte)1 : (byte)0);
            WriteShort(server.CurrentPlayers);
            WriteShort(server.MaxPlayers);
            WriteByte(server.Connected? (byte)1 : (byte)0); // status
            WriteInt(1);//bits); // 1: Normal, 2: Relax, 4: Public Test, 8: No Label, 16: Character Creation Restricted, 32: Event, 64: Free
            WriteByte(server.IsBrackets ? (byte)1 : (byte)0); //brackets
        }
    }
}