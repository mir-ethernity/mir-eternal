using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Client, 编号 = 241, 长度 = 4, 注释 = "玩家喝修复油")]
	public sealed class 玩家喝修复油 : GamePacket
	{
		
		public 玩家喝修复油()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte 背包类型;

		
		[WrappingFieldAttribute(SubScript = 3, Length = 1)]
		public byte 物品位置;
	}
}
