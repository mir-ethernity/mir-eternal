using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 533, 长度 = 2, 注释 = "查询收徒名册(已弃用, 不推送)")]
	public sealed class 查询收徒名册 : GamePacket
	{
		
		public 查询收徒名册()
		{
			
			
		}
	}
}
