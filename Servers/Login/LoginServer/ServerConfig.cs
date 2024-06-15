namespace LoginServer;

public sealed class ServerConfig
{
    public string? Host { get; set; }

    public int Port { get; set; }

    public int GameServersPort { get; set; }

    public bool AutoCreate { get; set; }
}