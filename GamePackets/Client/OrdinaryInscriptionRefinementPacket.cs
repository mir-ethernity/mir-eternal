using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Client, 编号 = 70, 长度 = 8, 注释 = "OrdinaryInscriptionRefinementPacket")]
	public sealed class OrdinaryInscriptionRefinementPacket : GamePacket
	{
		
		public OrdinaryInscriptionRefinementPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte 装备类型;

		
		[WrappingFieldAttribute(SubScript = 3, Length = 1)]
		public byte 装备位置;

		
		[WrappingFieldAttribute(SubScript = 4, Length = 4)]
		public int Id;
	}
}
