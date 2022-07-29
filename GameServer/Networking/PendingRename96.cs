using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 533, 长度 = 6, 注释 = "取消关注")]
	public sealed class 玩家取消关注 : GamePacket
	{
		
		public 玩家取消关注()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
