using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 533, Length = 2, Description = "查询收徒名册(已弃用, 不推送)")]
	public sealed class 查询收徒名册 : GamePacket
	{
		
		public 查询收徒名册()
		{
			
			
		}
	}
}
