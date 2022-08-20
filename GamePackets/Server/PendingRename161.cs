using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 151, Length = 0, Description = "同步地面物品")]
	public sealed class 同步地面物品 : GamePacket
	{
		
		public 同步地面物品()
		{
			
			
		}
	}
}
