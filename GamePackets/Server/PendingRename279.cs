using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 297, Length = 6, Description = "更新节点数据")]
	public sealed class 更新节点数据 : GamePacket
	{
		
		public 更新节点数据()
		{
			
			
		}
	}
}
