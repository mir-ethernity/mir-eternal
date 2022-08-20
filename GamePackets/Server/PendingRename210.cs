using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 137, Length = 4, Description = "背包容量改变")]
	public sealed class 背包容量改变 : GamePacket
	{
		
		public 背包容量改变()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte 背包类型;

		
		[WrappingFieldAttribute(SubScript = 3, Length = 1)]
		public byte 背包容量;
	}
}
