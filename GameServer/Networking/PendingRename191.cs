using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 216, 长度 = 4, 注释 = "领取特权礼包")]
	public sealed class 领取特权礼包 : GamePacket
	{
		
		public 领取特权礼包()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte 特权类型;

		
		[WrappingFieldAttribute(SubScript = 3, Length = 1)]
		public byte 礼包位置;
	}
}
