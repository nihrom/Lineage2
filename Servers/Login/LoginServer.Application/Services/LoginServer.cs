namespace LoginServer.Application.Services;

public class LoginServer
{
    public LoginServerStatus Status;
}

public enum LoginServerStatus
{
    StatusAuto = 0x00,
    StatusGood = 0x01,
    StatusNormal = 0x02,
    StatusFull = 0x03,
    StatusDown = 0x04,
    StatusGmOnly = 0x05,
}