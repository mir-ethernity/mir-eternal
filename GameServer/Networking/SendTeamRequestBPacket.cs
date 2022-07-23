using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 520, 长度 = 40, 注释 = "SendTeamRequestBPacket")]
	public sealed class SendTeamRequestBPacket : GamePacket
	{
		
		public SendTeamRequestBPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(下标 = 6, 长度 = 1)]
		public byte 组队方式;

		
		[WrappingFieldAttribute(下标 = 7, 长度 = 1)]
		public byte 对象职业;

		
		[WrappingFieldAttribute(下标 = 8, 长度 = 32)]
		public string 对象名字;
	}
}
