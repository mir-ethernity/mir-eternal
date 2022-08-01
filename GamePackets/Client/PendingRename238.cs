using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Client, 编号 = 569, 长度 = 2, 注释 = "查看结盟申请")]
	public sealed class 查看结盟申请 : GamePacket
	{
		
		public 查看结盟申请()
		{
			
			
		}
	}
}
