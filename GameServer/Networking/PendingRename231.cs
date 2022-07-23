using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 565, 长度 = 7, 注释 = "变更会员职位")]
	public sealed class 变更会员职位 : GamePacket
	{
		
		public 变更会员职位()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(下标 = 6, 长度 = 1)]
		public byte 对象职位;
	}
}
