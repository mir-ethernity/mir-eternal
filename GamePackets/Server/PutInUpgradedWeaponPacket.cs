using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 256, 长度 = 2, 注释 = "PutInUpgradedWeaponPacket")]
	public sealed class PutInUpgradedWeaponPacket : GamePacket
	{
		
		public PutInUpgradedWeaponPacket()
		{
			
			
		}
	}
}
