using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Client, 编号 = 51, 长度 = 2, 注释 = "SyncRepoListPacket")]
	public sealed class 查询回购列表 : GamePacket
	{
		
		public 查询回购列表()
		{
			
			
		}
	}
}
