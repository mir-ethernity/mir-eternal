using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Client, 编号 = 1008, 长度 = 38, 注释 = "更改CharName")]
	public sealed class 更改CharName : GamePacket
	{
		
		public 更改CharName()
		{
			
			
		}
	}
}
