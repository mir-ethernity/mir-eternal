using System;
using System.Drawing;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 150, Length = 34, Description = "掉落物品")]
	public sealed class ObjectDropItemsPacket : GamePacket
	{
		[WrappingFieldAttribute(SubScript = 2, Length = 2)]
		public ushort Unknown1 = 34; // TODO: WTF??

		[WrappingFieldAttribute(SubScript = 4, Length = 4)]
		public int DropperObjectId;

		
		[WrappingFieldAttribute(SubScript = 8, Length = 4)]
		public int ItemObjectId;

		
		[WrappingFieldAttribute(SubScript = 12, Length = 4)]
		public Point 掉落坐标;

		
		[WrappingFieldAttribute(SubScript = 16, Length = 2)]
		public ushort 掉落高度;

		
		[WrappingFieldAttribute(SubScript = 18, Length = 4)]
		public int ItemId;

		
		[WrappingFieldAttribute(SubScript = 22, Length = 4)]
		public int 物品数量;

		[WrappingFieldAttribute(SubScript = 26, Length = 4)]
		public int Unknown2 = 1;

		[WrappingFieldAttribute(SubScript = 30, Length = 4)]
		public int OwnerPlayerId;
	}
}
