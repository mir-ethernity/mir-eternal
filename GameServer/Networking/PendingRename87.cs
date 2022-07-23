using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 125, 长度 = 5, 注释 = "技能升级")]
	public sealed class 玩家技能升级 : GamePacket
	{
		
		public 玩家技能升级()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 2)]
		public ushort 技能编号;

		
		[WrappingFieldAttribute(下标 = 4, 长度 = 1)]
		public byte 技能等级;
	}
}
