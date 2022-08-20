using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 132, Length = 0, Description = "玩家掉落装备")]
	public sealed class 玩家掉落装备 : GamePacket
	{
		
		public 玩家掉落装备()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 4, Length = 4)]
		public byte[] 物品描述;
	}
}
