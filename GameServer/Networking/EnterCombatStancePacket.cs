using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 111, 长度 = 6, 注释 = "EnterCombatStancePacket")]
	public sealed class EnterCombatStancePacket : GamePacket
	{
		
		public EnterCombatStancePacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
