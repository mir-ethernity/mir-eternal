using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 636, 长度 = 8, 注释 = "帮会成就回应")]
	public sealed class 帮会成就回应 : GamePacket
	{
		
		public 帮会成就回应()
		{
			
			
		}
	}
}
