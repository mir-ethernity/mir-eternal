using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 141, Length = 4, Description = "武器幸运变化")]
	public sealed class 武器幸运变化 : GamePacket
	{
		
		public 武器幸运变化()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public sbyte 幸运变化;
	}
}
