using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 517, 长度 = 6, 注释 = "申请离开队伍")]
	public sealed class 申请离开队伍 : GamePacket
	{
		
		public 申请离开队伍()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;
	}
}
