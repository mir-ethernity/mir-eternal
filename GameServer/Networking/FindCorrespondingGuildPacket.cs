using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 555, 长度 = 31, 注释 = "FindCorrespondingGuildPacket")]
	public sealed class FindCorrespondingGuildPacket : GamePacket
	{
		
		public FindCorrespondingGuildPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 行会编号;

		
		[WrappingFieldAttribute(下标 = 6, 长度 = 25)]
		public string 行会名字;
	}
}
