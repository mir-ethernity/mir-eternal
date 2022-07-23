using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 137, 长度 = 4, 注释 = "背包容量改变")]
	public sealed class 背包容量改变 : GamePacket
	{
		
		public 背包容量改变()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 背包类型;

		
		[WrappingFieldAttribute(下标 = 3, 长度 = 1)]
		public byte 背包容量;
	}
}
