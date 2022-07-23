using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 76, 长度 = 8, 注释 = "ReplaceInscriptionRefinementPacket")]
	public sealed class ReplaceInscriptionRefinementPacket : GamePacket
	{
		
		public ReplaceInscriptionRefinementPacket()
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
