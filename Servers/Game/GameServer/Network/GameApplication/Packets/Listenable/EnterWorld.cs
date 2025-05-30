﻿using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class EnterWorld
{
    public EnterWorld(Packet packet)
    {
        packet.ReadBytesArray(32); // Unknown Byte Array
        packet.ReadInt(); // Unknown Value
        packet.ReadInt(); // Unknown Value
        packet.ReadInt(); // Unknown Value
        packet.ReadInt(); // Unknown Value
        packet.ReadBytesArray(32); // Unknown Byte Array
        packet.ReadInt(); // Unknown Value
        for (int i = 0; i < 5; i++)
        {
            for (int o = 0; o < 4; o++)
            {
                _tracert[i][o] = readUnsignedByte();
            }
        }
    }
}