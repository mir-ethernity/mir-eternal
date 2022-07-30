using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 40, 长度 = 4, 注释 = "BattleStanceSwitchPacket")]
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
