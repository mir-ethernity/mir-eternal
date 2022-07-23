using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 564, 长度 = 7, 注释 = "设置行会禁言")]
	public sealed class 设置行会禁言 : GamePacket
	{
		
		public 设置行会禁言()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 禁言状态;

		
		[WrappingFieldAttribute(下标 = 3, 长度 = 4)]
		public int 对象编号;
	}
}
