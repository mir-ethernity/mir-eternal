using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 40, Length = 4, Description = "BattleStanceSwitchPacket")]
	public sealed class BattleStanceSwitchPacket : GamePacket
	{
		
		public BattleStanceSwitchPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public bool 切回正常姿态;

		
		[WrappingFieldAttribute(SubScript = 3, Length = 1)]
		public bool 系统自动切换;
	}
}
