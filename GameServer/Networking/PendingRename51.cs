using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 523, 长度 = 6, 注释 = "取消好友关注")]
	public sealed class 取消好友关注 : GamePacket
	{
		
		public 取消好友关注()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;
	}
}
