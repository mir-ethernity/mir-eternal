using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 531, 长度 = 82, 注释 = "好友上下线")]
	public sealed class 好友上线下线 : GamePacket
	{
		
		public 好友上线下线()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 32)]
		public string 对象名字;

		
		[WrappingFieldAttribute(SubScript = 75, Length = 1)]
		public byte 对象职业;

		
		[WrappingFieldAttribute(SubScript = 76, Length = 1)]
		public byte 对象性别;

		
		[WrappingFieldAttribute(SubScript = 77, Length = 1)]
		public byte 上线下线;
	}
}
