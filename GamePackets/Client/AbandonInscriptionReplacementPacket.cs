using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Client, 编号 = 78, 长度 = 11, 注释 = "AbandonInscriptionReplacementPacket")]
	public sealed class AbandonInscriptionReplacementPacket : GamePacket
	{
		
		public AbandonInscriptionReplacementPacket()
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
