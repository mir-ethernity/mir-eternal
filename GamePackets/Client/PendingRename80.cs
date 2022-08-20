using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 564, Length = 7, Description = "设置行会禁言")]
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
