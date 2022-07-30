using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 143, 长度 = 8, 注释 = "EquipPermanentChangePacket")]
	public sealed class EquipPermanentChangePacket : GamePacket
	{
		
		public EquipPermanentChangePacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte 装备容器;

		
		[WrappingFieldAttribute(SubScript = 3, Length = 1)]
		public byte 装备位置;

		
		[WrappingFieldAttribute(SubScript = 4, Length = 4)]
		public int 当前持久;
	}
}
