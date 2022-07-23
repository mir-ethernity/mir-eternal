using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 70, 长度 = 8, 注释 = "OrdinaryInscriptionRefinementPacket")]
	public sealed class OrdinaryInscriptionRefinementPacket : GamePacket
	{
		
		public OrdinaryInscriptionRefinementPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 装备类型;

		
		[WrappingFieldAttribute(下标 = 3, 长度 = 1)]
		public byte 装备位置;

		
		[WrappingFieldAttribute(下标 = 4, 长度 = 4)]
		public int Id;
	}
}
