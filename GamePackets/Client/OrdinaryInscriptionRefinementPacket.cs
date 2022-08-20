using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 70, Length = 8, Description = "OrdinaryInscriptionRefinementPacket")]
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
