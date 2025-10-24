namespace GameServer;

public class GameServerConfig
{
    /// <summary>
    /// Локальный адрес на котором будут прослушиваться соединения
    /// </summary>
    public string? Host { get; set; }

    /// <summary>
    /// Порт по которому будут прослушиваться соединения
    /// </summary>
    public int Port { get; set; }
}