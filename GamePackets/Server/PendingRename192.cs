using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 254, Length = 3, Description = "玩家取下灵石")]
	public sealed class 成功取下灵石 : GamePacket
	{
		
		public 成功取下灵石()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte 灵石状态;
	}
}
