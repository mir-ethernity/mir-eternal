using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Client, 编号 = 212, 长度 = 2, 注释 = "SyncedWantedListPacket")]
	public sealed class SyncedWantedListPacket : GamePacket
	{
		
		public SyncedWantedListPacket()
		{
			
			
		}
	}
}
