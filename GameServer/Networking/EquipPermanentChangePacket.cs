using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 143, 长度 = 8, 注释 = "EquipPermanentChangePacket")]
	public sealed class EquipPermanentChangePacket : GamePacket
	{
		
		public EquipPermanentChangePacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 装备容器;

		
		[WrappingFieldAttribute(下标 = 3, 长度 = 1)]
		public byte 装备位置;

		
		[WrappingFieldAttribute(下标 = 4, 长度 = 4)]
		public int 当前持久;
	}
}
