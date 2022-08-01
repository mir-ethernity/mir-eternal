using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Client, 编号 = 566, 长度 = 6, 注释 = "ExpelMembersPacket")]
	public sealed class ExpelMembersPacket : GamePacket
	{
		
		public ExpelMembersPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
