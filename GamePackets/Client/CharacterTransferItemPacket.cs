using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 44, Length = 6, Description = "物品转移/交换/合并/更换装备")]
	public sealed class CharacterTransferItemPacket : GamePacket
	{
		
		public CharacterTransferItemPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte 当前背包;

		
		[WrappingFieldAttribute(SubScript = 3, Length = 1)]
		public byte 原有位置;

		
		[WrappingFieldAttribute(SubScript = 4, Length = 1)]
		public byte 目标背包;

		
		[WrappingFieldAttribute(SubScript = 5, Length = 1)]
		public byte 目标位置;
	}
}
