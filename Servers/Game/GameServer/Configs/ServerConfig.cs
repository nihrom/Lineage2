namespace GameServer.Configs;

public class ServerConfig
{
    #region Networking
    
    /// <summary>
    /// Ip адрес LoginServer для подключения.
    /// </summary>
    public required string LoginHost { get; init; }
    
    /// <summary>
    /// Порт LoginServer для подключения.
    /// </summary>
    public required int LoginPort { get; init; }
    
    /// <summary>
    /// Ip адрес на котором GameServer будет принимать новые соединиения.
    /// default: 127.0.0.1
    /// </summary>
    public required string GameServerHost { get; init; }
    
    /// <summary>
    /// Порт на котором GameServer будет принимать новые соединиения.
    /// </summary>
    public required int GameServerPort { get; init; }

    #endregion

    #region Database

    //Тут пока пусто
    //TODO: сюда вставить коннекшен стринг

    #endregion

    #region Misc Server Settings

    //TODO: Заполнить описание
    
    public required string RequestServerId { get; init; }
    
    public required string AcceptAlternateId { get; init; }
    
    public required string DatapackRoot { get; init; }
    
    public required string ScriptRoot { get; init; }
    
    public required string MaximumOnlineUsers { get; init; }
    
    public required string AllowedProtocolRevisions { get; init; }
    
    public required string ServerListType { get; init; }
    
    public required string ServerListAge { get; init; }
    
    public required string ServerListBrackets { get; init; }

    #endregion

    #region Misc Player Settings

    //TODO: Заполнить

    #endregion

    #region Precautionary Server Restart

    //TODO: Заполнить

    #endregion

    #region Scheduled Server Restart

    //TODO: Заполнить

    #endregion
}