using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 594, 长度 = 63, 注释 = "InviteJoinPacket")]
	public sealed class InviteJoinPacket : GamePacket
	{
		
		public InviteJoinPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 32)]
		public string 对象名字;

		
		[WrappingFieldAttribute(SubScript = 38, Length = 25)]
		public string 行会名字;
	}
}
