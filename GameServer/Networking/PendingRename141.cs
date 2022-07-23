using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 662, 长度 = 10, 注释 = "同步占领行会")]
	public sealed class 同步占领行会 : GamePacket
	{
		
		public 同步占领行会()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 6, 长度 = 4)]
		public int 行会编号;
	}
}
