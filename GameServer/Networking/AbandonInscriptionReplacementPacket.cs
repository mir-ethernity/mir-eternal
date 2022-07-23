using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 78, 长度 = 11, 注释 = "AbandonInscriptionReplacementPacket")]
	public sealed class AbandonInscriptionReplacementPacket : GamePacket
	{
		
		public AbandonInscriptionReplacementPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 装备类型;

		
		[WrappingFieldAttribute(下标 = 3, 长度 = 1)]
		public byte 装备位置;

		
		[WrappingFieldAttribute(下标 = 4, 长度 = 4)]
		public int 物品编号;
	}
}
