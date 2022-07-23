using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 121, 长度 = 10, 注释 = "CharacterSelectionTargetPacket")]
	public sealed class 玩家选中目标 : GamePacket
	{
		
		public 玩家选中目标()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 角色编号;

		
		[WrappingFieldAttribute(下标 = 6, 长度 = 4)]
		public int 目标编号;
	}
}
