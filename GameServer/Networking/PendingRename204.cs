using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 613, 长度 = 4, 注释 = "购买玛法特权")]
	public sealed class 购买玛法特权 : GamePacket
	{
		
		public 购买玛法特权()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 特权类型;

		
		[WrappingFieldAttribute(下标 = 3, 长度 = 1)]
		public byte 购买数量;
	}
}
