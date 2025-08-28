using LoginServer.Application.Services;
using LoginServer.Application.Services.L2GameApplication;
using LoginServer.Network.GameApplication.ClientsNetwork;
using LoginServer.Network.GameApplication.Packets.Sent;

namespace LoginServer.Network.GameApplication.Packets.Listenable.Handlers;

public class RequestServerListHandler
{
    private L2GameApplicationAvatar _avatar;
    private readonly ServersManager serversManager;
    
    public async Task Handle(RequestServerList request)
    {
        if (_avatar.CheckLoginOk(request.Skey1, request.Skey2))
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
            await _avatar.SendServerList(1, 1, mappedServers);
        }
        else
        {
            await _avatar.Close(LoginFailReason.ReasonAccessFailed);
        }
    }
}