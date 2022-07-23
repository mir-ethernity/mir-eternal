using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 312, 长度 = 0, 注释 = "SyncWantedListPacket")]
	public sealed class SyncWantedListPacket : GamePacket
	{
		
		public SyncWantedListPacket()
		{
			
			
		}
	}
}
