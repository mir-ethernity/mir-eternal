using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 256, Length = 2, Description = "PutInUpgradedWeaponPacket")]
	public sealed class PutInUpgradedWeaponPacket : GamePacket
	{
		
		public PutInUpgradedWeaponPacket()
		{
			
			
		}
	}
}
