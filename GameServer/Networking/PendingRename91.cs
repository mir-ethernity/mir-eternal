using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 213, 长度 = 7, 注释 = "玩家获得称号")]
	public sealed class 玩家获得称号 : GamePacket
	{
		
		public 玩家获得称号()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 称号编号;

		
		[WrappingFieldAttribute(下标 = 3, 长度 = 4)]
		public int 剩余时间;
	}
}
