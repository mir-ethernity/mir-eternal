using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 34, 长度 = 0, 注释 = "SyncPlayerAttributesPacket")]
	public sealed class SyncPlayerAttributesPacket : GamePacket
	{
		
		public SyncPlayerAttributesPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 4, 长度 = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(下标 = 8, 长度 = 4)]
		public int Stat数量;
	}
}
