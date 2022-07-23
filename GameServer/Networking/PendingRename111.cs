using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 56, 长度 = 7, 注释 = "角色复活")]
	public sealed class 玩家角色复活 : GamePacket
	{
		
		public 玩家角色复活()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(下标 = 6, 长度 = 1)]
		public byte 复活方式;
	}
}
