using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 256, 长度 = 2, 注释 = "PutInUpgradedWeaponPacket")]
	public sealed class PutInUpgradedWeaponPacket : GamePacket
	{
		
		public PutInUpgradedWeaponPacket()
		{
			
			
		}
	}
}
