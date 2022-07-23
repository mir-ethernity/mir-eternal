using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 83, 长度 = 7, 注释 = "玩家装配称号")]
	public sealed class 同步装配称号 : GamePacket
	{
		
		public 同步装配称号()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(下标 = 6, 长度 = 1)]
		public byte 称号编号;
	}
}
