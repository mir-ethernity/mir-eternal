using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 38, Length = 3, Description = "ToggleAttackMode")]
	public sealed class ToggleAttackMode : GamePacket
	{
		
		public ToggleAttackMode()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte AttackMode;
	}
}
