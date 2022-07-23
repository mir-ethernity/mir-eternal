using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 594, 长度 = 63, 注释 = "InviteJoinPacket")]
	public sealed class InviteJoinPacket : GamePacket
	{
		
		public InviteJoinPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(下标 = 6, 长度 = 32)]
		public string 对象名字;

		
		[WrappingFieldAttribute(下标 = 38, 长度 = 25)]
		public string 行会名字;
	}
}
