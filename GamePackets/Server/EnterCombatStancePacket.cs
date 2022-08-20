using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 111, Length = 6, Description = "EnterCombatStancePacket")]
	public sealed class EnterCombatStancePacket : GamePacket
	{
		
		public EnterCombatStancePacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
