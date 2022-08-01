using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Client, 编号 = 112, 长度 = 17, 注释 = "购买摊位物品")]
	public sealed class 购买摊位物品 : GamePacket
	{
		
		public 购买摊位物品()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 1)]
		public byte 物品位置;

		
		[WrappingFieldAttribute(SubScript = 7, Length = 2)]
		public ushort 购买数量;
	}
}
