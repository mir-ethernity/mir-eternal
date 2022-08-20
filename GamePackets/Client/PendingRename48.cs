using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 108, Length = 3, Description = "取回摊位物品")]
	public sealed class 取回摊位物品 : GamePacket
	{
		
		public 取回摊位物品()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte 取回位置;
	}
}
