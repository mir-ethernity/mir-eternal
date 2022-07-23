using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 542, 长度 = 2, 注释 = "离开师门申请")]
	public sealed class 离开师门申请 : GamePacket
	{
		
		public 离开师门申请()
		{
			
			
		}
	}
}
