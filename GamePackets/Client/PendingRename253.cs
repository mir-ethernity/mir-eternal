using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Client, 编号 = 532, 长度 = 2, 注释 = "查询拜师名册(已弃用, 不推送)")]
	public sealed class 查询拜师名册 : GamePacket
	{
		
		public 查询拜师名册()
		{
			
			
		}
	}
}
