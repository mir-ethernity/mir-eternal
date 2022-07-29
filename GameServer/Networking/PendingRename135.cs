using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 145, 长度 = 3, 注释 = "玩家装配称号")]
	public sealed class 玩家装配称号 : GamePacket
	{
		
		public 玩家装配称号()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public byte Id;
	}
}
