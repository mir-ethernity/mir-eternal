using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 128, Length = 0, Description = "物品变动")]
	public sealed class 玩家物品变动 : GamePacket
	{
		
		public 玩家物品变动()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 4, Length = 0)]
		public byte[] 物品描述;
	}
}
