using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 532, 长度 = 39, 注释 = "添加关注")]
	public sealed class 玩家添加关注 : GamePacket
	{
		
		public 玩家添加关注()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(下标 = 6, 长度 = 32)]
		public string 对象名字;

		
		[WrappingFieldAttribute(下标 = 38, 长度 = 1)]
		public bool 是否好友;
	}
}
