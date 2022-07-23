using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 579, 长度 = 27, 注释 = "StartGuildWarPacket")]
	public sealed class StartGuildWarPacket : GamePacket
	{
		
		public StartGuildWarPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 25)]
		public string 行会名字;
	}
}
