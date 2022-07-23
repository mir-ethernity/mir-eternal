using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 44, 长度 = 6, 注释 = "物品转移/交换/合并/更换装备")]
	public sealed class CharacterTransferItemPacket : GamePacket
	{
		
		public CharacterTransferItemPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 当前背包;

		
		[WrappingFieldAttribute(下标 = 3, 长度 = 1)]
		public byte 原有位置;

		
		[WrappingFieldAttribute(下标 = 4, 长度 = 1)]
		public byte 目标背包;

		
		[WrappingFieldAttribute(下标 = 5, 长度 = 1)]
		public byte 目标位置;
	}
}
