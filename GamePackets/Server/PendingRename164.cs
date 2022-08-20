using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 79, Length = 6, Description = "同步mp")]
	public sealed class 同步对象魔力 : GamePacket
	{
		
		public 同步对象魔力()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int CurrentMP;
	}
}
