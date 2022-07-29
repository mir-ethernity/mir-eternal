using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 132, 长度 = 0, 注释 = "玩家掉落装备")]
	public sealed class 玩家掉落装备 : GamePacket
	{
		
		public 玩家掉落装备()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 4, Length = 4)]
		public byte[] 物品描述;
	}
}
