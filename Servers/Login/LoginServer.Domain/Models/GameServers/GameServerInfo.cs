namespace LoginServer.Domain.Models.GameServers;

public class GameServerInfo
{
    public byte ServerId { get; }

    public byte[] Ip { get; }

    public int Port { get; }

    public byte AgeLimit { get; }

    public bool IsPvp { get; }

    public short CurrentPlayers { get; }

    public short MaxPlayers { get; }

    public bool Connected { get; }

    public bool IsBrackets { get; }

    public bool TestMode { get; }
    
    public bool IsAuthed { get; }

    public GameServerInfo(
        byte serverId,
        byte[] ip,
        int port,
        byte ageLimit,
        bool isPvp,
        short currentPlayers,
        short maxPlayers,
        bool connected,
        bool isBrackets,
        bool testMode,
        bool isAuthed)
    {
        ServerId = serverId;
        Ip = ip;
        Port = port;
        AgeLimit = ageLimit;
        IsPvp = isPvp;
        CurrentPlayers = currentPlayers;
        MaxPlayers = maxPlayers;
        Connected = connected;
        IsBrackets = isBrackets;
        TestMode = testMode;
        IsAuthed = isAuthed;
    }
}