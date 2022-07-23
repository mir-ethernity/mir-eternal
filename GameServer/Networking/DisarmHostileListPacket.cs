using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 640, 长度 = 10, 注释 = "DisarmHostileListPacket")]
	public sealed class DisarmHostileListPacket : GamePacket
	{
		
		public DisarmHostileListPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 申请类型;

		
		[WrappingFieldAttribute(下标 = 6, 长度 = 4)]
		public int 行会编号;
	}
}
