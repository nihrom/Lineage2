namespace LoginServer.Domain.Models.AccountInfos;

public class AccountInfo
{
    public string Login { get; protected set; }
    
    public string PasswordHash { get; protected set; }
    
    public int AccessLevel { get; protected set; }
    
    public int LastServer { get; protected set; }

    public AccountInfo(
        string login,
        string passwordHash,
        int accessLevel,
        int lastServer)
    {
        Login = login;
        PasswordHash = passwordHash;
        AccessLevel = accessLevel;
        LastServer = lastServer;
    }
}