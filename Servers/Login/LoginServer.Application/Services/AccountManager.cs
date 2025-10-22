using LoginServer.Application.Enums;
using LoginServer.Domain.Models.AccountInfos;

namespace LoginServer.Application.Services;

public class AccountManager
{
    public AccountInfo? GetAccountInfo(
        string clientAddr,
        string user,
        string password)
    {
        //TODO: реализовать логику
        
        return new AccountInfo(
            "nihrom",
            "123123",
            1,
            1);
    }

    public LoginResult TryCheckinAccount(
        //LoginClient client,
        string address,
        AccountInfo info)
    {
        if (info.AccessLevel < 0)
        {
            return LoginResult.AccountBanned;
        }
        
        // LoginResult result = LoginResult.InvalidPassword;
        // // Check auth.
        // if (CanCheckin(client, address, info))
        // {
        //     result = LoginResult.AlreadyOnGs;
        //     // Вход выполнен успешно, проверка присутствия на игровых серверах.
        //     if (!IsAccountInAnyGameServer(info.Login))
        //     {
        //         // Аккаунт не находится ни на одном GS, проверка на LS
        //         result = LoginResult.AlreadyOnLs;
        //         if (_loginServerClients.putIfAbsent(info.Login, client) == null)
        //         {
        //             result = LoginResult.AuthSuccess;
        //         }
        //     }
        // }
        // return result;

        return LoginResult.AuthSuccess;
    }

    public bool CanCheckin(
        //LoginClient client,
        string address,
        AccountInfo info)
    {
        try
        { 
            List<string> ipWhiteList = new List<string>();
            List<string> ipBlackList = new List<string>();
            
            // try (Connection con = DatabaseFactory.getConnection();
            // PreparedStatement ps = con.prepareStatement(ACCOUNT_IPAUTH_SELECT))
            // {
            //     ps.setString(1, info.Login);
            //     try (ResultSet rset = ps.executeQuery())
            //     {
            //         String ip;
            //         String type;
            //         while (rset.next())
            //         {
            //             ip = rset.getString("ip");
            //             type = rset.getString("type");
            //             if (!isValidIPAddress(ip))
            //             {
            //                 continue;
            //             }
            //             if (type.equals("allow"))
            //             {
            //                 ipWhiteList.add(ip);
            //             }
            //             else if (type.equals("deny"))
            //             {
            //                 ipBlackList.add(ip);
            //             }
            //         }
            //     }
            // }

            // Check IP.
            if (ipWhiteList.Any() || ipBlackList.Any())
            {
                if (ipWhiteList.Any() && !ipWhiteList.Contains(address))
                {
                    //LOGGER.warning("Account checkin attemp from address(" + address + ") not present on whitelist for account '" + info.getLogin() + "'.");
                    return false;
                }

                if (ipBlackList.Any() && ipBlackList.Contains(address))
                {
                    //LOGGER.warning("Account checkin attemp from address(" + address + ") on blacklist for account '" + info.getLogin() + "'.");
                    return false;
                }
            }

            // client.setAccessLevel(info.AccessLevel);
            // client.setLastServer(info.LastServer);
            //
            // try (Connection con = DatabaseFactory.getConnection();
            // PreparedStatement ps = con.prepareStatement(ACCOUNT_INFO_UPDATE))
            // {
            //     ps.setLong(1, System.currentTimeMillis());
            //     ps.setString(2, address);
            //     ps.setString(3, info.getLogin());
            //     ps.execute();
            // }
            
            return true;
        }
        catch (Exception e)
        {
            //LOGGER.log(Level.WARNING, "Could not finish login process!", e);
            return false;
        }
    }
    
    /// <summary>
    /// Проверка имеется ли активные подключения на игровых серверах
    /// </summary>
    /// <param name="account"></param>
    /// <returns></returns>
    public bool IsAccountInAnyGameServer(string account)
    {
        // Collection<GameServerInfo> serverList = GameServerTable.getInstance().getRegisteredGameServers().values();
        // for (GameServerInfo gsi : serverList)
        // {
        //     GameServerThread gst = gsi.getGameServerThread();
        //     if ((gst != null) && gst.hasAccountOnGameServer(account))
        //     {
        //         return true;
        //     }
        // }
        return false;
    }
    
    public bool IsLoginPossible(
        //LoginClient client,
        int serverId)
    {
        // GameServerInfo gsi = GameServerTable.getInstance().getRegisteredGameServerById(serverId);
        // if ((gsi != null) && gsi.isAuthed())
        // {
        //     boolean loginOk = gsi.canLogin(client);
        //     if (loginOk && (client.getLastServer() != serverId))
        //     {
        //         try (Connection con = DatabaseFactory.getConnection();
        //         PreparedStatement ps = con.prepareStatement(ACCOUNT_LAST_SERVER_UPDATE))
        //         {
        //             ps.setInt(1, serverId);
        //             ps.setString(2, client.getAccount());
        //             ps.executeUpdate();
        //         }
        //         catch (Exception e)
        //         {
        //             LOGGER.log(Level.WARNING, "Could not set lastServer: " + e.getMessage(), e);
        //         }
        //     }
        //     return loginOk;
        // }
        // return false;

        return true;
    }
}