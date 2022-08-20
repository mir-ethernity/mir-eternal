using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 289, Length = 3, Description = "玩家每日签到")]
	public sealed class 每日签到应答 : GamePacket
	{
		
		public 每日签到应答()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte 签到次数;
	}
}
