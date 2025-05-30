﻿using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestBuySeed
{
    public int ManorId;

    public RequestBuySeed(Packet packet)
    {
        ManorId = packet.ReadInt();
        
         int count = packet.ReadInt();
        if ((count <= 0) || (count > Config.MAX_ITEM_IN_PACKET) || ((count * BATCH_LENGTH) != remaining()))
        {
            return;
        }
		      
        _items = new ArrayList<>(count);
        for (int i = 0; i < count; i++)
        {
             int itemId = packet.ReadInt();
             int cnt = packet.ReadInt();
            if ((cnt > Integer.MAX_VALUE) || (cnt < 1) || (itemId < 1))
            {
                _items = null;
                return;
            }
            _items.add(new ItemHolder(itemId, cnt));
        }
    }
}