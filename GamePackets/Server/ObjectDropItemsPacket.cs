using System;
using System.Drawing;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 150, 长度 = 24, 注释 = "掉落物品")]
	public sealed class ObjectDropItemsPacket : GamePacket
	{
		
		public ObjectDropItemsPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 4)]
		public int MapId;

		
		[WrappingFieldAttribute(SubScript = 10, Length = 4)]
		public Point 掉落坐标;

		
		[WrappingFieldAttribute(SubScript = 14, Length = 2)]
		public ushort 掉落高度;

		
		[WrappingFieldAttribute(SubScript = 16, Length = 4)]
		public int Id;

		
		[WrappingFieldAttribute(SubScript = 20, Length = 4)]
		public int 物品数量;
	}
}
