using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 137, 长度 = 4, 注释 = "背包容量改变")]
	public sealed class 背包容量改变 : GamePacket
	{
		
		public 背包容量改变()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte 背包类型;

		
		[WrappingFieldAttribute(SubScript = 3, Length = 1)]
		public byte 背包容量;
	}
}
