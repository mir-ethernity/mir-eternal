using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 38, 长度 = 3, 注释 = "ToggleAttackMode")]
	public sealed class ToggleAttackMode : GamePacket
	{
		
		public ToggleAttackMode()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte AttackMode;
	}
}
