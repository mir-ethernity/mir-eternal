using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 297, 长度 = 6, 注释 = "更新节点数据")]
	public sealed class 更新节点数据 : GamePacket
	{
		
		public 更新节点数据()
		{
			
			
		}
	}
}
