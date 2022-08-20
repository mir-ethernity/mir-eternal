using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 332, Length = 3, Description = "SyncMarfaPrivilegesPacket")]
	public sealed class SyncMarfaPrivilegesPacket : GamePacket
	{
		
		public SyncMarfaPrivilegesPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte 玛法特权;
	}
}
