using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 149, Length = 30, Description = "货币数量变动")]
	public sealed class 货币数量变动 : GamePacket
	{
		
		public 货币数量变动()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte CurrencyType;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 4)]
		public int 货币数量;
	}
}
