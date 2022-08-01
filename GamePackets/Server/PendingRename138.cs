using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 121, 长度 = 10, 注释 = "CharacterSelectionTargetPacket")]
	public sealed class 玩家选中目标 : GamePacket
	{
		
		public 玩家选中目标()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 角色编号;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 4)]
		public int 目标编号;
	}
}
