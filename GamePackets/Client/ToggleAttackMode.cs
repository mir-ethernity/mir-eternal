using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Client, 编号 = 38, 长度 = 3, 注释 = "ToggleAttackMode")]
	public sealed class ToggleAttackMode : GamePacket
	{
		
		public ToggleAttackMode()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte AttackMode;
	}
}
