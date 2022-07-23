using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 546, 长度 = 2, 注释 = "提交出师申请")]
	public sealed class 提交出师申请 : GamePacket
	{
		
		public 提交出师申请()
		{
			
			
		}
	}
}
