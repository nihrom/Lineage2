using Newtonsoft.Json;

namespace LoginServer;

public sealed class ServerConfig
{
    public string? Host { get; set; }

    public int Port { get; set; }

    public int GsPort { get; set; }

    public bool AutoCreate { get; set; }
}