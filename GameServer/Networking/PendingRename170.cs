using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 523, 长度 = 7, 注释 = "同步队员状态")]
	public sealed class 同步队员状态 : GamePacket
	{
		
		public 同步队员状态()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(下标 = 6, 长度 = 1)]
		public byte 状态编号;
	}
}
