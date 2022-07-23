using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 76, 长度 = 6, 注释 = "DoubleExpChangePacket")]
	public sealed class DoubleExpChangePacket : GamePacket
	{
		
		public DoubleExpChangePacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 双倍经验;
	}
}
