using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 214, 长度 = 4, 注释 = "玩家失去称号")]
	public sealed class 玩家失去称号 : GamePacket
	{
		
		public 玩家失去称号()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 称号编号;
	}
}
