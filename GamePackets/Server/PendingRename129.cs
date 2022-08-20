using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 255, Length = 6, Description = "OrdinaryInscriptionRefinementPacket")]
	public sealed class 玩家普通洗练 : GamePacket
	{
		
		public 玩家普通洗练()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 2)]
		public ushort 铭文位一;

		
		[WrappingFieldAttribute(SubScript = 4, Length = 2)]
		public ushort 铭文位二;
	}
}
