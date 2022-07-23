using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 582, 长度 = 6, 注释 = "申请解除敌对")]
	public sealed class 申请解除敌对 : GamePacket
	{
		
		public 申请解除敌对()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 行会编号;
	}
}
