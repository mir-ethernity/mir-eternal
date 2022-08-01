using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Client, 编号 = 248, 长度 = 6, 注释 = "EnterMartialArtsBatllefieldPacket")]
	public sealed class EnterMartialArtsBatllefieldPacket : GamePacket
	{
		
		public EnterMartialArtsBatllefieldPacket()
		{
			
			
		}
	}
}
