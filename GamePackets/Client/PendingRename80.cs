using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Client, 编号 = 564, 长度 = 7, 注释 = "设置行会禁言")]
	public sealed class 设置行会禁言 : GamePacket
	{
		
		public 设置行会禁言()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte 禁言状态;

		
		[WrappingFieldAttribute(SubScript = 3, Length = 4)]
		public int 对象编号;
	}
}
