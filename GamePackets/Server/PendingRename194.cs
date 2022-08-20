using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 252, Length = 3, Description = "玩家合成灵石")]
	public sealed class 成功合成灵石 : GamePacket
	{
		
		public 成功合成灵石()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte 灵石状态;
	}
}
