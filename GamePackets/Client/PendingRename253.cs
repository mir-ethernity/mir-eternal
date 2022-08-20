using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 532, Length = 2, Description = "查询拜师名册(已弃用, 不推送)")]
	public sealed class 查询拜师名册 : GamePacket
	{
		
		public 查询拜师名册()
		{
			
			
		}
	}
}
