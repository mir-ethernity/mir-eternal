using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 531, 长度 = 82, 注释 = "好友上下线")]
	public sealed class 好友上线下线 : GamePacket
	{
		
		public 好友上线下线()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(下标 = 6, 长度 = 32)]
		public string 对象名字;

		
		[WrappingFieldAttribute(下标 = 75, 长度 = 1)]
		public byte 对象职业;

		
		[WrappingFieldAttribute(下标 = 76, 长度 = 1)]
		public byte 对象性别;

		
		[WrappingFieldAttribute(下标 = 77, 长度 = 1)]
		public byte 上线下线;
	}
}
