using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Client, 编号 = 177, 长度 = 2, 注释 = "申请离开行会")]
	public sealed class 申请离开行会 : GamePacket
	{
		
		public 申请离开行会()
		{
			
			
		}
	}
}
