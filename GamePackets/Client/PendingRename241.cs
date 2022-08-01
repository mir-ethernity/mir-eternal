using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Client, 编号 = 624, 长度 = 6, 注释 = "查看演武排名")]
	public sealed class 查看演武排名 : GamePacket
	{
		
		public 查看演武排名()
		{
			
			
		}
	}
}
