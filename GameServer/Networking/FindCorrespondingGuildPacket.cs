using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 555, 长度 = 31, 注释 = "FindCorrespondingGuildPacket")]
	public sealed class FindCorrespondingGuildPacket : GamePacket
	{
		
		public FindCorrespondingGuildPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 行会编号;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 25)]
		public string 行会名字;
	}
}
