using Common.Network;

namespace GameServer.Network.LoginServer.Packets.Sent;

public class _0x02_PlayerInGame : Packet
{
    public _0x02_PlayerInGame(List<string> players) : base(0x02)
    {
        WriteShort((short)players.Count);
        
        foreach (var player in players)
        {
            WriteString(player);
        }
    }
}