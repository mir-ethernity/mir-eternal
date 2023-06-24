using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 531, Length = 0, Description = "好友上下线")]
	public sealed class 好友上线下线 : GamePacket
	{
		
		public 好友上线下线()
		{
			
			
		}
		
		[WrappingFieldAttribute(SubScript = 4, Length = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(SubScript = 8, Length = 32)]
		public string 对象名字;

		
		[WrappingFieldAttribute(SubScript = 77, Length = 1)]
		public byte 对象职业;

		
		[WrappingFieldAttribute(SubScript = 78, Length = 1)]
		public byte 对象性别;

		
		[WrappingFieldAttribute(SubScript = 79, Length = 1)]
		public byte 上线下线;
	}
}
