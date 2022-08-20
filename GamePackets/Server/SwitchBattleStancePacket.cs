using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 105, Length = 8, Description = "SwitchBattleStancePacket")]
	public sealed class SwitchBattleStancePacket : GamePacket
	{
		
		public SwitchBattleStancePacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 角色编号;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 1)]
		public bool 切回正常姿态;

		
		[WrappingFieldAttribute(SubScript = 7, Length = 1)]
		public bool 系统自动切换;
	}
}
