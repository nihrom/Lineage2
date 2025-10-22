using LoginServer.Application.Services;
using LoginServer.Application.Services.L2GameApplication;
using LoginServer.Network.GameApplication.ClientsNetwork;
using LoginServer.Network.GameApplication.Packets.Sent;

namespace LoginServer.Network.GameApplication.Packets.Listenable.Handlers;

public class RequestServerListHandler
{
    public L2GameApplicationAvatar Avatar { get; set; }
    private readonly ServersManager serversManager;
    
    public async Task Handle(RequestServerList request)
    {
        if (Avatar.CheckLoginOk(request.Skey1, request.Skey2))
        {
            var servers = serversManager.GetServers();
            
            var mappedServers = servers
                .Select(x => new _0x04_ServerList.ServerData(
                    x.ServerId,
                    x.Ip,
                    x.Port,
                    x.AgeLimit,
                    x.IsPvp,
                    x.CurrentPlayers,
                    x.MaxPlayers,
                    x.Connected,
                    x.IsBrackets,
                    x.TestMode))
                .ToList();
            
            //TODO: откуда то взять эту инфу
            await Avatar.SendServerList(1, 1, mappedServers);
        }
        else
        {
            await Avatar.Close(LoginFailReason.ReasonAccessFailed);
        }
    }
}