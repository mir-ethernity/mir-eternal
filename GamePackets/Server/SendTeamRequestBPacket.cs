using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 520, 长度 = 40, 注释 = "SendTeamRequestBPacket")]
	public sealed class SendTeamRequestBPacket : GamePacket
	{
		
		public SendTeamRequestBPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 1)]
		public byte 组队方式;

		
		[WrappingFieldAttribute(SubScript = 7, Length = 1)]
		public byte 对象职业;

		
		[WrappingFieldAttribute(SubScript = 8, Length = 32)]
		public string 对象名字;
	}
}
