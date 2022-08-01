using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 266, 长度 = 2, 注释 = "铭文传承应答")]
	public sealed class 铭文传承应答 : GamePacket
	{
		
		public 铭文传承应答()
		{
			
			
		}
	}
}
