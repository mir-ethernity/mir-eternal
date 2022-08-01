using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 640, 长度 = 10, 注释 = "DisarmHostileListPacket")]
	public sealed class DisarmHostileListPacket : GamePacket
	{
		
		public DisarmHostileListPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 申请类型;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 4)]
		public int 行会编号;
	}
}
