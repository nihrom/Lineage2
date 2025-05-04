namespace LoginServer.Application.Enums;

public enum LoginResult
{
    InvalidPassword,
    
    AccountBanned,
    
    AlreadyOnLs,
    
    AlreadyOnGs,
    
    AuthSuccess
}