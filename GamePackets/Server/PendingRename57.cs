using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 563, 长度 = 2, 注释 = "离开师门应答")]
	public sealed class 离开师门应答 : GamePacket
	{
		
		public 离开师门应答()
		{
			
			
		}
	}
}
