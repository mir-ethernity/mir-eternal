using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 571, 长度 = 6, 注释 = "申请解除结盟")]
	public sealed class 申请解除结盟 : GamePacket
	{
		
		public 申请解除结盟()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 行会编号;
	}
}
