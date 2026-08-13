using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Sent;

public class LoginFail : Packet
{
    public const int NO_TEXT = 0;
    public const int SYSTEM_ERROR_LOGIN_LATER = 1;
    public const int PASSWORD_DOES_NOT_MATCH_THIS_ACCOUNT = 2;
    public const int PASSWORD_DOES_NOT_MATCH_THIS_ACCOUNT2 = 3;
    public const int ACCESS_FAILED_TRY_LATER = 4;
    public const int INCORRECT_ACCOUNT_INFO_CONTACT_CUSTOMER_SUPPORT = 5;
    public const int ACCESS_FAILED_TRY_LATER2 = 6;
    public const int ACOUNT_ALREADY_IN_USE = 7;
    public const int ACCESS_FAILED_TRY_LATER3 = 8;
    public const int ACCESS_FAILED_TRY_LATER4 = 9;
    public const int ACCESS_FAILED_TRY_LATER5 = 10;
    
    public LoginFail(int success, int reason) : base(0x0A)
    {
        //TODO: реализовать заполнение пакета
        
        WriteInt(-1);
        WriteInt(0);
    }
}