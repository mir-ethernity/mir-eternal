using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 73, Length = 4, Description = "ReplaceAdvancedInscriptionPacket")]
	public sealed class ReplaceAdvancedInscriptionPacket : GamePacket
	{
		
		public ReplaceAdvancedInscriptionPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte 装备类型;

		
		[WrappingFieldAttribute(SubScript = 3, Length = 1)]
		public byte 装备位置;
	}
}
