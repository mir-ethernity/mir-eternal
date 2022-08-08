using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 122, 长度 = 0, 注释 = "SelectTargetDetailsPacket")]
	public sealed class SelectTargetDetailsPacket : GamePacket
	{
		
		public SelectTargetDetailsPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 4, Length = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(SubScript = 8, Length = 4)]
		public int CurrentHP;

		
		[WrappingFieldAttribute(SubScript = 12, Length = 4)]
		public int CurrentMP;

		
		[WrappingFieldAttribute(SubScript = 16, Length = 4)]
		public int MaxHP;

		
		[WrappingFieldAttribute(SubScript = 20, Length = 4)]
		public int MaxMP;

		[WrappingFieldAttribute(SubScript = 25, Length = 1)]
		public byte[] Buff描述;
	}
}
