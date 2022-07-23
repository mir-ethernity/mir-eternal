using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 538, 长度 = 7, 注释 = "玩家申请收徒")]
	public sealed class 玩家申请收徒 : GamePacket
	{
		
		public 玩家申请收徒()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 3, 长度 = 4)]
		public int 对象编号;
	}
}
