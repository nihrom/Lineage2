using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestPartyMatchConfig
{
    public int Auto;
    
    /// <summary>
    /// Location
    /// </summary>
    public int Loc;

    /// <summary>
    /// My level
    /// </summary>
    public int Level;

    public RequestPartyMatchConfig(Packet packet)
    {
        Auto = packet.ReadInt();
        Loc = packet.ReadInt();
        Level = packet.ReadInt();
    }
}