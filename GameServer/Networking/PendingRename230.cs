using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 104, 长度 = 10, 注释 = "体力变动飘字")]
	public sealed class 体力变动飘字 : GamePacket
	{
		
		public 体力变动飘字()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(下标 = 6, 长度 = 4)]
		public int 血量变化;
	}
}
