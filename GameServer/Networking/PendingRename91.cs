using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 213, 长度 = 7, 注释 = "玩家获得称号")]
	public sealed class 玩家获得称号 : GamePacket
	{
		
		public 玩家获得称号()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte Id;

		
		[WrappingFieldAttribute(SubScript = 3, Length = 4)]
		public int 剩余时间;
	}
}
