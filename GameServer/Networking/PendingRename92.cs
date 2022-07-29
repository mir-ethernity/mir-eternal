using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 128, 长度 = 0, 注释 = "物品变动")]
	public sealed class 玩家物品变动 : GamePacket
	{
		
		public 玩家物品变动()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 4, Length = 0)]
		public byte[] 物品描述;
	}
}
