using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 662, 长度 = 10, 注释 = "同步占领行会")]
	public sealed class 同步占领行会 : GamePacket
	{
		
		public 同步占领行会()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 6, Length = 4)]
		public int 行会编号;
	}
}
