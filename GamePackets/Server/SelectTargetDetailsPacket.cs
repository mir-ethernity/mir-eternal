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
		public int CurrentStamina;

		
		[WrappingFieldAttribute(SubScript = 12, Length = 4)]
		public int 当前魔力;

		
		[WrappingFieldAttribute(SubScript = 16, Length = 4)]
		public int MaxPhysicalStrength;

		
		[WrappingFieldAttribute(SubScript = 20, Length = 4)]
		public int MaxMagic2;

		[WrappingFieldAttribute(SubScript = 25, Length = 1)]
		public byte[] Buff描述;
	}
}
