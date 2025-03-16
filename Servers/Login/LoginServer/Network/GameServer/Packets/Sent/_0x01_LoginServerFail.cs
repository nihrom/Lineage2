﻿using Common.Network;

namespace LoginServer.Network.GameServer.Packets.Sent;

public class _0x01_LoginServerFail : Packet
{
    public _0x01_LoginServerFail(byte reason) : base(0x01)
    {
        // public static final int REASON_IP_BANNED = 1;
        // public static final int REASON_IP_RESERVED = 2;
        // public static final int REASON_WRONG_HEXID = 3;
        // public static final int REASON_ID_RESERVED = 4;
        // public static final int REASON_NO_FREE_ID = 5;
        // public static final int NOT_AUTHED = 6;
        // public static final int REASON_ALREADY_LOGGED8IN = 7;
        
        WriteByte(reason);
    }
}